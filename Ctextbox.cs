﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IlvlCalc
{
    public partial class Ctextbox : TextBox
    {
        public Ctextbox()
        {
            InitializeComponent();
            SetStyle(ControlStyles.SupportsTransparentBackColor |
         ControlStyles.OptimizedDoubleBuffer |
         ControlStyles.AllPaintingInWmPaint |
         ControlStyles.ResizeRedraw |
         ControlStyles.UserPaint, true);
            BackColor = Color.Transparent;
        }
    }
}
