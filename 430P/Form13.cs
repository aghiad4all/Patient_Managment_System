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
    public partial class Form13 : Form
    {
        private SqlConnection conn8;
        private SqlConnection conn9;
        private SqlConnection conn10;
        private SqlConnection conn11;
        private SqlConnection conn12;
        public Form13()
        {
            InitializeComponent();
        }

        private void Deactivate_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string username = textBox1.Text.ToString();
           
            string query;
            string query2;
            string query3;
            string query4;
            string query5;
            string active;
            if (username.Equals(""))
            {

                MessageBox.Show("Please fill all fields.");
            }
            else
            {
                string u = username[0].ToString();
                if (checkBox1.Checked.Equals(true))
                {
                    active = "yes";
                }
                else
                {
                    active = "no";
                }

                if (u.Equals("s")|| u.Equals("l") || u.Equals("a") || u.Equals("r"))
                {
                    try
                    {
                        conn8 = new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog=medicalcenter; Integrated Security=true");
                        conn8.Open();
                        query = "UPDATE Staff SET Active = '" + active + "' WHERE Username= '" + username + "'";
                        SqlCommand cmd = new SqlCommand(query, conn8);
                        SqlDataReader reader = cmd.ExecuteReader();
                        MessageBox.Show(" Done Successfully.");
                        reader.Close();
                    }
                        catch (Exception ex)
                        {MessageBox.Show("Connection to Data Source Failed."); }
                        finally
                        {
                            conn8.Close();
                        }
                }
                if (u.Equals("d"))
                {
                    try
                    {
                        conn9 = new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog=medicalcenter; Integrated Security=true");
                        conn9.Open();
                        query2 = "UPDATE Doctor SET Active = '" + active + "' WHERE Username= '" + username + "'";
                        SqlCommand cmd2 = new SqlCommand(query2, conn9);
                        SqlDataReader reader2 = cmd2.ExecuteReader();
                        MessageBox.Show(" Done Successfully.");
                        reader2.Close();
                    }
                    catch (Exception ex)
                    { MessageBox.Show("Connection to Data Source Failed."); }
                    finally
                    {
                        conn9.Close();
                    }
                }
                if (u.Equals("p"))
                {
                    try
                    {
                        conn10 = new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog=medicalcenter; Integrated Security=true");
                        conn10.Open();
                        query3 = "UPDATE Patient SET Active = '" + active + "' WHERE Username= '" + username + "'";
                        SqlCommand cmd3 = new SqlCommand(query3, conn10);
                        SqlDataReader reader3 = cmd3.ExecuteReader();
                        MessageBox.Show(" Done Successfully.");
                        reader3.Close();
                    }
                    catch (Exception ex)
                    { MessageBox.Show("Connection to Data Source Failed."); }
                    finally
                    {
                        conn10.Close();
                    }
                }
            }
        }
    }
}
