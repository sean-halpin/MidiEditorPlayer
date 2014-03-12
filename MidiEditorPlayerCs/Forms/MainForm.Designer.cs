namespace MidiEditorPlayerCs
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.NoteLengthComboBox = new System.Windows.Forms.ComboBox();
            this.ButtonPanel = new System.Windows.Forms.Panel();
            this.ChannelLabel = new System.Windows.Forms.Label();
            this.ChannelComboBox = new System.Windows.Forms.ComboBox();
            this.ToolPanel = new System.Windows.Forms.Panel();
            this.SnapButton = new System.Windows.Forms.Button();
            this.TempoButton = new System.Windows.Forms.Button();
            this.InstrumentButton = new System.Windows.Forms.Button();
            this.ZoomMinusButton = new System.Windows.Forms.Button();
            this.ZoomPlusButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.SelectButton = new System.Windows.Forms.Button();
            this.MyMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeCompositionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MidiToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.PlayButton = new System.Windows.Forms.Button();
            this.StopButton = new System.Windows.Forms.Button();
            this.PlaybackPanel = new System.Windows.Forms.Panel();
            this.VolumeTrackBar = new System.Windows.Forms.TrackBar();
            this.MyStatusStrip = new System.Windows.Forms.StatusStrip();
            this.SpringToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.CellToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.TempoToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.InstrumentToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.SnapperStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.ButtonPanel.SuspendLayout();
            this.ToolPanel.SuspendLayout();
            this.MyMenuStrip.SuspendLayout();
            this.PlaybackPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VolumeTrackBar)).BeginInit();
            this.MyStatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // NoteLengthComboBox
            // 
            this.NoteLengthComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.NoteLengthComboBox.FormattingEnabled = true;
            this.NoteLengthComboBox.Items.AddRange(new object[] {
            "64th",
            "32nd",
            "16th",
            "8th",
            "Quarter",
            "Half",
            "Whole"});
            this.NoteLengthComboBox.Location = new System.Drawing.Point(4, 3);
            this.NoteLengthComboBox.Name = "NoteLengthComboBox";
            this.NoteLengthComboBox.Size = new System.Drawing.Size(55, 21);
            this.NoteLengthComboBox.TabIndex = 0;
            this.MidiToolTip.SetToolTip(this.NoteLengthComboBox, "Choose Note Length");
            this.NoteLengthComboBox.SelectedIndexChanged += new System.EventHandler(this.NoteLengthComboBox_SelectedIndexChanged);
            // 
            // ButtonPanel
            // 
            this.ButtonPanel.Controls.Add(this.ChannelLabel);
            this.ButtonPanel.Controls.Add(this.ChannelComboBox);
            this.ButtonPanel.Enabled = false;
            this.ButtonPanel.Location = new System.Drawing.Point(6, 28);
            this.ButtonPanel.Name = "ButtonPanel";
            this.ButtonPanel.Size = new System.Drawing.Size(566, 32);
            this.ButtonPanel.TabIndex = 16;
            // 
            // ChannelLabel
            // 
            this.ChannelLabel.AutoSize = true;
            this.ChannelLabel.Location = new System.Drawing.Point(57, 6);
            this.ChannelLabel.Name = "ChannelLabel";
            this.ChannelLabel.Size = new System.Drawing.Size(86, 13);
            this.ChannelLabel.TabIndex = 26;
            this.ChannelLabel.Text = "Current Channel:";
            this.ChannelLabel.Visible = false;
            // 
            // ChannelComboBox
            // 
            this.ChannelComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ChannelComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ChannelComboBox.Enabled = false;
            this.ChannelComboBox.FormattingEnabled = true;
            this.ChannelComboBox.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15"});
            this.ChannelComboBox.Location = new System.Drawing.Point(149, 3);
            this.ChannelComboBox.Name = "ChannelComboBox";
            this.ChannelComboBox.Size = new System.Drawing.Size(100, 21);
            this.ChannelComboBox.TabIndex = 24;
            this.MidiToolTip.SetToolTip(this.ChannelComboBox, "Set Current Channel");
            this.ChannelComboBox.Visible = false;
            // 
            // ToolPanel
            // 
            this.ToolPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ToolPanel.BackColor = System.Drawing.Color.Gainsboro;
            this.ToolPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ToolPanel.Controls.Add(this.SnapButton);
            this.ToolPanel.Controls.Add(this.TempoButton);
            this.ToolPanel.Controls.Add(this.InstrumentButton);
            this.ToolPanel.Controls.Add(this.ZoomMinusButton);
            this.ToolPanel.Controls.Add(this.ZoomPlusButton);
            this.ToolPanel.Controls.Add(this.NoteLengthComboBox);
            this.ToolPanel.Controls.Add(this.DeleteButton);
            this.ToolPanel.Controls.Add(this.SelectButton);
            this.ToolPanel.Enabled = false;
            this.ToolPanel.Location = new System.Drawing.Point(510, 66);
            this.ToolPanel.Name = "ToolPanel";
            this.ToolPanel.Size = new System.Drawing.Size(66, 147);
            this.ToolPanel.TabIndex = 18;
            // 
            // SnapButton
            // 
            this.SnapButton.Location = new System.Drawing.Point(4, 117);
            this.SnapButton.Name = "SnapButton";
            this.SnapButton.Size = new System.Drawing.Size(55, 23);
            this.SnapButton.TabIndex = 7;
            this.SnapButton.Text = "Snap";
            this.MidiToolTip.SetToolTip(this.SnapButton, "Toggle Snap Tool");
            this.SnapButton.UseVisualStyleBackColor = true;
            this.SnapButton.Click += new System.EventHandler(this.SnapButton_Click);
            // 
            // TempoButton
            // 
            this.TempoButton.Image = ((System.Drawing.Image)(resources.GetObject("TempoButton.Image")));
            this.TempoButton.Location = new System.Drawing.Point(34, 88);
            this.TempoButton.Name = "TempoButton";
            this.TempoButton.Size = new System.Drawing.Size(25, 23);
            this.TempoButton.TabIndex = 6;
            this.MidiToolTip.SetToolTip(this.TempoButton, "New Tempo Event");
            this.TempoButton.UseVisualStyleBackColor = true;
            this.TempoButton.Click += new System.EventHandler(this.TempoButton_Click);
            // 
            // InstrumentButton
            // 
            this.InstrumentButton.Image = ((System.Drawing.Image)(resources.GetObject("InstrumentButton.Image")));
            this.InstrumentButton.Location = new System.Drawing.Point(4, 88);
            this.InstrumentButton.Name = "InstrumentButton";
            this.InstrumentButton.Size = new System.Drawing.Size(25, 23);
            this.InstrumentButton.TabIndex = 5;
            this.MidiToolTip.SetToolTip(this.InstrumentButton, "New Instrument Event");
            this.InstrumentButton.UseVisualStyleBackColor = true;
            this.InstrumentButton.Click += new System.EventHandler(this.InstrumentButton_Click);
            // 
            // ZoomMinusButton
            // 
            this.ZoomMinusButton.Image = ((System.Drawing.Image)(resources.GetObject("ZoomMinusButton.Image")));
            this.ZoomMinusButton.Location = new System.Drawing.Point(34, 59);
            this.ZoomMinusButton.Name = "ZoomMinusButton";
            this.ZoomMinusButton.Size = new System.Drawing.Size(25, 23);
            this.ZoomMinusButton.TabIndex = 4;
            this.MidiToolTip.SetToolTip(this.ZoomMinusButton, "Zoom Out");
            this.ZoomMinusButton.UseVisualStyleBackColor = true;
            this.ZoomMinusButton.Click += new System.EventHandler(this.ZoomMinusButton_Click);
            // 
            // ZoomPlusButton
            // 
            this.ZoomPlusButton.Image = ((System.Drawing.Image)(resources.GetObject("ZoomPlusButton.Image")));
            this.ZoomPlusButton.Location = new System.Drawing.Point(4, 59);
            this.ZoomPlusButton.Name = "ZoomPlusButton";
            this.ZoomPlusButton.Size = new System.Drawing.Size(25, 23);
            this.ZoomPlusButton.TabIndex = 3;
            this.MidiToolTip.SetToolTip(this.ZoomPlusButton, "Zoom In");
            this.ZoomPlusButton.UseVisualStyleBackColor = true;
            this.ZoomPlusButton.Click += new System.EventHandler(this.ZoomPlusButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Image = ((System.Drawing.Image)(resources.GetObject("DeleteButton.Image")));
            this.DeleteButton.Location = new System.Drawing.Point(34, 30);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(25, 23);
            this.DeleteButton.TabIndex = 2;
            this.MidiToolTip.SetToolTip(this.DeleteButton, "Delete");
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // SelectButton
            // 
            this.SelectButton.Image = ((System.Drawing.Image)(resources.GetObject("SelectButton.Image")));
            this.SelectButton.Location = new System.Drawing.Point(4, 30);
            this.SelectButton.Name = "SelectButton";
            this.SelectButton.Size = new System.Drawing.Size(25, 23);
            this.SelectButton.TabIndex = 1;
            this.MidiToolTip.SetToolTip(this.SelectButton, "Select Notes");
            this.SelectButton.UseVisualStyleBackColor = true;
            this.SelectButton.Click += new System.EventHandler(this.SelectButton_Click);
            // 
            // MyMenuStrip
            // 
            this.MyMenuStrip.BackColor = System.Drawing.Color.LightGray;
            this.MyMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.toolsToolStripMenuItem});
            this.MyMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MyMenuStrip.Name = "MyMenuStrip";
            this.MyMenuStrip.Size = new System.Drawing.Size(589, 24);
            this.MyMenuStrip.TabIndex = 15;
            this.MyMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.closeCompositionToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.newToolStripMenuItem.Text = "&New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.saveAsToolStripMenuItem.Text = "&Save As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // closeCompositionToolStripMenuItem
            // 
            this.closeCompositionToolStripMenuItem.Name = "closeCompositionToolStripMenuItem";
            this.closeCompositionToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.closeCompositionToolStripMenuItem.Text = "&Close Composition";
            this.closeCompositionToolStripMenuItem.Click += new System.EventHandler(this.closeCompositionToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.selectAllToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "&Edit";
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.cutToolStripMenuItem.Text = "&Cut";
            this.cutToolStripMenuItem.Click += new System.EventHandler(this.cutToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.copyToolStripMenuItem.Text = "C&opy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.pasteToolStripMenuItem.Text = "&Paste";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.deleteToolStripMenuItem.Text = "&Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.selectAllToolStripMenuItem.Text = "&Select All";
            this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.selectAllToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.toolsToolStripMenuItem.Text = "&Tools";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.optionsToolStripMenuItem.Text = "&Options";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // PlayButton
            // 
            this.PlayButton.Image = ((System.Drawing.Image)(resources.GetObject("PlayButton.Image")));
            this.PlayButton.Location = new System.Drawing.Point(3, 3);
            this.PlayButton.Name = "PlayButton";
            this.PlayButton.Size = new System.Drawing.Size(25, 23);
            this.PlayButton.TabIndex = 0;
            this.MidiToolTip.SetToolTip(this.PlayButton, "Play");
            this.PlayButton.UseVisualStyleBackColor = true;
            this.PlayButton.Click += new System.EventHandler(this.PlayButton_Click);
            // 
            // StopButton
            // 
            this.StopButton.Image = ((System.Drawing.Image)(resources.GetObject("StopButton.Image")));
            this.StopButton.Location = new System.Drawing.Point(34, 3);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(25, 23);
            this.StopButton.TabIndex = 1;
            this.MidiToolTip.SetToolTip(this.StopButton, "Stop");
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // PlaybackPanel
            // 
            this.PlaybackPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PlaybackPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PlaybackPanel.Controls.Add(this.VolumeTrackBar);
            this.PlaybackPanel.Controls.Add(this.PlayButton);
            this.PlaybackPanel.Controls.Add(this.StopButton);
            this.PlaybackPanel.Location = new System.Drawing.Point(67, 404);
            this.PlaybackPanel.Name = "PlaybackPanel";
            this.PlaybackPanel.Size = new System.Drawing.Size(192, 31);
            this.PlaybackPanel.TabIndex = 28;
            // 
            // VolumeTrackBar
            // 
            this.VolumeTrackBar.LargeChange = 2;
            this.VolumeTrackBar.Location = new System.Drawing.Point(65, 3);
            this.VolumeTrackBar.Name = "VolumeTrackBar";
            this.VolumeTrackBar.Size = new System.Drawing.Size(127, 45);
            this.VolumeTrackBar.TabIndex = 30;
            this.VolumeTrackBar.ValueChanged += new System.EventHandler(this.VolumeTrackBar_ValueChanged);
            // 
            // MyStatusStrip
            // 
            this.MyStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SpringToolStripStatusLabel,
            this.CellToolStripStatusLabel,
            this.TempoToolStripStatusLabel,
            this.InstrumentToolStripStatusLabel,
            this.SnapperStatus});
            this.MyStatusStrip.Location = new System.Drawing.Point(0, 438);
            this.MyStatusStrip.Name = "MyStatusStrip";
            this.MyStatusStrip.Size = new System.Drawing.Size(589, 24);
            this.MyStatusStrip.TabIndex = 29;
            this.MyStatusStrip.Text = "MyStatusStrip";
            // 
            // SpringToolStripStatusLabel
            // 
            this.SpringToolStripStatusLabel.Name = "SpringToolStripStatusLabel";
            this.SpringToolStripStatusLabel.Size = new System.Drawing.Size(216, 19);
            this.SpringToolStripStatusLabel.Spring = true;
            // 
            // CellToolStripStatusLabel
            // 
            this.CellToolStripStatusLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.CellToolStripStatusLabel.Name = "CellToolStripStatusLabel";
            this.CellToolStripStatusLabel.Size = new System.Drawing.Size(104, 19);
            this.CellToolStripStatusLabel.Text = "Bar 0  Row 0  Col 0";
            // 
            // TempoToolStripStatusLabel
            // 
            this.TempoToolStripStatusLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.TempoToolStripStatusLabel.Name = "TempoToolStripStatusLabel";
            this.TempoToolStripStatusLabel.Size = new System.Drawing.Size(60, 19);
            this.TempoToolStripStatusLabel.Text = "BPM: 120";
            // 
            // InstrumentToolStripStatusLabel
            // 
            this.InstrumentToolStripStatusLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.InstrumentToolStripStatusLabel.Name = "InstrumentToolStripStatusLabel";
            this.InstrumentToolStripStatusLabel.Size = new System.Drawing.Size(125, 19);
            this.InstrumentToolStripStatusLabel.Text = "Acoustic Grand Piano";
            // 
            // SnapperStatus
            // 
            this.SnapperStatus.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.SnapperStatus.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.SnapperStatus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.SnapperStatus.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.SnapperStatus.Name = "SnapperStatus";
            this.SnapperStatus.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.SnapperStatus.Size = new System.Drawing.Size(69, 19);
            this.SnapperStatus.Text = "Free-Mode";
            this.SnapperStatus.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 462);
            this.Controls.Add(this.MyStatusStrip);
            this.Controls.Add(this.PlaybackPanel);
            this.Controls.Add(this.ToolPanel);
            this.Controls.Add(this.ButtonPanel);
            this.Controls.Add(this.MyMenuStrip);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.MyMenuStrip;
            this.MinimumSize = new System.Drawing.Size(600, 500);
            this.Name = "MainForm";
            this.Text = "Midi Editor & Player";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.ButtonPanel.ResumeLayout(false);
            this.ButtonPanel.PerformLayout();
            this.ToolPanel.ResumeLayout(false);
            this.MyMenuStrip.ResumeLayout(false);
            this.MyMenuStrip.PerformLayout();
            this.PlaybackPanel.ResumeLayout(false);
            this.PlaybackPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VolumeTrackBar)).EndInit();
            this.MyStatusStrip.ResumeLayout(false);
            this.MyStatusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ComboBox NoteLengthComboBox;
        private System.Windows.Forms.Panel ButtonPanel;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.Button PlayButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button SelectButton;
        private System.Windows.Forms.Button ZoomPlusButton;
        private System.Windows.Forms.Button ZoomMinusButton;
        private System.Windows.Forms.Panel ToolPanel;
        internal System.Windows.Forms.ComboBox ChannelComboBox;
        private System.Windows.Forms.MenuStrip MyMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.Label ChannelLabel;
        private System.Windows.Forms.Button InstrumentButton;
        private System.Windows.Forms.Button TempoButton;
        private System.Windows.Forms.ToolTip MidiToolTip;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.Panel PlaybackPanel;
        private System.Windows.Forms.Button SnapButton;
        private System.Windows.Forms.StatusStrip MyStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel SnapperStatus;
        private System.Windows.Forms.ToolStripStatusLabel SpringToolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel CellToolStripStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem closeCompositionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel InstrumentToolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel TempoToolStripStatusLabel;
        private System.Windows.Forms.TrackBar VolumeTrackBar;
      



    }
}