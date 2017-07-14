using System;
using System.Windows.Forms;

namespace MyAD.Forms
{
    public partial class InputBox : Form
    {
        private static string _lastInput = string.Empty;
        private readonly bool remmeber;

        public InputBox()
        {
            InitializeComponent();
        }

        public InputBox(string cap, bool showLastInput)
        {
            InitializeComponent();
            remmeber = showLastInput;
            Text = cap;
            if (showLastInput)
                InputTextbox.Text = _lastInput;
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        public string GetInput()
        {
            return InputTextbox.Text;
        }

        private void InputTextbox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
                Close();
            }
            if (e.KeyCode != Keys.Enter) return;
            if (remmeber)
                _lastInput = InputTextbox.Text;
            ButtonOK_Click(null, EventArgs.Empty);
        }
    }
}