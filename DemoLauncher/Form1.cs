﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoLauncher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        //Application.DoEvents();
        //    this.BeginInvoke(new MethodInvoker(delegate
        //    {
        //        label1.Text = gridUnlockPoint1.IsOn.ToString();
        //    }
        //    ));
    }
}
