namespace MidiEditorPlayerCs
{
    partial class ScoreUserControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ScorePanel = new System.Windows.Forms.Panel();
            this.ScorePictureBox = new System.Windows.Forms.PictureBox();
            this.PianoPictureBox = new System.Windows.Forms.PictureBox();
            this.PianoPanel = new System.Windows.Forms.Panel();
            this.ScorePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ScorePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PianoPictureBox)).BeginInit();
            this.PianoPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ScorePanel
            // 
            this.ScorePanel.AutoScroll = true;
            this.ScorePanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ScorePanel.Controls.Add(this.ScorePictureBox);
            this.ScorePanel.Location = new System.Drawing.Point(55, 0);
            this.ScorePanel.Margin = new System.Windows.Forms.Padding(0);
            this.ScorePanel.Name = "ScorePanel";
            this.ScorePanel.Size = new System.Drawing.Size(395, 210);
            this.ScorePanel.TabIndex = 2;
            this.ScorePanel.Scroll += new System.Windows.Forms.ScrollEventHandler(this.ScorePanel_Scroll);
            // 
            // ScorePictureBox
            // 
            this.ScorePictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ScorePictureBox.Location = new System.Drawing.Point(0, 0);
            this.ScorePictureBox.Margin = new System.Windows.Forms.Padding(0);
            this.ScorePictureBox.Name = "ScorePictureBox";
            this.ScorePictureBox.Size = new System.Drawing.Size(240, 149);
            this.ScorePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.ScorePictureBox.TabIndex = 0;
            this.ScorePictureBox.TabStop = false;
            this.ScorePictureBox.WaitOnLoad = true;
            this.ScorePictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ScorePictureBox_MouseMove);
            this.ScorePictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ScorePictureBox_MouseClick);
            this.ScorePictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ScorePictureBox_MouseDown);
            this.ScorePictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.ScorePictureBox_Paint);
            this.ScorePictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ScorePictureBox_MouseUp);
            // 
            // PianoPictureBox
            // 
            this.PianoPictureBox.Location = new System.Drawing.Point(0, 0);
            this.PianoPictureBox.Margin = new System.Windows.Forms.Padding(0);
            this.PianoPictureBox.Name = "PianoPictureBox";
            this.PianoPictureBox.Size = new System.Drawing.Size(55, 161);
            this.PianoPictureBox.TabIndex = 3;
            this.PianoPictureBox.TabStop = false;
            // 
            // PianoPanel
            // 
            this.PianoPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PianoPanel.Controls.Add(this.PianoPictureBox);
            this.PianoPanel.Location = new System.Drawing.Point(0, 0);
            this.PianoPanel.Margin = new System.Windows.Forms.Padding(0);
            this.PianoPanel.Name = "PianoPanel";
            this.PianoPanel.Size = new System.Drawing.Size(55, 210);
            this.PianoPanel.TabIndex = 3;
            // 
            // ScoreUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ScorePanel);
            this.Controls.Add(this.PianoPanel);
            this.Name = "ScoreUserControl";
            this.Size = new System.Drawing.Size(450, 210);
            this.Resize += new System.EventHandler(this.ScoreUserControl_Resize);
            this.ScorePanel.ResumeLayout(false);
            this.ScorePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ScorePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PianoPictureBox)).EndInit();
            this.PianoPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.PictureBox ScorePictureBox;
        internal System.Windows.Forms.PictureBox PianoPictureBox;
        internal System.Windows.Forms.Panel PianoPanel;
        public System.Windows.Forms.Panel ScorePanel;



    }
}
