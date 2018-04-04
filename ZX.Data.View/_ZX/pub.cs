using System;
using System.IO;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Web;

namespace App
{
    public class pub
    {
        /// <summary>返回Guid</summary>
        /// <returns>返回Guid</returns>
        public static string GetGuid()
        {
            return System.Guid.NewGuid().ToString("N").ToUpper();
        }

        /// <summary>返回指定日期的数字格式</summary>
        /// <param name="rq">指定日期</param>
        /// <returns>返回指定日期的数字格式</returns>
        public static int GetDateDayNum(DateTime rq)
        {
            return Convert.ToInt32(DateOften.ReFDateTime("{$Year}{$Month}{$Day}", rq));
        }

        /// <summary>返回指定日期的数字格式</summary>
        /// <param name="rqs">指定日期</param>
        /// <returns>返回指定日期的数字格式</returns>
        public static int GetDateDayNum(string rqs)
        {
            return Convert.ToInt32(DateOften.ReFDateTime("{$Year}{$Month}{$Day}", rqs));
        }

        /// <summary>删除Url参数列表指定参数名并返回</summary>
        /// <param name="urlname">url参数名称</param>
        /// <param name="urls">url参数列表，例: a=3&b=1&c=2</param>
        /// <returns>删除Url参数列表指定参数名并返回</returns>
        public static string DeleteUrlName(string urlname, string urls)
        {
            urls = urls.Trim();
            if (urls != "")
            {
                StringBuilder sb = new StringBuilder();
                string[] urlarr = urls.Split('&');
                for (int i = 0; i < urlarr.Length; i++)
                {
                    string str = urlarr[i].Trim();
                    if (str != "")
                    {
                        string[] strarr = str.Split('=');
                        if (strarr.Length == 2)
                        {
                            string sval = strarr[0].Trim();
                            if (sval.ToLower() != urlname.ToLower())
                            {
                                string stxt = strarr[1].Trim();
                                if (sb.Length > 0)
                                {
                                    sb.Append("&");
                                }
                                sb.Append(sval + "=" + stxt);
                            }
                        }
                    }
                }
                return sb.ToString();
            }
            return urls;
        }

        /// <summary>如果输入的字符串为空则返回默认字符串值</summary>
        /// <param name="str">输入的字符串</param>
        /// <param name="defstr">默认字符串值</param>
        /// <returns>如果输入的字符串为空则返回默认字符串值</returns>
        public static string GetStr(string str, string defstr)
        {
            if (str.Trim() == "")
            {
                return defstr;
            }
            return str;
        }

        /// <summary>如果输入的字符串不是长整数则返回默认字符串值</summary>
        /// <param name="str">输入的字符串</param>
        /// <param name="defstr">默认字符串值</param>
        /// <returns>如果输入的字符串不是长整数则返回默认字符串值</returns>
        public static string GetInt64(string str, string defstr)
        {
            if (Often.IsNum(str))
            {
                double d = Convert.ToDouble(str);
                if (Often.IsInt64(d))
                {
                    return Convert.ToInt64(d).ToString();
                }
            }
            return defstr;
        }

        /// <summary>如果输入的字符串不是整数则返回默认字符串值</summary>
        /// <param name="str">输入的字符串</param>
        /// <param name="defstr">默认字符串值</param>
        /// <returns>如果输入的字符串不是整数则返回默认字符串值</returns>
        public static string GetInt32(string str, string defstr)
        {
            if (Often.IsNum(str))
            {
                double d = Convert.ToDouble(str);
                if (Often.IsInt32(d))
                {
                    return Convert.ToInt32(d).ToString();
                }
            }
            return defstr;
        }

        /// <summary>如果输入的字符串不是数字则返回默认字符串值</summary>
        /// <param name="str">输入的字符串</param>
        /// <param name="defstr">默认字符串值</param>
        /// <returns>如果输入的字符串不是数字则返回默认字符串值</returns>
        public static string GetNum(string str, string defstr)
        {
            if (!Often.IsNum(str))
            {
                return defstr;
            }
            return str;
        }

