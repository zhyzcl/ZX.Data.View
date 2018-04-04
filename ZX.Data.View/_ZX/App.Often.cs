using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Collections.Specialized;

namespace App
{
    /// <summary>常用静态方法操作类</summary>
    [Serializable]
    public static class Often
    {
        #region 私有属性

        /// <summary>设置或获取随即种子(默认值：-99999999)</summary> 
        private static int _Seed = -99999999;

        /// <summary>累计数，最大99999999，最小1，超过99999999自动重置为1</summary>
        private static int _AddupNum = 1;

        /// <summary>长整数累计数，最大999999999999999999，最小1，超过999999999999999999自动重置为1</summary>
        private static long _AddupLongNum = 1;

        #endregion

        #region 公共属性

        /// <summary>设置或获取系统版本号(默认值：1.0.0.0)</summary> 
        public static string VersionNumber = "1.0.0.0";

        /// <summary>设置或获取静态应用程序跟路径(默认值：空字符串)</summary> 
        public static string BasePath = "";

        /// <summary>设置或获取随即种子，每获取一次，随即种子自动加1(默认值：-99999999)</summary>
        public static int Seed
        {
            get
            {
                if (_Seed > 99999999 || _Seed < -99999999)
                {
                    _Seed = -99999999;
                }
                _Seed++;
                return _Seed;
            }
            set { _Seed = value; }
        }

        /// <summary>返回累计数，最大99999999，最小1，超过99999999自动重置为1</summary>
        public static int AddupNum
        {
            get
            {
                if (_AddupNum > 99999999 || _AddupNum <= 0)
                {
                    _AddupNum = 1;
                }
                int num = _AddupNum;
                _AddupNum++;
                return num;
            }
            set { _AddupNum = value; }
        }

        /// <summary>返回长整数累计数，最大999999999999999999，最小1，超过999999999999999999自动重置为1</summary>
        public static long AddupLongNum
        {
            get
            {
                if (_AddupLongNum > 999999999999999999 || _AddupLongNum <= 0)
                {
                    _AddupLongNum = 1;
                }
                long num = _AddupLongNum;
                _AddupLongNum++;
                return num;
            }
            set { _AddupLongNum = value; }
        }

        #endregion

        #region 常用方法

        /// <summary>返回指定数组索引位置的值，如果索引位置不存在则返回空字符串</summary>
        /// <param name="arr">指定数组</param>
        /// <param name="num">索引值</param>
        /// <returns>返回指定数组索引位置的值，如果索引位置不存在则返回空字符串</returns>
        public static string GetArrValue(string[] arr, int num)
        {
            if (arr.Length > num && num > -1)
            {
                return arr[num];
            }
            return "";
        }

        /// <summary>返回指定数组列表索引位置的值，如果索引位置不存在则返回空字符串</summary>
        /// <param name="arr">指定数组列表</param>
        /// <param name="num">索引值</param>
        /// <returns>返回指定数组列表索引位置的值，如果索引位置不存在则返回空字符串</returns>
        public static string GetArrValue(List<string> arr, int num)
        {
            if (arr.Count > num && num > -1)
            {
                return arr[num];
            }
            return "";
        }

        /// <summary>将指定字符串尾部追加字符串,如果原字符串不为空,则追加小写逗号分隔符</summary>
        /// <param name="sbs">可变字符串</param>
        /// <param name="str">需要追加的字符串</param>
        public static void AddStr(ref StringBuilder sbs, string str)
        {
            AddStr(ref sbs, str, ",");
        }

        /// <summary>将指定字符串尾部追加字符串,如果原字符串不为空,则追加指定分隔符</summary>
        /// <param name="sbs">可变字符串</param>
        /// <param name="str">需要追加的字符串</param>
        /// <param name="separate">分隔符</param>
        public static void AddStr(ref StringBuilder sbs, string str, string separate)
        {
            if (str.Trim() == "")
            {
                return;
            }
            if (sbs.Length > 0)
            {
                sbs.Append(separate);
            }
            sbs.Append(str);
        }

        /// <summary>将指定字符串尾部追加字符串,如果原字符串不为空,则追加小写逗号分隔符</summary>
        /// <param name="sbs">字符串</param>
        /// <param name="str">需要追加的字符串</param>
        public static string AddStr(string sbs, string str)
        {
            return AddStr(sbs, str, ",");
        }

        /// <summary>将指定字符串尾部追加字符串,如果原字符串不为空,则追加指定分隔符</summary>
        /// <param name="sbs">字符串</param>
        /// <param name="str">需要追加的字符串</param>
        /// <param name="separate">分隔符</param>
        public static string AddStr(string sbs, string str, string separate)
        {
            if (str.Trim() == "")
            {
                return sbs;
            }
            if (sbs.Length > 0)
            {
                sbs += separate;
            }
            sbs += str;
            return sbs;
        }

        /// <summary>过滤SQL危险字符串</summary>
        /// <param name="strIn">要过滤的字符串</param>
        /// <returns>返回已过滤的字符串</returns>
        public static string Filter(string strIn)
        {
            return Regex.Replace(strIn, @"(\s|,|<|>|\||=|\?|%|@|:|'|net user|xp_cmdshell|/add|exec%20master\.dbo\.xp_cmdshell|net localgroup administrators|select|count|char|mid|insert|delete|drop|truncate|from)", "", RegexOptions.IgnoreCase | RegexOptions.Singleline) + "";
        }

        /// <summary>返回由指定String分隔的String类型一维数组。</summary>
        /// <param name="str">包含子字符串和分隔符的 String 表达式</param>
        /// <param name="spStr">分隔此实例中子字符串的Unicode字符串、不包含分隔符的空字符串或空引用</param>
        /// <returns>返回String类型一维数组</returns>
        public static string[] Split(string str, string spStr)
        {
            return Regex.Split(str, GetRegStr(spStr));
        }

        /// <summary>返回字符串的正则表达式格式</summary>
        /// <param name="inStr">输入的字符串</param>
        /// <returns>返回字符串的正则表达式格式</returns>
        public static string GetRegStr(string inStr)
        {
            inStr = inStr.Replace("\\", "\\\\");
            inStr = inStr.Replace(".", "\\.");
            inStr = inStr.Replace("$", "\\$");
            inStr = inStr.Replace("^", "\\^");
            inStr = inStr.Replace("{", "\\{");
            inStr = inStr.Replace("[", "\\[");
            inStr = inStr.Replace("(", "\\(");
            inStr = inStr.Replace("|", "\\|");
            inStr = inStr.Replace(")", "\\)");
            inStr = inStr.Replace("*", "\\*");
            inStr = inStr.Replace("+", "\\+");
            inStr = inStr.Replace("?", "\\?");
            return inStr;
        }

        /// <summary>格式化Id集合(字符效验为数字效验、分隔字符：, 返回值分隔字符,)</summary>
        /// <param name="inStr">需要效验的Id集合字符串</param>
        /// <returns>返回已格式化的Id集合</returns>
        public static string GetIdsFormat(string inStr)
        {
            return GetIdsFormat(inStr, 0, "", ",", ",");
        }

        /// <summary>格式化Id集合</summary>
        /// <param name="inStr">需要效验的Id集合字符串</param>
        /// <param name="style">类型效验。0 数字检验 ,1 字符串检验 ,2 日期检验,3 整数检验</param>
        /// <returns>返回已格式化的Id集合</returns>
        public static string GetIdsFormat(string inStr, byte style)
        {
            return GetIdsFormat(inStr, style, RegExpStr_Int, ",", ",");
        }

        /// <summary>格式化Id集合</summary>
        /// <param name="inStr">需要效验的Id集合字符串</param>
        /// <param name="style">类型效验。0 数字检验 ,1 字符串检验 ,2 日期检验,3 正则表达式检验</param>
        /// <param name="regStr">使用正则表达式检验时的正则表达式</param>
        /// <returns>返回已格式化的Id集合</returns>
        public static string GetIdsFormat(string inStr, byte style, string regStr)
        {
            return GetIdsFormat(inStr, style, regStr, ",", ",");
        }

        /// <summary>格式化Id集合</summary>
        /// <param name="inStr">需要效验的Id集合字符串</param>
        /// <param name="style">类型效验。0 数字检验 ,1 字符串检验 ,2 日期检验,3 正则表达式检验</param>
        /// <param name="regStr">使用正则表达式检验时的正则表达式</param>
        /// <param name="separate">分隔字符串</param>
        /// <returns>返回已格式化的Id集合</returns>
        public static string GetIdsFormat(string inStr, byte style, string regStr, string separate)
        {
            return GetIdsFormat(inStr, style, regStr, separate, ",");
        }

        /// <summary>格式化Id集合</summary>
        /// <param name="inStr">需要效验的Id集合字符串</param>
        /// <param name="style">类型效验。0 数字检验 ,1 字符串检验 ,2 日期检验,3 正则表达式检验</param>
        /// <param name="regStr">使用正则表达式检验时的正则表达式</param>
        /// <param name="separate">分隔字符串</param>
        /// <param name="backtrack">返回值分隔字符串</param>
        /// <returns>返回已格式化的Id集合</returns>
        public static string GetIdsFormat(string inStr, byte style, string regStr, string separate, string backtrack)
        {
            if (inStr.Length <= 0)
            {
                return "";
            }
            List<string> inStrArr = new List<string>();
            StringBuilder strB = new StringBuilder();
            string[] strArr = Split(inStr, separate);
            for (int i = 0; i < strArr.Length; i++)
            {
                string stra = strArr[i].Trim();
                if (inStrArr.IndexOf(stra) == -1)
                {
                    switch (style)
                    {
                        case 0:
                            if (!IsNum(stra))
                            {
                                stra = "";
                            }
                            break;
                        case 2:
                            if (!IsDate(stra))
                            {
                                stra = "";
                            }
                            break;
                        case 3:
                            if (!StrIsReg(stra, regStr))
                            {
                                stra = "";
                            }
                            break;
                    }
                    if (stra != "")
                    {
                        if (strB.Length > 0)
                        {
                            strB.Append(backtrack);
                        }
                        strB.Append(stra);
                        inStrArr.Add(stra);
                    }
                }
            }
            return strB.ToString();
        }

