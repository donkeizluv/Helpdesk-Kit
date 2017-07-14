using System;
using System.Windows.Forms;

namespace MyAD.Forms
{
    public partial class settingForm : Form
    {
        public settingForm()
        {
            InitializeComponent();
            checkBoxReadOL.Enabled = false;
            checkBoxSend.Enabled = false;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void checkBoxCtrSpace_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxReadOL.Enabled = true;
        }

        private void checkBoxCtrB_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxSend.Enabled = true;
        }

        private void checkBoxReadOL_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void checkBoxSend_CheckedChanged(object sender, EventArgs e)
        {
        }
    }
}