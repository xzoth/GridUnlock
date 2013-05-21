using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GridUnlock.Common;

namespace GridUnlock
{
    /// <summary>
    /// 九宫格解锁控件
    /// </summary>
    public class GridUnlock : UserControl, INotifyPropertyChanged
    {
        [Browsable(false)]
        public Key Key
        {
            get
            {
                return GridUnlockPointList.ToKey();
            }
        }

        private void DoUnlock()
        {
        }

        public bool Unlock(Key key)
        {
            UnlockEventArg e = new UnlockEventArg();
            e.Key = key;

            unlockEventHandler(e);

            if (e.IsUnlock)
            {
                DoUnlock();
            }

            return e.IsUnlock;
        }

        public GridUnlock()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.UserPaint,
                          true);
            
            DoInitLayout();
            this.PropertyChanged += GridUnlock_PropertyChanged;
        }

        private void DoInitLayout()
        {
            this.Controls.Clear();
            this.GridUnlockPointList.Clear();

            //获得循环因子
            int cycleFactor = (int)Math.Sqrt(Convert.ToDouble(GridUnlockStyle));

            for (int x = 1; x <= cycleFactor; x++)
            {
                for (int y = 1; y <= cycleFactor; y++)
                {
                    KeyPoint keyPoint = new KeyPoint(x, y);

                    GridUnlockPoint gridUnlockPoint = new GridUnlockPoint(keyPoint);
                    gridUnlockPoint.BackColor = this.BackColor;
                    gridUnlockPoint.PropertyChanged += gridUnlockPoint_PropertyChanged;

                    //计算坐标


                    this.Controls.Add(gridUnlockPoint);
                }
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (GridUnlockPointList.Count < MinKeyPoint)
            {
                foreach (var item in GridUnlockPointList)
                {
                    item.IsOn = false;
                }
            }
            else
            {
                //触发解锁事件
                Key key = GridUnlockPointList.ToKey();
                Unlock(key);
            }

            base.OnMouseUp(e);
        }

        private Point CurrMouseLocation = new Point();
        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (e.Button != System.Windows.Forms.MouseButtons.None)
            {
                Application.DoEvents();
                CurrMouseLocation = e.Location;
                this.Refresh();
            }

            base.OnMouseMove(e);
        }

        /// <summary>
        /// 获取或者设置触发解锁行为的最小链接点数量
        /// </summary>
        private int minKeyPoint = 4;
        /// <summary>
        /// 获取或者设置触发解锁行为的最小链接点数量
        /// </summary>
        [Browsable(true), Category("行为"), Description("获取或者设置触发解锁行为的最小链接点数量"), DefaultValue(4)]
        public int MinKeyPoint
        {
            get
            {
                return minKeyPoint;
            }
            set
            {
                if (value < 4)
                {
                    throw new ArgumentOutOfRangeException("最小链接点数量不能小于4");
                }

                minKeyPoint = value;
            }
        }

        private readonly object eventLock = new object();

        private OnUnlockEventDelegate unlockEventHandler;
        public event OnUnlockEventDelegate OnUnlock
        {
            add
            {
                lock (eventLock)
                {
                    unlockEventHandler += value;
                }
            }
            remove
            {
                lock (eventLock)
                {
                    unlockEventHandler -= value;
                }
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // GridUnlock
            // 
            this.Name = "GridUnlock";
            this.Size = new System.Drawing.Size(380, 250);
            this.ResumeLayout(false);
        }

        void GridUnlock_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == CONST_PROPERTY_NAME_GRIDUNLOCKSTYLE)
            {
                //重绘
                DoInitLayout();
                this.Refresh();
            }
        }

        protected override bool DoubleBuffered
        {
            get
            {
                return true;
            }
        }

        public const string CONST_PROPERTY_NAME_GRIDUNLOCKSTYLE = "GridUnlockStyle";
        private GridUnlockStyle gridUnlockStyle = GridUnlockStyle.NineKeyPoint;
        [Description("")]
        [Category("外观")]
        [Browsable(true)]
        [DefaultValue(GridUnlockStyle.NineKeyPoint)]
        public GridUnlockStyle GridUnlockStyle
        {
            get
            {
                return gridUnlockStyle;
            }
            set
            {
                if (gridUnlockStyle != value)
                {
                    gridUnlockStyle = value;
                    OnPropertyChanged(CONST_PROPERTY_NAME_GRIDUNLOCKSTYLE);
                }
            }
        }

        protected GridUnlockPointCollection GridUnlockPointList = new GridUnlockPointCollection();

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            base.OnPaintBackground(e);

            Graphics g = e.Graphics;
            //抗锯齿
            g.SmoothingMode = SmoothingMode.AntiAlias;

            g.Clear(this.BackColor);

            //TODO: 根据GridUnlockStyle进行界面绘制
            foreach (var item in GridUnlockPointList)
            {
                //g.DrawLine(Pens.GreenYellow, item.
            }

            g.DrawLine(Pens.GreenYellow, new Point(0, 0), CurrMouseLocation);
        }

        void gridUnlockPoint_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == GridUnlockPoint.CONST_PROPERTY_NAME_ISON)
            {
                var item = sender as GridUnlockPoint;
                if (item.IsOn)
                {
                    this.GridUnlockPointList.Add(item);
                }
                else
                {
                    this.GridUnlockPointList.Remove(item);
                }
            }
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

    public enum GridUnlockStyle : int
    {
        NineKeyPoint = 9,
        SixteenKeyPoint = 16
    }

    public delegate void OnUnlockEventDelegate(UnlockEventArg e);
}
