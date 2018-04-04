using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DXVision;
using App;

namespace ZX.Data.View
{
    public partial class frmMayors : Form
    {
        public DataGridView dgv = null;

        ///<summary>Dat,当前表管理员</summary>
        public DXTableManager DXTableManagerCurrent = null;

        ///<summary>Dat,原始表管理员</summary>
        public DXTableManager DXTableManagerOriginal = null;

        public int ynlmin = 0;
        public int ynlmax = 0;


        public int yzymin = 0;
        public int yzymax = 0;


        public int yjsmin = 0;
        public int yjsmax = 0;


        public int ydwmin = 0;
        public int ydwmax = 0;


        public int ymodmin = 0;
        public int ymodmax = 0;


        public int nlmin = 0;
        public int nlmax = 0;
        public int nlc = 0;

        public int zymin = 0;
        public int zymax = 0;
        public int zyc = 0;

        public int jsmin = 0;
        public int jsmax = 0;
        public int jsc = 0;

        public int dwmin = 0;
        public int dwmax = 0;
        public int dwc = 0;

        public int modmin = 0;
        public int modmax = 0;
        public int modc = 0;

        public int bnlcount = 0;

        public int rnlcount = 0;

        public int znlcount = 0;

        public frmMayors()
        {
            InitializeComponent();
        }

        private void frmMayors_Load(object sender, EventArgs e)
        {
            AppPub.SetComboBoxItems(cBrstyle, "|全部||" + App.AppList.L_MayorsRewardStyle(), "");
            AppPub.SetComboBoxItems(cBlv, "|全部||" + App.AppList.L_MayorsLevel(), "");
            AppPub.SetComboBoxItems(cBzt, "|全部||" + App.AppList.L_IsUser(), "");
            AppPub.SetComboBoxItems(cBsxm, App.AppList.L_MayorsSearchType(), "depict");
            ynlmin = App.pub.GetInt(tBnlmin.Text, "10");
            ynlmax = App.pub.GetInt(tBnlmax.Text, "12");
            yzymin = App.pub.GetInt(tBzymin.Text, "0");
            yzymax = App.pub.GetInt(tBzymax.Text, "2");
            yjsmin = App.pub.GetInt(tBjsmin.Text, "0");
            yjsmax = App.pub.GetInt(tBjsmax.Text, "2");
            ydwmin = App.pub.GetInt(tBdwmin.Text, "0");
            ydwmax = App.pub.GetInt(tBdwmax.Text, "2");
            ymodmin = App.pub.GetInt(tBmodmin.Text, "5");
            ymodmax = App.pub.GetInt(tBmodmax.Text, "6");
            LoadList();
        }

        private void LoadList()
        {
            StringBuilder sb = new StringBuilder();
            DataTable dt = null;
            int s_rstyle = pub.GetInt(AppPub.GetDropDownValue(cBrstyle), "-1");
            if (s_rstyle > -1)
            {
                pub.StrAdd(ref sb, " rstyle=" + s_rstyle.ToString() + " ", " and ");
            }
            int s_lv = pub.GetInt(AppPub.GetDropDownValue(cBlv), "-1");
            if (s_lv > -1)
            {
                pub.StrAdd(ref sb, " level=" + s_lv.ToString() + " ", " and ");
            }
            int s_zt = pub.GetInt(AppPub.GetDropDownValue(cBzt), "-1");
            if (s_zt > -1)
            {
                pub.StrAdd(ref sb, " isuse=" + s_zt.ToString() + " ", " and ");
            }
            string sxm = AppPub.GetDropDownValue(cBsxm);
            string skey = tBskey.Text.Trim();
            if (skey != "")
            {
                pub.StrAdd(ref sb, " " + sxm + " like '%" + skey + "%' ", " and ");
            }
            if (sb.Length > 0)
            {
                dt = App.DataOften.GetTable(App.MayorsPowers.MayorsPowerTable.Select(sb.ToString()));
            }
            else
            {
                dt = App.MayorsPowers.MayorsPowerTable;
            }
            vlist.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem itema = new ListViewItem((i + 1).ToString(), 0);
                string level = WebOften.GetListVal(AppList.L_MayorsLevel(), DataOften.GetVal(dt, "level", i));
                itema.SubItems.Add(level);
                string rstyle = WebOften.GetListVal(AppList.L_MayorsRewardStyle(), DataOften.GetVal(dt, "rstyle", i));
                itema.SubItems.Add(rstyle);
                itema.SubItems.Add(DataOften.GetVal(dt, "depict", i));
                itema.SubItems.Add(DataOften.GetVal(dt, "name", i));
                itema.SubItems.Add(DataOften.GetVal(dt, "sign", i));
                itema.SubItems.Add(DataOften.GetVal(dt, "min", i));
                itema.SubItems.Add(DataOften.GetVal(dt, "max", i));
                itema.SubItems.Add(DataOften.GetVal(dt, "dw", i));
                itema.SubItems.Add(DataOften.GetVal(dt, "mtype", i));
                string qy = WebOften.GetListVal(AppList.L_IsUser(), DataOften.GetVal(dt, "isuse", i));
                AppPub.SetSubItemsStyle(ref itema, qy, "已起用|已停用", "#69CE1F|#FF0000");
                itema.SubItems.Add(DataOften.GetVal(dt, "mid", i));
                vlist.Items.AddRange(new ListViewItem[] { itema });
            }
        }

