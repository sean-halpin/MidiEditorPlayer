namespace MidiEditorPlayerCs
{
    partial class OptionsForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.OptionsTabControl = new System.Windows.Forms.TabControl();
            this.CompositionTab = new System.Windows.Forms.TabPage();
            this.MiscApplyButton = new System.Windows.Forms.Button();
            this.MiscOKButton = new System.Windows.Forms.Button();
            this.MiscDefaultButton = new System.Windows.Forms.Button();
            this.CompGroupBox = new System.Windows.Forms.GroupBox();
            this.QtrBeatsPerBarLabel = new System.Windows.Forms.Label();
            this.QuarterBarTextBox = new System.Windows.Forms.TextBox();
            this.BarsLabel = new System.Windows.Forms.Label();
            this.BarsDisplayedTextBox = new System.Windows.Forms.TextBox();
            this.DisplayTab = new System.Windows.Forms.TabPage();
            this.ApplyButton = new System.Windows.Forms.Button();
            this.ColourPanel = new System.Windows.Forms.Panel();
            this.ColourSchemeGroupBox = new System.Windows.Forms.GroupBox();
            this.NoteOutlinePictureBox = new System.Windows.Forms.PictureBox();
            this.NoteFillPictureBox = new System.Windows.Forms.PictureBox();
            this.QtrPictureBox = new System.Windows.Forms.PictureBox();
            this.BarOctPictureBox = new System.Windows.Forms.PictureBox();
            this.BGPictureBox = new System.Windows.Forms.PictureBox();
            this.GridPictureBox = new System.Windows.Forms.PictureBox();
            this.NoteOutlineLabel = new System.Windows.Forms.Label();
            this.NoteFillingLabel = new System.Windows.Forms.Label();
            this.GridLabel = new System.Windows.Forms.Label();
            this.BGLabel = new System.Windows.Forms.Label();
            this.Qtrlabel = new System.Windows.Forms.Label();
            this.BarLabel = new System.Windows.Forms.Label();
            this.OKButton = new System.Windows.Forms.Button();
            this.DefaultButton = new System.Windows.Forms.Button();
            this.OptionsToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.OptionsColorDialog = new System.Windows.Forms.ColorDialog();
            this.PreviewLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.OptionsTabControl.SuspendLayout();
            this.CompositionTab.SuspendLayout();
            this.CompGroupBox.SuspendLayout();
            this.DisplayTab.SuspendLayout();
            this.ColourPanel.SuspendLayout();
            this.ColourSchemeGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NoteOutlinePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NoteFillPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QtrPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarOctPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BGPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // OptionsTabControl
            // 
            this.OptionsTabControl.Controls.Add(this.CompositionTab);
            this.OptionsTabControl.Controls.Add(this.DisplayTab);
            this.OptionsTabControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.OptionsTabControl.Location = new System.Drawing.Point(0, 0);
            this.OptionsTabControl.Name = "OptionsTabControl";
            this.OptionsTabControl.SelectedIndex = 0;
            this.OptionsTabControl.Size = new System.Drawing.Size(431, 241);
            this.OptionsTabControl.TabIndex = 0;
            // 
            // CompositionTab
            // 
            this.CompositionTab.Controls.Add(this.MiscApplyButton);
            this.CompositionTab.Controls.Add(this.MiscOKButton);
            this.CompositionTab.Controls.Add(this.MiscDefaultButton);
            this.CompositionTab.Controls.Add(this.CompGroupBox);
            this.CompositionTab.Location = new System.Drawing.Point(4, 22);
            this.CompositionTab.Name = "CompositionTab";
            this.CompositionTab.Padding = new System.Windows.Forms.Padding(3);
            this.CompositionTab.Size = new System.Drawing.Size(423, 215);
            this.CompositionTab.TabIndex = 0;
            this.CompositionTab.Text = "Misc";
            this.CompositionTab.UseVisualStyleBackColor = true;
            // 
            // MiscApplyButton
            // 
            this.MiscApplyButton.Location = new System.Drawing.Point(259, 189);
            this.MiscApplyButton.Name = "MiscApplyButton";
            this.MiscApplyButton.Size = new System.Drawing.Size(75, 23);
            this.MiscApplyButton.TabIndex = 1;
            this.MiscApplyButton.Text = "&Apply";
            this.MiscApplyButton.UseVisualStyleBackColor = true;
            this.MiscApplyButton.Click += new System.EventHandler(this.MiscApplyButton_Click);
            // 
            // MiscOKButton
            // 
            this.MiscOKButton.Location = new System.Drawing.Point(340, 189);
            this.MiscOKButton.Name = "MiscOKButton";
            this.MiscOKButton.Size = new System.Drawing.Size(75, 23);
            this.MiscOKButton.TabIndex = 2;
            this.MiscOKButton.Text = "&OK";
            this.MiscOKButton.UseVisualStyleBackColor = true;
            this.MiscOKButton.Click += new System.EventHandler(this.MiscOKButton_Click);
            // 
            // MiscDefaultButton
            // 
            this.MiscDefaultButton.Location = new System.Drawing.Point(178, 189);
            this.MiscDefaultButton.Name = "MiscDefaultButton";
            this.MiscDefaultButton.Size = new System.Drawing.Size(75, 23);
            this.MiscDefaultButton.TabIndex = 0;
            this.MiscDefaultButton.Text = "&Default";
            this.MiscDefaultButton.UseVisualStyleBackColor = true;
            this.MiscDefaultButton.Click += new System.EventHandler(this.MiscDefaultButton_Click);
            // 
            // CompGroupBox
            // 
            this.CompGroupBox.Controls.Add(this.QtrBeatsPerBarLabel);
            this.CompGroupBox.Controls.Add(this.QuarterBarTextBox);
            this.CompGroupBox.Controls.Add(this.BarsLabel);
            this.CompGroupBox.Controls.Add(this.BarsDisplayedTextBox);
            this.CompGroupBox.Location = new System.Drawing.Point(6, 6);
            this.CompGroupBox.Name = "CompGroupBox";
            this.CompGroupBox.Size = new System.Drawing.Size(408, 88);
            this.CompGroupBox.TabIndex = 2;
            this.CompGroupBox.TabStop = false;
            this.CompGroupBox.Text = "Composition";
            // 
            // QtrBeatsPerBarLabel
            // 
            this.QtrBeatsPerBarLabel.AutoSize = true;
            this.QtrBeatsPerBarLabel.Location = new System.Drawing.Point(6, 58);
            this.QtrBeatsPerBarLabel.Name = "QtrBeatsPerBarLabel";
            this.QtrBeatsPerBarLabel.Size = new System.Drawing.Size(117, 13);
            this.QtrBeatsPerBarLabel.TabIndex = 4;
            this.QtrBeatsPerBarLabel.Text = "Quarter Notes Per Bar :";
            // 
            // QuarterBarTextBox
            // 
            this.QuarterBarTextBox.Location = new System.Drawing.Point(128, 55);
            this.QuarterBarTextBox.Name = "QuarterBarTextBox";
            this.QuarterBarTextBox.Size = new System.Drawing.Size(100, 20);
            this.QuarterBarTextBox.TabIndex = 1;
            // 
            // BarsLabel
            // 
            this.BarsLabel.AutoSize = true;
            this.BarsLabel.Location = new System.Drawing.Point(6, 32);
            this.BarsLabel.Name = "BarsLabel";
            this.BarsLabel.Size = new System.Drawing.Size(99, 13);
            this.BarsLabel.TabIndex = 0;
            this.BarsLabel.Text = "16 Beat Measures :";
            // 
            // BarsDisplayedTextBox
            // 
            this.BarsDisplayedTextBox.Location = new System.Drawing.Point(128, 29);
            this.BarsDisplayedTextBox.Name = "BarsDisplayedTextBox";
            this.BarsDisplayedTextBox.Size = new System.Drawing.Size(100, 20);
            this.BarsDisplayedTextBox.TabIndex = 0;
            // 
            // DisplayTab
            // 
            this.DisplayTab.Controls.Add(this.ApplyButton);
            this.DisplayTab.Controls.Add(this.ColourPanel);
            this.DisplayTab.Controls.Add(this.OKButton);
            this.DisplayTab.Controls.Add(this.DefaultButton);
            this.DisplayTab.Location = new System.Drawing.Point(4, 22);
            this.DisplayTab.Name = "DisplayTab";
            this.DisplayTab.Padding = new System.Windows.Forms.Padding(3);
            this.DisplayTab.Size = new System.Drawing.Size(423, 215);
            this.DisplayTab.TabIndex = 1;
            this.DisplayTab.Text = "Display";
            this.DisplayTab.UseVisualStyleBackColor = true;
            // 
            // ApplyButton
            // 
            this.ApplyButton.Location = new System.Drawing.Point(259, 189);
            this.ApplyButton.Name = "ApplyButton";
            this.ApplyButton.Size = new System.Drawing.Size(75, 23);
            this.ApplyButton.TabIndex = 1;
            this.ApplyButton.Text = "&Apply";
            this.ApplyButton.UseVisualStyleBackColor = true;
            this.ApplyButton.Click += new System.EventHandler(this.ApplyButton_Click);
            // 
            // ColourPanel
            // 
            this.ColourPanel.Controls.Add(this.ColourSchemeGroupBox);
            this.ColourPanel.Location = new System.Drawing.Point(0, 0);
            this.ColourPanel.Name = "ColourPanel";
            this.ColourPanel.Size = new System.Drawing.Size(423, 183);
            this.ColourPanel.TabIndex = 14;
            // 
            // ColourSchemeGroupBox
            // 
            this.ColourSchemeGroupBox.Controls.Add(this.GridLabel);
            this.ColourSchemeGroupBox.Controls.Add(this.NoteOutlinePictureBox);
            this.ColourSchemeGroupBox.Controls.Add(this.BarLabel);
            this.ColourSchemeGroupBox.Controls.Add(this.NoteFillPictureBox);
            this.ColourSchemeGroupBox.Controls.Add(this.Qtrlabel);
            this.ColourSchemeGroupBox.Controls.Add(this.QtrPictureBox);
            this.ColourSchemeGroupBox.Controls.Add(this.BGLabel);
            this.ColourSchemeGroupBox.Controls.Add(this.BarOctPictureBox);
            this.ColourSchemeGroupBox.Controls.Add(this.NoteFillingLabel);
            this.ColourSchemeGroupBox.Controls.Add(this.BGPictureBox);
            this.ColourSchemeGroupBox.Controls.Add(this.NoteOutlineLabel);
            this.ColourSchemeGroupBox.Controls.Add(this.GridPictureBox);
            this.ColourSchemeGroupBox.Location = new System.Drawing.Point(3, 6);
            this.ColourSchemeGroupBox.Name = "ColourSchemeGroupBox";
            this.ColourSchemeGroupBox.Size = new System.Drawing.Size(417, 174);
            this.ColourSchemeGroupBox.TabIndex = 0;
            this.ColourSchemeGroupBox.TabStop = false;
            this.ColourSchemeGroupBox.Text = "Colour Scheme";
            // 
            // NoteOutlinePictureBox
            // 
            this.NoteOutlinePictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.NoteOutlinePictureBox.Location = new System.Drawing.Point(311, 149);
            this.NoteOutlinePictureBox.Name = "NoteOutlinePictureBox";
            this.NoteOutlinePictureBox.Size = new System.Drawing.Size(100, 20);
            this.NoteOutlinePictureBox.TabIndex = 18;
            this.NoteOutlinePictureBox.TabStop = false;
            this.NoteOutlinePictureBox.Click += new System.EventHandler(this.NoteOutlinePictureBox_Click);
            // 
            // NoteFillPictureBox
            // 
            this.NoteFillPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.NoteFillPictureBox.Location = new System.Drawing.Point(311, 123);
            this.NoteFillPictureBox.Name = "NoteFillPictureBox";
            this.NoteFillPictureBox.Size = new System.Drawing.Size(100, 20);
            this.NoteFillPictureBox.TabIndex = 17;
            this.NoteFillPictureBox.TabStop = false;
            this.NoteFillPictureBox.Click += new System.EventHandler(this.NoteFillPictureBox_Click);
            // 
            // QtrPictureBox
            // 
            this.QtrPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.QtrPictureBox.Location = new System.Drawing.Point(311, 97);
            this.QtrPictureBox.Name = "QtrPictureBox";
            this.QtrPictureBox.Size = new System.Drawing.Size(100, 20);
            this.QtrPictureBox.TabIndex = 16;
            this.QtrPictureBox.TabStop = false;
            this.QtrPictureBox.Click += new System.EventHandler(this.QtrPictureBox_Click);
            // 
            // BarOctPictureBox
            // 
            this.BarOctPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.BarOctPictureBox.Location = new System.Drawing.Point(311, 71);
            this.BarOctPictureBox.Name = "BarOctPictureBox";
            this.BarOctPictureBox.Size = new System.Drawing.Size(100, 20);
            this.BarOctPictureBox.TabIndex = 15;
            this.BarOctPictureBox.TabStop = false;
            this.BarOctPictureBox.Click += new System.EventHandler(this.BarOctPictureBox_Click);
            // 
            // BGPictureBox
            // 
            this.BGPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.BGPictureBox.Location = new System.Drawing.Point(311, 45);
            this.BGPictureBox.Name = "BGPictureBox";
            this.BGPictureBox.Size = new System.Drawing.Size(100, 20);
            this.BGPictureBox.TabIndex = 14;
            this.BGPictureBox.TabStop = false;
            this.BGPictureBox.Click += new System.EventHandler(this.BGPictureBox_Click);
            // 
            // GridPictureBox
            // 
            this.GridPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.GridPictureBox.Location = new System.Drawing.Point(311, 19);
            this.GridPictureBox.Name = "GridPictureBox";
            this.GridPictureBox.Size = new System.Drawing.Size(100, 20);
            this.GridPictureBox.TabIndex = 13;
            this.GridPictureBox.TabStop = false;
            this.GridPictureBox.Click += new System.EventHandler(this.GridPictureBox_Click);
            // 
            // NoteOutlineLabel
            // 
            this.NoteOutlineLabel.AutoSize = true;
            this.NoteOutlineLabel.Location = new System.Drawing.Point(139, 152);
            this.NoteOutlineLabel.Name = "NoteOutlineLabel";
            this.NoteOutlineLabel.Size = new System.Drawing.Size(72, 13);
            this.NoteOutlineLabel.TabIndex = 9;
            this.NoteOutlineLabel.Text = "Note Outline :";
            // 
            // NoteFillingLabel
            // 
            this.NoteFillingLabel.AutoSize = true;
            this.NoteFillingLabel.Location = new System.Drawing.Point(139, 126);
            this.NoteFillingLabel.Name = "NoteFillingLabel";
            this.NoteFillingLabel.Size = new System.Drawing.Size(65, 13);
            this.NoteFillingLabel.TabIndex = 10;
            this.NoteFillingLabel.Text = "Note Filling :";
            // 
            // GridLabel
            // 
            this.GridLabel.AutoSize = true;
            this.GridLabel.Location = new System.Drawing.Point(139, 22);
            this.GridLabel.Name = "GridLabel";
            this.GridLabel.Size = new System.Drawing.Size(60, 13);
            this.GridLabel.TabIndex = 4;
            this.GridLabel.Text = "Grid Lines :";
            // 
            // BGLabel
            // 
            this.BGLabel.AutoSize = true;
            this.BGLabel.Location = new System.Drawing.Point(139, 48);
            this.BGLabel.Name = "BGLabel";
            this.BGLabel.Size = new System.Drawing.Size(73, 13);
            this.BGLabel.TabIndex = 1;
            this.BGLabel.Text = "BackGround :";
            // 
            // Qtrlabel
            // 
            this.Qtrlabel.AutoSize = true;
            this.Qtrlabel.Location = new System.Drawing.Point(139, 100);
            this.Qtrlabel.Name = "Qtrlabel";
            this.Qtrlabel.Size = new System.Drawing.Size(123, 13);
            this.Qtrlabel.TabIndex = 2;
            this.Qtrlabel.Text = "Quarter Note Separator :";
            // 
            // BarLabel
            // 
            this.BarLabel.AutoSize = true;
            this.BarLabel.Location = new System.Drawing.Point(139, 74);
            this.BarLabel.Name = "BarLabel";
            this.BarLabel.Size = new System.Drawing.Size(118, 13);
            this.BarLabel.TabIndex = 3;
            this.BarLabel.Text = "Bar/Octave Separator :";
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(340, 189);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 23);
            this.OKButton.TabIndex = 2;
            this.OKButton.Text = "&OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // DefaultButton
            // 
            this.DefaultButton.Location = new System.Drawing.Point(178, 189);
            this.DefaultButton.Name = "DefaultButton";
            this.DefaultButton.Size = new System.Drawing.Size(75, 23);
            this.DefaultButton.TabIndex = 0;
            this.DefaultButton.Text = "&Default";
            this.DefaultButton.UseVisualStyleBackColor = true;
            this.DefaultButton.Click += new System.EventHandler(this.DefaultButton_Click);
            // 
            // PreviewLabel
            // 
            this.PreviewLabel.AutoSize = true;
            this.PreviewLabel.Location = new System.Drawing.Point(13, 244);
            this.PreviewLabel.Name = "PreviewLabel";
            this.PreviewLabel.Size = new System.Drawing.Size(48, 13);
            this.PreviewLabel.TabIndex = 13;
            this.PreviewLabel.Text = "Preview:";
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(4, 260);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(0, 0);
            this.panel1.TabIndex = 14;
            // 
            // OptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 417);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.PreviewLabel);
            this.Controls.Add(this.OptionsTabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionsForm";
            this.Text = "Options";
            this.TopMost = true;
            this.OptionsTabControl.ResumeLayout(false);
            this.CompositionTab.ResumeLayout(false);
            this.CompGroupBox.ResumeLayout(false);
            this.CompGroupBox.PerformLayout();
            this.DisplayTab.ResumeLayout(false);
            this.ColourPanel.ResumeLayout(false);
            this.ColourSchemeGroupBox.ResumeLayout(false);
            this.ColourSchemeGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NoteOutlinePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NoteFillPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QtrPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarOctPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BGPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl OptionsTabControl;
        private System.Windows.Forms.TabPage CompositionTab;
        private System.Windows.Forms.TabPage DisplayTab;
        private System.Windows.Forms.TextBox BarsDisplayedTextBox;
        private System.Windows.Forms.Label BarsLabel;
        private System.Windows.Forms.GroupBox CompGroupBox;
      
        private System.Windows.Forms.TextBox QuarterBarTextBox;
        private System.Windows.Forms.Button DefaultButton;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button MiscOKButton;
        private System.Windows.Forms.Button MiscDefaultButton;
        private System.Windows.Forms.Label QtrBeatsPerBarLabel;
        private System.Windows.Forms.ToolTip OptionsToolTip;
        private System.Windows.Forms.ColorDialog OptionsColorDialog;
        private System.Windows.Forms.Label PreviewLabel;
        private System.Windows.Forms.Panel ColourPanel;
        private System.Windows.Forms.PictureBox NoteOutlinePictureBox;
        private System.Windows.Forms.PictureBox NoteFillPictureBox;
        private System.Windows.Forms.PictureBox QtrPictureBox;
        private System.Windows.Forms.PictureBox BarOctPictureBox;
        private System.Windows.Forms.PictureBox BGPictureBox;
        private System.Windows.Forms.PictureBox GridPictureBox;
        private System.Windows.Forms.Label NoteOutlineLabel;
        private System.Windows.Forms.Label NoteFillingLabel;
        private System.Windows.Forms.Label GridLabel;
        private System.Windows.Forms.Label BGLabel;
        private System.Windows.Forms.Label Qtrlabel;
        private System.Windows.Forms.Label BarLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button MiscApplyButton;
        private System.Windows.Forms.Button ApplyButton;
        private System.Windows.Forms.GroupBox ColourSchemeGroupBox;
       
    }
}