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
    public partial class Form8 : Form
    {
        private SqlConnection conn8;
        private SqlConnection conn9;
        private SqlConnection conn10;
        private SqlConnection conn11;
        
        public Form8()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if ((checkBox1.Checked.Equals(true) && checkBox2.Checked.Equals(true)) || (checkBox1.Checked.Equals(true) && checkBox3.Checked.Equals(true)) || (checkBox1.Checked.Equals(true) && checkBox4.Checked.Equals(true)) || (checkBox2.Checked.Equals(true) && checkBox3.Checked.Equals(true)) || (checkBox2.Checked.Equals(true) && checkBox4.Checked.Equals(true)) || (checkBox3.Checked.Equals(true) && checkBox4.Checked.Equals(true)))
            {
                MessageBox.Show("Please Select One option ONLY!!");
            }
            else
            {
                if (textBox1.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Empty TextBox, Please input a value!!");
                }
                //int outputValue = 0;
                //bool isNumber = false;

                //isNumber = int.TryParse(textBox1.Text, out outputValue);
                //if (!isNumber)
                //    MessageBox.Show("Empty TextBox, Please input a value");
                //else
                //    MessageBox.Show("TextBox6 not empty" + outputValue.ToString());

                //bool usernamer = radioButton1.Checked;
                //bool genderr = radioButton2.Checked;
                // bool bloodr = radioButton3.Checked;
                //bool natr = radioButton4.Checked;
                string query;
                string query2;
                string query3;
                string query4;

                if (checkBox1.Checked.Equals(true))
                {
                    try
                    {
                        conn8 = new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog=medicalcenter; Integrated Security=true");
                        conn8.Open();

                        string name = textBox1.Text.ToString();
                        string name2;
                        name2 = name;
                        query = "SELECT * FROM Doctor WHERE Username = '" + name + "'";
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

                        string name = textBox1.Text.ToString();

                        query2 = "SELECT * FROM Doctor WHERE Gender = '" + name + "'";
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

                        string name = textBox1.Text.ToString();

                        query3 = "SELECT * FROM Doctor WHERE Specialty = '" + name + "'";
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
                if (checkBox4.Checked.Equals(true))
                {
                    try
                    {
                        conn11 = new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog=medicalcenter; Integrated Security=true");
                        conn11.Open();

                        string name = textBox1.Text.ToString();

                        query4 = "SELECT * FROM Doctor WHERE Nationality = '" + name + "'";
                        DataTable St4 = new DataTable();
                        SqlDataAdapter adapter4 = new SqlDataAdapter(query4, conn11);
                        adapter4.Fill(St4);
                        dataGridView1.DataSource = St4;

                    }
                    catch (Exception ex) { MessageBox.Show("Failed"); }
                    finally
                    {
                        conn11.Close();
                    }
                }
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