        private void btsc_Click(object sender, EventArgs e)
        {
            bnlcount = 0;
            nlmin = App.pub.GetInt(tBnlmin.Text, ynlmin.ToString());
            nlmax = App.pub.GetInt(tBnlmax.Text, ynlmax.ToString());
            SetNumMinMax(ref nlmin, ref nlmax);
            if (nlmax <= 0)
            {
                MessageBox.Show("能力总数最大值必须大于0！");
                return;
            }



            zymin = App.pub.GetInt(tBzymin.Text, yzymin.ToString());
            zymax = App.pub.GetInt(tBzymax.Text, yzymax.ToString());
            SetNumMinMax(ref zymin, ref zymax);


            jsmin = App.pub.GetInt(tBjsmin.Text, yjsmin.ToString());
            jsmax = App.pub.GetInt(tBjsmax.Text, yjsmax.ToString());
            SetNumMinMax(ref jsmin, ref jsmax);


            dwmin = App.pub.GetInt(tBdwmin.Text, ydwmin.ToString());
            dwmax = App.pub.GetInt(tBdwmax.Text, ydwmax.ToString());
            SetNumMinMax(ref dwmin, ref dwmax);


            modmin = App.pub.GetInt(tBmodmin.Text, ymodmin.ToString());
            modmax = App.pub.GetInt(tBmodmax.Text, ymodmax.ToString());
            SetNumMinMax(ref modmin, ref modmax);

            SetMayorsPowers();
            MessageBox.Show("生成成功！共计生成" + bnlcount.ToString() + "个市长能力。");
            //this.Close();
        }

        private void SetNumMinMax(ref int min, ref int max)
        {
            if (min < 0)
            {
                min = 0;
            }
            if (max < 0)
            {
                max = 0;
            }
            if (max < min)
            {
                max = min;
            }
        }

        private void SetRanNum()
        {
            if (nlmax > 0 && nlmax >= nlmin)
            {
                nlc = App.AppList.rd.Next(nlmin, nlmax + 1);
            }
            else
            {
                nlc = 0;
            }
            if (nlc <= 0)
            {
                return;
            }
            if (zymax > 0 && zymax >= zymin)
            {
                zyc = App.AppList.rd.Next(zymin, zymax + 1);
            }
            else
            {
                zyc = 0;
            }
            if (jsmax > 0 && jsmax >= jsmin)
            {
                jsc = App.AppList.rd.Next(jsmin, jsmax + 1);
            }
            else
            {
                jsc = 0;
            }
            if (dwmax > 0 && dwmax >= dwmin)
            {
                dwc = App.AppList.rd.Next(dwmin, dwmax + 1);
            }
            else
            {
                dwc = 0;
            }
            if (modmax > 0 && modmax >= modmin)
            {
                modc = App.AppList.rd.Next(modmin, modmax + 1);
            }
            else
            {
                modc = 0;
            }
        }

        private void btloaddef_Click(object sender, EventArgs e)
        {
            App.MayorsPowers.CreatDefaultMayorsPowerTable();
            LoadList();
        }

