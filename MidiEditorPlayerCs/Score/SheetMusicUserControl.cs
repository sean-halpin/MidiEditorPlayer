using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MidiEditorPlayerCs
{
    public partial class SheetMusicUserControl : UserControl
    {
        const int XPictureBoxPos = 38;
        const int YNoteStart = 114;
        int NoteToDisplay = 128;
        int NoteType = 0;
        
        public SheetMusicUserControl(Form Sender)
        { 
            InitializeComponent();
           
            SharpFlatLabel.Text = "";
            NotePictureBox.Location = new Point(0,200);
            this.DoubleBuffered = true;
        }
        #region Accessors
        public int NoteLength
        {
            get { return NoteType; }
            set{NoteType = value;}
        }
        public int MidiNote
        {
            get { return NoteToDisplay;}
            set 
            { 
                NoteToDisplay = value; 
                Display();
            }
        }
        #endregion

        public void Display()
        {
            NotePictureBox.Visible = false;
            SharpFlatLabel.Visible = false;
            if (NoteToDisplay <= 83 & NoteToDisplay >= 38)
            {
                //Decide sharp or flat
                switch (NoteToDisplay % 12)
                {
                    case 8:
                    case 6:
                    case 3:
                    case 1:
                        SharpFlatLabel.Text = "#"; 
                        break;
                    case 10:
                        //Unidcode Escape Sequance for Musical flat Character
                        SharpFlatLabel.Text = "b";
                        NoteToDisplay += 1;
                        break;
                    default:
                        SharpFlatLabel.Text = "";
                        break;
                }
                //Decide Note Position
                switch (NoteToDisplay)
                {
                    case 38: case 39:
                        NotePictureBox.Location = new Point(XPictureBoxPos, YNoteStart + 5);
                        break; 
                    case 40:
                        NotePictureBox.Location = new Point(XPictureBoxPos, YNoteStart - 0);
                        break;
                    case 41: case 42:
                        NotePictureBox.Location = new Point(XPictureBoxPos, YNoteStart - 5);
                        break;              
                    case 43: case 44:
                        NotePictureBox.Location = new Point(XPictureBoxPos, YNoteStart - 10);
                        break;
                    case 45: case 46:
                        NotePictureBox.Location = new Point(XPictureBoxPos, YNoteStart - 15);
                        break;
                    case 47:
                        NotePictureBox.Location = new Point(XPictureBoxPos, YNoteStart - 20);
                        break;
                    case 48: case 49:
                        NotePictureBox.Location = new Point(XPictureBoxPos, YNoteStart - 25);
                        break;
                    case 50: case 51:
                        NotePictureBox.Location = new Point(XPictureBoxPos, YNoteStart - 30);
                        break;
                    case 52:
                        NotePictureBox.Location = new Point(XPictureBoxPos, YNoteStart - 35);
                        break;
                    case 53: case 54:
                        NotePictureBox.Location = new Point(XPictureBoxPos, YNoteStart - 40);
                        break;
                    case 55: case 56:
                        NotePictureBox.Location = new Point(XPictureBoxPos, YNoteStart - 45);
                        break;
                    case 57: case 58:
                        NotePictureBox.Location = new Point(XPictureBoxPos, YNoteStart - 50);
                        break;
                    case 59:
                        NotePictureBox.Location = new Point(XPictureBoxPos, YNoteStart - 55);
                        break;
                    case 60: case 61:
                        NotePictureBox.Location = new Point(XPictureBoxPos, YNoteStart - 60);
                        break;
                    case 62: case 63:
                        NotePictureBox.Location = new Point(XPictureBoxPos, YNoteStart - 65);
                        break;
                    case 64:
                        NotePictureBox.Location = new Point(XPictureBoxPos, YNoteStart - 70);
                        break;
                    case 65: case 66:
                        NotePictureBox.Location = new Point(XPictureBoxPos, YNoteStart - 75);
                        break;
                    case 67: case 68:
                        NotePictureBox.Location = new Point(XPictureBoxPos, YNoteStart - 80);
                        break;
                    case 69: case 70:
                        NotePictureBox.Location = new Point(XPictureBoxPos, YNoteStart - 85);
                        break;
                    case 71:
                        NotePictureBox.Location = new Point(XPictureBoxPos, YNoteStart - 90);
                        break;
                    case 72: case 73:
                        NotePictureBox.Location = new Point(XPictureBoxPos, YNoteStart - 95);
                        break;
                    case 74: case 75:
                        NotePictureBox.Location = new Point(XPictureBoxPos, YNoteStart - 100);
                        break;
                    case 76:
                        NotePictureBox.Location = new Point(XPictureBoxPos, YNoteStart - 105);
                        break;
                    case 77: case 78:
                        NotePictureBox.Location = new Point(XPictureBoxPos, YNoteStart - 110);
                        break;
                    case 79: case 80:
                        NotePictureBox.Location = new Point(XPictureBoxPos, YNoteStart - 115);
                        break;
                    case 81: 
                        NotePictureBox.Location = new Point(XPictureBoxPos, YNoteStart - 120);
                        break;
                    case 83:
                        NotePictureBox.Location = new Point(XPictureBoxPos, YNoteStart - 125);
                        break;
                    default:
                        break;
                }
                SharpFlatLabel.Location = new Point(NotePictureBox.Location.X -16 , NotePictureBox.Location.Y +12);
                NotePictureBox.Visible = true;
                SharpFlatLabel.Visible = true;
            }
            else
            {
                NotePictureBox.Location = new Point(0, 200);
                SharpFlatLabel.Location = new Point(0, 200);
            }
        }
    }
}
