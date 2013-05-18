using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridUnlock
{
    public class UnlockEventArg : EventArgs
    {
        public Key Key
        {
            get;
            internal set;
        }

        private bool isUnlock = true;
        public bool IsUnlock
        {
            get
            {
                return isUnlock;
            }
            set
            {
                isUnlock = value;
            }
        }
    }
}
