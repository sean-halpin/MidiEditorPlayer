using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MidiEditorPlayerCs
{
    public partial class OptionsForm : Form
    {
        #region Declarations
        int BarsDisplayed= Properties.Settings.Default.SixteenNoteMeasureCount;
        int QtrBeatsPerBar = Properties.Settings.Default.QuarterNoteInMeasure;
        Color GridLines = (Properties.Settings.Default.GridLines);
        SolidBrush BackGround = new SolidBrush(Properties.Settings.Default.BackGround);
        Color QtrNoteSeparator = (Properties.Settings.Default.QtrNoteSeparator);
        Color BarSeparator = (Properties.Settings.Default.BarSeparator);
        SolidBrush NoteOutline = new SolidBrush(Properties.Settings.Default.NoteOutline);
        Color NoteFill = (Properties.Settings.Default.NoteFill);

        ScoreUserControl PreviewTheScoreUserControl = new ScoreUserControl();
        #endregion

        #region Constructor
        public OptionsForm()
        {
            InitializeComponent();
            PreviewTheScoreUserControl.Size = new Size(423, 145);
            PreviewTheScoreUserControl.Location = new Point(4, 260);
            PreviewTheScoreUserControl.NoteLength = 16;
            PreviewTheScoreUserControl.CurrentMidi.Track.Events[0] = new MidiEvent(16,16,0,9,0,126,127);
            this.Controls.Add(PreviewTheScoreUserControl);

            LoadMiscOptions();
            LoadDisplayOptions();
        }
        #endregion

        #region Methods
        public void LoadMiscOptions()
        {
            BarsDisplayedTextBox.Text = BarsDisplayed.ToString();
            QuarterBarTextBox.Text = QtrBeatsPerBar.ToString();
        }
        public void LoadDisplayOptions()
        {
            GridPictureBox.BackColor = GridLines;
            BGPictureBox.BackColor = BackGround.Color;
            BarOctPictureBox.BackColor = BarSeparator;
            QtrPictureBox.BackColor = QtrNoteSeparator;
            NoteOutlinePictureBox.BackColor = NoteOutline.Color;
            NoteFillPictureBox.BackColor = NoteFill;
        }
        #endregion

        #region Events
        private void GridPictureBox_Click(object sender, EventArgs e)
        {
            OptionsColorDialog.Color = GridPictureBox.BackColor;
            OptionsColorDialog.ShowDialog();
            GridPictureBox.BackColor = OptionsColorDialog.Color;
        }

        private void BGPictureBox_Click(object sender, EventArgs e)
        {
            OptionsColorDialog.Color = BGPictureBox.BackColor;
            OptionsColorDialog.ShowDialog();
            BGPictureBox.BackColor = OptionsColorDialog.Color;
        }

        private void BarOctPictureBox_Click(object sender, EventArgs e)
        {
            OptionsColorDialog.Color = BarOctPictureBox.BackColor;
            OptionsColorDialog.ShowDialog();
            BarOctPictureBox.BackColor = OptionsColorDialog.Color;
        }

        private void QtrPictureBox_Click(object sender, EventArgs e)
        {
            OptionsColorDialog.Color = QtrPictureBox.BackColor;
            OptionsColorDialog.ShowDialog();
            QtrPictureBox.BackColor = OptionsColorDialog.Color;
        }

        private void NoteFillPictureBox_Click(object sender, EventArgs e)
        {
            OptionsColorDialog.Color = NoteFillPictureBox.BackColor;
            OptionsColorDialog.ShowDialog();
            NoteFillPictureBox.BackColor = OptionsColorDialog.Color;
        }

        private void NoteOutlinePictureBox_Click(object sender, EventArgs e)
        {
            OptionsColorDialog.Color = NoteOutlinePictureBox.BackColor;
            OptionsColorDialog.ShowDialog();
            NoteOutlinePictureBox.BackColor = OptionsColorDialog.Color;
        }


        private void DefaultButton_Click(object sender, EventArgs e)
        {
            GridPictureBox.BackColor = Color.LightBlue;
            BGPictureBox.BackColor = Color.SteelBlue;
            QtrPictureBox.BackColor = Color.White;
            BarOctPictureBox.BackColor = Color.Black;
            NoteFillPictureBox.BackColor = Color.LightBlue;
            NoteOutlinePictureBox.BackColor = Color.Purple;

            ApplyButton_Click(sender, e);
        }
        private void ApplyButton_Click(object sender, EventArgs e)
        {
            try
            {
                (Properties.Settings.Default.GridLines) = GridPictureBox.BackColor;
                (Properties.Settings.Default.BackGround) = BGPictureBox.BackColor;
                (Properties.Settings.Default.QtrNoteSeparator) = QtrPictureBox.BackColor;
                (Properties.Settings.Default.BarSeparator) = BarOctPictureBox.BackColor;
                (Properties.Settings.Default.NoteFill) = NoteFillPictureBox.BackColor;
                (Properties.Settings.Default.NoteOutline) = NoteOutlinePictureBox.BackColor;
                Properties.Settings.Default.Save();

            }
            catch
            {
                MessageBox.Show("Error Recording Colour Scheme");
                LoadDisplayOptions();
            }
            PreviewTheScoreUserControl.PaintGrid();
        }
        private void OKButton_Click(object sender, EventArgs e)
        {
            try
            {
                (Properties.Settings.Default.GridLines) = GridPictureBox.BackColor;
                (Properties.Settings.Default.BackGround) = BGPictureBox.BackColor;
                (Properties.Settings.Default.QtrNoteSeparator) = QtrPictureBox.BackColor;
                (Properties.Settings.Default.BarSeparator) = BarOctPictureBox.BackColor;
                (Properties.Settings.Default.NoteFill) = NoteFillPictureBox.BackColor;
                (Properties.Settings.Default.NoteOutline) = NoteOutlinePictureBox.BackColor;
                Properties.Settings.Default.Save();

            }
            catch
            {
                MessageBox.Show("Error Recording Colour Scheme");
                LoadDisplayOptions();
            }
            this.Close();
        }

        private void MiscDefaultButton_Click(object sender, EventArgs e)
        {
            BarsDisplayedTextBox.Text = Convert.ToString(20);
            QuarterBarTextBox.Text = Convert.ToString(4);
           
            MiscApplyButton_Click(sender,e);
        }
        private void MiscApplyButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(BarsDisplayedTextBox.Text) > 0 && Convert.ToInt32(QuarterBarTextBox.Text) > 0)
                {
                    Properties.Settings.Default.SixteenNoteMeasureCount = Convert.ToInt32(BarsDisplayedTextBox.Text);
                    Properties.Settings.Default.QuarterNoteInMeasure = Convert.ToInt32(QuarterBarTextBox.Text);
                    Properties.Settings.Default.Save();
                }
                else
                {
                    MessageBox.Show("Please Enter a Number Larger than Zero");
                    LoadMiscOptions();
                }
            }
            catch
            {
                MessageBox.Show("Please Enter a Number");
                LoadMiscOptions();
            }
            PreviewTheScoreUserControl.PaintGrid();
        }
        private void MiscOKButton_Click(object sender, EventArgs e)
        {
          
            try
            {

                Properties.Settings.Default.SixteenNoteMeasureCount = Convert.ToInt32(BarsDisplayedTextBox.Text);
                Properties.Settings.Default.QuarterNoteInMeasure = Convert.ToInt32(QuarterBarTextBox.Text);
                Properties.Settings.Default.Save();
            }
            catch
            {
                MessageBox.Show("Please Enter a Number");
                LoadMiscOptions();
            }
            this.Close();
        
        }

    
        #endregion     
  
    }
}
