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
    public partial class AlterFormForStorage : Form
    {

        ShopDataBase dataBase = new ShopDataBase();
        OnlineShop onShop;
        public AlterFormForStorage(OnlineShop onlineShop)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            onShop = onlineShop;
        }

        private void SaveButton_Click_1(object sender, EventArgs e)
        {
            dataBase.openConnection();

            var CodeOfStor = CodeTextBox.Text;
            var AddressOfStor = AddressTextBox.Text;

            var addQuery = $"INSERT INTO STORAGE VALUES ('{CodeOfStor}', '{AddressOfStor}')";
            var command = new SqlCommand(addQuery, dataBase.getConnection());
            dataBase.openConnection();
            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show("The record was successfully created!", "Succsess!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                onShop.RefreshDataGridOfStorage(onShop.dataGridView3);
            }
            catch (Exception)
            {
                MessageBox.Show("The record wasn't created!", "Fail!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dataBase.closeConnection();
        }

        private void deleteRow()
        {
            int index = onShop.dataGridView3.CurrentCell.RowIndex;
            onShop.dataGridView3.Rows[index].Visible = false;
            onShop.dataGridView3.Rows[index].Cells[3].Value = OnlineShop.RowState.Deleted;
        }
        private void IsRowForDelete()
        {
            dataBase.openConnection();
            for (int index = 0; index < onShop.dataGridView3.Rows.Count; index++)
            {
                var rowState = (OnlineShop.RowState)onShop.dataGridView3.Rows[index].Cells[3].Value;
                if (rowState == OnlineShop.RowState.Existed)
                {
                    continue;
                }
                if (rowState == OnlineShop.RowState.Deleted)
                {
                    var deleteQuery = $"delete from STORAGE where CODE_OF_STOR = '{CodeTextBox.Text}'";
                    var command = new SqlCommand(deleteQuery, dataBase.getConnection());
                    command.ExecuteNonQuery();
                }
            }
            dataBase.closeConnection();
        }

        private void DelteButton_Click(object sender, EventArgs e)
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
            for (int index = 0; index < onShop.dataGridView3.Rows.Count; index++)
            {
                var rowState = (OnlineShop.RowState)onShop.dataGridView3.Rows[index].Cells[3].Value;
                if (rowState == OnlineShop.RowState.Existed)
                {
                    continue;
                }
                if (rowState == OnlineShop.RowState.Modified)
                {
                    var deleteQuery = $"update STORAGE set  CODE_OF_STOR = '{CodeTextBox.Text}'," +
                        $" ADDRESS_OF_STOR = '{AddressTextBox.Text}' where STOR_ID = '{textBox1.Text}'";
                    var command = new SqlCommand(deleteQuery, dataBase.getConnection());
                    command.ExecuteNonQuery();
                }
            }
            dataBase.closeConnection();
        }
        private void Change()
        {
            var SelectedRowIndex = onShop.dataGridView3.CurrentCell.RowIndex;
            var Cons_ID = textBox1.Text;
            var CodeOfStor = CodeTextBox.Text;
            var Address = AddressTextBox.Text;

            if (onShop.dataGridView3.Rows[SelectedRowIndex].Cells[0].Value.ToString() != string.Empty)
            {
                onShop.dataGridView3.Rows[SelectedRowIndex].SetValues(Cons_ID, CodeOfStor, Address);
                onShop.dataGridView3.Rows[SelectedRowIndex].Cells[3].Value = OnlineShop.RowState.Modified;
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