        private List<int> GetRanIntList(int mps)
        {
            List<int> nlist = new List<int>();
            if (mps>0)
            {
                List<int> ilist = new List<int>();
                for (int i = 0; i < mps; i++)
                {
                    ilist.Add(i);
                }
                while (ilist.Count > 0)
                {
                    int v = App.AppList.rd.Next(0, ilist.Count);
                    nlist.Add(ilist[v]);
                    ilist.RemoveAt(v);
                }
            }
            return nlist;
        }

        private void SetMayorsPowers()
        {
            DataTable dt = (DataTable)dgv.DataSource;
            if (dt.Columns.Count > 10)
            {
                string lvname = dt.Columns[1].ColumnName;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i][3] = "";
                    CellValueChanged(dgv, 3, i);

                    dt.Rows[i][4] = "";
                    CellValueChanged(dgv, 4, i);

                    dt.Rows[i][5] = "";
                    CellValueChanged(dgv, 5, i);

                    dt.Rows[i][6] = "";
                    CellValueChanged(dgv, 6, i);

                    dt.Rows[i][7] = "";
                    CellValueChanged(dgv, 7, i);

                    dt.Rows[i][8] = "";
                    CellValueChanged(dgv, 8, i);

                    dt.Rows[i][9] = "";
                    CellValueChanged(dgv, 9, i);

                    dt.Rows[i][10] = "";
                    CellValueChanged(dgv, 10, i);

                    SetRanNum();
                    int lv = Convert.ToInt32(dt.Rows[i][1]);
                    rnlcount = 0;
                    znlcount = 0;
                    List<int> slist = GetRanIntList(4);
                    for (int ii = 0; ii < slist.Count; ii++)
                    {
                        int sint = slist[ii];
                        if (sint == 0)
                        {
                            List<int> tl = new List<int>();
                            List<int> zlist = GetRanIntList(5);
                            for (int iii = 0; iii < zlist.Count; iii++)
                            {
                                int zint = zlist[iii];
                                if (zint == 0)
                                {
                                    int cindex = 3;
                                    string modname = dt.Columns[cindex].ColumnName;
                                    if (lvname == "Level" && modname == "ExtraGold")
                                    {
                                        string s = "";
                                        if (znlcount < zyc && rnlcount< nlc)
                                        {
                                            s = GetMayorsPowersResources(lv, 0, ref tl);
                                        }
                                        dt.Rows[i][cindex] = s;
                                        CellValueChanged(dgv, cindex, i);
                                    }
                                }
                                else if (zint == 1)
                                {
                                    int cindex = 4;
                                    string modname = dt.Columns[cindex].ColumnName;
                                    if (lvname == "Level" && modname == "ExtraWood")
                                    {
                                        string s = "";
                                        if (znlcount < zyc && rnlcount < nlc)
                                        {
                                            s = GetMayorsPowersResources(lv, 1, ref tl);
                                        }
                                        dt.Rows[i][cindex] = s;
                                        CellValueChanged(dgv, cindex, i);
                                    }
                                }
                                else if (zint == 2)
                                {
                                    int cindex = 5;
                                    string modname = dt.Columns[cindex].ColumnName;
                                    if (lvname == "Level" && modname == "ExtraStone")
                                    {
                                        string s = "";
                                        if (znlcount < zyc && rnlcount < nlc)
                                        {
                                            s = GetMayorsPowersResources(lv, 2, ref tl);
                                        }
                                        dt.Rows[i][cindex] = s;
                                        CellValueChanged(dgv, cindex, i);
                                    }
                                }
                                else if (zint == 3)
                                {
                                    int cindex = 6;
                                    string modname = dt.Columns[cindex].ColumnName;
                                    if (lvname == "Level" && modname == "ExtraIron")
                                    {
                                        string s = "";
                                        if (znlcount < zyc && rnlcount < nlc)
                                        {
                                            s = GetMayorsPowersResources(lv, 3, ref tl);
                                        }
                                        dt.Rows[i][cindex] = s;
                                        CellValueChanged(dgv, cindex, i);
                                    }
                                }
                                else if (zint == 4)
                                {
                                    int cindex = 7;
                                    string modname = dt.Columns[cindex].ColumnName;
                                    if (lvname == "Level" && modname == "ExtraOil")
                                    {
                                        string s = "";
                                        if (znlcount < zyc && rnlcount < nlc)
                                        {
                                            s = GetMayorsPowersResources(lv, 4, ref tl);
                                        }
                                        dt.Rows[i][cindex] = s;
                                        CellValueChanged(dgv, cindex, i);
                                    }
                                }
                            }
                        }
                        else if (sint == 1)
                        {
                            int cindex = 8;
                            string modname = dt.Columns[cindex].ColumnName;
                            if (lvname == "Level" && modname == "IDBonusTechnologies")
                            {
                                string s = "";
                                if (rnlcount < nlc)
                                {
                                    s = GetMayorsPowersTechnologies(lv);
                                }
                                dt.Rows[i][cindex] = s;
                                CellValueChanged(dgv, cindex, i);
                            }
                        }
                        else if (sint == 2)
                        {
                            int cindex = 9;
                            string modname = dt.Columns[cindex].ColumnName;
                            if (lvname == "Level" && modname == "IDBonusEntities")
                            {
                                string s = "";
                                if (rnlcount < nlc)
                                {
                                    s = GetMayorsPowersEntities(lv);
                                }
                                dt.Rows[i][cindex] = s;
                                CellValueChanged(dgv, cindex, i);
                            }

                        }
                        else if (sint == 3)
                        {
                            int cindex = 10;
                            string modname = dt.Columns[cindex].ColumnName;
                            if (lvname == "Level" && modname == "Mods")
                            {
                                string s = "";
                                if (rnlcount < nlc)
                                {
                                    s = GetMayorsPowersMods(lv);
                                }
                                dt.Rows[i][cindex] = s;
                                CellValueChanged(dgv, cindex, i);
                            }
                        }
                    }
                }
            }
        }

        private string GetMayorsPowersResources(int lv, int rstyle, ref List<int> tl)
        {
            DataRow[] dr = App.MayorsPowers.MayorsPowerTable.Select("rstyle=" + rstyle.ToString() + " and isuse=1 and level=" + lv);
            if (dr.Length > 0)
            {
                DataRow mdr = dr[App.AppList.rd.Next(0, dr.Length)];
                int type = Convert.ToInt32(mdr["mtype"]);
                if (tl.IndexOf(type) == -1)
                {
                    int mmin = Convert.ToInt32(mdr["min"]);
                    int mmax = Convert.ToInt32(mdr["max"]);
                    string msign = mdr["sign"].ToString();
                    int num = App.AppList.rd.Next(mmin, mmax + 1);
                    tl.Add(type);
                    if (num > 0)
                    {
                        bnlcount++;
                        rnlcount++;
                        znlcount++;
                        if (msign == "-")
                        {
                            return "-" + num.ToString();
                        }
                        else
                        {
                            return num.ToString();
                        }
                    }
                }
            }
            return "";
        }

        private string GetMayorsPowersTechnologies(int lv)
        {
            int rstyle = 5;
            LoadMayorsTypeCount(lv, rstyle, ref jsmin, ref jsmax);
            List<int> tl = new List<int>();
            StringBuilder ssb = new StringBuilder();
            bool iswb = true;
            int max = 0;
            int sc = App.AppList.rd.Next(jsmin, jsmax + 1);
            if (sc > 0)
            {
                while (iswb)
                {
                    if (rnlcount < nlc)
                    {
                        DataRow[] dr = App.MayorsPowers.MayorsPowerTable.Select("rstyle=" + rstyle.ToString() + " and isuse=1 and level=" + lv);
                        if (dr.Length > 0)
                        {
                            DataRow mdr = dr[App.AppList.rd.Next(0, dr.Length)];
                            int type = Convert.ToInt32(mdr["mtype"]);
                            if (tl.IndexOf(type) == -1)
                            {
                                if (ssb.Length > 0)
                                {
                                    ssb.Append(";");
                                }
                                string mname = mdr["name"].ToString();
                                ssb.Append(mname);
                                max++;
                                bnlcount++;
                                rnlcount++;
                                tl.Add(type);
                                if (max >= sc)
                                {
                                    iswb = false;
                                }
                            }
                        }
                    }
                    else
                    {
                        iswb = false;
                    }
                }
            }
            return ssb.ToString();
        }

        private string GetMayorsPowersEntities(int lv)
        {
            int rstyle = 6;
            LoadMayorsTypeCount(lv, rstyle, ref dwmin, ref dwmax);
            List<int> tl = new List<int>();
            StringBuilder ssb = new StringBuilder();
            bool iswb = true;
            int max = 0;
            int sc = App.AppList.rd.Next(dwmin, dwmax + 1);
            if (sc > 0)
            {
                while (iswb)
                {
                    if (rnlcount < nlc)
                    {
                        DataRow[] dr = App.MayorsPowers.MayorsPowerTable.Select("rstyle=" + rstyle.ToString() + " and isuse=1 and level=" + lv);
                        if (dr.Length > 0)
                        {
                            DataRow mdr = dr[App.AppList.rd.Next(0, dr.Length)];
                            int type = Convert.ToInt32(mdr["mtype"]);
                            if (tl.IndexOf(type) == -1)
                            {
                                if (ssb.Length > 0)
                                {
                                    ssb.Append(";");
                                }
                                string mname = mdr["name"].ToString();
                                int mmin = Convert.ToInt32(mdr["min"]);
                                int mmax = Convert.ToInt32(mdr["max"]);
                                int num = App.AppList.rd.Next(mmin, mmax + 1);
                                if (num > 0)
                                {
                                    bnlcount++;
                                    rnlcount++;
                                    if (num == 1)
                                    {
                                        ssb.Append(mname);
                                    }
                                    else
                                    {
                                        ssb.Append(mname + "(" + num.ToString() + ")");
                                    }
                                    max++;
                                    tl.Add(type);
                                }
                                if (max >= sc)
                                {
                                    iswb = false;
                                }
                            }
                        }
                    }
                    else
                    {
                        iswb = false;
                    }
                }
            }
            return ssb.ToString();
        }

        private string GetMayorsPowersMods(int lv)
        {
            int rstyle = 7;
            LoadMayorsTypeCount(lv, rstyle, ref modmin, ref modmax);
            List<int> tl = new List<int>();
            StringBuilder ssb = new StringBuilder();
            bool iswb = true;
            int max = 0;
            int sc = App.AppList.rd.Next(modmin, modmax + 1);
            if (sc > 0)
            {
                while (iswb)
                {
                    if (rnlcount < nlc)
                    {
                        DataRow[] dr = App.MayorsPowers.MayorsPowerTable.Select("rstyle=" + rstyle.ToString() + " and isuse=1 and level=" + lv);
                        if (dr.Length > 0)
                        {
                            DataRow mdr = dr[App.AppList.rd.Next(0, dr.Length)];
                            int type = Convert.ToInt32(mdr["mtype"]);
                            if (tl.IndexOf(type) == -1)
                            {
                                if (ssb.Length > 0)
                                {
                                    ssb.Append(";");
                                }
                                string mname = mdr["name"].ToString();
                                string msign = mdr["sign"].ToString();
                                int mmin = Convert.ToInt32(mdr["min"]);
                                int mmax = Convert.ToInt32(mdr["max"]);
                                string mdw = mdr["dw"].ToString();
                                ssb.Append(mname + " " + msign + App.AppList.rd.Next(mmin, mmax + 1).ToString() + mdw);
                                max++;
                                bnlcount++;
                                rnlcount++;
                                tl.Add(type);
                                if (max >= sc)
                                {
                                    iswb = false;
                                }
                            }
                        }
                    }
                    else
                    {
                        iswb = false;
                    }
                }
            }
            return ssb.ToString();
        }

        public void LoadMayorsTypeCount(int lv, int rstyle, ref int tmin, ref int tmax)
        {
            List<int> tl = new List<int>();
            DataRow[] dr = App.MayorsPowers.MayorsPowerTable.Select("rstyle=" + rstyle.ToString() + " and isuse=1 and level=" + lv);
            for (int i = 0; i < dr.Length; i++)
            {
                int type = Convert.ToInt32(dr[i]["mtype"]);
                if (tl.IndexOf(type) == -1)
                {
                    tl.Add(type);
                }
            }
            int lvc = tl.Count;
            if (tmin > lvc)
            {
                tmin = lvc;
            }
            if (tmax > lvc)
            {
                tmax = lvc;
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
                    if (!isStyle)
                    {
                        dgv[cindex, rindex].Style = App.AppList.CSytleNoFound;
                    }
                }
            }
            catch
            {

            }
        }

        private void btss_Click(object sender, EventArgs e)
        {
            LoadList();
        }

        private void vlist_DoubleClick(object sender, EventArgs e)
        {
            if (vlist.SelectedItems.Count > 0)
            {
                int index = vlist.SelectedItems[0].Index;
                int lindex = vlist.Items[index].SubItems.Count - 1;
                string ids = vlist.Items[index].SubItems[lindex].Text.Trim();
                if (ids != "")
                {
                    using (frmMayorsInfo form = new frmMayorsInfo(ids, "1"))
                    {
                        form.StartPosition = FormStartPosition.CenterScreen;
                        form.ShowDialog(this);
                        if (form.IsOper)
                        {
                            LoadList();
                        }
                    }
                }
            }
        }

        private void btqy_Click(object sender, EventArgs e)
        {
            if (vlist.SelectedItems.Count > 0)
            {
                int index = vlist.SelectedItems[0].Index;
                int lindex = vlist.Items[index].SubItems.Count - 1;
                string ids = vlist.Items[index].SubItems[lindex].Text.Trim();
                if (ids != "")
                {
                    DataRow[] drs = App.MayorsPowers.MayorsPowerTable.Select("mid='" + ids + "'");
                    if (drs.Length > 0)
                    {
                        drs[0]["isuse"] = 1;
                        MayorsPowers.SaveMayorsPowerTableXmlFile();
                        LoadList();
                    }
                }
            }
        }

        private void btty_Click(object sender, EventArgs e)
        {
            if (vlist.SelectedItems.Count > 0)
            {
                int index = vlist.SelectedItems[0].Index;
                int lindex = vlist.Items[index].SubItems.Count - 1;
                string ids = vlist.Items[index].SubItems[lindex].Text.Trim();
                if (ids != "")
                {
                    DataRow[] drs = App.MayorsPowers.MayorsPowerTable.Select("mid='" + ids + "'");
                    if (drs.Length > 0)
                    {
                        drs[0]["isuse"] = 0;
                        MayorsPowers.SaveMayorsPowerTableXmlFile();
                        LoadList();
                    }
                }
            }
        }

        private void btlc_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog();
            sfd.Filter = "Data files(*.xml)|*.xml";
            if (sfd.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            try
            {
                MayorsPowers.SaveMayorsPowerTableXmlFile(sfd.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存失败！错误信息：" + ex.Message);
                return;
            }
            MessageBox.Show("保存成功！");
        }

        private void btload_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            ofd.Filter = "Data files(*.xml)|*.xml";
            if (ofd.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            var path = ofd.FileName;
            DataTable ydt = MayorsPowers.MayorsPowerTable;
            DataTable dt = new DataTable();
            try
            {
                dt = MayorsPowers.LoadMayorsPowerTable(path);
            }
            catch (Exception ex)
            {
                MessageBox.Show("读取失败！错误信息：" + ex.Message);
                return;
            }
            try
            {
                MayorsPowers.MayorsPowerTable = dt;
                LoadList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("读取失败！错误信息：" + ex.Message);
                MayorsPowers.MayorsPowerTable = ydt;
                LoadList();
                return;
            }
        }

        private void btth_Click(object sender, EventArgs e)
        {
            SetMayorsDisplace();
        }

        private void SetMayorsDisplace()
        {
            DataTable dt = (DataTable)dgv.DataSource;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int ii = 0; ii < dt.Columns.Count; ii++)
                {
                    bool isval = false;
                    var oval = GetOriginalValue(dgv, ii, i, ref isval);
                    if (isval)
                    {
                        dt.Rows[i][ii] = oval;
                        CellValueChanged(dgv, ii, i);
                    }
                }
            }
        }

        private string GetOriginalValue(DataGridView dgv, int cindex, int rindex, ref bool isval)
        {
            try
            {
                if (cindex >= 0 && rindex >= 0)
                {
                    var tableName = ((TabPage)dgv.Parent).ToolTipText;
                    var id = $"{dgv[0, rindex].Value}";
                    var cname = dgv.Columns[cindex].Name;
                    if (DXTableManagerOriginal != null && DXTableManagerOriginal.Tables.ContainsKey(tableName))
                    {
                        DXTable dt = DXTableManagerOriginal[tableName];
                        if (dt.Rows.ContainsKey(id) && dt.Cols.ContainsKey(cname))
                        {
                            int cint = dt.Cols[cname];
                            var oval = $"{dt.Rows[id][cint]}";
                            isval = true;
                            return oval;
                        }
                    }
                }
            }
            catch
            {
            }
            isval = false;
            return "";
        }
    }
}
