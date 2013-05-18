using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GridUnlock
{
    /// <summary>
    /// 九宫格解锁控件
    /// </summary>
    public class GridUnlock : UserControl, INotifyPropertyChanged
    {
        private Key key = new Key();
        public Key Key
        {
            get
            {
                return key;
            }
            private set
            {
                key = value;
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
        }

        public const int MinKeyPoint = 4;

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
            this.Load += new System.EventHandler(this.GridUnlock_Load);
            this.ResumeLayout(false);
        }

        private void GridUnlock_Load(object sender, EventArgs e)
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.OptimizedDoubleBuffer,
                          true);

            this.PropertyChanged += GridUnlock_PropertyChanged;
        }

        void GridUnlock_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {

            if (e.PropertyName == CONST_PROPERTY_NAME_GRIDUNLOCKSTYLE)
            {
                //重绘
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
                gridUnlockStyle = value;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            base.OnPaintBackground(e);

            Graphics g = e.Graphics;
            //抗锯齿
            g.SmoothingMode = SmoothingMode.AntiAlias;


            //TODO: 根据GridUnlockStyle进行界面绘制

            g.Clear(this.BackColor);

            Brush brush = new SolidBrush(Color.Green);
            int penWidth = 2;
            Pen pen = new Pen(brush, penWidth);


            Point p1 = new Point(0, 0);

            Point p2 = p2 = new Point(2200, 2200);

            if (GridUnlockStyle == GridUnlockStyle.SixteenKeyPoint)
            {
                p2 = new Point(300, 120);
            }

            g.DrawLine(pen, p1, p2);
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
