using System;
using System.IO;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;
using System.Runtime.InteropServices;
using System.Net;
using App;

namespace App
{
    public class AppPub
    {
        /// <summary>返回object数组</summary>
        /// <param name="objs">object数组</param>
        public static object[] GetArray(params object[] objs)
        {
            return objs;
        }

        /// <summary>设置组合框列表内容</summary>
        /// <param name="cb">组合框</param>
        /// <param name="lists">列表字符串</param>
        /// <param name="selval">选中值</param>
        public static void SetComboBoxItems(ComboBox cb, string lists, string selval)
        {
            List<string> notVals = new List<string>();
            DataTable rdt = WebOften.StrToDataTable(lists);
            SetComboBoxItems(cb, "", rdt, 0, 1, 0, selval, "", notVals);
        }

        /// <summary>设置组合框列表内容</summary>
        /// <param name="cb">组合框</param>
        /// <param name="lists">列表字符串</param>
        /// <param name="valnum">值索引</param>
        /// <param name="txtnum">文本索引</param>
        /// <param name="mode">组合框列模式：0 值加文本模式 1值模式</param>
        /// <param name="selval">选中值</param>
        public static void SetComboBoxItems(ComboBox cb, string lists, int valnum, int txtnum, int mode, string selval)
        {
            List<string> notVals = new List<string>();
            DataTable rdt = WebOften.StrToDataTable(lists);
            SetComboBoxItems(cb, "", rdt, valnum, txtnum, mode, selval, "", notVals);
        }

        /// <summary>设置组合框列表内容</summary>
        /// <param name="cb">组合框</param>
        /// <param name="lists">列表字符串</param>
        /// <param name="valnum">值索引</param>
        /// <param name="txtnum">文本索引</param>
        /// <param name="mode">组合框列模式：0 值加文本模式 1值模式</param>
        /// <param name="selval">选中值</param>
        /// <param name="notVals">不出现在列表值的集合</param>
        public static void SetComboBoxItems(ComboBox cb, string lists, int valnum, int txtnum, int mode, string selval,  List<string> notVals)
        {
            DataTable rdt = WebOften.StrToDataTable(lists);
            SetComboBoxItems(cb, "", rdt, valnum, txtnum, mode, selval, "", notVals);
        }

        /// <summary>设置组合框列表内容</summary>
        /// <param name="cb">组合框</param>
        /// <param name="addlists">新增的列表</param>
        /// <param name="rdt">列表</param>
        /// <param name="valnum">值索引</param>
        /// <param name="txtnum">文本索引</param>
        /// <param name="mode">组合框列模式：0 值加文本模式 1值模式</param>
        /// <param name="defselval">默认选中的值</param>
        public static void SetComboBoxItems(ComboBox cb, string addlists, DataTable rdt, int valnum, int txtnum, int mode, string selval)
        {
            List<string> notVals = new List<string>();
            SetComboBoxItems(cb, addlists, rdt, valnum, txtnum, mode, selval, "", notVals);
        }

        /// <summary>设置组合框列表内容</summary>
        /// <param name="cb">组合框</param>
        /// <param name="addlists">新增的列表</param>
        /// <param name="rdt">列表</param>
        /// <param name="valnum">值索引</param>
        /// <param name="txtnum">文本索引</param>
        /// <param name="mode">组合框列模式：0 值加文本模式 1值模式</param>
        /// <param name="selval">选中值</param>
        /// <param name="notVals">不出现在列表值的集合</param>
        public static void SetComboBoxItems(ComboBox cb, string addlists, DataTable rdt, int valnum, int txtnum, int mode, string selval, List<string> notVals)
        {
            SetComboBoxItems(cb, addlists, rdt, valnum, txtnum, mode, selval, "", notVals);
        }

        /// <summary>设置组合框列表内容</summary>
        /// <param name="cb">组合框</param>
        /// <param name="lists">列表字符串</param>
        /// <param name="selval">选中值</param>
        /// <param name="defselval">默认选中的值</param>
        public static void SetComboBoxItems(ComboBox cb, string lists, string selval, string defselval)
        {
            List<string> notVals = new List<string>();
            DataTable rdt = WebOften.StrToDataTable(lists);
            SetComboBoxItems(cb, "", rdt, 0, 1, 0, selval, defselval, notVals);
        }

        /// <summary>设置组合框列表内容</summary>
        /// <param name="cb">组合框</param>
        /// <param name="lists">列表字符串</param>
        /// <param name="valnum">值索引</param>
        /// <param name="txtnum">文本索引</param>
        /// <param name="mode">组合框列模式：0 值加文本模式 1值模式</param>
        /// <param name="selval">选中值</param>
        /// <param name="defselval">默认选中的值</param>
        public static void SetComboBoxItems(ComboBox cb, string lists, int valnum, int txtnum, int mode, string selval, string defselval)
        {
            List<string> notVals = new List<string>();
            DataTable rdt = WebOften.StrToDataTable(lists);
            SetComboBoxItems(cb, "", rdt, valnum, txtnum, mode, selval, defselval, notVals);
        }

