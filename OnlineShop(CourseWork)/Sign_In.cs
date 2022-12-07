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
    public partial class Sign_In : Form
    {
        ShopDataBase dataBase = new ShopDataBase();
        public Sign_In()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            WindowState = FormWindowState.Maximized;
            this.BackColor = Color.FromArgb(255, 232, 232);
        }

        private void Sign_In_Load(object sender, EventArgs e)
        {
            textBox_password.PasswordChar = '●';
            closedEye.Visible = false;
        }

        private void log_in_button_Click(object sender, EventArgs e)
        {
            var AdminLogin = textBox_login.Text;
            var AdminPassword = textBox_password.Text;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string querystring = $"SELECT login_admin, password_admin FROM admins WHERE login_admin = '{AdminLogin}' and password_admin = '{AdminPassword}'";
            SqlCommand command = new SqlCommand(querystring, dataBase.getConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);

            if(table.Rows.Count == 1)
            {
                MessageBox.Show("Вход выполнен!", "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                OnlineShop frm = new OnlineShop();
                this.Hide();
                this.textBox_login.Text = "";
                this.textBox_password.Text = "";
                frm.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Ошибка входа!", "Аккаунта не существует!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Sign_up sign_form = new Sign_up();
            sign_form.ShowDialog();            
            this.Show();
        }
    }
}
