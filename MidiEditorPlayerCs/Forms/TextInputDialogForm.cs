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
    public partial class TextInputDialogForm : Form
    {
        DialogResult ButtonResult = DialogResult.Cancel;
        String TextResult = "";
        public TextInputDialogForm()
        {
            InitializeComponent();
        }

        public TextInputDialogForm(String UserPrompt, String FormText)
        {
            InitializeComponent();
            PromptLabel.Text = UserPrompt;
           
            this.Text = FormText;
        }
        #region Events
        private void OKButton_Click_1(object sender, EventArgs e)
        {
            ButtonResult = DialogResult.OK;
            TextResult = InputTextBox.Text;
            this.Close();
        }

        private void CancelClickButton_Click(object sender, EventArgs e)
        {
            ButtonResult = DialogResult.Cancel;
            this.Close();
        }
        #endregion

        #region Accessors
        public DialogResult ButtonClicked
        {
            get { return ButtonResult; }
            set { ButtonResult = value; }
        }
        public String TextEntered
        {
            get { return TextResult; }
            set { TextResult = value; }
        }
        #endregion

        private void InputTextBox_TextChanged(object sender, EventArgs e)
        {
            if (InputTextBox.Text != "" && Convert.ToInt32(InputTextBox.Text) == 0)
                InputTextBox.Clear();
        }
    }
}
