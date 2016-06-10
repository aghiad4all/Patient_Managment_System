using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _430P
{
    public partial class Form16 : Form
    {
        public Form16()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form17 f17 = new Form17();
            f17.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form18 f18 = new Form18();
            f18.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form19 f19 = new Form19();
            f19.Show();
        }
    }
}