        /// <summary>设置组合框列表内容</summary>
        /// <param name="cb">组合框</param>
        /// <param name="lists">列表字符串</param>
        /// <param name="valnum">值索引</param>
        /// <param name="txtnum">文本索引</param>
        /// <param name="mode">组合框列模式：0 值加文本模式 1值模式</param>
        /// <param name="selval">选中值</param>
        /// <param name="defselval">默认选中的值</param>
        /// <param name="notVals">不出现在列表值的集合</param>
        public static void SetComboBoxItems(ComboBox cb, string lists, int valnum, int txtnum, int mode, string selval, string defselval, List<string> notVals)
        {
            DataTable rdt = WebOften.StrToDataTable(lists);
            SetComboBoxItems(cb, "", rdt, valnum, txtnum, mode, selval, defselval, notVals);
        }

        /// <summary>设置组合框列表内容</summary>
        /// <param name="cb">组合框</param>
        /// <param name="addlists">新增的列表</param>
        /// <param name="rdt">列表</param>
        /// <param name="valnum">值索引</param>
        /// <param name="txtnum">文本索引</param>
        /// <param name="mode">组合框列模式：0 值加文本模式 1值模式</param>
        /// <param name="selval">选中值</param>
        /// <param name="defselval">默认选中的值</param>
        public static void SetComboBoxItems(ComboBox cb, string addlists, DataTable rdt, int valnum, int txtnum, int mode, string selval, string defselval)
        {
            List<string> notVals = new List<string>();
            SetComboBoxItems(cb, addlists, rdt, valnum, txtnum, mode, selval, defselval, notVals);
        }

        /// <summary>设置组合框列表内容</summary>
        /// <param name="cb">组合框</param>
        /// <param name="addlists">新增的列表</param>
        /// <param name="rdt">列表</param>
        /// <param name="valnum">值索引</param>
        /// <param name="txtnum">文本索引</param>
        /// <param name="mode">组合框列模式：0 值加文本模式 1值模式</param>
        /// <param name="selval">选中值</param>
        /// <param name="defselval">默认选中的值</param>
        /// <param name="notVals">不出现在列表值的集合</param>
        public static void SetComboBoxItems(ComboBox cb, string addlists,  DataTable rdt, int valnum, int txtnum, int mode, string selval, string defselval, List<string> notVals)
        {
            DataTable adt = WebOften.StrToDataTable(addlists);
            cb.Items.Clear();
            int index = 0;
            for (int i = 0; i < adt.Rows.Count; i++)
            {
                DataRow dr = rdt.NewRow();
                dr[valnum] = adt.Rows[i][0].ToString().Trim();
                dr[txtnum] = adt.Rows[i][1].ToString().Trim();
                rdt.Rows.InsertAt(dr, 0);
            }
            for (int i = 0; i < rdt.Rows.Count; i++)
            {
                string val = rdt.Rows[i][valnum].ToString().Trim();
                string txt = rdt.Rows[i][txtnum].ToString().Trim();
                if (mode == 0)
                {
                    if (notVals.Count == 0 || notVals.IndexOf(val) > -1)
                    {
                        cb.Items.Add(new ValTxt(val, txt));
                        if ((selval == val) || (defselval == val))
                        {
                            cb.SelectedIndex = index;
                        }
                        index++;
                    }
                }
                else
                {
                    if (notVals.Count == 0 || notVals.IndexOf(val) > -1)
                    {
                        cb.Items.Add(val);
                        if ((selval == val) || (defselval == val))
                        {
                            cb.SelectedIndex = index;
                        }
                        index++;
                    }
                }
            }
        }

        /// <summary>设置组合框列表内容</summary>
        /// <param name="selval">选中值</param>
        /// <param name="cb">组合框</param>
        /// <param name="vals">列表值集合</param>
        public static void SetComboBoxItems(string selval, ComboBox cb, params string[] vals)
        {
            List<string> notVals = new List<string>();
            SetComboBoxItems(selval, cb, notVals, vals);
        }

