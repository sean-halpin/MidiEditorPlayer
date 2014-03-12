using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace MidiEditorPlayerCs
{
    public partial class MainForm : Form
    {
        #region Declarations
        const double NUMBER_CELLS_QTR_BEAT = 16;

        MMTimer PlayBackTimer = new MMTimer();
        ScoreUserControl MainScore;
        SheetMusicUserControl MainSheetMusicUserControl;
        String TempFilePath = Application.StartupPath.ToString() + "\\temp.mid";

        WMPLib.WindowsMediaPlayer MidiWindowsMediaPlayer = new WMPLib.WindowsMediaPlayer();
        OpenFileDialog OpenDialog = new OpenFileDialog();
        SaveFileDialog SaveDialog = new SaveFileDialog();

        double CurrentScrollPosition = 0;
        int PreviousRow = 128;
        int PreviousColumn = 0;
        double PlaybackJump = 0;
        Boolean AllowPlaybackScoll = false;
        #endregion

        #region Constructors
        public MainForm()
        {
            MainSheetMusicUserControl = new SheetMusicUserControl(this);
            MainSheetMusicUserControl.Location = new Point(510, 222);
            MainSheetMusicUserControl.Size = new Size(66, 166);
            MainSheetMusicUserControl.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
            MainSheetMusicUserControl.BorderStyle = BorderStyle.Fixed3D;
            this.Controls.Add(MainSheetMusicUserControl);
            InitializeComponent();
            this.Text = "Midi Editor & Player";
            this.Size = new Size(1000, 500);
            this.Location = new Point(0, 0);

            //http://www.codeproject.com/Articles/5501/The-Multimedia-Timer-for-the-NET-Framework
            // PlayBack Timer, fires events to refresh score position during playback
            PlayBackTimer.Tick += new System.EventHandler(this.PlayBackTimer_Tick);
            //Set the timers frequency(Event occurs every x milliseconds)
            PlayBackTimer.Period = 34;
            //Set the timers resolution(accuracy in Milliseconds)-smaller value uses more resources: 0 value is highest resolution
            PlayBackTimer.Resolution = 2;
            PlayBackTimer.SynchronizingObject = this;
            //http://msdn.microsoft.com/en-us/library/windows/desktop/dd562692%28v=vs.85%29.aspx
            //Subscribe Handler to these Playstate change event
            MidiWindowsMediaPlayer.PlayStateChange += new WMPLib._WMPOCXEvents_PlayStateChangeEventHandler(this.MidiWindowsMediaPlayer_PlayStateChange);
            //Subscribe Handler to these Error event
            MidiWindowsMediaPlayer.MediaError += new WMPLib._WMPOCXEvents_MediaErrorEventHandler(this.MidiWindowsMediaPlayer_Error);
            VolumeTrackBar.Value = (MidiWindowsMediaPlayer.settings.volume / 10);
        }
        #endregion

        #region MainForm Events
        //Caputure KeyStrokes
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (MainScore != null)
            {
                //Escape
                if (!e.Control && e.KeyCode == Keys.Escape)
                {
                    MainScore.ClearSelectedNoteArrays();
                }
                //Copy
                if (e.Control && e.KeyCode == Keys.C)
                {
                    Copy();
                }
                //Cut
                if (e.Control && e.KeyCode == Keys.X)
                {
                    Cut();
                }
                //Paste
                if (e.Control && e.KeyCode == Keys.V)
                {
                    Paste();
                }
                //Delete
                if (!e.Control && e.KeyCode == Keys.Delete)
                {
                    Delete();
                }
                if (e.Control && e.KeyCode == Keys.A)
                {
                    SelectAll();
                }
                //Delete Tool Shortcut
                if (!e.Control && e.KeyCode == Keys.D)
                {
                    DeleteButton.PerformClick();
                }
                //Select Tool Shortcut
                if (!e.Control && e.KeyCode == Keys.S)
                {
                    SelectButton.PerformClick();
                }
                //Note Tool Shortcut
                if (!e.Control && e.KeyCode == Keys.N)
                {
                    NoteLengthComboBox.Focus();
                }
                //Tempo Tool Shortcut
                if (!e.Control && e.KeyCode == Keys.T)
                {
                    TempoButton.PerformClick();
                }
                //Instrument Tool Shortcut
                if (!e.Control && e.KeyCode == Keys.I)
                {
                    InstrumentButton.PerformClick();
                }
                //Snapper Tool Shortcut
                if (e.Control && e.KeyCode == Keys.S)
                {
                    SnapButton.PerformClick();
                }
                //Zoom Tool Shortcut : Out
                if (e.Control && e.KeyCode == Keys.OemMinus)
                {//http://stackoverflow.com/questions/3968423/what-is-the-enum-for-minus-underscore-and-equal-plus-key-in-keys-enumera
                    ZoomMinusButton.PerformClick();
                }
                //Zoom Tool Shortcut : In
                if (e.Control && e.KeyCode == Keys.Oemplus)
                {
                    ZoomPlusButton.PerformClick();
                }
                //Play Shortcut
                if (!e.Control && e.KeyCode == Keys.Space)
                {
                    PlayButton.PerformClick();
                }
                MainScore.ScorePictureBox.Refresh();
            }
        }
        //New Score
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolPanel.Enabled = true;
            ButtonPanel.Enabled = true;
            NoteLengthComboBox.SelectedIndex = -1;
            //If a score already exists, dispose of it
            if (MainScore != null)
                MainScore.Dispose();
           
            MainScore = new ScoreUserControl();
            MainScore.ScorePictureBox.MouseMove += new MouseEventHandler(GetCords);
            MainScore.Location = new Point(12, 66);
            this.Text = this.Text.Substring(0,20) + " - New";
            MainScore.Visible = false;
            this.Controls.Add(MainScore);
            ScoreResize();
            MainScore.Visible = true;
            UpdateMainForm();
        }
        //Open Composition from file
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //If there is no Score present, create one to hold opened composition
            if(MainScore==null)
                newToolStripMenuItem_Click(sender, e);
          
            OpenDialog.Filter = "Midi files (*.mid)|*.mid|All files (*.*)|*.*";
            if (OpenDialog.ShowDialog() == DialogResult.OK && MainScore!=null)
            {
                MainScore.OpenFile(OpenDialog.FileName);
                this.Text = this.Text.Substring(0, 20) + " - " + OpenDialog.SafeFileName;
            }
            OpenDialog.Dispose();
        }
        //Close the Current Composition
        private void closeCompositionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetMainForm();
        }
        //Save Score
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MainScore != null && MainScore.CurrentMidi.Track.Events.Length > 0 && MainScore.CurrentMidi.Track.Events[0] != null)
            {
              
                SaveDialog.Filter = "Midi files (*.mid)|*.mid|All files (*.*)|*.*";
                if (SaveDialog.ShowDialog() == DialogResult.OK)
                {
                    MainScore.SaveToFile(SaveDialog.FileName);
                    //http://stackoverflow.com/questions/8340157/get-only-name-from-save-file-dialog
                    this.Text = this.Text.Substring(0, 20) + " - " + System.IO.Path.GetFileName(SaveDialog.FileName);
                }
            }
        }
        //Options
        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OptionsForm MyOptions = new OptionsForm();
            MyOptions.ShowDialog(this);
            if (MainScore != null)
            {
                MainScore.PaintGrid();
                UpdateMainForm();
            }
        }
        //Cut, Copy,Paste,Delete Selected Notes
        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cut();
        }
        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Copy();
        }
        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Paste();
        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Delete();
        }
        //Select All Tool Strip
        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectAll();
        }
        //Snapper
        private void SnapButton_Click(object sender, EventArgs e)
        {
            //Toggle Snapper
            switch (MainScore.Snapper)
            {
                case true:
                    SnapperStatus.Text = "Free-Mode";
                    MainScore.Snapper = false;
                    break;
                case false:
                    SnapperStatus.Text = "Snap-Mode";
                    MainScore.Snapper = true;
                    break;
                default:
                    break;
            }
        }
        //On Form Resize
        private void MainForm_Resize(object sender, EventArgs e)
        {
            ScoreResize();
        }
        //Zoom in 
        private void ZoomPlusButton_Click(object sender, EventArgs e)
        {
            NoteLengthComboBox.SelectedIndex = -1;
            Point CurrentCellDims = MainScore.Zoom;
            if (CurrentCellDims.X <= 5)
                MainScore.Zoom = new Point(CurrentCellDims.X + 1, CurrentCellDims.Y + 4);
        }
        //Zoom out
        private void ZoomMinusButton_Click(object sender, EventArgs e)
        {
            NoteLengthComboBox.SelectedIndex = -1;
            Point CurrentCellDims = MainScore.Zoom;
            if (CurrentCellDims.X >= 3)
                MainScore.Zoom = new Point(CurrentCellDims.X - 1, CurrentCellDims.Y - 4);
        }
        //Note Placement
        private void NoteLengthComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                MainScore.Action = "note";
                MainScore.NoteLength = (Convert.ToInt32(Math.Pow(2, NoteLengthComboBox.SelectedIndex)));
            }
            catch { }
        }
        //Select Notes
        private void SelectButton_Click(object sender, EventArgs e)
        {
            NoteLengthComboBox.SelectedIndex = -1;
            MainScore.Action = "select";
        }
        //Delete Notes
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            NoteLengthComboBox.SelectedIndex = -1;
            MainScore.Action = "delete";
        }
        //New Instrument Event
        private void InstrumentButton_Click(object sender, EventArgs e)
        {
            NoteLengthComboBox.SelectedIndex = -1;
            MainScore.Action = "instrument";
            InstrumentSelectForm Input = new InstrumentSelectForm("Select Instrument");
            Input.ShowDialog(this);
            if (Input.ButtonClicked == DialogResult.OK)
            {
                try
                {
                    MainScore.Instrument = Convert.ToByte(Input.Instrument);
                }
                catch
                { MessageBox.Show("Instrument, Out of Range"); }
            }
            //If they clicked cancel, or closed the Instrument Selection Screen, default instrument 0: Grand Piano
            else
                MainScore.Instrument = 0;
        }
        //New Tempo Event
        private void TempoButton_Click(object sender, EventArgs e)
        {
            NoteLengthComboBox.SelectedIndex = -1;
            MainScore.Action = "tempo";
            TextInputDialogForm Input = new TextInputDialogForm("Please Enter Beats Per Minute", "Tempo");
            Input.ShowDialog(this);
            if (Input.ButtonClicked == DialogResult.OK)
            {
                try
                {
                    MainScore.Tempo = Convert.ToInt32(Input.TextEntered);
                }
                catch
                {
                    MessageBox.Show("Incorrect Format, Please enter a number.(0-1200)");
                }
            }
        }
        //Play Current Composition
        private void PlayButton_Click(object sender, EventArgs e)
        {
            if (MainScore != null && MainScore.CurrentMidi.Track.Events.Length > 0 && MainScore.CurrentMidi.Track.Events[0] !=null)
            {
                //Save the Composition to TempFilePath
                MainScore.SaveToFile(TempFilePath);
                //Pass the Path to the MediaPlayer
                MidiWindowsMediaPlayer.URL = TempFilePath;
                //Play the Composition
                MidiWindowsMediaPlayer.controls.play();
            }
        }
        //Stop Playback
        private void StopButton_Click(object sender, EventArgs e)
        {
            CurrentScrollPosition = 0;
            PlayBackTimer.Stop();
            AllowPlaybackScoll = false;
            MidiWindowsMediaPlayer.controls.stop();
            MidiWindowsMediaPlayer.close();
        }
       //Timer Tick
        private void PlayBackTimer_Tick(object sender, EventArgs e)
        {
            if (AllowPlaybackScoll == true)
            {
                //Calculate the distance to scroll
                double BPM = MainScore.TempoAtPosition(-(MainScore.ScorePanel.AutoScrollPosition.X / MainScore.CurrentCellSize.X));
                double CellsPerSecond = BPM * NUMBER_CELLS_QTR_BEAT / 60;
                double CellsPerTimerInterVal = CellsPerSecond * (Convert.ToDouble(PlayBackTimer.Period) / 1000);
                PlaybackJump = CellsPerTimerInterVal * MainScore.CurrentCellSize.X;
                //Add that to the Current Scroll position(which is a double, for accuracy)
                CurrentScrollPosition += PlaybackJump;
                //Update the Scroll position, which is narrowed from the double CurrentScrollPosition
                MainScore.ScorePanel.AutoScrollPosition = new Point(Convert.ToInt32(CurrentScrollPosition), -MainScore.ScorePanel.AutoScrollPosition.Y);
                //Update Tempo Label, Resolve Playback position from Variable'CurrentScrollPosition' Divided by the current Cell Width in MainScore
                TempoToolStripStatusLabel.Text = "BPM: " + MainScore.TempoAtPosition(Convert.ToInt32(CurrentScrollPosition / MainScore.CurrentCellSize.X));
                //Update Instrument Label
                InstrumentToolStripStatusLabel.Text = InstrumentNameFromNumber(MainScore.InstrumentAtPosition(Convert.ToInt32(CurrentScrollPosition / MainScore.CurrentCellSize.X)));
                //Update the Bar & Column Labels in toolstrip through playback
                CellToolStripStatusLabel.Text =
                "Bar " + (1 + (Convert.ToInt32(CurrentScrollPosition / MainScore.CurrentCellSize.X) - (Convert.ToInt32(CurrentScrollPosition / MainScore.CurrentCellSize.X) % (16 * Properties.Settings.Default.QuarterNoteInMeasure))) / (16 * Properties.Settings.Default.QuarterNoteInMeasure)) + "  " +
                "Row " + 0 + "  " +
                "Col " + Convert.ToInt32(CurrentScrollPosition);
            }
        }
        //Change Volume
        private void VolumeTrackBar_ValueChanged(object sender, EventArgs e)
        {
            //If the MediaPlayer and TrackBar exist, change the volume
           if (MidiWindowsMediaPlayer != null && VolumeTrackBar != null)
               MidiWindowsMediaPlayer.settings.volume = VolumeTrackBar.Value*10;
        }
        
        //MediaPlayer Playstate Changed
        private void MidiWindowsMediaPlayer_PlayStateChange(int newState)
        {
            //http://msdn.microsoft.com/en-us/library/windows/desktop/dd562460%28v=vs.85%29.aspx
            //PlayState 1 = Playback Finished
            if (newState == 1)
            {
                PlayBackTimer.Stop();
                CurrentScrollPosition = 0;
                MainScore.ScorePanel.AutoScrollPosition = new Point(0, -MainScore.ScorePanel.AutoScrollPosition.Y);
                MidiWindowsMediaPlayer.close();
                PlayButton.Enabled = true;
                ToolPanel.Enabled = true;
                MainScore.Enabled = true;
                AllowPlaybackScoll = false;
                MyMenuStrip.Enabled = true;
            }
            //PlayState 3 == (Started)Playing
            if (newState == 3)
            {
                AllowPlaybackScoll = true;
                PlayBackTimer.Start();
                CurrentScrollPosition = 0;
                ToolPanel.Enabled = false;
                MainScore.Enabled = false;
                PlayButton.Enabled = false;
                MyMenuStrip.Enabled = false;
            }
        }
        //MediaPlayer Error
        private void MidiWindowsMediaPlayer_Error(object o)
        {
            MessageBox.Show("Error During Playback");
            PlayBackTimer.Stop();
            CurrentScrollPosition = 0;
            MainScore.ScorePanel.AutoScrollPosition = new Point(0, -MainScore.ScorePanel.AutoScrollPosition.Y);
            MidiWindowsMediaPlayer.close();
            PlayButton.Enabled = true;
            ToolPanel.Enabled = true;
            MainScore.Enabled = true;
            AllowPlaybackScoll = false;
            MyMenuStrip.Enabled = true;
        }
        //Form closing event
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Stop the Playback timer if it is running
            if (PlayBackTimer != null && PlayBackTimer.IsRunning)
                PlayBackTimer.Stop();
        }
        #endregion

        #region Methods
        //Copy, Cut, Delete, Paste
        public void Copy()
        {
            if (MainScore != null)
            {
                MainScore.CopySelectedNotesToCopiedEvents();
                MainScore.ClearSelectedNoteArrays();
                MainScore.ScorePictureBox.Refresh();
            }
        }
        public void Cut()
        {
            if (MainScore != null)
            {
                MainScore.CopySelectedNotesToCopiedEvents();
                MainScore.DeleteCopiedNotes();
                MainScore.ClearSelectedNoteArrays();
                MainScore.ScorePictureBox.Refresh();
            }
        }
        public void Delete()
        {
            if (MainScore != null)
            {
                MainScore.CopySelectedNotesToCopiedEvents();
                MainScore.DeleteCopiedNotes();
                MainScore.ClearSelectedNoteArrays();
                MainScore.ClearCopiedNoteArrays();
                MainScore.ScorePictureBox.Refresh();
            }
        }
        public void Paste()
        {
            if (MainScore != null)
            {
                MainScore.PasteCopiedNotes();
                MainScore.ClearSelectedNoteArrays();
                MainScore.ScorePictureBox.Refresh();
            }
        }
        public void SelectAll()
        {
            if(MainScore!=null)
            {
                MainScore.RecordSelectedNotes(new Point(0,0),new Point( MainScore.ScorePictureBox.Width,MainScore.ScorePictureBox.Height));
                MainScore.ScorePictureBox.Refresh();
            }
        }
        //Get Coords of mouse over score, Update Piano Ref(Red Dot), Update Current Tempo & Instrument
        public void GetCords(object sender, EventArgs e)
        {
            CellToolStripStatusLabel.Text = 
            "Bar " + (1 + (MainScore.CurrentCell.X - MainScore.CurrentCell.X % (16 * Properties.Settings.Default.QuarterNoteInMeasure)) / (16 * Properties.Settings.Default.QuarterNoteInMeasure)) + "  " +
            "Row " + MainScore.CurrentCell.Y + "  " + 
            "Col "+ MainScore.CurrentCell.X;
            //if note is selected & mouse is over another Column
            if (MainScore.CurrentCell.Y != PreviousRow)
            {
                //Update Sheet Music Referance
                MainSheetMusicUserControl.NoteLength = NoteLengthComboBox.SelectedIndex;
                MainSheetMusicUserControl.MidiNote = 127 - MainScore.CurrentCell.Y;
            }
            //If the mouse is over a differant Row
            if (MainScore.CurrentCell.X!= PreviousColumn)
            {
                //Update Tempo Label
                TempoToolStripStatusLabel.Text = "BPM: "+MainScore.TempoAtPosition(MainScore.CurrentCell.X);
                //Update Instrument Label
                InstrumentToolStripStatusLabel.Text = InstrumentNameFromNumber(MainScore.InstrumentAtPosition(MainScore.CurrentCell.X));
            }
            //Show referance on piano
            MainScore.RefPianoNote();
            PreviousRow = MainScore.CurrentCell.Y;
            PreviousColumn = MainScore.CurrentCell.X;
        }

        //Get relative Instrument Name for Instrument Number
        public String InstrumentNameFromNumber(byte MidiInstrumentNumber)
        {
            String[] InstrumentNames = {"Acoustic Grand Piano",
                    "Bright Acoustic Piano",
                    "Electric Grand Piano",
                    "Honky-tonk Piano",
                    "Electric Piano",
                    "Electric Piano 2",
                    "Harpsichord",
                    "Clavinet",
                    "Celesta",
                    "Glockenspiel",
                    "Music Box",
                    "Vibraphone",
                    "Marimba",
                    "Xylophone",
                    "Tubular Bells",
                    "Dulcimer",
                    "Drawbar Organ",
                    "Percussive Organ",
                    "Rock Organ",
                    "Church Organ",
                    "Reed Organ",
                    "Accordion",
                    "Harmonica",
                    "Tango Accordion",
                    "Acoustic Guitar (nylon)",
                    "Acoustic Guitar (steel)",
                    "Electric Guitar (jazz)",
                    "Electric Guitar (clean)",
                    "Electric Guitar (muted)",
                    "Overdriven Guitar",
                    "Distortion Guitar",
                    "Guitar harmonics",
                    "Acoustic Bass",
                    "Electric Bass (finger)",
                    "Electric Bass (pick)",
                    "Fretless Bass",
                    "Slap Bass 1",
                    "Slap Bass 2",
                    "Synth Bass 1",
                    "Synth Bass 2",
                    "Violin",
                    "Viola",
                    "Cello",
                    "Contrabass",
                    "Tremolo Strings",
                    "Pizzicato Strings",
                    "Orchestral Harp",
                    "Timpani",
                    "String Ensemble 1",
                    "String Ensemble 2",
                    "Synth Strings 1",
                    "Synth Strings 2",
                    "Choir Aahs",
                    "Voice Oohs",
                    "Synth Voice",
                    "Orchestra Hit",
                    "Trumpet",
                    "Trombone",
                    "Tuba",
                    "Muted Trumpet",
                    "French Horn",
                    "Brass Section",
                    "Synth Brass 1",
                    "Synth Brass 2",
                    "Soprano Sax",
                    "Alto Sax",
                    "Tenor Sax",
                    "Baritone Sax",
                    "Oboe",
                    "English Horn",
                    "Bassoon",
                    "Clarinet",
                    "Piccolo",
                    "Flute",
                    "Recorder",
                    "Pan Flute",
                    "Blown Bottle",
                    "Shakuhachi",
                    "Whistle",
                    "Ocarina",
                    "Lead 1 (square)",
                    "Lead 2 (sawtooth)",
                    "Lead 3 (calliope)",
                    "Lead 4 (chiff)",
                    "Lead 5 (charang)",
                    "Lead 6 (voice)",
                    "Lead 7 (fifths)",
                    "Lead 8 (bass + lead)",
                    "Pad 1 (new age)",
                    "Pad 2 (warm)",
                    "Pad 3 (polysynth)",
                    "Pad 4 (choir)",
                    "Pad 5 (bowed)",
                    "Pad 6 (metallic)",
                    "Pad 7 (halo)",
                    "Pad 8 (sweep)",
                    "FX 1 (rain)",
                    "FX 2 (soundtrack)",
                    "FX 3 (crystal)",
                    "FX 4 (atmosphere)",
                    "FX 5 (brightness)",
                    "FX 6 (goblins)",
                    "FX 7 (echoes)",
                    "FX 8 (sci-fi))",
                    "Sitar",
                    "Banjo",
                    "Shamisen",
                    "Koto",
                    "Kalimba",
                    "Bag pipe",
                    "Fiddle",
                    "Shanai",
                    "Tinkle Bell",
                    "Agogo",
                    "Steel Drums",
                    "Woodblock",
                    "Taiko Drum",
                    "Melodic Tom",
                    "Synth Drum",
                    "Reverse Cymbal",                    
                    "Guitar Fret Noise",
                    "Breath Noise",
                    "Seashore",
                    "Bird Tweet",
                    "Telephone Ring",
                    "Helicopter",
                    "Applause",
                    "Gunshot"};
            return InstrumentNames[MidiInstrumentNumber];
        }

        //Update MainForm
        public void UpdateMainForm()
        {
             //Snapper Status
            switch (MainScore.Snapper)
            {
                case true:
                    SnapperStatus.Text = "Snap-Mode";
                    break;
                case false:
                    SnapperStatus.Text = "Free-Mode";
                    break;
                default:
                    break;
            }
        }
        
        //How to resize controls
        public void ScoreResize()
        {
            if (MainScore != null)
            {
                MainScore.Size = new Size(this.Size.Width - 115, this.Size.Height - 165);
                ToolPanel.Height = MainScore.Height - MainSheetMusicUserControl.Height - 20;
            }
        }
        
        //Reset the main form
        public void ResetMainForm()
        {
            MainScore.Dispose();
            this.Text = this.Text.Substring(0, 20);
            ToolPanel.Enabled = false;
            CellToolStripStatusLabel.Text = "Bar 0  Row 0  Col 0";
            SnapperStatus.Text = "Free-Mode";
            TempoToolStripStatusLabel.Text = "BPM: 120";
            InstrumentToolStripStatusLabel.Text = "Acoustic Grand Piano";
        }
        #endregion
    }
}
