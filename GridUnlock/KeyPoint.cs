using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridUnlock
{
    /// <summary>
    /// 钥齿
    /// </summary>
    public class KeyPoint : INotifyPropertyChanged
    {
        public const string CONST_PROPERTY_NAME_X = "X";
        private int x = 0;
        [DefaultValue(0), Browsable(true), Category(""), Description("")]
        public int X
        {
            get
            {
                return x;
            }
            set
            {
                if (x != value)
                {
                    x = value;
                    OnPropertyChanged(CONST_PROPERTY_NAME_X);
                }
            }
        }

        public const string CONST_PROPERTY_NAME_Y = "Y";
        [DefaultValue(0), Browsable(true), Category(""), Description("")]
        private int y = 0;
        public int Y
        {
            get
            {
                return y;
            }
            set
            {
                if (y != value)
                {
                    y = value;
                    OnPropertyChanged(CONST_PROPERTY_NAME_Y);
                }
            }
        }

        public KeyPoint(int x, int y)
        {
            this.X = x;
            this.Y = y;
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

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
