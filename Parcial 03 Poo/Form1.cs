﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parcial_03_Poo
{
    public partial class Form1 : Form
    {
        private UserControl current = null;
        public Form1()
        {
            InitializeComponent();
            current = login1;
        }
    }
}