        /// <summary>在字符串右侧增加文本，如果文本值不为空，添加指定分隔字符串</summary>
        /// <param name="sb">字符串</param>
        /// <param name="s">增加的文本</param>
        /// <param name="compart">分隔字符串</param>
        public static void StrAdd(ref StringBuilder sb, string s, string compart)
        {
            if (sb.Length > 0)
            {
                sb.Append(compart);
            }
            sb.Append(s);
        }

        /// <summary>如果字符串不为空则在字符串右侧增加指定的文本</summary>
        /// <param name="sb">字符串</param>
        /// <param name="compart">增加指定的文本</param>
        public static void StrAdd(ref StringBuilder sb, string compart)
        {
            if (sb.Length > 0)
            {
                sb.Append(compart);
            }
        }

        /// <summary>从选中的行建立新的表并返回</summary>
        /// <param name="alldt">指定内存表</param>
        /// <param name="pids">选中id集合</param>
        /// <returns>从选中的行建立新的表并返回</returns>
        public static DataTable GetSelectTable(DataTable alldt, string pids)
        {
            DataTable seldt = alldt.Clone();
            seldt.Clear();
            if (pids.Trim() != "")
            {
                string[] arrids = pids.Split(',');
                for (int i = 0; i < arrids.Length; i++)
                {
                    string sid = arrids[i];
                    if (Often.IsInt64(sid))
                    {
                        DataRow[] dr = alldt.Select("id=" + sid);
                        if (dr.Length > 0)
                        {
                            seldt.ImportRow(dr[0]);
                        }
                    }
                }
            }
            return seldt;
        }

        /// <summary>保留指定位小数，并舍去保留位之后的所有小数</summary>
        /// <param name="num">数字</param>
        /// <param name="digit">保留的小数位数</param>
        /// <returns>保留指定位小数，并舍去保留位之后的所有小数</returns>
        public static double GetHoldDigit(double num, int digit)
        {
            num = Math.Round(num, 4);
            if (num > 0)
            {
                if (digit >= 0)
                {
                    int xindex = num.ToString().IndexOf(".");
                    if (xindex > -1)
                    {
                        if (digit == 0)
                        {
                            return Convert.ToDouble(num.ToString().Split('.')[0]);
                        }
                        else
                        {
                            string[] sarr = num.ToString().Split('.');
                            string s1 = sarr[0].Trim();
                            string s2 = sarr[1].Trim();
                            if (s2.Length > digit)
                            {
                                return Convert.ToDouble(s1 + "." + s2.Remove(digit));
                            }
                        }
                    }
                }
                return num;
            }
            return 0;
        }

        /// <summary>返回数字的保留2位小数格式</summary>
        /// <param name="dnum">数字</param>
        /// <returns>返回数字的保留2位小数格式</returns>
        public static double GetNumber(double dnum)
        {
            return GetHoldDigit(dnum, 2);
        }

        /// <summary>返回数字的保留2位小数格式</summary>
        /// <param name="dnum">数字</param>
        /// <returns>返回数字的保留2位小数格式</returns>
        public static double GetNumber(string dnum)
        {
            if (!Often.IsNum(dnum))
            {
                dnum = "0";
            }
            return GetHoldDigit(Convert.ToDouble(dnum), 2);
        }

        /// <summary>返回数字的保留2位小数格式</summary>
        /// <param name="dnum">数字</param>
        /// <param name="defval">默认值</param>
        /// <returns>返回数字的保留2位小数格式</returns>
        public static double GetNumber(string dnum, string defval)
        {
            if (!Often.IsNum(dnum))
            {
                dnum = defval;
            }
            return GetHoldDigit(Convert.ToDouble(dnum), 2);
        }

        /// <summary>返回数字的正数并保留2位小数格式</summary>
        /// <param name="dnum">数字</param>
        /// <returns>返回数字的正数并保留2位小数格式</returns>
        public static double GetPNumber(string dnum)
        {
            if (!Often.IsNum(dnum))
            {
                dnum = "0";
            }
            double d = Convert.ToDouble(dnum);
            if (d < 0)
            {
                return 0;
            }
            else
            {
                return GetHoldDigit(Convert.ToDouble(dnum), 2);
            }
        }

