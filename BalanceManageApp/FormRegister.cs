using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BalanceManageApp
{
    public partial class FormRegister : Form
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
        public FormRegister()
        {
            InitializeComponent();
            textBox2.UseSystemPasswordChar = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                connection = new Microsoft.Data.SqlClient.SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=BalanceManagementDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
                command = new Microsoft.Data.SqlClient.SqlCommand();
                connection.Open();
                command.Connection = connection;
                command.CommandText = ("Select * From UserTable where Username='" + textBox1.Text + "'");
                reader = command.ExecuteReader();

                if (reader.Read())
                {
                    MessageBox.Show("Username you chose is already in use.Please choose a different username");
                }

                else if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text) || string.IsNullOrEmpty(textBox4.Text) || string.IsNullOrEmpty(textBox5.Text))
                {
                    MessageBox.Show("Please Fill All The Required Information", "Error");

                }
                else
                {
                    reader.Close();
                    connection.Close();
                    
                    connection2 = new Microsoft.Data.SqlClient.SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=BalanceManagementDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
                    command2 = new Microsoft.Data.SqlClient.SqlCommand();
                    connection2.Open();
                    command2.Connection = connection2;
                    command2.CommandText = ("Insert Into UserTable Values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')");
                    command2.ExecuteNonQuery();
                    connection2.Close();

                    connection3 = new Microsoft.Data.SqlClient.SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=BalanceManagementDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
                    command3 = new Microsoft.Data.SqlClient.SqlCommand();
                    connection3.Open();
                    command3.Connection = connection3;
                   command3.CommandText = ("Select ID From UserTable Where Username='"+textBox1.Text+"'");
                    reader=command3.ExecuteReader();
                    reader.Read();
                    int userID = reader.GetInt32(0);
                    reader.Close();
                    connection3.Close();
                    
                    connection4 = new Microsoft.Data.SqlClient.SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=BalanceManagementDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
                    command4 = new Microsoft.Data.SqlClient.SqlCommand();
                    connection4.Open();
                    command4.Connection = connection4;
                    command4.CommandText = ("Insert Into BalanceTable Values('"+userID+"',0,0,0,0,0)");
                    command4.ExecuteNonQuery();
                    connection4.Close();
                    MessageBox.Show("Your Registration is successfull", "Congrats");
                    Form1 form1 = new Form1();
                    this.Hide();
                    form1.Show();

                }
            }



            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);

            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
            }
        }
    }
}