        /// <summary>如果输入的宽度或高度大于指定的宽度或高度就等比列缩小宽度或高度</summary>
        /// <param name="MaxWidth">指定最大宽度限制并返回已等比列缩小的宽度值</param>
        /// <param name="MaxHeight">指定最大高度限制并返回已等比列缩小的高度值</param>
        /// <param name="inWidth">输入的宽度</param>
        /// <param name="inHeight">输入的高度</param>
        public static void AutoSizeNarrow(ref int MaxWidth, ref int MaxHeight, int inWidth, int inHeight)
        {
            if (inWidth <= MaxWidth && inHeight <= MaxHeight)
            {
                MaxWidth = inWidth;
                MaxHeight = inHeight;
                return;
            }
            double dHeight = inHeight;
            if (inWidth > MaxWidth)
            {
                dHeight = (dHeight * MaxWidth) / inWidth;
                inWidth = MaxWidth;
                inHeight = Convert.ToInt32(dHeight);
            }
            if (inHeight > MaxHeight)
            {
                inWidth = Convert.ToInt32((inWidth * MaxHeight) / dHeight);
                inHeight = MaxHeight;
            }
            MaxWidth = inWidth;
            MaxHeight = inHeight;
        }

        /// <summary>返回由指定字符串重复指定次数后形成的字符串</summary>
        /// <param name="sInput">需要重复的字符串</param>
        /// <param name="number">重复次数</param>
        /// <returns>返回完成重复后的字符串</returns>
        public static string StrDup(string sInput, int number)
        {
            StringBuilder strB = new StringBuilder();
            for (int i = 0; i < number; i++)
            {
                strB.Append(sInput);
            }
            return strB.ToString();
        }

        /// <summary>在字符串左侧并根据字符串位数限制添加重复字符串</summary>
        /// <param name="strInput">需要添加重复字符的字符串</param>
        /// <param name="sInput">重复字符串</param>
        /// <param name="number">字符串位数限制</param>
        /// <returns>返回已添加重复字符的字符串</returns>
        public static string LStrDup(string strInput, string sInput, int number)
        {
            int bwint = number - strInput.Length;
            if (bwint > 0)
            {
                return StrDup(sInput, bwint) + strInput;
            }
            return strInput;
        }

        /// <summary>在字符串右侧并根据字符串位数限制添加重复字符串</summary>
        /// <param name="strInput">需要添加重复字符的字符串</param>
        /// <param name="sInput">重复字符串</param>
        /// <param name="number">字符串位数限制</param>
        /// <returns>返回已添加重复字符的字符串</returns>
        public static string RStrDup(string strInput, string sInput, int number)
        {
            int bwint = number - strInput.Length;
            if (bwint > 0)
            {
                return strInput + StrDup(sInput, bwint);
            }
            return strInput;
        }

        /// <summary>返回由指定字符重复指定次数后形成的字符串</summary>
        /// <param name="CInput">需要重复的字符</param>
        /// <param name="number">重复次数</param>
        /// <returns>返回完成重复后的字符串</returns>
        public static string CharDup(char CInput, int number)
        {
            return new string(CInput, number);
        }

        /// <summary>在字符串左侧并根据字符串位数限制添加重复字符</summary>
        /// <param name="strInput">需要添加重复字符的字符串</param>
        /// <param name="CInput">重复字符</param>
        /// <param name="number">字符串位数限制</param>
        /// <returns>返回已添加重复字符的字符串</returns>
        public static string LCharDup(string strInput, char CInput, int number)
        {
            int bwint = number - strInput.Length;
            if (bwint > 0)
            {
                return CharDup(CInput, bwint) + strInput;
            }
            return strInput;
        }

        /// <summary>在字符串右侧并根据字符串位数限制添加重复字符</summary>
        /// <param name="strInput">需要添加重复字符的字符串</param>
        /// <param name="CInput">重复字符</param>
        /// <param name="number">字符串位数限制</param>
        /// <returns>返回已添加重复字符的字符串</returns>
        public static string RCharDup(string strInput, char CInput, int number)
        {
            int bwint = number - strInput.Length;
            if (bwint > 0)
            {
                return strInput + CharDup(CInput, bwint);
            }
            return strInput;
        }

        /// <summary>将指定字符串两端空白删除</summary>
        /// <param name="strInput">需要删除两端空白的字符串</param>
        /// <returns>返回已删除空白的字符串</returns>
        public static string Trim(string strInput)
        {
            return Trim(strInput, 0);
        }

        /// <summary>将指定字符串内空白删除</summary>
        /// <param name="strInput">需要删除空白的字符串</param>
        /// <param name="mode">删除模式：0 删除字符串两端空白、1 删除字符串左端空白、2 删除字符串右端空白、3 删除字符串内所有空白。</param>
        /// <returns>返回已删除空白的字符串</returns>
        public static string Trim(string strInput, byte mode)
        {
            if (mode == 1)
            {
                Regex.Replace(strInput, "^(\\s+)", "", RegexOptions.IgnoreCase | RegexOptions.Singleline);
            }
            else if (mode == 2)
            {
                Regex.Replace(strInput, "(\\s+)$", "", RegexOptions.IgnoreCase | RegexOptions.Singleline);
            }
            else if (mode == 3)
            {
                return Regex.Replace(strInput, "(\\s)", "", RegexOptions.IgnoreCase | RegexOptions.Singleline);
            }
            else
            {
                return strInput.Trim();
            }
            return strInput;
        }

        /// <summary>返回一个随即数。随机数的最小值：1,随机数的最大值：100000000,补位字符串：0,补位数：9</summary>
        /// <returns>返回一个字符串类型随即数值</returns>
        public static string RanNum()
        {
            return RanNum(1, 100000000, "0", 9);
        }

        /// <summary>返回一个随即数。补位字符串：0,补位数：9</summary>
        /// <param name="minNum">随机数的最小值</param>
        /// <param name="maxNum">随机数的最大值</param>
        /// <returns>返回一个字符串类型随即数值</returns>
        public static string RanNum(int minNum, int maxNum)
        {
            return RanNum(minNum, maxNum, "0", 9);
        }

        /// <summary>返回一个随即数。补位数：9</summary>
        /// <param name="minNum">随机数的最小值</param>
        /// <param name="maxNum">随机数的最大值</param>
        /// <param name="digitStr">补位字符串</param>
        /// <returns>返回一个字符串类型随即数值</returns>
        public static string RanNum(int minNum, int maxNum, string digitStr)
        {
            return RanNum(minNum, maxNum, digitStr, 9);
        }

        /// <summary>返回一个随即数。补位字符串：0</summary>
        /// <param name="minNum">随机数的最小值</param>
        /// <param name="maxNum">随机数的最大值</param>
        /// <param name="digit">补位数</param>
        /// <returns>返回一个字符串类型随即数值</returns>
        public static string RanNum(int minNum, int maxNum, int digit)
        {
            return RanNum(minNum, maxNum, "0", digit);
        }

        /// <summary>返回一个随即数。</summary>
        /// <param name="minNum">随机数的最小值</param>
        /// <param name="maxNum">随机数的最大值</param>
        /// <param name="digitStr">补位字符串</param>
        /// <param name="digit">补位数</param>
        /// <returns>返回一个字符串类型随即数值</returns>
        public static string RanNum(int minNum, int maxNum, string digitStr, int digit)
        {
            Random random = new Random(Seed);
            return LStrDup(random.Next(minNum, maxNum).ToString(), digitStr, digit);
        }

        /// <summary>返回一个32位长度的随即字符串。</summary>
        /// <returns>返回一个32位长度的随即字符串。</returns>
        public static string RanStr()
        {
            return RanStr(32, Guid.NewGuid().ToString("N"));
        }

        /// <summary>返回一个指定长度的随即字符串。</summary>
        /// <param name="keyNum">随即字符串生成位数</param>
        /// <returns>返回一个指定长度的随即字符串。</returns>
        public static string RanStr(int keyNum)
        {
            return RanStr(keyNum, Guid.NewGuid().ToString("N"));
        }

        /// <summary>返回一个指定长度和指定的随即提取字符串随即字符串。</summary>
        /// <param name="keyNum">随即字符串生成位数</param>
        /// <param name="keyStrs">随即字符串提取字符串</param>
        /// <returns>返回一个指定长度和指定的随即提取字符串随即字符串。</returns>
        public static string RanStr(int keyNum, string keyStrs)
        {
            StringBuilder sb = new StringBuilder();
            Random rand = new Random(Seed);
            for (int i = 0; i < keyNum; i++)
            {
                sb.Append(keyStrs.Substring(rand.Next(0, keyStrs.Length), 1));
            }
            return sb.ToString();
        }

        /// <summary>返回一个指定长度及种子的随即字符串。</summary>
        /// <param name="keyNum">随即字符串生成位数</param>
        /// <param name="seed">随即种子</param>
        /// <returns>返回一个指定长度及种子的随即字符串。</returns>
        public static string RanStr(int keyNum, int seed)
        {

            return RanStr(keyNum, seed, Guid.NewGuid().ToString("N"));
        }

        /// <summary>返回一个指定长度及种子并和指定的随即提取字符串随即字符串。</summary>
        /// <param name="keyNum">随即字符串生成位数</param>
        /// <param name="seed">随即种子</param>
        /// <param name="keyStrs">随即字符串提取字符串</param>
        /// <returns>返回一个指定长度及种子并和指定的随即提取字符串随即字符串。</returns>
        public static string RanStr(int keyNum, int seed, string keyStrs)
        {
            StringBuilder sb = new StringBuilder();
            Random rand = new Random(seed);
            for (int i = 0; i < keyNum; i++)
            {
                sb.Append(keyStrs.Substring(rand.Next(0, keyStrs.Length), 1));
            }
            return sb.ToString();
        }

        /// <summary>返回一个由时间+长整数自增数组成的随即字符串(共计35位字符)</summary>
        /// <returns>返回一个由时间+长整数自增数组成的随即字符串(共计35位字符)</returns>
        public static string GetLongAddup()
        {
            return DateOften.ReFDateTime("{$Year}{$Month}{$Day}{$Hour}{$Minute}{$Second}{$Millisecond}{$Addlongup}", DateTime.Now);
        }

        /// <summary>返回一个由时间+自增数组成的随即字符串(共计25位字符)</summary>
        /// <returns>返回一个由时间+自增数组成的随即字符串(共计25位字符)</returns>
        public static string GetAddup()
        {
            return DateOften.ReFDateTime("{$Year}{$Month}{$Day}{$Hour}{$Minute}{$Second}{$Millisecond}{$Addup}", DateTime.Now);
        }

        /// <summary>返回一个由时间+随即数组成的随即字符串(共计25位字符)</summary>
        /// <returns>返回一个由时间+随即数组成的随即字符串(共计25位字符)</returns>
        public static string GetRanChr()
        {
            return DateOften.ReFDateTime("{$Year}{$Month}{$Day}{$Hour}{$Minute}{$Second}{$Millisecond}{$Random}", DateTime.Now);
        }

