using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace App
{
    /// <summary>数据集常用静态操作类</summary>
    [Serializable]
    public static class DataOften
    {
        #region Sql语句合并重组

        /// <summary>合并Sql语句并添加Sql查询参数数组</summary>
        /// <param name="SqlStr">需要合并的Sql语句</param>
        /// <param name="ValStr">需要添加的参数值</param>
        /// <param name="Str">需要更新并输出的Sql语句</param>
        /// <param name="ArrStr">需要更新并输出的Sql查询参数数组</param>
        /// <param name="JoStr">Sql合并时的连接语句</param>
        /// <returns></returns>
        public static void SqlAddArr(string SqlStr, string ValStr, string JoStr, ref StringBuilder Str, ref List<string> ArrStr)
        {
            if (Str.Length > 0)
            {
                Str.Append(JoStr);
            }
            Str.Append(SqlStr);
            ArrStr.Add(ValStr);
        }

        /// <summary>合并Sql语句并添加Sql查询参数数组</summary>
        /// <param name="SqlStr">需要合并的Sql语句</param>
        /// <param name="ValStr">需要添加的参数值</param>
        /// <param name="Str">需要更新并输出的Sql语句</param>
        /// <param name="ArrStr">需要更新并输出的Sql查询参数数组</param>
        /// <returns></returns>
        public static void SqlAddArr(string SqlStr, string ValStr, ref StringBuilder Str, ref List<string> ArrStr)
        {
            SqlAddArr(SqlStr, ValStr, " and ", ref Str, ref ArrStr);
        }

        /// <summary>合并Sql语句并添加Sql查询参数数组</summary>
        /// <param name="SqlStr">需要合并的Sql语句</param>
        /// <param name="Str">需要更新并输出的Sql语句</param>
        /// <param name="ArrStr">需要更新并输出的Sql查询参数数组</param>
        /// <param name="JoStr">Sql合并时的连接语句</param>
        /// <param name="Params">需要添加的params可变参数数组</param>
        /// <returns></returns>
        public static void SqlAddArr(string SqlStr, string JoStr, ref StringBuilder Str, ref List<string> ArrStr, params string[] Params)
        {
            if (Str.Length > 0)
            {
                Str.Append(JoStr);
            }
            Str.Append(SqlStr);
            for (int i = 0; i < Params.Length; i++)
            {
                ArrStr.Add(Params[i]);
            }
        }

        /// <summary>合并Sql语句并添加Sql查询参数数组</summary>
        /// <param name="SqlStr">需要合并的Sql语句</param>
        /// <param name="Str">需要更新并输出的Sql语句</param>
        /// <param name="ArrStr">需要更新并输出的Sql查询参数数组</param>
        /// <param name="Params">需要添加的params可变参数数组</param>
        /// <returns></returns>
        public static void SqlAddArr(string SqlStr, ref StringBuilder Str, ref List<string> ArrStr, params string[] Params)
        {
            SqlAddArr(SqlStr, " and ", ref Str, ref ArrStr, Params);
        }

        /// <summary>如果Sql语句长度大于0，则在其前面插入 where</summary>
        /// <param name="Str">需要更新并输出的Sql语句</param>
        /// <returns></returns>
        public static void SqlAddWhere(ref StringBuilder Str)
        {
            if (Str.Length > 0)
            {
                SqlAddSql(ref Str, " where ");
            }
        }

        /// <summary>如果Sql语句长度大于0，则在其前面插入指定字符串</summary>
        /// <param name="Str">需要更新并输出的Sql语句</param>
        /// <param name="iStr">需要插入的字符串</param>
        /// <returns></returns>
        public static void SqlAddSql(ref StringBuilder Str, string iStr)
        {
            if (Str.Length > 0)
            {
                Str.Insert(0, iStr);
            }
        }

        /// <summary>追加指定Sql语句,如果Sql语句长度大于0，则在其前面插入指定字符串</summary>
        /// <param name="Str">需要更新并输出的Sql语句</param>
        /// <param name="addStr">需要追加的Sql语句</param>
        /// <param name="inStr">需要插入的字符串</param>
        /// <returns></returns>
        public static void SqlAddSql(ref StringBuilder Str, string addStr, string inStr)
        {
            if (Str.Length > 0)
            {
                Str.Append(inStr);
            }
            Str.Append(addStr);
        }

        #endregion

        #region 获取DataTable内某列的值，并删除该值左右空白。如果该列不存在则返回空字符串

        /// <summary>获取DataTable内的第一行的指定列的值，并删除左右空白。如果没有找到指定的列则返回空字符串</summary>
        /// <param name="DT">一个DataTable实例的引用</param>
        /// <param name="ColName">列名</param>
        /// <returns>返回DataTable内的第一行的指定列的值</returns>
        public static string GetStr(DataTable DT, string ColName)
        {
            ColName = ColName.Trim();
            if (DT.Columns.Contains(ColName))
            {
                if (DT.Rows.Count > 0)
                {
                    return DT.Rows[0][ColName].ToString().Trim();
                }
            }
            return "";
        }

        /// <summary>获取DataTable内的第一行的指定列索引的值，并删除左右空白。如果没有找到指定的列则返回空字符串</summary>
        /// <param name="DT">一个DataTable实例的引用</param>
        /// <param name="ColIndex">列的索引</param>
        /// <returns>返回DataTable内的第一行的指定列的值</returns>
        public static string GetStr(DataTable DT, int ColIndex)
        {
            if (DT.Columns.Count > ColIndex && ColIndex > -1)
            {
                if (DT.Rows.Count > 0)
                {
                    return DT.Rows[0][ColIndex].ToString().Trim();
                }
            }
            return "";
        }

        /// <summary>获取DataTable内的指定行的指定列的值，并删除左右空白。如果没有找到指定的列则返回空字符串</summary>
        /// <param name="DT">一个DataTable实例的引用</param>
        /// <param name="ColName">列名</param>
        /// <param name="RowIndex">行的索引</param>
        /// <returns>返回DataTable内的指定行的指定列的值</returns>
        public static string GetStr(DataTable DT, string ColName, int RowIndex)
        {
            ColName = ColName.Trim();
            if (DT.Columns.Contains(ColName))
            {
                if (DT.Rows.Count > RowIndex && RowIndex > -1)
                {
                    return DT.Rows[RowIndex][ColName].ToString().Trim();
                }
            }
            return "";
        }

        /// <summary>获取DataTable内的指定行的指定列索引的值，并删除左右空白。如果没有找到指定的列则返回空字符串</summary>
        /// <param name="DT">一个DataTable实例的引用</param>
        /// <param name="ColIndex">列的索引</param>
        /// <param name="RowIndex">行的索引</param>
        /// <returns>返回DataTable内的指定行的指定列的值</returns>
        public static string GetStr(DataTable DT, int ColIndex, int RowIndex)
        {
            if (DT.Columns.Count > ColIndex && ColIndex > -1)
            {
                if (DT.Rows.Count > RowIndex && RowIndex > -1)
                {
                    return DT.Rows[RowIndex][ColIndex].ToString().Trim();
                }
            }
            return "";
        }

        /// <summary>获取DataTable内的第一行的指定列的值，并删除左右空白。如果没有找到指定的列则返回空字符串</summary>
        /// <param name="filter">要用来筛选行的条件</param>
        /// <param name="DT">一个DataTable实例的引用</param>
        /// <param name="ColName">列名</param>
        /// <returns>返回DataTable内的第一行的指定列的值</returns>
        public static string GetStr(string filter, DataTable DT, string ColName)
        {
            ColName = ColName.Trim();
            if (DT.Columns.Contains(ColName))
            {
                DataRow[] dRow = DT.Select(filter);
                if (dRow.Length > 0)
                {
                    return dRow[0][ColName].ToString().Trim();
                }
            }
            return "";
        }

        /// <summary>获取DataTable内的第一行的指定列索引的值，并删除左右空白。如果没有找到指定的列则返回空字符串</summary>
        /// <param name="filter">要用来筛选行的条件</param>
        /// <param name="DT">一个DataTable实例的引用</param>
        /// <param name="ColIndex">列的索引</param>
        /// <returns>返回DataTable内的第一行的指定列的值</returns>
        public static string GetStr(string filter, DataTable DT, int ColIndex)
        {
            if (DT.Columns.Count > ColIndex && ColIndex > -1)
            {
                DataRow[] dRow = DT.Select(filter);
                if (dRow.Length > 0)
                {
                    return dRow[0][ColIndex].ToString().Trim();
                }
            }
            return "";
        }

        /// <summary>获取DataTable内的指定行的指定列的值，并删除左右空白。如果没有找到指定的列则返回空字符串</summary>
        /// <param name="filter">要用来筛选行的条件</param>
        /// <param name="DT">一个DataTable实例的引用</param>
        /// <param name="ColName">列名</param>
        /// <param name="RowIndex">行的索引</param>
        /// <returns>返回DataTable内的指定行的指定列的值</returns>
        public static string GetStr(string filter, DataTable DT, string ColName, int RowIndex)
        {
            ColName = ColName.Trim();
            if (DT.Columns.Contains(ColName))
            {
                DataRow[] dRow = DT.Select(filter);
                if (dRow.Length > RowIndex && RowIndex > -1)
                {
                    return dRow[RowIndex][ColName].ToString().Trim();
                }
            }
            return "";
        }

        /// <summary>获取DataTable内的指定行的指定列索引的值，并删除左右空白。如果没有找到指定的列则返回空字符串</summary>
        /// <param name="filter">要用来筛选行的条件</param>
        /// <param name="DT">一个DataTable实例的引用</param>
        /// <param name="ColIndex">列的索引</param>
        /// <param name="RowIndex">行的索引</param>
        /// <returns>返回DataTable内的指定行的指定列的值</returns>
        public static string GetStr(string filter, DataTable DT, int ColIndex, int RowIndex)
        {
            if (DT.Columns.Count > ColIndex && ColIndex > -1)
            {
                DataRow[] dRow = DT.Select(filter);
                if (dRow.Length > RowIndex && RowIndex > -1)
                {
                    return dRow[RowIndex][ColIndex].ToString().Trim();
                }
            }
            return "";
        }

        /// <summary>获取DataTable内的第一行的指定列的值，并删除左右空白。如果没有找到指定的列则返回空字符串</summary>
        /// <param name="filter">要用来筛选行的条件</param>
        /// <param name="sort">一个字符串，它指定列和排序方向</param>
        /// <param name="DT">一个DataTable实例的引用</param>
        /// <param name="ColName">列名</param>
        /// <returns>返回DataTable内的第一行的指定列的值</returns>
        public static string GetStr(string filter, string sort, DataTable DT, string ColName)
        {
            ColName = ColName.Trim();
            if (DT.Columns.Contains(ColName))
            {
                DataRow[] dRow = DT.Select(filter, sort);
                if (dRow.Length > 0)
                {
                    return dRow[0][ColName].ToString().Trim();
                }
            }
            return "";
        }

        /// <summary>获取DataTable内的第一行的指定列索引的值，并删除左右空白。如果没有找到指定的列则返回空字符串</summary>
        /// <param name="filter">要用来筛选行的条件</param>
        /// <param name="sort">一个字符串，它指定列和排序方向</param>
        /// <param name="DT">一个DataTable实例的引用</param>
        /// <param name="ColIndex">列的索引</param>
        /// <returns>返回DataTable内的第一行的指定列的值</returns>
        public static string GetStr(string filter, string sort, DataTable DT, int ColIndex)
        {
            if (DT.Columns.Count > ColIndex && ColIndex > -1)
            {
                DataRow[] dRow = DT.Select(filter, sort);
                if (dRow.Length > 0)
                {
                    return dRow[0][ColIndex].ToString().Trim();
                }
            }
            return "";
        }

        /// <summary>获取DataTable内的指定行的指定列的值，并删除左右空白。如果没有找到指定的列则返回空字符串</summary>
        /// <param name="filter">要用来筛选行的条件</param>
        /// <param name="sort">一个字符串，它指定列和排序方向</param>
        /// <param name="DT">一个DataTable实例的引用</param>
        /// <param name="ColName">列名</param>
        /// <param name="RowIndex">行的索引</param>
        /// <returns>返回DataTable内的指定行的指定列的值</returns>
        public static string GetStr(string filter, string sort, DataTable DT, string ColName, int RowIndex)
        {
            ColName = ColName.Trim();
            if (DT.Columns.Contains(ColName))
            {
                DataRow[] dRow = DT.Select(filter, sort);
                if (dRow.Length > RowIndex && RowIndex > -1)
                {
                    return dRow[RowIndex][ColName].ToString().Trim();
                }
            }
            return "";
        }

        /// <summary>获取DataTable内的指定行的指定列索引的值，并删除左右空白。如果没有找到指定的列则返回空字符串</summary>
        /// <param name="filter">要用来筛选行的条件</param>
        /// <param name="sort">一个字符串，它指定列和排序方向</param>
        /// <param name="DT">一个DataTable实例的引用</param>
        /// <param name="ColIndex">列的索引</param>
        /// <param name="RowIndex">行的索引</param>
        /// <returns>返回DataTable内的指定行的指定列的值</returns>
        public static string GetStr(string filter, string sort, DataTable DT, int ColIndex, int RowIndex)
        {
            if (DT.Columns.Count > ColIndex && ColIndex > -1)
            {
                DataRow[] dRow = DT.Select(filter, sort);
                if (dRow.Length > RowIndex && RowIndex > -1)
                {
                    return dRow[RowIndex][ColIndex].ToString().Trim();
                }
            }
            return "";
        }

        /// <summary>获取DataTable内的第一行的指定列的值，并删除左右空白。如果没有找到指定的列则返回空字符串</summary>
        /// <param name="filter">要用来筛选行的条件</param>
        /// <param name="sort">一个字符串，它指定列和排序方向</param>
        /// <param name="dvrs">DataViewRowState 值之一</param>
        /// <param name="DT">一个DataTable实例的引用</param>
        /// <param name="ColName">列名</param>
        /// <returns>返回DataTable内的第一行的指定列的值</returns>
        public static string GetStr(string filter, string sort, DataViewRowState dvrs, DataTable DT, string ColName)
        {
            ColName = ColName.Trim();
            if (DT.Columns.Contains(ColName))
            {
                DataRow[] dRow = DT.Select(filter, sort, dvrs);
                if (dRow.Length > 0)
                {
                    return dRow[0][ColName].ToString().Trim();
                }
            }
            return "";
        }

        /// <summary>获取DataTable内的第一行的指定列索引的值，并删除左右空白。如果没有找到指定的列则返回空字符串</summary>
        /// <param name="filter">要用来筛选行的条件</param>
        /// <param name="sort">一个字符串，它指定列和排序方向</param>
        /// <param name="dvrs">DataViewRowState 值之一</param>
        /// <param name="DT">一个DataTable实例的引用</param>
        /// <param name="ColIndex">列的索引</param>
        /// <returns>返回DataTable内的第一行的指定列的值</returns>
        public static string GetStr(string filter, string sort, DataViewRowState dvrs, DataTable DT, int ColIndex)
        {
            if (DT.Columns.Count > ColIndex && ColIndex > -1)
            {
                DataRow[] dRow = DT.Select(filter, sort, dvrs);
                if (dRow.Length > 0)
                {
                    return dRow[0][ColIndex].ToString().Trim();
                }
            }
            return "";
        }

        /// <summary>获取DataTable内的指定行的指定列的值，并删除左右空白。如果没有找到指定的列则返回空字符串</summary>
        /// <param name="filter">要用来筛选行的条件</param>
        /// <param name="sort">一个字符串，它指定列和排序方向</param>
        /// <param name="dvrs">DataViewRowState 值之一</param>
        /// <param name="DT">一个DataTable实例的引用</param>
        /// <param name="ColName">列名</param>
        /// <param name="RowIndex">行的索引</param>
        /// <returns>返回DataTable内的指定行的指定列的值</returns>
        public static string GetStr(string filter, string sort, DataViewRowState dvrs, DataTable DT, string ColName, int RowIndex)
        {
            ColName = ColName.Trim();
            if (DT.Columns.Contains(ColName))
            {
                DataRow[] dRow = DT.Select(filter, sort, dvrs);
                if (dRow.Length > RowIndex && RowIndex > -1)
                {
                    return dRow[RowIndex][ColName].ToString().Trim();
                }
            }
            return "";
        }

        /// <summary>获取DataTable内的指定行的指定列索引的值，并删除左右空白。如果没有找到指定的列则返回空字符串</summary>
        /// <param name="filter">要用来筛选行的条件</param>
        /// <param name="sort">一个字符串，它指定列和排序方向</param>
        /// <param name="dvrs">DataViewRowState 值之一</param>
        /// <param name="DT">一个DataTable实例的引用</param>
        /// <param name="ColIndex">列的索引</param>
        /// <param name="RowIndex">行的索引</param>
        /// <returns>返回DataTable内的指定行的指定列的值</returns>
        public static string GetStr(string filter, string sort, DataViewRowState dvrs, DataTable DT, int ColIndex, int RowIndex)
        {
            if (DT.Columns.Count > ColIndex && ColIndex > -1)
            {
                DataRow[] dRow = DT.Select(filter, sort, dvrs);
                if (dRow.Length > RowIndex && RowIndex > -1)
                {
                    return dRow[RowIndex][ColIndex].ToString().Trim();
                }
            }
            return "";
        }

        #endregion

        #region 获取DataTable内某列的值。如果该列不存在则返回空字符串

        /// <summary>获取DataTable内的第一行的指定列的值，如果没有找到指定的列则返回空字符串</summary>
        /// <param name="DT">一个DataTable实例的引用</param>
        /// <param name="ColName">列名</param>
        /// <returns>返回DataTable内的第一行的指定列的值</returns>
        public static string GetStrs(DataTable DT, string ColName)
        {
            ColName = ColName.Trim();
            if (DT.Columns.Contains(ColName))
            {
                if (DT.Rows.Count > 0)
                {
                    return DT.Rows[0][ColName].ToString();
                }
            }
            return "";
        }

        /// <summary>获取DataTable内的第一行的指定列索引的值，如果没有找到指定的列则返回空字符串</summary>
        /// <param name="DT">一个DataTable实例的引用</param>
        /// <param name="ColIndex">列的索引</param>
        /// <returns>返回DataTable内的第一行的指定列的值</returns>
        public static string GetStrs(DataTable DT, int ColIndex)
        {
            if (DT.Columns.Count > ColIndex && ColIndex > -1)
            {
                if (DT.Rows.Count > 0)
                {
                    return DT.Rows[0][ColIndex].ToString();
                }
            }
            return "";
        }

        /// <summary>获取DataTable内的指定行的指定列的值，如果没有找到指定的列则返回空字符串</summary>
        /// <param name="DT">一个DataTable实例的引用</param>
        /// <param name="ColName">列名</param>
        /// <param name="RowIndex">行的索引</param>
        /// <returns>返回DataTable内的指定行的指定列的值</returns>
        public static string GetStrs(DataTable DT, string ColName, int RowIndex)
        {
            ColName = ColName.Trim();
            if (DT.Columns.Contains(ColName))
            {
                if (DT.Rows.Count > RowIndex && RowIndex > -1)
                {
                    return DT.Rows[RowIndex][ColName].ToString();
                }
            }
            return "";
        }

        /// <summary>获取DataTable内的指定行的指定列索引的值，如果没有找到指定的列则返回空字符串</summary>
        /// <param name="DT">一个DataTable实例的引用</param>
        /// <param name="ColIndex">列的索引</param>
        /// <param name="RowIndex">行的索引</param>
        /// <returns>返回DataTable内的指定行的指定列的值</returns>
        public static string GetStrs(DataTable DT, int ColIndex, int RowIndex)
        {
            if (DT.Columns.Count > ColIndex && ColIndex > -1)
            {
                if (DT.Rows.Count > RowIndex && RowIndex > -1)
                {
                    return DT.Rows[RowIndex][ColIndex].ToString();
                }
            }
            return "";
        }

        /// <summary>获取DataTable内的第一行的指定列的值，如果没有找到指定的列则返回空字符串</summary>
        /// <param name="filter">要用来筛选行的条件</param>
        /// <param name="DT">一个DataTable实例的引用</param>
        /// <param name="ColName">列名</param>
        /// <returns>返回DataTable内的第一行的指定列的值</returns>
        public static string GetStrs(string filter, DataTable DT, string ColName)
        {
            ColName = ColName.Trim();
            if (DT.Columns.Contains(ColName))
            {
                DataRow[] dRow = DT.Select(filter);
                if (dRow.Length > 0)
                {
                    return dRow[0][ColName].ToString();
                }
            }
            return "";
        }

        /// <summary>获取DataTable内的第一行的指定列索引的值，如果没有找到指定的列则返回空字符串</summary>
        /// <param name="filter">要用来筛选行的条件</param>
        /// <param name="DT">一个DataTable实例的引用</param>
        /// <param name="ColIndex">列的索引</param>
        /// <returns>返回DataTable内的第一行的指定列的值</returns>
        public static string GetStrs(string filter, DataTable DT, int ColIndex)
        {
            if (DT.Columns.Count > ColIndex && ColIndex > -1)
            {
                DataRow[] dRow = DT.Select(filter);
                if (dRow.Length > 0)
                {
                    return dRow[0][ColIndex].ToString();
                }
            }
            return "";
        }

        /// <summary>获取DataTable内的指定行的指定列的值，如果没有找到指定的列则返回空字符串</summary>
        /// <param name="filter">要用来筛选行的条件</param>
        /// <param name="DT">一个DataTable实例的引用</param>
        /// <param name="ColName">列名</param>
        /// <param name="RowIndex">行的索引</param>
        /// <returns>返回DataTable内的指定行的指定列的值</returns>
        public static string GetStrs(string filter, DataTable DT, string ColName, int RowIndex)
        {
            ColName = ColName.Trim();
            if (DT.Columns.Contains(ColName))
            {
                DataRow[] dRow = DT.Select(filter);
                if (dRow.Length > RowIndex && RowIndex > -1)
                {
                    return dRow[RowIndex][ColName].ToString();
                }
            }
            return "";
        }

        /// <summary>获取DataTable内的指定行的指定列索引的值，如果没有找到指定的列则返回空字符串</summary>
        /// <param name="filter">要用来筛选行的条件</param>
        /// <param name="DT">一个DataTable实例的引用</param>
        /// <param name="ColIndex">列的索引</param>
        /// <param name="RowIndex">行的索引</param>
        /// <returns>返回DataTable内的指定行的指定列的值</returns>
        public static string GetStrs(string filter, DataTable DT, int ColIndex, int RowIndex)
        {
            if (DT.Columns.Count > ColIndex && ColIndex > -1)
            {
                DataRow[] dRow = DT.Select(filter);
                if (dRow.Length > RowIndex && RowIndex > -1)
                {
                    return dRow[RowIndex][ColIndex].ToString();
                }
            }
            return "";
        }

        /// <summary>获取DataTable内的第一行的指定列的值，如果没有找到指定的列则返回空字符串</summary>
        /// <param name="filter">要用来筛选行的条件</param>
        /// <param name="sort">一个字符串，它指定列和排序方向</param>
        /// <param name="DT">一个DataTable实例的引用</param>
        /// <param name="ColName">列名</param>
        /// <returns>返回DataTable内的第一行的指定列的值</returns>
        public static string GetStrs(string filter, string sort, DataTable DT, string ColName)
        {
            ColName = ColName.Trim();
            if (DT.Columns.Contains(ColName))
            {
                DataRow[] dRow = DT.Select(filter, sort);
                if (dRow.Length > 0)
                {
                    return dRow[0][ColName].ToString();
                }
            }
            return "";
        }

        /// <summary>获取DataTable内的第一行的指定列索引的值，如果没有找到指定的列则返回空字符串</summary>
        /// <param name="filter">要用来筛选行的条件</param>
        /// <param name="sort">一个字符串，它指定列和排序方向</param>
        /// <param name="DT">一个DataTable实例的引用</param>
        /// <param name="ColIndex">列的索引</param>
        /// <returns>返回DataTable内的第一行的指定列的值</returns>
        public static string GetStrs(string filter, string sort, DataTable DT, int ColIndex)
        {
            if (DT.Columns.Count > ColIndex && ColIndex > -1)
            {
                DataRow[] dRow = DT.Select(filter, sort);
                if (dRow.Length > 0)
                {
                    return dRow[0][ColIndex].ToString();
                }
            }
            return "";
        }

        /// <summary>获取DataTable内的指定行的指定列的值，如果没有找到指定的列则返回空字符串</summary>
        /// <param name="filter">要用来筛选行的条件</param>
        /// <param name="sort">一个字符串，它指定列和排序方向</param>
        /// <param name="DT">一个DataTable实例的引用</param>
        /// <param name="ColName">列名</param>
        /// <param name="RowIndex">行的索引</param>
        /// <returns>返回DataTable内的指定行的指定列的值</returns>
        public static string GetStrs(string filter, string sort, DataTable DT, string ColName, int RowIndex)
        {
            ColName = ColName.Trim();
            if (DT.Columns.Contains(ColName))
            {
                DataRow[] dRow = DT.Select(filter, sort);
                if (dRow.Length > RowIndex && RowIndex > -1)
                {
                    return dRow[RowIndex][ColName].ToString();
                }
            }
            return "";
        }

        /// <summary>获取DataTable内的指定行的指定列索引的值，如果没有找到指定的列则返回空字符串</summary>
        /// <param name="filter">要用来筛选行的条件</param>
        /// <param name="sort">一个字符串，它指定列和排序方向</param>
        /// <param name="DT">一个DataTable实例的引用</param>
        /// <param name="ColIndex">列的索引</param>
        /// <param name="RowIndex">行的索引</param>
        /// <returns>返回DataTable内的指定行的指定列的值</returns>
        public static string GetStrs(string filter, string sort, DataTable DT, int ColIndex, int RowIndex)
        {
            if (DT.Columns.Count > ColIndex && ColIndex > -1)
            {
                DataRow[] dRow = DT.Select(filter, sort);
                if (dRow.Length > RowIndex && RowIndex > -1)
                {
                    return dRow[RowIndex][ColIndex].ToString();
                }
            }
            return "";
        }

        /// <summary>获取DataTable内的第一行的指定列的值，如果没有找到指定的列则返回空字符串</summary>
        /// <param name="filter">要用来筛选行的条件</param>
        /// <param name="sort">一个字符串，它指定列和排序方向</param>
        /// <param name="dvrs">DataViewRowState 值之一</param>
        /// <param name="DT">一个DataTable实例的引用</param>
        /// <param name="ColName">列名</param>
        /// <returns>返回DataTable内的第一行的指定列的值</returns>
        public static string GetStrs(string filter, string sort, DataViewRowState dvrs, DataTable DT, string ColName)
        {
            ColName = ColName.Trim();
            if (DT.Columns.Contains(ColName))
            {
                DataRow[] dRow = DT.Select(filter, sort, dvrs);
                if (dRow.Length > 0)
                {
                    return dRow[0][ColName].ToString();
                }
            }
            return "";
        }

        /// <summary>获取DataTable内的第一行的指定列索引的值，如果没有找到指定的列则返回空字符串</summary>
        /// <param name="filter">要用来筛选行的条件</param>
        /// <param name="sort">一个字符串，它指定列和排序方向</param>
        /// <param name="dvrs">DataViewRowState 值之一</param>
        /// <param name="DT">一个DataTable实例的引用</param>
        /// <param name="ColIndex">列的索引</param>
        /// <returns>返回DataTable内的第一行的指定列的值</returns>
        public static string GetStrs(string filter, string sort, DataViewRowState dvrs, DataTable DT, int ColIndex)
        {
            if (DT.Columns.Count > ColIndex && ColIndex > -1)
            {
                DataRow[] dRow = DT.Select(filter, sort, dvrs);
                if (dRow.Length > 0)
                {
                    return dRow[0][ColIndex].ToString();
                }
            }
            return "";
        }

        /// <summary>获取DataTable内的指定行的指定列的值，如果没有找到指定的列则返回空字符串</summary>
        /// <param name="filter">要用来筛选行的条件</param>
        /// <param name="sort">一个字符串，它指定列和排序方向</param>
        /// <param name="dvrs">DataViewRowState 值之一</param>
        /// <param name="DT">一个DataTable实例的引用</param>
        /// <param name="ColName">列名</param>
        /// <param name="RowIndex">行的索引</param>
        /// <returns>返回DataTable内的指定行的指定列的值</returns>
        public static string GetStrs(string filter, string sort, DataViewRowState dvrs, DataTable DT, string ColName, int RowIndex)
        {
            ColName = ColName.Trim();
            if (DT.Columns.Contains(ColName))
            {
                DataRow[] dRow = DT.Select(filter, sort, dvrs);
                if (dRow.Length > RowIndex && RowIndex > -1)
                {
                    return dRow[RowIndex][ColName].ToString();
                }
            }
            return "";
        }

        /// <summary>获取DataTable内的指定行的指定列索引的值，如果没有找到指定的列则返回空字符串</summary>
        /// <param name="filter">要用来筛选行的条件</param>
        /// <param name="sort">一个字符串，它指定列和排序方向</param>
        /// <param name="dvrs">DataViewRowState 值之一</param>
        /// <param name="DT">一个DataTable实例的引用</param>
        /// <param name="ColIndex">列的索引</param>
        /// <param name="RowIndex">行的索引</param>
        /// <returns>返回DataTable内的指定行的指定列的值</returns>
        public static string GetStrs(string filter, string sort, DataViewRowState dvrs, DataTable DT, int ColIndex, int RowIndex)
        {
            if (DT.Columns.Count > ColIndex && ColIndex > -1)
            {
                DataRow[] dRow = DT.Select(filter, sort, dvrs);
                if (dRow.Length > RowIndex && RowIndex > -1)
                {
                    return dRow[RowIndex][ColIndex].ToString();
                }
            }
            return "";
        }

        #endregion

        #region 获取DataTable内某列的值，并删除该值左右空白。如果该列不存在则返回指定字符串

        /// <summary>获取DataTable内的第一行的指定列的值，并删除左右空白。如果没有找到指定的列则返回指定字符串</summary>
        /// <param name="DT">一个DataTable实例的引用</param>
        /// <param name="ColName">列名</param>
        /// <param name="defStr">默认值</param>
        /// <returns>返回DataTable内的第一行的指定列的值</returns>
        public static string GetStr(DataTable DT, string ColName, string defStr)
        {
            ColName = ColName.Trim();
            if (DT.Columns.Contains(ColName))
            {
                if (DT.Rows.Count > 0)
                {
                    return DT.Rows[0][ColName].ToString().Trim();
                }
            }
            return defStr;
        }

        /// <summary>获取DataTable内的第一行的指定列索引的值，并删除左右空白。如果没有找到指定的列则返回指定字符串</summary>
        /// <param name="DT">一个DataTable实例的引用</param>
        /// <param name="ColIndex">列的索引</param>
        /// <param name="defStr">默认值</param>
        /// <returns>返回DataTable内的第一行的指定列的值</returns>
        public static string GetStr(DataTable DT, int ColIndex, string defStr)
        {
            if (DT.Columns.Count > ColIndex && ColIndex > -1)
            {
                if (DT.Rows.Count > 0)
                {
                    return DT.Rows[0][ColIndex].ToString().Trim();
                }
            }
            return defStr;
        }

        /// <summary>获取DataTable内的指定行的指定列的值，并删除左右空白。如果没有找到指定的列则返回指定字符串</summary>
        /// <param name="DT">一个DataTable实例的引用</param>
        /// <param name="ColName">列名</param>
        /// <param name="RowIndex">行的索引</param>
        /// <param name="defStr">默认值</param>
        /// <returns>返回DataTable内的指定行的指定列的值</returns>
        public static string GetStr(DataTable DT, string ColName, int RowIndex, string defStr)
        {
            ColName = ColName.Trim();
            if (DT.Columns.Contains(ColName))
            {
                if (DT.Rows.Count > RowIndex && RowIndex > -1)
                {
                    return DT.Rows[RowIndex][ColName].ToString().Trim();
                }
            }
            return defStr;
        }

        /// <summary>获取DataTable内的指定行的指定列索引的值，并删除左右空白。如果没有找到指定的列则返回指定字符串</summary>
        /// <param name="DT">一个DataTable实例的引用</param>
        /// <param name="ColIndex">列的索引</param>
        /// <param name="RowIndex">行的索引</param>
        /// <param name="defStr">默认值</param>
        /// <returns>返回DataTable内的指定行的指定列的值</returns>
        public static string GetStr(DataTable DT, int ColIndex, int RowIndex, string defStr)
        {
            if (DT.Columns.Count > ColIndex && ColIndex > -1)
            {
                if (DT.Rows.Count > RowIndex && RowIndex > -1)
                {
                    return DT.Rows[RowIndex][ColIndex].ToString().Trim();
                }
            }
            return defStr;
        }

        /// <summary>获取DataTable内的第一行的指定列的值，并删除左右空白。如果没有找到指定的列则返回指定字符串</summary>
        /// <param name="filter">要用来筛选行的条件</param>
        /// <param name="DT">一个DataTable实例的引用</param>
        /// <param name="ColName">列名</param>
        /// <param name="defStr">默认值</param>
        /// <returns>返回DataTable内的第一行的指定列的值</returns>
        public static string GetStr(string filter, DataTable DT, string ColName, string defStr)
        {
            ColName = ColName.Trim();
            if (DT.Columns.Contains(ColName))
            {
                DataRow[] dRow = DT.Select(filter);
                if (dRow.Length > 0)
                {
                    return dRow[0][ColName].ToString().Trim();
                }
            }
            return defStr;
        }

        /// <summary>获取DataTable内的第一行的指定列索引的值，并删除左右空白。如果没有找到指定的列则返回指定字符串</summary>
        /// <param name="filter">要用来筛选行的条件</param>
        /// <param name="DT">一个DataTable实例的引用</param>
        /// <param name="ColIndex">列的索引</param>
        /// <param name="defStr">默认值</param>
        /// <returns>返回DataTable内的第一行的指定列的值</returns>
        public static string GetStr(string filter, DataTable DT, int ColIndex, string defStr)
        {
            if (DT.Columns.Count > ColIndex && ColIndex > -1)
            {
                DataRow[] dRow = DT.Select(filter);
                if (dRow.Length > 0)
                {
                    return dRow[0][ColIndex].ToString().Trim();
                }
            }
            return defStr;
        }

        /// <summary>获取DataTable内的指定行的指定列的值，并删除左右空白。如果没有找到指定的列则返回指定字符串</summary>
        /// <param name="filter">要用来筛选行的条件</param>
        /// <param name="DT">一个DataTable实例的引用</param>
        /// <param name="ColName">列名</param>
        /// <param name="RowIndex">行的索引</param>
        /// <param name="defStr">默认值</param>
        /// <returns>返回DataTable内的指定行的指定列的值</returns>
        public static string GetStr(string filter, DataTable DT, string ColName, int RowIndex, string defStr)
        {
            ColName = ColName.Trim();
            if (DT.Columns.Contains(ColName))
            {
                DataRow[] dRow = DT.Select(filter);
                if (dRow.Length > RowIndex && RowIndex > -1)
                {
                    return dRow[RowIndex][ColName].ToString().Trim();
                }
            }
            return defStr;
        }

        /// <summary>获取DataTable内的指定行的指定列索引的值，并删除左右空白。如果没有找到指定的列则返回指定字符串</summary>
        /// <param name="filter">要用来筛选行的条件</param>
        /// <param name="DT">一个DataTable实例的引用</param>
        /// <param name="ColIndex">列的索引</param>
        /// <param name="RowIndex">行的索引</param>
        /// <param name="defStr">默认值</param>
        /// <returns>返回DataTable内的指定行的指定列的值</returns>
        public static string GetStr(string filter, DataTable DT, int ColIndex, int RowIndex, string defStr)
        {
            if (DT.Columns.Count > ColIndex && ColIndex > -1)
            {
                DataRow[] dRow = DT.Select(filter);
                if (dRow.Length > RowIndex && RowIndex > -1)
                {
                    return dRow[RowIndex][ColIndex].ToString().Trim();
                }
            }
            return defStr;
        }

        /// <summary>获取DataTable内的第一行的指定列的值，并删除左右空白。如果没有找到指定的列则返回指定字符串</summary>
        /// <param name="filter">要用来筛选行的条件</param>
        /// <param name="sort">一个字符串，它指定列和排序方向</param>
        /// <param name="DT">一个DataTable实例的引用</param>
        /// <param name="ColName">列名</param>
        /// <param name="defStr">默认值</param>
        /// <returns>返回DataTable内的第一行的指定列的值</returns>
        public static string GetStr(string filter, string sort, DataTable DT, string ColName, string defStr)
        {
            ColName = ColName.Trim();
            if (DT.Columns.Contains(ColName))
            {
                DataRow[] dRow = DT.Select(filter, sort);
                if (dRow.Length > 0)
                {
                    return dRow[0][ColName].ToString().Trim();
                }
            }
            return defStr;
        }

        /// <summary>获取DataTable内的第一行的指定列索引的值，并删除左右空白。如果没有找到指定的列则返回指定字符串</summary>
        /// <param name="filter">要用来筛选行的条件</param>
        /// <param name="sort">一个字符串，它指定列和排序方向</param>
        /// <param name="DT">一个DataTable实例的引用</param>
        /// <param name="ColIndex">列的索引</param>
        /// <param name="defStr">默认值</param>
        /// <returns>返回DataTable内的第一行的指定列的值</returns>
        public static string GetStr(string filter, string sort, DataTable DT, int ColIndex, string defStr)
        {
            if (DT.Columns.Count > ColIndex && ColIndex > -1)
            {
                DataRow[] dRow = DT.Select(filter, sort);
                if (dRow.Length > 0)
                {
                    return dRow[0][ColIndex].ToString().Trim();
                }
            }
            return defStr;
        }

        /// <summary>获取DataTable内的指定行的指定列的值，并删除左右空白。如果没有找到指定的列则返回指定字符串</summary>
        /// <param name="filter">要用来筛选行的条件</param>
        /// <param name="sort">一个字符串，它指定列和排序方向</param>
        /// <param name="DT">一个DataTable实例的引用</param>
        /// <param name="ColName">列名</param>
        /// <param name="RowIndex">行的索引</param>
        /// <param name="defStr">默认值</param>
        /// <returns>返回DataTable内的指定行的指定列的值</returns>
        public static string GetStr(string filter, string sort, DataTable DT, string ColName, int RowIndex, string defStr)
        {
            ColName = ColName.Trim();
            if (DT.Columns.Contains(ColName))
            {
                DataRow[] dRow = DT.Select(filter, sort);
                if (dRow.Length > RowIndex && RowIndex > -1)
                {
                    return dRow[RowIndex][ColName].ToString().Trim();
                }
            }
            return defStr;
        }

        /// <summary>获取DataTable内的指定行的指定列索引的值，并删除左右空白。如果没有找到指定的列则返回指定字符串</summary>
        /// <param name="filter">要用来筛选行的条件</param>
        /// <param name="sort">一个字符串，它指定列和排序方向</param>
        /// <param name="DT">一个DataTable实例的引用</param>
        /// <param name="ColIndex">列的索引</param>
        /// <param name="RowIndex">行的索引</param>
        /// <param name="defStr">默认值</param>
        /// <returns>返回DataTable内的指定行的指定列的值</returns>
        public static string GetStr(string filter, string sort, DataTable DT, int ColIndex, int RowIndex, string defStr)
        {
            if (DT.Columns.Count > ColIndex && ColIndex > -1)
            {
                DataRow[] dRow = DT.Select(filter, sort);
                if (dRow.Length > RowIndex && RowIndex > -1)
                {
                    return dRow[RowIndex][ColIndex].ToString().Trim();
                }
            }
            return defStr;
        }

        /// <summary>获取DataTable内的第一行的指定列的值，并删除左右空白。如果没有找到指定的列则返回指定字符串</summary>
        /// <param name="filter">要用来筛选行的条件</param>
        /// <param name="sort">一个字符串，它指定列和排序方向</param>
        /// <param name="dvrs">DataViewRowState 值之一</param>
        /// <param name="DT">一个DataTable实例的引用</param>
        /// <param name="ColName">列名</param>
        /// <param name="defStr">默认值</param>
        /// <returns>返回DataTable内的第一行的指定列的值</returns>
        public static string GetStr(string filter, string sort, DataViewRowState dvrs, DataTable DT, string ColName, string defStr)
        {
            ColName = ColName.Trim();
            if (DT.Columns.Contains(ColName))
            {
                DataRow[] dRow = DT.Select(filter, sort, dvrs);
                if (dRow.Length > 0)
                {
                    return dRow[0][ColName].ToString().Trim();
                }
            }
            return defStr;
        }

        /// <summary>获取DataTable内的第一行的指定列索引的值，并删除左右空白。如果没有找到指定的列则返回指定字符串</summary>
        /// <param name="filter">要用来筛选行的条件</param>
        /// <param name="sort">一个字符串，它指定列和排序方向</param>
        /// <param name="dvrs">DataViewRowState 值之一</param>
        /// <param name="DT">一个DataTable实例的引用</param>
        /// <param name="ColIndex">列的索引</param>
        /// <param name="defStr">默认值</param>
        /// <returns>返回DataTable内的第一行的指定列的值</returns>
        public static string GetStr(string filter, string sort, DataViewRowState dvrs, DataTable DT, int ColIndex, string defStr)
        {
            if (DT.Columns.Count > ColIndex && ColIndex > -1)
            {
                DataRow[] dRow = DT.Select(filter, sort, dvrs);
                if (dRow.Length > 0)
                {
                    return dRow[0][ColIndex].ToString().Trim();
                }
            }
            return defStr;
        }

        /// <summary>获取DataTable内的指定行的指定列的值，并删除左右空白。如果没有找到指定的列则返回指定字符串</summary>
        /// <param name="filter">要用来筛选行的条件</param>
        /// <param name="sort">一个字符串，它指定列和排序方向</param>
        /// <param name="dvrs">DataViewRowState 值之一</param>
        /// <param name="DT">一个DataTable实例的引用</param>
        /// <param name="ColName">列名</param>
        /// <param name="RowIndex">行的索引</param>
        /// <param name="defStr">默认值</param>
        /// <returns>返回DataTable内的指定行的指定列的值</returns>
        public static string GetStr(string filter, string sort, DataViewRowState dvrs, DataTable DT, string ColName, int RowIndex, string defStr)
        {
            ColName = ColName.Trim();
            if (DT.Columns.Contains(ColName))
            {
                DataRow[] dRow = DT.Select(filter, sort, dvrs);
                if (dRow.Length > RowIndex && RowIndex > -1)
                {
                    return dRow[RowIndex][ColName].ToString().Trim();
                }
            }
            return defStr;
        }

        /// <summary>获取DataTable内的指定行的指定列索引的值，并删除左右空白。如果没有找到指定的列则返回指定字符串</summary>
        /// <param name="filter">要用来筛选行的条件</param>
        /// <param name="sort">一个字符串，它指定列和排序方向</param>
        /// <param name="dvrs">DataViewRowState 值之一</param>
        /// <param name="DT">一个DataTable实例的引用</param>
        /// <param name="ColIndex">列的索引</param>
        /// <param name="RowIndex">行的索引</param>
        /// <param name="defStr">默认值</param>
        /// <returns>返回DataTable内的指定行的指定列的值</returns>
        public static string GetStr(string filter, string sort, DataViewRowState dvrs, DataTable DT, int ColIndex, int RowIndex, string defStr)
        {
            if (DT.Columns.Count > ColIndex && ColIndex > -1)
            {
                DataRow[] dRow = DT.Select(filter, sort, dvrs);
                if (dRow.Length > RowIndex && RowIndex > -1)
                {
                    return dRow[RowIndex][ColIndex].ToString().Trim();
                }
            }
            return defStr;
        }

        #endregion

        #region 获取DataTable内某列的值。如果该列不存在则返回指定字符串

        /// <summary>获取DataTable内的第一行的指定列的值，如果没有找到指定的列则返回指定字符串</summary>
        /// <param name="DT">一个DataTable实例的引用</param>
        /// <param name="ColName">列名</param>
        /// <param name="defStr">默认值</param>
        /// <returns>返回DataTable内的第一行的指定列的值</returns>
        public static string GetStrs(DataTable DT, string ColName, string defStr)
        {
            ColName = ColName.Trim();
            if (DT.Columns.Contains(ColName))
            {
                if (DT.Rows.Count > 0)
                {
                    return DT.Rows[0][ColName].ToString();
                }
            }
            return defStr;
        }

        /// <summary>获取DataTable内的第一行的指定列索引的值，如果没有找到指定的列则返回指定字符串</summary>
        /// <param name="DT">一个DataTable实例的引用</param>
        /// <param name="ColIndex">列的索引</param>
        /// <param name="defStr">默认值</param>
        /// <returns>返回DataTable内的第一行的指定列的值</returns>
        public static string GetStrs(DataTable DT, int ColIndex, string defStr)
        {
            if (DT.Columns.Count > ColIndex && ColIndex > -1)
            {
                if (DT.Rows.Count > 0)
                {
                    return DT.Rows[0][ColIndex].ToString();
                }
            }
            return defStr;
        }

        /// <summary>获取DataTable内的指定行的指定列的值，如果没有找到指定的列则返回指定字符串</summary>
        /// <param name="DT">一个DataTable实例的引用</param>
        /// <param name="ColName">列名</param>
        /// <param name="RowIndex">行的索引</param>
        /// <param name="defStr">默认值</param>
        /// <returns>返回DataTable内的指定行的指定列的值</returns>
        public static string GetStrs(DataTable DT, string ColName, int RowIndex, string defStr)
        {
            ColName = ColName.Trim();
            if (DT.Columns.Contains(ColName))
            {
                if (DT.Rows.Count > RowIndex && RowIndex > -1)
                {
                    return DT.Rows[RowIndex][ColName].ToString();
                }
            }
            return defStr;
        }

        /// <summary>获取DataTable内的指定行的指定列索引的值，如果没有找到指定的列则返回指定字符串</summary>
        /// <param name="DT">一个DataTable实例的引用</param>
        /// <param name="ColIndex">列的索引</param>
        /// <param name="RowIndex">行的索引</param>
        /// <param name="defStr">默认值</param>
        /// <returns>返回DataTable内的指定行的指定列的值</returns>
        public static string GetStrs(DataTable DT, int ColIndex, int RowIndex, string defStr)
        {
            if (DT.Columns.Count > ColIndex && ColIndex > -1)
            {
                if (DT.Rows.Count > RowIndex && RowIndex > -1)
                {
                    return DT.Rows[RowIndex][ColIndex].ToString();
                }
            }
            return defStr;
        }

        /// <summary>获取DataTable内的第一行的指定列的值，如果没有找到指定的列则返回指定字符串</summary>
        /// <param name="filter">要用来筛选行的条件</param>
        /// <param name="DT">一个DataTable实例的引用</param>
        /// <param name="ColName">列名</param>
        /// <param name="defStr">默认值</param>
        /// <returns>返回DataTable内的第一行的指定列的值</returns>
        public static string GetStrs(string filter, DataTable DT, string ColName, string defStr)
        {
            ColName = ColName.Trim();
            if (DT.Columns.Contains(ColName))
            {
                DataRow[] dRow = DT.Select(filter);
                if (dRow.Length > 0)
                {
                    return dRow[0][ColName].ToString();
                }
            }
            return defStr;
        }

        /// <summary>获取DataTable内的第一行的指定列索引的值，如果没有找到指定的列则返回指定字符串</summary>
        /// <param name="filter">要用来筛选行的条件</param>
        /// <param name="DT">一个DataTable实例的引用</param>
        /// <param name="ColIndex">列的索引</param>
        /// <param name="defStr">默认值</param>
        /// <returns>返回DataTable内的第一行的指定列的值</returns>
        public static string GetStrs(string filter, DataTable DT, int ColIndex, string defStr)
        {
            if (DT.Columns.Count > ColIndex && ColIndex > -1)
            {
                DataRow[] dRow = DT.Select(filter);
                if (dRow.Length > 0)
                {
                    return dRow[0][ColIndex].ToString();
                }
            }
            return defStr;
        }

        /// <summary>获取DataTable内的指定行的指定列的值，如果没有找到指定的列则返回指定字符串</summary>
        /// <param name="filter">要用来筛选行的条件</param>
        /// <param name="DT">一个DataTable实例的引用</param>
        /// <param name="ColName">列名</param>
        /// <param name="RowIndex">行的索引</param>
        /// <param name="defStr">默认值</param>
        /// <returns>返回DataTable内的指定行的指定列的值</returns>
        public static string GetStrs(string filter, DataTable DT, string ColName, int RowIndex, string defStr)
        {
            ColName = ColName.Trim();
            if (DT.Columns.Contains(ColName))
            {
                DataRow[] dRow = DT.Select(filter);
                if (dRow.Length > RowIndex && RowIndex > -1)
                {
                    return dRow[RowIndex][ColName].ToString();
                }
            }
            return defStr;
        }

        /// <summary>获取DataTable内的指定行的指定列索引的值，如果没有找到指定的列则返回指定字符串</summary>
        /// <param name="filter">要用来筛选行的条件</param>
        /// <param name="DT">一个DataTable实例的引用</param>
        /// <param name="ColIndex">列的索引</param>
        /// <param name="RowIndex">行的索引</param>
        /// <param name="defStr">默认值</param>
        /// <returns>返回DataTable内的指定行的指定列的值</returns>
        public static string GetStrs(string filter, DataTable DT, int ColIndex, int RowIndex, string defStr)
        {
            if (DT.Columns.Count > ColIndex && ColIndex > -1)
            {
                DataRow[] dRow = DT.Select(filter);
                if (dRow.Length > RowIndex && RowIndex > -1)
                {
                    return dRow[RowIndex][ColIndex].ToString();
                }
            }
            return defStr;
        }

        /// <summary>获取DataTable内的第一行的指定列的值，如果没有找到指定的列则返回指定字符串</summary>
        /// <param name="filter">要用来筛选行的条件</param>
        /// <param name="sort">一个字符串，它指定列和排序方向</param>
        /// <param name="DT">一个DataTable实例的引用</param>
        /// <param name="ColName">列名</param>
        /// <param name="defStr">默认值</param>
        /// <returns>返回DataTable内的第一行的指定列的值</returns>
        public static string GetStrs(string filter, string sort, DataTable DT, string ColName, string defStr)
        {
            ColName = ColName.Trim();
            if (DT.Columns.Contains(ColName))
            {
                DataRow[] dRow = DT.Select(filter, sort);
                if (dRow.Length > 0)
                {
                    return dRow[0][ColName].ToString();
                }
            }
            return defStr;
        }

        /// <summary>获取DataTable内的第一行的指定列索引的值，如果没有找到指定的列则返回指定字符串</summary>
        /// <param name="filter">要用来筛选行的条件</param>
        /// <param name="sort">一个字符串，它指定列和排序方向</param>
        /// <param name="DT">一个DataTable实例的引用</param>
        /// <param name="ColIndex">列的索引</param>
        /// <param name="defStr">默认值</param>
        /// <returns>返回DataTable内的第一行的指定列的值</returns>
        public static string GetStrs(string filter, string sort, DataTable DT, int ColIndex, string defStr)
        {
            if (DT.Columns.Count > ColIndex && ColIndex > -1)
            {
                DataRow[] dRow = DT.Select(filter, sort);
                if (dRow.Length > 0)
                {
                    return dRow[0][ColIndex].ToString();
                }
            }
            return defStr;
        }

        /// <summary>获取DataTable内的指定行的指定列的值，如果没有找到指定的列则返回指定字符串</summary>
        /// <param name="filter">要用来筛选行的条件</param>
        /// <param name="sort">一个字符串，它指定列和排序方向</param>
        /// <param name="DT">一个DataTable实例的引用</param>
        /// <param name="ColName">列名</param>
        /// <param name="RowIndex">行的索引</param>
        /// <param name="defStr">默认值</param>
        /// <returns>返回DataTable内的指定行的指定列的值</returns>
        public static string GetStrs(string filter, string sort, DataTable DT, string ColName, int RowIndex, string defStr)
        {
            ColName = ColName.Trim();
            if (DT.Columns.Contains(ColName))
            {
                DataRow[] dRow = DT.Select(filter, sort);
                if (dRow.Length > RowIndex && RowIndex > -1)
                {
                    return dRow[RowIndex][ColName].ToString();
                }
            }
            return defStr;
        }

        /// <summary>获取DataTable内的指定行的指定列索引的值，如果没有找到指定的列则返回指定字符串</summary>
        /// <param name="filter">要用来筛选行的条件</param>
        /// <param name="sort">一个字符串，它指定列和排序方向</param>
        /// <param name="DT">一个DataTable实例的引用</param>
        /// <param name="ColIndex">列的索引</param>
        /// <param name="RowIndex">行的索引</param>
        /// <param name="defStr">默认值</param>
        /// <returns>返回DataTable内的指定行的指定列的值</returns>
        public static string GetStrs(string filter, string sort, DataTable DT, int ColIndex, int RowIndex, string defStr)
        {
            if (DT.Columns.Count > ColIndex && ColIndex > -1)
            {
                DataRow[] dRow = DT.Select(filter, sort);
                if (dRow.Length > RowIndex && RowIndex > -1)
                {
                    return dRow[RowIndex][ColIndex].ToString();
                }
            }
            return defStr;
        }

        /// <summary>获取DataTable内的第一行的指定列的值，如果没有找到指定的列则返回指定字符串</summary>
        /// <param name="filter">要用来筛选行的条件</param>
        /// <param name="sort">一个字符串，它指定列和排序方向</param>
        /// <param name="dvrs">DataViewRowState 值之一</param>
        /// <param name="DT">一个DataTable实例的引用</param>
        /// <param name="ColName">列名</param>
        /// <param name="defStr">默认值</param>
        /// <returns>返回DataTable内的第一行的指定列的值</returns>
        public static string GetStrs(string filter, string sort, DataViewRowState dvrs, DataTable DT, string ColName, string defStr)
        {
            ColName = ColName.Trim();
            if (DT.Columns.Contains(ColName))
            {
                DataRow[] dRow = DT.Select(filter, sort, dvrs);
                if (dRow.Length > 0)
                {
                    return dRow[0][ColName].ToString();
                }
            }
            return defStr;
        }

        /// <summary>获取DataTable内的第一行的指定列索引的值，如果没有找到指定的列则返回指定字符串</summary>
        /// <param name="filter">要用来筛选行的条件</param>
        /// <param name="sort">一个字符串，它指定列和排序方向</param>
        /// <param name="dvrs">DataViewRowState 值之一</param>
        /// <param name="DT">一个DataTable实例的引用</param>
        /// <param name="ColIndex">列的索引</param>
        /// <param name="defStr">默认值</param>
        /// <returns>返回DataTable内的第一行的指定列的值</returns>
        public static string GetStrs(string filter, string sort, DataViewRowState dvrs, DataTable DT, int ColIndex, string defStr)
        {
            if (DT.Columns.Count > ColIndex && ColIndex > -1)
            {
                DataRow[] dRow = DT.Select(filter, sort, dvrs);
                if (dRow.Length > 0)
                {
                    return dRow[0][ColIndex].ToString();
                }
            }
            return defStr;
        }

        /// <summary>获取DataTable内的指定行的指定列的值，如果没有找到指定的列则返回指定字符串</summary>
        /// <param name="filter">要用来筛选行的条件</param>
        /// <param name="sort">一个字符串，它指定列和排序方向</param>
        /// <param name="dvrs">DataViewRowState 值之一</param>
        /// <param name="DT">一个DataTable实例的引用</param>
        /// <param name="ColName">列名</param>
        /// <param name="RowIndex">行的索引</param>
        /// <param name="defStr">默认值</param>
        /// <returns>返回DataTable内的指定行的指定列的值</returns>
        public static string GetStrs(string filter, string sort, DataViewRowState dvrs, DataTable DT, string ColName, int RowIndex, string defStr)
        {
            ColName = ColName.Trim();
            if (DT.Columns.Contains(ColName))
            {
                DataRow[] dRow = DT.Select(filter, sort, dvrs);
                if (dRow.Length > RowIndex && RowIndex > -1)
                {
                    return dRow[RowIndex][ColName].ToString();
                }
            }
            return defStr;
        }

        /// <summary>获取DataTable内的指定行的指定列索引的值，如果没有找到指定的列则返回指定字符串</summary>
        /// <param name="filter">要用来筛选行的条件</param>
        /// <param name="sort">一个字符串，它指定列和排序方向</param>
        /// <param name="dvrs">DataViewRowState 值之一</param>
        /// <param name="DT">一个DataTable实例的引用</param>
        /// <param name="ColIndex">列的索引</param>
        /// <param name="RowIndex">行的索引</param>
        /// <param name="defStr">默认值</param>
        /// <returns>返回DataTable内的指定行的指定列的值</returns>
        public static string GetStrs(string filter, string sort, DataViewRowState dvrs, DataTable DT, int ColIndex, int RowIndex, string defStr)
        {
            if (DT.Columns.Count > ColIndex && ColIndex > -1)
            {
                DataRow[] dRow = DT.Select(filter, sort, dvrs);
                if (dRow.Length > RowIndex && RowIndex > -1)
                {
                    return dRow[RowIndex][ColIndex].ToString();
                }
            }
            return defStr;
        }

        #endregion

        #region 获取DataRow内某列的值，并删除该值左右空白。如果该列不存在则返回空字符串

        /// <summary>获取DataRow指定列的值，并删除左右空白。如果没有找到指定的列则返回空字符串</summary>
        /// <param name="dr">一个DataRow</param>
        /// <param name="ColName">列名</param>
        /// <returns>返回DataRow指定列的值</returns>
        public static string GetStr(DataRow dr, string ColName)
        {
            ColName = ColName.Trim();
            if (dr.Table.Columns.Contains(ColName))
            {
                return dr[ColName].ToString().Trim();
            }
            return "";
        }

        /// <summary>获取DataRow指定列索引的值，并删除左右空白。如果没有找到指定的列则返回空字符串</summary>
        /// <param name="dr">一个DataRow</param>
        /// <param name="ColIndex">列的索引</param>
        /// <returns>返回DataRow指定列的值</returns>
        public static string GetStr(DataRow dr, int ColIndex)
        {
            if (dr.Table.Columns.Count > ColIndex && ColIndex > -1)
            {
                return dr[ColIndex].ToString().Trim();
            }
            return "";
        }

        /// <summary>获取DataRow数组第一行指定列的值，并删除左右空白。如果没有找到指定的列则返回空字符串</summary>
        /// <param name="dr">一个DataRow</param>
        /// <param name="ColName">列名</param>
        /// <returns>返回DataRow指定列的值</returns>
        public static string GetStr(DataRow[] dr, string ColName)
        {
            ColName = ColName.Trim();
            if (dr.Length > 0)
            {
                if (dr[0].Table.Columns.Contains(ColName))
                {
                    return dr[0][ColName].ToString().Trim();
                }
            }
            return "";
        }

        /// <summary>获取DataRow数组第一行指定列索引的值，并删除左右空白。如果没有找到指定的列则返回空字符串</summary>
        /// <param name="dr">一个DataRow</param>
        /// <param name="ColIndex">列的索引</param>
        /// <returns>返回DataRow指定列的值</returns>
        public static string GetStr(DataRow[] dr, int ColIndex)
        {
            if (dr.Length > 0)
            {
                if (dr[0].Table.Columns.Count > ColIndex && ColIndex > -1)
                {
                    return dr[0][ColIndex].ToString().Trim();
                }
            }
            return "";
        }

        /// <summary>获取DataRow数组指定行的指定列的值，并删除左右空白。如果没有找到指定的列则返回空字符串</summary>
        /// <param name="dr">一个DataRow数组</param>
        /// <param name="ColName">列名</param>
        /// <param name="RowIndex">行的索引</param>
        /// <returns>返回DataRow指定行的指定列的值</returns>
        public static string GetStr(DataRow[] dr, string ColName, int RowIndex)
        {
            ColName = ColName.Trim();
            if (dr.Length > RowIndex && RowIndex > -1)
            {
                if (dr[RowIndex].Table.Columns.Contains(ColName))
                {
                    return dr[RowIndex][ColName].ToString().Trim();
                }
            }
            return "";
        }

        /// <summary>获取DataRow数组指定行的指定列索引的值，并删除左右空白。如果没有找到指定的列则返回空字符串</summary>
        /// <param name="dr">一个DataRow数组</param>
        /// <param name="ColIndex">列的索引</param>
        /// <param name="RowIndex">行的索引</param>
        /// <returns>返回DataRow指定行的指定列索引的值</returns>
        public static string GetStr(DataRow[] dr, int ColIndex, int RowIndex)
        {
            if (dr.Length > RowIndex && RowIndex > -1)
            {
                if (dr[RowIndex].Table.Columns.Count > ColIndex && ColIndex > -1)
                {
                    return dr[RowIndex][ColIndex].ToString().Trim();
                }
            }
            return "";
        }

        #endregion

        #region 获取DataRow内某列的值，并删除该值左右空白。如果该列不存在则返回指定字符串

        /// <summary>获取DataRow指定列的值，并删除左右空白。如果没有找到指定的列则返回指定字符串</summary>
        /// <param name="dr">一个DataRow</param>
        /// <param name="ColName">列名</param>
        /// <param name="defStr">默认值</param>
        /// <returns>返回DataRow指定列的值</returns>
        public static string GetStr(DataRow dr, string ColName, string defStr)
        {
            ColName = ColName.Trim();
            if (dr.Table.Columns.Contains(ColName))
            {
                return dr[ColName].ToString().Trim();
            }
            return defStr;
        }

        /// <summary>获取DataRow指定列索引的值，并删除左右空白。如果没有找到指定的列则返回指定字符串</summary>
        /// <param name="dr">一个DataRow</param>
        /// <param name="ColIndex">列的索引</param>
        /// <param name="defStr">默认值</param>
        /// <returns>返回DataRow指定列的值</returns>
        public static string GetStr(DataRow dr, int ColIndex, string defStr)
        {
            if (dr.Table.Columns.Count > ColIndex && ColIndex > -1)
            {
                return dr[ColIndex].ToString().Trim();
            }
            return defStr;
        }

        /// <summary>获取DataRow数组第一行指定列的值，并删除左右空白。如果没有找到指定的列则返回指定字符串</summary>
        /// <param name="dr">一个DataRow</param>
        /// <param name="ColName">列名</param>
        /// <param name="defStr">默认值</param>
        /// <returns>返回DataRow指定列的值</returns>
        public static string GetStr(DataRow[] dr, string ColName, string defStr)
        {
            ColName = ColName.Trim();
            if (dr.Length > 0)
            {
                if (dr[0].Table.Columns.Contains(ColName))
                {
                    return dr[0][ColName].ToString().Trim();
                }
            }
            return defStr;
        }

        /// <summary>获取DataRow数组第一行指定列索引的值，并删除左右空白。如果没有找到指定的列则返回指定字符串</summary>
        /// <param name="dr">一个DataRow</param>
        /// <param name="ColIndex">列的索引</param>
        /// <param name="defStr">默认值</param>
        /// <returns>返回DataRow指定列的值</returns>
        public static string GetStr(DataRow[] dr, int ColIndex, string defStr)
        {
            if (dr.Length > 0)
            {
                if (dr[0].Table.Columns.Count > ColIndex && ColIndex > -1)
                {
                    return dr[0][ColIndex].ToString().Trim();
                }
            }
            return defStr;
        }

        /// <summary>获取DataRow数组指定行的指定列的值，并删除左右空白。如果没有找到指定的列则返回指定字符串</summary>
        /// <param name="dr">一个DataRow数组</param>
        /// <param name="ColName">列名</param>
        /// <param name="RowIndex">行的索引</param>
        /// <param name="defStr">默认值</param>
        /// <returns>返回DataRow指定行的指定列的值</returns>
        public static string GetStr(DataRow[] dr, string ColName, int RowIndex, string defStr)
        {
            ColName = ColName.Trim();
            if (dr.Length > RowIndex && RowIndex > -1)
            {
                if (dr[RowIndex].Table.Columns.Contains(ColName))
                {
                    return dr[RowIndex][ColName].ToString().Trim();
                }
            }
            return defStr;
        }

        /// <summary>获取DataRow数组指定行的指定列索引的值，并删除左右空白。如果没有找到指定的列则返回指定字符串</summary>
        /// <param name="dr">一个DataRow数组</param>
        /// <param name="ColIndex">列的索引</param>
        /// <param name="RowIndex">行的索引</param>
        /// <param name="defStr">默认值</param>
        /// <returns>返回DataRow指定行的指定列索引的值</returns>
        public static string GetStr(DataRow[] dr, int ColIndex, int RowIndex, string defStr)
        {
            if (dr.Length > RowIndex && RowIndex > -1)
            {
                if (dr[RowIndex].Table.Columns.Count > ColIndex && ColIndex > -1)
                {
                    return dr[RowIndex][ColIndex].ToString().Trim();
                }
            }
            return defStr;
        }

        #endregion

        #region 获取DataRow内某列的值。如果该列不存在则返回空字符串

        /// <summary>获取DataRow指定列的值。如果没有找到指定的列则返回空字符串</summary>
        /// <param name="dr">一个DataRow</param>
        /// <param name="ColName">列名</param>
        /// <returns>返回DataRow指定列的值</returns>
        public static string GetStrs(DataRow dr, string ColName)
        {
            ColName = ColName.Trim();
            if (dr.Table.Columns.Contains(ColName))
            {
                return dr[ColName].ToString();
            }
            return "";
        }

        /// <summary>获取DataRow指定列索引的值。如果没有找到指定的列则返回空字符串</summary>
        /// <param name="dr">一个DataRow</param>
        /// <param name="ColIndex">列的索引</param>
        /// <returns>返回DataRow指定列的值</returns>
        public static string GetStrs(DataRow dr, int ColIndex)
        {
            if (dr.Table.Columns.Count > ColIndex && ColIndex > -1)
            {
                return dr[ColIndex].ToString();
            }
            return "";
        }

        /// <summary>获取DataRow数组第一行指定列的值。如果没有找到指定的列则返回空字符串</summary>
        /// <param name="dr">一个DataRow</param>
        /// <param name="ColName">列名</param>
        /// <returns>返回DataRow指定列的值</returns>
        public static string GetStrs(DataRow[] dr, string ColName)
        {
            ColName = ColName.Trim();
            if (dr.Length > 0)
            {
                if (dr[0].Table.Columns.Contains(ColName))
                {
                    return dr[0][ColName].ToString();
                }
            }
            return "";
        }

        /// <summary>获取DataRow数组第一行指定列索引的值。如果没有找到指定的列则返回空字符串</summary>
        /// <param name="dr">一个DataRow</param>
        /// <param name="ColIndex">列的索引</param>
        /// <returns>返回DataRow指定列的值</returns>
        public static string GetStrs(DataRow[] dr, int ColIndex)
        {
            if (dr.Length > 0)
            {
                if (dr[0].Table.Columns.Count > ColIndex && ColIndex > -1)
                {
                    return dr[0][ColIndex].ToString();
                }
            }
            return "";
        }

        /// <summary>获取DataRow数组指定行的指定列的值。如果没有找到指定的列则返回空字符串</summary>
        /// <param name="dr">一个DataRow数组</param>
        /// <param name="ColName">列名</param>
        /// <param name="RowIndex">行的索引</param>
        /// <returns>返回DataRow指定行的指定列的值</returns>
        public static string GetStrs(DataRow[] dr, string ColName, int RowIndex)
        {
            ColName = ColName.Trim();
            if (dr.Length > RowIndex && RowIndex > -1)
            {
                if (dr[RowIndex].Table.Columns.Contains(ColName))
                {
                    return dr[RowIndex][ColName].ToString();
                }
            }
            return "";
        }

        /// <summary>获取DataRow数组指定行的指定列索引的值。如果没有找到指定的列则返回空字符串</summary>
        /// <param name="dr">一个DataRow数组</param>
        /// <param name="ColIndex">列的索引</param>
        /// <param name="RowIndex">行的索引</param>
        /// <returns>返回DataRow指定行的指定列索引的值</returns>
        public static string GetStrs(DataRow[] dr, int ColIndex, int RowIndex)
        {
            if (dr.Length > RowIndex && RowIndex > -1)
            {
                if (dr[RowIndex].Table.Columns.Count > ColIndex && ColIndex > -1)
                {
                    return dr[RowIndex][ColIndex].ToString();
                }
            }
            return "";
        }

        #endregion

        #region 获取DataRow内某列的值。如果该列不存在则返回指定字符串

        /// <summary>获取DataRow指定列的值。如果没有找到指定的列则返回指定字符串</summary>
        /// <param name="dr">一个DataRow</param>
        /// <param name="ColName">列名</param>
        /// <param name="defStr">默认值</param>
        /// <returns>返回DataRow指定列的值</returns>
        public static string GetStrs(DataRow dr, string ColName, string defStr)
        {
            ColName = ColName.Trim();
            if (dr.Table.Columns.Contains(ColName))
            {
                return dr[ColName].ToString();
            }
            return defStr;
        }

        /// <summary>获取DataRow指定列索引的值。如果没有找到指定的列则返回指定字符串</summary>
        /// <param name="dr">一个DataRow</param>
        /// <param name="ColIndex">列的索引</param>
        /// <param name="defStr">默认值</param>
        /// <returns>返回DataRow指定列的值</returns>
        public static string GetStrs(DataRow dr, int ColIndex, string defStr)
        {
            if (dr.Table.Columns.Count > ColIndex && ColIndex > -1)
            {
                return dr[ColIndex].ToString();
            }
            return defStr;
        }

        /// <summary>获取DataRow数组第一行指定列的值。如果没有找到指定的列则返回指定字符串</summary>
        /// <param name="dr">一个DataRow</param>
        /// <param name="ColName">列名</param>
        /// <param name="defStr">默认值</param>
        /// <returns>返回DataRow指定列的值</returns>
        public static string GetStrs(DataRow[] dr, string ColName, string defStr)
        {
            ColName = ColName.Trim();
            if (dr.Length > 0)
            {
                if (dr[0].Table.Columns.Contains(ColName))
                {
                    return dr[0][ColName].ToString();
                }
            }
            return defStr;
        }

        /// <summary>获取DataRow数组第一行指定列索引的值。如果没有找到指定的列则返回指定字符串</summary>
        /// <param name="dr">一个DataRow</param>
        /// <param name="ColIndex">列的索引</param>
        /// <param name="defStr">默认值</param>
        /// <returns>返回DataRow指定列的值</returns>
        public static string GetStrs(DataRow[] dr, int ColIndex, string defStr)
        {
            if (dr.Length > 0)
            {
                if (dr[0].Table.Columns.Count > ColIndex && ColIndex > -1)
                {
                    return dr[0][ColIndex].ToString();
                }
            }
            return defStr;
        }

        /// <summary>获取DataRow数组指定行的指定列的值。如果没有找到指定的列则返回指定字符串</summary>
        /// <param name="dr">一个DataRow数组</param>
        /// <param name="ColName">列名</param>
        /// <param name="RowIndex">行的索引</param>
        /// <param name="defStr">默认值</param>
        /// <returns>返回DataRow指定行的指定列的值</returns>
        public static string GetStrs(DataRow[] dr, string ColName, int RowIndex, string defStr)
        {
            ColName = ColName.Trim();
            if (dr.Length > RowIndex && RowIndex > -1)
            {
                if (dr[RowIndex].Table.Columns.Contains(ColName))
                {
                    return dr[RowIndex][ColName].ToString();
                }
            }
            return defStr;
        }

        /// <summary>获取DataRow数组指定行的指定列索引的值。如果没有找到指定的列则返回指定字符串</summary>
        /// <param name="dr">一个DataRow数组</param>
        /// <param name="ColIndex">列的索引</param>
        /// <param name="RowIndex">行的索引</param>
        /// <param name="defStr">默认值</param>
        /// <returns>返回DataRow指定行的指定列索引的值</returns>
        public static string GetStrs(DataRow[] dr, int ColIndex, int RowIndex, string defStr)
        {
            if (dr.Length > RowIndex && RowIndex > -1)
            {
                if (dr[RowIndex].Table.Columns.Count > ColIndex && ColIndex > -1)
                {
                    return dr[RowIndex][ColIndex].ToString();
                }
            }
            return defStr;
        }

        #endregion

        #region 获取DataTable内某列的值，并删除该值左右空白。如果该列不存在则发生错误

        /// <summary>获取DataTable内的第一行的指定列的值，并删除左右空白。</summary>
        /// <param name="DT">一个DataTable实例的引用</param>
        /// <param name="ColName">列名</param>
        /// <returns>返回DataTable内的第一行的指定列的值</returns>
        public static string GetVal(DataTable DT, string ColName)
        {
            return DT.Rows[0][ColName.Trim()].ToString().Trim();
        }

        /// <summary>获取DataTable内的第一行的指定列索引的值，并删除左右空白。</summary>
        /// <param name="DT">一个DataTable实例的引用</param>
        /// <param name="ColIndex">列的索引</param>
        /// <returns>返回DataTable内的第一行的指定列的值</returns>
        public static string GetVal(DataTable DT, int ColIndex)
        {
            return DT.Rows[0][ColIndex].ToString().Trim();
        }

        /// <summary>获取DataTable内的指定行的指定列的值，并删除左右空白。</summary>
        /// <param name="DT">一个DataTable实例的引用</param>
        /// <param name="ColName">列名</param>
        /// <param name="RowIndex">行的索引</param>
        /// <returns>返回DataTable内的指定行的指定列的值</returns>
        public static string GetVal(DataTable DT, string ColName, int RowIndex)
        {
            return DT.Rows[RowIndex][ColName.Trim()].ToString().Trim();
        }

        /// <summary>获取DataTable内的指定行的指定列索引的值，并删除左右空白。</summary>
        /// <param name="DT">一个DataTable实例的引用</param>
        /// <param name="ColIndex">列的索引</param>
        /// <param name="RowIndex">行的索引</param>
        /// <returns>返回DataTable内的指定行的指定列的值</returns>
        public static string GetVal(DataTable DT, int ColIndex, int RowIndex)
        {
            return DT.Rows[RowIndex][ColIndex].ToString().Trim();
        }

        /// <summary>获取DataTable内的第一行的指定列的值，并删除左右空白。</summary>
        /// <param name="filter">要用来筛选行的条件</param>
        /// <param name="DT">一个DataTable实例的引用</param>
        /// <param name="ColName">列名</param>
        /// <returns>返回DataTable内的第一行的指定列的值</returns>
        public static string GetVal(string filter, DataTable DT, string ColName)
        {
            DataRow[] dRow = DT.Select(filter);
            if (dRow.Length > 0)
            {
                return dRow[0][ColName.Trim()].ToString().Trim();
            }
            return "";
        }

        /// <summary>获取DataTable内的第一行的指定列索引的值，并删除左右空白。</summary>
        /// <param name="filter">要用来筛选行的条件</param>
        /// <param name="DT">一个DataTable实例的引用</param>
        /// <param name="ColIndex">列的索引</param>
        /// <returns>返回DataTable内的第一行的指定列的值</returns>
        public static string GetVal(string filter, DataTable DT, int ColIndex)
        {
            DataRow[] dRow = DT.Select(filter);
            if (dRow.Length > 0)
            {
                return dRow[0][ColIndex].ToString().Trim();
            }
            return "";
        }

        /// <summary>获取DataTable内的指定行的指定列的值，并删除左右空白。</summary>
        /// <param name="filter">要用来筛选行的条件</param>
        /// <param name="DT">一个DataTable实例的引用</param>
        /// <param name="ColName">列名</param>
        /// <param name="RowIndex">行的索引</param>
        /// <returns>返回DataTable内的指定行的指定列的值</returns>
        public static string GetVal(string filter, DataTable DT, string ColName, int RowIndex)
        {
            DataRow[] dRow = DT.Select(filter);
            if (dRow.Length > RowIndex && RowIndex > -1)
            {
                return dRow[RowIndex][ColName.Trim()].ToString().Trim();
            }
            return "";
        }

        /// <summary>获取DataTable内的指定行的指定列索引的值，并删除左右空白。</summary>
        /// <param name="filter">要用来筛选行的条件</param>
        /// <param name="DT">一个DataTable实例的引用</param>
        /// <param name="ColIndex">列的索引</param>
        /// <param name="RowIndex">行的索引</param>
        /// <returns>返回DataTable内的指定行的指定列的值</returns>
        public static string GetVal(string filter, DataTable DT, int ColIndex, int RowIndex)
        {
            DataRow[] dRow = DT.Select(filter);
            if (dRow.Length > RowIndex && RowIndex > -1)
            {
                return dRow[RowIndex][ColIndex].ToString().Trim();
            }
            return "";
        }

        /// <summary>获取DataTable内的第一行的指定列的值，并删除左右空白。</summary>
        /// <param name="filter">要用来筛选行的条件</param>
        /// <param name="sort">一个字符串，它指定列和排序方向</param>
        /// <param name="DT">一个DataTable实例的引用</param>
        /// <param name="ColName">列名</param>
        /// <returns>返回DataTable内的第一行的指定列的值</returns>
        public static string GetVal(string filter, string sort, DataTable DT, string ColName)
        {
            DataRow[] dRow = DT.Select(filter, sort);
            if (dRow.Length > 0)
            {
                return dRow[0][ColName.Trim()].ToString().Trim();
            }
            return "";
        }

        /// <summary>获取DataTable内的第一行的指定列索引的值，并删除左右空白。</summary>
        /// <param name="filter">要用来筛选行的条件</param>
        /// <param name="sort">一个字符串，它指定列和排序方向</param>
        /// <param name="DT">一个DataTable实例的引用</param>
        /// <param name="ColIndex">列的索引</param>
        /// <returns>返回DataTable内的第一行的指定列的值</returns>
        public static string GetVal(string filter, string sort, DataTable DT, int ColIndex)
        {
            DataRow[] dRow = DT.Select(filter, sort);
            if (dRow.Length > 0)
            {
                return dRow[0][ColIndex].ToString().Trim();
            }
            return "";
        }

        /// <summary>获取DataTable内的指定行的指定列的值，并删除左右空白。</summary>
        /// <param name="filter">要用来筛选行的条件</param>
        /// <param name="sort">一个字符串，它指定列和排序方向</param>
        /// <param name="DT">一个DataTable实例的引用</param>
        /// <param name="ColName">列名</param>
        /// <param name="RowIndex">行的索引</param>
        /// <returns>返回DataTable内的指定行的指定列的值</returns>
        public static string GetVal(string filter, string sort, DataTable DT, string ColName, int RowIndex)
        {
            DataRow[] dRow = DT.Select(filter, sort);
            if (dRow.Length > RowIndex && RowIndex > -1)
            {
                return dRow[RowIndex][ColName.Trim()].ToString().Trim();
            }
            return "";
        }

        /// <summary>获取DataTable内的指定行的指定列索引的值，并删除左右空白。</summary>
        /// <param name="filter">要用来筛选行的条件</param>
        /// <param name="sort">一个字符串，它指定列和排序方向</param>
        /// <param name="DT">一个DataTable实例的引用</param>
        /// <param name="ColIndex">列的索引</param>
        /// <param name="RowIndex">行的索引</param>
        /// <returns>返回DataTable内的指定行的指定列的值</returns>
        public static string GetVal(string filter, string sort, DataTable DT, int ColIndex, int RowIndex)
        {
            DataRow[] dRow = DT.Select(filter, sort);
            if (dRow.Length > RowIndex && RowIndex > -1)
            {
                return dRow[RowIndex][ColIndex].ToString().Trim();
            }
            return "";
        }

        /// <summary>获取DataTable内的第一行的指定列的值，并删除左右空白。</summary>
        /// <param name="filter">要用来筛选行的条件</param>
        /// <param name="sort">一个字符串，它指定列和排序方向</param>
        /// <param name="dvrs">DataViewRowState 值之一</param>
        /// <param name="DT">一个DataTable实例的引用</param>
        /// <param name="ColName">列名</param>
        /// <returns>返回DataTable内的第一行的指定列的值</returns>
        public static string GetVal(string filter, string sort, DataViewRowState dvrs, DataTable DT, string ColName)
        {
            DataRow[] dRow = DT.Select(filter, sort, dvrs);
            if (dRow.Length > 0)
            {
                return dRow[0][ColName.Trim()].ToString().Trim();
            }
            return "";
        }

        /// <summary>获取DataTable内的第一行的指定列索引的值，并删除左右空白。</summary>
        /// <param name="filter">要用来筛选行的条件</param>
        /// <param name="sort">一个字符串，它指定列和排序方向</param>
        /// <param name="dvrs">DataViewRowState 值之一</param>
        /// <param name="DT">一个DataTable实例的引用</param>
        /// <param name="ColIndex">列的索引</param>
        /// <returns>返回DataTable内的第一行的指定列的值</returns>
        public static string GetVal(string filter, string sort, DataViewRowState dvrs, DataTable DT, int ColIndex)
        {
            DataRow[] dRow = DT.Select(filter, sort, dvrs);
            if (dRow.Length > 0)
            {
                return dRow[0][ColIndex].ToString().Trim();
            }
            return "";
        }

        /// <summary>获取DataTable内的指定行的指定列的值，并删除左右空白。</summary>
        /// <param name="filter">要用来筛选行的条件</param>
        /// <param name="sort">一个字符串，它指定列和排序方向</param>
        /// <param name="dvrs">DataViewRowState 值之一</param>
        /// <param name="DT">一个DataTable实例的引用</param>
        /// <param name="ColName">列名</param>
        /// <param name="RowIndex">行的索引</param>
        /// <returns>返回DataTable内的指定行的指定列的值</returns>
        public static string GetVal(string filter, string sort, DataViewRowState dvrs, DataTable DT, string ColName, int RowIndex)
        {
            DataRow[] dRow = DT.Select(filter, sort, dvrs);
            if (dRow.Length > RowIndex && RowIndex > -1)
            {
                return dRow[RowIndex][ColName.Trim()].ToString().Trim();
            }
            return "";
        }

        /// <summary>获取DataTable内的指定行的指定列索引的值，并删除左右空白。</summary>
        /// <param name="filter">要用来筛选行的条件</param>
        /// <param name="sort">一个字符串，它指定列和排序方向</param>
        /// <param name="dvrs">DataViewRowState 值之一</param>
        /// <param name="DT">一个DataTable实例的引用</param>
        /// <param name="ColIndex">列的索引</param>
        /// <param name="RowIndex">行的索引</param>
        /// <returns>返回DataTable内的指定行的指定列的值</returns>
        public static string GetVal(string filter, string sort, DataViewRowState dvrs, DataTable DT, int ColIndex, int RowIndex)
        {
            DataRow[] dRow = DT.Select(filter, sort, dvrs);
            if (dRow.Length > RowIndex && RowIndex > -1)
            {
                return dRow[RowIndex][ColIndex].ToString().Trim();
            }
            return "";
        }

        #endregion

        #region 获取DataTable内某列的值。如果该列不存在则发生错误

        /// <summary>获取DataTable内的第一行的指定列的值。</summary>
        /// <param name="DT">一个DataTable实例的引用</param>
        /// <param name="ColName">列名</param>
        /// <returns>返回DataTable内的第一行的指定列的值</returns>
        public static string GetVals(DataTable DT, string ColName)
        {
            return DT.Rows[0][ColName.Trim()].ToString();
        }

        /// <summary>获取DataTable内的第一行的指定列索引的值。</summary>
        /// <param name="DT">一个DataTable实例的引用</param>
        /// <param name="ColIndex">列的索引</param>
        /// <returns>返回DataTable内的第一行的指定列的值</returns>
        public static string GetVals(DataTable DT, int ColIndex)
        {
            return DT.Rows[0][ColIndex].ToString();
        }

        /// <summary>获取DataTable内的指定行的指定列的值。</summary>
        /// <param name="DT">一个DataTable实例的引用</param>
        /// <param name="ColName">列名</param>
        /// <param name="RowIndex">行的索引</param>
        /// <returns>返回DataTable内的指定行的指定列的值</returns>
        public static string GetVals(DataTable DT, string ColName, int RowIndex)
        {
            return DT.Rows[RowIndex][ColName.Trim()].ToString();
        }

        /// <summary>获取DataTable内的指定行的指定列索引的值。</summary>
        /// <param name="DT">一个DataTable实例的引用</param>
        /// <param name="ColIndex">列的索引</param>
        /// <param name="RowIndex">行的索引</param>
        /// <returns>返回DataTable内的指定行的指定列的值</returns>
        public static string GetVals(DataTable DT, int ColIndex, int RowIndex)
        {
            return DT.Rows[RowIndex][ColIndex].ToString();
        }

        /// <summary>获取DataTable内的第一行的指定列的值。</summary>
        /// <param name="filter">要用来筛选行的条件</param>
        /// <param name="DT">一个DataTable实例的引用</param>
        /// <param name="ColName">列名</param>
        /// <returns>返回DataTable内的第一行的指定列的值</returns>
        public static string GetVals(string filter, DataTable DT, string ColName)
        {
            DataRow[] dRow = DT.Select(filter);
            if (dRow.Length > 0)
            {
                return dRow[0][ColName.Trim()].ToString();
            }
            return "";
        }

        /// <summary>获取DataTable内的第一行的指定列索引的值。</summary>
        /// <param name="filter">要用来筛选行的条件</param>
        /// <param name="DT">一个DataTable实例的引用</param>
        /// <param name="ColIndex">列的索引</param>
        /// <returns>返回DataTable内的第一行的指定列的值</returns>
        public static string GetVals(string filter, DataTable DT, int ColIndex)
        {
            DataRow[] dRow = DT.Select(filter);
            if (dRow.Length > 0)
            {
                return dRow[0][ColIndex].ToString();
            }
            return "";
        }

        /// <summary>获取DataTable内的指定行的指定列的值。</summary>
        /// <param name="filter">要用来筛选行的条件</param>
        /// <param name="DT">一个DataTable实例的引用</param>
        /// <param name="ColName">列名</param>
        /// <param name="RowIndex">行的索引</param>
        /// <returns>返回DataTable内的指定行的指定列的值</returns>
        public static string GetVals(string filter, DataTable DT, string ColName, int RowIndex)
        {
            DataRow[] dRow = DT.Select(filter);
            if (dRow.Length > RowIndex && RowIndex > -1)
            {
                return dRow[RowIndex][ColName.Trim()].ToString();
            }
            return "";
        }

        /// <summary>获取DataTable内的指定行的指定列索引的值。</summary>
        /// <param name="filter">要用来筛选行的条件</param>
        /// <param name="DT">一个DataTable实例的引用</param>
        /// <param name="ColIndex">列的索引</param>
        /// <param name="RowIndex">行的索引</param>
        /// <returns>返回DataTable内的指定行的指定列的值</returns>
        public static string GetVals(string filter, DataTable DT, int ColIndex, int RowIndex)
        {
            DataRow[] dRow = DT.Select(filter);
            if (dRow.Length > RowIndex && RowIndex > -1)
            {
                return dRow[RowIndex][ColIndex].ToString();
            }
            return "";
        }

        /// <summary>获取DataTable内的第一行的指定列的值。</summary>
        /// <param name="filter">要用来筛选行的条件</param>
        /// <param name="sort">一个字符串，它指定列和排序方向</param>
        /// <param name="DT">一个DataTable实例的引用</param>
        /// <param name="ColName">列名</param>
        /// <returns>返回DataTable内的第一行的指定列的值</returns>
        public static string GetVals(string filter, string sort, DataTable DT, string ColName)
        {
            DataRow[] dRow = DT.Select(filter, sort);
            if (dRow.Length > 0)
            {
                return dRow[0][ColName.Trim()].ToString();
            }
            return "";
        }

        /// <summary>获取DataTable内的第一行的指定列索引的值。</summary>
        /// <param name="filter">要用来筛选行的条件</param>
        /// <param name="sort">一个字符串，它指定列和排序方向</param>
        /// <param name="DT">一个DataTable实例的引用</param>
        /// <param name="ColIndex">列的索引</param>
        /// <returns>返回DataTable内的第一行的指定列的值</returns>
        public static string GetVals(string filter, string sort, DataTable DT, int ColIndex)
        {
            DataRow[] dRow = DT.Select(filter, sort);
            if (dRow.Length > 0)
            {
                return dRow[0][ColIndex].ToString();
            }
            return "";
        }

        /// <summary>获取DataTable内的指定行的指定列的值。</summary>
        /// <param name="filter">要用来筛选行的条件</param>
        /// <param name="sort">一个字符串，它指定列和排序方向</param>
        /// <param name="DT">一个DataTable实例的引用</param>
        /// <param name="ColName">列名</param>
        /// <param name="RowIndex">行的索引</param>
        /// <returns>返回DataTable内的指定行的指定列的值</returns>
        public static string GetVals(string filter, string sort, DataTable DT, string ColName, int RowIndex)
        {
            DataRow[] dRow = DT.Select(filter, sort);
            if (dRow.Length > RowIndex && RowIndex > -1)
            {
                return dRow[RowIndex][ColName.Trim()].ToString();
            }
            return "";
        }

        /// <summary>获取DataTable内的指定行的指定列索引的值。</summary>
        /// <param name="filter">要用来筛选行的条件</param>
        /// <param name="sort">一个字符串，它指定列和排序方向</param>
        /// <param name="DT">一个DataTable实例的引用</param>
        /// <param name="ColIndex">列的索引</param>
        /// <param name="RowIndex">行的索引</param>
        /// <returns>返回DataTable内的指定行的指定列的值</returns>
        public static string GetVals(string filter, string sort, DataTable DT, int ColIndex, int RowIndex)
        {
            DataRow[] dRow = DT.Select(filter, sort);
            if (dRow.Length > RowIndex && RowIndex > -1)
            {
                return dRow[RowIndex][ColIndex].ToString();
            }
            return "";
        }

        /// <summary>获取DataTable内的第一行的指定列的值。</summary>
        /// <param name="filter">要用来筛选行的条件</param>
        /// <param name="sort">一个字符串，它指定列和排序方向</param>
        /// <param name="dvrs">DataViewRowState 值之一</param>
        /// <param name="DT">一个DataTable实例的引用</param>
        /// <param name="ColName">列名</param>
        /// <returns>返回DataTable内的第一行的指定列的值</returns>
        public static string GetVals(string filter, string sort, DataViewRowState dvrs, DataTable DT, string ColName)
        {
            DataRow[] dRow = DT.Select(filter, sort, dvrs);
            if (dRow.Length > 0)
            {
                return dRow[0][ColName.Trim()].ToString();
            }
            return "";
        }

        /// <summary>获取DataTable内的第一行的指定列索引的值。</summary>
        /// <param name="filter">要用来筛选行的条件</param>
        /// <param name="sort">一个字符串，它指定列和排序方向</param>
        /// <param name="dvrs">DataViewRowState 值之一</param>
        /// <param name="DT">一个DataTable实例的引用</param>
        /// <param name="ColIndex">列的索引</param>
        /// <returns>返回DataTable内的第一行的指定列的值</returns>
        public static string GetVals(string filter, string sort, DataViewRowState dvrs, DataTable DT, int ColIndex)
        {
            DataRow[] dRow = DT.Select(filter, sort, dvrs);
            if (dRow.Length > 0)
            {
                return dRow[0][ColIndex].ToString();
            }
            return "";
        }

        /// <summary>获取DataTable内的指定行的指定列的值。</summary>
        /// <param name="filter">要用来筛选行的条件</param>
        /// <param name="sort">一个字符串，它指定列和排序方向</param>
        /// <param name="dvrs">DataViewRowState 值之一</param>
        /// <param name="DT">一个DataTable实例的引用</param>
        /// <param name="ColName">列名</param>
        /// <param name="RowIndex">行的索引</param>
        /// <returns>返回DataTable内的指定行的指定列的值</returns>
        public static string GetVals(string filter, string sort, DataViewRowState dvrs, DataTable DT, string ColName, int RowIndex)
        {
            DataRow[] dRow = DT.Select(filter, sort, dvrs);
            if (dRow.Length > RowIndex && RowIndex > -1)
            {
                return dRow[RowIndex][ColName.Trim()].ToString();
            }
            return "";
        }

        /// <summary>获取DataTable内的指定行的指定列索引的值。</summary>
        /// <param name="filter">要用来筛选行的条件</param>
        /// <param name="sort">一个字符串，它指定列和排序方向</param>
        /// <param name="dvrs">DataViewRowState 值之一</param>
        /// <param name="DT">一个DataTable实例的引用</param>
        /// <param name="ColIndex">列的索引</param>
        /// <param name="RowIndex">行的索引</param>
        /// <returns>返回DataTable内的指定行的指定列的值</returns>
        public static string GetVals(string filter, string sort, DataViewRowState dvrs, DataTable DT, int ColIndex, int RowIndex)
        {
            DataRow[] dRow = DT.Select(filter, sort, dvrs);
            if (dRow.Length > RowIndex && RowIndex > -1)
            {
                return dRow[RowIndex][ColIndex].ToString();
            }
            return "";
        }

        #endregion

        #region 获取DataRow内某列的值，并删除该值左右空白。如果该列不存在则发生错误

        /// <summary>获取DataRow指定列的值，并删除左右空白。</summary>
        /// <param name="dr">一个DataRow</param>
        /// <param name="ColName">列名</param>
        /// <returns>返回DataRow指定列的值</returns>
        public static string GetVal(DataRow dr, string ColName)
        {
            return dr[ColName.Trim()].ToString().Trim();
        }

        /// <summary>获取DataRow指定列索引的值，并删除左右空白。</summary>
        /// <param name="dr">一个DataRow</param>
        /// <param name="ColIndex">列的索引</param>
        /// <returns>返回DataRow指定列的值</returns>
        public static string GetVal(DataRow dr, int ColIndex)
        {
            return dr[ColIndex].ToString().Trim();
        }

        /// <summary>获取DataRow数组第一行指定列的值，并删除左右空白。</summary>
        /// <param name="dr">一个DataRow</param>
        /// <param name="ColName">列名</param>
        /// <returns>返回DataRow指定列的值</returns>
        public static string GetVal(DataRow[] dr, string ColName)
        {
            if (dr.Length > 0)
            {
                return dr[0][ColName.Trim()].ToString().Trim();
            }
            return "";
        }

        /// <summary>获取DataRow数组第一行指定列索引的值，并删除左右空白。</summary>
        /// <param name="dr">一个DataRow</param>
        /// <param name="ColIndex">列的索引</param>
        /// <returns>返回DataRow指定列的值</returns>
        public static string GetVal(DataRow[] dr, int ColIndex)
        {
            if (dr.Length > 0)
            {
                return dr[0][ColIndex].ToString().Trim();
            }
            return "";
        }

        /// <summary>获取DataRow数组指定行的指定列的值，并删除左右空白。</summary>
        /// <param name="dr">一个DataRow数组</param>
        /// <param name="ColName">列名</param>
        /// <param name="RowIndex">行的索引</param>
        /// <returns>返回DataRow指定行的指定列的值</returns>
        public static string GetVal(DataRow[] dr, string ColName, int RowIndex)
        {
            if (dr.Length > RowIndex && RowIndex > -1)
            {
                return dr[RowIndex][ColName.Trim()].ToString().Trim();
            }
            return "";
        }

        /// <summary>获取DataRow数组指定行的指定列索引的值，并删除左右空白。</summary>
        /// <param name="dr">一个DataRow数组</param>
        /// <param name="ColIndex">列的索引</param>
        /// <param name="RowIndex">行的索引</param>
        /// <returns>返回DataRow指定行的指定列索引的值</returns>
        public static string GetVal(DataRow[] dr, int ColIndex, int RowIndex)
        {
            if (dr.Length > RowIndex && RowIndex > -1)
            {
                return dr[RowIndex][ColIndex].ToString().Trim();
            }
            return "";
        }

        #endregion

        #region 获取DataRow内某列的值。如果该列不存在则发生错误

        /// <summary>获取DataRow指定列的值。</summary>
        /// <param name="dr">一个DataRow</param>
        /// <param name="ColName">列名</param>
        /// <returns>返回DataRow指定列的值</returns>
        public static string GetVals(DataRow dr, string ColName)
        {
            return dr[ColName.Trim()].ToString();
        }

        /// <summary>获取DataRow指定列索引的值。</summary>
        /// <param name="dr">一个DataRow</param>
        /// <param name="ColIndex">列的索引</param>
        /// <returns>返回DataRow指定列的值</returns>
        public static string GetVals(DataRow dr, int ColIndex)
        {
            return dr[ColIndex].ToString();
        }

        /// <summary>获取DataRow数组第一行指定列的值。</summary>
        /// <param name="dr">一个DataRow</param>
        /// <param name="ColName">列名</param>
        /// <returns>返回DataRow指定列的值</returns>
        public static string GetVals(DataRow[] dr, string ColName)
        {
            if (dr.Length > 0)
            {
                return dr[0][ColName.Trim()].ToString();
            }
            return "";
        }

        /// <summary>获取DataRow数组第一行指定列索引的值。</summary>
        /// <param name="dr">一个DataRow</param>
        /// <param name="ColIndex">列的索引</param>
        /// <returns>返回DataRow指定列的值</returns>
        public static string GetVals(DataRow[] dr, int ColIndex)
        {
            if (dr.Length > 0)
            {
                return dr[0][ColIndex].ToString();
            }
            return "";
        }

        /// <summary>获取DataRow数组指定行的指定列的值。</summary>
        /// <param name="dr">一个DataRow数组</param>
        /// <param name="ColName">列名</param>
        /// <param name="RowIndex">行的索引</param>
        /// <returns>返回DataRow指定行的指定列的值</returns>
        public static string GetVals(DataRow[] dr, string ColName, int RowIndex)
        {
            if (dr.Length > RowIndex && RowIndex > -1)
            {
                return dr[RowIndex][ColName.Trim()].ToString();
            }
            return "";
        }

        /// <summary>获取DataRow数组指定行的指定列索引的值。</summary>
        /// <param name="dr">一个DataRow数组</param>
        /// <param name="ColIndex">列的索引</param>
        /// <param name="RowIndex">行的索引</param>
        /// <returns>返回DataRow指定行的指定列索引的值</returns>
        public static string GetVals(DataRow[] dr, int ColIndex, int RowIndex)
        {
            if (dr.Length > RowIndex && RowIndex > -1)
            {
                return dr[RowIndex][ColIndex].ToString();
            }
            return "";
        }

        #endregion

        #region DataTable常用操作方法

        /// <summary>返回正整数列表中指定索引值,如果未找到指定索引则返回-1</summary>
        /// <param name="li">列表</param>
        /// <param name="index">索引</param>
        /// <returns>返回正整数列表中指定索引值</returns>
        public static int GetIntListVal(List<int> li, int index)
        {
            if (index < li.Count)
            {
                return li[index];
            }
            return -1;
        }

        /// <summary>将一个DataTable插入到DataSet内并返回</summary>
        /// <param name="dt">一个DataTable</param>
        /// <param name="tableName">DataTable名称</param>
        /// <returns>返回一个DataSet</returns>
        public static DataSet GetDataSet(DataTable dt, string tableName)
        {
            DataSet Ds = new DataSet();
            Ds.Tables.Add(dt);
            Ds.Tables[0].TableName = tableName;
            return Ds;
        }

        /// <summary>将一个DataTable插入到DataSet内并返回</summary>
        /// <param name="dt">一个DataTable</param>
        /// <returns>返回一个DataSet</returns>
        public static DataSet GetDataSet(DataTable dt)
        {
            DataSet Ds = new DataSet();
            Ds.Tables.Add(dt);
            return Ds;
        }

        /// <summary>根据DataRow数组返回指定内存表构架的DataTable</summary>
        /// <param name="drs">DataRow数组</param>
        /// <param name="dt">需要拷贝构架的内存表</param>
        /// <returns>根据数据行数组返回DataTable</returns>
        public static DataTable GetTable(DataRow[] drs, DataTable dt)
        {
            DataTable ndt = new DataTable();
            ndt = dt.Clone();
            for (int i = 0; i < drs.Length; i++)
            {
                ndt.ImportRow(drs[i]);
            }
            return ndt;
        }

        /// <summary>根据DataRow数组返回DataTable</summary>
        /// <param name="drs">DataRow数组</param>
        /// <returns>根据数据行数组返回DataTable</returns>
        public static DataTable GetTable(DataRow[] drs)
        {
            DataTable ndt = new DataTable();
            if (drs.Length > 0) 
            {
                ndt = drs[0].Table.Clone();
                for (int i = 0; i < drs.Length; i++)
                {
                    ndt.ImportRow(drs[i]);
                }
            }
            return ndt;
        }

        /// <summary>将DataRow数组拷贝到指定内存表构架的DataTable</summary>
        /// <param name="drs">DataRow数组</param>
        /// <param name="cdt">需要复制数据的内存表</param>
        /// <param name="dt">需要拷贝构架的内存表</param>
        public static void CopyTable(DataRow[] drs, DataTable cdt, DataTable dt)
        {
            cdt = dt.Clone();
            for (int i = 0; i < drs.Length; i++)
            {
                cdt.ImportRow(drs[i]);
            }
        }

        /// <summary>将指定的DataTable内的数据和构架拷贝到指定内存表</summary>
        /// <param name="dt">需要拷贝构架的内存表</param>
        /// <param name="cdt">需要复制数据的内存表</param>
        public static void CopyTable(DataTable dt, DataTable cdt)
        {
            cdt = dt.Clone();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cdt.ImportRow(dt.Rows[i]);
            }
        }

        /// <summary>将指定的DataView内的数据和构架拷贝到指定内存表</summary>
        /// <param name="dv">需要拷贝数据和构架的DataView</param>
        /// <param name="cdt">需要复制数据的内存表</param>
        public static void CopyTable(DataView dv, DataTable cdt)
        {
            cdt = dv.Table.Clone();
            for (int i = 0; i < dv.Count; i++)
            {
                cdt.ImportRow(dv[i].Row);
            }
        }

        /// <summary>返回指定内存表不重复id集合</summary>
        /// <param name="rdt">包含id字段的内存表</param>
        /// <param name="idName">id字段名称</param>
        /// <returns>返回指定内存表不重复id集合</returns>
        public static string GetIds(DataTable rdt, string idName)
        {
            StringBuilder sb = new StringBuilder();
            List<string> ls = new List<string>();
            for (int i = 0; i < rdt.Rows.Count; i++)
            {
                string idstr = rdt.Rows[i][idName.Trim()].ToString().Trim();
                if (idstr != "" && ls.IndexOf(idstr) == -1)
                {
                    if (sb.Length > 0)
                    {
                        sb.Append(",");
                    }
                    sb.Append(idstr);
                    ls.Add(idstr);
                }
            }
            return sb.ToString();
        }

        /// <summary>返回指定内存表不重复用户名集合</summary>
        /// <param name="rdt">包含用户名字段的内存表</param>
        /// <param name="idName">用户名字段名称</param>
        /// <returns>返回指定内存表不重复用户名集合</returns>
        public static string GetUsers(DataTable rdt, string idName)
        {
            StringBuilder sb = new StringBuilder();
            List<string> ls = new List<string>();
            for (int i = 0; i < rdt.Rows.Count; i++)
            {
                string idstr = "'" + rdt.Rows[i][idName.Trim()].ToString().Trim() + "'";
                if (idstr != "" && ls.IndexOf(idstr) == -1)
                {
                    if (sb.Length > 0)
                    {
                        sb.Append(",");
                    }
                    sb.Append(idstr);
                    ls.Add(idstr);
                }
            }
            return sb.ToString();
        }

        /// <summary>根据指定的排序表达式返回已排序的内存表</summary>
        /// <param name="sdt">需要排序的内存表</param>
        /// <param name="sorts">排序表达式</param>
        /// <returns>根据指定的排序方法返回已排序的内存表</returns>
        public static DataTable GetSortTable(DataTable sdt, string sorts)
        {
            DataView dv = sdt.DefaultView;
            dv.Sort = sorts;
            return dv.ToTable();
        }

        #endregion
    }
}

