namespace MyAD.Forms
{
    partial class Lockouts_Viewer
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColADName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnlockTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnlocker = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonFilter = new System.Windows.Forms.Button();
            this.labelMaxPage = new System.Windows.Forms.Label();
            this.labelSlash = new System.Windows.Forms.Label();
            this.buttonFirst = new System.Windows.Forms.Button();
            this.buttonLast = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            this.buttonPrev = new System.Windows.Forms.Button();
            this.labelCurrentPage = new System.Windows.Forms.Label();
            this.labelTotalRowText = new System.Windows.Forms.Label();
            this.labelTotalRow = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID,
            this.ColADName,
            this.colUnlockTime,
            this.colUnlocker});
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(710, 460);
            this.dataGridView1.TabIndex = 0;
            // 
            // colID
            // 
            this.colID.HeaderText = "Id";
            this.colID.Name = "colID";
            this.colID.ReadOnly = true;
            this.colID.Width = 50;
            // 
            // ColADName
            // 
            this.ColADName.HeaderText = "ADName";
            this.ColADName.Name = "ColADName";
            this.ColADName.ReadOnly = true;
            this.ColADName.Width = 150;
            // 
            // colUnlockTime
            // 
            this.colUnlockTime.HeaderText = "UnlockTime";
            this.colUnlockTime.Name = "colUnlockTime";
            this.colUnlockTime.ReadOnly = true;
            this.colUnlockTime.Width = 180;
            // 
            // colUnlocker
            // 
            this.colUnlocker.HeaderText = "Unlocker";
            this.colUnlocker.Name = "colUnlocker";
            this.colUnlocker.ReadOnly = true;
            this.colUnlocker.Width = 120;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelTotalRow);
            this.panel1.Controls.Add(this.labelTotalRowText);
            this.panel1.Controls.Add(this.buttonFilter);
            this.panel1.Controls.Add(this.labelMaxPage);
            this.panel1.Controls.Add(this.labelSlash);
            this.panel1.Controls.Add(this.buttonFirst);
            this.panel1.Controls.Add(this.buttonLast);
            this.panel1.Controls.Add(this.buttonNext);
            this.panel1.Controls.Add(this.buttonPrev);
            this.panel1.Controls.Add(this.labelCurrentPage);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 458);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(710, 51);
            this.panel1.TabIndex = 1;
            // 
            // buttonFilter
            // 
            this.buttonFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonFilter.Location = new System.Drawing.Point(656, 10);
            this.buttonFilter.Name = "buttonFilter";
            this.buttonFilter.Size = new System.Drawing.Size(51, 31);
            this.buttonFilter.TabIndex = 20;
            this.buttonFilter.Text = "Filter";
            this.buttonFilter.UseVisualStyleBackColor = true;
            this.buttonFilter.Click += new System.EventHandler(this.buttonFilter_Click);
            // 
            // labelMaxPage
            // 
            this.labelMaxPage.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.labelMaxPage.AutoSize = true;
            this.labelMaxPage.Location = new System.Drawing.Point(370, 17);
            this.labelMaxPage.Name = "labelMaxPage";
            this.labelMaxPage.Size = new System.Drawing.Size(16, 17);
            this.labelMaxPage.TabIndex = 19;
            this.labelMaxPage.Text = "0";
            // 
            // labelSlash
            // 
            this.labelSlash.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.labelSlash.AutoSize = true;
            this.labelSlash.Location = new System.Drawing.Point(352, 17);
            this.labelSlash.Name = "labelSlash";
            this.labelSlash.Size = new System.Drawing.Size(12, 17);
            this.labelSlash.TabIndex = 18;
            this.labelSlash.Text = "/";
            // 
            // buttonFirst
            // 
            this.buttonFirst.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonFirst.Location = new System.Drawing.Point(195, 10);
            this.buttonFirst.Name = "buttonFirst";
            this.buttonFirst.Size = new System.Drawing.Size(51, 31);
            this.buttonFirst.TabIndex = 17;
            this.buttonFirst.Text = "<<";
            this.buttonFirst.UseVisualStyleBackColor = true;
            this.buttonFirst.Click += new System.EventHandler(this.buttonFirst_Click);
            // 
            // buttonLast
            // 
            this.buttonLast.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonLast.Location = new System.Drawing.Point(475, 10);
            this.buttonLast.Name = "buttonLast";
            this.buttonLast.Size = new System.Drawing.Size(51, 31);
            this.buttonLast.TabIndex = 16;
            this.buttonLast.Text = ">>";
            this.buttonLast.UseVisualStyleBackColor = true;
            this.buttonLast.Click += new System.EventHandler(this.buttonLast_Click);
            // 
            // buttonNext
            // 
            this.buttonNext.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonNext.Location = new System.Drawing.Point(418, 10);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(51, 31);
            this.buttonNext.TabIndex = 15;
            this.buttonNext.Text = ">";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // buttonPrev
            // 
            this.buttonPrev.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonPrev.Location = new System.Drawing.Point(252, 10);
            this.buttonPrev.Name = "buttonPrev";
            this.buttonPrev.Size = new System.Drawing.Size(51, 31);
            this.buttonPrev.TabIndex = 13;
            this.buttonPrev.Text = "<";
            this.buttonPrev.UseVisualStyleBackColor = true;
            this.buttonPrev.Click += new System.EventHandler(this.buttonPrev_Click);
            // 
            // labelCurrentPage
            // 
            this.labelCurrentPage.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.labelCurrentPage.AutoSize = true;
            this.labelCurrentPage.Location = new System.Drawing.Point(319, 17);
            this.labelCurrentPage.Name = "labelCurrentPage";
            this.labelCurrentPage.Size = new System.Drawing.Size(16, 17);
            this.labelCurrentPage.TabIndex = 14;
            this.labelCurrentPage.Text = "0";
            // 
            // labelTotalRowText
            // 
            this.labelTotalRowText.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.labelTotalRowText.AutoSize = true;
            this.labelTotalRowText.Location = new System.Drawing.Point(9, 17);
            this.labelTotalRowText.Name = "labelTotalRowText";
            this.labelTotalRowText.Size = new System.Drawing.Size(49, 17);
            this.labelTotalRowText.TabIndex = 2;
            this.labelTotalRowText.Text = "Count:";
            // 
            // labelTotalRow
            // 
            this.labelTotalRow.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.labelTotalRow.AutoSize = true;
            this.labelTotalRow.Location = new System.Drawing.Point(64, 17);
            this.labelTotalRow.Name = "labelTotalRow";
            this.labelTotalRow.Size = new System.Drawing.Size(35, 17);
            this.labelTotalRow.TabIndex = 21;
            this.labelTotalRow.Text = "XXX";
            // 
            // Lockouts_Viewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 509);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "Lockouts_Viewer";
            this.Text = "Lockouts Viewer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Lockouts_Viewer_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonFilter;
        private System.Windows.Forms.Label labelMaxPage;
        private System.Windows.Forms.Label labelSlash;
        private System.Windows.Forms.Button buttonFirst;
        private System.Windows.Forms.Button buttonLast;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Button buttonPrev;
        private System.Windows.Forms.Label labelCurrentPage;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColADName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnlockTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnlocker;
        private System.Windows.Forms.Label labelTotalRow;
        private System.Windows.Forms.Label labelTotalRowText;
    }
}