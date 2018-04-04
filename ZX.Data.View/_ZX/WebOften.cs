using System;
using System.Text;
using System.Net;
using System.Data;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Configuration;

namespace App
{
    /// <summary>Web常用静态方法操作类</summary>
    [Serializable]
    public static class WebOften
    {

        #region WEB常用方法

        /// <summary>由字符串返回DataTable表,组和组使用 || 分隔 值和文本使用 | 分隔(DataTable表列 0:value,1:text)</summary>
        /// <param name="Str">DataTable 数据表字符串</param>
        /// <returns>返回DataTable表</returns>
        public static DataTable StrToDataTable(string Str)
        {
            return StrToDataTable(Str, "||", "|");
        }

        /// <summary>由字符串返回DataTable表(DataTable表列 0:value,1:text)</summary>
        /// <param name="Str">DataTable 数据表字符串</param>
        /// <param name="groupCompart">组和组的分隔字符串</param>
        /// <param name="compart">值和文本的分隔字符串</param>
        /// <returns>返回DataTable表</returns>
        public static DataTable StrToDataTable(string Str, string groupCompart, string compart)
        {
            DataTable DT = new DataTable();
            DT.Columns.Add("value", Type.GetType("System.String"));
            DT.Columns.Add("text", Type.GetType("System.String"));
            string[] sArray = Regex.Split(Str, App.Often.GetRegStr(groupCompart), RegexOptions.IgnoreCase);
            for (int i = 0; i < sArray.Length; i++)
            {
                string stra = sArray[i].Trim();
                if (stra != "")
                {
                    string[] xArray = Regex.Split(stra, App.Often.GetRegStr(compart), RegexOptions.IgnoreCase);
                    if (xArray.Length > 1)
                    {
                        DataRow newRow = DT.NewRow();
                        newRow["value"] = xArray[0].Trim();
                        newRow["text"] = xArray[1].Trim();
                        DT.Rows.Add(newRow);
                    }
                }
            }
            return DT;
        }

        /// <summary>返回由值与文本列组成的DataTable字符串中选中行的文本</summary>
        /// <param name="Str">DataTable 数据表字符串 字符串格式：组和组使用 || 分隔 值和文本使用 | 分隔</param>
        /// <param name="selValue">选中的值</param>
        /// <returns>返回由值与文本列组成的DataTable字符串中选中行的文本</returns>
        public static string GetListVal(string Str, string selValue)
        {
            return GetListVal(StrToDataTable(Str, "||", "|"), selValue, 0, 1);
        }

        /// <summary>返回由值与文本列组成的DataTable字符串中选中行的文本</summary>
        /// <param name="Str">DataTable 数据表字符串 字符串格式：组和组使用 || 分隔 值和文本使用 | 分隔</param>
        /// <param name="selValue">选中的值</param>
        /// <param name="valueIndex">选择列的索引</param>
        /// <returns>返回由值与文本列组成的DataTable字符串中选中行的文本</returns>
        public static string GetListVal(string Str, string selValue, int valueIndex)
        {
            return GetListVal(StrToDataTable(Str, "||", "|"), selValue, valueIndex, 1);
        }

        /// <summary>返回由值与文本列组成的DataTable字符串中选中行的文本</summary>
        /// <param name="Str">DataTable 数据表字符串 字符串格式：组和组使用 || 分隔 值和文本使用 | 分隔</param>
        /// <param name="selValue">选中的值</param>
        /// <param name="valueIndex">选择列的索引</param>
        /// <param name="textIndex">文本列的索引</param>
        /// <returns>返回由值与文本列组成的DataTable字符串中选中行的文本</returns>
        public static string GetListVal(string Str, string selValue, int valueIndex, int textIndex)
        {
            return GetListVal(StrToDataTable(Str, "||", "|"), selValue, valueIndex, textIndex);
        }

        /// <summary>返回由值与文本列组成的DataTable字符串中选中行的文本</summary>
        /// <param name="Str">DataTable 数据表字符串</param>
        /// <param name="selValue">选中的值</param>
        /// <param name="valueIndex">选择列的索引</param>
        /// <param name="textIndex">文本列的索引</param>
        /// <param name="groupCompart">组和组的分隔字符串</param>
        /// <param name="compart">值和文本的分隔字符串</param>
        /// <returns>返回由值与文本列组成的DataTable字符串中选中行的文本</returns>
        public static string GetListVal(string Str, string selValue, int valueIndex, int textIndex, string groupCompart, string compart)
        {
            return GetListVal(StrToDataTable(Str, groupCompart, compart), selValue, valueIndex, textIndex);
        }

        /// <summary>返回由值与文本列组成的DataTable中选中行的文本</summary>
        /// <param name="DT">由值与文本列组成的DataTable 数据表(DataTable表列 0:value,1:text)</param>
        /// <param name="selValue">选中的值</param>
        /// <returns>返回由值与文本列组成的DataTable中选中行的文本</returns>
        public static string GetListVal(DataTable DT, string selValue)
        {
            return GetListVal(DT, selValue, 0, 1);
        }

        /// <summary>返回由值与文本列组成的DataTable中选中行的文本</summary>
        /// <param name="DT">由值与文本列组成的DataTable 数据表(DataTable表列 0:value,1:text)</param>
        /// <param name="selValue">选中的值</param>
        /// <param name="valueIndex">选择列的索引</param>
        /// <returns>返回由值与文本列组成的DataTable中选中行的文本</returns>
        public static string GetListVal(DataTable DT, string selValue, int valueIndex)
        {
            return GetListVal(DT, selValue, valueIndex, 1);
        }

        /// <summary>返回由值与文本列组成的DataTable中选中行的文本</summary>
        /// <param name="DT">由值与文本列组成的DataTable 数据表(DataTable表列 0:value,1:text)</param>
        /// <param name="selValue">选中的值</param>
        /// <param name="valueIndex">选择列的索引</param>
        /// <param name="textIndex">文本列的索引</param>
        /// <returns>返回由值与文本列组成的DataTable中选中行的文本</returns>
        public static string GetListVal(DataTable DT, string selValue, int valueIndex, int textIndex)
        {
            for (int i = 0; i < DT.Rows.Count; i++)
            {
                string val = DT.Rows[i][valueIndex].ToString().Trim();
                if (val == selValue.Trim())
                {
                    return DT.Rows[i][textIndex].ToString();
                }
            }
            return "";
        }

        #endregion
    }
}
