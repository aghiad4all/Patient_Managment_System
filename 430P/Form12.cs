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
    public partial class Form12 : Form
    {
        private SqlConnection conn8;
        public Form12()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string username = textBox1.Text.ToString();
            string address = textBox2.Text.ToString();
            string phonenum = textBox3.Text.ToString();
            string email = textBox6.Text.ToString();
            string password = textBox7.Text.ToString();
            string query;
            if (username.Equals("") || address.Equals("") || phonenum.Equals("") || email.Equals("") || password.Equals(""))
            {
               
                MessageBox.Show("Please fill all fields.");
            }
            else
            {
                int parsedValue;
                if (!int.TryParse(textBox3.Text, out parsedValue))
                {
                    MessageBox.Show("Phone Number must be a number.");
                    textBox3.Text = "";
                    return;
                }
                if (!email.Contains('@'))
                {
                    MessageBox.Show("Email must be of the correct form");
                    textBox6.Text = "";
                    return;
                }
                try
                {
                    conn8 = new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog=medicalcenter; Integrated Security=true");

                    conn8.Open();
                    query = "UPDATE Doctor SET ClinicAddress= '" + address + "'" + ",PhoneNum='" + phonenum + "',Email='" + email + "',Password='" + password + "' WHERE Username= '" + username + "'";

                    SqlCommand cmd = new SqlCommand(query, conn8);

                    SqlDataReader aReader1 = cmd.ExecuteReader();
                    aReader1.Read();


                    //cmd.BeginExecuteNonQuery();

                    MessageBox.Show("Balance Sheet Updated Successfully.");
                    aReader1.Close();
                    this.Hide();

                }

                catch (Exception ex)

                { MessageBox.Show("Connection to Data Source Failed."); }
                finally
                {

                    conn8.Close();
                }
            }
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";

        }
    }
}