        /// <summary> 获取字符串长度(按单字节模式计算长度)</summary>
        /// <param name="strInput">要获取长度的字符串</param>
        /// <returns>返回长度值</returns>
        public static int LenStr(string strInput)
        {
            return Encoding.Default.GetByteCount(strInput);
        }

        /// <summary>输入字符串超过指定长度则截取字符串(按单字节模式计算长度)</summary>
        /// <param name="strInput">要截取的字符串</param>
        /// <param name="intLen">截取长度</param>
        /// <returns>返回已被截取后的字符串</returns>
        public static string MidStr(string strInput, int intLen)
        {
            if (intLen <= 0)
            {
                return "";
            }
            byte[] myByte = Encoding.Default.GetBytes(strInput);
            if (myByte.Length > intLen)
            {
                System.Text.StringBuilder resultStr = new System.Text.StringBuilder();
                for (int i = 0; i < strInput.Length; i++)
                {
                    byte[] tempByte = Encoding.Default.GetBytes(resultStr.ToString());
                    if (tempByte.Length < intLen)
                    {
                        resultStr.Append(strInput.Substring(i, 1));
                    }
                    else
                    {
                        break;
                    }
                }
                if (LenStr(resultStr.ToString()) > intLen)
                {
                    resultStr.Remove(resultStr.Length - 1, 1);
                }
                return resultStr.ToString();
            }
            else
            {
                return strInput;
            }
        }

        /// <summary>输入字符串超过指定长度则截取字符串并添加默认省略符(按单字节模式计算长度)</summary>
        /// <param name="strInput">要截取的字符串</param>
        /// <param name="intLen">截取长度</param>
        /// <returns>返回已被截取后的字符串</returns>
        public static string MidStrAb(string strInput, int intLen)
        {
            if (intLen <= 0)
            {
                return "";
            }
            int slen = LenStr(strInput);
            if (slen <= intLen)
            {
                return strInput;
            }
            string mstr = MidStr(strInput, intLen - 1);
            string addstr = CharDup('.', intLen - LenStr(mstr));
            return mstr + addstr;
        }

        /// <summary>输入字符串超过指定长度则截取字符串并添加省略符(按单字节模式计算长度)</summary>
        /// <param name="strInput">要截取的字符串</param>
        /// <param name="intLen">截取长度</param>
        /// <param name="abridge">省略字符串</param>
        /// <returns>返回已被截取后的字符串</returns>
        public static string MidStrAb(string strInput, int intLen, string abridge)
        {
            if (intLen <= 0)
            {
                return "";
            }
            int slen = LenStr(strInput);
            if (slen <= intLen)
            {
                return strInput;
            }
            string mstr = MidStr(strInput, intLen - 1);
            string addstr = StrDup(abridge, intLen - LenStr(mstr));
            return mstr + addstr;
        }

        /// <summary>输入字符串超过指定长度则截取字符串(按双字节模式计算长度)</summary>
        /// <param name="strInput">要截取的字符串</param>
        /// <param name="intLen">截取长度</param>
        /// <returns>返回已被截取后的字符串</returns>
        public static string MidLStr(string strInput, int intLen)
        {
            if (intLen < 0)
            {
                return strInput;
            }
            if (strInput.Length > intLen)
            {
                return strInput.Substring(0, intLen);
            }
            return strInput;
        }

        /// <summary>输入字符串超过指定长度则截取字符串并添加默认省略符(按双字节模式计算长度)</summary>
        /// <param name="strInput">要截取的字符串</param>
        /// <param name="intLen">截取长度</param>
        /// <returns>返回已被截取后的字符串</returns>
        public static string MidLStrAb(string strInput, int intLen)
        {
            if (strInput.Length <= intLen)
            {
                return strInput;
            }
            string mstr = MidLStr(strInput, intLen - 1);
            string addstr = CharDup('.', intLen - LenStr(mstr));
            return mstr + addstr;
        }

        /// <summary>输入字符串超过指定长度则截取字符串并添加省略符(按双字节模式计算长度)</summary>
        /// <param name="strInput">要截取的字符串</param>
        /// <param name="intLen">截取长度</param>
        /// <param name="abridge">省略字符串</param>
        /// <returns>返回已被截取后的字符串</returns>
        public static string MidLStrAb(string strInput, int intLen, string abridge)
        {
            if (strInput.Length <= intLen)
            {
                return strInput;
            }
            string mstr = MidLStr(strInput, intLen - 1);
            string addstr = StrDup(abridge, intLen - LenStr(mstr));
            return mstr + addstr;
        }

        /// <summary>获取可省略参数数组</summary>
        /// <param name="parm">可省略参数数组</param>
        /// <param name="abridge">默认参数数组</param>
        /// <returns>返回已更新默认值的参数数组</returns>
        public static ArrayList GetParm(ArrayList parm, ArrayList abridge)
        {
            for (int i = 0; i < abridge.Count; i++)
            {
                if (parm.Count > i)
                {
                    if (parm[i] != null)
                    {
                        abridge[i] = parm[i];
                    }
                }
            }
            return abridge;
        }

        /// <summary>获取可省略参数char数组</summary>
        /// <param name="parm">可省略char参数数组</param>
        /// <param name="abridge">默认char参数数组</param>
        /// <returns>返回已更新默认值的参数char数组</returns>
        public static List<char> TypeParm(List<char> parm, List<char> abridge)
        {
            for (int i = 0; i < abridge.Count; i++)
            {
                if (parm.Count > i)
                {
                    abridge[i] = parm[i];
                }
            }
            return abridge;
        }

        /// <summary>获取可省略参数string数组</summary>
        /// <param name="parm">可省略string参数数组</param>
        /// <param name="abridge">默认string参数数组</param>
        /// <returns>返回已更新默认值的参数string数组</returns>
        public static List<string> TypeParm(List<string> parm, List<string> abridge)
        {
            for (int i = 0; i < abridge.Count; i++)
            {
                if (parm.Count > i)
                {
                    if (parm[i] != null)
                    {
                        abridge[i] = parm[i];
                    }
                }
            }
            return abridge;
        }

        /// <summary>获取可省略参数byte数组</summary>
        /// <param name="parm">可省略byte参数数组</param>
        /// <param name="abridge">默认byte参数数组</param>
        /// <returns>返回已更新默认值的参数byte数组</returns>
        public static List<byte> TypeParm(List<byte> parm, List<byte> abridge)
        {
            for (int i = 0; i < abridge.Count; i++)
            {
                if (parm.Count > i)
                {
                    abridge[i] = parm[i];
                }
            }
            return abridge;
        }

        /// <summary>获取可省略参数int数组</summary>
        /// <param name="parm">可省略int参数数组</param>
        /// <param name="abridge">默认int参数数组</param>
        /// <returns>返回已更新默认值的参数int数组</returns>
        public static List<int> TypeParm(List<int> parm, List<int> abridge)
        {
            for (int i = 0; i < abridge.Count; i++)
            {
                if (parm.Count > i)
                {
                    abridge[i] = parm[i];
                }
            }
            return abridge;
        }

        /// <summary>获取可省略参数long数组</summary>
        /// <param name="parm">可省略long参数数组</param>
        /// <param name="abridge">默认long参数数组</param>
        /// <returns>返回已更新默认值的参数long数组</returns>
        public static List<long> TypeParm(List<long> parm, List<long> abridge)
        {
            for (int i = 0; i < abridge.Count; i++)
            {
                if (parm.Count > i)
                {
                    abridge[i] = parm[i];
                }
            }
            return abridge;
        }

        /// <summary>返回当前应用程序相对根目录的绝对路径  例子：GetAbsPath(Server.MapPath("../about.aspx"), "/", Server.MapPath("/"));</summary>
        /// <param name="mPath">当前应用程序物理路径</param>
        /// <param name="topPath">应用程序的虚拟应用程序根路径</param>
        /// <param name="topDrivePath">应用程序的虚拟应用程序根物理路径</param>
        /// <returns>返回当前应用程序相对根目录的绝对路径</returns>
        public static string GetAbsPath(string mPath, string topPath, string topDrivePath)
        {
            mPath = mPath.Remove(0, topDrivePath.Length);
            mPath = mPath.Replace("\\", "/");
            mPath = topPath + mPath;
            return mPath;
        }

        /// <summary>清除html格式输出文本</summary>
        /// <param name="strInput">要清除的html字符串</param>
        /// <returns>返回已被清除html的字符串</returns>
        public static string OutText(string strInput)
        {
            if (strInput.Length > 0)
            {
                strInput = Regex.Replace(strInput, "<head[^>]*>", "<head>", RegexOptions.IgnoreCase | RegexOptions.Singleline);
                strInput = Regex.Replace(strInput, "</head[^>]*>", "</head>", RegexOptions.IgnoreCase | RegexOptions.Singleline);

                RegReplace(ref strInput, "<head>", "</head>");

                strInput = Regex.Replace(strInput, "<script[^>]*>", "<script>", RegexOptions.IgnoreCase | RegexOptions.Singleline);
                strInput = Regex.Replace(strInput, "</script[^>]*>", "</script>", RegexOptions.IgnoreCase | RegexOptions.Singleline);

                RegReplace(ref strInput, "<script>", "</script>");

                strInput = Regex.Replace(strInput, "<style[^>]*>", "<style>", RegexOptions.IgnoreCase | RegexOptions.Singleline);
                strInput = Regex.Replace(strInput, "</style[^>]*>", "</style>", RegexOptions.IgnoreCase | RegexOptions.Singleline);

                RegReplace(ref strInput, "<style>", "</style>");

                strInput = strInput.Replace("&nbsp;", " ");
                strInput = Regex.Replace(strInput, "<br[^>]*>", "\r\n", RegexOptions.IgnoreCase | RegexOptions.Singleline);
                strInput = Regex.Replace(strInput, "<td[^>]*>", " ", RegexOptions.IgnoreCase | RegexOptions.Singleline);
                strInput = Regex.Replace(strInput, "<tr[^>]*>", "\r\n", RegexOptions.IgnoreCase | RegexOptions.Singleline);

                strInput = Regex.Replace(strInput, "<(.[^>]*)>", "", RegexOptions.IgnoreCase | RegexOptions.Singleline);
            }
            return strInput;
        }

