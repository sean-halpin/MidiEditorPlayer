using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MidiEditorPlayerCs
{
    public class StandardMidi
    {
        #region Declarations
        const int HEADERLENGTHINBYTES = 14;
        const int EIGHTSHIFT = 8;
        const int TRACKHEADERLENGTH = 8;
        const int SHIFT = 7;

        HeaderChunk MidiHeaderChunk;
        TrackChunk MidiTrackChunk;

        int FarthestCellX = 0;
        #endregion

        #region Constructors
        public StandardMidi()
        {
            MidiHeaderChunk = new HeaderChunk();
            MidiTrackChunk = new TrackChunk();
        }
        #endregion

        #region File operations
        //Save Current Composition
        public void SaveMidiFile(String FilePath)
        {
            // Create a file: Write: Midi Header
            System.IO.FileStream MidiFileStream = null;
            MidiFileStream = new System.IO.FileStream(FilePath, System.IO.FileMode.Create);
            MidiFileStream.Write(Header.HeaderChunkInBytes(), 0, HEADERLENGTHINBYTES);
            MidiFileStream.Close();
            //Change FileMode
            //Append Following: Track Chunk
            MidiFileStream = new System.IO.FileStream(FilePath, System.IO.FileMode.Append);
            MidiFileStream.Write(Track.TrackChunkInBytes(Header.Ticks), 0, Track.AbsoluteTrackLength);
            MidiFileStream.Close();
        }

        //Open Composition
        public void OpenMidiFile(String FilePath)
        {
            //contains File Header
            byte[] MidiHeaderChunkInBytes = new byte[HEADERLENGTHINBYTES];
            //Contains all other tracks
            byte[] MidiTrackEventChunkInBytes = new byte[0];
            try
            {
                // Read a File: Read: Midi Header
                System.IO.FileStream MidiFileStream = null;
                MidiFileStream = new System.IO.FileStream(FilePath, System.IO.FileMode.Open);
                MidiFileStream.Read(MidiHeaderChunkInBytes, 0, HEADERLENGTHINBYTES);

                //Read: Track events
                Array.Resize(ref MidiTrackEventChunkInBytes, Convert.ToInt32(MidiFileStream.Length - HEADERLENGTHINBYTES));
                MidiFileStream.Read(MidiTrackEventChunkInBytes, 0, Convert.ToInt32(MidiFileStream.Length - HEADERLENGTHINBYTES));
                MidiFileStream.Close();
            }
            catch
            {
                MessageBox.Show("Error Reading File");
            }
            HeaderChunkFromBytes(MidiHeaderChunkInBytes);
            TrackChunkFromBytes(MidiTrackEventChunkInBytes);
        }
        #endregion

        #region Methods
        //Create HeaderChunk Object from Array of Bytes
        public void HeaderChunkFromBytes(byte[] HeaderBytes)
        {
            MidiHeaderChunk = new HeaderChunk(HeaderBytes[9], HeaderBytes[11], ((HeaderBytes[12] << EIGHTSHIFT) | HeaderBytes[13]));
        }

        //Create TrackChunk Object from Array of Bytes
        public void TrackChunkFromBytes(byte[] TrackBytes)
        {
            //MidiEvent
            int Delta = 0;
            sbyte EventType;
            sbyte MidiChannel;
            byte Param1;
            byte Param2;
            //TempoEvent
            int MicroSecondsPerQuarterNote = 1;
            //InstrumentEvent
            byte InstrumentNumber = 1;
     
            MidiEvent[] OpenedEvents = new MidiEvent[1];
            Boolean DeltaRetrieved = false;
            int NextEventIndex = 0;
            byte NextByteValue;

            for (int ByteIndex = TRACKHEADERLENGTH; ByteIndex < TrackBytes.Length - 1; ByteIndex++)
            {
                Delta = 0;
                while (!(DeltaRetrieved))
                {
                    NextByteValue = TrackBytes[ByteIndex];
                    if ((NextByteValue) >= 128)
                    {
                        Delta = NextByteValue & 127;
                        Delta = Delta << SHIFT;
                    }
                    else
                    {
                        Delta = Delta | NextByteValue;
                        DeltaRetrieved = true;
                    }
                    ByteIndex++;
                }
                DeltaRetrieved = false;

                NextByteValue = TrackBytes[ByteIndex];
                //If its a Meta Event
                if (NextByteValue==0xff)
                {
                    ByteIndex++;
                    NextByteValue = TrackBytes[ByteIndex];
                    if ((NextByteValue == 0x2F))
                    {
                        //EOT found
                        break;
                    }
                    ByteIndex++;
                    NextByteValue = TrackBytes[ByteIndex];
                    ByteIndex++;
                    MicroSecondsPerQuarterNote = TrackBytes[ByteIndex] << 8;
                    ByteIndex++;
                    MicroSecondsPerQuarterNote = (MicroSecondsPerQuarterNote | TrackBytes[ByteIndex]) <<8;
                    ByteIndex++;
                    MicroSecondsPerQuarterNote = (MicroSecondsPerQuarterNote | TrackBytes[ByteIndex]);

                   if (OpenedEvents[0] == null) { }
                    else
                        Array.Resize(ref OpenedEvents, OpenedEvents.Length + 1);
                   OpenedEvents[NextEventIndex] = new TempoMidiEvent(Delta, MicroSecondsPerQuarterNote);
                   NextEventIndex++;
                }
                //if its an instrument change event
                else if (NextByteValue == 0xC0)
                {
                    MidiChannel = Convert.ToSByte(0x0f & NextByteValue << 4);
                    ByteIndex++;
                    NextByteValue = TrackBytes[ByteIndex];
                    InstrumentNumber = NextByteValue;
                    if (OpenedEvents[0] == null) 
                    {
                        //Do Nothing. Opened events are empty and the first element is free
                    }
                    else //Resize the array for the extra event
                        Array.Resize(ref OpenedEvents, OpenedEvents.Length + 1);
                    OpenedEvents[NextEventIndex] = new InstrumentMidiEvent(Delta, 0, MidiChannel, InstrumentNumber);
                    NextEventIndex++;
                }
                //Other Midi Event
                else
                {
                    EventType = Convert.ToSByte(NextByteValue >> 4);
                    //No ByteIndex++ because EventType& MidiChannel are stored in same byte
                    MidiChannel = Convert.ToSByte(NextByteValue & 0xf);
                    ByteIndex++;

                    NextByteValue = TrackBytes[ByteIndex];
                    Param1 = NextByteValue;
                    ByteIndex++;

                    NextByteValue = TrackBytes[ByteIndex];
                    Param2 = NextByteValue;

                    if (OpenedEvents[0] == null) { }
                    else
                        Array.Resize(ref OpenedEvents, OpenedEvents.Length + 1);
                    OpenedEvents[NextEventIndex] = new MidiEvent(0, 0, Delta, EventType, MidiChannel, Param1, Param2);
                    NextEventIndex++;
                }
            }
            CalculateScorePositionFromDeltaTimes(OpenedEvents, MidiHeaderChunk.Ticks);
            CalculateNoteDownLengths(OpenedEvents);
            MidiTrackChunk = new TrackChunk(OpenedEvents);
        }

        //Calculate Relative Score Position from Delta Values
        public MidiEvent[] CalculateScorePositionFromDeltaTimes(MidiEvent[] MidiEvents, int TicksQtrNote)
        {
            int CumulativeDelta = 0;
            // based on standard 48 ticks per Qtr Note & 16 cells per Qtr Note(allows for 64thNote)
            for (int EventIndex = 0; EventIndex < MidiEvents.Length; EventIndex++)
            {
                CumulativeDelta += MidiEvents[EventIndex].Delta;
                MidiEvents[EventIndex].CellPosition = CumulativeDelta / (TicksQtrNote / 16);
                //Update Farthest CellX Position : Used to Size Score
                if (MidiEvents[EventIndex].CellPosition>FarthestCellX)
                    FarthestCellX = MidiEvents[EventIndex].CellPosition;
            }
            return MidiEvents;
        }

        //Calculate NoteDownLengths, from cell distance to next noteup
        public MidiEvent[] CalculateNoteDownLengths(MidiEvent[] MidiEvents)
        {
            for (int NoteDownIndex = 0; NoteDownIndex < MidiEvents.Length; NoteDownIndex++)
            {
                if (MidiEvents[NoteDownIndex].Type == 0x09)
                {
                    for (int NoteUpIndex = NoteDownIndex + 1; NoteUpIndex < (MidiEvents.Length); NoteUpIndex++)
                    {
                        if (MidiEvents[NoteDownIndex].Length == 0 && MidiEvents[NoteUpIndex].Type == 0x08 && (MidiEvents[NoteUpIndex].Paramater1 == MidiEvents[NoteDownIndex].Paramater1))
                        {
                            MidiEvents[NoteDownIndex].Length = MidiEvents[NoteUpIndex].CellPosition - MidiEvents[NoteDownIndex].CellPosition;
                            break;
                        }
                    }
                }
            }
            return MidiEvents;
        }
        #endregion

        #region Accessors
        public int FarthestEvent
        {
            get { return FarthestCellX; }
        }

        public HeaderChunk Header
        {
            get { return MidiHeaderChunk; }
            set { MidiHeaderChunk = value; }
        }
        public TrackChunk Track
        {
            get { return MidiTrackChunk; }
            set { MidiTrackChunk = value; }
        }
        #endregion
    }
}
