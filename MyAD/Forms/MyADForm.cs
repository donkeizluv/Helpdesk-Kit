using MyAD.AD;
using MyAD.DBAdapter;
using MyAD.Helper;
using MyAD.Log;
using MyAD.Outlook;
using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Drawing;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MyAD.Forms
{
    public partial class MainForm : Form
    {
        //db adapter
        //private const string CollectionName = "lockouts";

        //private const string NetworkDbPath = @"\\10.8.0.77\Users\myad_db";
        private readonly Regex _hrCodeRegex = new Regex(@"\bE([A-Z]{1})?[0-9]+\b", RegexOptions.Compiled);
        //private readonly string _debugDbPath = string.Format(@"{0}\db.mad", AssemblyDirectory);
        //private IDBAdapter _dbAdapter;

        //current adm
        private string _adm;

        private AdController _controller;
        private DirectoryEntry _currentEntry;

        //private IDBAdapter _dbAdapter = new LiteDBAdapter(string.Format("{0}/db.mad", AssemblyDirectory));
        //private readonly IDBAdapter _dbAdapter =
        //    new LiteDBAdapter(string.Format(@"{0}\db.mad", NetworkDbPath), CollectionName);

        //private readonly ILockoutViewer _lockOut;

        //modular forms
        private readonly LogViewer _logForm;

        //current entry
        private readonly ILogger _logger = LogManager.GetLogger(typeof(MainForm));

        private OutlookWrapper _outlook;

        public MainForm()
        {
            InitializeComponent();
            //_lockOut = new Lockouts_Viewer();
            _logForm = new LogViewer();
#if DEBUG
            //_dbAdapter = new LiteDBAdapter(_debugDbPath, CollectionName);
            _logForm.Show();
            //_lockOut.Show();
#endif
            LogManager.LogViewer = _logForm;
            //DataCollectionManager.Innit(_dbAdapter);
            //_lockOut.SetCurrentCollection(DataCollectionManager.UnFilteredData);
            //_lockOut.MoveFirst();
        }

        public string Adm
        {
            get => _adm;
            set
            {
                _adm = value;
                SetLoggedInAdm(value);
            }
        }

        public bool IsMonitorRunning { get; set; } = false;
        public string RootFolderMonitor { get; set; }
        public string FolderToMonitor { get; set; }
        public string CurrentEntryName { get; set; }
        public bool IsCurrentEntryLocked { get; set; }
        public bool IsCurrentEntryPwdNotExpired { get; set; }
        public bool IsCurrentEntryActive { get; set; }
        public bool IsPwdNeverExpired { get; set; }

        public bool ParseForID { get; set; }
        public Color BeerModeColor { get; } = Color.MintCream;

        //private void TestDBMethod()
        //{
        //    //OK
            //_dbAdapter.BeginDBAccess(COLLECTION_NAME);
            //UserLockouts.BuildDynamicLinqFilter("tran.duc-trong", null, "adm-hongln", out string filter, out object[] param);
            //var filteredData = _dbAdapter.GetData(filter, param);
            //_logger.Log(string.Format("filter string: {0}", filter));
            //_logger.Log(string.Format("filtered data: {0} from db", filteredData.Count()));

            //_logger.Log(string.Format("max page: {0}", _dbAdapter.GetMaxPage()));

            //var page1 = _dbAdapter.GetDataPage(1);
            //foreach (var record in page1)
            //{
            //    _logger.Log(record.UnlockTime.ToShortDateString());
            //}

            //_logger.Log("page2:");
            //var page2 = _dbAdapter.GetDataPage(3);
            //foreach (var record in page2)
            //{
            //    _logger.Log(record.UnlockTime.ToShortDateString());
            //}

            //_logger.Log(_dbAdapter.GetRecordCount().ToString());
            //_dbAdapter.EndDBAccess();
        //}

        private void MainForm_Load(object sender, EventArgs e)
        {
#if DEBUG
            SetLoggedInAdm("TEST_MODE");
            goto debug;
#endif
            try
            {
                var cre = ShowLoginForm();
                if (cre.Pwd == null || cre.Username == null) //exit without input anything.
                {
                    Close();
                    return;
                }
                if (cre.Pwd.Length < 1 || cre.Pwd.Length < 1)
                    throw new ArgumentException("Invalid login credentials.");
                _controller = new AdController(cre.Username, cre.Pwd);
                Adm = cre.Username;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error: " + ex.Message, "Error");
                Close();
            }
            debug:
            SetActionButtion(false);
            buttonDeactive.Enabled = false;
            labelVer.Text = $"Ver: {Assembly.GetEntryAssembly().GetName().Version} - Hongln";
            LoadAutoReplySetting();
        }

        private void SetLoggedInAdm(string adm)
        {
            Text = string.Format("{0} - {1}", Text, adm);
        }

        //bool _hotkeyPress = false;
        private void Hook_KeyPressed(object sender, KeyPressedEventArgs e)
        {
            //if foreground windows is not outlook, use clipboard instead, btw, shitty outlook detection.
            _logger.Log("Hot key pressed.");
            if (ParseForID && ForegroundChecker.GetActiveWindowTitle().ToLower().Contains("outlook"))
            {
                _logger.Log("Foreground is Outlook.");
                UnlockFromOutlook();
            }
            else
            {
                UnlockFromClipboard();
            }
            GetAttention();
        }

        private void UnlockFromClipboard()
        {
            string clipboard = GetClipboardText();
            //if (clipboard.Length < 1)
            //{
            //    ShowRed("Invalid content in clipboard.");
            //    textBoxUsername.Text = string.Empty;
            //    return;
            //}
            Automate(clipboard, false, false);
        }

        private void UnlockFromOutlook()
        {
            string id;
            try
            {
                id = _outlook.GetAdInSelectedEmail();
            }
            catch (Exception ex)
            {
                var mess = "Hotkey: Cant read Outlook, connect again";
                ShowRed(mess);
                ClearCurrentUser();
                _logger.Log(mess);
                return;
            }
            //cant parse any ids
            if (id == string.Empty)
            {
                ShowRed("Hotkey: Cant find any Ids.");
                ClearCurrentUser();
                return;
            }
            Automate(id, composeReplyEmailToolStripMenuItem.Checked, sendToolStripMenuItem.Checked);
        }

        private void Automate(string ad, bool reply, bool send)
        {
            textBoxUsername.Text = ad;
            //true: unlock ok
            //false: no lock
            //null: unlock fail or user not found
            bool? status = null;
            if (FetchUser(ad, out var error))
                if (IsCurrentEntryLocked)
                {
                    if (UnlockAD(_currentEntry))
                    {
                        ShowGreen("Hotkey: Unlocked OK.");
                        RefreshLabels();
                        status = true;
                    }
                    else
                    {
                        ShowRed("Hotkey: Failed to unlock.");
                    }
                }
                else
                {
                    ShowBlack("Hotkey: No action.");
                    status = false;
                }
            else
                ShowRed($"Hotkey: {error}");
            if (!reply || status == null) return;
            if (!IsCurrentEntryActive)
            {
                _outlook.Reply_NotActive(send);
                return;
            }
            if (!IsCurrentEntryPwdNotExpired)
            {
                _outlook.Reply_PwdExpired(send);
                return;
            }
            //status cant be null anymore, so its just custom
            if (status ?? false)
                _outlook.Reply_UnlockOK(send);
            else
                _outlook.Reply_NoLock(send);
        }

        //click unlock
        private void Unlock_Click(object sender, EventArgs e)
        {
            if (_currentEntry == null) return;
            if (UnlockAD(_currentEntry))
            {
                ShowGreen("AD: Unlocked OK.");
                RefreshLabels();
            }
            else
            {
                ShowRed("AD: Failed to unlock.");
            }
        }

        private bool UnlockAD(DirectoryEntry entry)
        {
            if (entry == null) return false;
            try
            {
                _controller.UnlockUserAccount(entry);
                LogUnlockToDb(CurrentEntryName);
                return true;
            }
            catch (Exception ex) //catch specific exception
            {
                _logger.Log(ex.Message);
                _logger.Log(ex.StackTrace);

                return false;
            }
        }

        //click change pwd
        private void buttonChange_Click(object sender, EventArgs e)
        {
            if (_currentEntry == null) return;
            string pwd = ShowInputBox("Enter new pwd:", true);
            if (lastDialogResult != DialogResult.OK) return;
            if (pwd.Length < 7)
            {
                ShowRed("AD: Invalid pwd.");
                return;
            }
            _controller.SetUserPassword(_currentEntry, pwd, out string ex);
            if (ex == string.Empty)
            {
                ShowGreen("AD: Pwd changed.");
            }
            else
            {
                ShowRed("AD: Failed to change pwd");
                MessageBox.Show(ex);
            }
            RefreshLabels();
        }

        //click change batch
        private void buttonChangeBatch_Click(object sender, EventArgs e)
        {
            if (_currentEntry == null) return;
            string batch = ShowInputBox("Enter batch:", false);
            if (lastDialogResult != DialogResult.OK) return;
            if (_controller.SetProperty(_currentEntry, "physicalDeliveryOfficeName", batch, out string ex))
                ShowGreen("AD: Batch changed.");
            else
                ShowRed("AD: Failed to change batch.");
            RefreshLabels();
        }

        //click fetch user
        private void buttonFetch_Click(object sender, EventArgs e)
        {
            if (FetchUser(textBoxUsername.Text, out var error))
            {
                SetActionButtion(true);
                ShowGreen("AD: User found.", "user: " + textBoxUsername.Text);
            }
            else
            {
                ShowRed($"AD: {error}");
            }
        }

        private bool FetchUser(string searchString, out string error)
        {
            error = string.Empty;
            if (string.IsNullOrEmpty(searchString) || CheckForInvalidChar(searchString))
            {
                error = "Invalid input.";
                ClearCurrentUser();
                return false;
            }
            try
            {
                if (_hrCodeRegex.IsMatch(searchString.ToUpper())) //test for HR code, normalize string case
                {
                    _logger.Log("Input is HR code.");
                    _currentEntry = _controller.GetUserByHRCode(searchString);
                }
                else
                {
                    //normal username
                    _currentEntry = _controller.GetUser(ParseName(searchString));
                }
            }
            catch (Exception ex) //be more specific
            {

                _logger.Log("Fail to contact server.");
                error = "Fail to contact server.";
                ClearCurrentUser();
                return false;
            }
           
            if (_currentEntry == null)
            {
                error = "User not found.";
                ClearCurrentUser();
                return false;
            }
            CurrentEntryName = _controller.GetUserName(_currentEntry);
            RefreshLabels();
            return true;
        }

        private bool CheckForInvalidChar(string s)
        {
            //ad search doesnt allow this char, escape or something....
            return s.Contains(@"\");
        }

        private void RefreshLabels()
        {
            labelCurrentActing.Text = CurrentEntryName;
            IsCurrentEntryLocked = _controller.IsAccountLocked(_currentEntry);
            IsPwdNeverExpired = _controller.IsPwsNeverExpired(_currentEntry);
            IsCurrentEntryActive = _controller.IsAccountActive(CurrentEntryName);
            //show active status
            if (IsCurrentEntryActive)
                ShowIsActive();
            else
                ShowNotActive();
            //show lock status
            if (IsCurrentEntryLocked)
                ShowIsLocked();
            else
                ShowNotLocked();
            var expDate = _controller.GetPasswordExpirationDate(_currentEntry);
            //show pwd expiration
            IsCurrentEntryPwdNotExpired = DateTime.Compare(DateTime.Today, expDate.Date) < 0;
            if (IsCurrentEntryPwdNotExpired || IsPwdNeverExpired)
                ShowNotExpired(expDate.ToShortDateString());
            else
                ShowIsExpired(expDate.ToShortDateString());
            //show never expire status
            ShowNeverExpired(IsPwdNeverExpired);

            //show user role
            richTextBoxRole.Text = _controller.GetProperty(_currentEntry, "description");
            //show user batch if any
            labelBatch.Text = _controller.GetProperty(_currentEntry, "physicalDeliveryOfficeName");
        }

        private void textBoxUsername_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            buttonFetch_Click(null, EventArgs.Empty);
            buttonUnlock.Focus();
        }

        private void buttonDeactive_Click(object sender, EventArgs e)
        {
            try
            {
                _controller.DisableUserAccount(_currentEntry);
                _controller.SetProperty(_currentEntry, "description",
                    string.Format("{0} {1}", richTextBoxRole.Text, DateTime.Now.ToShortDateString()), out string error);
                _controller.SetProperty(_currentEntry, "physicalDeliveryOfficeName", "", out error);
                if (error.Length > 0)
                {
                    ShowRed(error);
                    return;
                }
                ShowGreen("AD: Disabled account.");
                RefreshLabels();
            }
            catch (Exception ex)
            {
                ShowRed("AD: Fail to disable account.");
                MessageBox.Show(ex.Message);
                _logger.Log(ex.Message);
                _logger.Log(ex.StackTrace);
            }
        }
        private bool InstanciateOutlook(out OutlookWrapper outlook)
        {
            outlook = null;
            try
            {
                outlook = new OutlookWrapper();
                return true;
            }
            catch (NullReferenceException)
            {
                return false;
            }
        }
        private bool CheckOutlook()
        {
            if(_outlook != null) //check if instance valid
            {
                if(_outlook.IsCOMInstanceValid())
                {
                    return true;
                }
                else
                {
                    //try creating new instance
                    if (InstanciateOutlook(out _outlook))
                        return true;
                    else
                        return false;
                }
            }
            else
            {
                //try creating new instance
                if (InstanciateOutlook(out _outlook))
                    return true;
                else
                    return false;
            }
        }

        //auto parse for ID
        private void ReadOutlookToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (readOutlookToolStripMenuItem.Checked)
            {
                if (CheckOutlook())
                {
                    ParseForID = true;
                    ShowGreen("Read_Outlook: enabled.");
                    autoReplyToolStripMenuItem.Enabled = true;
                }
                else
                {
                    ParseForID = false;
                    readOutlookToolStripMenuItem.Checked = false;
                    ShowRed("Read_Outlook: Cant connect to Outlook!");
                }
            }
            else
            {
                ParseForID = false;
                ShowRed("Read_Outlook: disabled.");
                if(IsMonitorRunning)
                {
                    StopMonitor();
                }
                autoReplyToolStripMenuItem.Enabled = false;
                _outlook = null;
            }
        }

        //private void MainForm_Click(object sender, EventArgs e)
        //{
        //    MessageBox.Show("click!");
        //}

        private void ShowLogsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _logForm.Show();
        }

        private void ShowLockoutReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //_lockOut.Show();
        }
        private void LoadAutoReplySetting()
        {
            GetAutoReplySetting(out string mailbox, out string folder);
            toolStripTextBoxFolderName.Text = folder;
            toolStripTextBoxRootFolder.Text = mailbox;
        }
        private void SaveAutoReplySetting(string mailbox, string folder)
        {
            Properties.Settings.Default.Mailbox = mailbox;
            Properties.Settings.Default.Folder = folder;
            Properties.Settings.Default.Save();
        }
        private void GetAutoReplySetting(out string mailbox, out string folder)
        {
            mailbox = Properties.Settings.Default.Mailbox;
            folder = Properties.Settings.Default.Folder;
        }
        private void AutoReplyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //vadidate
            if (autoReplyToolStripMenuItem.Checked)
            {
                if (string.IsNullOrEmpty(toolStripTextBoxFolderName.Text) || string.IsNullOrEmpty(toolStripTextBoxRootFolder.Text))
                {
                    MessageBox.Show("Enter folder name first!");
                    autoReplyToolStripMenuItem.Checked = false;
                    return;
                }
                SaveAutoReplySetting(toolStripTextBoxRootFolder.Text, toolStripTextBoxFolderName.Text);
                if(CheckOutlook())
                    StartMonitor();
                else
                {
                    ShowRed("Auto_Reply: Cant connect to Outlook");
                    autoReplyToolStripMenuItem.Checked = false;
                    return;
                }
            }
            else
            {
                StopMonitor();
            }
        }

        private void StartMonitor()
        {
            //if (!InnitOutlook())
            //{
            //    autoReplyToolStripMenuItem.Checked = false;
            //    ShowRed("Outlook is not running!");
            //    return;
            //}
            try
            {
                FolderToMonitor = toolStripTextBoxFolderName.Text;
                RootFolderMonitor = toolStripTextBoxRootFolder.Text;

                _logger.Log("Auto_Reply: starting monitor....");
                _outlook.IncommingEmail += _outlook_IncommingEmail;
                _outlook.MonitorIncomingEmail(RootFolderMonitor, FolderToMonitor);

                IsMonitorRunning = true;
                OnBeerModeColor();
                ShowGreen("Auto_Reply: Monitor is running!");
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                ShowRed("Auto_Reply: Fail to start monitor.");
                _logger.Log(ex.Message);
                _logger.Log(ex.StackTrace);
                StopMonitor();
            }
        }

        private void StopMonitor()
        {
            try
            {
                _logger.Log("Auto_Reply: stop monitor....");
                _outlook.StopMonitorIncomingEmail();
                _outlook.IncommingEmail -= _outlook_IncommingEmail;
                IsMonitorRunning = false;
                FolderToMonitor = string.Empty;
                OffBeerModeColor();
                ShowRed("Auto_Reply: Monitor stopped.");
                autoReplyToolStripMenuItem.Checked = false;
            }
            catch (Exception ex)
            {
                ShowRed("Auto_Reply: Fail to stop monitor.");
                _logger.Log(ex.Message);
                _logger.Log(ex.StackTrace);
            }
        }

        private Color _bkColor;

        private void OnBeerModeColor()
        {
            _bkColor = BackColor;
            BackColor = BeerModeColor;
        }

        private void OffBeerModeColor()
        {
            BackColor = _bkColor;
        }

        private void _outlook_IncommingEmail(object sender, NewEnailEventArgs e)
        {
            if(string.Compare(e.Email.SentOnBehalfOfName, "helpdesk", true) == 0)
            {
                _logger.Log("helpdesk email -> skip");
                return;
            }
            if (!e.ContainAd)
            {
                _logger.Log($"Auto_Reply: incomming email doesnt contain ad");
            }
            else
            {
                _logger.Log($"Auto_Reply: incomming email ad: {e.Ad}");
                textBoxUsername.Text = e.Ad;
                buttonFetch_Click(this, EventArgs.Empty);

                if(_currentEntry == null)
                {
                    _logger.Log("Auto_Reply: Ad doesnt exists ");
                    ShowRed("Auto_Reply: Ad doesnt exists");
                    return;
                }
                if (!IsCurrentEntryActive)
                {
                    //set category of auto reply
                    _outlook.Reply_NotActive(e.Email);
                    _logger.Log($"reply -> not active");
                    return;
                }
                if(!IsCurrentEntryPwdNotExpired && !IsPwdNeverExpired)
                {
                    _outlook.Reply_PwdExpired(e.Email);
                    _logger.Log($"reply -> pwd expired");
                    return;
                }
                if (IsCurrentEntryLocked)
                {
                    if (UnlockAD(_currentEntry))
                    {
                        _outlook.Reply_UnlockOK(e.Email);
                        _logger.Log("Auto_Reply: reply unlocked ok");
                        ShowGreen("Auto_Reply: reply unlocked ok");
                        buttonFetch_Click(this, EventArgs.Empty);
                    }
                    else
                    {
                        _logger.Log("Auto_Reply: unlock fail.");
                        ShowRed("Auto_Reply: unlock fail.");
                    }

                    return;
                }
                else
                {
                    _logger.Log("Auto_Reply: not locked -> skip");
                    ShowRed("Auto_Reply: not locked -> skip");
                }
            }
        }
    }
}