        /// <summary>设置组合框列表内容</summary>
        /// <param name="selval">选中值</param>
        /// <param name="cb">组合框</param>
        /// <param name="notVals">不出现在列表值的集合</param>
        /// <param name="vals">列表值集合</param>
        public static void SetComboBoxItems(string selval, ComboBox cb, List<string> notVals, params string[] vals)
        {
            cb.Items.Clear();
            bool issel = false;
            int index = 0;
            for (int i = 0; i < vals.Length; i++)
            {
                string val = vals[i].Trim();
                if (notVals.Count == 0 || notVals.IndexOf(val) > -1)
                {
                    cb.Items.Add(val);
                    if (selval.Trim() != "" && selval == val)
                    {
                        cb.SelectedIndex = index;
                        issel = true;
                    }
                    index++;
                }
            }
            if (!issel && cb.Items.Count>0)
            {
                cb.SelectedIndex = 0;
            }
        }

        /// <summary>返回组合框选中的值</summary>
        /// <param name="cbs">组合框</param>
        /// <returns>返回组合框选中的值</returns>
        public static string GetComboBoxValue(ComboBox cbs)
        {
            try
            {
                return ((ValTxt)cbs.SelectedItem).Value.Trim();
            }
            catch
            {
            }
            return "";
        }

        /// <summary>返回组合框选中的标题</summary>
        /// <param name="cbs">组合框</param>
        /// <returns>返回组合框选中的标题</returns>
        public static string GetComboBoxText(ComboBox cbs)
        {
            try
            {
                return ((ValTxt)cbs.SelectedItem).Text.Trim();
            }
            catch
            {
            }
            return "";
        }

        /// <summary>返回组合框选中的值</summary>
        /// <param name="cbs">组合框</param>
        /// <returns>返回组合框选中的值</returns>
        public static string GetDropDownValue(ComboBox cbs)
        {
            try
            {
                if (cbs.SelectedItem != null)
                {
                    return ((ValTxt)cbs.SelectedItem).Value.Trim();
                }
                else
                {
                    return cbs.Text.Trim();
                }
            }
            catch
            {
            }
            return "";
        }

        /// <summary>返回组合框选中的标题</summary>
        /// <param name="cbs">组合框</param>
        /// <returns>返回组合框选中的标题</returns>
        public static string GetDropDownText(ComboBox cbs)
        {
            try
            {
                if (cbs.SelectedItem != null)
                {
                    return ((ValTxt)cbs.SelectedItem).Text.Trim();
                }
                else
                {
                    return cbs.Text.Trim();
                }
            }
            catch
            {
            }
            return "";
        }

        /// <summary>根据url或本地路径返回图片对象</summary>
        /// <param name="path">url或本地路径</param>
        /// <returns>根据url或本地路径返回图片对象</returns>
        public static Image GetImage(string path)
        {
            try
            {
                if (Often.IsUrl(path))
                {
                    Uri uri = new Uri(path);
                    WebRequest req = WebRequest.Create(uri);
                    WebResponse resp = req.GetResponse();
                    Stream str = resp.GetResponseStream();
                    Image img = Image.FromStream(str);
                    return img;
                }
                else if (File.Exists(path))
                {
                    Image img = Image.FromFile(path);
                    return img;
                }
            }
            catch
            {

            }
            return null;
        }

        /// <summary>在ListView添加Button并设置居中显示</summary>
        /// <param name="lv">ListView</param>
        /// <param name="bt">Button</param>
        /// <param name="bttext">Button文字</param>
        /// <param name="btw">Button宽度</param>
        /// <param name="bth">Button高度</param>
        /// <param name="rindex">ListView的行号</param>
        /// <param name="cindex">ListView的列号</param>
        public static void SetListViewButtonCenter(ListView lv, Button bt, string bttext, int btw, int bth, int rindex, int cindex)
        {
            bt.Text = bttext;
            Label bl = new Label();
            bl.Visible = false;
            bl.Text = rindex.ToString();
            bt.Controls.Add(bl);
            bt.Size = new Size(btw, bth);
            int lw = lv.Items[rindex].SubItems[cindex].Bounds.Width;
            int lh = lv.Items[rindex].SubItems[cindex].Bounds.Height;
            int x = lv.Items[rindex].SubItems[cindex].Bounds.Left + (int)((lw - btw) / 2);
            int y = lv.Items[rindex].SubItems[cindex].Bounds.Top + (int)((lh - bth) / 2);
            bt.Location = new Point(x, y);
        }

        /// <summary>设置列表行项目的颜色</summary>
        /// <param name="itema">列表行项目</param>
        /// <param name="s">列表值</param>
        /// <param name="isset">是否设置颜色</param>
        public static void SetSubItemsStyle(ref ListViewItem itema, string s, bool isset)
        {
            SetSubItemsStyle(ref itema, s, isset, "#000000", "#ff0000");
        }

