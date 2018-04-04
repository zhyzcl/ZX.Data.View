using System;
using System.Data;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Web;

namespace App
{
    /// <summary>系统内存表</summary>
    public class DataTables
    {
        /// <summary>返回内存表类型所对应的系统类型</summary>
        /// <param name="types">内存表类型</param>
        /// <returns>返回内存表类型所对应的系统类型</returns>
        public static string GetTableTypes(string types)
        {
            types = types.ToLower();
            if (types == "int" || types == "int32" || types == "system.int32")
            {
                return "System.Int32";
            }
            else if (types == "long" || types == "int64" || types == "system.int64")
            {
                return "System.Int64";
            }
            else if (types == "autoint")
            {
                return "System.Int32";
            }
            else if (types == "autolong")
            {
                return "System.Int64";
            }
            else if (types == "bit" || types == "tinyint" || types == "byte")
            {
                return "System.Byte";
            }
            else if (types == "datetime")
            {
                return "System.DateTime";
            }
            else if (types == "decimal")
            {
                return "System.Decimal";
            }
            else if (types == "double")
            {
                return "System.Double";
            }
            else if (types == "byte[]")
            {
                return "System.Byte[]";
            }
            return "System.String";
        }

        /// <summary>根据内存表配置对象返回新的一个内存表配置对象</summary>
        /// <param name="table">内存表配置对象</param>
        /// <param name="noNames">不需要返回的内存表配置对象列名称数组</param>
        /// <returns>根据内存表配置对象返回新的一个内存表配置对象</returns>
        public static Table GetTable(Table table, params string[] noNames)
        {
            List<string> nlist = new List<string>(noNames);
            Table newtable = new Table(table.TableName);
            for (int i = 0; i < table.NameList.Count; i++)
            {
                string cname = table.NameList[i].Trim();
                if (nlist.IndexOf(cname) == -1)
                {
                    newtable.Add(table.NameList[i], table.TypeList[i], table.IsNullList[i]);
                }
            }
            return newtable;
        }

        /// <summary>根据内存表配置对象返回新的一个内存表配置对象</summary>
        /// <param name="table">内存表配置对象</param>
        /// <param name="noIndexs">不需要返回的内存表配置对象列索引数组</param>
        /// <returns>根据内存表配置对象返回新的一个内存表配置对象</returns>
        public static Table GetTable(Table table, params int[] noIndexs)
        {
            List<int> nlist = new List<int>(noIndexs);
            Table newtable = new Table(table.TableName);
            for (int i = 0; i < table.NameList.Count; i++)
            {
                string cname = table.NameList[i].Trim();
                if (nlist.IndexOf(i) == -1)
                {
                    newtable.Add(table.NameList[i], table.TypeList[i], table.IsNullList[i]);
                }
            }
            return newtable;
        }

