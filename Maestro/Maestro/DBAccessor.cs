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

        public static DataTable selectSearchTable(String tableName, String searchKeywords)
        {
            String query = "SELECT * FROM " + tableName + " WHERE Title LIKE '%" + searchKeywords + "%';";

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

        public static DataTable selectCurrentPlaylist(String condition)
        {
            String query = "SELECT * FROM Media WHERE " + condition;

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
                //query = query.Substring(0, query.Length - 1);
                query += currAttr + ");";
                Console.WriteLine(query);
                using (SqlConnection sqlConn = new SqlConnection(connString))
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
                string sqlQuery = @"DELETE FROM " + tablename + " WHERE " + attributes;
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

        public static Boolean verifyLoginInfo(string username, string password)
        {
            string query = "SELECT * FROM Users WHERE Username = '" + username + "' and Passwd = '"
                + Math.Abs(password.GetHashCode() + username.GetHashCode()) + "'";
            using (SqlConnection sqlConn = new SqlConnection(connString))
            {
                //string sqlQuery = @"SELECT * from Items";
                SqlCommand cmd = new SqlCommand(query, sqlConn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count == 1)
                    return true;
            }
            return false;
        }

        public static string[] getAttributesFromTable(string tableName)
        {
            string query = "SELECT column_name FROM information_schema.columns WHERE table_name='"+tableName+"'";
            using (SqlConnection sqlConn = new SqlConnection(connString))
            {
                //string sqlQuery = @"SELECT * from Items";
                SqlCommand cmd = new SqlCommand(query, sqlConn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                string[] attributeNames = new string[dt.Rows.Count];
                for (int i = 0; i < dt.Columns.Count; i++)
                    attributeNames[i] = (dt.Rows[i][0]).ToString();
                return attributeNames;
            }
        }

        public static string[] getSongInfo(string songName)
        {
            string query = "SELECT * FROM SongView WHERE Title=" + songName;
            using (SqlConnection sqlConn = new SqlConnection(connString))
            {
                //string sqlQuery = @"SELECT * from Items";
                SqlCommand cmd = new SqlCommand(query, sqlConn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                string[] songInfo = new string[dt.Rows.Count];
                for (int i = 0; i < dt.Columns.Count; i++)
                    songInfo[i] = (dt.Rows[i][0]).ToString();
                return songInfo;
            }
        }

        public static void AddReview(String username, String mediaFilepath, int rating, String content)
        {
            //string query = "WriteReview ='" + username + "', @MedFP='" + mediaFilepath + "', @Rate=" + rating + ", @Cont='" + content + "'";
            using (SqlConnection sqlConn = new SqlConnection(connString))
            {
                //string sqlQuery = @"SELECT * from Items";
                if (content == null) content = "";
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand("WriteReview", sqlConn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.Add("@User", SqlDbType.VarChar).Value = username;
                cmd.Parameters.Add("@MedFP", SqlDbType.VarChar).Value = mediaFilepath;
                cmd.Parameters.Add("@Rate", SqlDbType.Int).Value = rating;
                cmd.Parameters.Add("@Cont", SqlDbType.Text).Value = content;
                cmd.ExecuteNonQuery();
                sqlConn.Close();
                /*SqlDataAdapter da = new SqlDataAdapter();
                da.InsertCommand = cmd;
                DataTable dt = new DataTable();
                da.Fill(dt);
                string[] songInfo = new string[dt.Rows.Count];
                for (int i = 0; i < dt.Columns.Count; i++)
                    songInfo[i] = (dt.Rows[i][0]).ToString();
                return songInfo;*/
            }
        }

        public static void UpdateReview(String username, String mediaFilepath, int rating, String content)
        {
            using (SqlConnection sqlConn = new SqlConnection(connString))
            {
                if (content == null) content = "";
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand("UpdateReview", sqlConn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.Add("@User", SqlDbType.VarChar).Value = username;
                cmd.Parameters.Add("@MedFP", SqlDbType.VarChar).Value = mediaFilepath;
                cmd.Parameters.Add("@Rate", SqlDbType.Int).Value = rating;
                cmd.Parameters.Add("@Cont", SqlDbType.Text).Value = content;
                cmd.ExecuteNonQuery();
                sqlConn.Close();
            }
        }

        public static int GetCurrentRating(String username, String mediaFilepath)
        {
            int result = 1;
            using (SqlConnection sqlConn = new SqlConnection(connString))
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand("GetCurrentRating", sqlConn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.Add("@User", SqlDbType.VarChar).Value = username;
                cmd.Parameters.Add("@MedFP", SqlDbType.VarChar).Value = mediaFilepath;
                cmd.Parameters.Add(new SqlParameter("@Rate", SqlDbType.Int));
                cmd.Parameters["@Rate"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                result = (int)cmd.Parameters["@Rate"].Value;
                sqlConn.Close();
            }
            return result;
        }

        public static int CheckReviewValidity(String username, String mediaFilepath)
        {
            int result = 0;
            using (SqlConnection sqlConn = new SqlConnection(connString))
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand("CheckReviewExistence", sqlConn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.Add("@User", SqlDbType.VarChar).Value = username;
                cmd.Parameters.Add("@MedFP", SqlDbType.VarChar).Value = mediaFilepath;
                cmd.Parameters.Add(new SqlParameter("@out", SqlDbType.Int));
                cmd.Parameters["@out"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                result = (int)cmd.Parameters["@out"].Value;
                sqlConn.Close();
            }
            return result;
        }


    }
}
