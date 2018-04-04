using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using DXVision;
using Ionic.Zip;
using App;

namespace ZX.Data.View
{
    public partial class frmMain : Form
    {
        public static string cfilepwd = "";
        public static string ofilepwd = "";

        ///<summary>Dat,当前表管理员</summary>
        DXTableManager DXTableManagerCurrent;
        ///<summary>Dat,原始表管理员</summary>
        DXTableManager DXTableManagerOriginal;

        Form frmChanged;
        Form frmSteamConfig;
        frmMayors FrmMayors;

        string SteamConfigPath;
        Dictionary<string, uint> DicSteamConfig;
        HashSet<string> HSetIncorrectFile;
        DataTable DtSteamConfig;
        string ZXRulesName = "";
        uint ZXRulesSum = 0;
        bool ZXRulesIncorrect = false;


        public frmMain()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void tsLoad_Click(object sender, EventArgs e)
        {
            LoadFile(0);
        }

        private void tsLoadOriginal_Click(object sender, EventArgs e)
        {
            LoadFile(1);
        }

        private void tsLoadSteamConfig_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog()
            {
                Filter = "Data files(*.dat)|*.dat"
            };
            if (ofd.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            LoadSteamConfig(ofd.FileName);
        }

        private void LoadFile(int loadType)
        {
            var ofd = new OpenFileDialog();
            ofd.Filter = "Data files(*.dat)|*.dat";
            if (ofd.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            var path = ofd.FileName;
            if (System.IO.Path.GetFileName(path).ToUpper() == "STEAMCONFIG.DAT")
            {
                this.LoadSteamConfig(path);
                return;
            }
            string errs = "";
            ZipExtract(loadType, ref path, ref errs);
            if (errs != "")
            {
                MessageBox.Show(errs);
                return;
            }
            try
            {
                switch (loadType)
                {
                    case 0:
                        this.DXTableManagerCurrent = null;
                        this.DXTableManagerCurrent = DXTableManager.FromDatFile(path);

                        if (this.DXTableManagerOriginal == null)
                        {
                            this.DXTableManagerOriginal = DXTableManager.FromDatFile(path);
                        }
                        break;
                    case 1:
                        this.DXTableManagerOriginal = null;
                        this.DXTableManagerOriginal = DXTableManager.FromDatFile(path);

                        break;
                }
                this.tsViewChanged.Enabled = this.DXTableManagerCurrent != null;

                if (this.DXTableManagerCurrent != null)
                {
                    this.TC.TabPages.Clear();
                    this.TC.ShowToolTips = true;
                    foreach (var i in this.DXTableManagerCurrent.Tables)
                    {
                        var dt = new DataTable();
                        foreach (var i2 in i.Value.Cols)
                        {
                            dt.Columns.Add(i2.Key);
                        }

                        foreach (var i2 in i.Value.Rows)
                        {
                            dt.Rows.Add(i2.Value);
                        }

                        var tp = new TabPage(i.Key);
                        var dgv = new DataGridView()
                        {
                            ShowCellToolTips = true,
                            DataSource = dt,
                            Dock = DockStyle.Fill,
                            AllowUserToOrderColumns = false,
                            AllowUserToAddRows = false,
                            AllowUserToDeleteRows = false,
                        };
                        typeof(DataGridView).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)?.SetValue(dgv, true, null);

                        dgv.DefaultCellStyle = App.AppList.CSytleNoFound;
                        dgv.CellValueChanged += this.Dgv_CellValueChanged;
                        dgv.DataBindingComplete += this.Dgv_DataBindingComplete;
                        dgv.CurrentCellChanged += this.Dgv_CurrentCellChanged;

                        tp.Controls.Add(dgv);
                        this.TC.TabPages.Add(tp);
                    }
                    SetDataGridView();
                    if (loadType==1)
                    {
                        if (this.DXTableManagerCurrent == null || this.DXTableManagerOriginal == null)
                        {
                        }
                        else
                        {
                            DataTable dtResult = GetTableResult();
                            if (dtResult.Rows.Count>0)
                            {
                                ViewChanged(dtResult);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("读取文件发生错误/r" + ex.Message);
            }
        }

        private void SetDataGridView()
        {
            StringBuilder sb = new StringBuilder();
            List<string> slist = new List<string>();
            TabControl.TabPageCollection tpc = this.TC.TabPages;
            if (tpc == null)
            {
                return;
            }
            for (int ii = 0; ii < tpc.Count; ii++)
            {
                TabPage tp = tpc[ii];
                string tpname = tp.Text.Trim();
                tp.ToolTipText = tpname;
                tp.Text = GetText(tpname);
                if (slist.IndexOf(tpname) == -1)
                {
                    slist.Add(tpname);
                }
                DataGridView dgv = (DataGridView)tp.Controls[0];
                for (int i = 0; i < dgv.ColumnCount; i++)
                {
                    DataGridViewColumnCollection dgvcc = dgv.Columns;
                    string cname = dgvcc[i].HeaderText;
                    dgvcc[i].ToolTipText = cname;
                    dgvcc[i].HeaderText = GetText(cname);
                    if (slist.IndexOf(cname) == -1)
                    {
                        slist.Add(cname);
                    }
                }
                for (int i = 0; i < dgv.RowCount; i++)
                {
                    DataGridViewRowCollection dgvrc = dgv.Rows;
                    string rname = dgvrc[i].HeaderCell.ToolTipText.ToString();
                    if (slist.IndexOf(rname) == -1)
                    {
                        slist.Add(rname);
                    }
                    for (int ix = 0; ix < dgv.ColumnCount; ix++)
                    {
                        CellValueChanged(dgv, ix, i);
                    }
                }
            }
            if (slist.Count > 0)
            {
                for (int i = 0; i < slist.Count; i++)
                {
                    if (sb.Length > 0)
                    {
                        sb.Append("\r");
                    }
                    sb.Append(slist[i]);
                }
            }
            string s = sb.ToString();
        }

        private string GetText(string cname)
        {
            if (dic.ContainsKey(cname))
            {
                string s = dic[cname].Trim();
                if (s != "")
                {
                    return s;
                    //return s + "(" + cname + ")";
                }
            }
            return cname;
        }

        private void ZipExtract(int loadType, ref string path, ref string errs)
        {
            List<string> flist = new List<string>();
            FileSys.DelDir(AppList.TestDir);
            FileSys.NewDir(AppList.TestDir);
            errs = "";
            int isext = 0;
            int excount = 0;
            List<string> tpwdlist = App.AppList.GetListValue(App.AppList.File_ZipPassword());
            int tcount = tpwdlist.Count;
            int actt = 0;
            while (isext == 0)
            {
                try
                {
                    using (ZipFile zip = ZipFile.Read(path))
                    {
                        if (loadType == 0)
                        {
                            zip.Password = cfilepwd;
                        }
                        else
                        {
                            zip.Password = ofilepwd;
                        }
                        foreach (ZipEntry entry in zip)
                        {
                            string fname = entry.FileName;
                            entry.Extract(AppList.TestDir, ExtractExistingFileAction.OverwriteSilently);
                            if (!entry.IsDirectory)
                            {
                                flist.Add(fname);
                            }
                        }
                        isext = 2;
                    }
                }
                catch (Exception ex)
                {
                    string es = ex.Message.ToLower();
                    if (es.IndexOf("password") > -1 && es.IndexOf("did") > -1 && es.IndexOf("not") > -1 && es.IndexOf("match") > -1)
                    {
                        if (tcount > 0 && actt < tcount)
                        {
                            if (loadType == 0)
                            {
                                cfilepwd = tpwdlist[actt];
                            }
                            else
                            {
                                ofilepwd = tpwdlist[actt];
                            }
                            actt++;
                        }
                        else
                        {
                            if (excount > 0)
                            {
                                MessageBox.Show("解压密码输入错误，请重新输入密码！");
                            }
                            isext = 0;
                            using (frmPassword form = new frmPassword())
                            {
                                form.StartPosition = FormStartPosition.CenterScreen;
                                form.ShowDialog(this);
                                if (!form.isoper)
                                {
                                    errs = "文件解压失败，失败原因：密码输入错误！";
                                    isext = 1;
                                }
                                else
                                {
                                    if (loadType == 0)
                                    {
                                        cfilepwd = form.pwd;
                                    }
                                    else
                                    {
                                        ofilepwd = form.pwd;
                                    }
                                }
                                excount++;
                            }
                        }
                    }
                    else
                    {
                        errs = es;
                        isext = 1;
                    }
                }
            }
            if (isext == 2 && flist.Count > 0)
            {
                try
                {
                    using (ZipFile zip = new ZipFile())
                    {
                        for (int i = 0; i < flist.Count; i++)
                        {
                            string fname = flist[i];
                            string apath = AppList.TestDir + fname;
                            zip.AddFile(apath, "");
                        }
                        string sfname = Path.GetFileName(path);
                        string npath = AppList.TestDir + sfname;
                        zip.Save(npath);
                        path = npath;
                    }
                }
                catch (Exception ex)
                {
                    errs = ex.Message;
                }
            }
        }


        private void LoadSteamConfig(string path)
        {
            try
            {
                var zipFile = new ZipFile(path);
                var entity = zipFile.Entries.FirstOrDefault();

                var ms = new System.IO.MemoryStream();
                entity.Extract(ms);
                ms.Seek(0, SeekOrigin.Begin);

                this.DicSteamConfig = new DXVision.Serialization.SharpSerializer().Deserialize(ms) as Dictionary<string, uint>;
                this.HSetIncorrectFile = new HashSet<string>();

                ms.Dispose();
                zipFile.Dispose();


                var folder = System.IO.Path.GetDirectoryName(path);

                this.DtSteamConfig = new DataTable();
                this.DtSteamConfig.Columns.Add("FileName", typeof(string));
                this.DtSteamConfig.Columns.Add("CheckValue", typeof(string));
                this.DtSteamConfig.Columns.Add("ActualValue", typeof(string));
                this.DtSteamConfig.Columns.Add("Result", typeof(string));

                foreach (var i in this.DicSteamConfig)
                {
                    var filepath = System.IO.Path.Combine(folder, i.Key);
                    uint sum = 0;

                    if (System.IO.File.Exists(filepath))
                    {
                        foreach (byte i2 in System.IO.File.ReadAllBytes(filepath))
                        {
                            sum += i2;
                        }
                        this.DtSteamConfig.Rows.Add(
                            i.Key
                            , i.Value
                            , sum
                            , i.Value == sum ? "file match" : "file incorrect");

                        if (i.Key.ToUpper() == "ZXRULDS.DAT")
                        {
                            this.ZXRulesName = i.Key;
                            this.ZXRulesSum = sum;
                            this.ZXRulesIncorrect = i.Value != sum;
                        }
                    }
                    else
                    {
                        this.DtSteamConfig.Rows.Add(
                           i.Key
                           , i.Value
                           , -1
                           , "no found file");
                    }
                    if (i.Value != sum)
                    {
                        this.HSetIncorrectFile.Add(i.Key);
                    }
                }

                if (this.frmSteamConfig != null)
                {
                    this.frmSteamConfig.Dispose();
                }

                this.frmSteamConfig = new Form()
                {
                    Size = new Size() { Width = 800, Height = 600 },
                    Text = "已删除不匹配的文件纪录, 请使用\"" + this.tsDeleteAndSaveSteamConfig.Text + "\"保存, 请注意备份原始文件"
                };

                var dgv = new DataGridView()
                {
                    DataSource = this.DtSteamConfig,
                    RowHeadersVisible = false,
                    Dock = DockStyle.Fill,
                    AllowUserToOrderColumns = false,
                    AllowUserToAddRows = false,
                    AllowUserToDeleteRows = false,
                };

                this.frmSteamConfig.Controls.Add(dgv);
                this.frmSteamConfig.Show();

                dgv.AutoResizeColumns();

                this.tsDeleteAndSaveSteamConfig.Enabled = true;

                if (this.ZXRulesIncorrect)
                {
                    this.tsFixFileAndSaveSteamConfig.Enabled = true;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("读取文件发生错误/r" + ex.Message);
            }

            this.SteamConfigPath = path;
        }

        private void tsDeleteAndSaveSteamConfig_Click(object sender, EventArgs e)
        {
            if (this.DicSteamConfig != null)
            {
                foreach (var i in this.HSetIncorrectFile)
                {
                    this.DicSteamConfig.Remove(i);
                }
                DXVision.Serialization.ZipSerializer.Write(this.SteamConfigPath, this.DicSteamConfig);
                MessageBox.Show("OK");
            }
        }

        private void tsFixFileAndSaveSteamConfig_Click(object sender, EventArgs e)
        {
            if (this.DicSteamConfig != null)
            {
                if (this.ZXRulesSum == 0)
                {
                    MessageBox.Show("SteamConfig.dat中没有ZXRule相关信息, 或者没有在SteamConfig.dat所在目录中发现ZXRules.dat");
                    return;
                }

                this.DicSteamConfig[this.ZXRulesName] = this.ZXRulesSum;
                DXVision.Serialization.ZipSerializer.Write(this.SteamConfigPath, this.DicSteamConfig);
                MessageBox.Show("OK");
            }
        }

        private void Dgv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            var dgv = (DataGridView)sender;
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                CellValueChanged(dgv, e.ColumnIndex, e.RowIndex);
            }
        }

        private void Dgv_CurrentCellChanged(object sender, EventArgs e)
        {
            var dgv = (DataGridView)sender;
            if (dgv.CurrentCell != null
                && dgv.CurrentCell.ColumnIndex >= 0
                && dgv.CurrentCell.RowIndex >= 0
                )
            {
                SetTipText(dgv, dgv.CurrentCell.ColumnIndex, dgv.CurrentCell.RowIndex);
            }
        }

        private void SetTipText(DataGridView dgv, int cindex, int rindex)
        {
            var tableName = ((TabPage)dgv.Parent).ToolTipText;
            if (this.ContainsFocus && DXTableManagerOriginal != null && DXTableManagerOriginal.Tables.ContainsKey(tableName))
            {
                var id = $"{dgv[0, rindex].Value}";
                var value = $"{dgv[cindex, rindex].Value}";
                var cname = dgv.Columns[cindex].Name;
                DXTable dt = DXTableManagerOriginal[tableName];
                if (dt.Rows.ContainsKey(id) && dt.Cols.ContainsKey(cname))
                {
                    int cint = dt.Cols[cname];
                    var oval = $"{dt.Rows[id][cint]}";
                    if (oval == value)
                    {
                    }
                    else
                    {
                        var rect = dgv.GetCellDisplayRectangle(cindex, rindex, true);
                        this.cmsTipText.Tag = dgv[cindex, rindex];
                        this.cmsTipText.Text = oval;
                        this.cmsTip.Show(dgv, rect.GetBottomLeft());
                    }
                }
            }
        }

        private void cmsTipText_Click(object sender, EventArgs e)
        {
            var ctl = (ToolStripMenuItem)sender;
            var cell = (ctl.Tag as DataGridViewCell);
            if (cell != null)
            {
                cell.Value = ctl.Text;
            }
        }

        private void Dgv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.Reset)
            {
                var dgv = (DataGridView)sender;
                var tableName = ((TabPage)dgv.Parent).ToolTipText;

                //ColumnHeader
                foreach (DataGridViewRow r in dgv.Rows)
                {
                    string cname = r.Cells[0].Value.ToString();
                    r.HeaderCell.Value = GetText(cname);
                    r.HeaderCell.ToolTipText = cname;
                    r.Cells[0].ReadOnly = true;
                }

                //Cell
                //if (this.DXTableManagerOriginal != null && this.DXTableManagerOriginal.Tables.ContainsKey(tableName))
                //{
                //    var tbOri = this.DXTableManagerOriginal.Tables[tableName];
                //    var dicColMap = new Dictionary<int, int>();

                //    //Map
                //    for (var f = 1; f < dgv.Columns.Count; f++)
                //    {
                //        var name = dgv.Columns[f].Name;
                //        if (name != "ID" && tbOri.Cols.ContainsKey(name))
                //        {
                //            dicColMap.Add(f, tbOri.Cols[name]);
                //        }
                //    }

                //    //Match
                //    foreach (DataGridViewRow r in dgv.Rows)
                //    {
                //        var id = $"{r.Cells[0].Value}";
                //        if (tbOri.Rows.ContainsKey(id))
                //        {
                //            foreach (var i in dicColMap)
                //            {
                //                string a1 = $"{r.Cells[i.Key].Value}";
                //                string a2 = $"{tbOri.Rows[id][i.Value]}";
                //                if (a1 == a2)
                //                {
                //                    r.Cells[i.Key].Style = App.AppList.CSytleMatch;
                //                }
                //                else
                //                {
                //                    r.Cells[i.Key].Style = App.AppList.CSytleNoMatch;
                //                }
                //            }
                //        }
                //        else
                //        {
                //            for (var f = 1; f < r.Cells.Count; f++)
                //            {
                //                r.Cells[f].Style = App.AppList.CSytleNoFound;
                //            }
                //        }
                //    }
                //}

                if (dgv.Tag == null)
                {
                    dgv.AutoResizeColumns();
                    dgv.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
                    dgv.Tag = "Resized";
                }
            }
        }

        private void CellValueChanged(DataGridView dgv, int cindex, int rindex)
        {
            try
            {
                if (cindex >= 0 && rindex >= 0)
                {
                    var tableName = ((TabPage)dgv.Parent).ToolTipText;
                    var id = $"{dgv[0, rindex].Value}";
                    var value = $"{dgv[cindex, rindex].Value}";
                    var cname = dgv.Columns[cindex].Name;
                    DXTableManagerCurrent[tableName].Rows[id][cindex] = value;
                    bool isStyle = false;
                    if (DXTableManagerOriginal != null && DXTableManagerOriginal.Tables.ContainsKey(tableName))
                    {
                        DXTable dt = DXTableManagerOriginal[tableName];
                        if (dt.Rows.ContainsKey(id) && dt.Cols.ContainsKey(cname))
                        {
                            int cint = dt.Cols[cname];
                            var oval = $"{dt.Rows[id][cint]}";
                            if (oval == value)
                            {
                                dgv[cindex, rindex].Style = App.AppList.CSytleMatch;
                                isStyle = true;
                            }
                            else
                            {
                                dgv[cindex, rindex].Style = App.AppList.CSytleNoMatch;
                                isStyle = true;
                            }
                        }
                    }
                    if(!isStyle)
                    {
                        dgv[cindex, rindex].Style = App.AppList.CSytleNoFound;
                    }
                }
            }
            catch
            {

            }
        }

        private void tsSaveAs_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog();
            sfd.Filter = "Data files(*.dat)|*.dat";
            if (sfd.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            try
            {
                DataSave(sfd.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存失败！错误信息：" + ex.Message);
                return;
            }
            MessageBox.Show("保存成功！");
        }

        private void DataSave(string spath)
        {
            List<string> flist = new List<string>();
            FileSys.DelDir(AppList.TestDir);
            FileSys.NewDir(AppList.TestDir);
            string fpath = AppList.TestDir + Path.GetFileName(spath);
            DXTableManager.ToDatFile(this.DXTableManagerCurrent, fpath);
            string t1dir = AppList.TestDir + "t1\\";
            FileSys.NewDir(t1dir);
            using (ZipFile zip = ZipFile.Read(fpath))
            {
                foreach (ZipEntry entry in zip)
                {
                    string fname = entry.FileName;
                    entry.Extract(t1dir, ExtractExistingFileAction.OverwriteSilently);
                    if (!entry.IsDirectory)
                    {
                        flist.Add(fname);
                    }
                }
            }
            if (flist.Count > 0)
            {
                using (ZipFile zip = new ZipFile())
                {
                    if (cfilepwd != "")
                    {
                        zip.Password = cfilepwd;
                    }
                    for (int i = 0; i < flist.Count; i++)
                    {
                        string fname = flist[i];
                        string apath = t1dir + fname;
                        zip.AddFile(apath, "");
                    }
                    FileSys.DelFile(spath);
                    zip.Save(spath);
                }
            }
        }

        private void tsViewChanged_Click(object sender, EventArgs e)
        {
            if (this.DXTableManagerCurrent == null || this.DXTableManagerOriginal == null)
            {
                return;
            }
            DataTable dtResult = GetTableResult();
            ViewChanged(dtResult);
        }

        private void ViewChanged(DataTable dtResult)
        {
            if (this.frmChanged != null)
            {
                this.frmChanged.Dispose();
            }
            this.frmChanged = new Form()
            {
                Size = new Size() { Width = 900, Height = 400 },
                Text = "共计" + dtResult.Rows.Count + "项记录不同"
            };
            var dgv = new DataGridView()
            {
                DataSource = dtResult,
                RowHeadersVisible = false,
                Dock = DockStyle.Fill,
                AllowUserToOrderColumns = false,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
            };

            dgv.CurrentCellChanged += delegate (object _sender, EventArgs _e)
            {
                if (dgv.CurrentCell != null
                    && dgv.CurrentCell.ColumnIndex >= 0
                    && dgv.CurrentCell.RowIndex >= 0
                    )
                {
                    var tableName = $"{dgv[0, dgv.CurrentCell.RowIndex].Value}";
                    var id = $"{dgv[1, dgv.CurrentCell.RowIndex].Value}";
                    var column = $"{dgv[2, dgv.CurrentCell.RowIndex].Value}";

                    foreach (TabPage tp in this.TC.TabPages)
                    {
                        if (tp.Text == tableName)
                        {
                            this.TC.SelectedTab = tp;
                            var tpdgv = tp.Controls[0] as DataGridView;
                            if (tpdgv != null && tpdgv.Columns[column] != null)
                            {
                                foreach (DataGridViewRow r in tpdgv.Rows)
                                {
                                    if ($"{r.Cells[0].Value}" == id)
                                    {
                                        tpdgv.CurrentCell = tpdgv[column, r.Index];
                                    }
                                }
                            }
                        }
                    }
                }
            };

            this.frmChanged.Controls.Add(dgv);
            this.frmChanged.Show();

            dgv.AutoResizeColumns();
        }

        private DataTable GetTableResult()
        {
            DataTable dtResult = new DataTable();
            //dtResult.Columns.Add("Table", typeof(string));
            //dtResult.Columns.Add("ID", typeof(string));
            //dtResult.Columns.Add("Column", typeof(string));
            //dtResult.Columns.Add("Original", typeof(string));
            //dtResult.Columns.Add("Current", typeof(string));

            dtResult.Columns.Add("表名", typeof(string));
            dtResult.Columns.Add("项目", typeof(string));
            dtResult.Columns.Add("列名", typeof(string));
            dtResult.Columns.Add("原始数据", typeof(string));
            dtResult.Columns.Add("当前数据", typeof(string));

            foreach (var i in this.DXTableManagerCurrent.Tables)
            {
                var tableName = i.Key;

                if (!this.DXTableManagerOriginal.Tables.ContainsKey(tableName))
                {
                    continue;
                }

                var tbCur = this.DXTableManagerCurrent.Tables[tableName];
                var tbOri = this.DXTableManagerOriginal.Tables[tableName];

                var dicColMap = new Dictionary<int, int>();

                //Map
                foreach (var i2 in tbCur.Cols)
                {
                    var name = i2.Key;
                    if (name != "ID" && tbOri.Cols.ContainsKey(name))
                    {
                        dicColMap.Add(i2.Value, tbOri.Cols[name]);
                    }
                }

                //Match
                foreach (var i2 in tbCur.Rows)
                {
                    var id = i2.Key;
                    if (tbOri.Rows.ContainsKey(id))
                    {
                        foreach (var i3 in dicColMap)
                        {
                            try
                            {
                                var v1 = tbCur.Rows[id][i3.Key] + "";
                                var v2 = tbOri.Rows[id][i3.Value] + "";
                                if (v1 == v2)
                                {

                                }
                                else
                                {
                                    string tname = GetText(tableName) + "  ";
                                    string idname = GetText(id) + "  ";
                                    string cname = GetText(tbCur.Cols.Keys.ElementAt(i3.Key)) + "  ";
                                    string oval = tbOri.Rows[id][i3.Value] + "";
                                    string cval = tbCur.Rows[id][i3.Key] + "";
                                    dtResult.Rows.Add(tname, idname, cname, oval, cval);
                                }
                            }
                            catch
                            {
                            }
                        }
                    }
                    else
                    {
                        //dtResult.Rows.Add(tableName, id, "No found id");
                        dtResult.Rows.Add(tableName, id, "没有此项");
                    }
                }
            }
            return dtResult;
        }

        private Dictionary<string, string> _dic = null;

        public Dictionary<string, string> dic
        {
            get
            {
                if (_dic == null)
                {
                    _dic = new Dictionary<string, string>();
                    _dic.Add("Advances", "进展");
                    _dic.Add("ID", "");
                    _dic.Add("Name", "名称");
                    _dic.Add("Order", "");
                    _dic.Add("Cost", "成本");
                    _dic.Add("IDParent", "父实体");
                    _dic.Add("IDEntities", "实体");
                    _dic.Add("IdRequisites", "必要条件");
                    _dic.Add("Quarry", "采石场");
                    _dic.Add("SoldiersCenter", "兵营");
                    _dic.Add("Soldier", "士兵");
                    _dic.Add("WoodWorkshop", "木材作坊");
                    _dic.Add("CottageHouse", "木屋");
                    _dic.Add("LookoutTower", "瞭望塔");
                    _dic.Add("Sniper", "狙击手");
                    _dic.Add("Farm", "农场");
                    _dic.Add("StoneWorkshop", "石材作坊");
                    _dic.Add("WareHouse", "仓库");
                    _dic.Add("Market", "市场");
                    _dic.Add("Bank", "银行");
                    _dic.Add("PowerPlant", "发电厂");
                    _dic.Add("StoneHouse", "石屋");
                    _dic.Add("Foundry", "钢铁铸造厂");
                    _dic.Add("WallStone", "石墙");
                    _dic.Add("WatchTowerStone", "石质哨塔");
                    _dic.Add("RadarTower", "雷达");
                    _dic.Add("MillIron", "先进能源工坊");
                    _dic.Add("OilPlatform", "采油平台");
                    _dic.Add("AdvancedUnitCenter", "工程研究中心");
                    _dic.Add("Lucifer", "坠天使");
                    _dic.Add("Thanatos", "死神");
                    _dic.Add("AdvancedQuarry", "高级采石场");
                    _dic.Add("AdvancedFarm", "高级农场");
                    _dic.Add("Titan", "泰坦");
                    _dic.Add("Campaigns", "战役");
                    _dic.Add("IDInitialMission", "初始任务");
                    _dic.Add("IDEndMission", "结束任务");
                    _dic.Add("IDEntitiesAvailable", "可用实体");
                    _dic.Add("IDClipWorldMap", "简洁的世界地图");
                    _dic.Add("Reconquest", "征服");
                    _dic.Add("Commands", "控制");
                    _dic.Add("Key", "键");
                    _dic.Add("ShowAsCommand", "显示命令");
                    _dic.Add("Category", "分类");
                    _dic.Add("PanelPosition", "菜单位置");
                    _dic.Add("CommandRequisite", "命令需求");
                    _dic.Add("BuildingRequisite", "建筑需求");
                    _dic.Add("AvailableFor", "可用");
                    _dic.Add("BuildingTimeFactor", "建造时间");
                    _dic.Add("OnlyOneExecution", "仅可执行一次");
                    _dic.Add("Activity", "激活");
                    _dic.Add("Infected", "被感染");
                    _dic.Add("UsabeThroughWalls", "可穿墙");
                    _dic.Add("HasShotEffect", "有射击效果");
                    _dic.Add("BurnFactor", "燃烧因子");
                    _dic.Add("WoodCost", "木材消耗");
                    _dic.Add("StoneCost", "石材消耗");
                    _dic.Add("IronCost", "钢铁消耗");
                    _dic.Add("OilCost", "石油消耗");
                    _dic.Add("GoldCost", "金钱消耗");
                    _dic.Add("ActionRange", "动作范围");
                    _dic.Add("DamageType", "伤害类型");
                    _dic.Add("Damage", "伤害");
                    _dic.Add("AniLoad", "动画读取");
                    _dic.Add("TimeLoad", "加载时间");
                    _dic.Add("AniAction", "动画执行");
                    _dic.Add("AniActionReverse", "动画恢复时间");
                    _dic.Add("TimeAction", "行动时间");
                    _dic.Add("TimePreAction", "行动前摇时间");
                    _dic.Add("TimePostAction", "行动后摇时间");
                    _dic.Add("TimeLoopAction", "行动周期时间");
                    _dic.Add("AniUnload", "动画卸载");
                    _dic.Add("TimeUnload", "行动取消时间");
                    _dic.Add("UnLoadReverse", "卸载反向");
                    _dic.Add("TimeFactorAction", "行动时间因子");
                    _dic.Add("AttackAreaType", "攻击区域类型");
                    _dic.Add("MinTargetDistance", "最小攻击距离");
                    _dic.Add("EffectRadius", "效果范围");
                    _dic.Add("MinFactorDamageInArea", "区域内最小因素伤害");
                    _dic.Add("FriendlyDamage", "友军伤害");
                    _dic.Add("ProyectileType", "子弹类型");
                    _dic.Add("ProyectileSpeed", "子弹速度");
                    _dic.Add("AnimationTargetEffect", "目标动画效果");
                    _dic.Add("AnimationProyectileEffect", "子弹动画效果");
                    _dic.Add("FactorPush", "击退系数");
                    _dic.Add("SoundOnExecute", "是否播放声音");
                    _dic.Add("SoundOnPerformEffect", "声音播放效果");
                    _dic.Add("SoundOnTargetEffect", "击中目标时声音播放效果");
                    _dic.Add("TechWatchTowerWood", "木制哨塔技术");
                    _dic.Add("TechLookoutTower", "瞭望塔技术");
                    _dic.Add("TechTrapStakes", "铁丝网陷阱技术");
                    _dic.Add("TechWoodHouse", "木屋技术");
                    _dic.Add("TechFarms", "农场技术");
                    _dic.Add("TechMarket", "市场技术");
                    _dic.Add("TechStoneWorkshop", "石材作坊技术");
                    _dic.Add("TechSniper", "狙击手技术");
                    _dic.Add("TechBallista", "大型弩车技术");
                    _dic.Add("TechStoneHouse", "石屋技术");
                    _dic.Add("TechWatchTowerStone", "石质哨塔");
                    _dic.Add("TechStoneWall", "石墙技术");
                    _dic.Add("TechPowerPlant", "发电厂技术");
                    _dic.Add("TechFoundry", "钢铁铸造厂");
                    _dic.Add("TechBank", "银行技术");
                    _dic.Add("TechShockingTower", "震荡波塔技术");
                    _dic.Add("TechTrapBlades", "铁丝网陷阱技术");
                    _dic.Add("TechAdvancedQuarry", "高级采石场技术");
                    _dic.Add("TechIronMill", "先进能源工坊");
                    _dic.Add("TechOilPlatform", "采油平台技术");
                    _dic.Add("TechRadarTower", "雷达技术");
                    _dic.Add("TechAdvancedUnitCenter", "工程研究中心技术");
                    _dic.Add("TechAdvancedFarm", "高级农场技术");
                    _dic.Add("TechExecutor", "机枪塔技术");
                    _dic.Add("TechThanatos", "死神技术");
                    _dic.Add("TechTitan", "泰坦技术");
                    _dic.Add("TechTheInn", "酒馆技术");
                    _dic.Add("TechWareHouse", "仓库技术");
                    _dic.Add("TechBunkerHouse", "燃料库");
                    _dic.Add("TechTrapMine", "地雷技术");
                    _dic.Add("TechShuttle", "飞弹技术");
                    _dic.Add("TechRefinery", "精炼厂技术");

                    _dic.Add("TechTheGreatTelescope", "间谍卫星技术");
                    _dic.Add("TechTheVictorius", "凯旋胜利塔技术");
                    _dic.Add("TechTheSoldierAcademy", "战士学院技术");
                    _dic.Add("TechTheElectricSpire", "超级特斯拉塔技术");
                    _dic.Add("TechTheTransmutator", "石油精炼厂技术");

                    _dic.Add("TechUnavailable", "不可用的技术");
                    _dic.Add("ExecutorAttack", "机枪塔攻击");
                    _dic.Add("ShockingTowerAttack", "震荡波塔攻击");
                    _dic.Add("BallistaAttack", "大型弩车攻击");
                    _dic.Add("RangerAttack", "游侠攻击");
                    _dic.Add("RangerAttackVeteran", "有经验的游侠攻击");
                    _dic.Add("SoldierRegularAttack", "士兵攻击规则");
                    _dic.Add("SoldierRegularAttackVeteran", "有经验的士兵攻击规则");
                    _dic.Add("SniperAttack", "狙击手攻击");
                    _dic.Add("SniperAttackVeteran", "有经验的狙击手攻击");
                    _dic.Add("ThanatosAttack", "死神攻击");
                    _dic.Add("ThanatosExtraAttack", "死神特出攻击");
                    _dic.Add("LuciferAttack", "坠天使攻击");
                    _dic.Add("TitanAttack", "泰坦攻击");
                    _dic.Add("ZombieWeakAttack", "老迈感染者攻击");
                    _dic.Add("ZombieWeakAAttack", "老迈感染者A攻击");
                    _dic.Add("ZombieWeakBAttack", "老迈感染者B攻击");
                    _dic.Add("ZombieWeakCAttack", "老迈感染者C攻击");
                    _dic.Add("ZombieWorkerAAttack", "被感染的居民A攻击");
                    _dic.Add("ZombieWorkerBAttack", "被感染的居民B攻击");
                    _dic.Add("ZombieMediumAAttack", "新鲜感染者A攻击");
                    _dic.Add("ZombieMediumBAttack", "新鲜感染者A攻击");
                    _dic.Add("ZombieDressedAAttack", "感染者主管攻击");
                    _dic.Add("ZombieStrongAAttack", "肿胀感染者攻击");
                    _dic.Add("ZombieHarpyAttack", "鹰身女妖攻击");
                    _dic.Add("ZombieGiantAttack", "感染者巨人攻击");
                    _dic.Add("ZombieVenomAttack", "毒液感染者攻击");
                    _dic.Add("ZombieLeaderAttack", "感染者精英攻击");
                    _dic.Add("Entities", "实体");
                    _dic.Add("Nature", "自然");
                    _dic.Add("Level", "等级");
                    _dic.Add("Power", "能源");
                    _dic.Add("UpgradeTo", "升级至");
                    _dic.Add("ExperienceNeededToVeteran", "升级到老兵所需经验");
                    _dic.Add("Life", "生命");
                    _dic.Add("Armor", "护甲");
                    _dic.Add("DeffensesLife", "防御壁垒");
                    _dic.Add("LifeRegenFactor", "生命恢复");
                    _dic.Add("WatchRange", "观察视野");
                    _dic.Add("EntityWatchInterval", "观察间隔");
                    _dic.Add("WatchThroughOpaque", "透视");
                    _dic.Add("WalkSpeed", "步行速度");
                    _dic.Add("RunSpeed", "奔跑速度");
                    _dic.Add("Mass", "大量");
                    _dic.Add("Height", "高度");
                    _dic.Add("ActivityAwarenessFactor", "活动感知等级");
                    _dic.Add("FactorResourcesReturn", "回收成本系数");
                    _dic.Add("BuildingFrom", "建筑来源");
                    _dic.Add("BuildingTarget", "建造要求");
                    _dic.Add("BuildingMargin", "建造间隔");
                    _dic.Add("SameBuildingMargin", "同类建筑间隔");
                    _dic.Add("IgnoreBuildingsMargin", "忽略建造间隔");
                    _dic.Add("MaxBuildingsAdjacent", "最大建筑相邻数");
                    _dic.Add("MinEmptyCellsAdjacent", "最小空地块间隔数");
                    _dic.Add("CanBeDestroyed", "可破坏");
                    _dic.Add("CanBeRepaired", "可修复");
                    _dic.Add("CanBeDisabled", "可停产");
                    _dic.Add("MaxUnitsInside", "最大单位容纳量");
                    _dic.Add("RangeBonus", "视野扩展");
                    _dic.Add("MaxInstances", "最大容量");
                    _dic.Add("MinColonistsRequisite", "最小居民需求");
                    _dic.Add("CanQueueCommands", "可以实现命令队列");
                    _dic.Add("CanBeBuiltOnWalls", "可在围墙上建造");
                    _dic.Add("ColonistType", "居民种类");
                    _dic.Add("ColonistUnitNumber", "每单元居民数量");
                    _dic.Add("ColonistNumber", "居民数量");
                    _dic.Add("EnergyTransferRadius", "能源供应范围");
                    _dic.Add("ResourcesStorage", "资源储备");
                    _dic.Add("FireDamageFactor", "火焰伤害因子");
                    _dic.Add("InflamableTime", "熄灭时间");
                    _dic.Add("BurningTime", "燃烧时间");
                    _dic.Add("VenomDamageFactor", "毒液伤害系数");
                    _dic.Add("Infectable", "可传染");
                    _dic.Add("ConvertibleInZombie", "可变为僵尸");
                    _dic.Add("VibrateWhenDamaged", "受到伤害时震动");
                    _dic.Add("ExplosionOnDestroy", "被破坏时爆炸");
                    _dic.Add("WorkersNeeded", "所需工人");
                    _dic.Add("FoodNeeded", "所需食物");
                    _dic.Add("EnergyNeeded", "所需能量");
                    _dic.Add("Colonists", "聚居地居民");
                    _dic.Add("WorkersSupply", "工人产出");
                    _dic.Add("FoodSupply", "食物产出");
                    _dic.Add("EnergySupply", "能量产出");
                    _dic.Add("WoodGen", "木材产出");
                    _dic.Add("StoneGen", "石材产出");
                    _dic.Add("IronGen", "钢铁产出");
                    _dic.Add("OilGen", "石油产出");
                    _dic.Add("GoldGen", "金钱收入");
                    _dic.Add("GoldGenPerColonist", "单个居民税金");
                    _dic.Add("ConvertResourcesIntoGold", "资源转成金钱");
                    _dic.Add("ResourcesGenerationTimeFactor", "资源生成时间因子");
                    _dic.Add("ResourceCollectionType", "资源收集种类");
                    _dic.Add("ResourceCollectionRadius", "资源收集半径");
                    _dic.Add("ResourceCollectionCellValue", "资源生成");
                    _dic.Add("Averageunitsperturnestimated", "每回合预估平均单位数");
                    _dic.Add("AffectedByEnhancerBuildings", "被增益建筑影响");
                    _dic.Add("FactorProductionNearBuildings", "资源产出要素靠近建筑");
                    _dic.Add("FactorGoldNearBuildings", "金钱产出要素靠近建筑");
                    _dic.Add("FactorFoodNeedNearBuildings", "食物需求要素靠近建筑");
                    _dic.Add("CanEnterInBuildings", "可进入建筑");

                    _dic.Add("ScorePoints", "得分");
                    _dic.Add("ExtraUnitsWhenInfected", "额外感染单位");
                    _dic.Add("MakeSoldiersVeteran", "升级成老兵");
                    _dic.Add("ShowFullMap", "显示全部地图");

                    _dic.Add("CanTravel", "可移动");
                    _dic.Add("CanStop", "可停止");
                    _dic.Add("CanHold", "可站岗");
                    _dic.Add("CanPatrol", "可巡逻");
                    _dic.Add("CanChase", "可歼敌");
                    _dic.Add("CanJump", "可跳跃");
                    _dic.Add("CanBeCarried", "可被携带");
                    _dic.Add("CanCarryObjects", "可携带物品");
                    _dic.Add("TimeAniNormal", "动画时间 普通");
                    _dic.Add("TimeAniSpecial", "动画时间 特殊");
                    _dic.Add("TimeAniWalk", "动画时间 行走");
                    _dic.Add("TimeAniRun", "动画时间 跑动");
                    _dic.Add("TimeAniDie", "动画时间 死亡");
                    _dic.Add("TimeAniWork", "动画时间 工作");
                    _dic.Add("TimeAniPrepareWork", "动画时间 工作");
                    _dic.Add("TimeAniFly", "动画时间 飞行");
                    _dic.Add("TimeAniPrepareFly", "动画时间 飞行");
                    _dic.Add("ReverseAniNormal", "动画时间 返回正常");
                    _dic.Add("ReverseAniSpecial", "动画时间 返回特殊");
                    _dic.Add("TimeAniJump", "动画时间 跳跃");
                    _dic.Add("AttackCommand", "攻击指令");
                    _dic.Add("ExtraAttackCommand", "额外攻击指令");
                    _dic.Add("BellWalkingFactor", "警戒时间行走系数");
                    _dic.Add("BellRunningFactor", "警戒时间跑动系数");
                    _dic.Add("Behaviour", "行为类型");
                    _dic.Add("CanAvoidOverkill", "可避免过度杀伤");
                    _dic.Add("DisableDiagonalBuilding", "禁用斜角建筑");
                    _dic.Add("EndGameIfInfected", "被感染时游戏结束");
                    _dic.Add("EndGameIfDestroyed", "被毁坏时游戏结束");
                    _dic.Add("InfectionNestSize", "感染者巢穴尺寸");
                    _dic.Add("InfectionNestMaxUnits", "感染者巢穴最多单位数");
                    _dic.Add("TerrainSpeedPercentage", "地形速度百分比");

                    _dic.Add("GoldPerKill", "杀死获得金钱");
                    _dic.Add("EmpirePointsCost", "雇佣成本");

                    _dic.Add("SoundOnDestroy", "毁坏时是否有声音");
                    _dic.Add("SoundOnCreation", "创建时是否有声音");
                    _dic.Add("SoundOnDie", "死亡时是否有声音");
                    _dic.Add("SoundOnSelected", "选中时是否有声音");
                    _dic.Add("SoundOnCommandGeneric", "一般命令是否有声音");
                    _dic.Add("SoundOnCommandAttack", "攻击命令是否有声音");
                    _dic.Add("SoundOnInfection", "被感染时是否有声音");
                    _dic.Add("SoundOnDesertion", "被抛弃时是否有声音");
                    _dic.Add("CommandCenter", "指挥中心");
                    _dic.Add("TentHouse", "营帐");
                    _dic.Add("FishermanCottage", "捕鱼小屋");
                    _dic.Add("HunterCottage", "猎人小屋");
                    _dic.Add("Sawmill", "锯木厂");
                    _dic.Add("EnergyWoodTower", "特斯拉塔");
                    _dic.Add("MillWood", "能源工坊");
                    _dic.Add("WallWood", "木墙");
                    _dic.Add("GateWood", "木门");
                    _dic.Add("WatchTowerWood", "木制哨塔");
                    _dic.Add("Ballista", "大型弩车");
                    _dic.Add("GateStone", "石门");
                    _dic.Add("ShockingTower", "震荡波塔");
                    _dic.Add("Executor", "机枪塔");
                    _dic.Add("Refinery", "精炼厂");
                    _dic.Add("BunkerHouse", "燃料库");
                    _dic.Add("Shuttle", "飞弹");
                    _dic.Add("TheInn", "酒馆");
                    _dic.Add("TrapPetrol", "汽油陷阱");
                    _dic.Add("TrapStakes", "木制陷阱");
                    _dic.Add("TrapBlades", "铁丝网陷阱");
                    _dic.Add("TrapMine", "地雷");
                    _dic.Add("PickableWood", "木材宝箱");
                    _dic.Add("PickableStone", "石材宝箱");
                    _dic.Add("PickableIron", "钢铁宝箱");
                    _dic.Add("PickableOil", "石油宝箱");
                    _dic.Add("PickableGold", "金钱宝箱");
                    _dic.Add("ExplosiveBarrel", "爆炸桶");

                    _dic.Add("TheGreatTelescope", "间谍卫星");
                    _dic.Add("TheVictorious", "凯旋胜利塔");
                    _dic.Add("TheSoldierAcademy", "战士学院");
                    _dic.Add("TheElectricSpire", "超级特斯拉塔");
                    _dic.Add("TheTransmutator", "石油精炼厂");

                    _dic.Add("TheSpire", "超级特斯拉塔");
                    _dic.Add("TheAcademy", "战士学院");

                    _dic.Add("DoomBuildingSmall", "厄运小屋");
                    _dic.Add("DoomBuildingMedium", "毁灭酒馆");
                    _dic.Add("DoomBuildingLarge", "末日市政厅");
                    _dic.Add("Worker_A", "工人_A");
                    _dic.Add("Worker_B", "工人_A");
                    _dic.Add("WorkerRunner_A", "工作的工人_A");
                    _dic.Add("WorkerRunner_B", "工作的工人_B");
                    _dic.Add("Raven", "乌鸦");
                    _dic.Add("Ranger", "游侠");
                    _dic.Add("SoldierRegular", "士兵");
                    _dic.Add("ZombieWeakA", "老迈感染者A");
                    _dic.Add("ZombieWeakB", "老迈感染者B");
                    _dic.Add("ZombieWeakC", "老迈感染者C");
                    _dic.Add("ZombieWorkerA", "被感染的居民A");
                    _dic.Add("ZombieWorkerB", "被感染的居民B");
                    _dic.Add("ZombieMediumA", "新鲜感染者A");
                    _dic.Add("ZombieMediumB", "新鲜感染者B");
                    _dic.Add("ZombieDressedA", "感染者主管");
                    _dic.Add("ZombieStrongA", "肿胀感染者");
                    _dic.Add("ZombieGiant", "感染者巨人");
                    _dic.Add("ZombieHarpy", "鹰身女妖");
                    _dic.Add("ZombieVenom", "毒液感染者");
                    _dic.Add("ZombieLeader", "感染者精英");
                    _dic.Add("Global", "全局");
                    _dic.Add("Type", "类型");
                    _dic.Add("BaseValue", "基础值");
                    _dic.Add("Easy", "简单");
                    _dic.Add("Normal", "普通");
                    _dic.Add("Hard", "困难");
                    _dic.Add("Description", "描述");
                    _dic.Add("GlobalTimeFactor", "全局时间系数");
                    _dic.Add("DefaultTimeForGeneratingResources", "默认资源产出时间");
                    _dic.Add("DefaultTimeForResearchingTechs", "默认技术研究时间");
                    _dic.Add("DefaultTimeTrainingUnit", "默认部队训练时间");
                    _dic.Add("DefaultTimeForBuilding", "默认建筑建造时间");
                    _dic.Add("DefaultGoldOnGameStart", "默认游戏开始金钱");
                    _dic.Add("DefaultWoodOnGameStart", "默认游戏开始木材");
                    _dic.Add("DefaultStoneOnGameStart", "默认游戏开始石材");
                    _dic.Add("DefaultIronOnGameStart", "默认游戏开始钢铁");
                    _dic.Add("DefaultOilOnGameStart", "默认游戏开始石油");
                    _dic.Add("GoldGenereatedByCell", "默认金矿数量");
                    _dic.Add("GoldStorageFactor", "金矿储量系数");
                    _dic.Add("TimeForLifeRegeneration", "生命恢复时间");
                    _dic.Add("MinTimeIdleForLifeRegeneration", "生命恢复前空闲时间");
                    _dic.Add("DesertionMinTurnsNoGold", "金钱数小于最小值后出现逃兵");
                    _dic.Add("FactorPenaltyCostUnitWhenNotFood", "没有食物时单位额外消耗系数");
                    _dic.Add("RadiusAlertWhenZombieAttacked", "当僵尸攻击时警报范围");
                    _dic.Add("DefaultFireDurationForOilStains", "默认油污燃烧持续时间");
                    _dic.Add("DefaultFireDamage", "默认燃烧时间");
                    _dic.Add("BuildingInitialLifeFactor", "开始建造建筑的生命值系数");
                    _dic.Add("MinRadiusFreeForEnemiesToEnableBuilding", "能修理建筑距离敌人最小半径");
                    _dic.Add("DesinfectionGoldFactor", "消毒成本系数");
                    _dic.Add("DefaultBuildingDeffenseFactor", "建筑默认防御系数");
                    _dic.Add("MaxCommandsQueue", "最大命令队列");

                    _dic.Add("NDaysInnNewMercenariesInterval", "雇佣兵到达时间间隔");

                    _dic.Add("PriceResourceBase", "资源基本价格");
                    _dic.Add("PriceSellFactorBase", "资源卖出价格基本系数");
                    _dic.Add("PriceBuyFactorBase", "资源买入价格基本系数");
                    _dic.Add("PriceSellFactorPerMarket", "市场卖出价格基本系数");
                    _dic.Add("PriceBuyFactorPerMarket", "市场买入价格基本系数");
                    _dic.Add("WoodGoldFactor", "木材转换为金钱系数");
                    _dic.Add("StoneGoldFactor", "石材材转换为金钱系数");
                    _dic.Add("IronGoldFactor", "钢铁转换为金钱系数");
                    _dic.Add("OilGoldFactor", "石油转换为金钱系数");
                    _dic.Add("DefaultNFramesToActivateTraps", "默认陷阱激活部位");
                    _dic.Add("TrapStakesDamage", "木制陷阱伤害");
                    _dic.Add("TrapStakesOwnDamage", "木制陷阱特有伤害");
                    _dic.Add("TrapBladesDamage", "铁丝网陷阱伤害");
                    _dic.Add("TrapBladesOwnDamage", "铁丝网陷阱特有伤害");
                    _dic.Add("TrapMineDamage", "地雷伤害");
                    _dic.Add("TrapMineRadius", "地雷伤害范围");
                    _dic.Add("ExplosiveBarrelDamage", "爆炸桶伤害");
                    _dic.Add("ExplosiveBarrelRadius", "爆炸桶伤害范围");
                    _dic.Add("Activity_MaxFactorWatchRange", "最大活动观察范围系数");
                    _dic.Add("Activity_FactorDetection", "活动感知系数");
                    _dic.Add("Activity_NFramesToDetectActivity", "活动感知部位");
                    _dic.Add("Activity_NFramesToVanishActivity", "活动感知消失部位");
                    _dic.Add("ActivityPerColonistOnInfection", "被感染的居民活动感知");
                    _dic.Add("InfectedNest_MinTimeForGeneratingZombies", "被感染巢穴产生僵尸的最小时间");
                    _dic.Add("InfectedNest_MinTimeToAttackCommandCenter", "被感染巢穴进攻指挥中心的最小时间");
                    _dic.Add("InfectedNest_TimeIdleToAttackCommandCenter", "被感染巢穴进攻指挥中心的闲置时间");
                    _dic.Add("InfectedNest_TimeToCheckInfectedAround", "被感染巢穴感知被感染者时间");
                    _dic.Add("SurvivalAutoBackupTime", "生存模式自动保存存档时间");
                    _dic.Add("MayorColonistsForLevel1", "等级1的市长");
                    _dic.Add("MayorColonistsForLevel2", "等级2的市长");
                    _dic.Add("MayorColonistsForLevel3", "等级3的市长");
                    _dic.Add("MayorColonistsForLevel4", "等级4的市长");
                    _dic.Add("LevelEvents", "等级事件");
                    _dic.Add("LevelName", "等级名称");
                    _dic.Add("GameTime", "游戏时间");
                    _dic.Add("GameTimeRandomOffset", "游戏时间随机偏移数");
                    _dic.Add("RepeatTime", "重复时间");
                    _dic.Add("MaxRepetitions", "最大重复次数");
                    _dic.Add("FactorUnitsNumberPerRepetition", "部队重复系数");
                    _dic.Add("MaxFactorUnitsNumberPerRepetition", "部队最大重复系数");
                    _dic.Add("AutoNotifyPlayer", "自动通知玩家");
                    _dic.Add("TimeToNotifyInAdvance", "提前通知时间");
                    _dic.Add("ShowCountdown", "显示倒计时");
                    _dic.Add("ShowMiniMapIndicator", "显示到迷你地图");
                    _dic.Add("AllInfectedToCommandCenter", "所有感染者聚集到指挥中心");
                    _dic.Add("GameWon", "游戏获胜");
                    _dic.Add("GameOver", "游戏结束");
                    _dic.Add("Generators", "发电机");
                    _dic.Add("AttackCommandCenter", "攻击指挥中心");
                    _dic.Add("EntityType1", "实体类型1");
                    _dic.Add("EntityType2", "实体类型2");
                    _dic.Add("EntityType3", "实体类型3");
                    _dic.Add("EntityType4", "实体类型4");
                    _dic.Add("EntityType5", "实体类型5");
                    _dic.Add("MapThemes", "地图配置");
                    _dic.Add("DefaultLocked", "是否默认锁定");
                    _dic.Add("ThemeRequisiteToUnlock", "解锁的主题");
                    _dic.Add("MinScoreFactorToUnlock", "解锁最小得分系数");
                    _dic.Add("PW", "");
                    _dic.Add("EarthFoodFactor", "地表的食物系数");
                    _dic.Add("GassFoodFactor", "有毒的食物系数");
                    _dic.Add("TreesFoodFactor", "树林的食物系数");
                    _dic.Add("NumDoomVillages", "毁灭村庄的数量");
                    _dic.Add("NumTreasures", "宝箱数量");
                    _dic.Add("NumRavens", "乌鸦数量");
                    _dic.Add("NumRadarTowers", "雷达数量");
                    _dic.Add("ScoreFactor", "得分系数");
                    _dic.Add("NumOldTowers", "旧塔的数量");
                    _dic.Add("MinDistanceForWeakInfected", "距离虚弱感染者最小距离");
                    _dic.Add("MinDistanceForMediumInfected", "距离普通感染者最小距离");
                    _dic.Add("MinDistanceForStrongInfected", "距离高级感染者最小距离");
                    _dic.Add("MinDistanceForPowerfulInfected", "距离BOSS级感染者最小距离");
                    _dic.Add("InfectedFactor", "感染系数");
                    _dic.Add("InfectedDispersion", "感染散布");
                    _dic.Add("Mods", "Mod效果");
                    _dic.Add("LandWaterFactor", "河流分布系数");
                    _dic.Add("LandDispersionFactor", "陆地散布系数");
                    _dic.Add("LandOctaves", "陆地分支系数");
                    _dic.Add("VegetationDispersionFactor", "植被散布系数");
                    _dic.Add("VegetationOctaves", "植被覆盖系数");
                    _dic.Add("MountainLandFactor", "山地分布系数");
                    _dic.Add("GrassEarthFactor", "草地分布系数");
                    _dic.Add("ForestGrassFactor", "森林覆盖系数");
                    _dic.Add("ForestEarthFactor", "树林覆盖系数");
                    _dic.Add("NCellsPerOilSource", "石油资源数量");
                    _dic.Add("StoneEarthFactor", "石材分布系数");
                    _dic.Add("IronEarthFactor", "铁矿分布系数");
                    _dic.Add("GoldEarthFactor", "金钱分布系数");
                    _dic.Add("BR", "");
                    _dic.Add("TM", "");
                    _dic.Add("AL", "");
                    _dic.Add("DS", "");
                    _dic.Add("Mayors", "市长");
                    _dic.Add("Gender", "性别");
                    _dic.Add("ExtraGold", "金钱奖励");
                    _dic.Add("ExtraWood", "木材奖励");
                    _dic.Add("ExtraStone", "石材奖励");
                    _dic.Add("ExtraIron", "钢铁奖励");
                    _dic.Add("ExtraOil", "石油奖励");
                    _dic.Add("IDBonusTechnologies", "技术奖励");
                    _dic.Add("IDBonusEntities", "单位或建筑奖励");
                    _dic.Add("Mayor_001", "市长_001");
                    _dic.Add("Mayor_002", "市长_002");
                    _dic.Add("Mayor_003", "市长_003");
                    _dic.Add("Mayor_004", "市长_004");
                    _dic.Add("Mayor_005", "市长_005");
                    _dic.Add("Mayor_006", "市长_006");
                    _dic.Add("Mayor_007", "市长_007");
                    _dic.Add("Mayor_008", "市长_008");
                    _dic.Add("Mayor_009", "市长_009");
                    _dic.Add("Mayor_010", "市长_010");
                    _dic.Add("Mayor_011", "市长_011");
                    _dic.Add("Mayor_012", "市长_012");
                    _dic.Add("Mayor_013", "市长_013");
                    _dic.Add("Mayor_014", "市长_014");
                    _dic.Add("Mayor_015", "市长_015");
                    _dic.Add("Mayor_016", "市长_016");
                    _dic.Add("Mayor_017", "市长_017");
                    _dic.Add("Mayor_018", "市长_018");
                    _dic.Add("Mayor_019", "市长_019");
                    _dic.Add("Mayor_020", "市长_020");
                    _dic.Add("Mayor_021", "市长_021");
                    _dic.Add("Mayor_022", "市长_022");
                    _dic.Add("Mayor_023", "市长_023");
                    _dic.Add("Mayor_024", "市长_024");
                    _dic.Add("Mayor_025", "市长_025");
                    _dic.Add("Mayor_026", "市长_026");
                    _dic.Add("Mayor_027", "市长_027");
                    _dic.Add("Mayor_028", "市长_028");
                    _dic.Add("Mayor_029", "市长_029");
                    _dic.Add("Mayor_030", "市长_030");
                    _dic.Add("Mayor_031", "市长_031");
                    _dic.Add("Mayor_032", "市长_032");
                    _dic.Add("Mayor_033", "市长_033");
                    _dic.Add("Mayor_034", "市长_034");
                    _dic.Add("Mayor_200", "市长_200");
                    _dic.Add("Mayor_201", "市长_201");
                    _dic.Add("Mayor_202", "市长_202");
                    _dic.Add("Mayor_203", "市长_203");
                    _dic.Add("Mayor_204", "市长_204");
                    _dic.Add("Mayor_205", "市长_205");
                    _dic.Add("Mayor_206", "市长_206");
                    _dic.Add("Mayor_207", "市长_207");
                    _dic.Add("Mayor_208", "市长_208");
                    _dic.Add("Mayor_209", "市长_209");
                    _dic.Add("Mayor_210", "市长_210");
                    _dic.Add("Mayor_211", "市长_211");
                    _dic.Add("Mayor_212", "市长_212");
                    _dic.Add("Mayor_213", "市长_213");
                    _dic.Add("Mayor_214", "市长_214");
                    _dic.Add("Mayor_215", "市长_215");
                    _dic.Add("Mayor_216", "市长_216");
                    _dic.Add("Mayor_217", "市长_217");
                    _dic.Add("Mayor_218", "市长_218");
                    _dic.Add("Mayor_219", "市长_219");
                    _dic.Add("Mayor_220", "市长_220");
                    _dic.Add("Mayor_221", "市长_221");
                    _dic.Add("Mayor_300", "市长_300");
                    _dic.Add("Mayor_301", "市长_301");
                    _dic.Add("Mayor_302", "市长_302");
                    _dic.Add("Mayor_303", "市长_303");
                    _dic.Add("Mayor_304", "市长_304");
                    _dic.Add("Mayor_305", "市长_305");
                    _dic.Add("Mayor_306", "市长_306");
                    _dic.Add("Mayor_307", "市长_307");
                    _dic.Add("Mayor_308", "市长_308");
                    _dic.Add("Mayor_309", "市长_309");
                    _dic.Add("Mayor_310", "市长_310");
                    _dic.Add("Mayor_311", "市长_311");
                    _dic.Add("Mayor_312", "市长_312");
                    _dic.Add("Mayor_313", "市长_313");
                    _dic.Add("Mayor_314", "市长_314");
                    _dic.Add("Mayor_315", "市长_315");
                    _dic.Add("Mayor_316", "市长_316");
                    _dic.Add("Mayor_317", "市长_317");
                    _dic.Add("Mayor_318", "市长_318");
                    _dic.Add("Mayor_319", "市长_319");
                    _dic.Add("Mayor_400", "市长_400");
                    _dic.Add("Mayor_401", "市长_401");
                    _dic.Add("Mayor_402", "市长_402");
                    _dic.Add("Mayor_403", "市长_403");
                    _dic.Add("Mayor_404", "市长_404");
                    _dic.Add("Mayor_405", "市长_405");
                    _dic.Add("Mayor_406", "市长_406");
                    _dic.Add("Mayor_407", "市长_407");
                    _dic.Add("Mayor_408", "市长_408");
                    _dic.Add("Mayor_409", "市长_409");
                    _dic.Add("Mayor_410", "市长_410");
                    _dic.Add("Mayor_411", "市长_411");
                    _dic.Add("Mayor_412", "市长_412");
                    _dic.Add("Mayor_413", "市长_413");
                    _dic.Add("Mayor_414", "市长_414");
                    _dic.Add("Mayor_415", "市长_415");
                    _dic.Add("Mayor_416", "市长_416");
                    _dic.Add("Mayor_417", "市长_417");
                    _dic.Add("Mayor_418", "市长_418");
                    _dic.Add("Mayor_419", "市长_419");
                    _dic.Add("Missions", "任务");
                    _dic.Add("IDCampaign", "战役");
                    _dic.Add("MissionType", "任务类型");
                    _dic.Add("EmpirePoints", "帝国分值");
                    _dic.Add("ResearchPoints", "研究分值");
                    _dic.Add("EngineeringPoints", "工程分值");
                    _dic.Add("MinMissionsForUnlocking", "解锁任务最小分数");
                    _dic.Add("IDEntitiesToUnlock", "实体解锁");
                    _dic.Add("IDMissionsToUnlock", "任务解锁");
                    _dic.Add("IDInitialUnits", "初始单位");
                    _dic.Add("InitialGold", "初始金钱");
                    _dic.Add("InitialWood", "初始木材");
                    _dic.Add("InitialStone", "初始石材");
                    _dic.Add("InitialIron", "初始钢铁");
                    _dic.Add("InitialOil", "初始石油");
                    _dic.Add("GoalColonists", "目标居民");
                    _dic.Add("GoalDaysAlive", "目标生存天数");
                    _dic.Add("GoalGold", "目标金钱");
                    _dic.Add("GoalWood", "目标木材");
                    _dic.Add("GoalStone", "目标石材");
                    _dic.Add("GoalIron", "目标钢铁");
                    _dic.Add("GoalOil", "目标石油");
                    _dic.Add("IDGoalEntities", "目标实体");
                    _dic.Add("MaxDaysLimit", "最大天数限制");
                    _dic.Add("InfectionNestsFactor", "感染巢穴系数");
                    _dic.Add("R1", "");
                    _dic.Add("R2", "");
                    _dic.Add("R3", "");
                    _dic.Add("Perks", "奖励");
                    _dic.Add("Requisites", "必须条件");
                    _dic.Add("Class", "种类");
                    _dic.Add("FoodSupplyFactor", "食物供应系数");
                    _dic.Add("WoodSuppyFactor", "木材供应系数");
                    _dic.Add("MineralSuppyFactor", "矿产供应系数");
                    _dic.Add("EnergySuppyFactor", "电力供应系数");
                    _dic.Add("UnitsTrainingFactor", "部队训练系数");
                    _dic.Add("ExtraUnitsOnStart", "开始额外的部队");
                    _dic.Add("GoldCostFactor", "金钱成本系数");
                    _dic.Add("BuildingsDeffenseFactor", "建筑防御系数");
                    _dic.Add("CostReturnOnDestroyFactor", "被破坏后回收系数");
                    _dic.Add("EnergyTransferBonus", "特斯拉塔奖励");
                    _dic.Add("LifeFactor", "生命系数");
                    _dic.Add("LifeBonus", "生命奖励");
                    _dic.Add("WatchRangeBonus", "视野范围奖励");
                    _dic.Add("DamageBonus", "伤害奖励");
                    _dic.Add("AdvancedHunting_I", "高级打猎_I");
                    _dic.Add("AdvancedHunting_II", "高级打猎_II");
                    _dic.Add("AdvancedFishing_I", "高级捕鱼_I");
                    _dic.Add("AdvancedFishing_II", "高级捕鱼_II");
                    _dic.Add("AdvancedFarming_I", "高级农场_I");
                    _dic.Add("AdvancedFarming_II", "高级农场_I");
                    _dic.Add("AdvancedChopping_I", "高级伐木_I");
                    _dic.Add("AdvancedMinning_I", "高级采矿_I");
                    _dic.Add("FasterUnitsTraining_I", "部队快速训练_I");
                    _dic.Add("FasterUnitsTraining_II", "部队快速训练_II");
                    _dic.Add("FasterUnitsTraining_III", "部队快速训练_III");
                    _dic.Add("ExtraUnits_I", "额外部队_I");
                    _dic.Add("ExtraUnits_II", "额外部队_II");
                    _dic.Add("CheaperUnits_I", "廉价部队_I");
                    _dic.Add("CheaperUnits_II", "廉价部队_II");
                    _dic.Add("ColonistsTraining_I", "居民训练_I");
                    _dic.Add("ColonistsTraining_II", "居民训练_II");
                    _dic.Add("FasterBuilding_I", "快速建造_I");
                    _dic.Add("FasterBuilding_II", "快速建造_II");
                    _dic.Add("ImprovedDeffenses_I", "改进防御_I");
                    _dic.Add("CheaperBuildings_I", "廉价建造_I");
                    _dic.Add("StrongerWalls_I", "强大的墙_I");
                    _dic.Add("StrongerWalls_II", "强大的墙_II");
                    _dic.Add("Advanced_Recycling_I", "高级回收_I");
                    _dic.Add("Advanced_Recycling_II", "高级回收_II");
                    _dic.Add("AdvancedRangers_I", "高级游侠_I");
                    _dic.Add("AdvancedSoldiers_I", "高级士兵_I");
                    _dic.Add("AdvancedEnergyTransfer_I", "现金能量传输");
                    _dic.Add("ExtraEnergyProduction_I", "特出能量生产_I");
                    _dic.Add("ExtraEnergyProduction_II", "特出能量生产_II");
                    _dic.Add("AdvancedGroundTraps_I", "先进地面陷阱");
                    _dic.Add("Research", "研究");
                    _dic.Add("IsDefault", "是否默认");
                    _dic.Add("MinClassLevel", "最小种类等级");
                    _dic.Add("Resources", "资源");
                    _dic.Add("AdvancedHunting1", "高级打猎1");
                    _dic.Add("AdvancedHunting2", "高级打猎2");
                    _dic.Add("AdvancedFishing1", "高级捕鱼1");
                    _dic.Add("AdvancedFishing2", "高级捕鱼2");
                    _dic.Add("AdvancedTools1", "高级工具1");
                    _dic.Add("AdvancedTools2", "高级工具2");
                    _dic.Add("AdvancedTools3", "高级工具3");
                    _dic.Add("AdvancedMinning1", "高级采矿1");
                    _dic.Add("AdvancedMinning2", "高级采矿2");
                    _dic.Add("AdvancedOilExtraction1", "高级采油1");
                    _dic.Add("AdvancedOilExtraction2", "高级采油2");
                    _dic.Add("AdvancedChopping1", "高级伐木1");
                    _dic.Add("AdvancedChopping2", "高级伐木2");
                    _dic.Add("AdvancedFarming1", "高级农场1");
                    _dic.Add("AdvancedFarming2", "高级农场2");
                    _dic.Add("Army", "军队");
                    _dic.Add("FasterUnitsTraining1", "部队快速训练1");
                    _dic.Add("FasterUnitsTraining2", "部队快速训练2");
                    _dic.Add("FasterUnitsTraining3", "部队快速训练3");
                    _dic.Add("UnitUpgrades1", "部队升级");
                    _dic.Add("Ranger1", "游侠1");
                    _dic.Add("Ranger2", "游侠2");
                    _dic.Add("Ranger3", "游侠3");
                    _dic.Add("Soldier1", "士兵1");
                    _dic.Add("Soldier2", "士兵2");
                    _dic.Add("Soldier3", "士兵3");
                    _dic.Add("Sniper1", "狙击手1");
                    _dic.Add("Sniper2", "狙击手2");
                    _dic.Add("Sniper3", "狙击手3");
                    _dic.Add("UnitUpgrades2", "部队升级2");
                    _dic.Add("Lucifer1", "坠天使1");
                    _dic.Add("Lucifer2", "坠天使2");
                    _dic.Add("Lucifer3", "坠天使3");
                    _dic.Add("Thanatos1", "死神1");
                    _dic.Add("Thanatos2", "死神2");
                    _dic.Add("Thanatos3", "死神3");
                    _dic.Add("Titan1", "泰坦1");
                    _dic.Add("Titan2", "泰坦2");
                    _dic.Add("Titan3", "泰坦3");
                    _dic.Add("Buildings", "建筑");
                    _dic.Add("CommandCenterExtraEnergy1", "指挥中心额外能源1");
                    _dic.Add("CommandCenterExtraEnergy2", "指挥中心额外能源2");
                    _dic.Add("FasterBuilding1", "快速建造1");
                    _dic.Add("FasterBuilding2", "快速建造2");
                    _dic.Add("FasterBuilding3", "快速建造3");
                    _dic.Add("ImprovedDeffenses1", "改进防御1");
                    _dic.Add("ImprovedDeffenses2", "改进防御2");
                    _dic.Add("ImprovedDeffenses3", "改进防御3");
                    _dic.Add("MaterialImprovements", "改进的材料");
                    _dic.Add("StrongerWalls1", "强大的墙1");
                    _dic.Add("StrongerWalls2", "强大的墙2");
                    _dic.Add("StrongerWalls3", "强大的墙3");
                    _dic.Add("Advanced_Recycling1", "高级回收1");
                    _dic.Add("Advanced_Recycling2", "高级回收2");
                    _dic.Add("Advanced_Recycling3", "高级回收3");
                    _dic.Add("AdvancedEnergyTransfer1", "高级电力传输1");
                    _dic.Add("CommandCenterTransfer1", "指挥中心电力传输1");
                    _dic.Add("CommandCenterTransfer2", "指挥中心电力传输2");
                    _dic.Add("AdvancedEnergyTransfer2", "高级电力传输2");
                    _dic.Add("TeslaTowerTransfer1", "特斯拉塔电力传输1");
                    _dic.Add("Economy", "节约");
                    _dic.Add("EmpirePayment1", "帝国报酬1");
                    _dic.Add("EmpirePayment2", "帝国报酬2");
                    _dic.Add("EmpirePayment3", "帝国报酬3");
                    _dic.Add("ColonistsEconomy", "居民节约");
                    _dic.Add("Taxes1", "税收1");
                    _dic.Add("Taxes2", "税收2");
                    _dic.Add("Taxes3", "税收3");
                    _dic.Add("BuildingEconomy", "建造节约");
                    _dic.Add("CheaperBuildings1", "廉价建造1");
                    _dic.Add("CheaperBuildings2", "廉价建造2");
                    _dic.Add("CheaperBuildings3", "廉价建造3");
                    _dic.Add("Bank1", "银行1");
                    _dic.Add("Bank2", "银行2");
                    _dic.Add("UnitsEconomy", "部队节约");
                    _dic.Add("CheaperUnits1", "廉价部队1");
                    _dic.Add("CheaperUnits2", "廉价部队2");
                    _dic.Add("CheaperUnits3", "廉价部队3");
                }
                return _dic;
            }
            set { _dic = value; }
        }

        private void TSMIsznlscq_Click(object sender, EventArgs e)
        {
            DataGridView dgv = GetMayorsDataGridView();
            if (dgv == null)
            {
                MessageBox.Show("市长列表不存在！");
                return;
            }
            if (FrmMayors == null || FrmMayors.IsDisposed)
            {
                FrmMayors = new frmMayors();
            }
            FrmMayors.DXTableManagerCurrent = DXTableManagerCurrent;
            FrmMayors.DXTableManagerOriginal = DXTableManagerOriginal;
            FrmMayors.dgv = dgv;
            FrmMayors.StartPosition = FormStartPosition.CenterScreen;
            FrmMayors.Show();
            FrmMayors.Activate();
        }

        public DataGridView GetMayorsDataGridView()
        {
            TabControl.TabPageCollection tpc = this.TC.TabPages;
            if (tpc != null)
            {
                for (int ii = 0; ii < tpc.Count; ii++)
                {
                    TabPage tp = tpc[ii];
                    string tpname = tp.Text.Trim();
                    string tpcname = tp.ToolTipText.Trim();
                    if (tpcname == "Mayors")
                    {
                        return (DataGridView)tp.Controls[0];
                    }
                }
            }
            return null;
        }

        private void TSMIExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

