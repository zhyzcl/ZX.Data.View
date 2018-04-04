namespace ZX.Data.View
{
    partial class frmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.TSC = new System.Windows.Forms.ToolStripContainer();
            this.TC = new System.Windows.Forms.TabControl();
            this.MS = new System.Windows.Forms.MenuStrip();
            this.tsLoad = new System.Windows.Forms.ToolStripMenuItem();
            this.tsSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.tsLoadOriginal = new System.Windows.Forms.ToolStripMenuItem();
            this.tsViewChanged = new System.Windows.Forms.ToolStripMenuItem();
            this.tssSteamConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.tsLoadSteamConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.tsDeleteAndSaveSteamConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.tsFixFileAndSaveSteamConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMIsznlscq = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMIExit = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsTip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsTipText = new System.Windows.Forms.ToolStripMenuItem();
            this.TSC.ContentPanel.SuspendLayout();
            this.TSC.TopToolStripPanel.SuspendLayout();
            this.TSC.SuspendLayout();
            this.MS.SuspendLayout();
            this.cmsTip.SuspendLayout();
            this.SuspendLayout();
            // 
            // TSC
            // 
            // 
            // TSC.ContentPanel
            // 
            this.TSC.ContentPanel.Controls.Add(this.TC);
            this.TSC.ContentPanel.Size = new System.Drawing.Size(1004, 386);
            this.TSC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TSC.Location = new System.Drawing.Point(0, 0);
            this.TSC.Name = "TSC";
            this.TSC.Size = new System.Drawing.Size(1004, 411);
            this.TSC.TabIndex = 0;
            this.TSC.Text = "toolStripContainer1";
            // 
            // TSC.TopToolStripPanel
            // 
            this.TSC.TopToolStripPanel.Controls.Add(this.MS);
            // 
            // TC
            // 
            this.TC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TC.Location = new System.Drawing.Point(0, 0);
            this.TC.Name = "TC";
            this.TC.SelectedIndex = 0;
            this.TC.Size = new System.Drawing.Size(1004, 386);
            this.TC.TabIndex = 0;
            // 
            // MS
            // 
            this.MS.Dock = System.Windows.Forms.DockStyle.None;
            this.MS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsLoad,
            this.tsSaveAs,
            this.tsLoadOriginal,
            this.tsViewChanged,
            this.tssSteamConfig,
            this.TSMIsznlscq,
            this.TSMIExit});
            this.MS.Location = new System.Drawing.Point(0, 0);
            this.MS.Name = "MS";
            this.MS.Size = new System.Drawing.Size(1004, 25);
            this.MS.TabIndex = 0;
            this.MS.Text = "menuStrip1";
            // 
            // tsLoad
            // 
            this.tsLoad.Name = "tsLoad";
            this.tsLoad.Size = new System.Drawing.Size(86, 21);
            this.tsLoad.Text = "读取文件(&O)";
            this.tsLoad.Click += new System.EventHandler(this.tsLoad_Click);
            // 
            // tsSaveAs
            // 
            this.tsSaveAs.Name = "tsSaveAs";
            this.tsSaveAs.Size = new System.Drawing.Size(59, 21);
            this.tsSaveAs.Text = "另存(&S)";
            this.tsSaveAs.Click += new System.EventHandler(this.tsSaveAs_Click);
            // 
            // tsLoadOriginal
            // 
            this.tsLoadOriginal.Name = "tsLoadOriginal";
            this.tsLoadOriginal.Size = new System.Drawing.Size(148, 21);
            this.tsLoadOriginal.Text = "读取原始文件(用于比对)";
            this.tsLoadOriginal.Click += new System.EventHandler(this.tsLoadOriginal_Click);
            // 
            // tsViewChanged
            // 
            this.tsViewChanged.Enabled = false;
            this.tsViewChanged.Name = "tsViewChanged";
            this.tsViewChanged.Size = new System.Drawing.Size(68, 21);
            this.tsViewChanged.Text = "查看不同";
            this.tsViewChanged.Click += new System.EventHandler(this.tsViewChanged_Click);
            // 
            // tssSteamConfig
            // 
            this.tssSteamConfig.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsLoadSteamConfig,
            this.tsDeleteAndSaveSteamConfig,
            this.tsFixFileAndSaveSteamConfig});
            this.tssSteamConfig.Name = "tssSteamConfig";
            this.tssSteamConfig.Size = new System.Drawing.Size(116, 21);
            this.tssSteamConfig.Text = "SteamConfig.dat";
            // 
            // tsLoadSteamConfig
            // 
            this.tsLoadSteamConfig.Name = "tsLoadSteamConfig";
            this.tsLoadSteamConfig.Size = new System.Drawing.Size(230, 22);
            this.tsLoadSteamConfig.Text = "读取";
            this.tsLoadSteamConfig.Click += new System.EventHandler(this.tsLoadSteamConfig_Click);
            // 
            // tsDeleteAndSaveSteamConfig
            // 
            this.tsDeleteAndSaveSteamConfig.Enabled = false;
            this.tsDeleteAndSaveSteamConfig.Name = "tsDeleteAndSaveSteamConfig";
            this.tsDeleteAndSaveSteamConfig.Size = new System.Drawing.Size(230, 22);
            this.tsDeleteAndSaveSteamConfig.Text = "删除不匹配项目并保存";
            this.tsDeleteAndSaveSteamConfig.Click += new System.EventHandler(this.tsDeleteAndSaveSteamConfig_Click);
            // 
            // tsFixFileAndSaveSteamConfig
            // 
            this.tsFixFileAndSaveSteamConfig.Enabled = false;
            this.tsFixFileAndSaveSteamConfig.Name = "tsFixFileAndSaveSteamConfig";
            this.tsFixFileAndSaveSteamConfig.Size = new System.Drawing.Size(230, 22);
            this.tsFixFileAndSaveSteamConfig.Text = "修复ZXRules文件校验并保存";
            this.tsFixFileAndSaveSteamConfig.Click += new System.EventHandler(this.tsFixFileAndSaveSteamConfig_Click);
            // 
            // TSMIsznlscq
            // 
            this.TSMIsznlscq.Name = "TSMIsznlscq";
            this.TSMIsznlscq.Size = new System.Drawing.Size(104, 21);
            this.TSMIsznlscq.Text = "市长能力生成器";
            this.TSMIsznlscq.Click += new System.EventHandler(this.TSMIsznlscq_Click);
            // 
            // TSMIExit
            // 
            this.TSMIExit.Name = "TSMIExit";
            this.TSMIExit.Size = new System.Drawing.Size(44, 21);
            this.TSMIExit.Text = "退出";
            this.TSMIExit.Click += new System.EventHandler(this.TSMIExit_Click);
            // 
            // cmsTip
            // 
            this.cmsTip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsTipText});
            this.cmsTip.Name = "CMS";
            this.cmsTip.Size = new System.Drawing.Size(69, 26);
            // 
            // cmsTipText
            // 
            this.cmsTipText.Name = "cmsTipText";
            this.cmsTipText.Size = new System.Drawing.Size(68, 22);
            this.cmsTipText.Click += new System.EventHandler(this.cmsTipText_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 411);
            this.Controls.Add(this.TSC);
            this.MainMenuStrip = this.MS;
            this.Name = "frmMain";
            this.Text = "ZX.Data.View 8.5.4";
            this.TSC.ContentPanel.ResumeLayout(false);
            this.TSC.TopToolStripPanel.ResumeLayout(false);
            this.TSC.TopToolStripPanel.PerformLayout();
            this.TSC.ResumeLayout(false);
            this.TSC.PerformLayout();
            this.MS.ResumeLayout(false);
            this.MS.PerformLayout();
            this.cmsTip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer TSC;
        private System.Windows.Forms.MenuStrip MS;
        private System.Windows.Forms.ToolStripMenuItem tsLoad;
        private System.Windows.Forms.TabControl TC;
        private System.Windows.Forms.ToolStripMenuItem tsSaveAs;
        private System.Windows.Forms.ToolStripMenuItem tsLoadOriginal;
        private System.Windows.Forms.ToolStripMenuItem tsViewChanged;
        private System.Windows.Forms.ContextMenuStrip cmsTip;
        private System.Windows.Forms.ToolStripMenuItem cmsTipText;
        private System.Windows.Forms.ToolStripMenuItem tssSteamConfig;
        private System.Windows.Forms.ToolStripMenuItem tsLoadSteamConfig;
        private System.Windows.Forms.ToolStripMenuItem tsDeleteAndSaveSteamConfig;
        private System.Windows.Forms.ToolStripMenuItem tsFixFileAndSaveSteamConfig;
        private System.Windows.Forms.ToolStripMenuItem TSMIsznlscq;
        private System.Windows.Forms.ToolStripMenuItem TSMIExit;
    }
}

