using System;
using System.Data;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Web;

namespace App
{
    /// <summary>内存表配置类</summary>
    public class Table
    {
        /// <summary>表名称</summary>
        private string _TableName = "";

        /// <summary>表名称</summary>
        public string TableName
        {
            get { return _TableName; }
            set { _TableName = value; }
        }

        /// <summary>字段名称列表</summary>
        private List<string> _NameList = new List<string>();

        /// <summary>字段名称列表</summary>
        public List<string> NameList
        {
            get { return _NameList; }
        }

        /// <summary>字段类型列表</summary>
        private List<string> _TypeList = new List<string>();

        /// <summary>字段类型列表</summary>
        public List<string> TypeList
        {
            get { return _TypeList; }
        }

        /// <summary>字段值是否可以为空值列表 0可以为空，1不能为空</summary>
        private List<byte> _IsNullList = new List<byte>();

        /// <summary>字段值是否可以为空值列表 0可以为空，1不能为空</summary>
        public List<byte> IsNullList
        {
            get { return _IsNullList; }
        }

        /// <summary>构造类</summary>
        public Table() { }

        /// <summary>构造类并赋予表名</summary>
        /// <param name="name">表名</param>
        public Table(string name)
        {
            _TableName = name;
        }

        /// <summary>在现有元素后面添加元素</summary>
        /// <param name="colname">字段名</param>
        /// <param name="coltype">字段类型:int；string；long；byte；datetime；decimal；double；byte[]；autoint；autolong</param>
        /// <param name="isnull">是否为空 0可以为空，1不能为空</param>
        public void Add(string colname, string coltype, byte isnull)
        {
            _NameList.Add(colname);
            _TypeList.Add(coltype);
            _IsNullList.Add(isnull);
        }
    }
}
