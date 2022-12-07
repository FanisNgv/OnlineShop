using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace OnlineShop_CourseWork_
{
    public partial class Sign_up : Form
    {

        ShopDataBase dataBase = new ShopDataBase();
        public Sign_up()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            WindowState = FormWindowState.Maximized;
        }
        private void Sign_up_Load(object sender, EventArgs e)
        {
            textBox_password.PasswordChar = '●';
            closedEye.Visible = false;
        }

        private void openedEye_Click(object sender, EventArgs e)
        {
            textBox_password.PasswordChar = (char)0;
            textBox_password.UseSystemPasswordChar = false;
            openedEye.Visible = false;
            closedEye.Visible = true;
        }

        private void closedEye_Click(object sender, EventArgs e)
        {
            textBox_password.UseSystemPasswordChar = true;
            openedEye.Visible = true;
            closedEye.Visible = false;
        }

        private void sign_up_button_Click(object sender, EventArgs e)
        {
            if (checkUser())
            {
                return;
            }

            var login = textBox_login.Text;
            var password = textBox_password.Text;
            string querysting = $"INSERT INTO admins VALUES ('{login}', '{password}')";
            SqlCommand command = new SqlCommand(querysting, dataBase.getConnection());
            dataBase.openConnection();
            if(command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("An account succsessfully created!");
                Sign_In sgn_form = new Sign_In();
                this.Hide();
                sgn_form.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("An account wasn't created!");
            }
            dataBase.closeConnection();
        }
        private bool checkUser()
        {
            var loginUser = textBox_login.Text;
            var passwordUser = textBox_password.Text;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            string querystring = $"SELECT login_admin FROM admins WHERE login_admin = '{loginUser}'";
            SqlCommand command = new SqlCommand(querystring, dataBase.getConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);

            if(table.Rows.Count>0)
            {
                MessageBox.Show("An account already exists!");
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
