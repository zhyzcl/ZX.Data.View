using DXVision.Serialization.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ZX.Data.View
{
    ///<summary>实体信息</summary>
    public class EntityInfo
    {
        ///<summary>名称</summary>
        public string Name;
        ///<summary>是否显示(未使用)</summary>
        public bool Visible;
        ///<summary>键</summary>
        public string Key;
        ///<summary>区域</summary>
        public RectangleF Rect;
        ///<summary>相关复合属性</summary>
        public ComplexProperty Property;
    }
}
