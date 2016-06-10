using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.Odbc;
using System.Data.SqlClient;
namespace _430P
{
    public partial class Form2 : Form
    {
        private SqlConnection conn8;
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 FirstForm = new Form1();
            FirstForm.Show();
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Really Quit?", "Exit", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 ThirdForm = new Form3();
            ThirdForm.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 FourthForm = new Form4();
            FourthForm.Show();
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form5 FifthForm = new Form5();
            FifthForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form9 f9 = new Form9();
            f9.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form13 f13 = new Form13();
            f13.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form14 f14 = new Form14();
            f14.Show();
        }

        
    }
}
