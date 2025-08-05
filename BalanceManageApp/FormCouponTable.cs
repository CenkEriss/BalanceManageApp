using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace BalanceManageApp
{
    public partial class FormCouponTable : Form
    {

        SqlCommand command;
        SqlConnection connection;
        //SqlDataReader reader;
        SqlDataAdapter adapter;
        int userID = Form1.userID;
        public FormCouponTable()
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
            Form2 mainMenu = new Form2();
            this.Hide();
            mainMenu.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FormBalance formBalance = new FormBalance();
            this.Hide();
            formBalance.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 formLogin = new Form1();

            if (MessageBox.Show("Are you sure you want to logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
                formLogin.Show();
            }
            else;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                connection = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=BalanceManagementDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
                command = new SqlCommand();
                connection.Open();
                command.Connection = connection;
                command.CommandText = ("SELECT * From CouponTable Where UserID='" + userID + "'");

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

        private void button3_Click(object sender, EventArgs e)
        {
            PaymentForm paymentForm = new PaymentForm();
            this.Hide();
            paymentForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PaymentHistory paymentHistory = new PaymentHistory();
            this.Hide();
            paymentHistory.Show();
        }
    }
}
