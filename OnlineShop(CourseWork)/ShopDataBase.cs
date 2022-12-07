using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace OnlineShop_CourseWork_
{
    class ShopDataBase
    {
        SqlConnection sqlConnection = new SqlConnection(@"Data Source = LAPTOP-MF8O4FSQ; Initial Catalog = OnlineShop;Integrated Security = true");
        public void openConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Closed)
            {
                sqlConnection.Open();
            }
        }
        public void closeConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Open)
            {
                sqlConnection.Close();
            }
        }
        public SqlConnection getConnection()
        {
            return sqlConnection;
        }
    }
}
