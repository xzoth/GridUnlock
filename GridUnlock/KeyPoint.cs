using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridUnlock
{
    /// <summary>
    /// 钥齿
    /// </summary>
    public class KeyPoint
    {
        public int X
        {
            get;
            set;
        }

        public int Y
        {
            get;
            set;
        }

        public static bool operator ==(KeyPoint source, KeyPoint target)
        {
            return source.Equals(target);
        }

        public static bool operator !=(KeyPoint source, KeyPoint target)
        {
            return !source.Equals(target);
        }

        public override bool Equals(object obj)
        {
            var point = obj as KeyPoint;
            return (this.X == point.X && this.Y == point.Y);
        }

        public override int GetHashCode()
        {
            //可能会判定为相同(1, 2)   (2, 1)
            return (X + Y);
        }
    }
}
