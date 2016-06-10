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
    public partial class Form3 : Form
    {
        private SqlConnection conn8;
        private SqlConnection conn9;
        private SqlConnection conn10;
        public Form3()
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
            string birthdate = textBox4.Text.ToString();
            string address = textBox5.Text.ToString();
            string gender = textBox6.Text.ToString();
            string marital = textBox7.Text.ToString();
            string nationality = textBox8.Text.ToString();
            string phonenum = textBox9.Text.ToString();
            string email = textBox10.Text.ToString();
            string enumb = textBox11.Text.ToString();
            string blood = textBox12.Text.ToString();
            string password = textBox13.Text.ToString();
            string doctor = textBox14.Text.ToString();
            string query;
            string query2;
            string query3;
            string active;
            bool nodoc = false;
            string sp = " ";
            string p = "p";
            if (fname.Equals("") || mname.Equals("") || lname.Equals("") || birthdate.Equals("") || address.Equals("") || gender.Equals("") || marital.Equals("") || nationality.Equals("") || phonenum.Equals("") || email.Equals("") || blood.Equals("") || enumb.Equals("") || password.Equals("") || doctor.Equals(""))
            {
                MessageBox.Show("Please fill all fields.");

            }
            
            else
            {
                string b1 = birthdate[2].ToString(); ;
                string b2 = birthdate[5].ToString();
                if (b1.Equals("/") && b2.Equals("/"))
                {
                    MessageBox.Show("Birth Date must be of --/--/----.");
                    textBox4.Text = "";
                    return;
                }
                if (!email.Contains('@'))
                {
                    MessageBox.Show("Email must be of the correct form");
                    textBox10.Text = "";
                    return;
                }
                if (gender.Equals("Male") && gender.Equals("Female"))
                {
                    MessageBox.Show("Gender is either 'Male' OR 'Female'.");
                    textBox6.Text = "";
                    return;
                }
                int parsedValue;
                if (!int.TryParse(textBox9.Text, out parsedValue))
                {
                    MessageBox.Show("Phone Number must be a number");
                    textBox9.Text = "";
                    return;
                }
                int parsedValue2;
                if (!int.TryParse(textBox11.Text, out parsedValue2))
                {
                    MessageBox.Show("Emergency Phone Number must be a number.");
                    textBox11.Text = "";
                    return;
                }
                if (!blood.Equals("A+") && !blood.Equals("A-") && !blood.Equals("B+") && !blood.Equals("B-") && !blood.Equals("O+") && !blood.Equals("O-") && !blood.Equals("A+") && !blood.Equals("AB+") && !blood.Equals("AB-"))
                {
                    MessageBox.Show("Please Enter A correct Blood Type.");
                    textBox12.Text = "";
                    return;
                }
                try
                {
                    conn10 = new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog=medicalcenter; Integrated Security=true");
                    conn10.Open();
                    query3 = "SELECT Username FROM Doctor";
                    SqlCommand cmd3 = new SqlCommand(query3, conn10);
                    SqlDataReader reader3 = cmd3.ExecuteReader();
                    while (reader3.Read())
                    {
                        string x = reader3["Username"].ToString();
                        if (x.Equals(doctor))
                        {
                            nodoc = true;
                        }
                    }
                    if (nodoc.Equals(false))
                    {
                        MessageBox.Show("No Doctor with this Username was found.");
                        textBox14.Text = "";
                        return;
                    }

                }
                catch (Exception ex) { MessageBox.Show("saddddd"); }
                finally
                {
                    conn10.Close();
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
                    query2 = "SELECT Username FROM Patient";
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
                catch (Exception ex) { MessageBox.Show("Failed"); }
                finally
                {
                    conn9.Close();
                }

                try
                {
                    conn8 = new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog=medicalcenter; Integrated Security=true");
                    conn8.Open();
                    query = "INSERT INTO Patient ( Name, BirthDate, Address, Gender, Marital, Nationality, PhoneNum, Email, EmergencyNum, BloodType, Username, Password, Active, Doctor) VALUES ('" + name + "','" + birthdate + "','" + address + "','" + gender + "','" + marital + "','" + nationality + "','" + phonenum + "','" + email + "','" + enumb + "','" + blood + "','" + username + "','" + password + "','" + active + "','" + doctor + "')";
                    SqlCommand cmd = new SqlCommand(query, conn8);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Patient Added Successfully");
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
            textBox11.Text = "";
            textBox12.Text = "";
            textBox13.Text = "";
            textBox14.Text = "";
            
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
       
    }
}