        /// <summary>返回数据表字段的正数格式</summary>
        /// <param name="dnum">数字</param>
        /// <returns>返回数据表字段的正数格式</returns>
        public static double GetPDouble(string dnum)
        {
            if (!Often.IsNum(dnum))
            {
                dnum = "0";
            }
            double d = Convert.ToDouble(dnum);
            if (d < 0)
            {
                return 0;
            }
            return d;
        }

        /// <summary>返回数据表字段的数字格式</summary>
        /// <param name="dnum">数字</param>
        /// <returns>返回数据表字段的数字格式</returns>
        public static double GetDouble(string dnum)
        {
            if (!Often.IsNum(dnum))
            {
                dnum = "0";
            }
            return Convert.ToDouble(dnum);
        }

        /// <summary>返回数据表字段的数字格式</summary>
        /// <param name="dnum">数字</param>
        /// <param name="defval">默认值</param>
        /// <returns>返回数据表字段的数字格式</returns>
        public static double GetDouble(string dnum, string defval)
        {
            if (!Often.IsNum(dnum))
            {
                dnum = defval;
            }
            return Convert.ToDouble(dnum);
        }


        /// <summary>返回数字的Byte整数格式，如果不是数字则返回0</summary>
        /// <param name="dnum">数字</param>
        /// <returns>返回数字的Byte整数格式，如果不是数字则返回0</returns>
        public static byte GetByte(string dnum)
        {
            if (Often.IsNum(dnum))
            {
                double d = Convert.ToDouble(dnum);
                if (Often.IsByte(d))
                {
                    return Convert.ToByte(d);
                }
            }
            return 0;
        }

        /// <summary>返回数据表字段的正整数格式</summary>
        /// <param name="dnum">数字</param>
        /// <returns>返回数据表字段的正整数格式</returns>
        public static int GetPInt(string dnum)
        {
            if (Often.IsNum(dnum))
            {
                double d = Convert.ToDouble(dnum);
                if (Often.IsInt32(d) && d > 0)
                {
                    return Convert.ToInt32(d);
                }
            }
            return 0;
        }

        /// <summary>返回数字的整数格式，如果不是数字则返回0</summary>
        /// <param name="dnum">数字</param>
        /// <returns>返回数字的整数格式，如果不是数字则返回0</returns>
        public static int GetInt(string dnum)
        {
            if (Often.IsNum(dnum))
            {
                double d = Convert.ToDouble(dnum);
                if (Often.IsInt32(d))
                {
                    return Convert.ToInt32(d);
                }
            }
            return 0;
        }

        /// <summary>返回数字的整数格式</summary>
        /// <param name="dnum">数字</param>
        /// <param name="defval">默认值</param>
        /// <returns>返回数字的整数格式</returns>
        public static int GetInt(string dnum, string defval)
        {
            if (Often.IsNum(dnum))
            {
                double d = Convert.ToDouble(dnum);
                if (Often.IsInt32(d))
                {
                    return Convert.ToInt32(d);
                }
            }
            return Convert.ToInt32(defval);
        }

        /// <summary>返回cmd命令对象</summary>
        /// <returns>返回cmd命令对象</returns>
        public static System.Diagnostics.Process GetProcess()
        {
            System.Diagnostics.Process ps = new System.Diagnostics.Process();
            ps.StartInfo.CreateNoWindow = true;         // 不创建新窗口    
            ps.StartInfo.UseShellExecute = false;       //不启用shell启动进程  
            ps.StartInfo.RedirectStandardInput = true;  // 重定向输入    
            ps.StartInfo.RedirectStandardOutput = true; // 重定向标准输出    
            ps.StartInfo.RedirectStandardError = true;  // 重定向错误输出  
            return ps;
        }

        /// <summary>返回文件夹完整路径</summary>
        /// <param name="sdir">文件夹</param>
        /// <returns>返回文件夹完整路径</returns>
        public static string GetDirectoryPath(string sdir)
        {
            sdir = sdir.Replace("/", "\\");
            if (!sdir.EndsWith("\\"))
            {
                sdir = sdir + "\\";
            }
            return sdir;
        }

