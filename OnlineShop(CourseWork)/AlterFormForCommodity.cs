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
    public partial class AlterFormForCommodity : Form
    {
        OnlineShop onShop;
        ShopDataBase dataBase = new ShopDataBase();
        public AlterFormForCommodity(OnlineShop onlineShop)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            onShop = onlineShop;
            

            SqlConnection con = new SqlConnection(@"Data Source = LAPTOP-MF8O4FSQ; Initial Catalog = OnlineShop; Integrated Security = true");
            SqlCommand cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM STORAGE";
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                comboBox1.Items.Add(dr["CODE_OF_STOR"]);
            }
            con.Close();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty)
            {
                MessageBox.Show("You shouldn't fill ID manually. It fills automatically!", "Fail!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            dataBase.openConnection();

            var CodeOfCom = textBox2.Text;
            var NameOfCom = textBox3.Text;
            var Price = textBox4.Text;
            var CodeOfStor = comboBox1.Text;
            var CountOfComm = textBox6.Text;

            var addQuery = $"INSERT INTO COMMODITY VALUES ('{CodeOfCom}', '{NameOfCom}','{Price}','{CodeOfStor}','{CountOfComm}')";
            var command = new SqlCommand(addQuery, dataBase.getConnection());
            dataBase.openConnection();
            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show("The record was successfully created!", "Succsess!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                onShop.RefreshDataGridOfCommodity(onShop.dataGridView2);
            }
            catch (Exception)
            {
                MessageBox.Show("The record wasn't created!", "Fail!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dataBase.closeConnection();
        }
        private void deleteRow()
        {
            int index = onShop.dataGridView2.CurrentCell.RowIndex;
            onShop.dataGridView2.Rows[index].Visible = false;
            onShop.dataGridView2.Rows[index].Cells[6].Value = OnlineShop.RowState.Deleted;
        }
        private void IsRowForDelete()
        {
            dataBase.openConnection();
            for (int index = 0; index < onShop.dataGridView1.Rows.Count; index++)
            {
                var rowState = (OnlineShop.RowState)onShop.dataGridView2.Rows[index].Cells[6].Value;
                if (rowState == OnlineShop.RowState.Existed)
                {
                    continue;
                }
                if (rowState == OnlineShop.RowState.Deleted)
                {
                    var deleteQuery = $"delete from COMMODITY where CODE_OF_COM = '{textBox2.Text}'";
                    var command = new SqlCommand(deleteQuery, dataBase.getConnection());
                    command.ExecuteNonQuery();
                }
            }
            dataBase.closeConnection();
        }
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you going to delete this row?", "Delete", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                deleteRow();
                IsRowForDelete();
            }
        }
        private void IsRowForChange()
        {
            dataBase.openConnection();
            for (int index = 0; index < onShop.dataGridView2.Rows.Count; index++)
            {
                var rowState = (OnlineShop.RowState)onShop.dataGridView2.Rows[index].Cells[6].Value;
                if (rowState == OnlineShop.RowState.Existed)
                {
                    continue;
                }
                if (rowState == OnlineShop.RowState.Modified)
                {
                    var deleteQuery = $"update COMMODITY set CODE_OF_COM = '{textBox2.Text}', NAME_OF_COM = '{textBox3.Text}'," +
                        $" PRICE = '{textBox4.Text}',CODE_OF_STOR = '{comboBox1.Text}', COUNT_OF_COM = '{textBox6.Text}' where COMM_ID = '{textBox1.Text}'";
                    var command = new SqlCommand(deleteQuery, dataBase.getConnection());
                    command.ExecuteNonQuery();
                }
            }
            dataBase.closeConnection();
        }
        private void Change()
        {
            var SelectedRowIndex = onShop.dataGridView2.CurrentCell.RowIndex;

            var ComID = textBox1.Text;
            var CodeOfCom = textBox2.Text;
            var NameOfCom = textBox3.Text;
            var Price = textBox4.Text;
            var CodeOfStor = comboBox1.Text;
            var CountOfCom = textBox6.Text;

            if (onShop.dataGridView2.Rows[SelectedRowIndex].Cells[0].Value.ToString() != string.Empty)
            {
                onShop.dataGridView2.Rows[SelectedRowIndex].SetValues(ComID, CodeOfCom, NameOfCom, Price, CodeOfStor, CountOfCom);
                onShop.dataGridView2.Rows[SelectedRowIndex].Cells[6].Value = OnlineShop.RowState.Modified;
            }
        }
        private void ChangeButton_Click(object sender, EventArgs e)
        {
            try
            {
                Change();
                IsRowForChange();
                MessageBox.Show("The changes succsessfully applied!", "Succsess!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception)
            {
                MessageBox.Show("The changes wasn't applied!", "Fail!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
