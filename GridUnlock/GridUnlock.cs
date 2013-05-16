using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GridUnlock
{
    /// <summary>
    /// 九宫格解锁控件
    /// </summary>
    public class GridUnlock : UserControl
    {
        public bool Unlock(Key key)
        {
            UnlockEventArg e = new UnlockEventArg();
            e.Key = key;

            unlockEventHandler(e);

            if (e.IsUnlock)
            {
                //TODO: do unlock
            }
            else
            {
                //TODO: 
            }

            return e.IsUnlock;
        }

        public void Lock()
        {

        }

        public GridUnlock()
        {
        }

        public GridUnlock(bool isLock)
        {
        }

        public bool IsLock
        {
            get;
            set;
        }

        public const int MinKeyPoint = 4;

        private readonly object eventLock = new object();

        private GridUnlockState state = GridUnlockState.Locked;
        public GridUnlockState State
        {
            get
            {
                return state;
            }
            private set
            {
            }
        }

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
            this.Size = new System.Drawing.Size(677, 475);
            this.ResumeLayout(false);

        }
    }

    public class UnlockEventArg : EventArgs
    {
        public Key Key
        {
            get;
            internal set;
        }

        public bool IsUnlock
        {
            get;
            set;
        }
    }

    public enum GridUnlockState
    {
        Unlock, Locked
    }

    public delegate void OnUnlockEventDelegate(UnlockEventArg e);
}
