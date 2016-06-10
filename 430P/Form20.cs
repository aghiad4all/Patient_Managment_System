using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace _430P
{
    public partial class Form20 : Form
    {
        private SqlConnection conn8;
        private SqlConnection conn9;
        private SqlConnection conn10;

        public Form20()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((checkBox1.Checked.Equals(true) && checkBox2.Checked.Equals(true)) || (checkBox1.Checked.Equals(true) && checkBox3.Checked.Equals(true)) || (checkBox2.Checked.Equals(true) && checkBox3.Checked.Equals(true)) || (checkBox1.Checked.Equals(true) && checkBox2.Checked.Equals(true) && checkBox3.Checked.Equals(true)) || (checkBox1.Checked.Equals(false) && checkBox2.Checked.Equals(false) && checkBox3.Checked.Equals(false)))
            {
                MessageBox.Show("Please Select One option ONLY!!");

            }
            else
            {
                string query;
                string query2;
                string query3;
                if (checkBox1.Checked.Equals(true))
                {
                    try
                    {
                        conn8 = new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog=medicalcenter; Integrated Security=true");
                        conn8.Open();
                        query = "SELECT * FROM Staff ";
                        DataTable St = new DataTable();
                        SqlDataAdapter adapter = new SqlDataAdapter(query, conn8);
                        adapter.Fill(St);
                        dataGridView1.DataSource = St;

                    }
                    catch (Exception ex) { MessageBox.Show("Failed"); }
                    finally
                    {
                        conn8.Close();
                    }
                }
                if (checkBox2.Checked.Equals(true))
                {
                    try
                    {
                        conn9 = new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog=medicalcenter; Integrated Security=true");
                        conn9.Open();
                        query2 = "SELECT * FROM Doctor ";
                        DataTable St2 = new DataTable();
                        SqlDataAdapter adapter2 = new SqlDataAdapter(query2, conn9);
                        adapter2.Fill(St2);
                        dataGridView1.DataSource = St2;

                    }
                    catch (Exception ex) { MessageBox.Show("Failed"); }
                    finally
                    {
                        conn9.Close();
                    }

                }
                if (checkBox3.Checked.Equals(true))
                {
                    try
                    {
                        conn10 = new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog=medicalcenter; Integrated Security=true");
                        conn10.Open();
                        query3 = "SELECT * FROM Patient ";
                        DataTable St3 = new DataTable();
                        SqlDataAdapter adapter3 = new SqlDataAdapter(query3, conn10);
                        adapter3.Fill(St3);
                        dataGridView1.DataSource = St3;

                    }
                    catch (Exception ex) { MessageBox.Show("Failed"); }
                    finally
                    {
                        conn10.Close();
                    }

                }
            }
        }
    }
}
