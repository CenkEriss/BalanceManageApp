using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace BalanceManageApp
{
    public partial class FormBalance : Form
    {
        SqlCommand command;
        SqlConnection connection;
        //SqlDataReader reader;
        SqlDataAdapter adapter;

        int userID = Form1.userID;
        public FormBalance()
        {
            InitializeComponent();
        }

        private void FormBalance_Load(object sender, EventArgs e)
        {
            try
            {
                connection = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=BalanceManagementDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
                command = new SqlCommand();
                connection.Open();
                command.Connection = connection;
                command.CommandText = ("SELECT UserID,CashBalance,FlightBalance,RoadTollBalance,FoodBalance,FuelBalance From BalanceTable Where UserID='" + userID + "'");
                adapter = new SqlDataAdapter(command);
                DataSet dataset = new DataSet();
                adapter.Fill(dataset);
                dataGridView1.ReadOnly = true;
                dataGridView1.DataSource = dataset;


            }

            catch (Exception exception)
            {
                MessageBox.Show("Something went wrong!", "Error");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 mainMenu = new Form2();
            this.Hide();
            mainMenu.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 loginMenu = new Form1();
            if (MessageBox.Show("Are you sure you want to logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
                loginMenu.Show();
            }
       
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormCoupon couponMenu = new FormCoupon();
            this.Hide();
            couponMenu.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                connection = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=BalanceManagementDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
                command = new SqlCommand();
                connection.Open();
                command.Connection = connection;
                command.CommandText = ("SELECT UserID,CashBalance,FlightBalance,RoadTollBalance,FoodBalance,FuelBalance From BalanceTable Where UserID='" + userID + "'");

                adapter = new SqlDataAdapter(command);
                DataSet dataset = new DataSet();

                adapter.Fill(dataset);

                dataGridView1.ReadOnly = true;
                dataGridView1.DataSource = dataset.Tables[0];


            }

            catch (Exception exception)
            {
                MessageBox.Show("Something went wrong!", "Error");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
           FormCouponCreate couponCreateMenu = new FormCouponCreate();
            couponCreateMenu.Show();
            this.Hide();
           
        }
    }
}
