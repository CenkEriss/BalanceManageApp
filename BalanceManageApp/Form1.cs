using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Globalization;
using System.Linq;
using System.Reflection.Emit;
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
            Culture();
            InitializeComponent();
            
        }

        private void Culture()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                connection = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=BalanceManagementDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
                command = new SqlCommand();
                connection.Open();
                command.Connection = connection;
                command.CommandText = (" Select UserTable.ID,UserTable.Username,UserTable.Password,BalanceTable.CashBalance FROM UserTable INNER JOIN BalanceTable ON(UserTable.ID=BalanceTable.UserID) Where UserTable.Username COLLATE SQL_Latin1_General_CP1_CS_AS='"+textBox1.Text+"' AND  UserTable.Password Collate SQL_Latin1_General_CP1_CS_AS='"+textBox2.Text+"'");

              

                reader = command.ExecuteReader();

                if (reader.Read() )
                {
                    userID = reader.GetInt32(reader.GetOrdinal("ID"));
                    username = reader.GetString(reader.GetOrdinal("Username"));
                    password = reader.GetString(reader.GetOrdinal("Password"));
                    cashBalance = reader.GetDecimal(reader.GetOrdinal("CashBalance"));
                    MessageBox.Show("Login Successful", "Congratulations");
                    

                    this.Hide();
                    Form2 Hub=new Form2();
                    Hub.Show();
                    Hub.FormClosed += (s, args) => this.Close();
                    
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
        public static string password;
        public static int userID;
        public static string username;
        public static decimal cashBalance;
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
   
        }
    }
}