        /// <summary>清除html格式输出纯文本</summary>
        /// <param name="strInput">要清除的html字符串</param>
        /// <returns>返回已被清除html的字符串</returns>
        public static string OutTxt(string strInput)
        {
            if (strInput.Length > 0)
            {
                strInput = Regex.Replace(strInput, "<head[^>]*>", "<head>", RegexOptions.IgnoreCase | RegexOptions.Singleline);
                strInput = Regex.Replace(strInput, "</head[^>]*>", "</head>", RegexOptions.IgnoreCase | RegexOptions.Singleline);

                RegReplace(ref strInput, "<head>", "</head>");

                strInput = Regex.Replace(strInput, "<script[^>]*>", "<script>", RegexOptions.IgnoreCase | RegexOptions.Singleline);
                strInput = Regex.Replace(strInput, "</script[^>]*>", "</script>", RegexOptions.IgnoreCase | RegexOptions.Singleline);

                RegReplace(ref strInput, "<script>", "</script>");

                strInput = Regex.Replace(strInput, "<style[^>]*>", "<style>", RegexOptions.IgnoreCase | RegexOptions.Singleline);
                strInput = Regex.Replace(strInput, "</style[^>]*>", "</style>", RegexOptions.IgnoreCase | RegexOptions.Singleline);

                RegReplace(ref strInput, "<style>", "</style>");

                strInput = Regex.Replace(strInput, "<(.[^>]*)>", "", RegexOptions.IgnoreCase | RegexOptions.Singleline);
            }
            return strInput;
        }

        /// <summary>根据首字符串与尾字符串循环清除首与尾之间字符串</summary>
        /// <param name="strInput">要清除的html字符串</param>
        /// <param name="Rea">首字符串</param>
        /// <param name="Reb">尾字符串</param>
        /// <returns></returns>
        public static void RegReplace(ref string strInput, string Rea, string Reb)
        {
            int inRea = strInput.IndexOf(Rea);
            int inReb = strInput.IndexOf(Reb);
            if (inRea > -1 && inReb > -1 && inReb > inRea)
            {
                strInput = strInput.Remove(inRea, inReb - inRea + Reb.Length);
                RegReplace(ref strInput, Rea, Reb);
            }
        }

        /// <summary>将WebUrl相对地址换成绝对地址</summary>
        /// <param name="BaseUrl">基Url地址</param>
        /// <param name="theUrl">相对Url地址</param>
        /// <returns>返回绝对地址</returns>
        public static string FormatUrl(string BaseUrl, string theUrl)
        {
            try
            {
                Uri baseUri = new Uri(BaseUrl);
                Uri theUri = new Uri(baseUri, theUrl);
                return theUri.AbsoluteUri;
            }
            catch
            {
                return theUrl;
            }
        }

        /// <summary>检查输入的数据库列名并返回合法的数据库列名(默认输出的列名为合法数据库列名的第一个)</summary>
        /// <param name="sqlName">需要检查的数据库列名</param>
        /// <param name="sqlNames">合法的数据库列名，多个列名使用,分隔。例如：Name,Email</param>
        /// <returns>返回合法的数据库列名</returns>
        public static string GetSqlName(string sqlName, string sqlNames)
        {
            string defName = sqlNames.Split(',')[0].Trim();
            return GetSqlName(sqlName, sqlNames, defName, ",");
        }

        /// <summary>检查输入的数据库列名并返回合法的数据库列名</summary>
        /// <param name="sqlName">需要检查的数据库列名</param>
        /// <param name="sqlNames">合法的数据库列名，多个列名使用,分隔。例如：Name,Email</param>
        /// <param name="defName">默认输出的列名</param>
        /// <returns>返回合法的数据库列名</returns>
        public static string GetSqlName(string sqlName, string sqlNames, string defName)
        {
            return GetSqlName(sqlName, sqlNames, defName, ",");
        }

        /// <summary>检查输入的数据库列名并返回合法的数据库列名</summary>
        /// <param name="sqlName">需要检查的数据库列名</param>
        /// <param name="sqlNames">合法的数据库列名，多个列名使用part指定的分隔符分隔。例如：Name,Email</param>
        /// <param name="defName">默认输出的列名</param>
        /// <param name="part">分隔符</param>
        /// <returns>返回合法的数据库列名</returns>
        public static string GetSqlName(string sqlName, string sqlNames, string defName, string part)
        {
            if (sqlName.Trim() == "" || sqlNames.Trim() == "")
            {
                return defName;
            }
            sqlNames = part + sqlNames + part;
            if (sqlNames.IndexOf(part + sqlName + part) > -1)
            {
                return sqlName;
            }
            else
            {
                return defName;
            }
        }

        #endregion

        #region 常用数值效验

        /// <summary>对象效验,效验成功返回true 否则返回false
        /// <para>mode：</para>
        /// <para>0  IsInt32</para>
        /// <para>1  IsDate</para>
        /// <para>2  IsNum</para>
        /// <para>3  IsInt64</para>
        /// <para>4  IsInt16</para>
        /// <para>5  IsByte</para>
        /// <para>6  IsSByte</para>
        /// <para>7  IsUrl</para>
        /// <para>8  IsUInt64</para>
        /// <para>9  IsUInt32</para>
        /// <para>10 IsUInt16</para>
        /// </summary>
        /// <param name="inStr">需要效验的对象</param>
        /// <param name="mode">效验模式</param>
        /// <returns>对象效验,效验成功返回true 否则返回false</returns>
        public static bool IsVer(object inStr, int mode)
        {
            switch (mode)
            {
                case 0:
                    return IsInt32(inStr);
                case 1:
                    return IsDate(inStr);
                case 2:
                    return IsNum(inStr);
                case 3:
                    return IsInt64(inStr);
                case 4:
                    return IsInt16(inStr);
                case 5:
                    return IsByte(inStr);
                case 6:
                    return IsSByte(inStr);
                case 7:
                    return IsUrl(inStr);
                case 8:
                    return IsUInt64(inStr);
                case 9:
                    return IsUInt32(inStr);
                case 10:
                    return IsUInt16(inStr);
            }
            return false;
        }

        /// <summary>字符串效验,效验成功返回true 否则返回false
        /// <para>mode：</para>
        /// <para>0  IsInt32</para>
        /// <para>1  IsDate</para>
        /// <para>2  IsNum</para>
        /// <para>3  IsInt64</para>
        /// <para>4  IsInt16</para>
        /// <para>5  IsByte</para>
        /// <para>6  IsSByte</para>
        /// <para>7  IsUrl</para>
        /// <para>8  IsUInt64</para>
        /// <para>9  IsUInt32</para>
        /// <para>10 IsUInt16</para>
        /// </summary>
        /// <param name="inStr">需要效验的字符串</param>
        /// <param name="mode">效验模式</param>
        /// <returns>字符串效验,效验成功返回true 否则返回false</returns>
        public static bool IsVer(string inStr, int mode)
        {
            switch (mode)
            {
                case 0:
                    return IsInt32(inStr);
                case 1:
                    return IsDate(inStr);
                case 2:
                    return IsNum(inStr);
                case 3:
                    return IsInt64(inStr);
                case 4:
                    return IsInt16(inStr);
                case 5:
                    return IsByte(inStr);
                case 6:
                    return IsSByte(inStr);
                case 7:
                    return IsUrl(inStr);
                case 8:
                    return IsUInt64(inStr);
                case 9:
                    return IsUInt32(inStr);
                case 10:
                    return IsUInt16(inStr);
            }
            return false;
        }

        /// <summary>正则表达式验证输入字符串，匹配返回 true 不匹配 返回 false</summary>
        /// <param name="strIn">要验证的字符串</param>
        /// <param name="regStr">正则表达式</param>
        /// <returns>返回true | false</returns>
        public static bool StrIsReg(string strIn, string regStr)
        {
            return Regex.IsMatch(strIn, regStr);
        }

        /// <summary>字符串是否为空白检验，成功返回 true 失败返回 false</summary>
        /// <param name="inStr">需要检验的字符串</param>
        /// <returns>成功返回 true 失败返回 false</returns>
        public static bool StrVer(string inStr)
        {
            string outErrStr = "";
            return StrVer(inStr, true, -1, -1, true, ref outErrStr);
        }

        /// <summary>字符串长度检验，成功返回 true 失败返回 false</summary>
        /// <param name="inStr">需要检验的字符串</param>
        /// <param name="minLeng">最小长度限制检验。该值等于-1不效验</param>
        /// <param name="maxLeng">最大长度限制检验。该值等于-1不效验</param>
        /// <param name="isSingle">单字节/双字节模式。  True 单字节长度检验 | False 双字节长度检验</param>
        /// <returns>成功返回 true 失败返回 false</returns>
        public static bool StrVer(string inStr, int minLeng, int maxLeng, bool isSingle)
        {
            string outErrStr = "";
            return StrVer(inStr, false, minLeng, maxLeng, isSingle, ref outErrStr);
        }

        /// <summary>字符串检验，成功返回 true 失败返回 false</summary>
        /// <param name="inStr">需要检验的字符串</param>
        /// <param name="isEmpty">是否为空白字符串检验。 true 检验 | false 不检验</param>
        /// <param name="minLeng">最小长度限制检验。该值等于-1不效验</param>
        /// <param name="maxLeng">最大长度限制检验。该值等于-1不效验</param>
        /// <param name="isSingle">单字节/双字节模式。  True 单字节长度检验 | False 双字节长度检验</param>
        /// <returns>成功返回 true 失败返回 false</returns>
        public static bool StrVer(string inStr, bool isEmpty, int minLeng, int maxLeng, bool isSingle)
        {
            string outErrStr = "";
            return StrVer(inStr, isEmpty, minLeng, maxLeng, isSingle, ref outErrStr);
        }

