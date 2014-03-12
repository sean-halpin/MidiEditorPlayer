namespace MidiEditorPlayerCs
{
    partial class TextInputDialogForm
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
            this.MainPanel = new System.Windows.Forms.Panel();
            this.TextInputPanel = new System.Windows.Forms.Panel();
            this.InputTextBox = new System.Windows.Forms.MaskedTextBox();
            this.PromptLabel = new System.Windows.Forms.Label();
            this.CancelClickButton = new System.Windows.Forms.Button();
            this.OKButton = new System.Windows.Forms.Button();
            this.MainPanel.SuspendLayout();
            this.TextInputPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.Controls.Add(this.TextInputPanel);
            this.MainPanel.Controls.Add(this.CancelClickButton);
            this.MainPanel.Controls.Add(this.OKButton);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(235, 106);
            this.MainPanel.TabIndex = 4;
            // 
            // TextInputPanel
            // 
            this.TextInputPanel.Controls.Add(this.InputTextBox);
            this.TextInputPanel.Controls.Add(this.PromptLabel);
            this.TextInputPanel.Location = new System.Drawing.Point(0, 0);
            this.TextInputPanel.Name = "TextInputPanel";
            this.TextInputPanel.Size = new System.Drawing.Size(235, 66);
            this.TextInputPanel.TabIndex = 0;
            // 
            // InputTextBox
            // 
            this.InputTextBox.Location = new System.Drawing.Point(67, 43);
            this.InputTextBox.Mask = "000";
            this.InputTextBox.Name = "InputTextBox";
            this.InputTextBox.Size = new System.Drawing.Size(100, 20);
            this.InputTextBox.TabIndex = 0;
            this.InputTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.InputTextBox.TextChanged += new System.EventHandler(this.InputTextBox_TextChanged);
            // 
            // PromptLabel
            // 
            this.PromptLabel.AutoSize = true;
            this.PromptLabel.Location = new System.Drawing.Point(3, 9);
            this.PromptLabel.Name = "PromptLabel";
            this.PromptLabel.Size = new System.Drawing.Size(33, 13);
            this.PromptLabel.TabIndex = 0;
            this.PromptLabel.Text = "Label";
            // 
            // CancelClickButton
            // 
            this.CancelClickButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelClickButton.Location = new System.Drawing.Point(120, 72);
            this.CancelClickButton.Name = "CancelClickButton";
            this.CancelClickButton.Size = new System.Drawing.Size(75, 23);
            this.CancelClickButton.TabIndex = 1;
            this.CancelClickButton.Text = "&Cancel";
            this.CancelClickButton.UseVisualStyleBackColor = true;
            this.CancelClickButton.Click += new System.EventHandler(this.CancelClickButton_Click);
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(39, 72);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 23);
            this.OKButton.TabIndex = 0;
            this.OKButton.Text = "&OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click_1);
            // 
            // TextInputDialogForm
            // 
            this.AcceptButton = this.OKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelClickButton;
            this.ClientSize = new System.Drawing.Size(235, 106);
            this.Controls.Add(this.MainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TextInputDialogForm";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InputDialogForm";
            this.TopMost = true;
            this.MainPanel.ResumeLayout(false);
            this.TextInputPanel.ResumeLayout(false);
            this.TextInputPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.Button CancelClickButton;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Panel TextInputPanel;
        private System.Windows.Forms.Label PromptLabel;
        private System.Windows.Forms.MaskedTextBox InputTextBox;
    }
}