        /// <summary>返回指定内存表指定字段名与指定标识的值</summary>
        /// <param name="dt">内存表</param>
        /// <param name="idname">id字段名</param>
        /// <param name="cname">标识字段名</param>
        /// <param name="marks">标识</param>
        /// <returns>返回指定内存表指定字段名与指定标识的值</returns>
        public static string GetIDs(DataTable dt, string idname, string cname, string marks)
        {
            DataRow[] dr = dt.Select(cname + "='" + marks + "'");
            if (dr.Length > 0)
            {
                return dr[0][idname].ToString().Trim();
            }
            return "";
        }

        /// <summary>返回sha1加密值</summary>
        /// <param name="s">需要加密的字符串</param>
        /// <returns>返回sha1加密值</returns>
        public static string GetSHA1(string s)
        {
            System.Security.Cryptography.SHA1CryptoServiceProvider sha1Hasher = new System.Security.Cryptography.SHA1CryptoServiceProvider();
            byte[] data = sha1Hasher.ComputeHash(Encoding.UTF8.GetBytes(s));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }

        /// <summary>返回md5加密值</summary>
        /// <param name="s">需要加密的字符串</param>
        /// <returns>返回md5加密值</returns>
        public static string GetMD5(string s)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider md5Hasher = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] data = md5Hasher.ComputeHash(Encoding.UTF8.GetBytes(s));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }

        /// <summary>返回内存表过滤语句转义格式</summary>
        /// <param name="s">字符串</param>
        /// <returns>返回内存表过滤语句转义格式</returns>
        public static string GetTableFilter(string s)
        {
            s = s.Replace("'", "''");
            return s;
        }


        /// <summary>返回需要转移的url页面</summary>
        /// <param name="urlmode">页面打开模式</param>
        /// <param name="reurl">用户自定义url</param>
        /// <param name="defurl">默认url</param>
        /// <param name="IsCustomUrl">返回是否是自定义url模式</param>
        /// <returns>返回需要转移的url页面</returns>
        public static string GetReUrl(string urlmode, string reurl, string defurl, ref bool IsCustomUrl)
        {
            if (reurl != "")
            {
                IsCustomUrl = true;
                if (urlmode != "")
                {
                    return urlmode + ".location=\"" + reurl + "\";";
                }
                else
                {
                    return "location=\"" + reurl + "\";";
                }
            }
            IsCustomUrl = false;
            return defurl;
        }

        /// <summary>返回需要转移的url页面</summary>
        /// <param name="reurl">用户自定义url</param>
        /// <param name="defurl">默认url</param>
        /// <param name="IsCustomUrl">返回是否是自定义url模式</param>
        /// <returns>返回需要转移的url页面</returns>
        public static string GetReUrl(string reurl, string defurl, ref bool IsCustomUrl)
        {
            if (reurl != "")
            {
                IsCustomUrl = true;
                return reurl;
            }
            IsCustomUrl = false;
            return defurl;
        }

        /// <summary>返回已隐藏部分的电话号码</summary>
        /// <param name="tel">原始电话号码</param>
        /// <returns>返回已隐藏部分的电话号码</returns>
        public static string GetTelHide(string tel)
        {
            if (tel.Length < 7)
            {
                return tel;
            }
            string tela = tel.Substring(0, 3);
            string telb = tel.Substring(tel.Length - 4, 4);
            return tela + "****" + telb;
        }


        /// <summary>返回已隐藏部分的银行卡号</summary>
        /// <param name="bankCode">银行卡号</param>
        /// <returns>返回已隐藏部分的银行卡号</returns>
        public static string GetBankCodeHide(string bankCode)
        {
            if (bankCode.Length < 8)
            {
                return bankCode;
            }
            string tela = bankCode.Substring(0, 4);
            string telb = bankCode.Substring(bankCode.Length - 4, 4);
            return tela + "****" + telb;
        }

        /// <summary>返回姓名只保留姓隐藏名字</summary>
        /// <param name="name">姓名</param>
        /// <returns>返回姓名只保留姓隐藏名字</returns>
        public static string GetHideName(string name)
        {
            if (name.Length > 1)
            {
                return name.Substring(0, 1) + "**";
            }
            return name + "**";
        }

        /// <summary>添加id到不重复id集合</summary>
        /// <param name="ids">需要添加的id</param>
        /// <param name="idlist">id列表引用</param>
        /// <param name="idstr">id集合引用</param>
        public static void AddIDs(string ids, ref List<long> idlist, ref StringBuilder idstr)
        {
            if (Often.IsInt64(ids))
            {
                long lid = Convert.ToInt64(ids);
                if (lid > 0 && idlist.IndexOf(lid) == -1)
                {
                    if (idstr.Length > 0)
                    {
                        idstr.Append(",");
                    }
                    idstr.Append(lid.ToString());
                    idlist.Add(lid);
                }
            }
        }

        /// <summary>将图片数据转换为Base64字符串</summary>
        /// <param name="imgpath">图片路径</param>
        /// <returns>将图片数据转换为Base64字符串</returns> 
        public static string ImageToBase64(string imgpath)
        {
            string errs = "";
            return ImageToBase64(imgpath, ref errs);
        }

        /// <summary>将图片数据转换为Base64字符串</summary>
        /// <param name="imgpath">图片路径</param>
        /// <param name="errs">发生错误则返回错误信息</param>
        /// <returns>将图片数据转换为Base64字符串</returns> 
        public static string ImageToBase64(string imgpath, ref string errs)
        {
            try
            {
                System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(imgpath);
                MemoryStream ms = new MemoryStream();
                bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] arr = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(arr, 0, (int)ms.Length);
                ms.Close();
                return Convert.ToBase64String(arr);
            }
            catch (Exception ex)
            {
                errs = ex.Message;
            }
            return "";
        }

        /// <summary>将Base64字符串转换为图片</summary>
        /// <param name="s">Base64字符串</param>
        /// <returns>将Base64字符串转换为图片</returns>
        public static System.Drawing.Image Base64ToImage(string s)
        {
            string errs = "";
            return Base64ToImage(s, ref errs);
        }

        /// <summary>将Base64字符串转换为图片</summary>
        /// <param name="s">Base64字符串</param>
        /// <param name="errs">发生错误则返回错误信息</param>
        /// <returns>将Base64字符串转换为图片</returns>
        public static System.Drawing.Image Base64ToImage(string s, ref string errs)
        {
            try
            {
                byte[] bytes = Convert.FromBase64String(s);
                MemoryStream ms = new MemoryStream(bytes);
                System.Drawing.Image img = System.Drawing.Image.FromStream(ms);
                return img;
            }
            catch (Exception ex)
            {
                errs = ex.Message;
            }
            return null;
        }

        /// <summary>返回指定字符串不重复sql文本字段集合</summary>
        /// <param name="s">字符串</param>
        /// <returns>返回指定字符串不重复sql文本字段集合/returns>
        public static string GetSqlInStr(string s)
        {
            string[] sarr = s.Split(',');
            StringBuilder sb = new StringBuilder();
            List<string> ls = new List<string>();
            for (int i = 0; i < sarr.Length; i++)
            {
                string val = sarr[i].Trim();
                if (val != "" && ls.IndexOf(val) == -1)
                {
                    string idstr = "'" + val + "'";
                    if (sb.Length > 0)
                    {
                        sb.Append(",");
                    }
                    sb.Append(idstr);
                    ls.Add(val);
                }
            }
            return sb.ToString();
        }

        /// <summary>根据指定时间返回出生日期</summary>
        /// <param name="birth">指定时间</param>
        /// <returns>根据指定时间返回出生日期</returns>
        public static string GetBirthDate(string birth)
        {
            if (Often.IsDate(birth))
            {
                return App.DateOften.ReFDateTime("{$Year}-{$Month}-{$day}", birth);
            }
            return "";
        }
    }
}