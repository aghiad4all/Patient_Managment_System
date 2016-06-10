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
    public partial class Form4 : Form
    {
        private SqlConnection conn8;
        private SqlConnection conn9;
        public Form4()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string fname = textBox1.Text.ToString();
            string mname = textBox2.Text.ToString();
            string lname = textBox3.Text.ToString();
            string clinic = textBox4.Text.ToString();
            string gender = textBox5.Text.ToString();
            string nationality = textBox6.Text.ToString();
            string spec = textBox7.Text.ToString();
            string phonenum = textBox8.Text.ToString();
            string email = textBox9.Text.ToString();
            string password = textBox10.Text.ToString();
            string query;
            string query2;
            string active;
            string sp = " ";
            string p = "d";
            if (fname.Equals("") || mname.Equals("") || lname.Equals("") || clinic.Equals("") || gender.Equals("") || nationality.Equals("") || spec.Equals("") || phonenum.Equals("") || email.Equals("") || password.Equals(""))
            {
                MessageBox.Show("Please fill all fields.");

            }
            
           
            else
            {
                int parsedValue;
                if (!int.TryParse(textBox8.Text, out parsedValue))
                {
                    MessageBox.Show("Phone Number must be a number");
                    textBox8.Text = "";
                    return;
                }
                if (gender.Equals("Male") && gender.Equals("Female"))
                {
                    MessageBox.Show("Gender is either 'Male' OR 'Female'.");
                    textBox5.Text = "";
                    return;
                }
                if (!email.Contains('@'))
                {
                    MessageBox.Show("Email must be of the correct form");
                    textBox9.Text = "";
                    return;
                }
                string name = fname + sp + mname + sp + lname;
                if (checkBox1.Checked.Equals(true))
                {
                    active = "yes";
                }
                else
                {
                    active = "no";
                }
                string F = fname[0].ToString();
                string M = mname[0].ToString();
                string L = lname[0].ToString();
                string l = L.ToLower();
                string f = F.ToLower();
                string m = M.ToLower();
                string username = p + f + m + l;
                string num;
                string dd;
                int count = 0;
                try
                {
                    conn9 = new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog=medicalcenter; Integrated Security=true");
                    conn9.Open();
                    query2 = "SELECT Username FROM Doctor";
                    SqlCommand cmd2 = new SqlCommand(query2, conn9);
                    SqlDataReader reader = cmd2.ExecuteReader();
                    while (reader.Read())
                    {
                        string x = reader["Username"].ToString();
                        string x1 = x[1].ToString();
                        string x2 = x[2].ToString();
                        string x3 = x[3].ToString();
                        if (f == x1)
                        {
                            if (m == x2)
                            {
                                if (l == x3)
                                {
                                    count++;
                                }
                            }
                        }
                    }

                    if (count == 0)
                    {
                        dd = "00";
                    }
                    if (count < 10)
                    {
                        string temp = count.ToString();
                        dd = "0" + temp;
                    }
                    else
                    {
                        dd = count.ToString();
                    }
                    username = username + dd;
                }
                catch (Exception ex) { MessageBox.Show("ERROR"); }
                finally
                {
                    conn9.Close();
                }
                try
                {
                    conn8 = new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog=medicalcenter; Integrated Security=true");
                    conn8.Open();
                    query = "INSERT INTO Doctor ( Name, ClinicAddress, Gender, Nationality, Specialty, PhoneNum, Email, Username, Password, Active) VALUES ('" + name + "','" + clinic + "','" + gender + "','" + nationality + "','" + spec + "','" + phonenum + "','" + email + "','" + username + "','" + password + "','" + active + "')";
                    SqlCommand cmd = new SqlCommand(query, conn8);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Doctor Added Successfully");
                }
                catch (Exception ex) { MessageBox.Show("Failed"); }
                finally
                {
                    conn8.Close();
                }
            }
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            
        }
    }
}
