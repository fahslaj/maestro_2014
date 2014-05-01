using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace Maestro
{
    static class DBAccessor
    {
        static string connString = @"Persist Security Info=False; User ID=joe;Initial Catalog=Inventory;Password=shmoe;Data Source=bogus.network.name";
        public DataTable selectAllTable(String name)
        {
            String query = "SELECT * FROM " + name;

            // create to strings for the connection and the query

            using (SqlConnection sqlConn = new SqlConnection(""))
            {
                //string sqlQuery = @"SELECT * from Items";
                SqlCommand cmd = new SqlCommand(query, sqlConn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                da.Fill(table);
                return table;
                //dataGridView1.DataSource = new BindingSource(table, null);
            }
            
        }

        public DataTable insertEntry(String attributes)
        {

        }

        public DataTable updateEntry(String tablename, DataRow oldrow, String attributes)
        {
            using (SqlConnection sqlConn = new SqlConnection(connString))
            {
                string sqlQuery = @"UPDATE " + tablename + " SET " + " WHERE ";
                SqlCommand cmd = new SqlCommand(sqlQuery, sqlConn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                da.Fill(table);
                //dataGridView1.DataSource = new BindingSource(table, null);
                return table;
            }

        }

        public DataTable deleteEntry(String tablename, String attributes)
        {
            using (SqlConnection sqlConn = new SqlConnection(connString))
            {
                string sqlQuery = @"DELETE FROM " + tablename + " WHERE ";
                SqlCommand cmd = new SqlCommand(sqlQuery, sqlConn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                da.Fill(table);
                //dataGridView1.DataSource = new BindingSource(table, null);
                return table;
            }

        }
    }
}
