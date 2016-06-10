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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form6 sixthForm = new Form6();
            sixthForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form7 seventhForm = new Form7();
            seventhForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form8 eiForm = new Form8();
            eiForm.Show();
        }
    }
}
