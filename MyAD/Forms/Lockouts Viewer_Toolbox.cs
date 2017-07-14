using MyAD.POCO;
using System;
using System.Windows.Forms;

namespace MyAD.Forms
{
    public partial class Lockouts_Viewer_Toolbox : Form
    {
        private ILockoutViewer _viewer;

        public Lockouts_Viewer_Toolbox(ILockoutViewer viewer)
        {
            _viewer = viewer;
            InitializeComponent();
        }

        private void Lockouts_Viewer_Toolbox_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            var date = dateTimePicker.Checked ? dateTimePicker.Value : DateTime.MinValue;
            UserLockouts.BuildDynamicLinqFilter(textBoxUser.Text, date, textBoxUnlocker.Text,
                out string filter, out object[] param);
            DataCollectionManager.CreateFilteredData(filter, param);
            _viewer.SetCurrentCollection(DataCollectionManager.FilteredData);
            _viewer.MoveFirst();
            _viewer.ShowFilterIndicator();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxUser.Text = string.Empty;
            textBoxUnlocker.Text = string.Empty;
            dateTimePicker.Checked = false;
            _viewer.SetCurrentCollection(DataCollectionManager.UnFilteredData);
            _viewer.MoveFirst();
            _viewer.ClearFilterIndicator();
        }
    }
}