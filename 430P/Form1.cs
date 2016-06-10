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
    public partial class Form1 : Form
    {
        private SqlConnection conn8;
        private SqlConnection conn9;
        private SqlConnection conn10;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string fname = textBox1.Text.ToString();
            string mname = textBox2.Text.ToString();
            string lname = textBox3.Text.ToString();
            string phonenum = textBox11.Text.ToString();
            string address = textBox5.Text.ToString();
            string position = textBox10.Text.ToString();
            string salary = textBox7.Text.ToString();
            string gender = textBox6.Text.ToString();
            string birthdate = textBox4.Text.ToString();
            string username = textBox10.Text.ToString();
            string password = textBox13.Text.ToString();
            string email = textBox9.Text.ToString();
            string nationality = textBox8.Text.ToString();
            string remarks = textBox12.Text.ToString();
            string level = textBox14.Text.ToString();
            string query;
            string query2;
            string active;
            string sp = " ";
            string p = "s";
            if (fname.Equals("") || mname.Equals("") || lname.Equals("") || phonenum.Equals("") || address.Equals("") || position.Equals("") || salary.Equals("") || gender.Equals("") || birthdate.Equals("") || password.Equals("") || email.Equals("") || nationality.Equals("") || remarks.Equals("") || level.Equals(""))
            {
                MessageBox.Show("Please fill all fields.");

            }
            
            else
            {
                if ((level!="1") && (level!="2"))
                {
                    MessageBox.Show("Level must be 1 OR 2.");
                    textBox14.Text = "";
                    return;
                }

                string b1 = birthdate[2].ToString(); ;
                string b2 = birthdate[5].ToString();
                if (!b1.Equals("/") && !b2.Equals("/"))
                {
                    MessageBox.Show("Birth Date must be of --/--/----.");
                    textBox4.Text = "";
                    return;
                }
                int parsedValue;
                if (!int.TryParse(textBox11.Text, out parsedValue))
                {
                    MessageBox.Show("Phone Number must be a number");
                    textBox11.Text = "";
                    return;
                }
                int parsedValue2;
                if (!int.TryParse(textBox7.Text, out parsedValue2))
                {
                    MessageBox.Show("Salary must be a digit in $");
                    textBox7.Text = "";
                    return;
                }
                if(!email.Contains('@')){
                    MessageBox.Show("Email must be of the correct form");
                    textBox9.Text = "";
                    return;
                }
                if (gender.Equals("Male") && gender.Equals("Female"))
                {
                    MessageBox.Show("Gender is either 'Male' OR 'Female'.");
                    textBox6.Text = "";
                    return;
                }
                if (!position[0].ToString().Equals("s") && !position[0].ToString().Equals("a") && !position[0].ToString().Equals("l"))
                {
                    MessageBox.Show("Type 's' For Staff, Type 'a' For Accountant, Type 'l' For lab.");
                    textBox10.Text = "";
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
                string pos = position[0].ToString();
                username = pos + f + m + l;
                string num;
                string dd;
                int count = 0;
                try
                {
                    conn9 = new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog=medicalcenter; Integrated Security=true");
                    conn9.Open();
                    query2 = "SELECT Username FROM Staff";
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
                    query = "INSERT INTO Staff ( Name, Address, BirthDate, Gender, Phonenum, Position, Salary, Email, Nationality, Remarks, Username, Password, Active, Level) VALUES ('" + name + "','" + address + "','" + birthdate + "','" + gender + "','" + phonenum + "','" + position + "','" + salary + "','" + email + "','" + nationality + "','" + remarks + "','" + username + "','" + password + "','" + active + "','" + level + "')";
                    SqlCommand cmd = new SqlCommand(query, conn8);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Added Successfully.");

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
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

       

        
    
       

    }
}
