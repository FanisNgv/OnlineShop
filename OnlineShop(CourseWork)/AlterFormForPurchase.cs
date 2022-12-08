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
    public partial class AlterFormForPurchase : Form
    {
        ShopDataBase dataBase = new ShopDataBase();
        OnlineShop onShop;
        public AlterFormForPurchase(OnlineShop onlineShop)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            onShop = onlineShop;

            SqlConnection con = new SqlConnection(@"Data Source = LAPTOP-MF8O4FSQ; Initial Catalog = OnlineShop; Integrated Security = true");
            SqlCommand cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM PURCHASE";
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                comboBox1.Items.Add(dr["PURCHASE_ID"]);
            }
            con.Close();

            con.Open();
            cmd.CommandText = "SELECT * FROM CONSUMER";
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox2.Items.Add(dr["EMAIL"]);
            }
            con.Close();

            con.Open();
            cmd.CommandText = "SELECT * FROM COMMODITY";
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox3.Items.Add(dr["CODE_OF_COM"]);
            }
            con.Close();
        }
        private void AlterFormForPurchase_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "d-MMM-yyyy hh:mm:ss";

            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "d-MMM-yyyy hh:mm:ss";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != string.Empty)
            {
                MessageBox.Show("You shouldn't fill ID manually. It fills automatically!", "Fail!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            dataBase.openConnection();

            var Email = comboBox2.Text;
            var CodeOfComm = comboBox3.Text;
            var DateOfPurchase = Convert.ToString(dateTimePicker1.Value);
            var DateOfReceipt = Convert.ToString(dateTimePicker2.Value);

            var addQuery = $"INSERT INTO PURCHASE VALUES ( '{Email}','{CodeOfComm}','{DateOfPurchase}','{DateOfReceipt}')";
            var command = new SqlCommand(addQuery, dataBase.getConnection());
            dataBase.openConnection();
            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show("The record was successfully created!", "Succsess!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                onShop.RefreshDataGridOfPurchase(onShop.dataGridView4);
            }
            catch (Exception)
            {
                MessageBox.Show("The record wasn't created!", "Fail!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dataBase.closeConnection();
        }
        private void IsRowForChange()
        {
            dataBase.openConnection();
            for (int index = 0; index < onShop.dataGridView4.Rows.Count; index++)
            {
                var rowState = (OnlineShop.RowState)onShop.dataGridView4.Rows[index].Cells[5].Value;
                if (rowState == OnlineShop.RowState.Existed)
                {
                    continue;
                }
                if (rowState == OnlineShop.RowState.Modified)
                {
                    var deleteQuery = $"update PURCHASE set EMAIL = '{comboBox2.Text}', CODE_OF_COM = '{comboBox3.Text}'," +
                        $" DATE_OF_PURCHASE = '{dateTimePicker1.Text}', DATE_OF_RECEIPT = '{dateTimePicker2.Text}'  where PURCHASE_ID = '{comboBox1.Text}'";
                    var command = new SqlCommand(deleteQuery, dataBase.getConnection());
                    command.ExecuteNonQuery();
                }
            }
            dataBase.closeConnection();
        }
        private void Change()
        {
            var SelectedRowIndex = onShop.dataGridView4.CurrentCell.RowIndex;

            var PurchaseID = comboBox1.Text;
            var Email = comboBox2.Text;
            var CodeOfComm = comboBox3.Text;
            var DateOfPurchase = Convert.ToString(dateTimePicker1.Value);
            var DateOfReceipt = Convert.ToString(dateTimePicker2.Value);

            if (onShop.dataGridView4.Rows[SelectedRowIndex].Cells[0].Value.ToString() != string.Empty)
            {
                onShop.dataGridView4.Rows[SelectedRowIndex].SetValues(PurchaseID, Email, CodeOfComm, DateOfPurchase, DateOfReceipt);
                onShop.dataGridView4.Rows[SelectedRowIndex].Cells[5].Value = OnlineShop.RowState.Modified;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Change();
            IsRowForChange();
            try
            {
                
                MessageBox.Show("The changes succsessfully applied!", "Succsess!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception)
            {
                MessageBox.Show("The changes wasn't applied!", "Fail!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void deleteRow()
        {
            int index = onShop.dataGridView4.CurrentCell.RowIndex;
            onShop.dataGridView4.Rows[index].Visible = false;
            onShop.dataGridView4.Rows[index].Cells[5].Value = OnlineShop.RowState.Deleted;
        }
        private void IsRowForDelete()
        {
            dataBase.openConnection();
            for (int index = 0; index < onShop.dataGridView4.Rows.Count; index++)
            {
                var rowState = (OnlineShop.RowState)onShop.dataGridView4.Rows[index].Cells[5].Value;
                if (rowState == OnlineShop.RowState.Existed)
                {
                    continue;
                }
                if (rowState == OnlineShop.RowState.Deleted)
                {
                    var deleteQuery = $"delete from PURCHASE where PURCHASE_ID = '{comboBox1.Text}'";
                    var command = new SqlCommand(deleteQuery, dataBase.getConnection());
                    command.ExecuteNonQuery();
                }
            }
            dataBase.closeConnection();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you going to delete this row?", "Delete", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                deleteRow();
                IsRowForDelete();
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox3.Clear();
            SqlConnection con = new SqlConnection(@"Data Source = LAPTOP-MF8O4FSQ; Initial Catalog = OnlineShop; Integrated Security = true");
            SqlCommand cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = $"select FULL_NAME from CONSUMER where EMAIL like '%" + comboBox2.Text + "%'";
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                textBox3.AppendText(dr["FULL_NAME"].ToString());
            }
            con.Close();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox4.Clear();
            SqlConnection con = new SqlConnection(@"Data Source = LAPTOP-MF8O4FSQ; Initial Catalog = OnlineShop; Integrated Security = true");
            SqlCommand cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = $"select NAME_OF_COM from COMMODITY where CODE_OF_COM like '%" + comboBox3.Text + "%'";
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                textBox4.AppendText(dr["NAME_OF_COM"].ToString());
            }
            con.Close();
        }

        
    }
}
