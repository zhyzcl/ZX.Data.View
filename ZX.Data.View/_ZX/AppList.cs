using System;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace App
{
    public class AppList
    {
        /// <summary>程序安装路径</summary>
        public static string AppPath = Application.StartupPath;

        /// <summary>临时文件保存目录</summary>
        public static string TestDir = AppPath + "\\Test\\";

        /// <summary>配置文件保存目录</summary>
        public static string ConfigDir = AppPath + "\\Cfg\\";

        /// <summary>市长能力列表文件名称</summary>
        public static string MayorsPowerTableName = "MayorsPowerTable";

        /// <summary>能力列表文件名称</summary>
        public static string PowerListTableName = "PowerListTable";

        /// <summary>全局随机函数</summary>
        public static Random rd = new Random();

        public static readonly DataGridViewCellStyle CSytleNoFound = new DataGridViewCellStyle() { BackColor = Color.WhiteSmoke };
        public static readonly DataGridViewCellStyle CSytleMatch = new DataGridViewCellStyle() { BackColor = Color.Honeydew };
        public static readonly DataGridViewCellStyle CSytleNoMatch = new DataGridViewCellStyle() { BackColor = Color.PeachPuff };

        /// <summary>根据名称返回系统内存表构架</summary>
        /// <param name="name">名称</param>
        /// <returns>根据名称返回系统内存表构架</returns>
        public static DataTable GetConfigDataTable(string name)
        {
            Table t = new Table();
            t.TableName = name;
            if (name == MayorsPowerTableName)
            {
                t.Add("mid", "autoint", 0);//自增id
                t.Add("level", "int", 0);//等级
                t.Add("name", "string", 0);//名称
                t.Add("depict", "string", 0);//描述
                t.Add("sign", "string", 0);//加减运算符
                t.Add("min", "int", 0);//最小值
                t.Add("max", "int", 0);//最大值
                t.Add("dw", "string", 0);//单位
                t.Add("mtype", "int", 0);//种类
                t.Add("isuse", "int", 0);//是否起用： 0:已停用,1:已起用
                t.Add("rstyle", "int", 0);//奖励类型： 0:金钱奖励,1:木材奖励,2:石材奖励,3:钢铁奖励,4:石油奖励,5:技术奖励,6:单位或建筑奖励,7:MOD效果
                t.Add("sign_limit", "string", 0);//运算符限制，多个限制符使用小写逗号分隔
                t.Add("dw_limit", "string", 0);//单位限制，多个限制符使用小写逗号分隔
            }
            return App.DataTables.GetDataTable(t);
        }

        /// <summary>对应版本文件解压与加密密码</summary>
        /// <returns>对应版本文件解压与加密密码</returns>
        public static string File_ZipPassword()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("-2099717824-430703793638994083|v0.6.0.49密码");
            sb.Append("||-1613437835763669308-1035603436|v0.6.4.1密码");
            sb.Append("||-2099717824-430703793638994083-2099717824-430703793638994083334454FADSFASDF45345|v0.7.0.32密码");
            return sb.ToString();
        }

        /// <summary>停用起用</summary>
        /// <returns>停用起用</returns>
        public static string L_IsUser()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("0|已停用");
            sb.Append("||1|已起用");
            return sb.ToString();
        }

        /// <summary>市长等级</summary>
        /// <returns>市长等级</returns>
        public static string L_MayorsLevel()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("1|等级1");
            sb.Append("||2|等级2");
            sb.Append("||3|等级3");
            sb.Append("||4|等级4");
            return sb.ToString();
        }

        /// <summary>市长列表搜索类型</summary>
        /// <returns>市长列表搜索类型</returns>
        public static string L_MayorsSearchType()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("depict|描述");
            sb.Append("||name|名称");
            return sb.ToString();
        }

        /// <summary>市长奖励类型</summary>
        /// <returns>市长奖励类型</returns>
        public static string L_MayorsRewardStyle()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("0|金钱奖励");
            sb.Append("||1|木材奖励");
            sb.Append("||2|石材奖励");
            sb.Append("||3|钢铁奖励");
            sb.Append("||4|石油奖励");
            sb.Append("||5|技术奖励");
            sb.Append("||6|单位或建筑奖励");
            sb.Append("||7|MOD效果");
            return sb.ToString();
        }

        /// <summary>数据表字段类型</summary>
        public static string DataType()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("string|字符串");
            sb.Append("||int|整数(32位 int)");
            sb.Append("||long|长整数(64位 long)");
            sb.Append("||autoint|自动编号(32位 int)");
            sb.Append("||autolong|自动编号(64位 long)");
            sb.Append("||byte|byte(8位正整数)");
            sb.Append("||datetime|长日期(datetime)");
            sb.Append("||decimal|高精度浮点数字(decimal)");
            sb.Append("||double|双精度浮点数字(double)");
            sb.Append("||byte[]|字节数组(byte[])");
            return sb.ToString();
        }

        /// <summary>判断数据类型是否一致，一致则返回true, 否则返回false</summary>
        /// <param name="types">数据类型</param>
        /// <param name="intype">用户数据类型</param>
        /// <returns>判断数据类型是否一致，一致则返回true, 否则返回false</returns>
        public static bool IsDataType(string types, string intype)
        {
            string stype = GetDataType(intype).Trim();
            if (types.Trim() == stype)
            {
                return true;
            }
            return false;
        }

        /// <summary>返回内存表类型所对应的系统类型简写</summary>
        /// <param name="types">内存表类型</param>
        /// <returns>返回内存表类型所对应的系统类型简写</returns>
        public static string GetDataSType(string types)
        {
            types = types.ToLower();
            if (types == "int" || types == "int32" || types == "system.int32" || types == "i")
            {
                return "i";
            }
            else if (types == "long" || types == "int64" || types == "system.int64" || types == "l")
            {
                return "l";
            }
            else if (types == "autoint" || types == "ai")
            {
                return "ai";
            }
            else if (types == "autolong" || types == "al")
            {
                return "al";
            }
            else if (types == "bit" || types == "tinyint" || types == "byte" || types == "b")
            {
                return "b";
            }
            else if (types == "datetime" || types == "t")
            {
                return "t";
            }
            else if (types == "decimal" || types == "de")
            {
                return "de";
            }
            else if (types == "double" || types == "d")
            {
                return "d";
            }
            else if (types == "byte[]" || types == "bts")
            {
                return "bts";
            }
            return "string";
        }

        /// <summary>返回内存表类型所对应的系统类型</summary>
        /// <param name="types">内存表类型</param>
        /// <returns>返回内存表类型所对应的系统类型</returns>
        public static string GetDataType(string types)
        {
            types = types.ToLower();
            if (types == "int" || types == "int32" || types == "system.int32" || types == "i")
            {
                return "int";
            }
            else if (types == "long" || types == "int64" || types == "system.int64" || types == "l")
            {
                return "long";
            }
            else if (types == "autoint" || types == "ai")
            {
                return "autoint";
            }
            else if (types == "autolong" || types == "al")
            {
                return "autolong";
            }
            else if (types == "bit" || types == "tinyint" || types == "byte" || types == "b")
            {
                return "byte";
            }
            else if (types == "datetime" || types == "t")
            {
                return "datetime";
            }
            else if (types == "decimal" || types == "de")
            {
                return "decimal";
            }
            else if (types == "double" || types == "d")
            {
                return "double";
            }
            else if (types == "byte[]" || types == "bts")
            {
                return "byte[]";
            }
            return "string";
        }

        /// <summary>返回内存表类型所对应的系统类型</summary>
        /// <param name="types">内存表类型</param>
        /// <returns>返回内存表类型所对应的系统类型</returns>
        public static string GetDataTypes(string types)
        {
            types = types.ToLower();
            if (types == "int" || types == "int32" || types == "system.int32" || types == "i")
            {
                return "整数(32位 int)";
            }
            else if (types == "long" || types == "int64" || types == "system.int64" || types == "l")
            {
                return "长整数(64位 long)";
            }
            else if (types == "autoint" || types == "ai")
            {
                return "自动编号(32位 int)";
            }
            else if (types == "autolong" || types == "al")
            {
                return "自动编号(64位 long)";
            }
            else if (types == "bit" || types == "tinyint" || types == "byte" || types == "b")
            {
                return "byte(8位正整数)";
            }
            else if (types == "datetime" || types == "t")
            {
                return "长日期(datetime)";
            }
            else if (types == "decimal" || types == "de")
            {
                return "高精度浮点数字(decimal)";
            }
            else if (types == "double" || types == "d")
            {
                return "双精度浮点数字(double)";
            }
            else if (types == "byte[]" || types == "bts")
            {
                return "字节数组(byte[])";
            }
            return "字符串";
        }

        /// <summary>将指定列表字符串插入到指定内存列表并返回内存列表</summary>
        /// <param name="rdt">内存列表</param>
        /// <param name="str">指定列表字符串</param>
        /// <returns>将指定列表字符串插入到指定内存列表并返回内存列表</returns>
        public static DataTable AddTable(DataTable rdt, string str)
        {
            DataTable sdt = WebOften.StrToDataTable(str, "||", "|");
            for (int i = 0; i < sdt.Rows.Count; i++)
            {
                DataRow dr = rdt.NewRow();
                dr[0] = sdt.Rows[i][0];
                dr[1] = sdt.Rows[i][1];
                rdt.Rows.Add(dr);
            }
            return rdt;
        }

        /// <summary>将指定列表字符串插入到指定内存列表索引位置并返回内存列表</summary>
        /// <param name="rdt">内存列表</param>
        /// <param name="str">指定列表字符串</param>
        /// <param name="pos">内存列表索引位置</param>
        /// <returns>将指定列表字符串插入到指定内存列表索引位置并返回内存列表</returns>
        public static DataTable AddTable(DataTable rdt, string str, int pos)
        {
            DataTable sdt = WebOften.StrToDataTable(str, "||", "|");
            for (int i = 0; i < sdt.Rows.Count; i++)
            {
                DataRow dr = rdt.NewRow();
                dr[0] = sdt.Rows[i][0];
                dr[1] = sdt.Rows[i][1];
                rdt.Rows.InsertAt(dr, pos);
                pos++;
            }
            return rdt;
        }

        /// <summary>根据字符串数组返回列表字符串</summary>
        /// <param name="lists">字符串数组</param>
        /// <returns>根据字符串数组返回列表字符串</returns>
        public static string GetLists(string[] lists)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < lists.Length; i++)
            {
                if (sb.Length > 0)
                {
                    sb.Append("||");
                }
                sb.Append(lists[i] + "|" + lists[i]);
            }
            return sb.ToString();
        }

        /// <summary>根据字符串数组返回列表字符串</summary>
        /// <param name="lists">字符串数组</param>
        /// <returns>根据字符串数组返回列表字符串</returns>
        public static List<string> GetListValue(string lists)
        {
            List<string> li = new List<string>();
            string[] sArray = Regex.Split(lists, App.Often.GetRegStr("||"), RegexOptions.IgnoreCase);
            for (int i = 0; i < sArray.Length; i++)
            {
                string stra = sArray[i].Trim();
                if (stra != "")
                {
                    string[] xArray = Regex.Split(stra, App.Often.GetRegStr("|"), RegexOptions.IgnoreCase);
                    if (xArray.Length > 1)
                    {
                        string sval = xArray[0].Trim();
                        if (li.IndexOf(sval)==-1)
                        {
                            li.Add(sval);
                        }
                    }
                }
            }
            return li;
        }
    }
}
