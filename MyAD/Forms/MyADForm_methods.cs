using MyAD.Helper;
using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace MyAD.Forms
{
    public partial class MainForm
    {
        private KeyboardHook hook;
        private DialogResult lastDialogResult;

        private void SetUpGlobalHotkey()
        {
            hook = new KeyboardHook();
            hook.KeyPressed += Hook_KeyPressed;
            hook.RegisterHotKey(Helper.ModifierKeys.Control, Keys.Space);
        }

        private void RemoveGlobalHotkey()
        {
            hook.Dispose();
        }

        private void GetAttention()
        {
            WindowState = FormWindowState.Minimized;
            WindowState = FormWindowState.Normal;
            Focus();
        }

        private static string GetClipboardText()
        {
            var clipboard = new ClipboardAsync();
            return clipboard.GetText();
        }

        public AccountCredentials ShowLoginForm()
        {
            var loginForm = new LoginForm();
            if (loginForm.ShowDialog(this) != DialogResult.OK) return new AccountCredentials();
            var cre = loginForm.GetCredentials();
            loginForm.Dispose();
            return cre;
        }

        public string ShowInputBox(string cap, bool showLastInput)
        {
            var input = new InputBox(cap, showLastInput);
            string res = string.Empty;
            lastDialogResult = input.ShowDialog(this);
            if (lastDialogResult == DialogResult.OK)
                res = input.GetInput();
            input.Dispose();
            return res;
        }

        //enable global hotkey to unlock
        private void ctrKUnlockToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (ctrKUnlockToolStripMenuItem.Checked)
            {
                ShowGreen("Global hotkey enabled.");
                SetUpGlobalHotkey();
            }
            else
            {
                ShowGreen("Global hotkey disabled.");
                RemoveGlobalHotkey();
            }
        }

        private void ClearLabels()
        {
            labelCurrentActing.Text = string.Empty;
            labelActive.Text = "Null";
            labelActive.ForeColor = Color.Black;
            labelLock.Text = "Null";
            labelLock.ForeColor = Color.Black;
            richTextBoxRole.Text = string.Empty;
            labelBatch.Text = "Null";
            labelBatch.ForeColor = Color.Black;
            labelPwdExp.Text = "Null";
            labelPwdExp.ForeColor = Color.Black;
        }

        //enable top most
        private void topmostToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            TopMost = topmostToolStripMenuItem.Checked;
        }

        private void ClearCurrentUser()
        {
            _currentEntry = null;
            SetActionButtion(false);
            ClearLabels();
        }

        private void SetActionButtion(bool enable)
        {
            buttonUnlock.Enabled = enable;
            buttonChange.Enabled = enable;
            buttonChangeBatch.Enabled = enable;
            buttonDeactive.Enabled = enable && (string.Compare(labelActive.Text, "active", true) == 0) ? true : false;
        }

        private static string ParseName(string name)
        {
            if (!name.Contains("@")) return name.Trim();
            var splited = name.Trim().Split('@');
            return splited[0];
        }

        private void MainForm_Activated(object sender, EventArgs e)
        {
            textBoxUsername.Focus();
            textBoxUsername.SelectAll();
        }

        #region Show status

        private void ShowIsExpired(string s)
        {
            labelPwdExp.Text = s + " (Expired)";
            labelPwdExp.ForeColor = Color.Red;
        }

        private void ShowNotExpired(string s)
        {
            labelPwdExp.Text = s;
            labelPwdExp.ForeColor = Color.Green;
        }

        private void ShowIsLocked()
        {
            labelLock.Text = "Locked";
            labelLock.ForeColor = Color.Red;
        }

        private void ShowNotLocked()
        {
            labelLock.Text = "No locked";
            labelLock.ForeColor = Color.Green;
        }

        private void ShowIsActive()
        {
            labelActive.Text = "Active";
            labelActive.ForeColor = Color.Green;
        }

        private void ShowNotActive()
        {
            labelActive.Text = "Inactive";
            labelActive.ForeColor = Color.Red;
        }

        private void ShowRed(string s)
        {
            _logger.Log(s);
            labelGeneral.Text = s;
            labelGeneral.ForeColor = Color.Red;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="s">to show in status</param>
        /// <param name="log">additional info to show in logger</param>
        private void ShowGreen(string s, string log = "")
        {
            if (string.IsNullOrEmpty(log))
                _logger.Log(s);
            else
                _logger.Log(string.Format("{0}-{1}", s, log));
            labelGeneral.Text = s;
            labelGeneral.ForeColor = Color.Green;
        }

        private void ShowBlack(string s)
        {
            _logger.Log(s);
            labelGeneral.Text = s;
            labelGeneral.ForeColor = Color.Black;
        }

        private void LogUnlockToDb(string adName)
        {
            //try
            //{
            //    _dbAdapter.LogUnlockAction(adName, Adm);
            //}
            //catch (Exception ex)
            //{
            //    _logger.Log("Cant save to log db.");
            //    _logger.Log(ex.Message);
            //    if (ex.InnerException != null) _logger.Log(string.Format("Inner Ex: {0}", ex.InnerException.Message));
            //}
        }

        public static string AssemblyDirectory
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }

        #endregion Show status
    }
}