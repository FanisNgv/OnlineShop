using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace OnlineShop_CourseWork_
{    
    public partial class OnlineShop : Form
    {
        public enum RowState
        {
            Existed,
            New,
            Modified,
            ModifiedNew,
            Deleted

        }
        ShopDataBase dataBase = new ShopDataBase();
        int selectedRow;

        AlterFormForCommodity alterFormForCommodity;
        AlterFormForConsumer alterFormForConsumer;
        AlterFormForPurchase alterFormForPurchase;
        AlterFormForStorage alterFormForStorage;
        
        public OnlineShop()
        {
            InitializeComponent();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.AllowUserToResizeColumns = true;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dataGridView2.AllowUserToOrderColumns = true;
            dataGridView2.AllowUserToResizeColumns = true;
            dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView3.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dataGridView3.AllowUserToOrderColumns = true;
            dataGridView3.AllowUserToResizeColumns = true;
            dataGridView4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView4.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dataGridView4.AllowUserToOrderColumns = true;
            dataGridView4.AllowUserToResizeColumns = true;
            dataGridView5.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView5.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dataGridView5.AllowUserToOrderColumns = true;
            dataGridView5.AllowUserToResizeColumns = true;
        }
        //CONSUMER
        private void CreateColumnsOfConsumer()
        {
            dataGridView1.Columns.Add("CONSUMER_ID", "ID");
            dataGridView1.Columns.Add("EMAIL", "EMAIL");
            dataGridView1.Columns.Add("FULL_NAME", "FULL_NAME");
            dataGridView1.Columns.Add("ADDRESS_OF_RESID", "ADDRESS_OF_RESID");
            dataGridView1.Columns.Add("IsNew", String.Empty);
        }
        private void ReadSingleRowOfConsumer(DataGridView dgv, IDataRecord record)
        {
            dgv.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2), record.GetString(3), RowState.ModifiedNew);
            dgv.Columns[4].Visible = false;

        }
        public void RefreshDataGridOfConsumer(DataGridView dgv)
        {
            dgv.Rows.Clear();
            string queryString = $"select * from CONSUMER";

            SqlCommand command = new SqlCommand(queryString, dataBase.getConnection());
            dataBase.openConnection();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ReadSingleRowOfConsumer(dgv, reader);
            }
            reader.Close();
        }
        //CONSUMER ACTIONS
        private void addRecord1_Click(object sender, EventArgs e)
        {
            if (alterFormForConsumer!=null)
            {
                alterFormForConsumer.Close();
                alterFormForConsumer = null;
            }
            alterFormForConsumer = new AlterFormForConsumer(this);
            alterFormForConsumer.Show();
        }
        private void UpdateButton1_Click(object sender, EventArgs e)
        {
            RefreshDataGridOfConsumer(dataGridView1);
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (alterFormForConsumer != null)
            {
                alterFormForConsumer.Close();
                alterFormForConsumer = null;
            }
            selectedRow = e.RowIndex;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[selectedRow];

                alterFormForConsumer = new AlterFormForConsumer(this);
                alterFormForConsumer.Show();

                alterFormForConsumer.textBox4.Text = row.Cells[0].Value.ToString();
                alterFormForConsumer.textBox1.Text = row.Cells[1].Value.ToString();
                alterFormForConsumer.textBox2.Text = row.Cells[2].Value.ToString();
                alterFormForConsumer.textBox3.Text = row.Cells[3].Value.ToString();


            }
        }
        private void SearchButton1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                dataGridView1.Rows.Clear();
            }
            else
            {
                dataGridView1.Rows.Clear();
                string searchString = $"select * from CONSUMER where {comboBox1.Text} like '%" + textBox1.Text + "%'";
                SqlCommand command = new SqlCommand(searchString, dataBase.getConnection());
                dataBase.openConnection();
                SqlDataReader read = command.ExecuteReader();
                while (read.Read())
                {
                    ReadSingleRowOfConsumer(dataGridView1, read);
                }
                read.Close();
            }
        }




        //COMMODITY
        private void CreateColumnsForCommodity()
        {
            dataGridView2.Columns.Add("COMM_ID", "ID");
            dataGridView2.Columns.Add("CODE_OF_COM", "CODE_OF_COM");
            dataGridView2.Columns.Add("NAME_OF_COM", "NAME_OF_COM");
            dataGridView2.Columns.Add("PRICE", "PRICE");
            dataGridView2.Columns.Add("CODE_OF_STOR", "CODE_OF_STOR");
            dataGridView2.Columns.Add("COUNT_OF_COM", "COUNT_OF_COM");
            dataGridView2.Columns.Add("IsNew", String.Empty);
        }
        private void ReadSingleRowForCommodity(DataGridView dgv, IDataRecord record)
        {
            dgv.Rows.Add(record.GetInt32(0),record.GetString(1), record.GetString(2),record.GetDecimal(3),record.GetString(4),record.GetInt32(5) ,RowState.ModifiedNew);
            dgv.Columns[6].Visible = false;
        }
        public void RefreshDataGridOfCommodity(DataGridView dgv)
        {
            dgv.Rows.Clear();
            string queryString = $"select * from COMMODITY";

            SqlCommand command = new SqlCommand(queryString, dataBase.getConnection());
            dataBase.openConnection();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ReadSingleRowForCommodity(dgv, reader);
            }
            reader.Close();
        }
        //COMMODITY ACTIONS        
        private void UpdateButton2_Click(object sender, EventArgs e)
        {
            RefreshDataGridOfStorage(dataGridView3);
        }
        private void SearchButton2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                dataGridView2.Rows.Clear();
            }
            else
            {
                dataGridView2.Rows.Clear();
                string searchString = $"select * from COMMODITY where {comboBox2.Text} like '%" + textBox2.Text + "%'";
                SqlCommand command = new SqlCommand(searchString, dataBase.getConnection());
                dataBase.openConnection();
                SqlDataReader read = command.ExecuteReader();
                while (read.Read())
                {
                    ReadSingleRowForCommodity(dataGridView2, read);
                }
                read.Close();
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            RefreshDataGridOfCommodity(dataGridView2);
        }
        private void addRecCom_Click(object sender, EventArgs e)
        {
            if (alterFormForCommodity != null)
            {
                alterFormForCommodity.Close();
                alterFormForCommodity = null;
            }
            alterFormForCommodity = new AlterFormForCommodity(this);
            alterFormForCommodity.Show();
        }
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (alterFormForCommodity != null)
            {
                alterFormForCommodity.Close();
                alterFormForCommodity = null;
            }
            selectedRow = e.RowIndex;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView2.Rows[selectedRow];

                alterFormForCommodity = new AlterFormForCommodity(this);
                alterFormForCommodity.Show();
                alterFormForCommodity.textBox1.Text = row.Cells[0].Value.ToString();
                alterFormForCommodity.textBox2.Text = row.Cells[1].Value.ToString();
                alterFormForCommodity.textBox3.Text = row.Cells[2].Value.ToString();
                alterFormForCommodity.textBox4.Text = row.Cells[3].Value.ToString();
                alterFormForCommodity.comboBox1.Text = row.Cells[4].Value.ToString();
                alterFormForCommodity.textBox6.Text = row.Cells[5].Value.ToString();


            }
        }



        //STORAGE
        private void CreateColumnsForStorage()
        {
            dataGridView3.Columns.Add("STOR_ID", "ID");
            dataGridView3.Columns.Add("CODE_OF_STOR", "CODE_OF_STOR");
            dataGridView3.Columns.Add("ADDRESS_OF_STOR", "ADDRESS_OF_STOR");
            dataGridView3.Columns.Add("IsNew", String.Empty);
        }
        private void ReadSingleRowForStorage(DataGridView dgv, IDataRecord record)
        {
            dgv.Rows.Add(record.GetInt32(0),record.GetString(1), record.GetString(2), RowState.ModifiedNew);
            dgv.Columns[3].Visible = false;
        }
        public void RefreshDataGridOfStorage(DataGridView dgv)
        {
            dgv.Rows.Clear();
            string queryString = $"select * from STORAGE";

            SqlCommand command = new SqlCommand(queryString, dataBase.getConnection());
            dataBase.openConnection();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ReadSingleRowForStorage(dgv, reader);
            }
            reader.Close();
        }
        // STORAGE ACTIONS
        private void AddRecord2_Click(object sender, EventArgs e)
        {
            if (alterFormForStorage != null)
            {
                alterFormForStorage.Close();
                alterFormForStorage = null;
            }
            alterFormForStorage = new AlterFormForStorage(this);
            alterFormForStorage.Show();
        }
        private void UpdateButton3_Click(object sender, EventArgs e)
        {
            RefreshDataGridOfStorage(dataGridView3);
        }
        private void SearchButton3_Click(object sender, EventArgs e)
        {
            if (alterFormForStorage != null)
            {
                alterFormForStorage.Close();
                alterFormForStorage = null;
            }
            if (string.IsNullOrEmpty(textBox3.Text))
            {
                dataGridView3.Rows.Clear();
            }
            else
            {
                dataGridView3.Rows.Clear();
                string searchString = $"select * from STORAGE where {comboBox3.Text} like '%" + textBox3.Text + "%'";
                SqlCommand command = new SqlCommand(searchString, dataBase.getConnection());
                dataBase.openConnection();
                SqlDataReader read = command.ExecuteReader();
                while (read.Read())
                {
                    ReadSingleRowForStorage(dataGridView3, read);
                }
                read.Close();
            }
        }
        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView3.Rows[selectedRow];

                alterFormForStorage = new AlterFormForStorage(this);
                alterFormForStorage.Show();

                alterFormForStorage.textBox1.Text = row.Cells[0].Value.ToString();
                alterFormForStorage.CodeTextBox.Text = row.Cells[1].Value.ToString();
                alterFormForStorage.AddressTextBox.Text = row.Cells[2].Value.ToString();


            }
        }

        //PURCHASE
        private void CreateColumnsForPurchase()
        {
            dataGridView4.Columns.Add("PURCHASE_ID", "ID");
            dataGridView4.Columns.Add("EMAIL", "EMAIL");
            dataGridView4.Columns.Add("CODE_OF_COM", "CODE_OF_COM");
            dataGridView4.Columns.Add("DATE_OF_PURCHASE", "DATE_OF_PURCHASE");
            dataGridView4.Columns.Add("DATE_OF_RECEIPT", "DATE_OF_RECEIPT");
            dataGridView4.Columns.Add("IsNew", String.Empty);
        }
        private void ReadSingleRowForPurchase(DataGridView dgv, IDataRecord record)
        {
            dgv.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2), record.GetDateTime(3), record.GetDateTime(4), RowState.ModifiedNew);
            dgv.Columns[5].Visible = false;
        }
        public void RefreshDataGridOfPurchase(DataGridView dgv)
        {
            dgv.Rows.Clear();
            string queryString = $"select * from PURCHASE";

            SqlCommand command = new SqlCommand(queryString, dataBase.getConnection());
            dataBase.openConnection();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ReadSingleRowForPurchase(dgv, reader);
            }
            reader.Close();
        }
        //PURCHASE ACITONS
        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (alterFormForPurchase != null)
            {
                alterFormForPurchase.Close();
                alterFormForPurchase = null;
            }
            selectedRow = e.RowIndex;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView4.Rows[selectedRow];

                alterFormForPurchase = new AlterFormForPurchase(this);
                alterFormForPurchase.Show();

                alterFormForPurchase.comboBox1.Text = row.Cells[0].Value.ToString();
                alterFormForPurchase.comboBox2.Text = row.Cells[1].Value.ToString();
                alterFormForPurchase.comboBox3.Text = row.Cells[2].Value.ToString();
                alterFormForPurchase.dateTimePicker1.Value = Convert.ToDateTime(row.Cells[3].Value);
                alterFormForPurchase.dateTimePicker2.Value = Convert.ToDateTime(row.Cells[4].Value);


            }
        }
        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            RefreshDataGridOfPurchase(dataGridView4);

        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox4.Text))
            {
                dataGridView4.Rows.Clear();
            }
            else
            {
                dataGridView4.Rows.Clear();
                string searchString = $"select * from PURCHASE where {comboBox4.Text} like '%" + textBox4.Text + "%'";
                SqlCommand command = new SqlCommand(searchString, dataBase.getConnection());
                dataBase.openConnection();
                SqlDataReader read = command.ExecuteReader();
                while (read.Read())
                {
                    ReadSingleRowForPurchase(dataGridView4, read);
                }
                read.Close();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (alterFormForPurchase != null)
            {
                alterFormForPurchase.Close();
                alterFormForPurchase = null;
            }
            alterFormForPurchase = new AlterFormForPurchase(this);
            alterFormForPurchase.Show();
        }
        private void OnlineShop_Load(object sender, EventArgs e)
        {
            StartPosition = FormStartPosition.CenterScreen;
            WindowState = FormWindowState.Maximized;

            CreateColumnsOfConsumer();
            CreateColumnsForStorage();
            CreateColumnsForCommodity();
            CreateColumnsForPurchase();
            CreateColumnsForPurchaseAdd();

            RefreshDataGridOfConsumer(dataGridView1);
            RefreshDataGridOfCommodity(dataGridView2);            
            RefreshDataGridOfStorage(dataGridView3);
            RefreshDataGridOfPurchase(dataGridView4);
            RefreshDataGridOfPurchaseAdd(dataGridView5);
        }

        private void OnlineShop_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (alterFormForCommodity != null)
            {
                alterFormForCommodity.Close();
            }
            if (alterFormForConsumer != null)
            {
                alterFormForConsumer.Close();
            }
            if (alterFormForStorage != null)
            {
                alterFormForStorage.Close();
            }
            if (alterFormForPurchase != null)
            {
                alterFormForPurchase.Close();
            }
        }
        //PURCHASE ADDITIONAL INFO
        private void CreateColumnsForPurchaseAdd()
        {
            dataGridView5.Columns.Add("FULL_NAME", "FULL_NAME");
            dataGridView5.Columns.Add("NAME_OF_COM", "NAME_OF_COM");
            dataGridView5.Columns.Add("DATE_OF_PURCHASE", "DATE_OF_PURCHASE");
            dataGridView5.Columns.Add("DATE_OF_RECEIPT", "DATE_OF_RECEIPT");

        }
        private void ReadSingleRowForPurchaseAdd(DataGridView dgv, IDataRecord record)
        {
            dgv.Rows.Add(record.GetString(0), record.GetString(1), record.GetDateTime(2), record.GetDateTime(3));
        }
        public void RefreshDataGridOfPurchaseAdd(DataGridView dgv)
        {
            dgv.Rows.Clear();
            string queryString = $"SELECT CONSUMER.FULL_NAME, COMMODITY.NAME_OF_COM, PURCHASE.DATE_OF_PURCHASE,PURCHASE.DATE_OF_RECEIPT " +
                $"FROM(PURCHASE INNER JOIN CONSUMER ON CONSUMER.EMAIL = PURCHASE.EMAIL) INNER JOIN COMMODITY ON PURCHASE.CODE_OF_COM = " +
                $"COMMODITY.CODE_OF_COM";

            SqlCommand command = new SqlCommand(queryString, dataBase.getConnection());
            dataBase.openConnection();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ReadSingleRowForPurchaseAdd(dgv, reader);
            }
            reader.Close();
        }


    }
}
