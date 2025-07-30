using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace BalanceManageApp
{

    public partial class Form1 : Form
    {

        SqlCommand command;
        SqlDataReader reader;
        SqlConnection connection;


        public Form1()
        {

            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                connection = new SqlConnection("Data Source=SELIN\\SQLEXPRESS;Initial Catalog=BalanceManagementDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
                command = new SqlCommand();
                connection.Open();
                command.Connection = connection;
                command.CommandText = ("Select * From UserTable where Username='" + textBox1.Text + "' AND Password='" + textBox2.Text + " ' ");
                reader = command.ExecuteReader();

                if (reader.Read())
                {
                    userID = reader.GetInt32(reader.GetOrdinal("ID"));
                    username = textBox1.Text;

                    MessageBox.Show("Login Successful", "Congratulations");

                    Form2 Hub = new Form2();
                    Hub.Show();
                    this.Hide();
                }
                else
                    MessageBox.Show("Incorrect username or password", "Error");
            }



            catch (Exception exception)
            {
                MessageBox.Show("Something Went wrong,Shutting Down", "Error");
                this.Close();
            }




            finally
            {

                connection.Close();
            }
        }
        public static int userID;
        public static string username;
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            //if (checkBox1.Checked)
            //{
            //    textBox2.UseSystemPasswordChar = true;
            //}
            //else
            //{
            //    textBox2.UseSystemPasswordChar = false;
            //}




        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
