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
            String searchOn = "";
            //add ability to search other tables?
            if (tableName.Equals("SongView"))
            {
                tableName = "Song";
                searchOn = "Filepath";
            }
            else if (tableName.Equals("MediaView"))
            {
                tableName = "Media";
                searchOn = "Filepath";
            }
            else if (tableName.Equals("PlaylistView"))
            {
                tableName = "Media";
                searchOn = "Filepath";
            }
            else if (tableName.Equals("ReviewView"))
            {
                tableName = "Reviews";
                searchOn = "MediaFilepath";
            }
            else
            {
                tableName = "Media";
                searchOn = "Filepath";
            }

            if (searchKeywords.Contains(" "))
            {
                String[] arr = searchKeywords.Split(' ');
                searchKeywords = "";
                for (int i = 0; i < arr.Length; i++)
                {
                    searchKeywords += arr[i] + "%";
                }
            }
            else searchKeywords += "%";
            String query = "SELECT * FROM " + tableName + " WHERE " + searchOn + " LIKE '%" + searchKeywords + "';";
            Console.WriteLine(query);
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

        public static void uploadSong(string attributes)
        {
            //Console.WriteLine(attributes);
            string[] strings = attributes.Split('|');
            using (SqlConnection sqlConn = new SqlConnection(connString))
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand("UploadSong", sqlConn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.Add("@Filepath", SqlDbType.VarChar).Value = strings[0];
                cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = strings[1];
                cmd.Parameters.Add("@Artist", SqlDbType.VarChar).Value = strings[2];
                cmd.Parameters.Add("@Length", SqlDbType.Int).Value = strings[3];
                cmd.Parameters.Add("@Genre", SqlDbType.VarChar).Value = strings[4];
                cmd.Parameters.Add("@Uploader", SqlDbType.VarChar).Value = strings[5];
                cmd.Parameters.Add("@ReleaseDate", SqlDbType.Int).Value = strings[6];
                cmd.Parameters.Add("@AlbumFilepath", SqlDbType.VarChar).Value = strings[7];
                cmd.Parameters.Add("@TrackNo", SqlDbType.Int).Value = strings[8];
                cmd.Parameters.Add("@AlbumName", SqlDbType.VarChar).Value = strings[9];
                cmd.ExecuteNonQuery();
                sqlConn.Close();
            }
        }

        public static DataTable selectAllWhere(String tableName, String attributeName, String attributeValue)
        {
            String query = "SELECT * FROM "+tableName+" WHERE "+attributeName+" = '"+attributeValue+"'";
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
            /*
            using (SqlConnection sqlConn = new SqlConnection(connString))
            {
                string sqlQuery = @"UPDATE " + tablename + " SET " + attributes + " WHERE ";
                for (int i = 0; i < oldrow.Table.Columns.Count; i++)
                    sqlQuery += "[" + oldrow.Table.Columns[i].ColumnName + "] = '" + (oldrow[i].ToString()) + "' ";
                SqlCommand cmd = new SqlCommand(sqlQuery, sqlConn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                da.Fill(table);
                //dataGridView1.DataSource = new BindingSource(table, null);
                return table;
            }*/
            return null;

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
                Console.WriteLine(sqlQuery);
                //dataGridView1.DataSource = new BindingSource(table, null);
                return table;
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

        public static void AddPlaylist(String Username, String Name)
        {
            //Console.WriteLine("Date addpLAYLIST: " + date);
            using (SqlConnection sqlConn = new SqlConnection(connString))
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand("AddPlaylist", sqlConn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.Add("@Author", SqlDbType.VarChar).Value = Username;
                cmd.Parameters.Add("@Date", SqlDbType.DateTime).Value = DateTime.Now;
                cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = Name;
                cmd.ExecuteNonQuery();
                sqlConn.Close();
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

        public static void addFavorite(String user, String fp)
        {
            string query = "SELECT COUNT(*) FROM Likes WHERE Username ='" +
                user + "' AND MediaFilepath = '" + fp + "';";
            int count = 0;
            using (SqlConnection sqlConn = new SqlConnection(connString))
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(query, sqlConn);
                count = (int) cmd.ExecuteScalar();
                sqlConn.Close();
            }

            if (count == 0)
            {
                query = "INSERT INTO Likes (Username, MediaFilepath) VALUES('" +
                    user + "', '" + fp + "');";
                using (SqlConnection sqlConn = new SqlConnection(connString))
                {
                    SqlCommand cmd = new SqlCommand(query, sqlConn);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                }
            }
        }

        public static DataTable getFavorites(String user)
        {
            string query = "SELECT * FROM Likes JOIN Media ON Likes.MediaFilepath = Media.Filepath" +
                " WHERE Likes.Username = '" + user + "';";
            using (SqlConnection sqlConn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand(query, sqlConn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public static DataTable getMyPlaylists(String user)
        {
            string query = "SELECT * FROM Playlist WHERE Author = '" + user + "';";
            using (SqlConnection sqlConn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand(query, sqlConn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public static void follow(String user, String author, DateTime date)
        {
            string query = "SELECT COUNT(*) FROM Follows WHERE Username ='" + user + "' AND PlaylistAuthor = '"
                + author + "' AND PlaylistDateCreated = '" + date + "';";
            int count = 0;
            using (SqlConnection sqlConn = new SqlConnection(connString))
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(query, sqlConn);
                count = (int) cmd.ExecuteScalar();
                sqlConn.Close();
            }

            if (count == 0)
            {
                query = "INSERT INTO Follows (Username, PlaylistAuthor, PlaylistDateCreated) VALUES('" +
                    user + "', '" + author + "', '" + date + "');";
                using (SqlConnection sqlConn = new SqlConnection(connString))
                {
                    SqlCommand cmd = new SqlCommand(query, sqlConn);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                }
            }
        }
    }
}
