using System;
using System.Windows.Forms;

namespace MyAD.Forms
{
    public partial class LogViewer : Form
    {
        public LogViewer()
        {
            InitializeComponent();
        }

        public void Log(string log)
        {
            richTbLog.AppendText(log);
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            richTbLog.Clear();
        }

        private void LogViewer_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
    }
}