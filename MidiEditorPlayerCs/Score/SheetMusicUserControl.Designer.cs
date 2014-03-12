namespace MidiEditorPlayerCs
{
    partial class SheetMusicUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SheetMusicUserControl));
            this.SharpFlatLabel = new System.Windows.Forms.Label();
            this.NotePictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.NotePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // SharpFlatLabel
            // 
            this.SharpFlatLabel.AutoSize = true;
            this.SharpFlatLabel.BackColor = System.Drawing.Color.Transparent;
            this.SharpFlatLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SharpFlatLabel.Location = new System.Drawing.Point(3, 220);
            this.SharpFlatLabel.Name = "SharpFlatLabel";
            this.SharpFlatLabel.Size = new System.Drawing.Size(90, 24);
            this.SharpFlatLabel.TabIndex = 5;
            this.SharpFlatLabel.Text = "SharpFlat";
            // 
            // NotePictureBox
            // 
            this.NotePictureBox.BackColor = System.Drawing.Color.Transparent;
            this.NotePictureBox.Image = ((System.Drawing.Image)(resources.GetObject("NotePictureBox.Image")));
            this.NotePictureBox.Location = new System.Drawing.Point(80, 81);
            this.NotePictureBox.Name = "NotePictureBox";
            this.NotePictureBox.Size = new System.Drawing.Size(31, 49);
            this.NotePictureBox.TabIndex = 6;
            this.NotePictureBox.TabStop = false;
            // 
            // SheetMusicUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::MidiEditorPlayerCs.Properties.Resources.SheetMusic;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Controls.Add(this.NotePictureBox);
            this.Controls.Add(this.SharpFlatLabel);
            this.DoubleBuffered = true;
            this.Name = "SheetMusicUserControl";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Size = new System.Drawing.Size(302, 318);
            ((System.ComponentModel.ISupportInitialize)(this.NotePictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label SharpFlatLabel;
        private System.Windows.Forms.PictureBox NotePictureBox;



    }
}
