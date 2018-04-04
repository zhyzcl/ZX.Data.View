using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace App
{
    /// <summary>日期时间常用静态操作类</summary>
    [Serializable]
    public static class DateOften
    {
        /// <summary>返回当前日期是星期几(返回中文日期：星期一、星期二、星期三、星期四、星期五、星期六、星期日)</summary> 
        /// <returns>返回当前日期是星期几</returns>
        public static string DayToWeek()
        {
            return DayToWeek(DateTime.Now);
        }

        /// <summary>根据字符串格式的日期返回该日期是星期几(返回中文日期：星期一、星期二、星期三、星期四、星期五、星期六、星期日)</summary> 
        /// <param name="de">一个字符串格式的日期</param>
        /// <returns>返回日期是星期几</returns>
        public static string DayToWeek(string de)
        {
            if (Often.IsDate(de))
            {
                return DayToWeek(Convert.ToDateTime(de));
            }
            return "";
        }

        /// <summary>根据日期返回该日期是星期几(返回中文日期：星期一、星期二、星期三、星期四、星期五、星期六、星期日)</summary> 
        /// <param name="de">一个日期</param>
        /// <returns>返回日期是星期几</returns>
        public static string DayToWeek(DateTime de)
        {
            if (de.DayOfWeek == DayOfWeek.Monday)
            {
                return "星期一";
            }
            if (de.DayOfWeek == DayOfWeek.Tuesday)
            {
                return "星期二";
            }
            if (de.DayOfWeek == DayOfWeek.Wednesday)
            {
                return "星期三";
            }
            if (de.DayOfWeek == DayOfWeek.Thursday)
            {
                return "星期四";
            }
            if (de.DayOfWeek == DayOfWeek.Friday)
            {
                return "星期五";
            }
            if (de.DayOfWeek == DayOfWeek.Saturday)
            {
                return "星期六";
            }
            return "星期日";
        }

        /// <summary>根据日期和参数列出的星期返回该日期是星期几(第二个参数值可以是：1234567，例如：524。返回中文日期：星期一、星期二、星期三、星期四、星期五、星期六、星期日)</summary> 
        /// <param name="de">一个日期</param>
        /// <param name="sd">只返回该参数列出的星期，参数值可以是：1234567，例如：524</param>
        /// <returns>返回日期是星期几</returns>
        public static string DayToWeek(DateTime de, string sd)
        {
            if (de.DayOfWeek == DayOfWeek.Monday)
            {
                if (sd.IndexOf("1") > -1)
                {
                    return "星期一";
                }
                else
                {
                    return "";
                }
            }
            if (de.DayOfWeek == DayOfWeek.Tuesday)
            {
                if (sd.IndexOf("2") > -1)
                {
                    return "星期二";
                }
                else
                {
                    return "";
                }
            }
            if (de.DayOfWeek == DayOfWeek.Wednesday)
            {
                if (sd.IndexOf("3") > -1)
                {
                    return "星期三";
                }
                else
                {
                    return "";
                }
            }
            if (de.DayOfWeek == DayOfWeek.Thursday)
            {
                if (sd.IndexOf("4") > -1)
                {
                    return "星期四";
                }
                else
                {
                    return "";
                }
            }
            if (de.DayOfWeek == DayOfWeek.Friday)
            {
                if (sd.IndexOf("5") > -1)
                {
                    return "星期五";
                }
                else
                {
                    return "";
                }
            }
            if (de.DayOfWeek == DayOfWeek.Saturday)
            {
                if (sd.IndexOf("6") > -1)
                {
                    return "星期六";
                }
                else
                {
                    return "";
                }
            }
            if (sd.IndexOf("7") > -1)
            {
                return "星期日";
            }
            else
            {
                return "";
            }
        }

        /// <summary>返回当前日期是星期几(返回数字：1、2、3、4、5、6、7)</summary> 
        /// <returns>返回当前日期是星期几</returns>
        public static byte DayToNumWeek()
        {
            return DayToNumWeek(DateTime.Now);
        }

        /// <summary>根据字符串格式的日期返回该日期是星期几(返回数字：1、2、3、4、5、6、7)</summary> 
        /// <param name="de">一个字符串格式的日期</param>
        /// <returns>返回日期是星期几</returns>
        public static byte DayToNumWeek(string de)
        {
            return DayToNumWeek(Convert.ToDateTime(de));
        }

        /// <summary>根据日期返回该日期是星期几(返回数字：1、2、3、4、5、6、7)</summary> 
        /// <param name="de">一个日期</param>
        /// <returns>返回日期是星期几</returns>
        public static byte DayToNumWeek(DateTime de)
        {
            if (de.DayOfWeek == DayOfWeek.Monday)
            {
                return 1;
            }
            if (de.DayOfWeek == DayOfWeek.Tuesday)
            {
                return 2;
            }
            if (de.DayOfWeek == DayOfWeek.Wednesday)
            {
                return 3;
            }
            if (de.DayOfWeek == DayOfWeek.Thursday)
            {
                return 4;
            }
            if (de.DayOfWeek == DayOfWeek.Friday)
            {
                return 5;
            }
            if (de.DayOfWeek == DayOfWeek.Saturday)
            {
                return 6;
            }
            return 7;
        }

        /// <summary>根据日期和参数列出的星期返回该日期是星期几(第二个参数值可以是：1234567，例如：524。返回数字：1、2、3、4、5、6、7)</summary> 
        /// <param name="de">一个日期</param>
        /// <param name="sd">只返回该参数列出的星期，参数值可以是：1234567，例如：524</param>
        /// <returns>返回日期是星期几</returns>
        public static byte DayToNumWeek(DateTime de, string sd)
        {
            if (de.DayOfWeek == DayOfWeek.Monday)
            {
                if (sd.IndexOf("1") > -1)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            if (de.DayOfWeek == DayOfWeek.Tuesday)
            {
                if (sd.IndexOf("2") > -1)
                {
                    return 2;
                }
                else
                {
                    return 0;
                }
            }
            if (de.DayOfWeek == DayOfWeek.Wednesday)
            {
                if (sd.IndexOf("3") > -1)
                {
                    return 3;
                }
                else
                {
                    return 0;
                }
            }
            if (de.DayOfWeek == DayOfWeek.Thursday)
            {
                if (sd.IndexOf("4") > -1)
                {
                    return 4;
                }
                else
                {
                    return 0;
                }
            }
            if (de.DayOfWeek == DayOfWeek.Friday)
            {
                if (sd.IndexOf("5") > -1)
                {
                    return 5;
                }
                else
                {
                    return 0;
                }
            }
            if (de.DayOfWeek == DayOfWeek.Saturday)
            {
                if (sd.IndexOf("6") > -1)
                {
                    return 6;
                }
                else
                {
                    return 0;
                }
            }
            if (sd.IndexOf("7") > -1)
            {
                return 7;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>中文日期转换成标准日期格式。例如 2008年10月1日 6时33分50秒 格式的日期转换成 2008-10-1 6:33:50</summary> 
        /// <param name="strIn">要转换的字符串</param>
        /// <param name="mode">
        /// 转换模式
        /// <para>0、对应 2008年10月1日 格式</para>
        /// <para>1、对应 2008年10月1日 6时33分 格式</para>
        /// <para>2、对应 2008年10月1日 6时33分50秒 格式</para>
        /// <para>3、对应 2008-10-1 格式</para>
        /// </param>
        /// <returns>返回已转换好的字符串</returns>
        public static string ChToDTime(string strIn, byte mode)
        {
            switch (mode)
            {
                case 0:
                    strIn = strIn.Replace("年", "-");
                    strIn = strIn.Replace("月", "-");
                    strIn = strIn.Replace("日", "");
                    break;
                case 1:
                    strIn = strIn.Replace("年", "-");
                    strIn = strIn.Replace("月", "-");
                    strIn = strIn.Replace("日", "");
                    strIn = strIn.Replace("时", ":");
                    strIn = strIn.Replace("分", ":00");
                    break;
                case 2:
                    strIn = strIn.Replace("年", "-");
                    strIn = strIn.Replace("月", "-");
                    strIn = strIn.Replace("日", "");
                    strIn = strIn.Replace("时", ":");
                    strIn = strIn.Replace("分", ":");
                    strIn = strIn.Replace("秒", "");
                    break;
                case 3:
                    StringBuilder strB = new StringBuilder(strIn);
                    strIn = strB.Replace("-", "年", strIn.IndexOf("-"), 1).ToString();
                    strB = new StringBuilder(strIn);
                    strIn = strB.Replace("-", "月", strIn.IndexOf("-"), 1).ToString();
                    strIn += "日";
                    break;
            }
            return strIn;
        }

        /// <summary>返回指定格式(yyyy-MM-dd HH:mm:ss)的当前系统日期字符串表示</summary>
        /// <returns>返回已格式的日期字符串表示</returns>
        public static string GetDate()
        {
            return GetDate(DateTime.Now, "yyyy-MM-dd HH:mm:ss");
        }

        /// <summary>返回指定格式(yyyy-MM-dd HH:mm:ss)的日期字符串表示</summary>
        /// <param name="dt">需要格式化的日期</param>
        /// <returns>返回已格式的日期字符串表示</returns>
        public static string GetDate(DateTime dt)
        {
            return GetDate(dt, "yyyy-MM-dd HH:mm:ss");
        }

        /// <summary>返回指定格式(yyyy-MM-dd HH:mm:ss)的日期字符串表示</summary>
        /// <param name="dt">需要格式化的日期</param>
        /// <returns>返回已格式的日期字符串表示</returns>
        public static string GetDates(string dt)
        {
            return GetDate(dt, "yyyy-MM-dd HH:mm:ss");
        }

        /// <summary>返回指定格式的当前系统日期字符串表示
        /// <para>常用格式字符：</para> 
        /// <para>gg 时期或纪元。如果要设置格式的日期不具有关联的时期或纪元字符串，则忽略该模式。</para>  
        /// <para>y、%y 不包含纪元的年份。如果不包含纪元的年份小于 10，则显示不具有前导零的年份。如果该格式模式没有与其他格式模式组合，则指定“%y”。</para>  
        /// <para>yy 不包含纪元的年份。如果不包含纪元的年份小于 10，则显示具有前导零的年份。</para>
        /// <para>yyyy 包括纪元的四位数的年份。</para>
        /// <para>d、%d 月中的某一天。一位数的日期没有前导零。如果该格式模式没有与其他格式模式组合，则指定“%d”。</para>  
        /// <para>dd 月中的某一天。一位数的日期有一个前导零。</para>  
        /// <para>ddd 周中某天的缩写名称。</para>  
        /// <para>dddd 周中某天的完整名称</para>  
        /// <para>M、%M 月份数字。一位数的月份没有前导零。如果该格式模式没有与其他格式模式组合，则指定“%M”。</para>  
        /// <para>MM 月份数字。一位数的月份有一个前导零。</para>  
        /// <para>MMM 月份的缩写名称。</para>  
        /// <para>MMMM 月份的完整名称。</para>  
        /// <para>h、%h 12 小时制的小时。一位数的小时数没有前导零。如果该格式模式没有与其他格式模式组合，则指定“%h”。</para>
        /// <para>hh 12 小时制的小时。一位数的小时数有前导零。 </para>
        /// <para>H、%H 24 小时制的小时。一位数的小时数没有前导零。如果该格式模式没有与其他格式模式组合，则指定“%H”。</para>
        /// <para>HH 24 小时制的小时。一位数的小时数有前导零。</para>
        /// <para>m、%m 分钟。一位数的分钟数没有前导零。如果该格式模式没有与其他格式模式组合，则指定“%m”。</para>
        /// <para>mm 分钟。一位数的分钟数有一个前导零。</para>
        /// <para>s、%s 秒。一位数的秒数没有前导零。如果该格式模式没有与其他格式模式组合，则指定“%s”。</para>
        /// <para>ss 秒。一位数的秒数有一个前导零。</para>
        /// <para>f、%f 秒的小数精度为一位。其余数字被截断。如果该格式模式没有与其他格式模式组合，则指定“%f”。</para>
        /// <para>ff 秒的小数精度为两位。其余数字被截断。</para>
        /// <para>fff 秒的小数精度为三位。其余数字被截断。</para>
        /// <para>F、%F 示秒的小数部分的最高有效数字。如果该数字为零，则不显示任何内容。如果该格式模式没有与其他格式模式组合，则指定“%F”。</para>
        /// <para>FF 显示秒的小数部分的两个最高有效数字。但是，不显示尾随的零（两个零数字）。</para>
        /// <para>FFF 显示秒的小数部分的三个最高有效数字。但是，不显示尾随的零（三个零数字）。</para>  
        /// </summary>
        /// <param name="format">格式字符串</param>
        /// <returns>返回已格式的日期字符串表示</returns>
        public static string GetDate(string format)
        {
            return GetDate(DateTime.Now, format);
        }

        /// <summary>返回指定格式的日期字符串表示
        /// <para>常用格式字符：</para> 
        /// <para>gg 时期或纪元。如果要设置格式的日期不具有关联的时期或纪元字符串，则忽略该模式。</para>  
        /// <para>y、%y 不包含纪元的年份。如果不包含纪元的年份小于 10，则显示不具有前导零的年份。如果该格式模式没有与其他格式模式组合，则指定“%y”。</para>  
        /// <para>yy 不包含纪元的年份。如果不包含纪元的年份小于 10，则显示具有前导零的年份。</para>
        /// <para>yyyy 包括纪元的四位数的年份。</para>
        /// <para>d、%d 月中的某一天。一位数的日期没有前导零。如果该格式模式没有与其他格式模式组合，则指定“%d”。</para>  
        /// <para>dd 月中的某一天。一位数的日期有一个前导零。</para>  
        /// <para>ddd 周中某天的缩写名称。</para>  
        /// <para>dddd 周中某天的完整名称</para>  
        /// <para>M、%M 月份数字。一位数的月份没有前导零。如果该格式模式没有与其他格式模式组合，则指定“%M”。</para>  
        /// <para>MM 月份数字。一位数的月份有一个前导零。</para>  
        /// <para>MMM 月份的缩写名称。</para>  
        /// <para>MMMM 月份的完整名称。</para>  
        /// <para>h、%h 12 小时制的小时。一位数的小时数没有前导零。如果该格式模式没有与其他格式模式组合，则指定“%h”。</para>
        /// <para>hh 12 小时制的小时。一位数的小时数有前导零。 </para>
        /// <para>H、%H 24 小时制的小时。一位数的小时数没有前导零。如果该格式模式没有与其他格式模式组合，则指定“%H”。</para>
        /// <para>HH 24 小时制的小时。一位数的小时数有前导零。</para>
        /// <para>m、%m 分钟。一位数的分钟数没有前导零。如果该格式模式没有与其他格式模式组合，则指定“%m”。</para>
        /// <para>mm 分钟。一位数的分钟数有一个前导零。</para>
        /// <para>s、%s 秒。一位数的秒数没有前导零。如果该格式模式没有与其他格式模式组合，则指定“%s”。</para>
        /// <para>ss 秒。一位数的秒数有一个前导零。</para>
        /// <para>f、%f 秒的小数精度为一位。其余数字被截断。如果该格式模式没有与其他格式模式组合，则指定“%f”。</para>
        /// <para>ff 秒的小数精度为两位。其余数字被截断。</para>
        /// <para>fff 秒的小数精度为三位。其余数字被截断。</para>
        /// <para>F、%F 示秒的小数部分的最高有效数字。如果该数字为零，则不显示任何内容。如果该格式模式没有与其他格式模式组合，则指定“%F”。</para>
        /// <para>FF 显示秒的小数部分的两个最高有效数字。但是，不显示尾随的零（两个零数字）。</para>
        /// <para>FFF 显示秒的小数部分的三个最高有效数字。但是，不显示尾随的零（三个零数字）。</para>  
        /// </summary>
        /// <param name="dt">需要格式化的日期</param>
        /// <param name="format">格式字符串</param>
        /// <returns>返回已格式的日期字符串表示</returns>
        public static string GetDate(DateTime dt, string format)
        {
            return dt.ToString(format);
        }

        /// <summary>返回指定格式的日期字符串表示
        /// <para>常用格式字符：</para> 
        /// <para>gg 时期或纪元。如果要设置格式的日期不具有关联的时期或纪元字符串，则忽略该模式。</para>  
        /// <para>y、%y 不包含纪元的年份。如果不包含纪元的年份小于 10，则显示不具有前导零的年份。如果该格式模式没有与其他格式模式组合，则指定“%y”。</para>  
        /// <para>yy 不包含纪元的年份。如果不包含纪元的年份小于 10，则显示具有前导零的年份。</para>
        /// <para>yyyy 包括纪元的四位数的年份。</para>
        /// <para>d、%d 月中的某一天。一位数的日期没有前导零。如果该格式模式没有与其他格式模式组合，则指定“%d”。</para>  
        /// <para>dd 月中的某一天。一位数的日期有一个前导零。</para>  
        /// <para>ddd 周中某天的缩写名称。</para>  
        /// <para>dddd 周中某天的完整名称</para>  
        /// <para>M、%M 月份数字。一位数的月份没有前导零。如果该格式模式没有与其他格式模式组合，则指定“%M”。</para>  
        /// <para>MM 月份数字。一位数的月份有一个前导零。</para>  
        /// <para>MMM 月份的缩写名称。</para>  
        /// <para>MMMM 月份的完整名称。</para>  
        /// <para>h、%h 12 小时制的小时。一位数的小时数没有前导零。如果该格式模式没有与其他格式模式组合，则指定“%h”。</para>
        /// <para>hh 12 小时制的小时。一位数的小时数有前导零。 </para>
        /// <para>H、%H 24 小时制的小时。一位数的小时数没有前导零。如果该格式模式没有与其他格式模式组合，则指定“%H”。</para>
        /// <para>HH 24 小时制的小时。一位数的小时数有前导零。</para>
        /// <para>m、%m 分钟。一位数的分钟数没有前导零。如果该格式模式没有与其他格式模式组合，则指定“%m”。</para>
        /// <para>mm 分钟。一位数的分钟数有一个前导零。</para>
        /// <para>s、%s 秒。一位数的秒数没有前导零。如果该格式模式没有与其他格式模式组合，则指定“%s”。</para>
        /// <para>ss 秒。一位数的秒数有一个前导零。</para>
        /// <para>f、%f 秒的小数精度为一位。其余数字被截断。如果该格式模式没有与其他格式模式组合，则指定“%f”。</para>
        /// <para>ff 秒的小数精度为两位。其余数字被截断。</para>
        /// <para>fff 秒的小数精度为三位。其余数字被截断。</para>
        /// <para>F、%F 示秒的小数部分的最高有效数字。如果该数字为零，则不显示任何内容。如果该格式模式没有与其他格式模式组合，则指定“%F”。</para>
        /// <para>FF 显示秒的小数部分的两个最高有效数字。但是，不显示尾随的零（两个零数字）。</para>
        /// <para>FFF 显示秒的小数部分的三个最高有效数字。但是，不显示尾随的零（三个零数字）。</para>  
        /// </summary>
        /// <param name="dts">需要格式化的日期字符串</param>
        /// <param name="format">格式字符串</param>
        /// <returns>返回已格式的日期字符串表示</returns>
        public static string GetDate(string dts, string format)
        {
            return Convert.ToDateTime(dts).ToString(format);
        }

        /// <summary>使用替换关键字对当前时间重组并将时间格式化为等长字符串(例如：2008-1-1 格式化后：2008-01-01)。
        /// <para>格式化为等长字符串的替换关键字：</para> 
        /// <para>{$Year} 年</para>  
        /// <para>{$Month} 月</para>  
        /// <para>{$Day} 日</para>  
        /// <para>{$Hour} 时</para>  
        /// <para>{$Minute} 分</para>  
        /// <para>{$Second} 秒</para>  
        /// <para>{$Millisecond} 毫秒</para>  
        /// <para>{$Random} 10000000至100000000之间随即数</para> 
        /// <para>{$Addup} 1至99999999之间累计数</para> 
        /// <para>{$Addlongup} 1至999999999999999999之间累计数</para> 
        /// <para>直接替换关键字：</para> 
        /// <para>{$year} 年</para>  
        /// <para>{$month} 月</para>  
        /// <para>{$day} 日</para>  
        /// <para>{$hour} 时</para>  
        /// <para>{$minute} 分</para>  
        /// <para>{$second} 秒</para>  
        /// <para>{$millisecond} 毫秒</para>  
        /// <para>{$random} 10000000至100000000之间随即数</para> 
        /// <para>{$addup} 1至99999999之间累计数</para> 
        /// <para>{$addlongup} 1至999999999999999999之间累计数</para> 
        /// </summary>
        /// <param name="strInput">重组替换字符串</param>
        /// <returns>返回已重组的字符串</returns>
        public static string ReFDateTime(string strInput)
        {
            return ReFDateTime(strInput, DateTime.Now);
        }

        /// <summary>使用替换关键字对当前时间重组并将时间格式化为等长字符串(例如：2008-1-1 格式化后：2008-01-01)。
        /// <para>格式化为等长字符串的替换关键字：</para> 
        /// <para>{$Year} 年</para>  
        /// <para>{$Month} 月</para>  
        /// <para>{$Day} 日</para>  
        /// <para>{$Hour} 时</para>  
        /// <para>{$Minute} 分</para>  
        /// <para>{$Second} 秒</para>  
        /// <para>{$Millisecond} 毫秒</para>  
        /// <para>{$Random} 10000000至100000000之间随即数</para> 
        /// <para>{$Addup} 1至99999999之间累计数</para> 
        /// <para>{$Addlongup} 1至999999999999999999之间累计数</para> 
        /// <para>直接替换关键字：</para> 
        /// <para>{$year} 年</para>  
        /// <para>{$month} 月</para>  
        /// <para>{$day} 日</para>  
        /// <para>{$hour} 时</para>  
        /// <para>{$minute} 分</para>  
        /// <para>{$second} 秒</para>  
        /// <para>{$millisecond} 毫秒</para>  
        /// <para>{$random} 10000000至100000000之间随即数</para> 
        /// <para>{$addup} 1至99999999之间累计数</para> 
        /// <para>{$addlongup} 1至999999999999999999之间累计数</para> 
        /// </summary>
        /// <param name="strInput">重组替换字符串</param>
        /// <param name="sdate">一个字符串时间</param>
        /// <returns>返回已重组的字符串</returns>
        public static string ReFDateTime(string strInput, string sdate)
        {
            if (Often.IsDate(sdate))
            {
                return ReFDateTime(strInput, Convert.ToDateTime(sdate));
            }
            return "";
        }

        /// <summary>使用替换关键字对时间重组并将时间格式化为等长字符串(例如：2008-1-1 格式化后：2008-01-01)。
        /// <para>格式化为等长字符串的替换关键字：</para> 
        /// <para>{$Year} 年</para>  
        /// <para>{$Month} 月</para>  
        /// <para>{$Day} 日</para>  
        /// <para>{$Hour} 时</para>  
        /// <para>{$Minute} 分</para>  
        /// <para>{$Second} 秒</para>  
        /// <para>{$Millisecond} 毫秒</para>  
        /// <para>{$Random} 10000000至100000000之间随即数</para> 
        /// <para>{$Addup} 1至99999999之间累计数</para> 
        /// <para>{$Addlongup} 1至999999999999999999之间累计数</para> 
        /// <para>直接替换关键字：</para> 
        /// <para>{$year} 年</para>  
        /// <para>{$month} 月</para>  
        /// <para>{$day} 日</para>  
        /// <para>{$hour} 时</para>  
        /// <para>{$minute} 分</para>  
        /// <para>{$second} 秒</para>  
        /// <para>{$millisecond} 毫秒</para>  
        /// <para>{$random} 10000000至100000000之间随即数</para> 
        /// <para>{$addup} 1至99999999之间累计数</para> 
        /// <para>{$addlongup} 1至999999999999999999之间累计数</para> 
        /// </summary>
        /// <param name="strInput">重组替换字符串</param>
        /// <param name="date">时间</param>
        /// <returns>返回已重组的字符串</returns>
        public static string ReFDateTime(string strInput, DateTime date)
        {
            strInput = strInput.Replace("{$Year}", date.Year.ToString());
            strInput = strInput.Replace("{$Month}", Often.LCharDup(date.Month.ToString(), '0', 2));
            strInput = strInput.Replace("{$Day}", Often.LCharDup(date.Day.ToString(), '0', 2));
            strInput = strInput.Replace("{$Hour}", Often.LCharDup(date.Hour.ToString(), '0', 2));
            strInput = strInput.Replace("{$Minute}", Often.LCharDup(date.Minute.ToString(), '0', 2));
            strInput = strInput.Replace("{$Second}", Often.LCharDup(date.Second.ToString(), '0', 2));
            strInput = strInput.Replace("{$Millisecond}", Often.LCharDup(date.Millisecond.ToString(), '0', 3));
            strInput = strInput.Replace("{$year}", date.Year.ToString());
            strInput = strInput.Replace("{$month}", date.Month.ToString());
            strInput = strInput.Replace("{$day}", date.Day.ToString());
            strInput = strInput.Replace("{$hour}", date.Hour.ToString());
            strInput = strInput.Replace("{$minute}", date.Minute.ToString());
            strInput = strInput.Replace("{$second}", date.Second.ToString());
            strInput = strInput.Replace("{$millisecond}", date.Millisecond.ToString());
            Random random = new Random(Often.Seed);
            strInput = strInput.Replace("{$Random}", random.Next(10000000, 100000000).ToString());
            strInput = strInput.Replace("{$random}", random.Next(10000000, 100000000).ToString());
            if (strInput.IndexOf("{$Addup}") > -1)
            {
                strInput = strInput.Replace("{$Addup}", Often.LCharDup(Often.AddupNum.ToString(), '0', 8));
            }
            if (strInput.IndexOf("{$addup}") > -1)
            {
                strInput = strInput.Replace("{$addup}", Often.AddupNum.ToString());
            }
            if (strInput.IndexOf("{$Addlongup}") > -1)
            {
                strInput = strInput.Replace("{$Addlongup}", Often.LCharDup(Often.AddupLongNum.ToString(), '0', 18));
            }
            if (strInput.IndexOf("{$addlongup}") > -1)
            {
                strInput = strInput.Replace("{$addlongup}", Often.AddupLongNum.ToString());
            }
            return strInput;
        }

        /// <summary>使用替换关键字对时间重组。
        /// <para>替换关键字：</para>
        /// <para>{$Year} 年</para>
        /// <para>{$Month} 月</para>
        /// <para>{$Day} 日</para>
        /// <para>{$Hour} 时</para>  
        /// <para>{$Minute} 分</para> 
        /// <para>{$Second} 秒</para>  
        /// <para>{$Millisecond} 毫秒</para>  
        /// <para>{$Random} 10000000至100000000之间随即数</para>
        /// <para>{$Addup} 1至99999999之间累计数</para> 
        /// <para>{$Addlongup} 1至999999999999999999之间累计数</para> 
        /// </summary>
        /// <param name="strInput">重组替换字符串</param>
        /// <returns>返回已重组的字符串</returns>
        public static string ReDateTime(string strInput)
        {
            return ReDateTime(strInput, DateTime.Now);
        }

        /// <summary>使用替换关键字对时间重组。
        /// <para>替换关键字：</para>
        /// <para>{$Year} 年</para>
        /// <para>{$Month} 月</para>
        /// <para>{$Day} 日</para>
        /// <para>{$Hour} 时</para>  
        /// <para>{$Minute} 分</para> 
        /// <para>{$Second} 秒</para>  
        /// <para>{$Millisecond} 毫秒</para>  
        /// <para>{$Random} 10000000至100000000之间随即数</para>
        /// <para>{$Addup} 1至99999999之间累计数</para> 
        /// <para>{$Addlongup} 1至999999999999999999之间累计数</para> 
        /// </summary>
        /// <param name="strInput">重组替换字符串</param>
        /// <param name="sdate">一个字符串时间</param>
        /// <returns>返回已重组的字符串</returns>
        public static string ReDateTime(string strInput, string sdate)
        {
            if (Often.IsDate(sdate))
            {
                return ReDateTime(strInput, Convert.ToDateTime(sdate));
            }
            return "";
        }

        /// <summary>使用替换关键字对时间重组。
        /// <para>替换关键字：</para>
        /// <para>{$Year} 年</para>
        /// <para>{$Month} 月</para>
        /// <para>{$Day} 日</para>
        /// <para>{$Hour} 时</para>  
        /// <para>{$Minute} 分</para> 
        /// <para>{$Second} 秒</para>  
        /// <para>{$Millisecond} 毫秒</para>  
        /// <para>{$Random} 10000000至100000000之间随即数</para>
        /// <para>{$Addup} 1至99999999之间累计数</para> 
        /// <para>{$Addlongup} 1至999999999999999999之间累计数</para> 
        /// </summary>
        /// <param name="strInput">重组替换字符串</param>
        /// <param name="date">时间</param>
        /// <returns>返回已重组的字符串</returns>
        public static string ReDateTime(string strInput, DateTime date)
        {
            strInput = strInput.Replace("{$Year}", date.Year.ToString());
            strInput = strInput.Replace("{$Month}", date.Month.ToString());
            strInput = strInput.Replace("{$Day}", date.Day.ToString());
            strInput = strInput.Replace("{$Hour}", date.Hour.ToString());
            strInput = strInput.Replace("{$Minute}", date.Minute.ToString());
            strInput = strInput.Replace("{$Second}", date.Second.ToString());
            strInput = strInput.Replace("{$Millisecond}", date.Millisecond.ToString());
            Random random = new Random(Often.Seed);
            strInput = strInput.Replace("{$Random}", random.Next(10000000, 100000000).ToString());
            if (strInput.IndexOf("{$Addup}") > -1)
            {
                strInput = strInput.Replace("{$Addup}", Often.AddupNum.ToString());
            }
            if (strInput.IndexOf("{$Addlongup}") > -1)
            {
                strInput = strInput.Replace("{$Addlongup}", Often.AddupLongNum.ToString());
            }
            return strInput;
        }

        /// <summary>返回开始与结束时间之间的间隔分钟数</summary>
        /// <param name="startDate">开始时间</param>
        /// <param name="endDate">结束时间</param>
        /// <returns>返回开始与结束时间之间的间隔分钟数</returns>
        public static int GetTimeMinutes(string startDate, string endDate)
        {
            if (Often.IsDate(startDate) && Often.IsDate(endDate))
            {
                return GetTimeMinutes(Convert.ToDateTime(startDate), Convert.ToDateTime(endDate));
            }
            return 0;
        }

        /// <summary>返回开始与结束时间之间的间隔分钟数</summary>
        /// <param name="startDate">开始时间</param>
        /// <param name="endDate">结束时间</param>
        /// <returns>返回开始与结束时间之间的间隔分钟数</returns>
        public static int GetTimeMinutes(DateTime startDate, DateTime endDate)
        {
            TimeSpan ts1 = new TimeSpan(endDate.Ticks);
            TimeSpan ts2 = new TimeSpan(startDate.Ticks);
            TimeSpan ts = ts1.Subtract(ts2).Duration();
            double dateDiff = ts.TotalMinutes;
            return Convert.ToInt32(dateDiff);
        }

        /// <summary>返回两个日期之间的时间间隔（y：年份间隔、M：月份间隔、d：天数间隔、h：小时间隔、m：分钟间隔、s：秒钟间隔、ms：微秒间隔）</summary>
        /// <param name="startDate">开始时间</param>
        /// <param name="endDate">结束时间</param>
        /// <param name="Interval">间隔标志（y：年份间隔、M：月份间隔、d：天数间隔、h：小时间隔、m：分钟间隔、s：秒钟间隔、ms：微秒间隔）</param>
        /// <returns>返回两个日期之间的时间间隔（y：年份间隔、M：月份间隔、d：天数间隔、h：小时间隔、m：分钟间隔、s：秒钟间隔、ms：微秒间隔）</returns>
        public static int DateDiff(string startDate, string endDate, string Interval)
        {
            if (Often.IsDate(startDate) && Often.IsDate(endDate))
            {
                return DateDiff(Convert.ToDateTime(startDate), Convert.ToDateTime(endDate), Interval);
            }
            return 0;
        }

        /// <summary>返回两个日期之间的时间间隔（y：年份间隔、M：月份间隔、d：天数间隔、h：小时间隔、m：分钟间隔、s：秒钟间隔、ms：微秒间隔）</summary>
        /// <param name="startDate">开始时间</param>
        /// <param name="endDate">结束时间</param>
        /// <param name="Interval">间隔标志（y：年份间隔、M：月份间隔、d：天数间隔、h：小时间隔、m：分钟间隔、s：秒钟间隔、ms：微秒间隔）</param>
        /// <returns>返回两个日期之间的时间间隔（y：年份间隔、M：月份间隔、d：天数间隔、h：小时间隔、m：分钟间隔、s：秒钟间隔、ms：微秒间隔）</returns>
        public static int DateDiff(System.DateTime startDate, System.DateTime endDate, string Interval)
        {
            double dblYearLen = 365;//年的长度，365天   
            double dblMonthLen = (365 / 12);//每个月平均的天数   
            System.TimeSpan objT;
            objT = endDate.Subtract(startDate);
            switch (Interval)
            {
                case "y"://返回日期的年份间隔   
                    return System.Convert.ToInt32(objT.Days / dblYearLen);
                case "M"://返回日期的月份间隔   
                    return System.Convert.ToInt32(objT.Days / dblMonthLen);
                case "d"://返回日期的天数间隔   
                    return objT.Days;
                case "h"://返回日期的小时间隔   
                    return objT.Hours;
                case "m"://返回日期的分钟间隔   
                    return objT.Minutes;
                case "s"://返回日期的秒钟间隔   
                    return objT.Seconds;
                case "ms"://返回时间的微秒间隔   
                    return objT.Milliseconds;
                default:
                    break;
            }
            return 0;
        }

        /// <summary>根据统计模式返回统计日期</summary>
        /// <param name="cmode">统计模式,0:天;1:周;2:月;3:季;4:半年;5:年;6:自定义;</param>
        /// <param name="addmode">日期模式,0:指定日期;1:指定日期的上一日期(环比期);2:指定日期的下一日期;3:指定日期的同比期;</param>
        /// <param name="sdate">需要计算并返回的开始日期</param>
        /// <param name="edate">需要计算并返回的结束日期</param>
        public static void LoadCountDate(string cmode, string addmode, ref DateTime sdate, ref DateTime edate)
        {
            if (edate < sdate)
            {
                edate = sdate;
            }
            if (cmode == "1")
            {
                edate = sdate;
                if (addmode == "1")
                {
                    sdate = GetWeekUpMonday(sdate);
                    edate = GetWeekUpSunday(edate);
                }
                else if (addmode == "2")
                {
                    sdate = GetWeekNextMonday(sdate);
                    edate = GetWeekNextSunday(edate);
                }
                else if (addmode == "3")
                {
                    sdate = GetWeekMondayOn(sdate);
                    edate = GetWeekSundayOn(edate);
                }
                else
                {
                    sdate = GetWeekMonday(sdate);
                    edate = GetWeekSunday(edate);
                }
            }
            else if (cmode == "2")
            {
                edate = sdate;
                if (addmode == "1")
                {
                    sdate = GetMonthUpStart(sdate);
                    edate = GetMonthUpEnd(edate);
                }
                else if (addmode == "2")
                {
                    sdate = GetMonthNextStart(sdate);
                    edate = GetMonthNextEnd(edate);
                }
                else if (addmode == "3")
                {
                    sdate = GetMonthStartOn(sdate);
                    edate = GetMonthEndOn(edate);
                }
                else
                {
                    sdate = GetMonthStart(sdate);
                    edate = GetMonthEnd(edate);
                }
            }
            else if (cmode == "3")
            {
                edate = sdate;
                if (addmode == "1")
                {
                    sdate = GetSeasonUpStart(sdate);
                    edate = GetSeasonUpEnd(edate);
                }
                else if (addmode == "2")
                {
                    sdate = GetSeasonNextStart(sdate);
                    edate = GetSeasonNextEnd(edate);
                }
                else if (addmode == "3")
                {
                    sdate = GetSeasonStartOn(sdate);
                    edate = GetSeasonEndOn(edate);
                }
                else
                {
                    sdate = GetSeasonStart(sdate);
                    edate = GetSeasonEnd(edate);
                }
            }
            else if (cmode == "4")
            {
                edate = sdate;
                if (addmode == "1")
                {
                    sdate = GetHalfyearUpStart(sdate);
                    edate = GetHalfyearUpEnd(edate);
                }
                else if (addmode == "2")
                {
                    sdate = GetHalfyearNextStart(sdate);
                    edate = GetHalfyearNextEnd(edate);
                }
                else if (addmode == "3")
                {
                    sdate = GetHalfyearStartOn(sdate);
                    edate = GetHalfyearEndOn(edate);
                }
                else
                {
                    sdate = GetHalfyearStart(sdate);
                    edate = GetHalfyearEnd(edate);
                }
            }
            else if (cmode == "5")
            {
                edate = sdate;
                if (addmode == "1")
                {
                    sdate = GetYearUpStart(sdate);
                    edate = GetYearUpEnd(edate);
                }
                else if (addmode == "2")
                {
                    sdate = GetYearNextStart(sdate);
                    edate = GetYearNextEnd(edate);
                }
                else if (addmode == "3")
                {
                    sdate = GetYearStartOn(sdate);
                    edate = GetYearEndOn(edate);
                }
                else
                {
                    sdate = GetYearStart(sdate);
                    edate = GetYearEnd(edate);
                }
            }
            else if (cmode == "6")
            {
                int daynum = Math.Abs(DateOften.DateDiff(sdate, edate, "d")) + 1;
                if (addmode == "1")
                {
                    sdate = sdate.AddDays(-daynum);
                    edate = edate.AddDays(-daynum);
                }
                else if (addmode == "2")
                {
                    sdate = sdate.AddDays(daynum);
                    edate = edate.AddDays(daynum);
                }
                else if (addmode == "3")
                {
                    sdate = sdate.AddYears(-1);
                    edate = edate.AddYears(-1);
                }
            }
            else
            {
                if (addmode == "1")
                {
                    sdate = sdate.AddDays(-1);
                }
                else if (addmode == "2")
                {
                    sdate = sdate.AddDays(1);
                }
                else if (addmode == "3")
                {
                    sdate = sdate.AddYears(-1);
                }
                edate = sdate;
            }
            LoadSEDate(ref sdate, ref edate);
        }

        /// <summary>根据统计模式返回统计日期</summary>
        /// <param name="cmode">统计模式,0:天;1:周;2:月;3:季;4:半年;5:年;6:自定义;</param>
        /// <param name="addmode">日期模式,0:当前日期;1:上一日期(环比期);2:下一日期;3:指定日期的同比期;</param>
        /// <param name="sdate">需要计算并返回的开始日期</param>
        /// <param name="edate">需要计算并返回的结束日期</param>
        public static void LoadCountDate(string cmode, string addmode, ref string sdate, ref string edate)
        {
            DateTime dqrq = DateTime.Now;
            if (!Often.IsDate(sdate))
            {
                sdate = dqrq.ToString();
            }
            if (!Often.IsDate(edate))
            {
                edate = sdate;
            }
            DateTime srq = Convert.ToDateTime(sdate);
            DateTime erq = Convert.ToDateTime(edate);
            LoadCountDate(cmode, addmode, ref srq, ref erq);
            sdate = srq.ToString();
            edate = erq.ToString();
        }

        /// <summary>格式化统计日期</summary>
        /// <param name="cmode">统计模式,0:天;1:周;2:月;3:季;4:半年;5:年;6:自定义;</param>
        /// <param name="addmode">日期模式,0:当前日期;1:上一日期(环比期);2:下一日期;3:指定日期的同比期;</param>
        /// <param name="sdates">需要计算并返回的开始日期</param>
        /// <param name="edates">需要计算并返回的结束日期</param>
        public static void FormatCountDate(string cmode, string addmode, ref string sdates, ref string edates)
        {
            DateTime dqrq = DateTime.Now;
            DateTime sdate = dqrq;
            DateTime edate = dqrq;
            if (Often.IsDate(sdates))
            {
                sdate = Convert.ToDateTime(sdates);
            }
            if (Often.IsDate(edates))
            {
                edate = Convert.ToDateTime(edates);
            }
            FormatCountDate(cmode, addmode, ref sdate, ref edate);
            sdates = sdate.ToString();
            edates = edate.ToString();
        }

        /// <summary>格式化统计日期</summary>
        /// <param name="cmode">统计模式,0:天;1:周;2:月;3:季;4:半年;5:年;6:自定义;</param>
        /// <param name="addmode">日期模式,0:当前日期;1:上一日期(环比期);2:下一日期;3:指定日期的同比期;</param>
        /// <param name="sdate">需要计算并返回的开始日期</param>
        /// <param name="edate">需要计算并返回的结束日期</param>
        public static void FormatCountDate(string cmode, string addmode, ref DateTime sdate, ref DateTime edate)
        {
            int cmodeint = 0;
            if (Often.IsInt32(cmode))
            {
                cmodeint = Convert.ToInt32(cmode);
            }
            int addmodeint = 0;
            if (Often.IsInt32(addmode))
            {
                addmodeint = Convert.ToInt32(addmode);
            }
            if (cmodeint != 6 && addmodeint == 0)
            {
                DateTime dqrq = DateTime.Now;
                sdate = dqrq;
                edate = dqrq;
            }
        }

        /// <summary>返回开始日期最早时间与返回结束日期最晚时间</summary>
        /// <param name="sdate">返回开始日期最早时间</param>
        /// <param name="edate">返回结束日期最晚时间</param>
        public static void LoadSEDate(ref DateTime sdate, ref DateTime edate)
        {
            if (edate < sdate)
            {
                edate = sdate;
            }
            sdate = Convert.ToDateTime(DateOften.ReFDateTime("{$Year}-{$Month}-{$Day} 0:0:0", sdate));
            edate = Convert.ToDateTime(DateOften.ReFDateTime("{$Year}-{$Month}-{$Day} 23:59:59", edate));
        }

        /// <summary>返回开始日期最早时间与返回结束日期最晚时间</summary>
        /// <param name="sdates">返回开始日期最早时间</param>
        /// <param name="edates">返回结束日期最晚时间</param>
        public static void LoadSEDate(ref string sdates, ref string edates)
        {
            DateTime dqrq = DateTime.Now;
            DateTime sdate = dqrq;
            DateTime edate = dqrq;
            if (Often.IsDate(sdates))
            {
                sdate = Convert.ToDateTime(sdates);
            }
            if (Often.IsDate(edates))
            {
                edate = Convert.ToDateTime(edates);
            }
            LoadSEDate(ref sdate, ref edate);
            sdates = sdate.ToString();
            edates = edate.ToString();
        }

        /// <summary>返回指定日期的上一周周一</summary>
        /// <param name="rq">日期</param>
        /// <returns>返回指定日期的上一周周一</returns>
        public static DateTime GetWeekUpMonday(string rq)
        {
            if (!Often.IsDate(rq))
            {
                return GetWeekUpMonday(DateTime.Now);
            }
            return GetWeekUpMonday(Convert.ToDateTime(rq));
        }

        /// <summary>返回指定日期的上一周周一</summary>
        /// <param name="rq">日期</param>
        /// <returns>返回指定日期的上一周周一</returns>
        public static DateTime GetWeekUpMonday(DateTime rq)
        {
            return GetWeekMonday(rq).AddDays(-7);
        }

        /// <summary>返回指定日期的上一周周日</summary>
        /// <param name="rq">日期</param>
        /// <returns>返回指定日期的上一周周日</returns>
        public static DateTime GetWeekUpSunday(string rq)
        {
            if (!Often.IsDate(rq))
            {
                return GetWeekUpSunday(DateTime.Now);
            }
            return GetWeekUpSunday(Convert.ToDateTime(rq));
        }

        /// <summary>返回指定日期的上一周周日</summary>
        /// <param name="rq">日期</param>
        /// <returns>返回指定日期的上一周周日</returns>
        public static DateTime GetWeekUpSunday(DateTime rq)
        {
            return Convert.ToDateTime(DateOften.ReDateTime("{$Year}-{$Month}-{$Day} 23:59:59", GetWeekUpMonday(rq).AddDays(6)));
        }

        /// <summary>返回指定日期的下一周周一</summary>
        /// <param name="rq">日期</param>
        /// <returns>返回指定日期的下一周周一</returns>
        public static DateTime GetWeekNextMonday(string rq)
        {
            if (!Often.IsDate(rq))
            {
                return GetWeekNextMonday(DateTime.Now);
            }
            return GetWeekNextMonday(Convert.ToDateTime(rq));
        }

        /// <summary>返回指定日期的下一周周一</summary>
        /// <param name="rq">日期</param>
        /// <returns>返回指定日期的下一周周一</returns>
        public static DateTime GetWeekNextMonday(DateTime rq)
        {
            return GetWeekSunday(rq).AddDays(1);
        }

        /// <summary>返回指定日期的下一周周日</summary>
        /// <param name="rq">日期</param>
        /// <returns>返回指定日期的下一周周日</returns>
        public static DateTime GetWeekNextSunday(string rq)
        {
            if (!Often.IsDate(rq))
            {
                return GetWeekNextSunday(DateTime.Now);
            }
            return GetWeekNextSunday(Convert.ToDateTime(rq));
        }

        /// <summary>返回指定日期的下一周周日</summary>
        /// <param name="rq">日期</param>
        /// <returns>返回指定日期的下一周周日</returns>
        public static DateTime GetWeekNextSunday(DateTime rq)
        {
            return Convert.ToDateTime(DateOften.ReDateTime("{$Year}-{$Month}-{$Day} 23:59:59", GetWeekNextMonday(rq).AddDays(6)));
        }

        /// <summary>返回指定日期的本周周一</summary>
        /// <param name="rq">日期</param>
        /// <returns>返回指定日期的本周周一</returns>
        public static DateTime GetWeekMonday(string rq)
        {
            if (!Often.IsDate(rq))
            {
                return GetWeekMonday(DateTime.Now);
            }
            return GetWeekMonday(Convert.ToDateTime(rq));
        }

        /// <summary>返回指定日期的本周周一</summary>
        /// <param name="rq">日期</param>
        /// <returns>返回指定日期的本周周一</returns>
        public static DateTime GetWeekMonday(DateTime rq)
        {
            DateTime srq = rq.AddDays(1 - DayToNumWeek(rq));
            return Convert.ToDateTime(DateOften.ReDateTime("{$Year}-{$Month}-{$Day} 0:0:0", srq));
        }

        /// <summary>返回指定日期的本周周日</summary>
        /// <param name="rq">日期</param>
        /// <returns>返回指定日期的本周周日</returns>
        public static DateTime GetWeekSunday(string rq)
        {
            if (!Often.IsDate(rq))
            {
                return GetWeekSunday(DateTime.Now);
            }
            return GetWeekSunday(Convert.ToDateTime(rq));
        }

        /// <summary>返回指定日期的本周周日</summary>
        /// <param name="rq">日期</param>
        /// <returns>返回指定日期的本周周日</returns>
        public static DateTime GetWeekSunday(DateTime rq)
        {
            return Convert.ToDateTime(DateOften.ReDateTime("{$Year}-{$Month}-{$Day} 23:59:59", GetWeekMonday(rq).AddDays(6)));
        }

        /// <summary>返回指定日期的上一月最后一天</summary>
        /// <param name="rq">日期</param>
        /// <returns>返回指定日期的上一月最后一天</returns>
        public static DateTime GetMonthUpEnd(string rq)
        {
            if (!Often.IsDate(rq))
            {
                return GetMonthUpEnd(DateTime.Now);
            }
            return GetMonthUpEnd(Convert.ToDateTime(rq));
        }

        /// <summary>返回指定日期的上一月最后一天</summary>
        /// <param name="rq">日期</param>
        /// <returns>返回指定日期的上一月最后一天</returns>
        public static DateTime GetMonthUpEnd(DateTime rq)
        {
            DateTime srq = GetMonthUpStart(rq).AddMonths(1).AddDays(-1);
            return Convert.ToDateTime(DateOften.ReDateTime("{$Year}-{$Month}-{$Day} 23:59:59", srq));
        }

        /// <summary>返回指定日期的上一月第一天</summary>
        /// <param name="rq">日期</param>
        /// <returns>返回指定日期的上一月第一天</returns>
        public static DateTime GetMonthUpStart(string rq)
        {
            if (!Often.IsDate(rq))
            {
                return GetMonthUpStart(DateTime.Now);
            }
            return GetMonthUpStart(Convert.ToDateTime(rq));
        }

        /// <summary>返回指定日期的上一月第一天</summary>
        /// <param name="rq">日期</param>
        /// <returns>返回指定日期的上一月第一天</returns>
        public static DateTime GetMonthUpStart(DateTime rq)
        {
            return Convert.ToDateTime(DateOften.ReDateTime("{$Year}-{$Month}-1 0:0:0", rq.AddMonths(-1)));
        }

        /// <summary>返回指定日期的下一月最后一天</summary>
        /// <param name="rq">日期</param>
        /// <returns>返回指定日期的下一月最后一天</returns>
        public static DateTime GetMonthNextEnd(string rq)
        {
            if (!Often.IsDate(rq))
            {
                return GetMonthNextEnd(DateTime.Now);
            }
            return GetMonthNextEnd(Convert.ToDateTime(rq));
        }

        /// <summary>返回指定日期的下一月最后一天</summary>
        /// <param name="rq">日期</param>
        /// <returns>返回指定日期的下一月最后一天</returns>
        public static DateTime GetMonthNextEnd(DateTime rq)
        {
            DateTime srq = GetMonthNextStart(rq).AddMonths(1).AddDays(-1);
            return Convert.ToDateTime(DateOften.ReDateTime("{$Year}-{$Month}-{$Day} 23:59:59", srq));
        }

        /// <summary>返回指定日期的下一月第一天</summary>
        /// <param name="rq">日期</param>
        /// <returns>返回指定日期的下一月第一天</returns>
        public static DateTime GetMonthNextStart(string rq)
        {
            if (!Often.IsDate(rq))
            {
                return GetMonthNextStart(DateTime.Now);
            }
            return GetMonthNextStart(Convert.ToDateTime(rq));
        }

        /// <summary>返回指定日期的下一月第一天</summary>
        /// <param name="rq">日期</param>
        /// <returns>返回指定日期的下一月第一天</returns>
        public static DateTime GetMonthNextStart(DateTime rq)
        {
            return Convert.ToDateTime(DateOften.ReDateTime("{$Year}-{$Month}-1 0:0:0", rq.AddMonths(1)));
        }

        /// <summary>返回指定日期的本月最后一天</summary>
        /// <param name="rq">日期</param>
        /// <returns>返回指定日期的本月最后一天</returns>
        public static DateTime GetMonthEnd(string rq)
        {
            if (!Often.IsDate(rq))
            {
                return GetMonthEnd(DateTime.Now);
            }
            return GetMonthEnd(Convert.ToDateTime(rq));
        }

        /// <summary>返回指定日期的本月最后一天</summary>
        /// <param name="rq">日期</param>
        /// <returns>返回指定日期的本月最后一天</returns>
        public static DateTime GetMonthEnd(DateTime rq)
        {
            DateTime srq = GetMonthStart(rq).AddMonths(1).AddDays(-1);
            return Convert.ToDateTime(DateOften.ReDateTime("{$Year}-{$Month}-{$Day} 23:59:59", srq));
        }

        /// <summary>返回指定日期的本月第一天</summary>
        /// <param name="rq">日期</param>
        /// <returns>返回指定日期的本月第一天</returns>
        public static DateTime GetMonthStart(string rq)
        {
            if (!Often.IsDate(rq))
            {
                return GetMonthStart(DateTime.Now);
            }
            return GetMonthStart(Convert.ToDateTime(rq));
        }

        /// <summary>返回指定日期的本月第一天</summary>
        /// <param name="rq">日期</param>
        /// <returns>返回指定日期的本月第一天</returns>
        public static DateTime GetMonthStart(DateTime rq)
        {
            return Convert.ToDateTime(DateOften.ReDateTime("{$Year}-{$Month}-1 0:0:0", rq));
        }

        /// <summary>返回指定日期的上一季度最后一天</summary>
        /// <param name="rq">日期</param>
        /// <returns>返回指定日期的上一季度最后一天</returns>
        public static DateTime GetSeasonUpEnd(string rq)
        {
            if (!Often.IsDate(rq))
            {
                return GetSeasonUpEnd(DateTime.Now);
            }
            return GetSeasonUpEnd(Convert.ToDateTime(rq));
        }

        /// <summary>返回指定日期的上一季度最后一天</summary>
        /// <param name="rq">日期</param>
        /// <returns>返回指定日期的上一季度最后一天</returns>
        public static DateTime GetSeasonUpEnd(DateTime rq)
        {
            DateTime srq = GetSeasonStart(rq).AddDays(-1);
            return Convert.ToDateTime(DateOften.ReDateTime("{$Year}-{$Month}-{$Day} 23:59:59", srq));
        }

        /// <summary>返回指定日期的上一季度第一天</summary>
        /// <param name="rq">日期</param>
        /// <returns>返回指定日期的上一季度第一天</returns>
        public static DateTime GetSeasonUpStart(string rq)
        {
            if (!Often.IsDate(rq))
            {
                return GetSeasonUpStart(DateTime.Now);
            }
            return GetSeasonUpStart(Convert.ToDateTime(rq));
        }

        /// <summary>返回指定日期的上一季度第一天</summary>
        /// <param name="rq">日期</param>
        /// <returns>返回指定日期的上一季度第一天</returns>
        public static DateTime GetSeasonUpStart(DateTime rq)
        {
            return GetSeasonStart(GetSeasonUpEnd(rq));
        }

        /// <summary>返回指定日期的下一季度最后一天</summary>
        /// <param name="rq">日期</param>
        /// <returns>返回指定日期的下一季度最后一天</returns>
        public static DateTime GetSeasonNextEnd(string rq)
        {
            if (!Often.IsDate(rq))
            {
                return GetSeasonNextEnd(DateTime.Now);
            }
            return GetSeasonNextEnd(Convert.ToDateTime(rq));
        }

        /// <summary>返回指定日期的下一季度最后一天</summary>
        /// <param name="rq">日期</param>
        /// <returns>返回指定日期的下一季度最后一天</returns>
        public static DateTime GetSeasonNextEnd(DateTime rq)
        {
            return GetSeasonEnd(GetSeasonNextStart(rq));
        }

        /// <summary>返回指定日期的下一季度第一天</summary>
        /// <param name="rq">日期</param>
        /// <returns>返回指定日期的下一季度第一天</returns>
        public static DateTime GetSeasonNextStart(string rq)
        {
            if (!Often.IsDate(rq))
            {
                return GetSeasonNextStart(DateTime.Now);
            }
            return GetSeasonNextStart(Convert.ToDateTime(rq));
        }

        /// <summary>返回指定日期的下一季度第一天</summary>
        /// <param name="rq">日期</param>
        /// <returns>返回指定日期的下一季度第一天</returns>
        public static DateTime GetSeasonNextStart(DateTime rq)
        {
            DateTime srq = GetSeasonEnd(rq).AddDays(1);
            return Convert.ToDateTime(DateOften.ReDateTime("{$Year}-{$Month}-1 0:0:0", srq));
        }

        /// <summary>返回指定日期的本季度最后一天</summary>
        /// <param name="rq">日期</param>
        /// <returns>返回指定日期的本季度最后一天</returns>
        public static DateTime GetSeasonEnd(string rq)
        {
            if (!Often.IsDate(rq))
            {
                return GetSeasonEnd(DateTime.Now);
            }
            return GetSeasonEnd(Convert.ToDateTime(rq));
        }

        /// <summary>返回指定日期的本季度最后一天</summary>
        /// <param name="rq">日期</param>
        /// <returns>返回指定日期的本季度最后一天</returns>
        public static DateTime GetSeasonEnd(DateTime rq)
        {
            DateTime srq = GetSeasonStart(rq).AddMonths(3).AddDays(-1);
            return Convert.ToDateTime(DateOften.ReDateTime("{$Year}-{$Month}-{$Day} 23:59:59", srq));
        }

        /// <summary>返回指定日期的本季度第一天</summary>
        /// <param name="rq">日期</param>
        /// <returns>返回指定日期的本季度第一天</returns>
        public static DateTime GetSeasonStart(string rq)
        {
            if (!Often.IsDate(rq))
            {
                return GetSeasonStart(DateTime.Now);
            }
            return GetSeasonStart(Convert.ToDateTime(rq));
        }

        /// <summary>返回指定日期的本季度第一天</summary>
        /// <param name="rq">日期</param>
        /// <returns>返回指定日期的本季度第一天</returns>
        public static DateTime GetSeasonStart(DateTime rq)
        {
            DateTime srq = rq.AddMonths(0 - (rq.Month - 1) % 3).AddDays(1 - rq.Day);
            return Convert.ToDateTime(DateOften.ReDateTime("{$Year}-{$Month}-1 0:0:0", srq));
        }

        /// <summary>返回指定日期的上一半年度最后一天</summary>
        /// <param name="rq">日期</param>
        /// <returns>返回指定日期的上半年度最后一天</returns>
        public static DateTime GetHalfyearUpEnd(string rq)
        {
            if (!Often.IsDate(rq))
            {
                return GetHalfyearUpEnd(DateTime.Now);
            }
            return GetHalfyearUpEnd(Convert.ToDateTime(rq));
        }

        /// <summary>返回指定日期的上一半年度最后一天</summary>
        /// <param name="rq">日期</param>
        /// <returns>返回指定日期的上一半年度最后一天</returns>
        public static DateTime GetHalfyearUpEnd(DateTime rq)
        {
            DateTime srq = GetHalfyearStart(rq).AddDays(-1);
            return Convert.ToDateTime(DateOften.ReDateTime("{$Year}-{$Month}-{$Day} 23:59:59", srq));
        }

        /// <summary>返回指定日期的上一半年度第一天</summary>
        /// <param name="rq">日期</param>
        /// <returns>返回指定日期的上一半年度第一天</returns>
        public static DateTime GetHalfyearUpStart(string rq)
        {
            if (!Often.IsDate(rq))
            {
                return GetHalfyearUpStart(DateTime.Now);
            }
            return GetHalfyearUpStart(Convert.ToDateTime(rq));
        }

        /// <summary>返回指定日期的上一半年度第一天</summary>
        /// <param name="rq">日期</param>
        /// <returns>返回指定日期的上一半年度第一天</returns>
        public static DateTime GetHalfyearUpStart(DateTime rq)
        {
            return GetHalfyearStart(GetHalfyearUpEnd(rq));
        }

        /// <summary>返回指定日期的下一半年度最后一天</summary>
        /// <param name="rq">日期</param>
        /// <returns>返回指定日期的下一半年度最后一天</returns>
        public static DateTime GetHalfyearNextEnd(string rq)
        {
            if (!Often.IsDate(rq))
            {
                return GetHalfyearNextEnd(DateTime.Now);
            }
            return GetHalfyearNextEnd(Convert.ToDateTime(rq));
        }

        /// <summary>返回指定日期的下一半年度最后一天</summary>
        /// <param name="rq">日期</param>
        /// <returns>返回指定日期的下一半年度最后一天</returns>
        public static DateTime GetHalfyearNextEnd(DateTime rq)
        {
            return GetHalfyearEnd(GetHalfyearNextStart(rq));
        }

        /// <summary>返回指定日期的下一半年度第一天</summary>
        /// <param name="rq">日期</param>
        /// <returns>返回指定日期的下一半年度第一天</returns>
        public static DateTime GetHalfyearNextStart(string rq)
        {
            if (!Often.IsDate(rq))
            {
                return GetHalfyearNextStart(DateTime.Now);
            }
            return GetHalfyearNextStart(Convert.ToDateTime(rq));
        }

        /// <summary>返回指定日期的下一半年度第一天</summary>
        /// <param name="rq">日期</param>
        /// <returns>返回指定日期的下一半年度第一天</returns>
        public static DateTime GetHalfyearNextStart(DateTime rq)
        {
            DateTime srq = GetHalfyearEnd(rq).AddDays(1);
            return Convert.ToDateTime(DateOften.ReDateTime("{$Year}-{$Month}-1 0:0:0", srq));
        }

        /// <summary>返回指定日期的本半年最后一天</summary>
        /// <param name="rq">日期</param>
        /// <returns>返回指定日期的本半年最后一天</returns>
        public static DateTime GetHalfyearEnd(string rq)
        {
            if (!Often.IsDate(rq))
            {
                return GetHalfyearEnd(DateTime.Now);
            }
            return GetHalfyearEnd(Convert.ToDateTime(rq));
        }

        /// <summary>返回指定日期的本半年最后一天</summary>
        /// <param name="rq">日期</param>
        /// <returns>返回指定日期的本半年最后一天</returns>
        public static DateTime GetHalfyearEnd(DateTime rq)
        {
            int yf = rq.Month;
            if (yf > 6)
            {
                return GetMonthEnd(Convert.ToDateTime(DateOften.ReDateTime("{$Year}-12-1 0:0:0", rq)));
            }
            else
            {
                return GetMonthEnd(Convert.ToDateTime(DateOften.ReDateTime("{$Year}-6-1 0:0:0", rq)));
            }
        }

        /// <summary>返回指定日期的本半年第一天</summary>
        /// <param name="rq">日期</param>
        /// <returns>返回指定日期的本半年第一天</returns>
        public static DateTime GetHalfyearStart(string rq)
        {
            if (!Often.IsDate(rq))
            {
                return GetHalfyearStart(DateTime.Now);
            }
            return GetHalfyearStart(Convert.ToDateTime(rq));
        }

        /// <summary>返回指定日期的本半年第一天</summary>
        /// <param name="rq">日期</param>
        /// <returns>返回指定日期的本半年第一天</returns>
        public static DateTime GetHalfyearStart(DateTime rq)
        {
            int yf = rq.Month;
            if (yf > 6)
            {
                return Convert.ToDateTime(DateOften.ReDateTime("{$Year}-7-1 0:0:0", rq));
            }
            else
            {
                return Convert.ToDateTime(DateOften.ReDateTime("{$Year}-1-1 0:0:0", rq));
            }
        }

        /// <summary>返回指定日期的上一年最后一天</summary>
        /// <param name="rq">日期</param>
        /// <returns>返回指定日期的上一年最后一天</returns>
        public static DateTime GetYearUpEnd(string rq)
        {
            if (!Often.IsDate(rq))
            {
                return GetYearUpEnd(DateTime.Now);
            }
            return GetYearUpEnd(Convert.ToDateTime(rq));
        }

        /// <summary>返回指定日期的上一年最后一天</summary>
        /// <param name="rq">日期</param>
        /// <returns>返回指定日期的上一年最后一天</returns>
        public static DateTime GetYearUpEnd(DateTime rq)
        {
            DateTime srq = GetYearUpStart(rq).AddYears(1).AddDays(-1);
            return Convert.ToDateTime(DateOften.ReDateTime("{$Year}-{$Month}-{$Day} 23:59:59", srq));
        }

        /// <summary>返回指定日期的上一年第一天</summary>
        /// <param name="rq">日期</param>
        /// <returns>返回指定日期的上一年第一天</returns>
        public static DateTime GetYearUpStart(string rq)
        {
            if (!Often.IsDate(rq))
            {
                return GetYearUpStart(DateTime.Now);
            }
            return GetYearUpStart(Convert.ToDateTime(rq));
        }

        /// <summary>返回指定日期的上一年第一天</summary>
        /// <param name="rq">日期</param>
        /// <returns>返回指定日期的上一年第一天</returns>
        public static DateTime GetYearUpStart(DateTime rq)
        {
            return Convert.ToDateTime(DateOften.ReDateTime("{$Year}-1-1 0:0:0", rq.AddYears(-1)));
        }

        /// <summary>返回指定日期的下一年最后一天</summary>
        /// <param name="rq">日期</param>
        /// <returns>返回指定日期的下一年最后一天</returns>
        public static DateTime GetYearNextEnd(string rq)
        {
            if (!Often.IsDate(rq))
            {
                return GetYearNextEnd(DateTime.Now);
            }
            return GetYearNextEnd(Convert.ToDateTime(rq));
        }

        /// <summary>返回指定日期的下一年最后一天</summary>
        /// <param name="rq">日期</param>
        /// <returns>返回指定日期的下一年最后一天</returns>
        public static DateTime GetYearNextEnd(DateTime rq)
        {
            DateTime srq = GetYearNextStart(rq).AddYears(1).AddDays(-1);
            return Convert.ToDateTime(DateOften.ReDateTime("{$Year}-{$Month}-{$Day} 23:59:59", srq));
        }

        /// <summary>返回指定日期的下一年第一天</summary>
        /// <param name="rq">日期</param>
        /// <returns>返回指定日期的下一年第一天</returns>
        public static DateTime GetYearNextStart(string rq)
        {
            if (!Often.IsDate(rq))
            {
                return GetYearNextStart(DateTime.Now);
            }
            return GetYearNextStart(Convert.ToDateTime(rq));
        }

        /// <summary>返回指定日期的下一年第一天</summary>
        /// <param name="rq">日期</param>
        /// <returns>返回指定日期的下一年第一天</returns>
        public static DateTime GetYearNextStart(DateTime rq)
        {
            return Convert.ToDateTime(DateOften.ReDateTime("{$Year}-1-1 0:0:0", rq.AddYears(1)));
        }

        /// <summary>返回指定日期的本年最后一天</summary>
        /// <param name="rq">日期</param>
        /// <returns>返回指定日期的本年最后一天</returns>
        public static DateTime GetYearEnd(string rq)
        {
            if (!Often.IsDate(rq))
            {
                return GetYearEnd(DateTime.Now);
            }
            return GetYearEnd(Convert.ToDateTime(rq));
        }

        /// <summary>返回指定日期的本年最后一天</summary>
        /// <param name="rq">日期</param>
        /// <returns>返回指定日期的本年最后一天</returns>
        public static DateTime GetYearEnd(DateTime rq)
        {
            DateTime srq = GetYearStart(rq).AddYears(1).AddDays(-1);
            return Convert.ToDateTime(DateOften.ReDateTime("{$Year}-{$Month}-{$Day} 23:59:59", srq));
        }

        /// <summary>返回指定日期的本年第一天</summary>
        /// <param name="rq">日期</param>
        /// <returns>返回指定日期的本年第一天</returns>
        public static DateTime GetYearStart(string rq)
        {
            if (!Often.IsDate(rq))
            {
                return GetYearStart(DateTime.Now);
            }
            return GetYearStart(Convert.ToDateTime(rq));
        }

        /// <summary>返回指定日期的本年第一天</summary>
        /// <param name="rq">日期</param>
        /// <returns>返回指定日期的本年第一天</returns>
        public static DateTime GetYearStart(DateTime rq)
        {
            return Convert.ToDateTime(DateOften.ReDateTime("{$Year}-1-1 0:0:0", rq));
        }

        /// <summary>返回指定日期的本周同比周一</summary>
        /// <param name="rq">日期</param>
        /// <returns>返回指定日期的本周同比周一</returns>
        public static DateTime GetWeekMondayOn(string rq)
        {
            if (!Often.IsDate(rq))
            {
                return GetWeekMondayOn(DateTime.Now);
            }
            return GetWeekMondayOn(Convert.ToDateTime(rq));
        }

        /// <summary>返回指定日期的本周同比周一</summary>
        /// <param name="rq">日期</param>
        /// <returns>返回指定日期的本周同比周一</returns>
        public static DateTime GetWeekMondayOn(DateTime rq)
        {
            DateTime trq = GetWeekMonday(rq.AddYears(-1));
            int dwnum = GetDayOfWeek(rq);
            int tdwnum = GetDayOfWeek(trq);
            int ynum = trq.Year;
            int nynum = ynum;
            while (dwnum != tdwnum && nynum == ynum)
            {
                DateTime crq = trq;
                if (dwnum > tdwnum)
                {
                    crq = GetWeekNextMonday(crq);
                    tdwnum++;
                }
                else
                {
                    crq = GetWeekUpMonday(crq);
                    tdwnum--;
                }
                nynum = crq.Year;
                if (nynum == ynum)
                {
                    trq = crq;
                }
            }
            return trq;
        }

        /// <summary>返回指定日期的本周同比周日</summary>
        /// <param name="rq">日期</param>
        /// <returns>返回指定日期的本周同比周日</returns>
        public static DateTime GetWeekSundayOn(string rq)
        {
            if (!Often.IsDate(rq))
            {
                return GetWeekSundayOn(DateTime.Now);
            }
            return GetWeekSundayOn(Convert.ToDateTime(rq));
        }

        /// <summary>返回指定日期的本周同比周日</summary>
        /// <param name="rq">日期</param>
        /// <returns>返回指定日期的本周同比周日</returns>
        public static DateTime GetWeekSundayOn(DateTime rq)
        {
            DateTime trq = GetWeekSunday(rq.AddYears(-1));
            int dwnum = GetDayOfWeek(rq);
            int tdwnum = GetDayOfWeek(trq);
            int ynum = trq.Year;
            int nynum = ynum;
            while (dwnum != tdwnum && nynum == ynum)
            {
                DateTime crq = trq;
                if (dwnum > tdwnum)
                {
                    crq = GetWeekNextSunday(crq);
                    tdwnum++;
                }
                else
                {
                    crq = GetWeekUpSunday(crq);
                    tdwnum--;
                }
                nynum = crq.Year;
                if (nynum == ynum)
                {
                    trq = crq;
                }
            }
            return trq;
        }

        /// <summary>返回指定日期的本月同比最后一天</summary>
        /// <param name="rq">日期</param>
        /// <returns>返回指定日期的本月同比最后一天</returns>
        public static DateTime GetMonthEndOn(string rq)
        {
            if (!Often.IsDate(rq))
            {
                return GetMonthEndOn(DateTime.Now);
            }
            return GetMonthEndOn(Convert.ToDateTime(rq));
        }

        /// <summary>返回指定日期的本月同比最后一天</summary>
        /// <param name="rq">日期</param>
        /// <returns>返回指定日期的本月同比最后一天</returns>
        public static DateTime GetMonthEndOn(DateTime rq)
        {
            return GetMonthEnd(rq.AddYears(-1));
        }

        /// <summary>返回指定日期的本月同比第一天</summary>
        /// <param name="rq">日期</param>
        /// <returns>返回指定日期的本月同比第一天</returns>
        public static DateTime GetMonthStartOn(string rq)
        {
            if (!Often.IsDate(rq))
            {
                return GetMonthStartOn(DateTime.Now);
            }
            return GetMonthStartOn(Convert.ToDateTime(rq));
        }

        /// <summary>返回指定日期的本月同比第一天</summary>
        /// <param name="rq">日期</param>
        /// <returns>返回指定日期的本月同比第一天</returns>
        public static DateTime GetMonthStartOn(DateTime rq)
        {
            return GetMonthStart(rq.AddYears(-1));
        }

        /// <summary>返回指定日期的本季度同比最后一天</summary>
        /// <param name="rq">日期</param>
        /// <returns>返回指定日期的本季度同比最后一天</returns>
        public static DateTime GetSeasonEndOn(string rq)
        {
            if (!Often.IsDate(rq))
            {
                return GetSeasonEndOn(DateTime.Now);
            }
            return GetSeasonEndOn(Convert.ToDateTime(rq));
        }

        /// <summary>返回指定日期的本季度同比最后一天</summary>
        /// <param name="rq">日期</param>
        /// <returns>返回指定日期的本季度同比最后一天</returns>
        public static DateTime GetSeasonEndOn(DateTime rq)
        {
            return GetSeasonEnd(rq.AddYears(-1));
        }

        /// <summary>返回指定日期的本季度同比第一天</summary>
        /// <param name="rq">日期</param>
        /// <returns>返回指定日期的本季度同比第一天</returns>
        public static DateTime GetSeasonStartOn(string rq)
        {
            if (!Often.IsDate(rq))
            {
                return GetSeasonStartOn(DateTime.Now);
            }
            return GetSeasonStartOn(Convert.ToDateTime(rq));
        }

        /// <summary>返回指定日期的本季度同比第一天</summary>
        /// <param name="rq">日期</param>
        /// <returns>返回指定日期的本季度同比第一天</returns>
        public static DateTime GetSeasonStartOn(DateTime rq)
        {
            return GetSeasonStart(rq.AddYears(-1));
        }

        /// <summary>返回指定日期的本半年同比最后一天</summary>
        /// <param name="rq">日期</param>
        /// <returns>返回指定日期的本半年同比最后一天</returns>
        public static DateTime GetHalfyearEndOn(string rq)
        {
            if (!Often.IsDate(rq))
            {
                return GetHalfyearEndOn(DateTime.Now);
            }
            return GetHalfyearEndOn(Convert.ToDateTime(rq));
        }

        /// <summary>返回指定日期的本半年同比最后一天</summary>
        /// <param name="rq">日期</param>
        /// <returns>返回指定日期的本半年同比最后一天</returns>
        public static DateTime GetHalfyearEndOn(DateTime rq)
        {
            return GetHalfyearEnd(rq.AddYears(-1));
        }

        /// <summary>返回指定日期的本半年同比第一天</summary>
        /// <param name="rq">日期</param>
        /// <returns>返回指定日期的本半年同比第一天</returns>
        public static DateTime GetHalfyearStartOn(string rq)
        {
            if (!Often.IsDate(rq))
            {
                return GetHalfyearStartOn(DateTime.Now);
            }
            return GetHalfyearStartOn(Convert.ToDateTime(rq));
        }

        /// <summary>返回指定日期的本半年同比第一天</summary>
        /// <param name="rq">日期</param>
        /// <returns>返回指定日期的本半年同比第一天</returns>
        public static DateTime GetHalfyearStartOn(DateTime rq)
        {
            return GetHalfyearStart(rq.AddYears(-1));
        }

        /// <summary>返回指定日期的本年同比最后一天</summary>
        /// <param name="rq">日期</param>
        /// <returns>返回指定日期的本年同比最后一天</returns>
        public static DateTime GetYearEndOn(string rq)
        {
            if (!Often.IsDate(rq))
            {
                return GetYearEndOn(DateTime.Now);
            }
            return GetYearEndOn(Convert.ToDateTime(rq));
        }

        /// <summary>返回指定日期的本年同比最后一天</summary>
        /// <param name="rq">日期</param>
        /// <returns>返回指定日期的本年同比最后一天</returns>
        public static DateTime GetYearEndOn(DateTime rq)
        {
            return GetYearEnd(rq.AddYears(-1));
        }

        /// <summary>返回指定日期的本年同比第一天</summary>
        /// <param name="rq">日期</param>
        /// <returns>返回指定日期的本年同比第一天</returns>
        public static DateTime GetYearStartOn(string rq)
        {
            if (!Often.IsDate(rq))
            {
                return GetYearStartOn(DateTime.Now);
            }
            return GetYearStartOn(Convert.ToDateTime(rq));
        }

        /// <summary>返回指定日期的本年同比第一天</summary>
        /// <param name="rq">日期</param>
        /// <returns>返回指定日期的本年同比第一天</returns>
        public static DateTime GetYearStartOn(DateTime rq)
        {
            return GetYearStart(rq.AddYears(-1));
        }

        /// <summary>返回指定日期是本年度第几周</summary>
        /// <param name="date">指定日期</param>
        /// <returns>返回指定日期是本年度第几周</returns>
        public static int GetDayOfWeek(string date)
        {
            if (!Often.IsDate(date))
            {
                return GetDayOfWeek(DateTime.Now);
            }
            return GetDayOfWeek(Convert.ToDateTime(date));
        }

        /// <summary>返回指定日期是本年度第几周</summary>
        /// <param name="date">指定日期</param>
        /// <returns>返回指定日期是本年度第几周</returns>
        public static int GetDayOfWeek(DateTime date)
        {
            return date.DayOfYear / 7 + 1;
        }

        /// <summary>返回指定日期是本月中第几周</summary>
        /// <param name="date">指定日期</param>
        /// <returns>返回指定日期是本月中第几周</returns>
        public static int WeekOfMonth(string date)
        {
            if (!Often.IsDate(date))
            {
                return WeekOfMonth(DateTime.Now);
            }
            return WeekOfMonth(Convert.ToDateTime(date));
        }

        /// <summary>返回指定日期是本月中第几周</summary>
        /// <param name="date">指定日期</param>
        /// <returns>返回指定日期是本月中第几周</returns>
        public static int WeekOfMonth(DateTime date)
        {
            DateTime FirstofMonth = Convert.ToDateTime(DateOften.ReDateTime("{$Year}-{$Month}-01", date));
            int i = (int)DayToNumWeek(FirstofMonth);
            return (date.Date.Day + i - 2) / 7 + 1;
        }

        /// <summary>返回指定日期是本年度第几季度</summary>
        /// <param name="date">指定日期</param>
        /// <returns>返回指定日期是本年度第几季度</returns>
        public static int GetSeasonNum(string date)
        {
            if (!Often.IsDate(date))
            {
                return GetSeasonNum(DateTime.Now);
            }
            return GetSeasonNum(Convert.ToDateTime(date));
        }

        /// <summary>返回指定日期是本年度第几季度</summary>
        /// <param name="date">指定日期</param>
        /// <returns>返回指定日期是本年度第几季度</returns>
        public static int GetSeasonNum(DateTime date)
        {
            int m = date.Month;
            if (m < 4)
            {
                return 1;
            }
            else if (m > 3 && m < 7)
            {
                return 2;
            }
            else if (m > 6 && m < 10)
            {
                return 3;
            }
            return 4;
        }

        /// <summary>返回指定日期是本年度是上半年或着是下半年</summary>
        /// <param name="date">指定日期</param>
        /// <returns>返回指定日期是本年度是上半年或着是下半年</returns>
        public static string GetSemiyearly(string date)
        {
            if (!Often.IsDate(date))
            {
                return GetSemiyearly(DateTime.Now);
            }
            return GetSemiyearly(Convert.ToDateTime(date));
        }

        /// <summary>返回指定日期是本年度是上半年或着是下半年</summary>
        /// <param name="date">指定日期</param>
        /// <returns>返回指定日期是本年度是上半年或着是下半年</returns>
        public static string GetSemiyearly(DateTime date)
        {
            int m = date.Month;
            if (m < 7)
            {
                return "上半年";
            }
            else
            {
                return "下半年";
            }
        }

        /// <summary>根据统计模式返回统计标题日期</summary>
        /// <param name="cmode">统计模式,0:天;1:周;2:月;3:季;4:半年;5:年;6:自定义;</param>
        /// <param name="sdate">开始日期</param>
        /// <param name="edate">结束日期</param>
        /// <returns>根据统计模式返回统计标题日期</returns>
        public static string GetCountTitle(string cmode, string sdate, string edate)
        {
            if (cmode == "1")
            {
                return DateOften.ReDateTime("{$Year}", sdate) + "年第" + DateOften.GetDayOfWeek(sdate).ToString() + "周";
            }
            else if (cmode == "2")
            {
                return DateOften.ReDateTime("{$Year}年{$Month}月", sdate);
            }
            else if (cmode == "3")
            {
                return DateOften.ReDateTime("{$Year}", sdate) + "年第" + DateOften.GetSeasonNum(sdate).ToString() + "季";
            }
            else if (cmode == "4")
            {
                return DateOften.ReDateTime("{$Year}", sdate) + "年" + DateOften.GetSemiyearly(sdate).ToString();
            }
            else if (cmode == "5")
            {
                return DateOften.ReDateTime("{$Year}年", sdate);
            }
            return DateOften.ReDateTime("{$Year}年{$Month}月{$Day}日", sdate) + "-" + DateOften.ReDateTime("{$Year}年{$Month}月{$Day}日", edate);
        }

        /// <summary>根据统计模式返回统计标题日期</summary>
        /// <param name="cmode">统计模式,0:天;1:周;2:月;3:季;4:半年;5:年;6:自定义;</param>
        /// <param name="sdate">开始日期</param>
        /// <param name="edate">结束日期</param>
        /// <returns>根据统计模式返回统计标题日期</returns>
        public static string GetCountTitle(string cmode, DateTime sdate, DateTime edate)
        {
            if (cmode == "1")
            {
                return DateOften.ReDateTime("{$Year}", sdate) + "年第" + DateOften.GetDayOfWeek(sdate).ToString() + "周";
            }
            else if (cmode == "2")
            {
                return DateOften.ReDateTime("{$Year}年{$Month}月", sdate);
            }
            else if (cmode == "3")
            {
                return DateOften.ReDateTime("{$Year}", sdate) + "年第" + DateOften.GetSeasonNum(sdate).ToString() + "季";
            }
            else if (cmode == "4")
            {
                return DateOften.ReDateTime("{$Year}", sdate) + "年" + DateOften.GetSemiyearly(sdate).ToString();
            }
            else if (cmode == "5")
            {
                return DateOften.ReDateTime("{$Year}年", sdate);
            }
            return DateOften.ReDateTime("{$Year}年{$Month}月{$Day}日", sdate) + "-" + DateOften.ReDateTime("{$Year}年{$Month}月{$Day}日", edate);
        }

        /// <summary>根据统计模式返回统计标题</summary>
        /// <param name="cmode">统计模式,0:天;1:周;2:月;3:季;4:半年;5:年;6:自定义;</param>
        /// <param name="addmode">日期模式,0:本期日期;1:上期日期(环比期);2:下期日期;3:同比日期;</param>
        /// <param name="sdate">开始日期</param>
        /// <returns>根据统计模式返回统计标题</returns>
        public static string GetDateTitle(string cmode, string addmode, string sdate)
        {
            if (cmode == "1")
            {
                if (addmode == "0")
                {
                    return "本周(第" + DateOften.GetDayOfWeek(sdate).ToString() + "周)";
                }
                else if (addmode == "1")
                {
                    return "上周(第" + DateOften.GetDayOfWeek(sdate).ToString() + "周)";
                }
                else if (addmode == "2")
                {
                    return "下周(第" + DateOften.GetDayOfWeek(sdate).ToString() + "周)";
                }
                else if (addmode == "3")
                {
                    return "同期(第" + DateOften.GetDayOfWeek(sdate).ToString() + "周)";
                }
            }
            else if (cmode == "2")
            {
                DateTime rq = DateTime.Now;
                if (Often.IsDate(sdate))
                {
                    rq = Convert.ToDateTime(sdate);
                }
                int m = rq.Month;
                if (addmode == "0")
                {
                    return "本月(" + m.ToString() + "月)";
                }
                else if (addmode == "1")
                {
                    return "上月(" + m.ToString() + "月)";
                }
                else if (addmode == "2")
                {
                    return "下月(" + m.ToString() + "月)";
                }
                else if (addmode == "3")
                {
                    return "同期(" + m.ToString() + "月)";
                }
            }
            else if (cmode == "3")
            {
                if (addmode == "0")
                {
                    return "本季(第" + DateOften.GetSeasonNum(sdate).ToString() + "季)";
                }
                else if (addmode == "1")
                {
                    return "上季(第" + DateOften.GetSeasonNum(sdate).ToString() + "季)";
                }
                else if (addmode == "2")
                {
                    return "下季(第" + DateOften.GetSeasonNum(sdate).ToString() + "季)";
                }
                else if (addmode == "3")
                {
                    return "同期(第" + DateOften.GetSeasonNum(sdate).ToString() + "季)";
                }
            }
            else if (cmode == "4")
            {
                if (addmode == "0")
                {
                    return "本半年(" + DateOften.GetSemiyearly(sdate).ToString() + ")";
                }
                else if (addmode == "1")
                {
                    return "上半年(" + DateOften.GetSemiyearly(sdate).ToString() + ")";
                }
                else if (addmode == "2")
                {
                    return "下半年(" + DateOften.GetSemiyearly(sdate).ToString() + ")";
                }
                else if (addmode == "3")
                {
                    return "同期(" + DateOften.GetSemiyearly(sdate).ToString() + ")";
                }
            }
            else if (cmode == "5")
            {
                DateTime rq = DateTime.Now;
                if (Often.IsDate(sdate))
                {
                    rq = Convert.ToDateTime(sdate);
                }
                int y = rq.Year;
                if (addmode == "0")
                {
                    return "本年度(" + y.ToString() + "年)";
                }
                else if (addmode == "1")
                {
                    return "上年度(" + y.ToString() + "年)";
                }
                else if (addmode == "2")
                {
                    return "下年度(" + y.ToString() + "年)";
                }
                else if (addmode == "3")
                {
                    return "同期(" + y.ToString() + "年)";
                }
            }
            else
            {
                if (addmode == "0")
                {
                    return "本期";
                }
                else if (addmode == "1")
                {
                    return "上期";
                }
                else if (addmode == "2")
                {
                    return "下期";
                }
                else if (addmode == "3")
                {
                    return "同期";
                }
            }
            return "";
        }
    }
}

