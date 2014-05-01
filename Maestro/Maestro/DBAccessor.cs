using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
//using System

namespace Maestro
{
    static class DBAccessor
    {
        public DataTable selectAllTable(String name)
        {
            String query = "SELECT * FROM " + name;

            // create to strings for the connection and the query
            string connString = @"Persist Security Info=False; User ID=joe;Initial Catalog=Inventory;Password=inventory;Data Source=vmspdgdr001.amr.corp.intel.com";

            using (SqlConnection sqlConn = new SqlConnection(connString))
            {
                string sqlQuery = @"SELECT * from Items";
                SqlCommand cmd = new SqlCommand(sqlQuery, sqlConn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                da.Fill(table);
                dataGridView1.DataSource = new BindingSource(table, null);
            }
        }

        public DataTable insertEntry(String attributes)
        {

        }

        public DataTable updateEntry(String attributes)
        {

        }

        public DataTable deleteEntry(String attributes)
        {

        }
    }
}
