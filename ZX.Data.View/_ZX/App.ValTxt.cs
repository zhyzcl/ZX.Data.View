using System;
using System.Text;
using System.ComponentModel;

namespace App
{
    /// <summary>存储一个健和文本值</summary>
    [Serializable]
    public class ValTxt
    {
        #region 私有属性

        /// <summary>获取或设置健(默认值：空字符串)</summary>
        private string _Value = "";

        /// <summary>获取或设置文本值(默认值：空字符串)</summary>
        private string _Text = "";

        #endregion

        #region 公共属性

        /// <summary>获取或设置健(默认值：空字符串)</summary>
        [Description("健(默认值：空字符串)")]
        public string Value
        {
            get { return _Value; }
            set { _Value = value; }
        }

        /// <summary>获取或设置文本值(默认值：空字符串)</summary>
        [Description("文本值(默认值：空字符串)")]
        public string Text
        {
            get { return _Text; }
            set { _Text = value; }
        }

        #endregion

        #region 构造类

        /// <summary>构造类</summary>
        /// <returns></returns>
        public ValTxt(){}

        /// <summary>使用单一值填充健及文本构造类</summary>
        /// <param name="value">值(该值将填充健及文本)</param>
        /// <returns></returns>
        public ValTxt(string value)
        {
            _Value = value;
            _Text = value;
        }

        /// <summary>使用健及文本值构造类</summary>
        /// <param name="value">健</param>
        /// <param name="text">文本值</param>
        /// <returns></returns>
        public ValTxt(string value, string text)
        {
            _Value = value;
            _Text = text;
        }

        #endregion

        #region 公共方法

        /// <summary>返回文本值</summary>
        /// <returns>返回文本值</returns>
        public override string ToString()
        {
            return _Text;
        }

        #endregion
    }
}

