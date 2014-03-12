using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MidiEditorPlayerCs
{
    public class MidiEvent : IComparable<MidiEvent> 

    {
        #region Declarations
        protected int DeltaTime;
        protected sbyte EventType;
        protected sbyte MidiChannel;
        byte Param1;
        byte Param2;
        // Used to Calculate Delta Times
        protected int CellX;
        //For drawing notes & finding attached 'NoteUp' Event
        int NoteLength;
        #endregion

        #region Constructors
        //default constructor
        public MidiEvent()
        {
            CellX = 0;
            NoteLength = 0;
            DeltaTime = 0;
            EventType = 0;
            MidiChannel = 0;
            Param1 = 0;
            Param2 = 0;
        }
        //contructor for NoteDown Events(records cell length)
        public MidiEvent(int eventXCell, int lengthCells,int DeltaT, sbyte eventNum, sbyte chan, byte parameter1, byte parameter2)
        {
            CellX = eventXCell;
            NoteLength = lengthCells;
            DeltaTime = DeltaT;
            EventType = eventNum;
            MidiChannel = chan;
            Param1 = parameter1;
            Param2 = parameter2;
        }
        #endregion

        #region CompareTo() OverRide
        //If 2 events of the same note, occur at the same time, NoteUP will preceed NoteDown
        //Otherwise the Event that occurs first in time will preceed the other Event
        //Sort Midi Events, By CellX then EventType
        public int CompareTo(MidiEvent AnEvent)
        {
            int Result = 0;
            if ((AnEvent.CellX.CompareTo(this.CellX)) == 0)
            {
                if (AnEvent.Type == 0x0C || this.Type == 0x0C)
                    Result = (AnEvent.Type.CompareTo(this.Type));
                else
                    Result = (AnEvent.Type.CompareTo(this.Type))* -1;
            }
            else
            {
                Result = (AnEvent.CellX.CompareTo(this.CellX)) * -1;
            }
            return Result;
        }
        #endregion

        #region Accessors
        //accessor methods for a MidiEvent
        public int CellPosition
        {
            get { return CellX; }
            set { CellX = value; }
        }

        public int Length
        {
            get { return NoteLength; }
            set { NoteLength = value; }
        }

        public int Delta
        {
            get { return DeltaTime; }
            set { DeltaTime = value; }
        }

        public sbyte Type
        {
            get { return EventType; }
            set { EventType = value; }
        }

        public sbyte Channel
        {
            get { return MidiChannel; }
            set { MidiChannel = value; }
        }

        public byte Paramater1
        {
            get { return Param1; }
            set { Param1 = value; }
        }

        public byte Paramater2
        {
            get { return Param2; }
            set { Param2 = value; }
        }
        #endregion
    }
}
