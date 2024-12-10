﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            toolStripComboBox1.Items.Add("Test 1");
            toolStripComboBox1.Items.Add("Test 2");
            toolStripComboBox1.Items.Add("Test 3");

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem obj = (ToolStripMenuItem)sender;
            MessageBox.Show(obj.Text);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem obj = (ToolStripMenuItem)sender;
            MessageBox.Show(obj.Text);
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem obj = (ToolStripMenuItem)sender;
            MessageBox.Show(obj.Text);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem obj = (ToolStripMenuItem)sender;
            MessageBox.Show(obj.Text);
            this.Close();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem obj = (ToolStripMenuItem)sender;
            MessageBox.Show(obj.Text);
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void toolStripComboBox1_DropDownClosed(object sender, EventArgs e)
        {
            MessageBox.Show(toolStripComboBox1.SelectedItem.ToString());
        }
    }
}
