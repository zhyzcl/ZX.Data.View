namespace ZX.Data.View
{
    partial class frmPassword
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
            this.label1 = new System.Windows.Forms.Label();
            this.tBpwd = new System.Windows.Forms.TextBox();
            this.btqd = new System.Windows.Forms.Button();
            this.btqx = new System.Windows.Forms.Button();
            this.cBver = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "解压密码：";
            // 
            // tBpwd
            // 
            this.tBpwd.Location = new System.Drawing.Point(87, 55);
            this.tBpwd.Name = "tBpwd";
            this.tBpwd.Size = new System.Drawing.Size(270, 21);
            this.tBpwd.TabIndex = 1;
            // 
            // btqd
            // 
            this.btqd.Location = new System.Drawing.Point(87, 91);
            this.btqd.Name = "btqd";
            this.btqd.Size = new System.Drawing.Size(75, 23);
            this.btqd.TabIndex = 2;
            this.btqd.Text = "确定";
            this.btqd.UseVisualStyleBackColor = true;
            this.btqd.Click += new System.EventHandler(this.btqd_Click);
            // 
            // btqx
            // 
            this.btqx.Location = new System.Drawing.Point(204, 91);
            this.btqx.Name = "btqx";
            this.btqx.Size = new System.Drawing.Size(75, 23);
            this.btqx.TabIndex = 3;
            this.btqx.Text = "取消";
            this.btqx.UseVisualStyleBackColor = true;
            this.btqx.Click += new System.EventHandler(this.btqx_Click);
            // 
            // cBver
            // 
            this.cBver.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBver.FormattingEnabled = true;
            this.cBver.Location = new System.Drawing.Point(87, 18);
            this.cBver.Name = "cBver";
            this.cBver.Size = new System.Drawing.Size(270, 20);
            this.cBver.TabIndex = 4;
            this.cBver.SelectedIndexChanged += new System.EventHandler(this.cBver_SelectedIndexChanged);
            // 
            // frmPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 126);
            this.ControlBox = false;
            this.Controls.Add(this.cBver);
            this.Controls.Add(this.btqx);
            this.Controls.Add(this.btqd);
            this.Controls.Add(this.tBpwd);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(396, 165);
            this.MinimumSize = new System.Drawing.Size(396, 165);
            this.Name = "frmPassword";
            this.Text = "输入压缩文件解压密码";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tBpwd;
        private System.Windows.Forms.Button btqd;
        private System.Windows.Forms.Button btqx;
        private System.Windows.Forms.ComboBox cBver;
    }
}