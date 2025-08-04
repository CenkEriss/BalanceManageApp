using Microsoft.Data.Sql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace BalanceManageApp
{
    public partial class FormCouponCreate : Form
    {
        Microsoft.Data.SqlClient.SqlCommand command;
        Microsoft.Data.SqlClient.SqlCommand command2;
        Microsoft.Data.SqlClient.SqlCommand command3;
        Microsoft.Data.SqlClient.SqlDataReader reader;
        Microsoft.Data.SqlClient.SqlConnection connection;
        Microsoft.Data.SqlClient.SqlConnection connection2;
        Microsoft.Data.SqlClient.SqlConnection connection3;
        //Microsoft.Data.SqlClient.SqlDataReader reader2;


        int userID = Form1.userID;
        //decimal cash = Form1.cashBalance;
        decimal cash=Form2.cashBalance;

        
        public FormCouponCreate()
        {
            Culture();
            InitializeComponent();
        }
        private void Culture()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;
        }
        public void FormCouponCreate_Load(object sender, EventArgs e)
        {
            
            label4.Text = cash.ToString();
            //try
            //{
            //    connection3 = new Microsoft.Data.SqlClient.SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=BalanceManagementDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
            //    command3 = new Microsoft.Data.SqlClient.SqlCommand();
            //    connection3.Open();
            //    command3.Connection = connection3;
            //    command.CommandText = ("Select CashBalance FROM BalanceTable ");
            //    reader = command.ExecuteReader();
            //    reader.Read();
            //    cash=reader.GetDecimal("a");
            //}

            //catch (Exception ee)
            //{
            //    MessageBox.Show(ee.Message);
            //}
        }
      
        public void button5_Click(object sender, EventArgs e)
        {

            try
            {
                connection = new Microsoft.Data.SqlClient.SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=BalanceManagementDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
                command = new Microsoft.Data.SqlClient.SqlCommand();
                connection.Open();
                command.Connection = connection;
               
                if (string.IsNullOrEmpty(textBox1.Text))
                {
                    MessageBox.Show("Please type an amount", "Error");
                }
                else;
                    string amountInString = textBox1.Text;

                decimal couponAmount = decimal.Parse(amountInString,CultureInfo.InvariantCulture);

                if (cash >= couponAmount)
                {
                    string characters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                    Random random = new Random();
                    int passLength = 10;
                    string CouponCode = "";

                    for (int i = 0; i < passLength; i++)
                    {
                        int index=random.Next(characters.Length);
                        CouponCode += characters[index];
                    }
                    command.CommandText = ("INSERT INTO CouponTable(UserID, Amount, ValidUntil,Used,CouponCode)VALUES('" + userID + "','" + couponAmount + "',DATEADD(YEAR, 1, GETDATE()),0,'"+CouponCode+"')");
                    command.ExecuteNonQuery();
                    connection.Close();

                    connection2 = new Microsoft.Data.SqlClient.SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=BalanceManagementDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
                    command2 = new Microsoft.Data.SqlClient.SqlCommand();
                    command2.Connection = connection2;
                    connection2.Open();
                    cash = decimal.Subtract(cash, couponAmount);

                    command2.CommandText = ("UPDATE BalanceTable Set CashBalance=" + cash + "Where UserID='" + userID + "'");
                    command2.ExecuteNonQuery();
                    label4.Text = cash.ToString();
                    MessageBox.Show("Your Coupon Has Been Created Succesfully", "Congratulations", MessageBoxButtons.OK, MessageBoxIcon.None);
                    connection2.Close();
        
                }
                




                else
                {
                    MessageBox.Show("You Have Insufficient Balance", "Error");
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
       
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            FormBalance formbalance = new FormBalance();
            formbalance.Show();
        }

     private void label1_Click(object sender, EventArgs e) 
        {
        }

    }







}

