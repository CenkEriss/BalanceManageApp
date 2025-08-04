using Azure.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using System;
using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel;
using System.Data;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing;
using System.Drawing.Text;
using System.Globalization;
using System.Linq;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BalanceManageApp
{
    public partial class Form2 : Form
    {
        Microsoft.Data.SqlClient.SqlCommand command;
        Microsoft.Data.SqlClient.SqlDataReader reader;
        Microsoft.Data.SqlClient.SqlConnection connection;

        int userID = Form1.userID;

        public void displayUsername()
        {
            string loggedUser = Form1.username;
            label13.Text = loggedUser;
        }


        public Form2()
        {
            Culture();
            InitializeComponent();
            displayUsername();
            

        }
        private void Culture()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            try
            {
                connection = new Microsoft.Data.SqlClient.SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=BalanceManagementDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
                command = new Microsoft.Data.SqlClient.SqlCommand();
                connection.Open();
                command.Connection = connection;
                command.CommandText = ("Select * From BalanceTable where UserID='" + userID + "'");
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    decimal cashBalance = reader.GetDecimal(reader.GetOrdinal("CashBalance"));
                    label3.Text = cashBalance.ToString();
                    Form2.cashBalance = cashBalance;
                    decimal fuelBalance = reader.GetDecimal(reader.GetOrdinal("FuelBalance"));
                    label4.Text = fuelBalance.ToString();
                    decimal flightBalance = reader.GetDecimal(reader.GetOrdinal("FlightBalance"));
                    label6.Text = flightBalance.ToString();
                    decimal roadBalance = reader.GetDecimal(reader.GetOrdinal("RoadTollBalance"));
                    label8.Text = roadBalance.ToString();
                    decimal foodBalance = reader.GetDecimal(reader.GetOrdinal("FoodBalance"));
                    label10.Text = foodBalance.ToString();

                }


            }

            catch (Exception ex)
            {
                MessageBox.Show("Something Unexpected Happened" + ex);
            }
            finally
            {

                connection.Close();
            }
        }
        public static decimal foodBalance;
        public static decimal cashBalance;


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            // textBox1.Text = 
        }
        private void button2_Click(object sender, EventArgs e)
        {
            FormBalance formBalance = new FormBalance();
            this.Hide();
            formBalance.Show();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form1 formLogin = new Form1();

            if (MessageBox.Show("Are you sure you want to logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
                formLogin.Show();
            }
            else;

        }

        private void button3_Click(object sender, EventArgs e)
        {


            FormCouponTable formCoupon = new FormCouponTable();
            this.Hide();

            formCoupon.Show();

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void button5_Click(object sender, EventArgs e)
        {
            PaymentForm paymentForm = new PaymentForm();
            this.Hide();
            paymentForm.Show();
        }
    }
}
