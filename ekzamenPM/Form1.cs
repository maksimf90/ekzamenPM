using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ekzamenPM
{
    public partial class Form1 : Form
    {

        public Form1()
        {
                InitializeComponent(); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
                string login = Login.Text;
                string password = Password.Text;

                string connectionString = "host=localhost; username=postgres; port=5432; database=ezkPM; password=11111";

                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT role FROM users WHERE Login=@login AND Password=@password";

                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("Login", login);
                        command.Parameters.AddWithValue("Password", password);

                        string role = (string)command.ExecuteScalar();

                        if (role == null)
                        {
                            MessageBox.Show("Данные неверны");
                            return;
                        }
                        if (role == "admin")
                        {
                            Admin Admin = new Admin();
                            Admin.Show();
                            this.Hide();
                        }
                        else if (role == "student")
                        {
                            Student Student = new Student();
                            Student.Show();
                            this.Hide();
                    }
                    }
                }
            }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Registration Registration = new Registration();
             Registration.Show();
            this.Hide();
        }
    } 
}