        /// <summary>返回内存表配置对象列名集合</summary>
        /// <param name="table">内存表配置对象</param>
        /// <returns>返回内存表配置对象列名集合</returns>
        public static string GetColNames(Table table)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < table.NameList.Count; i++)
            {
                if (sb.Length > 0)
                {
                    sb.Append(",");
                }
                sb.Append(table.NameList[i].Trim());
            }
            return sb.ToString();
        }

        /// <summary>返回内存表配置对象列名集合</summary>
        /// <param name="table">内存表配置对象</param>
        /// <param name="noNames">不需要返回的列名称数组</param>
        /// <returns>返回内存表配置对象列名集合</returns>
        public static string GetColNames(Table table, params string[] noNames)
        {
            List<string> nlist = new List<string>(noNames);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < table.NameList.Count; i++)
            {
                string cname = table.NameList[i].Trim();
                if (nlist.IndexOf(cname) == -1)
                {
                    if (sb.Length > 0)
                    {
                        sb.Append(",");
                    }
                    sb.Append(cname);
                }
            }
            return sb.ToString();
        }

        /// <summary>返回内存表配置对象列名集合</summary>
        /// <param name="table">内存表配置对象</param>
        /// <param name="noIndexs">不需要返回的列索引数组</param>
        /// <returns>返回内存表配置对象列名集合</returns>
        public static string GetColNames(Table table, params int[] noIndexs)
        {
            List<int> nlist = new List<int>(noIndexs);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < table.NameList.Count; i++)
            {
                string cname = table.NameList[i].Trim();
                if (nlist.IndexOf(i) == -1)
                {
                    if (sb.Length > 0)
                    {
                        sb.Append(",");
                    }
                    sb.Append(cname);
                }
            }
            return sb.ToString();
        }

        /// <summary>根据列名称和字段类型定义增加内存表列构架</summary>
        /// <param name="names">列名称</param>
        /// <param name="types">列类型定义</param>
        /// <param name="dt">引用的内存表</param>
        public static void AddColumns(string names, string types, ref DataTable dt)
        {
            if (types.ToLower() == "autoint")
            {
                DataColumn TColumn = dt.Columns.Add(names, Type.GetType("System.Int32"));
                TColumn.AutoIncrement = true;
                TColumn.AutoIncrementSeed = 1;
                TColumn.AutoIncrementStep = 1;
            }
            else if (types.ToLower() == "autolong")
            {
                DataColumn TColumn = dt.Columns.Add(names, Type.GetType("System.Int64"));
                TColumn.AutoIncrement = true;
                TColumn.AutoIncrementSeed = 1;
                TColumn.AutoIncrementStep = 1;
            }
            else
            {
                dt.Columns.Add(names, Type.GetType(GetTableTypes(types)));
            }
        }

        /// <summary>根据内存表配置对象返回内存表</summary>
        /// <param name="table">内存表配置对象</param>
        /// <returns>根据内存表配置对象返回内存表</returns>
        public static DataTable GetDataTable(Table table)
        {
            StringBuilder sb = new StringBuilder();
            DataTable dt = new DataTable();
            dt.TableName = table.TableName;
            for (int i = 0; i < table.NameList.Count; i++)
            {
                string names = table.NameList[i].Trim();
                string types = table.TypeList[i].Trim();
                AddColumns(names, types, ref dt);  
            }
            return dt;
        }

        /// <summary>根据内存表配置对象返回内存表</summary>
        /// <param name="table">内存表配置对象</param>
        /// <param name="noNames">不需要建立的列名称数组</param>
        /// <returns>根据内存表配置对象返回内存表</returns>
        public static DataTable GetDataTable(Table table, params string[] noNames)
        {
            List<string> nlist = new List<string>(noNames);
            StringBuilder sb = new StringBuilder();
            DataTable dt = new DataTable();
            dt.TableName = table.TableName;
            for (int i = 0; i < table.NameList.Count; i++)
            {
                string cname = table.NameList[i].Trim();
                string types = table.TypeList[i].Trim();
                if (nlist.IndexOf(cname) == -1)
                {
                    AddColumns(cname, types, ref dt);
                }
            }
            return dt;
        }

        /// <summary>根据内存表配置对象返回内存表</summary>
        /// <param name="table">内存表配置对象</param>
        /// <param name="noIndexs">不需要建立的列索引数组</param>
        /// <returns>根据内存表配置对象返回内存表</returns>
        public static DataTable GetDataTable(Table table, params int[] noIndexs)
        {
            List<int> nlist = new List<int>(noIndexs);
            StringBuilder sb = new StringBuilder();
            DataTable dt = new DataTable();
            dt.TableName = table.TableName;
            for (int i = 0; i < table.NameList.Count; i++)
            {
                string cname = table.NameList[i].Trim();
                string types = table.TypeList[i].Trim();
                if (nlist.IndexOf(i) == -1)
                {
                    AddColumns(cname, types, ref dt);
                }
            }
            return dt;
        }

        /// <summary>根据内存表配置对象返回内存表</summary>
        /// <param name="name">内存表名称</param>
        /// <param name="table">内存表配置对象</param>
        /// <returns>根据内存表配置对象返回内存表</returns>
        public static DataTable OutDataTable(string name, Table table)
        {
            StringBuilder sb = new StringBuilder();
            DataTable dt = new DataTable();
            dt.TableName = name;
            for (int i = 0; i < table.NameList.Count; i++)
            {
                string names = table.NameList[i].Trim();
                string types = table.TypeList[i].Trim();
                AddColumns(names, types, ref dt);
            }
            return dt;
        }

        /// <summary>根据内存表配置对象返回内存表</summary>
        /// <param name="name">内存表名称</param>
        /// <param name="table">内存表配置对象</param>
        /// <param name="noNames">不需要建立的列名称数组</param>
        /// <returns>根据内存表配置对象返回内存表</returns>
        public static DataTable OutDataTable(string name, Table table, params string[] noNames)
        {
            List<string> nlist = new List<string>(noNames);
            StringBuilder sb = new StringBuilder();
            DataTable dt = new DataTable();
            dt.TableName = name;
            for (int i = 0; i < table.NameList.Count; i++)
            {
                string cname = table.NameList[i].Trim();
                string types = table.TypeList[i].Trim();
                if (nlist.IndexOf(cname) == -1)
                {
                    AddColumns(cname, types, ref dt);
                }
            }
            return dt;
        }

        /// <summary>根据内存表配置对象返回内存表</summary>
        /// <param name="name">内存表名称</param>
        /// <param name="table">内存表配置对象</param>
        /// <param name="noIndexs">不需要建立的列索引数组</param>
        /// <returns>根据内存表配置对象返回内存表</returns>
        public static DataTable OutDataTable(string name, Table table, params int[] noIndexs)
        {
            List<int> nlist = new List<int>(noIndexs);
            StringBuilder sb = new StringBuilder();
            DataTable dt = new DataTable();
            dt.TableName = name;
            for (int i = 0; i < table.NameList.Count; i++)
            {
                string cname = table.NameList[i].Trim();
                string types = table.TypeList[i].Trim();
                if (nlist.IndexOf(i) == -1)
                {
                    AddColumns(cname, types, ref dt);
                }
            }
            return dt;
        }

        /// <summary>将一个内存表的数据拷贝到另一个内存表中并返回拷贝的数据行数</summary>
        /// <param name="table">内存表配置</param>
        /// <param name="sdt">源内存表</param>
        /// <param name="adt">目的内存表</param>
        /// <returns>将一个内存表的数据拷贝到另一个内存表中并返回拷贝的数据行数</returns>
        public static int DataTableCopy(Table table, DataTable sdt, DataTable adt)
        {
            int count = 0;
            for (int i = 0; i < sdt.Rows.Count; i++)
            {
                DataRow newRow = adt.NewRow();
                for (int n = 0; n < table.NameList.Count; n++)
                {
                    newRow[table.NameList[n]] = sdt.Rows[i][n];
                }
                adt.Rows.Add(newRow);
                count++;
            }
            return count;
        }
    }
}
