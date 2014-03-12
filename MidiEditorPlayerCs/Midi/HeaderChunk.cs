using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MidiEditorPlayerCs
{
    public class HeaderChunk
    {
        const int BITSHIFT = 8;
        const int HEADERLENGTHINBYTES = 14;
        byte[] MidiHeaderChunk = { 0x4d, 0x54, 0x68, 0x64,0,0,0,6 };
        byte TrackFormat = 0x0;
        byte TrackCount = 0x1;
        int TicksQtrBeat = 0x30;

        public HeaderChunk()
        {
        }
        public HeaderChunk(byte Format, byte Count, int Ticks)
        {
            TrackFormat = Format;
            TrackCount = Count;
            TicksQtrBeat = Ticks;
        }
        public byte Format
        {
            get { return TrackFormat; }
            set { TrackFormat = value; }
        }
        public byte NumOfTracks
        {
            get { return TrackCount; }
            set { TrackCount = value; }
        }
        public int Ticks
        {
            get { return TicksQtrBeat; }
            set { TicksQtrBeat = value; }
        }

        public byte[] HeaderChunkInBytes()
        {
            Array.Resize(ref MidiHeaderChunk, HEADERLENGTHINBYTES);
            MidiHeaderChunk[8] = 0;
            MidiHeaderChunk[9] = TrackFormat;
            MidiHeaderChunk[10] = 0;
            MidiHeaderChunk[11] = TrackCount;
            MidiHeaderChunk[12] = Convert.ToByte(255 & (TicksQtrBeat >> BITSHIFT ));
            MidiHeaderChunk[13] = Convert.ToByte(255 & TicksQtrBeat);
            return MidiHeaderChunk;
        }
    }
}