        /// <summary>设置列表行项目的前景色与背景颜色</summary>
        /// <param name="itema">列表行项目</param>
        /// <param name="s">列表值</param>
        /// <param name="isset">是否设置颜色</param>
        /// <param name="fontcolor">文本颜色</param>
        /// <param name="bgcolor">背景色</param>
        public static void SetSubItemsStyle(ref ListViewItem itema, string s, bool isset, string fontcolor, string bgcolor)
        {
            ListViewItem.ListViewSubItem lvs = itema.SubItems.Add(s);
            if (isset && (fontcolor != "" || bgcolor != ""))
            {
                itema.UseItemStyleForSubItems = false;
                if (fontcolor != "")
                {
                    lvs.ForeColor = ColorTranslator.FromHtml(fontcolor);
                }
                if (bgcolor != "")
                {
                    lvs.BackColor = ColorTranslator.FromHtml(bgcolor);
                }
            }
        }

        /// <summary>设置列表行项目的颜色</summary>
        /// <param name="itema">列表行项目</param>
        /// <param name="s">列表值</param>
        /// <param name="vals">颜色对应的值集合，使用|分隔，例：0|1</param>
        /// <param name="colors">值对应的颜色集合，使用|分隔，例：#000000|#ff0000</param>
        public static void SetSubItemsStyle(ref ListViewItem itema, string s, string vals, string colors)
        {
            string color = "";
            string[] valarr = vals.Split('|');
            string[] carr = colors.Split('|');
            for (int i = 0; i < valarr.Length; i++)
            {
                string sval = valarr[i].Trim();
                if (s == sval)
                {
                    if (i < carr.Length)
                    {
                        color = carr[i].Trim();
                    }
                }
            }
            ListViewItem.ListViewSubItem lvs = itema.SubItems.Add(s);
            if (color != "")
            {
                itema.UseItemStyleForSubItems = false;
                lvs.ForeColor = ColorTranslator.FromHtml(color);
            }
        }

        /// <summary>设置列表行项目的颜色</summary>
        /// <param name="itema">列表行项目</param>
        /// <param name="s">列表值</param>
        /// <param name="vals">颜色对应的值集合，使用|分隔，例：0|1</param>
        /// <param name="colors">值对应的颜色集合，使用|分隔，例：#000000|#ff0000</param>
        /// <param name="bgcolors">值对应的背景色集合，使用|分隔，例：#000000|#ff0000</param>
        public static void SetSubItemsStyle(ref ListViewItem itema, string s, string vals, string colors, string bgcolors)
        {
            string color = "";
            string bgcolor = "";
            string[] valarr = vals.Split('|');
            string[] carr = colors.Split('|');
            string[] bgcarr = bgcolors.Split('|');
            for (int i = 0; i < valarr.Length; i++)
            {
                string sval = valarr[i].Trim();
                if (s == sval)
                {
                    if (i < carr.Length)
                    {
                        color = carr[i].Trim();
                    }
                    if (i < bgcarr.Length)
                    {
                        bgcolor = bgcarr[i].Trim();
                    }
                }
            }
            ListViewItem.ListViewSubItem lvs = itema.SubItems.Add(s);
            if (color != "" && bgcolor != "")
            {
                itema.UseItemStyleForSubItems = false;
                if (color != "")
                {
                    lvs.ForeColor = ColorTranslator.FromHtml(color);
                }
                if (bgcolor != "")
                {
                    lvs.BackColor = ColorTranslator.FromHtml(bgcolor);
                }
            }
        }

        /// <summary>返回复选框选中状态的数字值，选中返回1，否则返回0</summary>
        /// <param name="cb">复选框</param>
        /// <returns>返回复选框选中状态的数字值，选中返回1，否则返回0</returns>
        public static int GetCheckBoxInt(CheckBox cb)
        {
            if (cb.Checked)
            {
                return 1;
            }
            return 0;
        }

        /// <summary>返回复选框选中状态的数字值，选中返回0，否则返回1</summary>
        /// <param name="cb">复选框</param>
        /// <returns>返回复选框选中状态的数字值，选中返回0，否则返回1</returns>
        public static int GetCheckBoxFInt(CheckBox cb)
        {
            if (cb.Checked)
            {
                return 0;
            }
            return 1;
        }

        /// <summary>设置复选框选中状态</summary>
        /// <param name="cb">复选框</param>
        /// <param name="sel">选中值，1：选中，否则不选中</param>
        /// <returns>设置复选框选中状态</returns>
        public static void SetCheckBoxChecked(CheckBox cb, string sel)
        {
            if (sel=="1")
            {
                cb.Checked = true;
                return;
            }
            cb.Checked = false;
        }

        /// <summary>设置复选框选中状态</summary>
        /// <param name="cb">复选框</param>
        /// <param name="sel">选中值，0：选中，否则不选中</param>
        /// <returns>设置复选框选中状态</returns>
        public static void SetCheckBoxCheckedF(CheckBox cb, string sel)
        {
            if (sel == "0")
            {
                cb.Checked = true;
                return;
            }
            cb.Checked = false;
        }
    }
}
