namespace MyAD.Forms
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.buttonUnlock = new System.Windows.Forms.Button();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonFetch = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonChangeBatch = new System.Windows.Forms.Button();
            this.buttonDeactive = new System.Windows.Forms.Button();
            this.buttonChange = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbPwdNoExpired = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.labelBatch = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.richTextBoxRole = new System.Windows.Forms.RichTextBox();
            this.labelPwdExp = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelActive = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labelLock = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelGeneral = new System.Windows.Forms.Label();
            this.labelVer = new System.Windows.Forms.Label();
            this.contextMenuStripMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.topmostToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ctrKUnlockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.readOutlookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.composeReplyEmailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoReplyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBoxRootFolder = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripTextBoxFolderName = new System.Windows.Forms.ToolStripTextBox();
            this.showLockoutReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showLogsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelCurrentActing = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.contextMenuStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonUnlock
            // 
            this.buttonUnlock.ForeColor = System.Drawing.Color.DarkGreen;
            this.buttonUnlock.Location = new System.Drawing.Point(17, 22);
            this.buttonUnlock.Margin = new System.Windows.Forms.Padding(4);
            this.buttonUnlock.Name = "buttonUnlock";
            this.buttonUnlock.Size = new System.Drawing.Size(110, 28);
            this.buttonUnlock.TabIndex = 3;
            this.buttonUnlock.Text = "Unlock";
            this.buttonUnlock.UseVisualStyleBackColor = true;
            this.buttonUnlock.Click += new System.EventHandler(this.Unlock_Click);
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxUsername.Location = new System.Drawing.Point(73, 53);
            this.textBoxUsername.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(169, 24);
            this.textBoxUsername.TabIndex = 1;
            this.textBoxUsername.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxUsername_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 58);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Find:";
            // 
            // buttonFetch
            // 
            this.buttonFetch.Location = new System.Drawing.Point(308, 53);
            this.buttonFetch.Margin = new System.Windows.Forms.Padding(4);
            this.buttonFetch.Name = "buttonFetch";
            this.buttonFetch.Size = new System.Drawing.Size(66, 28);
            this.buttonFetch.TabIndex = 2;
            this.buttonFetch.Text = "Fetch";
            this.buttonFetch.UseVisualStyleBackColor = true;
            this.buttonFetch.Click += new System.EventHandler(this.buttonFetch_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonChangeBatch);
            this.groupBox1.Controls.Add(this.buttonDeactive);
            this.groupBox1.Controls.Add(this.buttonChange);
            this.groupBox1.Controls.Add(this.buttonUnlock);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox1.Location = new System.Drawing.Point(268, 98);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(143, 255);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Action";
            // 
            // buttonChangeBatch
            // 
            this.buttonChangeBatch.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.buttonChangeBatch.Location = new System.Drawing.Point(17, 95);
            this.buttonChangeBatch.Margin = new System.Windows.Forms.Padding(4);
            this.buttonChangeBatch.Name = "buttonChangeBatch";
            this.buttonChangeBatch.Size = new System.Drawing.Size(110, 28);
            this.buttonChangeBatch.TabIndex = 5;
            this.buttonChangeBatch.Text = "Batch";
            this.buttonChangeBatch.UseVisualStyleBackColor = true;
            this.buttonChangeBatch.Click += new System.EventHandler(this.buttonChangeBatch_Click);
            // 
            // buttonDeactive
            // 
            this.buttonDeactive.ForeColor = System.Drawing.Color.Red;
            this.buttonDeactive.Location = new System.Drawing.Point(17, 185);
            this.buttonDeactive.Margin = new System.Windows.Forms.Padding(4);
            this.buttonDeactive.Name = "buttonDeactive";
            this.buttonDeactive.Size = new System.Drawing.Size(110, 28);
            this.buttonDeactive.TabIndex = 6;
            this.buttonDeactive.TabStop = false;
            this.buttonDeactive.Text = "Deactive";
            this.buttonDeactive.UseVisualStyleBackColor = true;
            this.buttonDeactive.Click += new System.EventHandler(this.buttonDeactive_Click);
            // 
            // buttonChange
            // 
            this.buttonChange.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.buttonChange.Location = new System.Drawing.Point(17, 59);
            this.buttonChange.Margin = new System.Windows.Forms.Padding(4);
            this.buttonChange.Name = "buttonChange";
            this.buttonChange.Size = new System.Drawing.Size(110, 28);
            this.buttonChange.TabIndex = 4;
            this.buttonChange.Text = "Pwd";
            this.buttonChange.UseVisualStyleBackColor = true;
            this.buttonChange.Click += new System.EventHandler(this.buttonChange_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbPwdNoExpired);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.labelBatch);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.richTextBoxRole);
            this.groupBox2.Controls.Add(this.labelPwdExp);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.labelActive);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.labelLock);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox2.Location = new System.Drawing.Point(11, 98);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(243, 255);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "User:";
            // 
            // lbPwdNoExpired
            // 
            this.lbPwdNoExpired.AutoSize = true;
            this.lbPwdNoExpired.Location = new System.Drawing.Point(79, 118);
            this.lbPwdNoExpired.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbPwdNoExpired.Name = "lbPwdNoExpired";
            this.lbPwdNoExpired.Size = new System.Drawing.Size(32, 17);
            this.lbPwdNoExpired.TabIndex = 12;
            this.lbPwdNoExpired.Text = "Null";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(40, 118);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 17);
            this.label8.TabIndex = 11;
            this.label8.Text = "Exp:";
            // 
            // labelBatch
            // 
            this.labelBatch.AutoSize = true;
            this.labelBatch.Location = new System.Drawing.Point(79, 144);
            this.labelBatch.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelBatch.Name = "labelBatch";
            this.labelBatch.Size = new System.Drawing.Size(32, 17);
            this.labelBatch.TabIndex = 10;
            this.labelBatch.Text = "Null";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 144);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 17);
            this.label6.TabIndex = 9;
            this.label6.Text = "Batch:";
            // 
            // richTextBoxRole
            // 
            this.richTextBoxRole.Location = new System.Drawing.Point(81, 177);
            this.richTextBoxRole.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.richTextBoxRole.Name = "richTextBoxRole";
            this.richTextBoxRole.ReadOnly = true;
            this.richTextBoxRole.Size = new System.Drawing.Size(150, 67);
            this.richTextBoxRole.TabIndex = 8;
            this.richTextBoxRole.Text = "";
            // 
            // labelPwdExp
            // 
            this.labelPwdExp.AutoSize = true;
            this.labelPwdExp.Location = new System.Drawing.Point(79, 92);
            this.labelPwdExp.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPwdExp.Name = "labelPwdExp";
            this.labelPwdExp.Size = new System.Drawing.Size(32, 17);
            this.labelPwdExp.TabIndex = 7;
            this.labelPwdExp.Text = "Null";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 92);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 17);
            this.label7.TabIndex = 6;
            this.label7.Text = "Pwd Exp:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 177);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Role:";
            // 
            // labelActive
            // 
            this.labelActive.AutoSize = true;
            this.labelActive.Location = new System.Drawing.Point(79, 65);
            this.labelActive.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelActive.Name = "labelActive";
            this.labelActive.Size = new System.Drawing.Size(32, 17);
            this.labelActive.TabIndex = 3;
            this.labelActive.Text = "Null";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 65);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 17);
            this.label5.TabIndex = 2;
            this.label5.Text = "Active:";
            // 
            // labelLock
            // 
            this.labelLock.AutoSize = true;
            this.labelLock.Location = new System.Drawing.Point(79, 39);
            this.labelLock.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelLock.Name = "labelLock";
            this.labelLock.Size = new System.Drawing.Size(32, 17);
            this.labelLock.TabIndex = 1;
            this.labelLock.Text = "Null";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 39);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Lock:";
            // 
            // labelGeneral
            // 
            this.labelGeneral.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.labelGeneral.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelGeneral.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelGeneral.Font = new System.Drawing.Font("Lucida Console", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGeneral.Location = new System.Drawing.Point(0, 0);
            this.labelGeneral.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelGeneral.Name = "labelGeneral";
            this.labelGeneral.Size = new System.Drawing.Size(422, 43);
            this.labelGeneral.TabIndex = 4;
            this.labelGeneral.Text = "...";
            this.labelGeneral.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelVer
            // 
            this.labelVer.AutoSize = true;
            this.labelVer.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelVer.Location = new System.Drawing.Point(266, 359);
            this.labelVer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelVer.Name = "labelVer";
            this.labelVer.Size = new System.Drawing.Size(30, 17);
            this.labelVer.TabIndex = 11;
            this.labelVer.Text = "Ver";
            // 
            // contextMenuStripMain
            // 
            this.contextMenuStripMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.topmostToolStripMenuItem,
            this.ctrKUnlockToolStripMenuItem,
            this.readOutlookToolStripMenuItem,
            this.composeReplyEmailToolStripMenuItem,
            this.sendToolStripMenuItem,
            this.autoReplyToolStripMenuItem,
            this.toolStripTextBoxRootFolder,
            this.toolStripTextBoxFolderName,
            this.showLockoutReportToolStripMenuItem,
            this.showLogsToolStripMenuItem});
            this.contextMenuStripMain.Name = "contextMenuStripMain";
            this.contextMenuStripMain.Size = new System.Drawing.Size(223, 282);
            this.contextMenuStripMain.Text = "Settings";
            // 
            // topmostToolStripMenuItem
            // 
            this.topmostToolStripMenuItem.CheckOnClick = true;
            this.topmostToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.topmostToolStripMenuItem.Name = "topmostToolStripMenuItem";
            this.topmostToolStripMenuItem.Size = new System.Drawing.Size(222, 24);
            this.topmostToolStripMenuItem.Text = "Top most";
            this.topmostToolStripMenuItem.CheckedChanged += new System.EventHandler(this.topmostToolStripMenuItem_CheckedChanged);
            // 
            // ctrKUnlockToolStripMenuItem
            // 
            this.ctrKUnlockToolStripMenuItem.CheckOnClick = true;
            this.ctrKUnlockToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ctrKUnlockToolStripMenuItem.Name = "ctrKUnlockToolStripMenuItem";
            this.ctrKUnlockToolStripMenuItem.Size = new System.Drawing.Size(222, 24);
            this.ctrKUnlockToolStripMenuItem.Text = "Ctr + Space to Unlock";
            this.ctrKUnlockToolStripMenuItem.CheckedChanged += new System.EventHandler(this.ctrKUnlockToolStripMenuItem_CheckedChanged);
            // 
            // readOutlookToolStripMenuItem
            // 
            this.readOutlookToolStripMenuItem.CheckOnClick = true;
            this.readOutlookToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.readOutlookToolStripMenuItem.Name = "readOutlookToolStripMenuItem";
            this.readOutlookToolStripMenuItem.Size = new System.Drawing.Size(222, 24);
            this.readOutlookToolStripMenuItem.Text = "Read Outlook";
            this.readOutlookToolStripMenuItem.CheckedChanged += new System.EventHandler(this.ReadOutlookToolStripMenuItem_CheckedChanged);
            // 
            // composeReplyEmailToolStripMenuItem
            // 
            this.composeReplyEmailToolStripMenuItem.CheckOnClick = true;
            this.composeReplyEmailToolStripMenuItem.Name = "composeReplyEmailToolStripMenuItem";
            this.composeReplyEmailToolStripMenuItem.Size = new System.Drawing.Size(222, 24);
            this.composeReplyEmailToolStripMenuItem.Text = "Compose reply";
            // 
            // sendToolStripMenuItem
            // 
            this.sendToolStripMenuItem.CheckOnClick = true;
            this.sendToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.sendToolStripMenuItem.Name = "sendToolStripMenuItem";
            this.sendToolStripMenuItem.Size = new System.Drawing.Size(222, 24);
            this.sendToolStripMenuItem.Text = "Send w/o display";
            // 
            // autoReplyToolStripMenuItem
            // 
            this.autoReplyToolStripMenuItem.CheckOnClick = true;
            this.autoReplyToolStripMenuItem.Enabled = false;
            this.autoReplyToolStripMenuItem.Name = "autoReplyToolStripMenuItem";
            this.autoReplyToolStripMenuItem.Size = new System.Drawing.Size(222, 24);
            this.autoReplyToolStripMenuItem.Text = "Auto reply";
            this.autoReplyToolStripMenuItem.Click += new System.EventHandler(this.AutoReplyToolStripMenuItem_Click);
            // 
            // toolStripTextBoxRootFolder
            // 
            this.toolStripTextBoxRootFolder.AutoToolTip = true;
            this.toolStripTextBoxRootFolder.BackColor = System.Drawing.SystemColors.ControlLight;
            this.toolStripTextBoxRootFolder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toolStripTextBoxRootFolder.Name = "toolStripTextBoxRootFolder";
            this.toolStripTextBoxRootFolder.Size = new System.Drawing.Size(100, 27);
            this.toolStripTextBoxRootFolder.ToolTipText = "Root folder to find";
            // 
            // toolStripTextBoxFolderName
            // 
            this.toolStripTextBoxFolderName.AutoToolTip = true;
            this.toolStripTextBoxFolderName.BackColor = System.Drawing.SystemColors.ControlLight;
            this.toolStripTextBoxFolderName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toolStripTextBoxFolderName.Name = "toolStripTextBoxFolderName";
            this.toolStripTextBoxFolderName.Size = new System.Drawing.Size(100, 27);
            this.toolStripTextBoxFolderName.ToolTipText = "Folder name to monitor for incomming emails";
            // 
            // showLockoutReportToolStripMenuItem
            // 
            this.showLockoutReportToolStripMenuItem.Enabled = false;
            this.showLockoutReportToolStripMenuItem.Name = "showLockoutReportToolStripMenuItem";
            this.showLockoutReportToolStripMenuItem.Size = new System.Drawing.Size(222, 24);
            this.showLockoutReportToolStripMenuItem.Text = "Show Lockout Report";
            this.showLockoutReportToolStripMenuItem.Visible = false;
            this.showLockoutReportToolStripMenuItem.Click += new System.EventHandler(this.ShowLockoutReportToolStripMenuItem_Click);
            // 
            // showLogsToolStripMenuItem
            // 
            this.showLogsToolStripMenuItem.Name = "showLogsToolStripMenuItem";
            this.showLogsToolStripMenuItem.Size = new System.Drawing.Size(222, 24);
            this.showLogsToolStripMenuItem.Text = "Show Logs";
            this.showLogsToolStripMenuItem.Click += new System.EventHandler(this.ShowLogsToolStripMenuItem_Click);
            // 
            // labelCurrentActing
            // 
            this.labelCurrentActing.BackColor = System.Drawing.SystemColors.ControlLight;
            this.labelCurrentActing.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCurrentActing.Location = new System.Drawing.Point(73, 94);
            this.labelCurrentActing.Name = "labelCurrentActing";
            this.labelCurrentActing.Size = new System.Drawing.Size(169, 25);
            this.labelCurrentActing.TabIndex = 11;
            this.labelCurrentActing.Text = "...";
            this.labelCurrentActing.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(422, 382);
            this.ContextMenuStrip = this.contextMenuStripMain;
            this.Controls.Add(this.labelCurrentActing);
            this.Controls.Add(this.labelVer);
            this.Controls.Add(this.labelGeneral);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonFetch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxUsername);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = global::MyAD.Properties.Resources.book;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "My AD";
            this.Activated += new System.EventHandler(this.MainForm_Activated);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.contextMenuStripMain.ResumeLayout(false);
            this.contextMenuStripMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonUnlock;
        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonFetch;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelActive;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelLock;
        private System.Windows.Forms.Button buttonChange;
        private System.Windows.Forms.Label labelGeneral;
        private System.Windows.Forms.Button buttonDeactive;
        private System.Windows.Forms.Label labelPwdExp;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox richTextBoxRole;
        private System.Windows.Forms.Button buttonChangeBatch;
        private System.Windows.Forms.Label labelBatch;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelVer;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripMain;
        private System.Windows.Forms.ToolStripMenuItem topmostToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ctrKUnlockToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem readOutlookToolStripMenuItem;
        private System.Windows.Forms.Label labelCurrentActing;
        private System.Windows.Forms.ToolStripMenuItem composeReplyEmailToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sendToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showLogsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showLockoutReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autoReplyToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxFolderName;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxRootFolder;
        private System.Windows.Forms.Label lbPwdNoExpired;
        private System.Windows.Forms.Label label8;
    }
}

