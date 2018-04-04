using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZX.Data.View
{
    public partial class frmPassword : Form
    {
        public string pwd = "";

        public bool isoper = false;

        public frmPassword()
        {
            InitializeComponent();
            App.AppPub.SetComboBoxItems(cBver, "|选择版本密码||" + App.AppList.File_ZipPassword(), "", "");
        }

        private void btqd_Click(object sender, EventArgs e)
        {
            isoper = false;
            pwd = tBpwd.Text;
            isoper = true;
            this.Close();
        }

        private void btqx_Click(object sender, EventArgs e)
        {
            isoper = false;
            this.Close();
        }

        private void cBver_SelectedIndexChanged(object sender, EventArgs e)
        {
            tBpwd.Text = App.AppPub.GetComboBoxValue(cBver);
        }
    }
}
