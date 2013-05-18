using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GridUnlock.Common;

namespace GridUnlock
{
    /// <summary>
    /// 钥齿集
    /// </summary>
    public class KeyPointCollection : CollectionBase<KeyPoint>
    {
        public new void Add(KeyPoint item)
        {
            if (!Contains(item))
            {
                base.Add(item);
            }
            else
            {
                string strErrMsg = string.Format("不允许具有相同坐标值的钥齿 X：{0} Y：{1}", item.X, item.Y);
                throw new NotSupportedException(strErrMsg);
            }
        }
    }
}
