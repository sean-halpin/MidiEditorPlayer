using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MidiEditorPlayerCs
{
    public class TempoMidiEvent : MidiEvent
    {
        const int MICROSECONDSINAMINUTE = 60000000;
        const byte LENGTHBYTE = 3;
        //Tempo Event
        const byte METAEVENTNUMBER = 0xff;
        const byte METAEVENTTYPE = 0x51;

        int MicrosecondsQuarterNote;

        public TempoMidiEvent()
        {
            MicrosecondsQuarterNote=0;
        }
        public TempoMidiEvent(int Delt, int XPos, int BPM )
        {
            Delta = Delt;
            CellX = XPos;
            EventType = 0x0f;
            MidiChannel = 0x0f;
            MicrosecondsQuarterNote = MICROSECONDSINAMINUTE / BPM;
        }
        public TempoMidiEvent(int Delt, int MicroSec)
        {
            Delta = Delt;
            CellX = 0;
            EventType = 0x0f;
            MidiChannel = 0x0f;
            MicrosecondsQuarterNote = MicroSec;
        }

        //accessor methods

        public int QuarterNoteTime
        {
            get { return MicrosecondsQuarterNote; }
            set { MicrosecondsQuarterNote = value; }
        }
        public int Tempo
        {
            get { return (MICROSECONDSINAMINUTE/MicrosecondsQuarterNote); }
        }
        public byte MetaEventNumber
        {
            get { return METAEVENTNUMBER; }
        }
        public byte MetaEventType
        {
            get { return METAEVENTTYPE; }
        }
        public byte MetaEventDataLength
        {
            get { return LENGTHBYTE; }
        }
    }
}
