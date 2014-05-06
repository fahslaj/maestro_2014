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
        static string connString = "Server=titan.csse.rose-hulman.edu;Database=Maestro;User Id=maestro;Password=maestro;";
        public static DataTable selectAllTable(String name)
        {
            String query = "SELECT * FROM " + name;

            // create to strings for the connection and the query

            using (SqlConnection sqlConn = new SqlConnection(connString))
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

        public static DataTable insertEntry(String attributes, String tableName)
        {
            String query = "";
            if(!attributes.Equals("") && !tableName.Equals("")){
                query = "INSERT INTO " + tableName + " VALUES (";

                String currAttr = "";
                while (attributes.Length > 0)
                {
                    String currChar = attributes.Substring(0, 1);
                    if (currChar.Equals("|"))
                    {
                        query += currAttr + ",";
                        currAttr = "";
                    }
                    else currAttr += currChar;

                    attributes = attributes.Substring(1);
                }
                query = query.Substring(0, query.Length - 1);
                query += ");";

                using (SqlConnection sqlConn = new SqlConnection(""))
                {
                    SqlCommand cmd = new SqlCommand(query, sqlConn);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    da.Fill(table);
                    return table;
                }
            }

            return new DataTable();
        }

        public static DataTable updateEntry(String tablename, DataRow oldrow, String attributes)
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

        public static DataTable deleteEntry(String tablename, String attributes)
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

        public static DataTable insertIntoDB(string tableName, object[] attributeValues)
        {
            string query = "SELECT * FROM " + tableName;

            using (SqlConnection sqlConn = new SqlConnection(connString))
            {
                //string sqlQuery = @"SELECT * from Items";
                SqlCommand cmd = new SqlCommand(query, sqlConn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }
}
