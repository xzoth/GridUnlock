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
    public partial class GridUnlockPoint : UserControl
    {
        public GridUnlockPoint()
        {
            InitializeComponent();
        }

        public KeyPoint keyPoint = new KeyPoint();
        public KeyPoint KeyPoint
        {
            get
            {
                return keyPoint;
            }
            private set
            {
                keyPoint = value;
            }
        }

    }
}
