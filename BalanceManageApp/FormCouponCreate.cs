using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.Sql;


namespace BalanceManageApp
{
    public partial class FormCouponCreate : Form
    {
        Microsoft.Data.SqlClient.SqlCommand command;
        Microsoft.Data.SqlClient.SqlCommand command2;
        Microsoft.Data.SqlClient.SqlCommand command3;
        Microsoft.Data.SqlClient.SqlDataReader reader;
        Microsoft.Data.SqlClient.SqlConnection connection;
        

        //Microsoft.Data.SqlClient.SqlDataReader reader2;


        int userID = Form1.userID;


           
        public FormCouponCreate()
        {
            InitializeComponent();
        }

        public void FormCouponCreate_Load(object sender, EventArgs e)
        {

        }
        public void button5_Click(object sender, EventArgs e)
        {

            try
            {
                connection = new Microsoft.Data.SqlClient.SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=BalanceManagementDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
                command = new Microsoft.Data.SqlClient.SqlCommand();
                command.Connection = connection;
                command2 = new Microsoft.Data.SqlClient.SqlCommand();
                command2.Connection = connection;
                command3=new Microsoft.Data.SqlClient.SqlCommand();
                command3.Connection = connection;
                connection.Open();
                string amount = textBox1.Text;
                decimal couponAmount=decimal.Parse(amount);
                decimal cashBalance = 0;
                decimal newCashBalance = 0;
                command.CommandText = ("Select CashBalance From BalanceTable Where UserID='" + userID + "'");
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    
                     cashBalance = reader.GetDecimal(reader.GetOrdinal("CashBalance"));


                }
                reader.NextResult();



                if (reader.Read() && cashBalance >= couponAmount)
                {
                    command2.CommandText = ("INSERT INTO CouponTable(UserID, Amount, ExpirationDate, IsUsed);VALUES('" + userID + "','" + amount + "',DATEADD(YEAR, 1, GETDATE()),0)");
                    newCashBalance = cashBalance - couponAmount;
                    reader.NextResult();
                    command3.CommandText = ("Update  BalanceTable SET CashBalance='"+newCashBalance+"' Where UserID='"+userID+"'");
                }
                else { MessageBox.Show("You Have Insufficient Balance", "Error"); }
                



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
    }







    }

