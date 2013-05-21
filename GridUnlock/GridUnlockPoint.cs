using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GridUnlock
{
    public partial class GridUnlockPoint : UserControl, INotifyPropertyChanged
    {
        //public GridUnlockPoint() { }

        public GridUnlockPoint(KeyPoint keyPoint)
        {
            this.KeyPoint = keyPoint;
        }

        public KeyPoint KeyPoint
        {
            get;
            protected set;
        }

        public bool IsEnter(Point point)
        {
            return point.X >= this.Left && point.X <= (this.Left + this.Width) &&
                   point.Y >= this.Top && point.Y <= (this.Top + this.Height);
        }

        private Size size = new Size(12, 12);
        public new Size Size
        {
            get
            {
                return size;
            }
            internal set
            {
                size = value;
            }
        }

        public Point Center
        {
            get
            {
                //计算中心点坐标
                Point center = new Point();

                //中心点X = 左上角X + 宽度/2
                //中心点Y = 左上角Y + 高度/2
                center.X = this.Left + this.Size.Width / 2;
                center.Y = this.Top + this.size.Height / 2;

                return center;
            }
        }

        public const string CONST_PROPERTY_NAME_ISON = "IsOn";
        private bool isOn = false;
        public bool IsOn
        {
            get
            {
                return isOn;
            }
            internal set
            {
                if (isOn != value)
                {
                    isOn = value;
                    OnPropertyChanged(CONST_PROPERTY_NAME_ISON);
                }
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            this.IsOn = e.Button != MouseButtons.None;

            base.OnMouseMove(e);
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
