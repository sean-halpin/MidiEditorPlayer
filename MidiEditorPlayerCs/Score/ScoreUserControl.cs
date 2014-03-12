using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace MidiEditorPlayerCs
{
    public partial class ScoreUserControl : UserControl
    {
        #region Declarations
        //Current Midi
        private StandardMidi CurrentMidiObject;
        //Constants
        const sbyte NOTE_DOWN = 0x9;
        const sbyte NOTE_UP = 0x8;
        const int NUMBER_OF_NOTES_IN_AN_OCTAVE = 12;
        const int POINT_FLAG_VALUE = 128;
        const int NUMBER_ROWS = 128;
        const double NUMBER_CELLS_QUARTERNOTE = 16;
        const int COLUMNS_IN_16BEAT_MEASURE = 256;
        const byte TEMPO_EVENT_TYPE = 0x51;
        //Score Size
        const int ROWCOUNT = 128;
        int ColumnCount = (Properties.Settings.Default.SixteenNoteMeasureCount) * COLUMNS_IN_16BEAT_MEASURE;
        int NumberQtrNotesInABar = Properties.Settings.Default.QuarterNoteInMeasure;
        //Cell Size /Zoom
        int CellWidth = 4;
        int CellHeight = 16;
        int PianoTextSize = 10;
        //Current Mouse Position
        Point CurrentMousePosition;
        //Current Cell mouse is over
        int CurrentCellXPosition;
        int CurrentCellYPosition = POINT_FLAG_VALUE;
        //current Note Length
        int CurrentNoteLength = 0;
        //current Action
        String CurrentAction = "";
        //Current MidiChannel
        sbyte CurrentChannel = 0;
        //Current Velocity 63h 99dec
        byte CurrentNoteVelocity = 0x7F;
        //Current Tempo Event Value
        int CurrentTempo = 120;
        //Current Instrument Event Value
        byte CurrentInstrument = 1; 
        //Snapping Tool -On/Off : From Persistant Storage
        Boolean SnapperTool = Properties.Settings.Default.Snapper;
        //Select Event Variables as Cell CoOrds, (0,128) is a flag value :indicates no current select points
        Point SelectStartPoint = new Point(0, POINT_FLAG_VALUE);
        Point SelectEndPoint = new Point(0, POINT_FLAG_VALUE);
        //Resolved Rectangle
        Point RectStartPoint = new Point(0, POINT_FLAG_VALUE);
        Point RectEndPoint = new Point(0, POINT_FLAG_VALUE);
        //Selected Events
        MidiEvent[] SelectedEvents = new MidiEvent[1];
        MidiEvent[] CopiedEvents = new MidiEvent[1];
        MidiEvent[] TransposedEvents = new MidiEvent[1];
        //Bitmap for drawing BG of grid
        Bitmap GridBitMap;
            
        //Graphic for drawing notes to current 'clip rectangle'
        Graphics ScoreGraphic = null;
        Pen GridLines = new Pen(Properties.Settings.Default.GridLines);
        SolidBrush BackGround = new SolidBrush(Properties.Settings.Default.BackGround);
        Pen QtrNoteSeparator = new Pen(Properties.Settings.Default.QtrNoteSeparator);
        Pen BarSeparator = new Pen(Properties.Settings.Default.BarSeparator);
        SolidBrush  NoteFill= new SolidBrush(Properties.Settings.Default.NoteFill);
        Pen NoteOutline = new Pen(Properties.Settings.Default.NoteOutline);
        #endregion

        #region Constructors
        //New Instance of Object is Initialised
        public ScoreUserControl()
        {
            InitializeComponent();
            PaintGrid();
            PianoPictureBox.Size = new Size(PianoPictureBox.Width, NUMBER_ROWS* CellHeight);
            PaintPiano();
            CurrentMidiObject = new StandardMidi();
            
        }
        #endregion

        #region File Operations
        //Save Current Composition
        public void SaveToFile(String FilePath)
        {
            CurrentMidiObject.SaveMidiFile(FilePath);
        }

        //Open a Composition
        public void OpenFile(String FilePath)
        {
        
            CurrentMidiObject.OpenMidiFile(FilePath);
            //Calculate the amount of extra score to draw
            Properties.Settings.Default.SixteenNoteMeasureCount = ((CurrentMidiObject.FarthestEvent - (CurrentMidiObject.FarthestEvent % COLUMNS_IN_16BEAT_MEASURE))/COLUMNS_IN_16BEAT_MEASURE)+4;
            PaintGrid();
            ScorePictureBox.Refresh();
        }

        //Get the Persistant Data for the Application
        public void GetPersistentSettings()
        {
            ColumnCount = (Properties.Settings.Default.SixteenNoteMeasureCount) * COLUMNS_IN_16BEAT_MEASURE ;
            NumberQtrNotesInABar = Properties.Settings.Default.QuarterNoteInMeasure;
            GridLines = new Pen(Properties.Settings.Default.GridLines);
            BackGround = new SolidBrush(Properties.Settings.Default.BackGround);
            QtrNoteSeparator = new Pen(Properties.Settings.Default.QtrNoteSeparator);
            BarSeparator = new Pen(Properties.Settings.Default.BarSeparator);
            NoteFill = new SolidBrush(Properties.Settings.Default.NoteFill);
            NoteOutline = new Pen(Properties.Settings.Default.NoteOutline);
        }
        #endregion

        #region Drawing the Score
   
        //Draw the grid
        public void PaintGrid()
        {
            GetPersistentSettings();
            ScorePanel.VerticalScroll.SmallChange = CellHeight;
            //Create a bitmap to hold the score's grid(If the bitmap is null or its size must be changed)
            if (GridBitMap == null || ColumnCount * CellWidth != GridBitMap.Width || ROWCOUNT * CellHeight != GridBitMap.Height)
            {
                ScorePictureBox.Visible = false;
                //Release System Resources if MyBitMap already contains am image
                if (GridBitMap != null)
                    GridBitMap.Dispose();
                GridBitMap = new Bitmap(ColumnCount * CellWidth, ROWCOUNT * CellHeight);
            }
            ScoreGraphic = Graphics.FromImage(GridBitMap);
            ScoreGraphic.FillRectangle(BackGround, 0, 0, GridBitMap.Width, GridBitMap.Height);

            //Paint Columns
            for (int x = 0; x <= ColumnCount - 1; x++)
            {
                if (x%NUMBER_CELLS_QUARTERNOTE==0)
                    if (x%(NUMBER_CELLS_QUARTERNOTE*NumberQtrNotesInABar)==0)
                        ScoreGraphic.DrawLine(BarSeparator, x * CellWidth, 0, x * CellWidth, ROWCOUNT * CellHeight);
                    else
                        ScoreGraphic.DrawLine(QtrNoteSeparator, x * CellWidth, 0, x * CellWidth, ROWCOUNT * CellHeight);
                else
                    ScoreGraphic.DrawLine(GridLines, x * CellWidth, 0, x * CellWidth, ROWCOUNT * CellHeight);
            }
            //Paint Rows
            for (int y = 0; y <= ROWCOUNT - 1; y++)
            {
                if (y%NUMBER_OF_NOTES_IN_AN_OCTAVE == 11)
                    ScoreGraphic.DrawLine(BarSeparator, 0, y * CellHeight, ColumnCount * CellWidth, y * CellHeight);
                else
                    ScoreGraphic.DrawLine(GridLines, 0, y * CellHeight, ColumnCount * CellWidth, y * CellHeight);
            }
          
            //Add bitmap with grid to BG
            ScorePictureBox.Image = GridBitMap;
            ScorePictureBox.Visible = true;
            //Release Resources
            ScoreGraphic.Dispose();
        }

        //Draw Visual Referance Piano
        public void PaintPiano()
        {
            String[] Notes = { "G", "F#", "F", "E", "D#", "D", "C#", "C", "B", "Bb", "A", "G#"};
            PianoPanel.VerticalScroll.SmallChange = CellHeight;
            //Create a bitmap to hold the piano
            GridBitMap = new Bitmap(PianoPictureBox.Width, ScorePictureBox.Height);
            ScoreGraphic = Graphics.FromImage(GridBitMap);
            ScoreGraphic.FillRectangle(Brushes.White, 0, 0, GridBitMap.Width, GridBitMap.Height);
            for (int y = 0; y < ROWCOUNT; y++)
            {
                switch (y % NUMBER_OF_NOTES_IN_AN_OCTAVE)
                {
                    case 1:
                    case 4:
                    case 6:
                    case 9:
                    case 11:
                        ScoreGraphic.FillRectangle(Brushes.Black, 0, y * CellHeight, PianoPictureBox.Width - 2, CellHeight);
                        break;
                    case 7:
                        ScoreGraphic.DrawString(Notes[(y % NUMBER_OF_NOTES_IN_AN_OCTAVE)] + Convert.ToString((((NUMBER_ROWS - y) / NUMBER_OF_NOTES_IN_AN_OCTAVE) - 5)), new Font("Arial", PianoTextSize), Brushes.Chocolate, new Point(5, y * CellHeight));
                        ScoreGraphic.DrawRectangle(Pens.Black, 0, y * CellHeight, PianoPictureBox.Width - 2, CellHeight);
                        break;
                    default:
                        ScoreGraphic.DrawString(Notes[(y % NUMBER_OF_NOTES_IN_AN_OCTAVE)], new Font("Arial", PianoTextSize), Brushes.Chocolate, new Point(5, y * CellHeight));
                        ScoreGraphic.DrawRectangle(Pens.Black, 0, y * CellHeight, PianoPictureBox.Width - 2, CellHeight);
                        break;
                }
            }
            //Add bitmap with grid to BG
            PianoPictureBox.BackgroundImage = GridBitMap;
            //Release Resources
            ScoreGraphic.Dispose();
        }

        //Show Selected Note on Piano
        public void RefPianoNote()
        {
            GridBitMap = new Bitmap(PianoPictureBox.Width, ScorePictureBox.Height);
            ScoreGraphic = Graphics.FromImage(GridBitMap);
            ScoreGraphic.FillEllipse(Brushes.Red, 30, CurrentCellYPosition * CellHeight+1, CellHeight-1, CellHeight-2);
            PianoPictureBox.Image = GridBitMap;
        }
        #endregion

        #region Paint Events onto Score
        //Paint Events
        public void PaintEvents(PaintEventArgs e)
        {
            //Get a copy of currentMidiObjects Events
            MidiEvent[] CurrentMidiEvents = new MidiEvent[0];
            Array.Resize(ref CurrentMidiEvents, CurrentMidiObject.Track.Events.Length);
            Array.Copy(CurrentMidiObject.Track.Events, CurrentMidiEvents, CurrentMidiObject.Track.Events.Length);

            if (CurrentMidiEvents != null && CurrentMidiEvents.Length > 0 && CurrentMidiEvents[0] != null)
            {
                MidiEvent CurrentEvent = null;
                for (int EventIndex = 0; EventIndex <= CurrentMidiEvents.Length - 1; EventIndex++)
                {
                    CurrentEvent = CurrentMidiEvents[EventIndex];
                    //Paint Tempo Events : Paint all TempoEvents before NoteDown Events, for depth
                    if (CurrentEvent is TempoMidiEvent)
                    {
                        TempoMidiEvent CurrentTempoEvent = (TempoMidiEvent)CurrentEvent;
                        e.Graphics.FillRectangle(Brushes.Yellow, (CurrentTempoEvent.CellPosition * CellWidth) + (CellWidth / 2), 0, (CellWidth / 2), ROWCOUNT * CellHeight);
                    }
                    //Paint InstrumentEvents : Paint all InstrumentEvents before NoteDown Events, for depth
                    if (CurrentEvent is InstrumentMidiEvent)
                    {
                        InstrumentMidiEvent CurrentTempoEvent = (InstrumentMidiEvent)CurrentEvent;
                        e.Graphics.FillRectangle(Brushes.Red, (CurrentTempoEvent.CellPosition * CellWidth), 0, (CellWidth / 2), ROWCOUNT * CellHeight );
                    }
                }
                //for each Note
                for (int EventIndex = 0; EventIndex <= CurrentMidiEvents.Length - 1; EventIndex++)
                {
                    CurrentEvent = CurrentMidiEvents[EventIndex];
                    //Paint note events
                    if (CurrentEvent.Type == NOTE_DOWN)
                    {
                        //Paint notes
                        e.Graphics.FillRectangle(NoteFill, CurrentEvent.CellPosition * CellWidth, (127 - CurrentEvent.Paramater1) * CellHeight, CurrentEvent.Length * CellWidth, CellHeight);
                        e.Graphics.DrawRectangle(NoteOutline, CurrentEvent.CellPosition * CellWidth, (127 - CurrentEvent.Paramater1) * CellHeight, CurrentEvent.Length * CellWidth, CellHeight);
                    }
                }
                //for each selected note
                if (SelectedEvents != null && SelectedEvents.Length > 0 && SelectedEvents[0] != null)
                {
                    for (int EventIndex = 0; EventIndex <= SelectedEvents.Length - 1; EventIndex++)
                    {
                        CurrentEvent = SelectedEvents[EventIndex];
                        //Paint note events
                        if (CurrentEvent.Type == NOTE_DOWN)
                        {
                            //Paint notes
                            e.Graphics.FillRectangle(Brushes.Red, CurrentEvent.CellPosition * CellWidth, (127 - CurrentEvent.Paramater1) * CellHeight, CurrentEvent.Length * CellWidth, CellHeight);
                            e.Graphics.DrawRectangle(Pens.Black, CurrentEvent.CellPosition * CellWidth, (127 - CurrentEvent.Paramater1) * CellHeight, CurrentEvent.Length * CellWidth, CellHeight);
                        }
                    }
                }
                e.Dispose();
            }
        }

        //PaintSelectionRectangle
        private void PaintSelectionRectangle(PaintEventArgs e)
        {
            if (SelectStartPoint.X != SelectEndPoint.X && SelectStartPoint.Y != SelectEndPoint.Y)
            {
                e.Graphics.DrawRectangle(Pens.DarkRed, RectStartPoint.X, RectStartPoint.Y, (RectEndPoint.X) - (RectStartPoint.X), (RectEndPoint.Y) - (RectStartPoint.Y));
                e.Graphics.DrawRectangle(Pens.DarkRed, RectStartPoint.X - 1, RectStartPoint.Y - 1, (RectEndPoint.X) - (RectStartPoint.X) + 2, (RectEndPoint.Y) - (RectStartPoint.Y) + 2);
            }
        }
        #endregion

        #region Score Events

        //Paint PictureBox Event
        private void ScorePictureBox_Paint(object sender, PaintEventArgs e)
        {
            PaintEvents(e);
            PaintSelectionRectangle(e);
        }

        //Resize the Panel with the Control
        private void ScoreUserControl_Resize(object sender, EventArgs e)
        {
            ReSizeGUIComponents();
        }

        //As the score is scrolled, move the visual piano in sync
        private void ScorePanel_Scroll(object sender, ScrollEventArgs e)
        {
            ReSizeGUIComponents();
        }

        //Calculate Current MousePosition & relative Cell Value, Calculate Selection Rectangle
        public void ScorePictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            //Give the Score focus, to allow mouse scroll Up/Down.
            ScorePanel.Focus();
            try
            {
                CurrentMousePosition.X = MousePosition.X - this.Parent.Location.X - ScorePictureBox.Location.X - 73;
                CurrentMousePosition.Y = MousePosition.Y - this.Parent.Location.Y - ScorePictureBox.Location.Y - 98;
                CurrentCellXPosition = (CurrentMousePosition.X / CellWidth);
                CurrentCellYPosition = (CurrentMousePosition.Y / CellHeight);
                if (CurrentAction == "note" && SnapperTool == true && CurrentNoteLength!=0)
                {
                    //If Snapper is on, Snap to nearest musically relevant position
                    CurrentCellXPosition = (CurrentCellXPosition - CurrentCellXPosition % CurrentNoteLength);
                    CurrentMousePosition.X = CurrentCellXPosition * CellWidth;
                }
            }
            catch {/*do nothing*/ }
            // Create the selection rectangle from my selection start and end points.
            if (CurrentAction == "select" && SelectStartPoint.Y != POINT_FLAG_VALUE)
            {
                SelectEndPoint = CurrentMousePosition;
                RectStartPoint = SelectStartPoint;
                RectEndPoint = SelectEndPoint;
                if (SelectStartPoint.X <= SelectEndPoint.X)
                {
                    //Do not swap X's
                    if (SelectStartPoint.Y <= SelectEndPoint.Y)
                    { /*Leave them*/
                      
                    }
                    else
                    {/*Swap Y's*/
                        RectStartPoint = new Point(RectStartPoint.X, SelectEndPoint.Y);
                        RectEndPoint = new Point(RectEndPoint.X, SelectStartPoint.Y);
                    }
                }
                else
                {//Swap X's
                    RectStartPoint = new Point(SelectEndPoint.X, RectStartPoint.Y);
                    RectEndPoint = new Point(SelectStartPoint.X, RectEndPoint.Y);
                    if (SelectStartPoint.Y <= SelectEndPoint.Y)
                    { /*Leave them*/ }
                    else
                    { /*Swap Y's*/
                        RectStartPoint = new Point(RectStartPoint.X, SelectEndPoint.Y);
                        RectEndPoint = new Point(RectEndPoint.X, SelectStartPoint.Y);
                    }
                }
                ScorePictureBox.Refresh();
            }
        }
        //When the score is clicked
        private void ScorePictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            //Get a copy of currentMidiObjects Events
            MidiEvent[] CurrentMidiEvents = new MidiEvent[0];
            Array.Resize(ref CurrentMidiEvents, CurrentMidiObject.Track.Events.Length);
            Array.Copy(CurrentMidiObject.Track.Events, CurrentMidiEvents, CurrentMidiObject.Track.Events.Length);

            //Select Current Action
            switch (CurrentAction)
            {
                case "note":
                    CurrentMidiObject.Track.Events = AddNote(CurrentMidiEvents, new MidiEvent(CurrentCellXPosition, CurrentNoteLength,0, NOTE_DOWN, CurrentChannel, Convert.ToByte(127 - CurrentCellYPosition), CurrentNoteVelocity));
                    break;
                case "delete":
                    DeleteEvent(CurrentMidiEvents, e);
                    break;
                case "tempo":
                    AddTempoEvent(CurrentMidiEvents, CurrentTempo);
                    break;
                case "instrument":
                    AddInstrumentEvent(CurrentMidiEvents, CurrentInstrument);
                    break;
                default:
                    break;
            }
            ScorePictureBox.Refresh();
        }
        //Mouse Down over score
        private void ScorePictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            //Record the mouseDown position as Cell CoOrds
            if (CurrentAction == "select")
            {
                SelectStartPoint = CurrentMousePosition;
            }
        }
        //Mouse Down over score
        private void ScorePictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            //Record the mouseUp position as Cell CoOrds
            if (CurrentAction == "select" && (SelectStartPoint.Y != POINT_FLAG_VALUE) && (SelectEndPoint.Y != POINT_FLAG_VALUE))
            {
                //Record the selected Notes!
                RecordSelectedNotes(RectStartPoint, RectEndPoint);
            
                //Reset to Flag Points
                SelectStartPoint = new Point(0, POINT_FLAG_VALUE);
                SelectEndPoint = new Point(0, POINT_FLAG_VALUE);
                ScorePictureBox.Refresh();
            }
        }
        #endregion   

        #region Methods

        //Determine the tempo at a certain cell
        public int TempoAtPosition(int MyCellPosition)
        {
            int Tempo = 0;
            //Get a copy of currentMidiObjects Events
            MidiEvent[] CurrentMidiEvents = new MidiEvent[0];
            Array.Resize(ref CurrentMidiEvents, CurrentMidiObject.Track.Events.Length);
            Array.Copy(CurrentMidiObject.Track.Events, CurrentMidiEvents, CurrentMidiObject.Track.Events.Length);

            for (int EventIndex = 0; EventIndex < CurrentMidiEvents.Length; EventIndex++)
            {
                if (CurrentMidiEvents[EventIndex] is TempoMidiEvent && CurrentMidiEvents[EventIndex].CellPosition <= MyCellPosition)
                {
                    TempoMidiEvent CurrentTempoEvent = (TempoMidiEvent)CurrentMidiEvents[EventIndex];
                    Tempo = (CurrentTempoEvent.Tempo);
                }
            }
            //If no Tempo event is present or found, Midi assumes 120 beats per minutes
            if (Tempo == 0)
                Tempo = 120;
            return Tempo;
        }
        //Determine the Instrument number at a certain cell
        public byte InstrumentAtPosition(int MyCellPosition)
        {
            byte Instrument = 0;
            //Get a copy of currentMidiObjects Events
            MidiEvent[] CurrentMidiEvents = new MidiEvent[0];
            Array.Resize(ref CurrentMidiEvents, CurrentMidiObject.Track.Events.Length);
            Array.Copy(CurrentMidiObject.Track.Events, CurrentMidiEvents, CurrentMidiObject.Track.Events.Length);
            //check each event
            for (int EventIndex = 0; EventIndex < CurrentMidiEvents.Length; EventIndex++)
            {
                //Update Current Instrument, to be the Instrument closest to the mouseposition, but still to the left(time)
                if (CurrentMidiEvents[EventIndex] is InstrumentMidiEvent && CurrentMidiEvents[EventIndex].CellPosition <= MyCellPosition)
                {
                    InstrumentMidiEvent CurrentInstrumentEvent = (InstrumentMidiEvent)CurrentMidiEvents[EventIndex];
                    //Parameter1 Holds the Instrument value
                    Instrument = (CurrentInstrumentEvent.Paramater1);
                }
            }
            //If no Instrument event is found, midi assumes instrument 0, Acoustice Grand Piano
          
            return Instrument;
        }

        //Record Selected Notes
        public void RecordSelectedNotes(Point Start, Point End)
        {
            //Clear Selected Events
            Array.Resize(ref SelectedEvents, 1);
            SelectedEvents[0]= null;
            //Get a copy of currentMidiObjects Events
            MidiEvent[] CurrentMidiEvents = new MidiEvent[0];
            Array.Resize(ref CurrentMidiEvents, CurrentMidiObject.Track.Events.Length);
            Array.Copy(CurrentMidiObject.Track.Events, CurrentMidiEvents, CurrentMidiObject.Track.Events.Length);
            if(CurrentMidiEvents!=null && CurrentMidiEvents.Length>0 && CurrentMidiEvents[0]!=null)
                for (int EventIndex = 0; EventIndex < CurrentMidiEvents.Length; EventIndex++)
                {
                    if (CurrentMidiEvents[EventIndex].Type == NOTE_DOWN &&
                        Start.X / CellWidth <= CurrentMidiEvents[EventIndex].CellPosition &&
                        Start.X / CellWidth < CurrentMidiEvents[EventIndex].CellPosition + CurrentMidiEvents[EventIndex].Length &&
                        End.X / CellWidth > CurrentMidiEvents[EventIndex].CellPosition &&
                        End.X / CellWidth >= CurrentMidiEvents[EventIndex].CellPosition + CurrentMidiEvents[EventIndex].Length &&
                        Start.Y / CellHeight <= (127 - CurrentMidiEvents[EventIndex].Paramater1) &&
                        End.Y / CellHeight >= (127 - CurrentMidiEvents[EventIndex].Paramater1))
                    {
                        //Resize the array for new events
                        if (SelectedEvents.Length == 1 && SelectedEvents[0] == null)
                            Array.Resize(ref SelectedEvents, SelectedEvents.Length + 1);
                        else
                            Array.Resize(ref SelectedEvents, SelectedEvents.Length + 2);
                        //add note down event(with length: to calculate noteUp events later)
                        SelectedEvents[SelectedEvents.Length - 2] = CurrentMidiEvents[EventIndex];
                        //add relative up down event
                        SelectedEvents[SelectedEvents.Length - 1] = new MidiEvent(CurrentMidiEvents[EventIndex].CellPosition + CurrentMidiEvents[EventIndex].Length, 0, 0, NOTE_UP, CurrentMidiEvents[EventIndex].Channel, CurrentMidiEvents[EventIndex].Paramater1, CurrentMidiEvents[EventIndex].Paramater2);
                    }
            }
        }

        //Copy Selected Notes to 'Clipboard' CopiedEvents[]
        public void CopySelectedNotesToCopiedEvents()
        {
            Array.Resize(ref CopiedEvents, SelectedEvents.Length);
            Array.Copy(SelectedEvents, CopiedEvents, SelectedEvents.Length);
        }

        //Paste Selected Notes
        public void PasteCopiedNotes()
        {
            int SmallestCellXPos = 0;
            int SmallestCellYPos = 0;
            if (CopiedEvents != null && CopiedEvents.Length > 0 && CopiedEvents[0] != null)
            {
                //Find the Earliest Note, and the Highest note, from copied event
                for (int EventIndex = 0; EventIndex < CopiedEvents.Length; EventIndex++)
                {
                    if (EventIndex == 0)
                    {
                        SmallestCellXPos = CopiedEvents[EventIndex].CellPosition;
                        SmallestCellYPos = 127-CopiedEvents[EventIndex].Paramater1;
                    }
                    if (CopiedEvents[EventIndex].CellPosition <SmallestCellXPos)
                        SmallestCellXPos = CopiedEvents[EventIndex].CellPosition;
                    if (127 - CopiedEvents[EventIndex].Paramater1 < SmallestCellYPos)
                        SmallestCellYPos = 127 - CopiedEvents[EventIndex].Paramater1;
                }
                //MidiEvent FirstEvent = new MidiEvent();
                //FirstEvent = CopiedEvents[0];
                for (int EventIndex = 0; EventIndex < CopiedEvents.Length; EventIndex++)
                {
                    //If the note to be pastes is a note down, and occurs within the boundaries of the score
                    if (CopiedEvents[EventIndex].Type == NOTE_DOWN &&
                        (CopiedEvents[EventIndex].Paramater1 - (127-SmallestCellYPos) + (127 - CurrentCellYPosition)) <=127 &&
                        (CopiedEvents[EventIndex].Paramater1 - (127-SmallestCellYPos) + (127 - CurrentCellYPosition)) >= 0 &&
                        CopiedEvents[EventIndex].CellPosition - (SmallestCellXPos) + (CurrentCellXPosition) >= 0)
                    {
                        //Get a copy of currentMidiObjects Events
                        MidiEvent[] CurrentMidiEvents = new MidiEvent[0];
                        Array.Resize(ref CurrentMidiEvents, CurrentMidiObject.Track.Events.Length);
                        Array.Copy(CurrentMidiObject.Track.Events, CurrentMidiEvents, CurrentMidiObject.Track.Events.Length);

                        Array.Resize(ref TransposedEvents, CopiedEvents.Length);
                        //Transform All Copied Events to new Location
                        TransposedEvents[EventIndex] = new MidiEvent(
                        CopiedEvents[EventIndex].CellPosition - SmallestCellXPos + CurrentCellXPosition,
                        CopiedEvents[EventIndex].Length,
                        0,
                        CopiedEvents[EventIndex].Type,
                        CopiedEvents[EventIndex].Channel,
                        Convert.ToByte(CopiedEvents[EventIndex].Paramater1 - (127-SmallestCellYPos) + (127 - CurrentCellYPosition)),
                        CopiedEvents[EventIndex].Paramater2);
                        //Update Current Midi Object with new Notes
                        CurrentMidiObject.Track.Events = AddNote(CurrentMidiEvents, TransposedEvents[EventIndex]);
                    }
                }
            }
        }

        //Delete Copied Notes
        public void DeleteCopiedNotes()
        {
            for (int EventIndex = 0; EventIndex < CopiedEvents.Length; EventIndex++)
            {
                CurrentMidiObject.Track.Events = RemoveEventFromArray(CurrentMidiObject.Track.Events, CopiedEvents[EventIndex]);
            }
        }

        //Clear Selected Notes
        public void ClearSelectedNoteArrays()
        {
            //Clear, Resisize and Initialise Selected Events Array
            Array.Clear(SelectedEvents,0,SelectedEvents.Length);
            Array.Resize(ref SelectedEvents, 1);
            SelectedEvents[0] = new MidiEvent();

            Array.Clear(TransposedEvents, 0, TransposedEvents.Length);
            Array.Resize(ref TransposedEvents, 1);
            TransposedEvents[0] = new MidiEvent();
        }

        //Clear Copied Notes
        public void ClearCopiedNoteArrays()
        {
            //Clear, Resisize and Initialise Copied Events Array
            Array.Clear(CopiedEvents, 0, CopiedEvents.Length);
            Array.Resize(ref CopiedEvents, 1);
            CopiedEvents[0] = new MidiEvent();
        }

        //Keep Gui components visible
        public void ReSizeGUIComponents()
        {
            ScorePanel.Height = this.Size.Height;
            ScorePanel.Width = this.Size.Width - 55;
            PianoPanel.Height = ScorePanel.Height - 18;
            PianoPictureBox.Location = new Point(0, ScorePictureBox.Location.Y);
            RefPianoNote();
        }

        //Add NoteDown & NoteUp Events : Sort Events
        public void AddTempoEvent(MidiEvent[] CurrentMidiEvents, int BPM)
        {
            if (ValidateTempoPlacement(CurrentMidiEvents, new TempoMidiEvent(0,CurrentCellXPosition, BPM)))
            {
                //Resize the array for new events
                if (CurrentMidiEvents[0] == null)
                    Array.Resize(ref CurrentMidiEvents, CurrentMidiEvents.Length);
                else
                    Array.Resize(ref CurrentMidiEvents, CurrentMidiEvents.Length + 1);
                //add tempo event
                CurrentMidiEvents[CurrentMidiEvents.Length - 1] = new TempoMidiEvent(0,CurrentCellXPosition, BPM) ;
                Array.Sort(CurrentMidiEvents);
                //Update the CurrentMidiObjectsEvents
                CurrentMidiObject.Track.Events = CurrentMidiEvents;
            }
        }

        //Validate tempo event, to avoid overlapping
        public Boolean ValidateTempoPlacement(MidiEvent[] CurrentMidiEvents, MidiEvent CurrentEvent)
        {
            //Caste current event to TempoEvent
            TempoMidiEvent CurrentTempoEvent = (TempoMidiEvent)CurrentEvent;
            //If there are no events at the moment, return true
            if (CurrentMidiEvents.Length == 0 || CurrentMidiEvents[0] == null)
                return true;
            for (int i = 0; i < CurrentMidiEvents.Length; i++)
            {
                //for each event that is a TempoMidiEvent, check for overlapping location
                if (CurrentMidiEvents[i] is TempoMidiEvent &&
                    CurrentMidiEvents[i].CellPosition == CurrentTempoEvent.CellPosition)
                {
                    //if there is an overlap, return false. Event will not be placed
                    return false;
                }
            }
            //If there is no tempo event here, return true
            return true;
        }

        //Add NoteDown & NoteUp Events : Sort Events
        public void AddInstrumentEvent(MidiEvent[] CurrentMidiEvents, byte InstrumentNumber)
        {
            //Validate the placement
            if (ValidateInstrumentPlacement(CurrentMidiEvents, new InstrumentMidiEvent(0, CurrentCellXPosition, CurrentChannel, InstrumentNumber)))
            {
                //Resize the array for new events
                if (CurrentMidiEvents[0] == null)
                    Array.Resize(ref CurrentMidiEvents, CurrentMidiEvents.Length);
                else
                    Array.Resize(ref CurrentMidiEvents, CurrentMidiEvents.Length + 1);
                //add instrument event
                CurrentMidiEvents[CurrentMidiEvents.Length - 1] = new InstrumentMidiEvent(0,CurrentCellXPosition,CurrentChannel,InstrumentNumber);
                Array.Sort(CurrentMidiEvents);
                //Update the CurrentMidiObjectsEvents
                CurrentMidiObject.Track.Events = CurrentMidiEvents;
            }
        }

        //Validate Instrument event, to avoid overlapping
        public Boolean ValidateInstrumentPlacement(MidiEvent[] CurrentMidiEvents, MidiEvent CurrentEvent)
        {
            //Caste current event to TempoEvent
            InstrumentMidiEvent CurrentTempoEvent = (InstrumentMidiEvent)CurrentEvent;
            //If there are no events at the moment, return true
            if (CurrentMidiEvents.Length == 0 || CurrentMidiEvents[0] == null)
                return true;
            for (int i = 0; i < CurrentMidiEvents.Length; i++)
            {
                //for each event that is a InstrumentMidiEvent, check for overlapping location
                if (CurrentMidiEvents[i] is InstrumentMidiEvent &&
                    CurrentMidiEvents[i].CellPosition == CurrentTempoEvent.CellPosition)
                {
                    //if there is an overlap, return false. Event will not be placed
                    return false;
                }
            }
            //If there is no instrument event here, return true
            return true;
        }

        //Add NoteDown to an Array
        public MidiEvent[] AddNote(MidiEvent[] CurrentMidiEvents, MidiEvent NewNoteDown)
        {
            if (ValidateNotePlacement(CurrentMidiEvents,NewNoteDown))
            {
                //Resize the array for new events
                if (CurrentMidiEvents.Length == 1 && CurrentMidiEvents[0] == null)
                    Array.Resize(ref CurrentMidiEvents, CurrentMidiEvents.Length + 1);
                else
                    Array.Resize(ref CurrentMidiEvents, CurrentMidiEvents.Length + 2);
                //add note down event(with length: to calculate noteUp events later)
                CurrentMidiEvents[CurrentMidiEvents.Length - 2] = NewNoteDown;
                //add relative up down event
                CurrentMidiEvents[CurrentMidiEvents.Length - 1] = new MidiEvent(NewNoteDown.CellPosition + NewNoteDown.Length,0, 0, NOTE_UP, NewNoteDown.Channel, NewNoteDown.Paramater1, NewNoteDown.Paramater2);
                //
                Array.Sort(CurrentMidiEvents);
            }
            return CurrentMidiEvents;
        }

        //Remove Instrument/Tempo/Midi Event from CurrentMidi Object
        public void DeleteEvent(MidiEvent[] CurrentMidiEvents, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    
                    for (int EventIndex = 0; EventIndex < CurrentMidiEvents.Length; EventIndex++)
                    {
                        #region Search for Note to Delete
                        if ((CurrentMidiEvents[EventIndex].Type == NOTE_DOWN &&
                            CurrentMidiEvents[EventIndex].Paramater1 == 127 - CurrentCellYPosition) &&
                            (CurrentCellXPosition >= CurrentMidiEvents[EventIndex].CellPosition &&
                            CurrentCellXPosition < CurrentMidiEvents[EventIndex].CellPosition + CurrentMidiEvents[EventIndex].Length))
                        //if the current Cell is within the bounds of a note
                        {
                            for (int NoteUpIndex = EventIndex + 1; NoteUpIndex < (CurrentMidiEvents.Length); NoteUpIndex++)
                            {
                                if (CurrentMidiEvents[NoteUpIndex].Type == 0x08 && (CurrentMidiEvents[NoteUpIndex].Paramater1 == CurrentMidiEvents[EventIndex].Paramater1))
                                {
                                    for (int i = NoteUpIndex; i < CurrentMidiEvents.Length - 1; i++)
                                    {
                                        CurrentMidiEvents[i] = CurrentMidiEvents[i + 1];
                                    }
                                    for (int i = EventIndex; i < CurrentMidiEvents.Length - 2; i++)
                                    {
                                        CurrentMidiEvents[i] = CurrentMidiEvents[i + 1];
                                    }
                                    if (CurrentMidiEvents.Length == 2)
                                    {
                                        Array.Resize(ref CurrentMidiEvents, 0);
                                    }
                                    else
                                        Array.Resize(ref CurrentMidiEvents, CurrentMidiEvents.Length - 2);
                                    //finish
                                    EventIndex = CurrentMidiEvents.Length;
                                    break;
                                }
                            }
                        }
                        if (EventIndex == CurrentMidiEvents.Length)
                            break;
                        #endregion
                        #region Search Instrument Event
                        if (CurrentMidiEvents[EventIndex] is InstrumentMidiEvent && EventIndex != CurrentMidiEvents.Length)
                        //if the current Cell is within the bounds of a note
                        {
                            InstrumentMidiEvent CurrentInstrumentEvent = (InstrumentMidiEvent)CurrentMidiEvents[EventIndex];
                            if (CurrentInstrumentEvent.CellPosition == CurrentCellXPosition)
                            {
                                for (int i = EventIndex; i < CurrentMidiEvents.Length - 1; i++)
                                {
                                    CurrentMidiEvents[i] = CurrentMidiEvents[i + 1];
                                }
                                if (CurrentMidiEvents.Length == 1)
                                {
                                    Array.Resize(ref CurrentMidiEvents, 0);
                                }
                                else
                                    Array.Resize(ref CurrentMidiEvents, CurrentMidiEvents.Length - 1);
                                //finish
                                EventIndex = CurrentMidiEvents.Length;
                                break;
                            }
                        }
                        if (EventIndex == CurrentMidiEvents.Length)
                            break;
                        #endregion
                    }
                    //Update the Track Events
                    CurrentMidiObject.Track.Events = CurrentMidiEvents;
                    break;
                case MouseButtons.Right:
                    for (int EventIndex = 0; EventIndex < CurrentMidiEvents.Length; EventIndex++)
                    {
                       
                        #region Search tempo event
                        if (CurrentMidiEvents[EventIndex] is TempoMidiEvent && EventIndex != CurrentMidiEvents.Length)
                        //if the current Cell is within the bounds of a note
                        {
                            TempoMidiEvent CurrentTempoEvent = (TempoMidiEvent)CurrentMidiEvents[EventIndex];
                            if (CurrentTempoEvent.CellPosition == CurrentCellXPosition)
                            {
                                for (int i = EventIndex; i < CurrentMidiEvents.Length - 1; i++)
                                {
                                    CurrentMidiEvents[i] = CurrentMidiEvents[i + 1];
                                }
                                if (CurrentMidiEvents.Length == 1)
                                {
                                    Array.Resize(ref CurrentMidiEvents, 0);
                                }
                                else
                                    Array.Resize(ref CurrentMidiEvents, CurrentMidiEvents.Length - 1);
                                //finish
                                EventIndex = CurrentMidiEvents.Length;
                                break;
                            }
                        }
                        if (EventIndex == CurrentMidiEvents.Length)
                            break;
                        #endregion
                    }
                    //Update the Track Events
                    CurrentMidiObject.Track.Events = CurrentMidiEvents;
                    break;
                default:
                    break;   
            }
        }
    
        //Remove an Event an Array
        public MidiEvent[] RemoveEventFromArray(MidiEvent[] CurrentMidiEvents, MidiEvent RemoveEvent)
        {
            Boolean EventRemoved = false;
            if (RemoveEvent != null)
            {
                for (int EventIndex = 0; EventIndex < CurrentMidiEvents.Length; EventIndex++)
                {
                    if (CurrentMidiEvents[EventIndex].CellPosition == RemoveEvent.CellPosition &&
                        CurrentMidiEvents[EventIndex].Channel == RemoveEvent.Channel &&
                        CurrentMidiEvents[EventIndex].Length == RemoveEvent.Length &&
                        CurrentMidiEvents[EventIndex].Paramater1 == RemoveEvent.Paramater1 &&
                        CurrentMidiEvents[EventIndex].Paramater2 == RemoveEvent.Paramater2 &&
                        CurrentMidiEvents[EventIndex].Type == RemoveEvent.Type)
                    {
                        for (int i = EventIndex; i < CurrentMidiEvents.Length - 1; i++)
                        {
                            CurrentMidiEvents[i] = CurrentMidiEvents[i + 1];
                        }
                        //break outer loop
                        EventIndex = CurrentMidiEvents.Length;
                        EventRemoved = true;
                    }
                }
                //resize array
                if (EventRemoved)
                {
                    if (CurrentMidiEvents.Length == 1 || CurrentMidiEvents.Length == 0)
                        Array.Resize(ref CurrentMidiEvents, 0);
                    else
                        Array.Resize(ref CurrentMidiEvents, CurrentMidiEvents.Length - 1);
                }
            }
            return CurrentMidiEvents;
        }

        //Make sure notes will not overlap
        public Boolean ValidateNotePlacement(MidiEvent[] CurrentMidiEvents, MidiEvent CurrentEvent)
        {
            if (CurrentMidiEvents.Length == 0 || CurrentMidiEvents[0] == null)
                return true;
            for (int i = 0; i < CurrentMidiEvents.Length; i++)
            {
                if (CurrentMidiEvents[i].Type == NOTE_DOWN &&
                    CurrentMidiEvents[i].Paramater1 == CurrentEvent.Paramater1)
                {
                    if (CurrentEvent.CellPosition < 0)
                        //if The Note to be placed, begins outside the score
                        return false;
                    if (CurrentEvent.Paramater1 < 0 || CurrentEvent.Paramater1 >127)
                        //if The Note to be placed, occurs above or below the score Horizontally
                        return false;
                    if (CurrentEvent.CellPosition >= CurrentMidiEvents[i].CellPosition &&
                        CurrentEvent.CellPosition < CurrentMidiEvents[i].CellPosition + CurrentMidiEvents[i].Length)
                        //if The Note to be placed, begins within the bounds of another note
                        return false;
                    if (CurrentEvent.CellPosition + CurrentNoteLength > CurrentMidiEvents[i].CellPosition &&
                        CurrentEvent.CellPosition + CurrentNoteLength < CurrentMidiEvents[i].CellPosition + CurrentMidiEvents[i].Length)
                        //if The Note to be placed, ends withing the bounds of another note
                        return false;
                    if (CurrentMidiEvents[i].CellPosition > CurrentEvent.CellPosition &&
                        CurrentMidiEvents[i].CellPosition < CurrentEvent.CellPosition + CurrentEvent.Length)
                        //if a note begins within the bounds of the note to be placed
                        return false;
                    if (CurrentMidiEvents[i].CellPosition + CurrentMidiEvents[i].Length < CurrentEvent.CellPosition &&
                        CurrentMidiEvents[i].CellPosition + CurrentMidiEvents[i].Length > CurrentEvent.CellPosition + CurrentEvent.Length)
                        //if a note ends within the bounds of the note to be placed
                        return false;
                }
            }
            //If none of the exceptions occured return true, so the note may be placed
            return true;
        }
        #endregion

        #region Accessors
        public Boolean Snapper
        {
            get { return SnapperTool; }
            set { 
                SnapperTool = value;
                Properties.Settings.Default.Snapper = value;
                Properties.Settings.Default.Save();
                }
        }
        public int NoteLength
        {
            get { return CurrentNoteLength; }
            set { CurrentNoteLength = value; }
        }
        public String Action
        {
            get { return CurrentAction; }
            set { CurrentAction = value; }
        }
        public sbyte Channel
        {
            get { return CurrentChannel; }
            set { CurrentChannel = value; }
        }
        public int Tempo
        {
            get { return CurrentTempo; }
            set { CurrentTempo = value; }
        }
        public byte Instrument
        {
            get { return CurrentInstrument; }
            set { CurrentInstrument = value; }
        }
        public Point CurrentCell
        {
            get { return new Point(CurrentCellXPosition,CurrentCellYPosition); }
        }
        public Point CurrentCellSize
        {
            get { return new Point(CellWidth, CellHeight); }
        }
        public Point Zoom
        {
            get { return new Point(CellWidth, CellHeight); }
            set
            {
                CellWidth = value.X;
                CellHeight = value.Y;
                PianoTextSize = Convert.ToInt32(value.Y * 0.6);
                PianoPictureBox.Size = new Size(PianoPictureBox.Width, NUMBER_ROWS * CellHeight);
                //refresh score with new settings
                PaintGrid();
                PaintPiano();
                ReSizeGUIComponents();
            }
        }

        public StandardMidi CurrentMidi
        {
            get { return CurrentMidiObject; }
        }

        public int NumberOfColumns
        {
            get { return ColumnCount; }
            set { ColumnCount = value; }
        }
        #endregion
    }
}