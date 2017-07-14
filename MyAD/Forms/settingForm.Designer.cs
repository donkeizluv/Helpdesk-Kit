namespace MyAD.Forms
{
    partial class settingForm
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
            this.checkBoxCtrSpace = new System.Windows.Forms.CheckBox();
            this.checkBoxReadOL = new System.Windows.Forms.CheckBox();
            this.checkBoxSend = new System.Windows.Forms.CheckBox();
            this.checkBoxCtrB = new System.Windows.Forms.CheckBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // checkBoxCtrSpace
            // 
            this.checkBoxCtrSpace.AutoSize = true;
            this.checkBoxCtrSpace.Location = new System.Drawing.Point(12, 12);
            this.checkBoxCtrSpace.Name = "checkBoxCtrSpace";
            this.checkBoxCtrSpace.Size = new System.Drawing.Size(165, 21);
            this.checkBoxCtrSpace.TabIndex = 0;
            this.checkBoxCtrSpace.Text = "Ctr + Space to unlock";
            this.checkBoxCtrSpace.UseVisualStyleBackColor = true;
            this.checkBoxCtrSpace.CheckedChanged += new System.EventHandler(this.checkBoxCtrSpace_CheckedChanged);
            // 
            // checkBoxReadOL
            // 
            this.checkBoxReadOL.AutoSize = true;
            this.checkBoxReadOL.Location = new System.Drawing.Point(34, 39);
            this.checkBoxReadOL.Name = "checkBoxReadOL";
            this.checkBoxReadOL.Size = new System.Drawing.Size(114, 21);
            this.checkBoxReadOL.TabIndex = 1;
            this.checkBoxReadOL.Text = "Read outlook";
            this.checkBoxReadOL.UseVisualStyleBackColor = true;
            this.checkBoxReadOL.CheckedChanged += new System.EventHandler(this.checkBoxReadOL_CheckedChanged);
            // 
            // checkBoxSend
            // 
            this.checkBoxSend.AutoSize = true;
            this.checkBoxSend.Location = new System.Drawing.Point(34, 109);
            this.checkBoxSend.Name = "checkBoxSend";
            this.checkBoxSend.Size = new System.Drawing.Size(126, 21);
            this.checkBoxSend.TabIndex = 3;
            this.checkBoxSend.Text = "Send response";
            this.checkBoxSend.UseVisualStyleBackColor = true;
            this.checkBoxSend.CheckedChanged += new System.EventHandler(this.checkBoxSend_CheckedChanged);
            // 
            // checkBoxCtrB
            // 
            this.checkBoxCtrB.AutoSize = true;
            this.checkBoxCtrB.Location = new System.Drawing.Point(12, 82);
            this.checkBoxCtrB.Name = "checkBoxCtrB";
            this.checkBoxCtrB.Size = new System.Drawing.Size(209, 21);
            this.checkBoxCtrB.TabIndex = 2;
            this.checkBoxCtrB.Text = "Ctr + B to unlock n response";
            this.checkBoxCtrB.UseVisualStyleBackColor = true;
            this.checkBoxCtrB.CheckedChanged += new System.EventHandler(this.checkBoxCtrB_CheckedChanged);
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(73, 154);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 4;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // settingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(220, 189);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.checkBoxSend);
            this.Controls.Add(this.checkBoxCtrB);
            this.Controls.Add(this.checkBoxReadOL);
            this.Controls.Add(this.checkBoxCtrSpace);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "settingForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Setting";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonOK;
        public System.Windows.Forms.CheckBox checkBoxCtrSpace;
        public System.Windows.Forms.CheckBox checkBoxReadOL;
        public System.Windows.Forms.CheckBox checkBoxSend;
        public System.Windows.Forms.CheckBox checkBoxCtrB;
    }
}