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
    public partial class AlterFormForConsumer : Form
    {
        ShopDataBase dataBase = new ShopDataBase();
        OnlineShop onShop;
        public AlterFormForConsumer(OnlineShop onlineShop)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            onShop = onlineShop;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (textBox4.Text != string.Empty)
            {
                MessageBox.Show("You shouldn't fill ID manually. It fills automatically!", "Fail!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            dataBase.openConnection();

            var Email = textBox1.Text;
            var FullName = textBox2.Text;
            var AddressOfRes = textBox3.Text;

            var addQuery = $"INSERT INTO CONSUMER VALUES ('{Email}', '{FullName}', '{AddressOfRes}')";
            var command = new SqlCommand(addQuery, dataBase.getConnection());
            dataBase.openConnection();
            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show("The record was successfully created!", "Succsess!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                onShop.RefreshDataGridOfConsumer(onShop.dataGridView1);
            }
            catch (Exception)
            {
                MessageBox.Show("The record wasn't created!", "Fail!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dataBase.closeConnection();
        }
        private void deleteRow()
        {        
            int index = onShop.dataGridView1.CurrentCell.RowIndex;
            onShop.dataGridView1.Rows[index].Visible = false;
            onShop.dataGridView1.Rows[index].Cells[4].Value = OnlineShop.RowState.Deleted;
        }
        private void IsRowForDelete()
        {
            dataBase.openConnection();
            for (int index = 0; index < onShop.dataGridView1.Rows.Count; index++)
            {
                var rowState = (OnlineShop.RowState)onShop.dataGridView1.Rows[index].Cells[4].Value;
                if (rowState == OnlineShop.RowState.Existed)
                {
                    continue;
                }
                if (rowState == OnlineShop.RowState.Deleted)
                {
                    var deleteQuery = $"delete from CONSUMER where EMAIL = '{textBox1.Text}'";
                    var command = new SqlCommand(deleteQuery, dataBase.getConnection());
                    command.ExecuteNonQuery();
                }
            }
            dataBase.closeConnection();
        }

        private void DelButton1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you going to delete this row?", "Delete", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    deleteRow();
                    IsRowForDelete();
                    MessageBox.Show("The record was successfully deleted!", "Succsess!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    onShop.RefreshDataGridOfConsumer(onShop.dataGridView1);
                }
                catch (Exception)
                {
                    MessageBox.Show("The record wasn't deleted!", "Fail!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void IsRowForChange()
        {
            dataBase.openConnection();
            for (int index = 0; index < onShop.dataGridView1.Rows.Count; index++)
            {
                var rowState = (OnlineShop.RowState)onShop.dataGridView1.Rows[index].Cells[4].Value;
                if (rowState == OnlineShop.RowState.Existed)
                {
                    continue;
                }
                if (rowState == OnlineShop.RowState.Modified)
                {
                    var deleteQuery = $"update CONSUMER set EMAIL = '{textBox1.Text}', FULL_NAME = '{textBox2.Text}'," +
                        $" ADDRESS_OF_RESID = '{textBox3.Text}' where CONSUMER_ID = '{textBox4.Text}'";
                    var command = new SqlCommand(deleteQuery, dataBase.getConnection());
                    command.ExecuteNonQuery();
                }
            }
            dataBase.closeConnection();
        }
        private void Change()
        {
            var SelectedRowIndex = onShop.dataGridView1.CurrentCell.RowIndex;
            var Cons_ID = textBox4.Text;
            var Email = textBox1.Text;
            var FullName = textBox2.Text;
            var Address = textBox3.Text;


            if (onShop.dataGridView1.Rows[SelectedRowIndex].Cells[0].Value.ToString() != string.Empty)
            {
                onShop.dataGridView1.Rows[SelectedRowIndex].SetValues(Cons_ID, Email, FullName, Address);
                onShop.dataGridView1.Rows[SelectedRowIndex].Cells[4].Value = OnlineShop.RowState.Modified;
            }
        }
        private void ChangeButton1_Click(object sender, EventArgs e)
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