        /// <summary>字符串检验，成功返回 true 失败返回 false</summary>
        /// <param name="inStr">需要检验的字符串</param>
        /// <param name="isEmpty">是否为空白字符串检验。 true 检验 | false 不检验</param>
        /// <param name="minLeng">最小长度限制检验。该值等于-1不效验</param>
        /// <param name="maxLeng">最大长度限制检验。该值等于-1不效验</param>
        /// <param name="isSingle">单字节/双字节模式。  True 单字节长度检验 | False 双字节长度检验</param>
        /// <param name="outErrStr">检验失败输出的错误信息，没有发生错误则输出空字符串</param>
        /// <returns>成功返回 true 失败返回 false</returns>
        public static bool StrVer(string inStr, bool isEmpty, int minLeng, int maxLeng, bool isSingle, ref string outErrStr)
        {
            if (isEmpty == true)
            {
                if (inStr.Trim() == "")
                {
                    outErrStr = "不能为空";
                    return false;
                }
            }
            if (minLeng > -1)
            {
                if (isSingle)
                {
                    if (Often.LenStr(inStr) < minLeng)
                    {
                        outErrStr = "长度不能小于" + minLeng.ToString();
                        return false;
                    }
                }
                else
                {
                    if (inStr.Length < minLeng)
                    {
                        outErrStr = "长度不能小于" + minLeng.ToString();
                        return false;
                    }
                }
            }
            if (maxLeng > -1)
            {
                if (isSingle)
                {
                    if (Often.LenStr(inStr) > maxLeng)
                    {
                        outErrStr = "长度不能大于" + maxLeng.ToString();
                        return false;
                    }
                }
                else
                {
                    if (inStr.Length > maxLeng)
                    {
                        outErrStr = "长度不能大于" + maxLeng.ToString();
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>数字检验，成功返回 true 失败返回 false</summary>
        /// <param name="inStr">需要检验的字符串</param>
        /// <param name="isEmpty">是否为空字符串检验。 true 检验 | false 不检验</param>
        /// <param name="minNum">最小值限制检验。</param>
        /// <param name="maxNum">最大值限制检验。</param>
        /// <returns>成功返回 true 失败返回 false</returns>
        public static bool NumVer(string inStr, bool isEmpty, double minNum, double maxNum)
        {
            string outErrStr = "";
            return NumVer(inStr, isEmpty, minNum, maxNum, ref outErrStr);
        }

        /// <summary>数字检验，成功返回 true 失败返回 false</summary>
        /// <param name="inStr">需要检验的字符串</param>
        /// <param name="isEmpty">是否为空字符串检验。 true 检验 | false 不检验</param>
        /// <param name="minNum">最小值限制检验。</param>
        /// <param name="maxNum">最大值限制检验。</param>
        /// <param name="outErrStr">检验失败输出的错误信息，没有发生错误则输出空字符串</param>
        /// <returns>成功返回 true 失败返回 false</returns>
        public static bool NumVer(string inStr, bool isEmpty, double minNum, double maxNum, ref string outErrStr)
        {
            if (isEmpty == true)
            {
                if (inStr == "")
                {
                    outErrStr = "不能为空";
                    return false;
                }
            }
            if (inStr.Trim() == "")
            {
                return true;
            }
            if (IsNum(inStr) == false)
            {
                outErrStr = "必须是数字";
                return false;
            }
            if (Convert.ToDouble(inStr) < minNum)
            {
                outErrStr = "不能小于" + minNum.ToString();
                return false;
            }
            if (Convert.ToDouble(inStr) > maxNum)
            {
                outErrStr = "不能大于" + maxNum.ToString();
                return false;
            }
            return true;
        }

        /// <summary>日期检验，成功返回 true 失败返回 false</summary>
        /// <param name="inStr">需要检验的字符串</param>
        /// <param name="isEmpty">是否为空字符串检验。 true 检验 | false 不检验</param>
        /// <param name="minDate">日期最小值限制检验</param>
        /// <param name="maxDate">日期最大值限制检验</param>
        /// <param name="outErrStr">检验失败输出的错误信息，没有发生错误则输出空字符串</param>
        /// <returns>成功返回 true 失败返回 false</returns>
        public static bool DateVer(string inStr, bool isEmpty, DateTime minDate, DateTime maxDate, ref string outErrStr)
        {
            if (isEmpty == true)
            {
                if (inStr == "")
                {
                    outErrStr = "不能为空";
                    return false;
                }
            }
            if (inStr == "")
            {
                return true;
            }
            if (IsDate(inStr) == false)
            {
                outErrStr = "格式不正确";
                return false;
            }
            if (Convert.ToDateTime(inStr) < minDate)
            {
                outErrStr = "不能小于" + minDate.ToString();
                return false;
            }
            if (Convert.ToDateTime(inStr) > maxDate)
            {
                outErrStr = "不能大于" + maxDate.ToString();
                return false;
            }
            return true;
        }

        /// <summary>检验是否是日期格式，成功返回 true 失败返回 false</summary>
        /// <param name="inStr">要检验的字符串</param>
        /// <returns>成功返回 true 失败返回 false</returns>
        public static bool IsDate(string inStr)
        {
            try
            {
                if (inStr.Trim() == "")
                {
                    return false;
                }
                DateTime dstr = Convert.ToDateTime(inStr);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>检验是否是数字格式，成功返回 true 失败返回 false</summary>
        /// <param name="inStr">要检验的字符串</param>
        /// <returns>成功返回 true 失败返回 false</returns>
        public static bool IsNum(string inStr)
        {
            try
            {
                if (inStr.Trim() == "")
                {
                    return false;
                }
                double dstr = Convert.ToDouble(inStr);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>检验是否是UInt64无符号整数格式，成功返回 true 失败返回 false</summary>
        /// <param name="inStr">要检验的字符串</param>
        /// <returns>成功返回 true 失败返回 false</returns>
        public static bool IsUInt64(string inStr)
        {
            try
            {
                if (inStr.Trim() == "")
                {
                    return false;
                }
                UInt64 dstr = Convert.ToUInt64(inStr);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>检验是否是UInt32无符号整数格式，成功返回 true 失败返回 false</summary>
        /// <param name="inStr">要检验的字符串</param>
        /// <returns>成功返回 true 失败返回 false</returns>
        public static bool IsUInt32(string inStr)
        {
            try
            {
                if (inStr.Trim() == "")
                {
                    return false;
                }
                UInt32 dstr = Convert.ToUInt32(inStr);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>检验是否是UInt16无符号整数格式，成功返回 true 失败返回 false</summary>
        /// <param name="inStr">要检验的字符串</param>
        /// <returns>成功返回 true 失败返回 false</returns>
        public static bool IsUInt16(string inStr)
        {
            try
            {
                if (inStr.Trim() == "")
                {
                    return false;
                }
                UInt16 dstr = Convert.ToUInt16(inStr);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>检验是否是Byte无符号整数格式，成功返回 true 失败返回 false</summary>
        /// <param name="inStr">要检验的字符串</param>
        /// <returns>成功返回 true 失败返回 false</returns>
        public static bool IsByte(string inStr)
        {
            try
            {
                if (inStr.Trim() == "")
                {
                    return false;
                }
                byte dstr = Convert.ToByte(inStr);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>检验是否是Int64有符号整数格式，成功返回 true 失败返回 false</summary>
        /// <param name="inStr">要检验的字符串</param>
        /// <returns>成功返回 true 失败返回 false</returns>
        public static bool IsInt64(string inStr)
        {
            try
            {
                if (inStr.Trim() == "")
                {
                    return false;
                }
                Int64 dstr = Convert.ToInt64(inStr);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>检验是否是Int32有符号整数格式，成功返回 true 失败返回 false</summary>
        /// <param name="inStr">要检验的字符串</param>
        /// <returns>成功返回 true 失败返回 false</returns>
        public static bool IsInt32(string inStr)
        {
            try
            {
                if (inStr.Trim() == "")
                {
                    return false;
                }
                Int32 dstr = Convert.ToInt32(inStr);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>检验是否是Int16有符号整数格式，成功返回 true 失败返回 false</summary>
        /// <param name="inStr">要检验的字符串</param>
        /// <returns>成功返回 true 失败返回 false</returns>
        public static bool IsInt16(string inStr)
        {
            try
            {
                if (inStr.Trim() == "")
                {
                    return false;
                }
                Int16 dstr = Convert.ToInt16(inStr);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>检验是否是SByte有符号整数格式，成功返回 true 失败返回 false</summary>
        /// <param name="inStr">要检验的字符串</param>
        /// <returns>成功返回 true 失败返回 false</returns>
        public static bool IsSByte(string inStr)
        {
            try
            {
                if (inStr.Trim() == "")
                {
                    return false;
                }
                SByte dstr = Convert.ToSByte(inStr);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>检验是否Url，成功返回 true 失败返回 false</summary>
        /// <param name="urls">要检验的字符串</param>
        /// <returns>成功返回 true 失败返回 false</returns>
        public static bool IsUrl(string urls)
        {
            try
            {
                Uri myUri = new Uri(urls);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>检验是否是日期格式，成功返回 true 失败返回 false</summary>
        /// <param name="inStr">要检验的字符串</param>
        /// <returns>成功返回 true 失败返回 false</returns>
        public static bool IsDate(object inStr)
        {
            try
            {
                if (inStr == null)
                {
                    return false;
                }
                DateTime dstr = Convert.ToDateTime(inStr);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>检验是否是数字格式，成功返回 true 失败返回 false</summary>
        /// <param name="inStr">要检验的字符串</param>
        /// <returns>成功返回 true 失败返回 false</returns>
        public static bool IsNum(object inStr)
        {
            try
            {
                if (inStr == null)
                {
                    return false;
                }
                double dstr = Convert.ToDouble(inStr);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>检验是否是UInt64无符号整数格式，成功返回 true 失败返回 false</summary>
        /// <param name="inStr">要检验的字符串</param>
        /// <returns>成功返回 true 失败返回 false</returns>
        public static bool IsUInt64(object inStr)
        {
            try
            {
                if (inStr == null)
                {
                    return false;
                }
                UInt64 dstr = Convert.ToUInt64(inStr);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>检验是否是UInt32无符号整数格式，成功返回 true 失败返回 false</summary>
        /// <param name="inStr">要检验的字符串</param>
        /// <returns>成功返回 true 失败返回 false</returns>
        public static bool IsUInt32(object inStr)
        {
            try
            {
                if (inStr == null)
                {
                    return false;
                }
                UInt32 dstr = Convert.ToUInt32(inStr);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>检验是否是UInt16无符号整数格式，成功返回 true 失败返回 false</summary>
        /// <param name="inStr">要检验的字符串</param>
        /// <returns>成功返回 true 失败返回 false</returns>
        public static bool IsUInt16(object inStr)
        {
            try
            {
                if (inStr == null)
                {
                    return false;
                }
                UInt16 dstr = Convert.ToUInt16(inStr);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>检验是否是Byte无符号整数格式，成功返回 true 失败返回 false</summary>
        /// <param name="inStr">要检验的字符串</param>
        /// <returns>成功返回 true 失败返回 false</returns>
        public static bool IsByte(object inStr)
        {
            try
            {
                if (inStr == null)
                {
                    return false;
                }
                byte dstr = Convert.ToByte(inStr);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>检验是否是Int64有符号整数格式，成功返回 true 失败返回 false</summary>
        /// <param name="inStr">要检验的字符串</param>
        /// <returns>成功返回 true 失败返回 false</returns>
        public static bool IsInt64(object inStr)
        {
            try
            {
                if (inStr == null)
                {
                    return false;
                }
                Int64 dstr = Convert.ToInt64(inStr);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>检验是否是Int32有符号整数格式，成功返回 true 失败返回 false</summary>
        /// <param name="inStr">要检验的字符串</param>
        /// <returns>成功返回 true 失败返回 false</returns>
        public static bool IsInt32(object inStr)
        {
            try
            {
                if (inStr == null)
                {
                    return false;
                }
                Int32 dstr = Convert.ToInt32(inStr);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>检验是否是Int16有符号整数格式，成功返回 true 失败返回 false</summary>
        /// <param name="inStr">要检验的字符串</param>
        /// <returns>成功返回 true 失败返回 false</returns>
        public static bool IsInt16(object inStr)
        {
            try
            {
                if (inStr == null)
                {
                    return false;
                }
                Int16 dstr = Convert.ToInt16(inStr);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>检验是否是SByte有符号整数格式，成功返回 true 失败返回 false</summary>
        /// <param name="inStr">要检验的字符串</param>
        /// <returns>成功返回 true 失败返回 false</returns>
        public static bool IsSByte(object inStr)
        {
            try
            {
                if (inStr == null)
                {
                    return false;
                }
                SByte dstr = Convert.ToSByte(inStr);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>检验是否Url，成功返回 true 失败返回 false</summary>
        /// <param name="urls">要检验的字符串</param>
        /// <returns>成功返回 true 失败返回 false</returns>
        public static bool IsUrl(object urls)
        {
            try
            {
                if (urls == null)
                {
                    return false;
                }
                Uri myUri = new Uri(urls.ToString());
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>字母是否大写判断</summary>
        /// <param name="inStr">需要判断的字母</param>
        /// <returns>如果是大写返回true 如果是小写就返回false</returns>
        public static bool IsUpper(string inStr)
        {
            if (inStr == inStr.ToUpper())
            {
                return true;
            }
            return false;
        }

        /// <summary>判断路径文件名后缀是否在指定的后缀，如果存在返回true，否则返回false</summary>
        /// <param name="path">文件路径</param>
        /// <param name="opt">验证所需后缀字符串组，多个后缀使用|分隔。 例如： jpg|jpeg|bmp</param>
        /// <returns>如果存在返回true，否则返回false</returns>
        public static bool IsExt(string path, string opt)
        {
            if (path.Trim() == "")
            {
                return false;
            }
            string[] exta = opt.Split('|');
            for (int i = 0; i < exta.Length; i++)
            {
                string exs = "." + exta[i].Trim();
                if (path.EndsWith(exs, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>判断Url文件名后缀是否在指定的后缀，如果存在返回1，不存在返回0，无文件名则返回2</summary>
        /// <param name="urls">Url地址</param>
        /// <param name="opt">验证所需后缀字符串组，多个后缀使用|分隔。 例如： jpg|jpeg|bmp</param>
        /// <returns>如果存在返回1，不存在返回0，无文件名则返回2</returns>
        public static byte IsUrlExt(string urls, string opt)
        {
            Uri myUri = new Uri(urls);
            return IsUrlExt(myUri, opt);
        }

        /// <summary>判断Uri对象文件名后缀是否在指定的后缀，如果存在返回1，不存在返回0，无文件名则返回2</summary>
        /// <param name="urli">Uri对象</param>
        /// <param name="opt">验证所需后缀字符串组，多个后缀使用|分隔。 例如： jpg|jpeg|bmp</param>
        /// <returns>如果存在返回1，不存在返回0，无文件名则返回2</returns>
        public static byte IsUrlExt(Uri urli, string opt)
        {
            string pa = urli.Segments[urli.Segments.Length - 1];
            if (pa.IndexOf(".") == -1)
            {
                return 2;
            }
            string[] exta = opt.Split('|');
            for (int i = 0; i < exta.Length; i++)
            {
                string exs = "." + exta[i].Trim();
                if (pa.EndsWith(exs, StringComparison.OrdinalIgnoreCase))
                {
                    return 1;
                }
            }
            return 0;
        }

        /// <summary>判断一个url是否和另一个url的域相同，如果相同返回true，不相同返回false</summary>
        /// <param name="urla">第一个Url地址</param>
        /// <param name="urlb">第二个Url地址</param>
        /// <returns>如果相同返回true，不相同返回false</returns>
        public static bool IsUrlCompare(string urla, string urlb)
        {
            Uri myUria = new Uri(urla);
            Uri myUrib = new Uri(urlb);
            return IsUrlCompare(myUria, myUrib);
        }

        /// <summary>判断一个Uri对象是否和另一个Uri对象的域相同，如果相同返回true，不相同返回false</summary>
        /// <param name="urlia">第一个Uri对象</param>
        /// <param name="urlib">第二个Uri对象</param>
        /// <returns>如果相同返回true，不相同返回false</returns>
        public static bool IsUrlCompare(Uri urlia, Uri urlib)
        {
            int cp = Uri.Compare(urlia, urlib, UriComponents.SchemeAndServer, UriFormat.Unescaped, StringComparison.OrdinalIgnoreCase);
            if (cp == 0)
            {
                return true;
            }
            return false;
        }

        #endregion

        #region NameValueCollection操作

        /// <summary>由NameValueCollection返回指定键的一个值</summary>
        /// <param name="InName">一个NameValueCollection对象</param>
        /// <param name="item">键的名称</param>
        /// <returns>返回指定键的第一个值</returns>
        public static string GetName(NameValueCollection InName, string item)
        {
            string[] strS = InName.GetValues(item);
            if (strS != null)
            {
                return strS[0];
            }
            return "";
        }

        /// <summary>由NameValueCollection返回指定键的一个值</summary>
        /// <param name="InName">一个NameValueCollection对象</param>
        /// <param name="item">键的名称</param>
        /// <param name="num">指定键的指定索引</param>
        /// <returns>返回指定键的指定索引值</returns>
        public static string GetName(NameValueCollection InName, string item, int num)
        {
            string[] strS = InName.GetValues(item);
            if (strS != null)
            {
                if (strS.Length > num)
                {
                    return strS[num];
                }
            }
            return "";
        }

        /// <summary>由NameValueCollection返回指定索引键的一个值</summary>
        /// <param name="InName">一个NameValueCollection对象</param>
        /// <param name="item">键的索引</param>
        /// <param name="num">指定索引键的指定索引</param>
        /// <returns>返回指定索引键的指定索引值</returns>
        public static string GetName(NameValueCollection InName, int item, int num)
        {
            string[] strS = InName.GetValues(item);
            if (strS != null)
            {
                if (strS.Length > num)
                {
                    return strS[num];
                }
            }
            return "";
        }

        #endregion

        #region 常用正则表达式

        /// <summary>电子邮件校验</summary>
        public static readonly string RegExpStr_Email = @"^\w+((-\w+)|(\.\w+))*\@\w+((\.|-)\w+)*\.\w+$";

        /// <summary>网址校验校验</summary>
        public static readonly string RegExpStr_Url = @"^http://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?";

        /// <summary>邮编校验校验</summary>
        public static readonly string RegExpStr_Zip = @"\d{6}";

        /// <summary>身份证校验校验</summary> 
        public static readonly string RegExpStr_Ssn = @"\d{18}|\d{15}";

        /// <summary>严格15位身份证校验校验(15位)</summary> 
        public static readonly string RegExpStr_IDCard15 = @"^[1-9]\d{7}((0\d)|(1[0-2]))(([0|1|2]\d)|3[0-1])\d{3}$";

        /// <summary>严格18位身份证校验校验(18位)</summary> 
        public static readonly string RegExpStr_IDCard18 = @"^[1-9][0-7]\d{4}((\d{4}(0[13-9]|1[012])(0[1-9]|[12]\d|30))|(\d{4}(0[13578]|1[02])31)|(\d{4}02(0[1-9]|1\d|2[0-8]))|(\d{2}([13579][26]|[2468][048]|0[48])0229))\d{3}(\d|X|x)$";

        /// <summary>IP校验</summary>
        public static readonly string RegExpStr_Ip = @"^(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])$";

        /// <summary>日期校验</summary>
        public static readonly string RegExpStr_Date = @"^(?:(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00)))(\/|-|\.)(?:0?2\1(?:29))$)|(?:(?:1[6-9]|[2-9]\d)?\d{2})(\/|-|\.)(?:(?:(?:0?[13578]|1[02])\2(?:31))|(?:(?:0?[1,3-9]|1[0-2])\2(29|30))|(?:(?:0?[1-9])|(?:1[0-2]))\2(?:0?[1-9]|1\d|2[0-8]))$";

        /// <summary>url校验</summary>
        public static readonly string RegExpStr_ReUrl = @"^[a-zA-z]+://(\w+(-\w+)*)(\.(\w+(-\w+)*))*(\?\S*)?$";

        /// <summary>颜色值十六进格式制校验 校验格式： #ff56ee</summary>
        public static readonly string RegExpStr_Color = @"^#[0-9a-fA-F]{6}$";

        /// <summary>颜色值十进制格式校验 校验格式： 128,233,144</summary>
        public static readonly string RegExpStr_ColorTen = @"^(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\,(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\,(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])$";

        /// <summary>整数校验</summary>
        public static readonly string RegExpStr_Int = @"^\d{1,}$";

        /// <summary>数字校验</summary>
        public static readonly string RegExpStr_Demical = @"^-?(0|\d+)(\.\d+)?$";

        /// <summary>非负整数（正整数 + 0）校验</summary>
        public static readonly string RegExpStr_NotMinus = @"^\d+$";

        /// <summary>正整数校验</summary>
        public static readonly string RegExpStr_Plus = @"^[0-9]*[1-9][0-9]*$";

        /// <summary>非正整数（负整数 + 0）校验</summary>
        public static readonly string RegExpStr_NotPlus = @"^((-\d+)|(0+))$";

        /// <summary>负整数校验</summary>
        public static readonly string RegExpStr_Minus = @"^-[0-9]*[1-9][0-9]*$";

        /// <summary>非负浮点数（正浮点数 + 0）校验</summary>
        public static readonly string RegExpStr_NotMinusFr = @"^\d+(\.\d+)?$";

        /// <summary>正浮点数校验</summary>
        public static readonly string RegExpStr_PlusFr = @"^(([0-9]+\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\.[0-9]+)|([0-9]*[1-9][0-9]*))$";

        /// <summary>非正浮点数（负浮点数 + 0）校验</summary> 
        public static readonly string RegExpStr_NotPlusFr = @"^((-\d+(\.\d+)?)|(0+(\.0+)?))$";

        /// <summary>负浮点数校验</summary>
        public static readonly string RegExpStr_MinusFr = @"^(-(([0-9]+\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\.[0-9]+)|([0-9]*[1-9][0-9]*)))$";

        /// <summary>浮点数校验</summary>
        public static readonly string RegExpStr_Fraction = @"^(-?\d+)(\.\d+)?$";

        /// <summary>由26个英文字母组成的字符串校验</summary>
        public static readonly string RegExpStr_26Letter = @"^[A-Za-z]+$";

        /// <summary>由26个英文字母的大写组成的字符串校验</summary>
        public static readonly string RegExpStr_26UpperLetter = @"^[A-Z]+$";

        /// <summary>由26个英文字母的小写组成的字符串校验</summary>
        public static readonly string RegExpStr_26LowerLetter = @"^[a-z]+$";

        /// <summary>由数字和26个英文大小写字母组成的字符串校验</summary>
        public static readonly string RegExpStr_Num26Letter = @"^[A-Za-z0-9]+$";

        /// <summary>由数字和26个英文大小写字母和“-”组成的字符串校验</summary>
        public static readonly string RegExpStr_Num26LetterAnd = @"^[A-Za-z0-9-]+$";

        /// <summary>由数字、26个英文大小写字母或者中文组成的字符串校验</summary>
        public static readonly string RegExpStr_Num26LeAndCn = @"^[\u4e00-\u9fa5A-Za-z0-9]+$";

        /// <summary>由数字、下划线、26个英文大小写字母或者中文组成的字符串校验</summary>
        public static readonly string RegExpStr_Num26LeAndCna = @"^[\u4e00-\u9fa5A-Za-z0-9_]+$";

        /// <summary>由数字、26个英文字母或者下划线组成的字符串校验</summary>
        public static readonly string RegExpStr_SNum26LeLine = @"^[A-Za-z0-9_]+$";

        /// <summary>首字符必须是字母后续字符由数字、26个英文字母或者下划线组成的字符串校验</summary>
        public static readonly string RegExpStr_S26NumLeLine = @"^[A-Za-z][A-Za-z0-9_]+$";

        /// <summary>手机号字符串效验</summary>
        public static readonly string RegExpStr_MOBILEPHONE = "^0?(1[34578][0-9])[0-9]{8}$";

        /// <summary>固定电话效验</summary>
        public static readonly string RegExpStr_PHONE = "^((\\d{7,8})|(\\d{4}|\\d{3})-(\\d{7,8})|(\\d{4}|\\d{3})-(\\d{7,8})-(\\d{4}|\\d{3}|\\d{2}|\\d{1})|(\\d{7,8})-(\\d{4}|\\d{3}|\\d{2}|\\d{1}))$";

        #endregion

        #region 常用编码及解码和字符转义

        /// <summary>Html编码</summary> 
        /// <param name="strIn">要编码的字符串</param>
        /// <returns>返回已编码的字符串</returns>
        public static string EasyHtmlEncode(string strIn)
        {
            StringBuilder strB = new StringBuilder();
            for (int i = 0; i < strIn.Length; i++)
            {
                int sbint = (int)strIn[i];
                if (sbint > 255 || sbint == 34 || sbint == 39 || sbint == 60 || sbint == 62 || sbint == 38 || sbint == 10 || sbint == 13)
                {
                    strB.Append("&#" + sbint.ToString() + ";");
                }
                else
                {
                    strB.Append(strIn[i].ToString());
                }
            }
            return strB.ToString();
        }

        /// <summary>将文本中回车、换行、空格、左尖括号、右尖括号、转换成对应Html代码</summary> 
        /// <param name="strIn">要转换的字符串</param>
        /// <returns>返回已转换的字符串</returns>
        public static string TxtToHtml(string strIn)
        {
            StringBuilder strB = new StringBuilder(strIn);
            strB.Replace(" ", "&nbsp;");
            strB.Replace("<", "&#60;");
            strB.Replace(">", "&#62;");
            strB.Replace(((char)13).ToString() + ((char)10).ToString(), "<br>");
            strB.Replace(((char)13).ToString(), "<br>");
            strB.Replace(((char)10).ToString(), "<br>");
            return strB.ToString();
        }

        /// <summary>将字符串内容转换为16进制Unicode数据编码。</summary>
        /// <param name="strEncode">需要转换的字符串</param>
        /// <param name="parm">
        /// 可省略参数列表：
        /// <para>1、string类型,前缀(默认值：\u)。 </para> 
        /// </param>
        /// <returns>返回已转换后的字符串</returns>
        public static string EnUnicode(string strEncode, params string[] parm)
        {
            List<string> abridge = new List<string>();
            abridge.Add("\\u");
            abridge = TypeParm(new List<string>(parm), abridge);
            StringBuilder strReturn = new StringBuilder();
            foreach (short shortx in strEncode.ToCharArray())
            {
                strReturn.Append(abridge[0] + shortx.ToString("X4"));
            }
            return strReturn.ToString();
        }

        /// <summary>将16进制Unicode数据编码转换为字符串。</summary>
        /// <param name="strDecode">需要转换的字符串</param>
        /// <param name="parm">
        /// 可省略参数列表：
        /// <para>1、string类型,前缀(默认值：\u)。</para>  
        /// </param>
        /// <returns>返回已转换后的字符串</returns>
        public static string DeUnicode(string strDecode, params string[] parm)
        {
            List<string> abridge = new List<string>();
            abridge.Add("\\u");
            abridge = TypeParm(new List<string>(parm), abridge);
            StringBuilder sResult = new StringBuilder();
            int sint = abridge[0].Length + 4;
            for (int i = 0; i < strDecode.Length / sint; i++)
            {
                string ins = strDecode.Substring(i * sint, sint);
                ins = ins.Substring(abridge[0].Length, 4);
                sResult.Append((char)short.Parse(ins, global::System.Globalization.NumberStyles.HexNumber));
            }
            return sResult.ToString();
        }

        /// <summary>返回DataTable表达式转义字符串</summary>
        /// <param name="s">需要转义的字符串</param>
        /// <returns>返回DataTable表达式转义字符串</returns>
        public static string GetEscTable(string s)
        {
            StringBuilder sb = new StringBuilder();
            sb.Replace("*", "[*]");
            sb.Replace("%", "[%]");
            sb.Replace("'", "[']");
            sb.Replace("[", "[[]");
            sb.Replace("]", "[]]");
            return sb.ToString();
        }

        /// <summary>返回DataTable表达式完全转义字符串</summary>
        /// <param name="s">需要转义的字符串</param>
        /// <returns>返回DataTable表达式完全转义字符串</returns>
        public static string GetAllEscTable(string s)
        {
            StringBuilder sb = new StringBuilder();
            sb.Replace("\n", "[\n]");
            sb.Replace("\t", "[\t]");
            sb.Replace("\r", "[\r]");
            sb.Replace("~", "[~]");
            sb.Replace("(", "[(]");
            sb.Replace(")", "[)]");
            sb.Replace("#", "[#]");
            sb.Replace("\\", "[\\]");
            sb.Replace("/", "[/]");
            sb.Replace("=", "[=]");
            sb.Replace(">", "[>]");
            sb.Replace("<", "[<]");
            sb.Replace("+", "[+]");
            sb.Replace("-", "[-]");
            sb.Replace("*", "[*]");
            sb.Replace("%", "[%]");
            sb.Replace("&", "[&]");
            sb.Replace("|", "[|]");
            sb.Replace("^", "[^]");
            sb.Replace("'", "[']");
            sb.Replace("\"", "[\"]");
            sb.Replace("[", "[[]");
            sb.Replace("]", "[]]");
            return sb.ToString();
        }

        #endregion

        #region 数值转换操作

        /// <summary>将Byte数组转换成16进制字符串</summary>
        /// <param name="byteArray">Byte数组</param>
        /// <returns>返回16进制字符串</returns>
        public static string ByteToHex(byte[] byteArray)
        {
            StringBuilder outString = new StringBuilder();
            foreach (Byte b in byteArray)
            {
                outString.Append(b.ToString("X2"));
            }
            return outString.ToString();
        }

        /// <summary>将16进制字符串转换成Byte数组</summary>
        /// <param name="hexString">16进制字符串</param>
        /// <returns>返回Byte数组</returns>
        public static byte[] HexToByte(string hexString)
        {
            byte[] returnBytes = new byte[hexString.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
            {
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            }
            return returnBytes;
        }

        /// <summary>将字符串转换为全角</summary>
        /// <param name="input">字符串</param>
        /// <returns>将字符串转换为全角</returns>
        /// <remarks>全角空格为12288，半角空格为32，其他字符半角(33-126)与全角(65281-65374)的对应关系是：均相差65248</remarks>
        public static string StringToSBC(string input)
        {
            char[] c = input.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 32)
                {
                    c[i] = (char)12288;
                    continue;
                }
                if (c[i] < 127)
                    c[i] = (char)(c[i] + 65248);
            }
            return new string(c);
        }

        /// <summary>将字符串转换为半角</summary>
        /// <param name="input">字符串</param>
        /// <returns>将字符串转换为半角</returns>
        /// <remarks>全角空格为12288，半角空格为32，其他字符半角(33-126)与全角(65281-65374)的对应关系是：均相差65248</remarks> 
        public static string StringToDBC(string input)
        {
            input = GetStrNarrow(GetNumNarrow(input));
            char[] c = input.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 12288)
                {
                    c[i] = (char)32;
                    continue;
                }
                if (c[i] > 65280 && c[i] < 65375)
                    c[i] = (char)(c[i] - 65248);
            }
            return new string(c);
        }

        /// <summary>将输入字符串中的全角数字转换成半角数字并返回</summary>
        /// <param name="inStr">输入字符串</param>
        /// <returns>将输入字符串中的全角数字转换成半角数字并返回</returns>
        public static string GetNumNarrow(string inStr)
        {
            StringBuilder sb = new StringBuilder(inStr);
            sb.Replace("１", "1");
            sb.Replace("２", "2");
            sb.Replace("３", "3");
            sb.Replace("４", "4");
            sb.Replace("５", "5");
            sb.Replace("６", "6");
            sb.Replace("７", "7");
            sb.Replace("８", "8");
            sb.Replace("９", "9");
            sb.Replace("０", "0");
            sb.Replace("－", "-");
            sb.Replace("＝", "=");
            sb.Replace("＋", "+");
            sb.Replace("，", ",");
            sb.Replace("。", ".");
            sb.Replace("；", ";");
            sb.Replace("：", ":");
            sb.Replace("‘", "'");
            sb.Replace("“", "\"");
            sb.Replace("”", "\"");
            sb.Replace("’", "'");
            sb.Replace("（", "(");
            sb.Replace("）", ")");
            sb.Replace("＊", "*");
            sb.Replace("％", "%");
            sb.Replace("￥", "$");
            sb.Replace("＃", "#");
            sb.Replace("！", "!");
            sb.Replace("～", "~");
            sb.Replace("、", "|");
            sb.Replace("？", "?");
            sb.Replace("《", "<");
            sb.Replace("》", ">");
            sb.Replace("【", "[");
            sb.Replace("】", "]");
            return sb.ToString();
        }

        /// <summary>将输入字符串中的全角数字及英文转换成半角数字及英文并返回</summary>
        /// <param name="inStr">输入字符串</param>
        /// <returns>将输入字符串中的全角数字及英文转换成半角数字及英文并返回</returns>
        public static string GetStrNarrow(string inStr)
        {
            StringBuilder sb = new StringBuilder(GetNumNarrow(inStr));
            sb.Replace("ａ", "a");
            sb.Replace("ｂ", "b");
            sb.Replace("ｃ", "c");
            sb.Replace("ｄ", "d");
            sb.Replace("ｅ", "e");
            sb.Replace("ｆ", "f");
            sb.Replace("ｇ", "g");
            sb.Replace("ｈ", "h");
            sb.Replace("ｉ", "i");
            sb.Replace("ｊ", "j");
            sb.Replace("ｋ", "k");
            sb.Replace("ｌ", "l");
            sb.Replace("ｍ", "m");
            sb.Replace("ｎ", "n");
            sb.Replace("ｏ", "o");
            sb.Replace("ｐ", "p");
            sb.Replace("ｑ", "q");
            sb.Replace("ｒ", "r");
            sb.Replace("ｓ", "s");
            sb.Replace("ｔ", "t");
            sb.Replace("ｕ", "u");
            sb.Replace("ｖ", "v");
            sb.Replace("ｗ", "w");
            sb.Replace("ｘ", "x");
            sb.Replace("ｙ", "y");
            sb.Replace("ｚ", "z");
            sb.Replace("Ａ", "A");
            sb.Replace("Ｂ", "B");
            sb.Replace("Ｃ", "C");
            sb.Replace("Ｄ", "D");
            sb.Replace("Ｅ", "E");
            sb.Replace("Ｆ", "F");
            sb.Replace("Ｇ", "G");
            sb.Replace("Ｈ", "H");
            sb.Replace("Ｉ", "I");
            sb.Replace("Ｊ", "J");
            sb.Replace("Ｋ", "K");
            sb.Replace("Ｌ", "L");
            sb.Replace("Ｍ", "M");
            sb.Replace("Ｎ", "N");
            sb.Replace("Ｏ", "O");
            sb.Replace("Ｐ", "P");
            sb.Replace("Ｑ", "Q");
            sb.Replace("Ｒ", "R");
            sb.Replace("Ｓ", "S");
            sb.Replace("Ｔ", "T");
            sb.Replace("Ｕ", "U");
            sb.Replace("Ｖ", "V");
            sb.Replace("Ｗ", "W");
            sb.Replace("Ｘ", "X");
            sb.Replace("Ｙ", "Y");
            sb.Replace("Ｚ", "Z");
            return sb.ToString();
        }

        /// <summary>数值转换操作方法列表：
        /// <para>1、十进制转二进制：    Convert.ToString(69, 2);</para>  
        /// <para>2、十进制转八进制：    Convert.ToString(69, 8);</para> 
        /// <para>3、十进制转十六进制：  Convert.ToString(69, 16);</para> 
        /// <para>4、二进制转十进制：    Convert.ToInt32("100111101″, 2);</para>
        /// <para>5、八进制转十进制：    Convert.ToInt32("76″, 8);</para>
        /// <para>6、十六进制转十进制：  Convert.ToInt32("FF", 16);</para>
        /// </summary>
        /// <returns></returns>
        public static void DataConversion() { }

        /// <summary>人民币小写转大写</summary>
        /// <param name="num">人民币数字</param>
        /// <returns>返回人民币的大写</returns>
        public static string GetNumCHN(decimal num)
        {
            string str1 = "零壹贰叁肆伍陆柒捌玖";            //0-9所对应的汉字
            string str2 = "万仟佰拾亿仟佰拾万仟佰拾元角分"; //数字位所对应的汉字
            string str3 = "";    //从原num值中取出的值
            string str4 = "";    //数字的字符串形式
            string str5 = "";  //人民币大写金额形式
            int i;    //循环变量
            int j;    //num的值乘以100的字符串长度
            string ch1 = "";    //数字的汉语读法
            string ch2 = "";    //数字位的汉字读法
            int nzero = 0;  //用来计算连续的零值是几个
            int temp;            //从原num值中取出的值

            num = Math.Round(Math.Abs(num), 2);    //将num取绝对值并四舍五入取2位小数
            str4 = ((long)(num * 100)).ToString();        //将num乘100并转换成字符串形式
            j = str4.Length;      //找出最高位
            if (j > 15) { return "溢出"; }
            str2 = str2.Substring(15 - j);   //取出对应位数的str2的值。如：200.55,j为5所以str2=佰拾元角分

            //循环取出每一位需要转换的值
            for (i = 0; i < j; i++)
            {
                str3 = str4.Substring(i, 1);          //取出需转换的某一位的值
                temp = Convert.ToInt32(str3);      //转换为数字
                if (i != (j - 3) && i != (j - 7) && i != (j - 11) && i != (j - 15))
                {
                    //当所取位数不为元、万、亿、万亿上的数字时
                    if (str3 == "0")
                    {
                        ch1 = "";
                        ch2 = "";
                        nzero = nzero + 1;
                    }
                    else
                    {
                        if (str3 != "0" && nzero != 0)
                        {
                            ch1 = "零" + str1.Substring(temp * 1, 1);
                            ch2 = str2.Substring(i, 1);
                            nzero = 0;
                        }
                        else
                        {
                            ch1 = str1.Substring(temp * 1, 1);
                            ch2 = str2.Substring(i, 1);
                            nzero = 0;
                        }
                    }
                }
                else
                {
                    //该位是万亿，亿，万，元位等关键位
                    if (str3 != "0" && nzero != 0)
                    {
                        ch1 = "零" + str1.Substring(temp * 1, 1);
                        ch2 = str2.Substring(i, 1);
                        nzero = 0;
                    }
                    else
                    {
                        if (str3 != "0" && nzero == 0)
                        {
                            ch1 = str1.Substring(temp * 1, 1);
                            ch2 = str2.Substring(i, 1);
                            nzero = 0;
                        }
                        else
                        {
                            if (str3 == "0" && nzero >= 3)
                            {
                                ch1 = "";
                                ch2 = "";
                                nzero = nzero + 1;
                            }
                            else
                            {
                                if (j >= 11)
                                {
                                    ch1 = "";
                                    nzero = nzero + 1;
                                }
                                else
                                {
                                    ch1 = "";
                                    ch2 = str2.Substring(i, 1);
                                    nzero = nzero + 1;
                                }
                            }
                        }
                    }
                }
                if (i == (j - 11) || i == (j - 3))
                {
                    //如果该位是亿位或元位，则必须写上
                    ch2 = str2.Substring(i, 1);
                }
                str5 = str5 + ch1 + ch2;

                if (i == j - 1 && str3 == "0")
                {
                    //最后一位（分）为0时，加上“整”
                    str5 = str5 + '整';
                }
            }
            if (num == 0)
            {
                str5 = "零元整";
            }
            return str5;
        }

        /// <summary>将bool转换为byte,true返回1，false返回0</summary>
        /// <param name="Input">要转换的bool值</param>
        /// <returns>返回已被转换为byte值</returns>
        public static byte BoolToByte(bool Input)
        {
            if (Input == true)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>64位整数转换为ip地址</summary>
        /// <param name="Input">要转换的整数</param>
        /// <returns>返回已被转换的ip字符串</returns>
        public static string DecToIp(long Input)
        {
            if (Input >= 4294967295)
            {
                return "255.255.255.255";
            }
            if (Input <= 0)
            {
                return "0.0.0.0";
            }
            System.Text.StringBuilder ipStr = new System.Text.StringBuilder();
            string hexstr = Convert.ToString(Input, 16);
            string lonstr = new string('0', 8 - hexstr.Length);
            lonstr += hexstr;
            for (int i = 0; i < 8; i++)
            {
                if (ipStr.Length > 0)
                {
                    ipStr.Append(".");
                }
                ipStr.Append(Convert.ToInt32(lonstr.Substring(i, 2), 16));
                i++;
            }
            return ipStr.ToString();
        }

        /// <summary>ip地址转换为64位整数</summary>
        /// <param name="Input">要转换的ip地址</param>
        /// <returns>返回已被转换的64位整数</returns>
        public static long IpToDec(string Input)
        {
            if (Input.Trim() != "")
            {
                long srIp = 0;
                string[] aIp = Input.Split('.');
                if (aIp.Length == 4)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        srIp += Convert.ToInt64(aIp[i]) * (long)(Math.Pow(256, (3 - i)));
                    }
                }
                return srIp;
            }
            return 0;
        }

        /// <summary>计算机存储容量单位转换。例如 ： 10000转换结果为9.77KB</summary>
        /// <param name="numStr">需要转换的基数字类型字符串(单位：字节)</param>
        /// <returns>返回已转换后的字符串</returns>
        public static string GetPcSize(string numStr)
        {
            double dou = Convert.ToDouble(numStr);
            if (dou < 1024)
            {
                return Convert.ToInt64(numStr).ToString() + "B";
            }
            else if (dou >= 1024 && dou < 1048576)
            {
                return Math.Round(dou / 1024, 2).ToString() + "KB";
            }
            else if (dou >= 1048576 && dou < 1073741824)
            {
                return Math.Round(dou / 1048576, 2).ToString() + "MB";
            }
            else if (dou >= 1073741824 && dou < 1099511627776)
            {
                return Math.Round(dou / 1073741824, 2).ToString() + "GB";
            }
            else
            {
                return Math.Round(dou / 1099511627776, 2).ToString() + "TB";
            }
        }

        /// <summary>根据指定数字字符串返回每千位使用小写逗号分隔的字符串</summary>
        /// <param name="num">数字字符串</param>
        /// <returns>根据指定数字字符串返回每千位使用小写逗号分隔的字符串</returns>
        public static string GetNumFN(string num)
        {
            string newstr = string.Empty;
            Regex r = new Regex(@"(\d+?)(\d{3})*(\.\d+|$)");
            Match m = r.Match(num);
            newstr += m.Groups[1].Value;
            for (int i = 0; i < m.Groups[2].Captures.Count; i++)
            {
                newstr += "," + m.Groups[2].Captures[i].Value;
            }
            newstr += m.Groups[3].Value;
            return newstr;
        }

        #endregion
    }
}

