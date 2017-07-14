using MyAD.Log;
using MyAD.POCO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MyAD.Forms
{
    public interface ILockoutViewer
    {
        int CurrentPage { get; }
        int LastPage { get; }
        int RecordCount { get; }

        void MoveFirst();

        void MoveNext();

        void MoveLast();

        void MovePrev();

        bool IsAtLastPage { get; }

        void RefreshData();

        void SetCurrentCollection(IDataCollection collection);

        void ClearFilterIndicator();

        void ShowFilterIndicator();

        void Show(); //lol, this method is from base Form but it still counted

        //how about overload? need more testing, but i think its highly possible that it will be counted
        void Hide();
    }

    public partial class Lockouts_Viewer : Form, ILockoutViewer
    {
        private readonly Lockouts_Viewer_Toolbox _toolbox;
        private ILogger _logger;
        public int CurrentPage { get; private set; } = 1;
        public int LastPage { get; private set; } = 1;
        public int RecordCount { get; private set; }
        //public bool IsFilterApplied { get; private set; } = false;
        //public string FilterString { get; private set; }
        //public object[] FilterParam { get; private set; }

        private IDataCollection _currentCollection; //collection in effect

        public bool IsAtLastPage => CurrentPage == LastPage;

        public Lockouts_Viewer()
        {
            _toolbox = new Lockouts_Viewer_Toolbox(this);
            _logger = LogManager.GetLogger(this.GetType());
            InitializeComponent();
        }

        //protected override void OnShown(EventArgs e)
        //{
        //    DisplayPage(1);
        //    base.OnShown(e);
        //}
        public void RefreshData()
        {
        }

        private void SetRecordCount(int count)
        {
            RecordCount = count;
            labelTotalRow.Text = RecordCount.ToString();
        }

        private void SetMaxPage(int maxPage)
        {
            LastPage = maxPage;
            labelMaxPage.Text = LastPage.ToString();
        }

        private void SetCurrentPage(int page)
        {
            CurrentPage = page;
            labelCurrentPage.Text = page.ToString();
        }

        private void DisplayPage(int pageNumber)
        {
            DisplayRecord(_currentCollection.GetPage(pageNumber));
            UpdateLabelsAndProperties(pageNumber, _currentCollection.LastPage, _currentCollection.RecordCount);
        }

        private void UpdateLabelsAndProperties(int current, int max, int total)
        {
            SetRecordCount(total);
            SetMaxPage(max);
            SetCurrentPage(current);
        }

        //public void ClearFilter()
        //{
        //    TurnOffFilterButtonColor();
        //    IsFilterApplied = false;
        //    FilterString = string.Empty;
        //    FilterParam = null;
        //}
        private void TurnOnFilterButtonColor()
        {
            buttonFilter.BackColor = Color.LightSalmon; //means filter is applied
        }

        private void TurnOffFilterButtonColor()
        {
            buttonFilter.BackColor = SystemColors.Control;
        }

        private void DisplayRecord(IEnumerable<UserLockouts> col)
        {
            dataGridView1.Rows.Clear();
            foreach (var record in col)
            {
                var row = (DataGridViewRow)dataGridView1.RowTemplate.Clone();
                row.CreateCells(dataGridView1, record.GetDataArray());
                dataGridView1.Rows.Add(row);
            }
        }

        private void Lockouts_Viewer_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true; //cancel event
            _toolbox.Hide();
            Hide();
        }

        private void buttonFilter_Click(object sender, EventArgs e)
        {
            _toolbox.Show();
        }

        private void buttonFirst_Click(object sender, EventArgs e)
        {
            DisplayPage(1);
            CurrentPage = 1;
            SetNavigationalButtonState();
        }

        private void buttonPrev_Click(object sender, EventArgs e)
        {
            CurrentPage--;
            DisplayPage(CurrentPage);
            SetNavigationalButtonState();
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            CurrentPage++;
            DisplayPage(CurrentPage);
            SetNavigationalButtonState();
        }

        private void buttonLast_Click(object sender, EventArgs e)
        {
            DisplayPage(LastPage);
            CurrentPage = LastPage;
            SetNavigationalButtonState();
        }

        private void SetNavigationalButtonState()
        {
            if (CurrentPage == 1)
            {
                buttonPrev.Enabled = false;
                buttonFirst.Enabled = false;
            }
            else
            {
                buttonPrev.Enabled = true;
                buttonFirst.Enabled = true;
            }
            if (IsAtLastPage)
            {
                buttonNext.Enabled = false;
                buttonLast.Enabled = false;
            }
            else
            {
                buttonNext.Enabled = true;
                buttonLast.Enabled = true;
            }
        }

        public void SetCurrentCollection(IDataCollection collection)
        {
            //move to page 1
            _currentCollection = collection;
            DisplayPage(1);
            UpdateLabelsAndProperties(1, _currentCollection.LastPage, _currentCollection.RecordCount);
            SetNavigationalButtonState();
        }

        public void ClearFilterIndicator()
        {
            TurnOffFilterButtonColor();
        }

        public void ShowFilterIndicator()
        {
            TurnOnFilterButtonColor();
        }

        public void MoveFirst()
        {
            buttonFirst_Click(this, EventArgs.Empty);
        }

        public void MoveNext()
        {
            buttonNext_Click(this, EventArgs.Empty);
        }

        public void MoveLast()
        {
            buttonLast_Click(this, EventArgs.Empty);
        }

        public void MovePrev()
        {
            buttonFirst_Click(this, EventArgs.Empty);
        }
    }
}