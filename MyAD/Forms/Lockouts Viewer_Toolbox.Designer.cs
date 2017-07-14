namespace MyAD.Forms
{
    partial class Lockouts_Viewer_Toolbox
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
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.labelUser = new System.Windows.Forms.Label();
            this.buttonClear = new System.Windows.Forms.Button();
            this.groupBoxFilter = new System.Windows.Forms.GroupBox();
            this.buttonApply = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxUnlocker = new System.Windows.Forms.TextBox();
            this.labelUnlker = new System.Windows.Forms.Label();
            this.textBoxUser = new System.Windows.Forms.TextBox();
            this.groupBoxFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Checked = false;
            this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker.Location = new System.Drawing.Point(97, 106);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.ShowCheckBox = true;
            this.dateTimePicker.Size = new System.Drawing.Size(160, 22);
            this.dateTimePicker.TabIndex = 0;
            // 
            // labelUser
            // 
            this.labelUser.AutoSize = true;
            this.labelUser.Location = new System.Drawing.Point(38, 31);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(42, 17);
            this.labelUser.TabIndex = 1;
            this.labelUser.Text = "User:";
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(213, 146);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(75, 35);
            this.buttonClear.TabIndex = 2;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // groupBoxFilter
            // 
            this.groupBoxFilter.Controls.Add(this.buttonApply);
            this.groupBoxFilter.Controls.Add(this.label3);
            this.groupBoxFilter.Controls.Add(this.textBoxUnlocker);
            this.groupBoxFilter.Controls.Add(this.labelUnlker);
            this.groupBoxFilter.Controls.Add(this.textBoxUser);
            this.groupBoxFilter.Controls.Add(this.dateTimePicker);
            this.groupBoxFilter.Controls.Add(this.labelUser);
            this.groupBoxFilter.Controls.Add(this.buttonClear);
            this.groupBoxFilter.Location = new System.Drawing.Point(15, 12);
            this.groupBoxFilter.Name = "groupBoxFilter";
            this.groupBoxFilter.Size = new System.Drawing.Size(321, 195);
            this.groupBoxFilter.TabIndex = 3;
            this.groupBoxFilter.TabStop = false;
            this.groupBoxFilter.Text = "Filter";
            // 
            // buttonApply
            // 
            this.buttonApply.Location = new System.Drawing.Point(41, 146);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(75, 35);
            this.buttonApply.TabIndex = 6;
            this.buttonApply.Text = "Apply";
            this.buttonApply.UseVisualStyleBackColor = true;
            this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Date:";
            // 
            // textBoxUnlocker
            // 
            this.textBoxUnlocker.Location = new System.Drawing.Point(97, 68);
            this.textBoxUnlocker.Name = "textBoxUnlocker";
            this.textBoxUnlocker.Size = new System.Drawing.Size(160, 22);
            this.textBoxUnlocker.TabIndex = 4;
            // 
            // labelUnlker
            // 
            this.labelUnlker.AutoSize = true;
            this.labelUnlker.Location = new System.Drawing.Point(25, 68);
            this.labelUnlker.Name = "labelUnlker";
            this.labelUnlker.Size = new System.Drawing.Size(55, 17);
            this.labelUnlker.TabIndex = 3;
            this.labelUnlker.Text = "Unlock:";
            // 
            // textBoxUser
            // 
            this.textBoxUser.Location = new System.Drawing.Point(97, 31);
            this.textBoxUser.Name = "textBoxUser";
            this.textBoxUser.Size = new System.Drawing.Size(160, 22);
            this.textBoxUser.TabIndex = 0;
            // 
            // Lockouts_Viewer_Toolbox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 221);
            this.Controls.Add(this.groupBoxFilter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Lockouts_Viewer_Toolbox";
            this.Text = "Toolbox";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Lockouts_Viewer_Toolbox_FormClosing);
            this.groupBoxFilter.ResumeLayout(false);
            this.groupBoxFilter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Label labelUser;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.GroupBox groupBoxFilter;
        private System.Windows.Forms.Button buttonApply;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxUnlocker;
        private System.Windows.Forms.Label labelUnlker;
        private System.Windows.Forms.TextBox textBoxUser;
    }
}