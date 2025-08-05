using Microsoft.Data.Sql;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BalanceManageApp
{
    public partial class PaymentForm : Form
    {
        Microsoft.Data.SqlClient.SqlCommand command;
        Microsoft.Data.SqlClient.SqlDataReader reader;
        Microsoft.Data.SqlClient.SqlConnection connection;
        Microsoft.Data.SqlClient.SqlCommand command2;
        Microsoft.Data.SqlClient.SqlConnection connection2;
        Microsoft.Data.SqlClient.SqlCommand command3;
        Microsoft.Data.SqlClient.SqlConnection connection3;
        Microsoft.Data.SqlClient.SqlCommand command4;
        Microsoft.Data.SqlClient.SqlConnection connection4;
        Microsoft.Data.SqlClient.SqlCommand command5;
        Microsoft.Data.SqlClient.SqlConnection connection5;
        Microsoft.Data.SqlClient.SqlCommand command6;
        Microsoft.Data.SqlClient.SqlConnection connection6;

        int userID = Form1.userID;
        decimal cashBalance = Form2.cashBalance;
        decimal loanAmount;
        decimal newCash;






        public PaymentForm()
        {
            Culture();
            InitializeComponent();

        }

        private void Culture()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;
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

        private void PaymentForm_Load(object sender, EventArgs e)
        {

        }
        public static string CreditCardNo;
        public static string amountInString;
        public static string CVV;
        public static decimal paymentAmount;
        public static decimal specifiedBalance;

        public string CreditCardCrypt(string CardNo)
        {

            string newCardNo = "";
            for (int i = 0; i < CardNo.Length; i++)
            {
                if (i > 5 && i <= 11)
                {
                    newCardNo += "*";
                }
                else { newCardNo += CardNo[i]; }
            }

            return newCardNo;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                connection = new Microsoft.Data.SqlClient.SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=BalanceManagementDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
                command = new Microsoft.Data.SqlClient.SqlCommand();
                connection.Open();
                command.Connection = connection;


                if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(comboBox2.Text) || string.IsNullOrEmpty(textBox7.Text) || string.IsNullOrEmpty(comboBox1.Text) || string.IsNullOrEmpty(comboBox3.Text))
                {
                    MessageBox.Show("Please Enter All The Required Information", "Error");
                }

                else
                {
                    amountInString = textBox7.Text;
                    CreditCardNo = textBox1.Text;
                    CVV = textBox2.Text;
                    paymentAmount = decimal.Parse(amountInString, CultureInfo.InvariantCulture);
                    command.CommandText = ("Select  " + comboBox1.Text + " From BalanceTable Where UserID='" + userID + "'");
                    reader = command.ExecuteReader();

                }

                if (IsValidCreditCard(CreditCardNo) && CVV.Equals("000") && reader.Read())
                {

                    string maskedCard = CreditCardCrypt(CreditCardNo);
                    decimal specifiedBalance = Convert.ToDecimal(reader[0]);
                    connection.Close();
                    connection2 = new Microsoft.Data.SqlClient.SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=BalanceManagementDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
                    command2 = new Microsoft.Data.SqlClient.SqlCommand();
                    command2.Connection = connection2;
                    connection2.Open();
                    Decimal newCash = decimal.Add(specifiedBalance, paymentAmount);
                    command2.CommandText = ("Update BalanceTable Set " + comboBox1.Text + " = " + newCash + " Where UserID='" + userID + "'");
                    command2.ExecuteNonQuery();
                    connection2.Close();
                    connection6 = new Microsoft.Data.SqlClient.SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=BalanceManagementDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
                    command6 = new Microsoft.Data.SqlClient.SqlCommand();
                    command6.Connection = connection6;
                    connection6.Open();
                    command6.CommandText = ("Insert Into PaymentTable (UserID,Amount,BoughtBalance,PaymentType,CreditCardNo) Values('" + userID + "','" + amountInString + "','" + comboBox1.Text + "','CreditCard','" + maskedCard + "')");
                    command6.ExecuteNonQuery();
                    connection6.Close();
                    MessageBox.Show("Your Payment Is Succesfull");
                }
                else
                {
                    MessageBox.Show("Incorrect Card Info, Please Check Again", "Error");
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
        public static bool IsValidCreditCard(string cc)
        {
            var attr = new CreditCardAttribute();
            return attr.IsValid(cc);
        }
        private void button6_Click(object sender, EventArgs e)
        {
            try
            {

                connection3 = new Microsoft.Data.SqlClient.SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=BalanceManagementDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
                command3 = new Microsoft.Data.SqlClient.SqlCommand();
                command3.Connection = connection3;
                connection3.Open();

                if (string.IsNullOrEmpty(textBox4.Text) || string.IsNullOrEmpty(textBox5.Text) || string.IsNullOrEmpty(textBox6.Text) || string.IsNullOrEmpty(comboBox1.Text))
                {
                    MessageBox.Show("Please Enter All The Required Information", "Error");
                }
                else
                {
                    command3.CommandText = ("Select  " + comboBox1.Text + " From BalanceTable Where UserID='" + userID + "'");
                    reader = command3.ExecuteReader();
                    reader.Read();
                    decimal specifiedBalance = Convert.ToDecimal(reader[0]);
                    string loanAmountInString = textBox6.Text;
                    loanAmount = decimal.Parse(loanAmountInString);
                    connection3.Close();
                    newCash = decimal.Add(loanAmount, specifiedBalance);
                }


                if (loanAmount < 10000)
                {
                    connection3.Close();
                    connection4 = new Microsoft.Data.SqlClient.SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=BalanceManagementDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
                    command4 = new Microsoft.Data.SqlClient.SqlCommand();
                    connection4.Open();
                    command4.Connection = connection4;
                    command4.CommandText = ("Update BalanceTable Set " + comboBox1.Text + " = " + newCash + " Where UserID='" + userID + "'");
                    command4.ExecuteNonQuery();
                    connection4.Close();
                    connection5 = new Microsoft.Data.SqlClient.SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=BalanceManagementDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
                    command5 = new Microsoft.Data.SqlClient.SqlCommand();
                    connection5.Open();
                    command5.Connection = connection5;
                    command5.CommandText = ("Insert Into PaymentTable (UserID,Amount,BoughtBalance,PaymentType,Bank) Values('" + userID + "','" + loanAmount + "','" + comboBox1.Text + "','Loan','" + comboBox4.Text + "')");
                    command5.ExecuteNonQuery();
                    connection5.Close();

                    MessageBox.Show("Your Payment Is Succesfull");

                }

                else { MessageBox.Show("You are not aligible for a loan of that amount.", "Error"); }
            }
            catch (Exception exc)
            { MessageBox.Show(exc.Message); }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 hub = new Form2();
            this.Hide();
            hub.Show();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            FormBalance formBalance = new FormBalance();
            this.Hide();
            formBalance.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormCouponTable formCoupon = new FormCouponTable();
            this.Hide();

            formCoupon.Show();
        }
        private void button8_Click(object sender, EventArgs e)
        {
            PaymentHistory paymentHistory = new PaymentHistory();
            this.Hide();
            paymentHistory.Show();
        }
    }
}

