using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using App;

namespace ZX.Data.View
{
    public partial class frmMayorsInfo : Form
    {
        /// <summary>是否操作成功</summary>
        public bool IsOper = false;

        /// <summary>编辑时的信息id</summary>
        public string ids = "";

        /// <summary>操作模式 0:添加,1:编辑</summary>
        public byte OpMode = 0;

        public DataTable dt = new DataTable();

        public frmMayorsInfo()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        public frmMayorsInfo(params object[] param)
        {
            InitializeComponent();
            if (param.Length > 1)
            {
                ids = param[0].ToString().Trim();
                OpMode = Convert.ToByte(param[1]);
            }
        }

        private void frmMayorsInfo_Load(object sender, EventArgs e)
        {
            llevel.Text = "";
            lstyle.Text = "";
            if (OpMode == 1)
            {
                LoadInfo();
            }
        }

        private void LoadInfo()
        {
            rBsign1.Enabled = false;
            rBsign2.Enabled = false;
            rBsign3.Enabled = false;
            rBdw1.Enabled = false;
            rBdw2.Enabled = false;
            DataRow[] drs = App.MayorsPowers.MayorsPowerTable.Select("mid='" + ids + "'");
            if (drs.Length > 0)
            {
                dt = DataOften.GetTable(drs);
            }
            else
            {
                MessageBox.Show("信息不存在或已被删除！");
                this.Close();
                return;
            }
            string level = DataOften.GetVal(dt, "level");
            llevel.Text = WebOften.GetListVal(AppList.L_MayorsLevel(), level);
            string rstyle = DataOften.GetVal(dt, "rstyle");
            lstyle.Text = WebOften.GetListVal(AppList.L_MayorsRewardStyle(), rstyle);
            tBname.Text = DataOften.GetVal(dt, "name");
            tBdepict.Text = DataOften.GetVal(dt, "depict");
            tBmin.Text = DataOften.GetVal(dt, "min");
            tBmax.Text = DataOften.GetVal(dt, "max");
            string sign = DataOften.GetVal(dt, "sign");
            if (sign == "+")
            {
                rBsign1.Checked = true;
            }
            else if (sign == "-")
            {
                rBsign2.Checked = true;
            }
            else if (sign == "=")
            {
                rBsign3.Checked = true;
            }
            string dw = DataOften.GetVal(dt, "dw");
            if (dw == "%")
            {
                rBdw2.Checked = true;
            }
            else
            {
                rBdw1.Checked = true;
            }
            tBmtype.Text = DataOften.GetVal(dt, "mtype");
            string sign_limit = DataOften.GetVal(dt, "sign_limit");
            string dw_limit = DataOften.GetVal(dt, "dw_limit");
            if (sign_limit.IndexOf("+") > -1)
            {
                rBsign1.Enabled = true;
            }
            else
            {
                rBsign1.Checked = false;
            }
            if (sign_limit.IndexOf("-") > -1)
            {
                rBsign2.Enabled = true;
            }
            else
            {
                rBsign2.Checked = false;
            }
            if (sign_limit.IndexOf("=") > -1)
            {
                rBsign3.Enabled = true;
            }
            else
            {
                rBsign3.Checked = false;
            }
            if (dw_limit == "")
            {
                rBdw1.Enabled = true;
                rBdw2.Enabled = false;
                rBdw2.Checked = false;
            }
            else if (dw_limit=="%")
            {
                rBdw1.Enabled = false;
                rBdw1.Checked = false;
                rBdw2.Enabled = true;
            }
            else if (dw_limit == ",%")
            {
                rBdw1.Enabled = true;
                rBdw2.Enabled = true;
            }
        }

        public bool IsRunOper()
        {

            string depict = tBdepict.Text.Trim();
            if (depict == "")
            {
                MessageBox.Show("描述不能为空！");
                return false;
            }
            string min = tBmin.Text.Trim();
            if (!Often.IsInt32(min))
            {
                MessageBox.Show("最小值必须是整数！");
                return false;
            }
            int mini = Convert.ToInt32(min);
            if (mini < 0)
            {
                MessageBox.Show("最小值不能小于0！");
                return false;
            }
            string max = tBmax.Text.Trim();
            if (!Often.IsInt32(max))
            {
                MessageBox.Show("最大值必须是整数！");
                return false;
            }
            int maxi = Convert.ToInt32(max);
            if (maxi < 0)
            {
                MessageBox.Show("最大值不能小于0！");
                return false;
            }
            if (maxi < mini)
            {
                MessageBox.Show("最大值必须大于或等于最小值！");
                return false;
            }
            string mtype = tBmtype.Text.Trim();
            if (!Often.IsInt32(mtype))
            {
                MessageBox.Show("种类必须是整数！");
                return false;
            }
            int mtypei = Convert.ToInt32(mtype);
            if (mtypei < 0)
            {
                MessageBox.Show("种类不能小于0！");
                return false;
            }
            return true;
        }

        private void btsave_Click(object sender, EventArgs e)
        {
            if (!IsRunOper())
            {
                return;
            }
            string depict = tBdepict.Text.Trim();
            string min = tBmin.Text.Trim();
            string max = tBmax.Text.Trim();
            string mtype = tBmtype.Text.Trim();
            string sign = "";
            if (rBsign1.Checked)
            {
                sign = "+";
            }
            else if (rBsign2.Checked)
            {
                sign = "-";
            }
            else if (rBsign3.Checked)
            {
                sign = "=";
            }
            string dw = "";
            if (rBdw2.Checked)
            {
                dw = "%";
            }
            if (OpMode == 1)
            {
                DataRow[] drs = App.MayorsPowers.MayorsPowerTable.Select("mid='" + ids + "'");
                if (drs.Length > 0)
                {
                    drs[0]["depict"] = depict;
                    drs[0]["sign"] = sign;
                    drs[0]["min"] = min;
                    drs[0]["max"] = max;
                    drs[0]["dw"] = dw;
                    drs[0]["mtype"] = mtype;
                }
            }
            else
            {

            }
            MayorsPowers.SaveMayorsPowerTableXmlFile();
            MessageBox.Show("保存成功！");
            IsOper = true;
            this.Close();
        }

        private void btexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
