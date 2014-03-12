namespace MidiEditorPlayerCs
{
    partial class InstrumentSelectForm
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
            this.CancelClickButton = new System.Windows.Forms.Button();
            this.OKButton = new System.Windows.Forms.Button();
            this.InstrumentPanel = new System.Windows.Forms.Panel();
            this.InstrumentLabel = new System.Windows.Forms.Label();
            this.InstrumentComboBox = new System.Windows.Forms.ComboBox();
            this.TypeLabel = new System.Windows.Forms.Label();
            this.TypeComboBox = new System.Windows.Forms.ComboBox();
            this.InstrumentPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // CancelClickButton
            // 
            this.CancelClickButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelClickButton.Location = new System.Drawing.Point(117, 65);
            this.CancelClickButton.Name = "CancelClickButton";
            this.CancelClickButton.Size = new System.Drawing.Size(75, 23);
            this.CancelClickButton.TabIndex = 1;
            this.CancelClickButton.Text = "&Cancel";
            this.CancelClickButton.UseVisualStyleBackColor = true;
            this.CancelClickButton.Click += new System.EventHandler(this.CancelClickButton_Click);
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(36, 65);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 23);
            this.OKButton.TabIndex = 0;
            this.OKButton.Text = "&OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // InstrumentPanel
            // 
            this.InstrumentPanel.Controls.Add(this.InstrumentLabel);
            this.InstrumentPanel.Controls.Add(this.InstrumentComboBox);
            this.InstrumentPanel.Controls.Add(this.TypeLabel);
            this.InstrumentPanel.Controls.Add(this.TypeComboBox);
            this.InstrumentPanel.Location = new System.Drawing.Point(1, 2);
            this.InstrumentPanel.Name = "InstrumentPanel";
            this.InstrumentPanel.Size = new System.Drawing.Size(226, 57);
            this.InstrumentPanel.TabIndex = 8;
            // 
            // InstrumentLabel
            // 
            this.InstrumentLabel.AutoSize = true;
            this.InstrumentLabel.Location = new System.Drawing.Point(11, 34);
            this.InstrumentLabel.Name = "InstrumentLabel";
            this.InstrumentLabel.Size = new System.Drawing.Size(65, 13);
            this.InstrumentLabel.TabIndex = 3;
            this.InstrumentLabel.Text = "Instrument : ";
            // 
            // InstrumentComboBox
            // 
            this.InstrumentComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.InstrumentComboBox.FormattingEnabled = true;
            this.InstrumentComboBox.Location = new System.Drawing.Point(95, 30);
            this.InstrumentComboBox.Name = "InstrumentComboBox";
            this.InstrumentComboBox.Size = new System.Drawing.Size(121, 21);
            this.InstrumentComboBox.TabIndex = 1;
            // 
            // TypeLabel
            // 
            this.TypeLabel.AutoSize = true;
            this.TypeLabel.Location = new System.Drawing.Point(11, 7);
            this.TypeLabel.Name = "TypeLabel";
            this.TypeLabel.Size = new System.Drawing.Size(34, 13);
            this.TypeLabel.TabIndex = 1;
            this.TypeLabel.Text = "Type:";
            // 
            // TypeComboBox
            // 
            this.TypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TypeComboBox.FormattingEnabled = true;
            this.TypeComboBox.Items.AddRange(new object[] {
            "Piano",
            "Chromatic Percussion",
            "Organ",
            "Guitar",
            "Bass",
            "Strings",
            "Strings(con\'t)",
            "Brass",
            "Reed",
            "Pipe",
            "Synth Lead",
            "Synth Pad",
            "Synth Effects",
            "Ethnic",
            "Percussive",
            "Sound effects"});
            this.TypeComboBox.Location = new System.Drawing.Point(95, 3);
            this.TypeComboBox.Name = "TypeComboBox";
            this.TypeComboBox.Size = new System.Drawing.Size(121, 21);
            this.TypeComboBox.TabIndex = 0;
            this.TypeComboBox.SelectedIndexChanged += new System.EventHandler(this.TypeComboBox_SelectedIndexChanged);
            // 
            // InstrumentSelectForm
            // 
            this.AcceptButton = this.OKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelClickButton;
            this.ClientSize = new System.Drawing.Size(229, 100);
            this.Controls.Add(this.InstrumentPanel);
            this.Controls.Add(this.CancelClickButton);
            this.Controls.Add(this.OKButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "InstrumentSelectForm";
            this.ShowIcon = false;
            this.Text = "InstrumentSelectForm";
            this.InstrumentPanel.ResumeLayout(false);
            this.InstrumentPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button CancelClickButton;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Panel InstrumentPanel;
        private System.Windows.Forms.ComboBox TypeComboBox;
        private System.Windows.Forms.Label InstrumentLabel;
        private System.Windows.Forms.ComboBox InstrumentComboBox;
        private System.Windows.Forms.Label TypeLabel;
    }
}