﻿using Air.WeifenLuo.WinFormsUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirCodeGeneration
{
    public partial class Form1 : Form
    {
        private ToolWindow m_toolbox;
        public Form1()
        {
            InitializeComponent();
            AutoScaleMode = AutoScaleMode.Dpi;
           
        }
        private void CreateStandardControls()
        {
            m_toolbox = new ToolWindow();
            this.dpleft.Controls.Add(m_toolbox);
            m_toolbox.Show(dpleft, new Rectangle(98, 133, 200, 383));
        }

    }
}
