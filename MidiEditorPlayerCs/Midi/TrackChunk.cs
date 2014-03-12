using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MidiEditorPlayerCs
{
    public class TrackChunk
    {
        #region Declarations
        const int TRACKHEADERLENGTH = 8;
        const byte SEVENSHIFT = 7;
        const byte EIGHTSHIFT = 8;
        //Quarter note is always 16cells wide(allows 64th note to be 1cell wide)
        const byte CELLCOUNTQTRNOTE = 16;
        //TrackHeader Chunk Id: Ascii 'MTrk'
        byte[] TrackHeaderChunk = { 0x4D, 0x54, 0x72, 0x6B };
        //End of Track Bytes
        byte[] EndOfTrack = { 0xff, 0xff, 0x0, 0xff, 0x2f, 0x0 };
        //TrackLength
        int TrackByteCount = 0;
        //TrackEvents
        MidiEvent[] TrackEvents;
        //TrackChunk in bytes, according to Midi Protocol
        byte[] TrackChunkBytes;
        #endregion

        #region Constructors
        public TrackChunk()
        {
            TrackEvents = new MidiEvent[1];
        }
        public TrackChunk(MidiEvent[] MidiEvents)
        {
            TrackEvents = MidiEvents;
        }
        #endregion

        #region Methods
        public byte[] TrackChunkInBytes(int Ticks)
        {
            CalculateDeltaTimes(TrackEvents, Ticks);
            GenerateMidiEventByteArray(TrackEvents);
            GenerateTrackHeader();
            //Add Header & Events
            Array.Resize(ref TrackHeaderChunk, TrackHeaderChunk.Length + TrackChunkBytes.Length);
            Array.Copy(TrackChunkBytes, 0, TrackHeaderChunk,8, TrackChunkBytes.Length);
            return TrackHeaderChunk;
        }

        //Generate Delta time for each event
        public void CalculateDeltaTimes(MidiEvent[] EventArray, int TicksQtrBeat)
        {
            for (int index = 0; index < EventArray.Length; index++)
            {
                //(The delta time is = (this note's cell position - last events cell position)* ticks per qtrBeat/num cells in a qrt note)
                if (index !=0)
                EventArray[index].Delta = (EventArray[index].CellPosition - EventArray[index-1].CellPosition) * (TicksQtrBeat / CELLCOUNTQTRNOTE);
                else
                    EventArray[index].Delta = (EventArray[index].CellPosition) * (TicksQtrBeat / CELLCOUNTQTRNOTE);
            }
        }

        //Generate Midi Event Bytes, Calculate Delta times in bytes.
        public void GenerateMidiEventByteArray(MidiEvent[] MidiEventArray)
        {
            int ByteIndex = 0;
            for (int EventIndex = 0; EventIndex <= MidiEventArray.Length - 1; EventIndex++)
            {
                //Convert Delta times to Big-Endian bytes (max 4 bytes)
                if ((MidiEventArray[EventIndex].Delta >> SEVENSHIFT * 3) > 0)
                {
                    Array.Resize(ref TrackChunkBytes, ByteIndex + 1);
                    TrackChunkBytes[ByteIndex] = Convert.ToByte(128 | (MidiEventArray[EventIndex].Delta >> SEVENSHIFT * 3));
                    ByteIndex += 1;
                }

                if ((MidiEventArray[EventIndex].Delta >> SEVENSHIFT * 2) > 0)
                {
                    Array.Resize(ref TrackChunkBytes, ByteIndex + 1);
                    TrackChunkBytes[ByteIndex] = Convert.ToByte(128 | (MidiEventArray[EventIndex].Delta >> SEVENSHIFT * 2));
                    ByteIndex += 1;
                }

                if ((MidiEventArray[EventIndex].Delta >> SEVENSHIFT) > 0)
                {
                    Array.Resize(ref TrackChunkBytes, ByteIndex + 1);
                    TrackChunkBytes[ByteIndex] = Convert.ToByte(128 | MidiEventArray[EventIndex].Delta >> SEVENSHIFT);
                    ByteIndex += 1;
                }
                //Final byte Delta Time
                Array.Resize(ref TrackChunkBytes, ByteIndex + 1);
                TrackChunkBytes[ByteIndex] = Convert.ToByte(127 & (MidiEventArray[EventIndex].Delta));
                ByteIndex += 1;
                //Decide how to write event data
                if (MidiEventArray[EventIndex] is TempoMidiEvent)
                {
                    //Caste Event
                    TempoMidiEvent CurrentTempoEvent = (TempoMidiEvent)MidiEventArray[EventIndex];
                    //Meta Event Number
                    Array.Resize(ref TrackChunkBytes, ByteIndex + 1);
                    TrackChunkBytes[ByteIndex] = CurrentTempoEvent.MetaEventNumber;
                    ByteIndex += 1;

                    //Meta Event Type
                    Array.Resize(ref TrackChunkBytes, ByteIndex + 1);
                    TrackChunkBytes[ByteIndex] = CurrentTempoEvent.MetaEventType;
                    ByteIndex += 1;
                    //Meta Event Data Length
                    Array.Resize(ref TrackChunkBytes, ByteIndex + 1);
                    TrackChunkBytes[ByteIndex] = CurrentTempoEvent.MetaEventDataLength;
                    ByteIndex += 1;
                    //Quarter Note Time
                    Array.Resize(ref TrackChunkBytes, ByteIndex + 1);
                    TrackChunkBytes[ByteIndex] = Convert.ToByte(255 & (CurrentTempoEvent.QuarterNoteTime >> 16));
                    ByteIndex += 1;
                    //Quarter Note Time
                    Array.Resize(ref TrackChunkBytes, ByteIndex + 1);
                    TrackChunkBytes[ByteIndex] = Convert.ToByte(255 & (CurrentTempoEvent.QuarterNoteTime >> 8));
                    ByteIndex += 1;
                    //Quarter Note Time
                    Array.Resize(ref TrackChunkBytes, ByteIndex + 1);
                    TrackChunkBytes[ByteIndex] = Convert.ToByte(255 & (CurrentTempoEvent.QuarterNoteTime));
                    ByteIndex += 1;
                }
                else if (MidiEventArray[EventIndex] is InstrumentMidiEvent)
                {
                    //Caste Event
                    InstrumentMidiEvent CurrentTempoEvent = (InstrumentMidiEvent)MidiEventArray[EventIndex];
                    //Instrument Event Number :channel default zero
                    Array.Resize(ref TrackChunkBytes, ByteIndex + 1);
                    TrackChunkBytes[ByteIndex] = Convert.ToByte(CurrentTempoEvent.Type << 4);
                    ByteIndex += 1;

                    //Meta Event Type
                    Array.Resize(ref TrackChunkBytes, ByteIndex + 1);
                    TrackChunkBytes[ByteIndex] = CurrentTempoEvent.Paramater1;
                    ByteIndex += 1;
                }
                else
                {
                    //Event Type & Channel(Zero) TODO:This defaults channel to zero always
                    Array.Resize(ref TrackChunkBytes, ByteIndex + 1);
                    TrackChunkBytes[ByteIndex] = Convert.ToByte(MidiEventArray[EventIndex].Type << 4);
                    ByteIndex += 1;

                    //Param1
                    Array.Resize(ref TrackChunkBytes, ByteIndex + 1);
                    TrackChunkBytes[ByteIndex] = MidiEventArray[EventIndex].Paramater1;
                    ByteIndex += 1;
                    //Param2
                    Array.Resize(ref TrackChunkBytes, ByteIndex + 1);
                    TrackChunkBytes[ByteIndex] = MidiEventArray[EventIndex].Paramater2;
                    ByteIndex += 1;
                }
            }
            //Add end of Track Event
            Array.Resize(ref TrackChunkBytes, ByteIndex + 6);
            TrackChunkBytes[ByteIndex] = EndOfTrack[0];
            ByteIndex += 1;
            TrackChunkBytes[ByteIndex] = EndOfTrack[1];
            ByteIndex += 1;
            TrackChunkBytes[ByteIndex] = EndOfTrack[2];
            ByteIndex += 1;
            TrackChunkBytes[ByteIndex] = EndOfTrack[3];
            ByteIndex += 1;
            TrackChunkBytes[ByteIndex] = EndOfTrack[4];
            ByteIndex += 1;
            TrackChunkBytes[ByteIndex] = EndOfTrack[5];
        }

        //Calculate Length of track in bytes, according to midi protocol. Not BigEndian!
        public void GenerateTrackHeader()
        {
            TrackByteCount = TrackChunkBytes.Length;
            Array.Resize(ref TrackHeaderChunk, 8);
            TrackHeaderChunk[4] = Convert.ToByte(255 & (TrackByteCount >> EIGHTSHIFT * 3));
            TrackHeaderChunk[5] = Convert.ToByte(255 & (TrackByteCount >> EIGHTSHIFT * 2));
            TrackHeaderChunk[6] = Convert.ToByte(255 & (TrackByteCount >> EIGHTSHIFT * 1));
            TrackHeaderChunk[7] = Convert.ToByte(255 & TrackByteCount);
        }
        #endregion

        #region Accessors
        public int TrackEventLength
        {
            get { return TrackByteCount; }
            set { TrackByteCount = value; }
        }
        public int AbsoluteTrackLength
        {
            get { return TrackByteCount + TRACKHEADERLENGTH; }
        }
        public MidiEvent[] Events
        {
            get { return TrackEvents; }
            set 
            {
                Array.Resize(ref TrackEvents, value.Length);
                Array.Copy(value,TrackEvents,value.Length); 
            }
        }
        #endregion
    }
}
