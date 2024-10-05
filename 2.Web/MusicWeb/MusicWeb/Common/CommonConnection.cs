using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using System.Xml.Linq;

namespace MusicWeb.Models
{
    public class CommonConnection
    {
        public string connectionString = "";
        public IEnumerable<AdminUserModel> GetUsers()
        {
            string connectionString = "Data Source=.;Initial Catalog=QL_WebNgheNhac;" + "Integrated Security=true";

            // Provide the query string with a parameter placeholder.
            string queryString = "SELECT * from dbo.AdminUser";
            var users = new List<AdminUserModel>();

            // Specify the parameter value.
            // Create and open the connection in a using block. This
            // ensures that all resources will be closed and disposed
            // when the code exits.
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                // Create the Command and Parameter objects.
                SqlCommand command = new SqlCommand(queryString, connection);
                //command.Parameters.AddWithValue("@pricePoint", paramValue);

                // Open the connection in a try/catch block.
                // Create and execute the DataReader, writing the result
                // set to the console window.
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var user = new AdminUserModel();
                        user.ID = int.Parse(reader["ID"].ToString());
                        user.NameUser = reader["NameUser"].ToString();
                        user.EmailUser = reader["EmailUser"].ToString();
                        user.RoleUser = reader["RoleUser"].ToString();
                        user.PasswordUser = reader["PasswordUser"].ToString();
                        users.Add(user);
                    }
                    reader.Close();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    connection.Close();
                }
            }
            return users;
        }

        public AdminUserModel GetUsersById(int id)
        {
            string connectionString = "Data Source=.;Initial Catalog=QL_WebNgheNhac;" + "Integrated Security=true";

            // Provide the query string with a parameter placeholder.
            string queryString = string.Format("SELECT * from dbo.AdminUser where Id = {0} ", id);
            var users = new List<AdminUserModel>();

            // Specify the parameter value.
            // Create and open the connection in a using block. This
            // ensures that all resources will be closed and disposed
            // when the code exits.
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                // Create the Command and Parameter objects.
                SqlCommand command = new SqlCommand(queryString, connection);
                //command.Parameters.AddWithValue("@pricePoint", paramValue);

                // Open the connection in a try/catch block.
                // Create and execute the DataReader, writing the result
                // set to the console window.
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var user = new AdminUserModel();
                        user.ID = int.Parse(reader["ID"].ToString());
                        user.NameUser = reader["NameUser"].ToString();
                        user.EmailUser = reader["EmailUser"].ToString();
                        user.RoleUser = reader["RoleUser"].ToString();
                        user.PasswordUser = reader["PasswordUser"].ToString();
                        users.Add(user);
                    }
                    reader.Close();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    connection.Close();
                }
            }
            return users.FirstOrDefault();
        }


        public AdminUserModel AuthUser(string username, string password)
        {
            string connectionString = "Data Source=.;Initial Catalog=QL_WebNgheNhac;" + "Integrated Security=true";

            // Provide the query string with a parameter placeholder.
            string queryString = "SELECT * from dbo.AdminUser where NameUser = @name  AND PasswordUser = @pass";
            var users = new List<AdminUserModel>();

            // Specify the parameter value.
            // Create and open the connection in a using block. This
            // ensures that all resources will be closed and disposed
            // when the code exits.
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                // Create the Command and Parameter objects.
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@name", username);
                command.Parameters.AddWithValue("@pass", password);

                // Open the connection in a try/catch block.
                // Create and execute the DataReader, writing the result
                // set to the console window.
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var user = new AdminUserModel();
                        user.ID = int.Parse(reader["ID"].ToString());
                        user.NameUser = reader["NameUser"].ToString();
                        user.PasswordUser = reader["PasswordUser"].ToString();
                        user.RoleUser = reader["RoleUser"].ToString();
                        users.Add(user);
                    }
                    reader.Close();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    connection.Close();
                }
            }
            return users[0];
        }

        public void AddAdminUser(AdminUserModel person)
        {
            string connectionString = "Data Source=.;Initial Catalog=QL_WebNgheNhac;" + "Integrated Security=true";
            // Provide the query string with a parameter placeholder.
            string queryString = "INSERT INTO AdminUser (NameUser, EmailUser, RoleUser, PasswordUser) VALUES (@username,@email,@role,@pass)";
            var users = new List<AdminUserModel>();

            // Specify the parameter value.
            // Create and open the connection in a using block. This
            // ensures that all resources will be closed and disposed
            // when the code exits.
            try
            {
                using (SqlConnection connection =
                    new SqlConnection(connectionString))
                {
                    connection.Open();
                    // Create the Command and Parameter objects.
                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.Parameters.AddWithValue("@username", person.NameUser);
                    command.Parameters.AddWithValue("@email", person.EmailUser);
                    command.Parameters.AddWithValue("@role", person.RoleUser);
                    command.Parameters.AddWithValue("@pass", person.PasswordUser);
                    command.ExecuteNonQuery();
                    // Open the connection in a try/catch block.
                    // Create and execute the DataReader, writing the result
                    // set to the console window.
                    connection.Close();

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void EditAdminUser(AdminUserModel person)
        {
            string connectionString = "Data Source=.;Initial Catalog=QL_WebNgheNhac;" + "Integrated Security=true";
            // Provide the query string with a parameter placeholder.
            string queryString = "UPDATE dbo.AdminUser SET NameUser = @username, EmailUser= @email,RoleUser=@role,PasswordUser=@pass WHERE ID = @id;";
            var users = new List<AdminUserModel>();

            // Specify the parameter value.
            // Create and open the connection in a using block. This
            // ensures that all resources will be closed and disposed
            // when the code exits.
            try
            {
                using (SqlConnection connection =
                    new SqlConnection(connectionString))
                {
                    connection.Open();
                    // Create the Command and Parameter objects.
                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.Parameters.AddWithValue("@username", person.NameUser);
                    command.Parameters.AddWithValue("@email", person.EmailUser);
                    command.Parameters.AddWithValue("@role", person.RoleUser);
                    command.Parameters.AddWithValue("@pass", person.PasswordUser);
                    command.Parameters.AddWithValue("@id", person.ID);
                    command.ExecuteNonQuery();
                    // Open the connection in a try/catch block.
                    // Create and execute the DataReader, writing the result
                    // set to the console window.
                    connection.Close();

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void DeleteAdminUser(AdminUserModel person)
        {
            string connectionString = "Data Source=.;Initial Catalog=QL_WebNgheNhac;" + "Integrated Security=true";
            // Provide the query string with a parameter placeholder.
            string queryString = "DELETE FROM dbo.AdminUser WHERE ID=@id;";
            var users = new List<AdminUserModel>();

            // Specify the parameter value.
            // Create and open the connection in a using block. This
            // ensures that all resources will be closed and disposed
            // when the code exits.
            try
            {
                using (SqlConnection connection =
                    new SqlConnection(connectionString))
                {
                    connection.Open();
                    // Create the Command and Parameter objects.
                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.Parameters.AddWithValue("@id", person.ID);
                    command.ExecuteNonQuery();
                    // Open the connection in a try/catch block.
                    // Create and execute the DataReader, writing the result
                    // set to the console window.
                    connection.Close();

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public IEnumerable<SelectListItem> GetCatergoryDropdownList()
        {
            string connectionString = "Data Source=.;Initial Catalog=QL_WebNgheNhac;" + "Integrated Security=true";

            // Provide the query string with a parameter placeholder.
            string queryString = "SELECT * FROM Catergory";
            var cates = new List<SelectListItem>();

            // Specify the parameter value.
            // Create and open the connection in a using block. This
            // ensures that all resources will be closed and disposed
            // when the code exits.
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                // Create the Command and Parameter objects.
                SqlCommand command = new SqlCommand(queryString, connection);
                //command.Parameters.AddWithValue("@pricePoint", paramValue);

                // Open the connection in a try/catch block.
                // Create and execute the DataReader, writing the result
                // set to the console window.
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var cate = new SelectListItem();
                        cate.Value = reader["ID_Catergory"].ToString();
                        cate.Text = reader["Name_Catergory"].ToString();
                        cates.Add(cate);
                    }
                    reader.Close();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.Message);
                    connection.Close();
                }
            }
            return cates;
        }
        public IEnumerable<SelectListItem> GetSingerList()
        {
            string connectionString = "Data Source=.;Initial Catalog=QL_WebNgheNhac;" + "Integrated Security=true";

            // Provide the query string with a parameter placeholder.
            string queryString = "SELECT * FROM Singer";
            var singers = new List<SelectListItem>();

            // Specify the parameter value.
            // Create and open the connection in a using block. This
            // ensures that all resources will be closed and disposed
            // when the code exits.
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                // Create the Command and Parameter objects.
                SqlCommand command = new SqlCommand(queryString, connection);
                //command.Parameters.AddWithValue("@pricePoint", paramValue);

                // Open the connection in a try/catch block.
                // Create and execute the DataReader, writing the result
                // set to the console window.
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var singer = new SelectListItem();
                        singer.Value = reader["ID_Singer"].ToString();
                        singer.Text = reader["Name_singer"].ToString();
                        singers.Add(singer);
                    }
                    reader.Close();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.Message);
                    connection.Close();
                }
            }
            return singers;
        }
        public IEnumerable<Song> GetSongs()
        {
            string connectionString = "Data Source=.;Initial Catalog=QL_WebNgheNhac;" + "Integrated Security=true";

            // Provide the query string with a parameter placeholder.
            string queryString = "SELECT * FROM Song INNER  JOIN Singer ON Song.ID_Singer = Singer.ID_Singer;";
            var songs = new List<Song>();

            // Specify the parameter value.
            // Create and open the connection in a using block. This
            // ensures that all resources will be closed and disposed
            // when the code exits.
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                // Create the Command and Parameter objects.
                SqlCommand command = new SqlCommand(queryString, connection);
                //command.Parameters.AddWithValue("@pricePoint", paramValue);

                // Open the connection in a try/catch block.
                // Create and execute the DataReader, writing the result
                // set to the console window.
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var song = new Song();
                        song.ID_Song = int.Parse(reader["ID_Song"].ToString());
                        song.Name_Song = reader["Name_Song"].ToString();
                        song.ID_Catergory = int.Parse(reader["ID_Catergory"].ToString());
                        song.Release_Date = DateTime.Parse(reader["Release_Date"].ToString());
                        song.Audio_Song = reader["Audio_Song"].ToString();
                        song.ImageSong = reader["ImageSong"].ToString();
                        song.View_Song = int.Parse(reader["View_Song"].ToString());
                        song.ID_Singer = int.Parse(reader["ID_Singer"].ToString());
                        song.Name_singer = reader["Name_singer"].ToString();
                        songs.Add(song);
                    }
                    reader.Close();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.Message);
                    connection.Close();
                }
            }
            return songs;
        }
        public IEnumerable<Song> GetSongsSearch(string name)
        {
            string connectionString = "Data Source=.;Initial Catalog=QL_WebNgheNhac;" + "Integrated Security=true";

            // Provide the query string with a parameter placeholder.
            string queryString = "SELECT * FROM Song INNER  JOIN Singer ON Song.ID_Singer = Singer.ID_Singer WHERE Name_Song LIKE N'%" + name + "%' ORDER BY View_Song DESC";
            var songs = new List<Song>();

            // Specify the parameter value.
            // Create and open the connection in a using block. This
            // ensures that all resources will be closed and disposed
            // when the code exits.
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                // Create the Command and Parameter objects.
                SqlCommand command = new SqlCommand(queryString, connection);
                /*command.Parameters.AddWithValue("@name", name);*/

                // Open the connection in a try/catch block.
                // Create and execute the DataReader, writing the result
                // set to the console window.
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var song = new Song();
                        song.ID_Song = int.Parse(reader["ID_Song"].ToString());
                        song.Name_Song = reader["Name_Song"].ToString();
                        song.ID_Catergory = int.Parse(reader["ID_Catergory"].ToString());
                        song.Release_Date = DateTime.Parse(reader["Release_Date"].ToString());
                        song.Audio_Song = reader["Audio_Song"].ToString();
                        song.ImageSong = reader["ImageSong"].ToString();
                        song.View_Song = int.Parse(reader["View_Song"].ToString());
                        song.ID_Singer = int.Parse(reader["ID_Singer"].ToString());
                        Singer singer = new Singer();
                        song.Name_singer = reader["Name_singer"].ToString();
                        songs.Add(song);
                    }
                    reader.Close();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    connection.Close();
                }
            }
            return songs;
        }
        public IEnumerable<Song> OrderBySongs(string name)
        {
            string connectionString = "Data Source=.;Initial Catalog=QL_WebNgheNhac;" + "Integrated Security=true";

            // Provide the query string with a parameter placeholder.
            string queryString = "SELECT * FROM Song ORDER BY Name_Song;";
            var songs = new List<Song>();

            // Specify the parameter value.
            // Create and open the connection in a using block. This
            // ensures that all resources will be closed and disposed
            // when the code exits.
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                // Create the Command and Parameter objects.
                SqlCommand command = new SqlCommand(queryString, connection);
                /*command.Parameters.AddWithValue("@name", name);*/

                // Open the connection in a try/catch block.
                // Create and execute the DataReader, writing the result
                // set to the console window.
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var song = new Song();
                        song.ID_Song = int.Parse(reader["ID_Song"].ToString());
                        song.Name_Song = reader["Name_Song"].ToString();
                        song.ID_Catergory = int.Parse(reader["ID_Catergory"].ToString());
                        song.Release_Date = DateTime.Parse(reader["Release_Date"].ToString());
                        song.Audio_Song = reader["Audio_Song"].ToString();
                        song.ImageSong = reader["ImageSong"].ToString();
                        song.View_Song = int.Parse(reader["View_Song"].ToString());
                        song.ID_Singer = int.Parse(reader["ID_Singer"].ToString());
                        Singer singer = new Singer();
                        song.Name_singer = reader["Name_singer"].ToString();
                        songs.Add(song);
                    }
                    reader.Close();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    connection.Close();
                }
            }
            return songs;
        }
        public IEnumerable<Song> GetSongsTop100()
        {
            string connectionString = "Data Source=.;Initial Catalog=QL_WebNgheNhac;" + "Integrated Security=true";

            // Provide the query string with a parameter placeholder.
            string queryString = "SELECT * FROM Song INNER  JOIN Singer ON Song.ID_Singer = Singer.ID_Singer ORDER BY View_Song DESC";
            var songs = new List<Song>();

            // Specify the parameter value.
            // Create and open the connection in a using block. This
            // ensures that all resources will be closed and disposed
            // when the code exits.
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                // Create the Command and Parameter objects.
                SqlCommand command = new SqlCommand(queryString, connection);
                //command.Parameters.AddWithValue("@pricePoint", paramValue);

                // Open the connection in a try/catch block.
                // Create and execute the DataReader, writing the result
                // set to the console window.
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var song = new Song();
                        song.ID_Song = int.Parse(reader["ID_Song"].ToString());
                        song.Name_Song = reader["Name_Song"].ToString();
                        song.ID_Catergory = int.Parse(reader["ID_Catergory"].ToString());
                        song.Release_Date = DateTime.Parse(reader["Release_Date"].ToString());
                        song.Audio_Song = reader["Audio_Song"].ToString();
                        song.ImageSong = reader["ImageSong"].ToString();
                        song.View_Song = int.Parse(reader["View_Song"].ToString());
                        song.ID_Singer = int.Parse(reader["ID_Singer"].ToString());
                        Singer singer = new Singer();
                        song.Name_singer = reader["Name_singer"].ToString();
                        songs.Add(song);
                    }
                    reader.Close();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    connection.Close();
                }
            }
            return songs;
        }





        public SongViewModel GetSongById(int id)
        {
            string connectionString = "Data Source=.;Initial Catalog=QL_WebNgheNhac;" + "Integrated Security=true";

            // Provide the query string with a parameter placeholder.
            string queryString ="select * from dbo.Song where ID_Song=@id";
            var songs = new List<SongViewModel>();

            // Specify the parameter value.
            // Create and open the connection in a using block. This
            // ensures that all resources will be closed and disposed
            // when the code exits.
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                // Create the Command and Parameter objects.
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@id", id);

                // Open the connection in a try/catch block.
                // Create and execute the DataReader, writing the result
                // set to the console window.
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var songView = new SongViewModel();
                        var song = new Song();        

                        song.ID_Song = int.Parse(reader["ID_Song"].ToString());
                        song.Name_Song = reader["Name_Song"].ToString();
                        song.ID_Catergory = int.Parse(reader["ID_Catergory"].ToString());
                        song.Release_Date = DateTime.Parse(reader["Release_Date"].ToString());
                        song.Audio_Song = reader["Audio_Song"].ToString();
                        song.ImageSong = reader["ImageSong"].ToString();
                        song.View_Song = int.Parse(reader["View_Song"].ToString());
                        song.ID_Singer = int.Parse(reader["ID_Singer"].ToString());

                        songView.song = song;
                        songs.Add(songView);

                    }
                    reader.Close();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    connection.Close();
                }
            }
            return songs.FirstOrDefault();
        }
        public void AddSong(SongViewModel songview)
        {
            string connectionString = "Data Source=.;Initial Catalog=QL_WebNgheNhac;" + "Integrated Security=true";
            // Provide the query string with a parameter placeholder.
            string queryString = "Insert into Song(Name_Song,ID_Catergory,Release_Date,Audio_Song,ImageSong,View_Song,Id_Singer) VALUES (@name,@catergory,@date_release,@audio,@image,@view,@Idsinger)";
            // Specify the parameter value.
            // Create and open the connection in a using block. This
            // ensures that all resources will be closed and disposed
            // when the code exits.
            try
            {
                using (SqlConnection connection =
                    new SqlConnection(connectionString))
                {
                    connection.Open();
                    // Create the Command and Parameter objects.
                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.Parameters.AddWithValue("@name", songview.song.Name_Song);
                    command.Parameters.AddWithValue("@catergory", songview.song.ID_Catergory);
                    command.Parameters.AddWithValue("@date_release", songview.song.Release_Date);
                    command.Parameters.AddWithValue("@audio", songview.song.Audio_Song);
                    command.Parameters.AddWithValue("@image", songview.song.ImageSong);
                    command.Parameters.AddWithValue("@view", songview.song.View_Song);
                    command.Parameters.AddWithValue("@Idsinger", songview.song.ID_Singer);
                    command.ExecuteNonQuery();
                    // Open the connection in a try/catch block.
                    // Create and execute the DataReader, writing the result
                    // set to the console window.
                    connection.Close();

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void UpdateViewSong(int id)
        {
            string connectionString = "Data Source=.;Initial Catalog=QL_WebNgheNhac;" + "Integrated Security=true";
            // Provide the query string with a parameter placeholder.
            string queryString = "UPDATE Song SET View_Song = View_Song + 1 WHERE ID_Song = @id;";
            var users = new List<AdminUserModel>();

            // Specify the parameter value.
            // Create and open the connection in a using block. This
            // ensures that all resources will be closed and disposed
            // when the code exits.
            try
            {
                using (SqlConnection connection =
                    new SqlConnection(connectionString))
                {
                    connection.Open();
                    // Create the Command and Parameter objects.
                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.Parameters.AddWithValue("@id", id);

                    command.ExecuteNonQuery();
                    // Open the connection in a try/catch block.
                    // Create and execute the DataReader, writing the result
                    // set to the console window.
                    connection.Close();

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void EditSong(SongViewModel songView)
        {
            string connectionString = "Data Source=.;Initial Catalog=QL_WebNgheNhac;" + "Integrated Security=true";
            // Provide the query string with a parameter placeholder.
            string queryString = "UPDATE Song SET Name_Song = @name, ID_Catergory = @catergory, Release_Date= @date,Audio_Song= @audio,ImageSong= @image,View_Song=@view,ID_Singer=@idsinger WHERE ID_Song= @idsong;";
            var users = new List<AdminUserModel>();

            // Specify the parameter value.
            // Create and open the connection in a using block. This
            // ensures that all resources will be closed and disposed
            // when the code exits.
            try
            {
                using (SqlConnection connection =
                    new SqlConnection(connectionString))
                {
                    connection.Open();
                    // Create the Command and Parameter objects.
                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.Parameters.AddWithValue("@name", songView.song.Name_Song);
                    command.Parameters.AddWithValue("@catergory", songView.song.ID_Catergory);
                    command.Parameters.AddWithValue("@date", songView.song.Release_Date);
                    command.Parameters.AddWithValue("@audio", songView.song.Audio_Song);
                    command.Parameters.AddWithValue("@image", songView.song.ImageSong);
                    command.Parameters.AddWithValue("@view", songView.song.View_Song);
                    command.Parameters.AddWithValue("@idsinger", songView.song.ID_Singer);
                    command.Parameters.AddWithValue("@idsong", songView.song.ID_Song);
                    command.ExecuteNonQuery();
                    // Open the connection in a try/catch block.
                    // Create and execute the DataReader, writing the result
                    // set to the console window.
                    connection.Close();

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void DeleteSong(int ID_Song)
        {
            string connectionString = "Data Source=.;Initial Catalog=QL_WebNgheNhac;" + "Integrated Security=true";
            // Provide the query string with a parameter placeholder.
            string queryString = "DELETE FROM [dbo].[Song] WHERE ID_Song=@id";
            // Specify the parameter value.
            // Create and open the connection in a using block. This
            // ensures that all resources will be closed and disposed
            // when the code exits.
            try
            {
                using (SqlConnection connection =
                    new SqlConnection(connectionString))
                {
                    connection.Open();
                    // Create the Command and Parameter objects.
                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.Parameters.AddWithValue("@id", ID_Song);
                    command.ExecuteNonQuery();
                    // Open the connection in a try/catch block.
                    // Create and execute the DataReader, writing the result
                    // set to the console window.
                    connection.Close();

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        
        public IEnumerable<Singer> GetSinger()
        {
            string connectionString = "Data Source=.;Initial Catalog=QL_WebNgheNhac;" + "Integrated Security=true";

            // Provide the query string with a parameter placeholder.
            string queryString = "SELECT * from dbo.Singer";
            var singers = new List<Singer>();

            // Specify the parameter value.
            // Create and open the connection in a using block. This
            // ensures that all resources will be closed and disposed
            // when the code exits.
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                // Create the Command and Parameter objects.
                SqlCommand command = new SqlCommand(queryString, connection);
                //command.Parameters.AddWithValue("@pricePoint", paramValue);

                // Open the connection in a try/catch block.
                // Create and execute the DataReader, writing the result
                // set to the console window.
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var singer = new Singer();
                        singer.ID_Singer = int.Parse(reader["ID_Singer"].ToString());
                        singer.Name_singer = reader["Name_Singer"].ToString();
                        singer.Story = reader["Story"].ToString();
                        singer.View_moth = int.Parse(reader["View_moth"].ToString());
                        singer.ImageSinger = reader["imgSinger"].ToString();
                        singers.Add(singer);
                    }
                    reader.Close();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    connection.Close();
                }
            }
            return singers;
        }
        public Singer GetSingerById(int id)
        {
            string connectionString = "Data Source=.;Initial Catalog=QL_WebNgheNhac;" + "Integrated Security=true";

            // Provide the query string with a parameter placeholder.
            string queryString = string.Format("SELECT * from dbo.Singer where ID_Singer = {0} ", id);
            var singers = new List<Singer>();

            // Specify the parameter value.
            // Create and open the connection in a using block. This
            // ensures that all resources will be closed and disposed
            // when the code exits.
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                // Create the Command and Parameter objects.
                SqlCommand command = new SqlCommand(queryString, connection);
                //command.Parameters.AddWithValue("@pricePoint", paramValue);

                // Open the connection in a try/catch block.
                // Create and execute the DataReader, writing the result
                // set to the console window.
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var singer = new Singer();
                        singer.ID_Singer = int.Parse(reader["ID_Singer"].ToString());
                        singer.Name_singer = reader["Name_Singer"].ToString();
                        singer.Story = reader["Story"].ToString();
                        singer.View_moth = int.Parse(reader["View_moth"].ToString());
                        singer.ImageSinger = reader["imgSinger"].ToString();
                        singers.Add(singer);
                    }
                    reader.Close();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    connection.Close();
                }
            }
            return singers.FirstOrDefault();
        }
        public void AddSinger(Singer singer)
        {
            string connectionString = "Data Source=.;Initial Catalog=QL_WebNgheNhac;" + "Integrated Security=true";
            // Provide the query string with a parameter placeholder.
            string queryString = "Insert into Singer(Name_singer,Story,View_moth,ImgSinger) VALUES (@name,@story,@view,@img)";
            var singers = new List<Singer>();

            // Specify the parameter value.
            // Create and open the connection in a using block. This
            // ensures that all resources will be closed and disposed
            // when the code exits.
            try
            {
                using (SqlConnection connection =
                    new SqlConnection(connectionString))
                {
                    connection.Open();
                    // Create the Command and Parameter objects.
                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.Parameters.AddWithValue("@name", singer.Name_singer);
                    command.Parameters.AddWithValue("@story", singer.Story);
                    command.Parameters.AddWithValue("@view", singer.View_moth);
                    command.Parameters.AddWithValue("@img", singer.ImageSinger);
                    command.ExecuteNonQuery();
                    // Open the connection in a try/catch block.
                    // Create and execute the DataReader, writing the result
                    // set to the console window.
                    connection.Close();

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public IEnumerable<Catergory> GetListCatergory()
        {
            string connectionString = "Data Source=.;Initial Catalog=QL_WebNgheNhac;" + "Integrated Security=true";

            // Provide the query string with a parameter placeholder.
            string queryString = "select * from dbo.Catergory";
            var cates = new List<Catergory>();

            // Specify the parameter value.
            // Create and open the connection in a using block. This
            // ensures that all resources will be closed and disposed
            // when the code exits.
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                // Create the Command and Parameter objects.
                SqlCommand command = new SqlCommand(queryString, connection);
                //command.Parameters.AddWithValue("@pricePoint", paramValue);

                // Open the connection in a try/catch block.
                // Create and execute the DataReader, writing the result
                // set to the console window.
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var cate = new Catergory();
                        cate.ID_Catergory = int.Parse(reader["ID_Catergory"].ToString());
                        cate.Name_Catergory = reader["Name_Catergory"].ToString();
                        cates.Add(cate);
                    }
                    reader.Close();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    connection.Close();
                }
            }
            return cates;
        }
        public void DeleteSinger(int ID_Song)
        {
            string connectionString = "Data Source=.;Initial Catalog=QL_WebNgheNhac;" + "Integrated Security=true";
            // Provide the query string with a parameter placeholder.
            string queryString = "DELETE FROM [dbo].[Singer] WHERE ID_Singer=@id";
            // Specify the parameter value.
            // Create and open the connection in a using block. This
            // ensures that all resources will be closed and disposed
            // when the code exits.
            try
            {
                using (SqlConnection connection =
                    new SqlConnection(connectionString))
                {
                    connection.Open();
                    // Create the Command and Parameter objects.
                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.Parameters.AddWithValue("@id", ID_Song);
                    command.ExecuteNonQuery();
                    // Open the connection in a try/catch block.
                    // Create and execute the DataReader, writing the result
                    // set to the console window.
                    connection.Close();

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void AddLibrary(int idsong, int iduser)
        {
            string connectionString = "Data Source=.;Initial Catalog=QL_WebNgheNhac;" + "Integrated Security=true";
            // Provide the query string with a parameter placeholder.
            string queryString = "Insert Into Library_Music (ID_Song,ID_AdminUser) Values (@idsong,@iduser)";
            // Specify the parameter value.
            // Create and open the connection in a using block. This
            // ensures that all resources will be closed and disposed
            // when the code exits.
            try
            {
                using (SqlConnection connection =
                    new SqlConnection(connectionString))
                {
                    connection.Open();
                    // Create the Command and Parameter objects.
                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.Parameters.AddWithValue("@idsong", idsong);
                    command.Parameters.AddWithValue("@iduser", iduser);
                    command.ExecuteNonQuery();
                    connection.Close();

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public IEnumerable<LibraryModel> GetLibrary()
        {
            string connectionString = "Data Source=.;Initial Catalog=QL_WebNgheNhac;" + "Integrated Security=true";

            // Provide the query string with a parameter placeholder.
            string queryString = "Select * From Library_Music INNER JOIN Song ON Song.ID_Song = Library_Music.ID_Song JOIN Singer ON  Song.ID_Singer = Singer.ID_Singer";
            var lbs = new List<LibraryModel>();

            // Specify the parameter value.
            // Create and open the connection in a using block. This
            // ensures that all resources will be closed and disposed
            // when the code exits.
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                // Create the Command and Parameter objects.
                SqlCommand command = new SqlCommand(queryString, connection);
                //command.Parameters.AddWithValue("@pricePoint", paramValue);

                // Open the connection in a try/catch block.
                // Create and execute the DataReader, writing the result
                // set to the console window.
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var lb = new LibraryModel();
                        lb.ID_Library = int.Parse(reader["ID_Library"].ToString());
                        lb.ID_AdminUser = int.Parse(reader["ID_AdminUser"].ToString());
                        lb.ID_Song = int.Parse(reader["ID_Song"].ToString());
                        lb.song.Name_Song = reader["Name_Song"].ToString();
                        lb.song.ID_Catergory = int.Parse(reader["ID_Catergory"].ToString());
                        lb.song.Release_Date = DateTime.Parse(reader["Release_Date"].ToString());
                        lb.song.Audio_Song = reader["Audio_Song"].ToString();
                        lb.song.ImageSong = reader["ImageSong"].ToString();
                        lb.song.View_Song = int.Parse(reader["View_Song"].ToString());
                        lb.song.ID_Singer = int.Parse(reader["ID_Singer"].ToString());
                        lb.song.Name_singer = reader["Name_singer"].ToString();
                        lbs.Add(lb);
                    }
                    reader.Close();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    connection.Close();
                }
            }
            return lbs;
        }
        public List<LibraryModel> checkSongExist(int ID_Song, int ID_AdminUser)
        {
            string connectionString = "Data Source=.;Initial Catalog=QL_WebNgheNhac;" + "Integrated Security=true";

            // Provide the query string with a parameter placeholder.
            string queryString = "SELECT * from Library_Music where ID_Song = @idsong  AND ID_AdminUser = @iduser";
            // Specify the parameter value.
            // Create and open the connection in a using block. This
            // ensures that all resources will be closed and disposed
            // when the code exits.
            var lbs = new List<LibraryModel>();
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                // Create the Command and Parameter objects.
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@idsong", ID_Song);
                command.Parameters.AddWithValue("@iduser", ID_AdminUser);
                // Open the connection in a try/catch block.
                // Create and execute the DataReader, writing the result
                // set to the console window.
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var lb = new LibraryModel();
                        lb.ID_Library = int.Parse(reader["ID_Library"].ToString());
                        lb.ID_Song = int.Parse(reader["ID_Song"].ToString());
                        lb.ID_AdminUser = int.Parse(reader["ID_AdminUser"].ToString());
                        lbs.Add(lb);
                    }
                    reader.Close();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    connection.Close();
                }
            }
            return lbs;

        }
        public void deleteSongInLibrary(int ID_Library)
        {
            string connectionString = "Data Source=.;Initial Catalog=QL_WebNgheNhac;" + "Integrated Security=true";
            // Provide the query string with a parameter placeholder.
            string queryString = "DELETE FROM dbo.Library_Music WHERE ID_Library=@id;";
            var users = new List<AdminUserModel>();

            // Specify the parameter value.
            // Create and open the connection in a using block. This
            // ensures that all resources will be closed and disposed
            // when the code exits.
            try
            {
                using (SqlConnection connection =
                    new SqlConnection(connectionString))
                {
                    connection.Open();
                    // Create the Command and Parameter objects.
                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.Parameters.AddWithValue("@id", ID_Library);
                    command.ExecuteNonQuery();
                    // Open the connection in a try/catch block.
                    // Create and execute the DataReader, writing the result
                    // set to the console window.
                    connection.Close();

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void EditSinger(Singer singer)
         {
            string connectionString = "Data Source=.;Initial Catalog=QL_WebNgheNhac;" + "Integrated Security=true";
            // Provide the query string with a parameter placeholder.
            string queryString = "UPDATE dbo.Singer SET Name_singer = @name, Story= @story,View_moth=@view,ImgSinger=@img WHERE ID_Singer = @id;";
            // Specify the parameter value.
            // Create and open the connection in a using block. This
            // ensures that all resources will be closed and disposed
            // when the code exits.
            try
            {
                using (SqlConnection connection =
                    new SqlConnection(connectionString))
                {
                    connection.Open();
                    // Create the Command and Parameter objects.
                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.Parameters.AddWithValue("@name", singer.Name_singer);
                    command.Parameters.AddWithValue("@story", singer.Story);
                    command.Parameters.AddWithValue("@view", singer.View_moth);
                    command.Parameters.AddWithValue("@img", singer.ImageSinger);
                    command.Parameters.AddWithValue("@id", singer.ID_Singer);
                    command.ExecuteNonQuery();
                    // Open the connection in a try/catch block.
                    // Create and execute the DataReader, writing the result
                    // set to the console window.
                    connection.Close();

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public Song CheckSongInLibrary(int ID_User, int ID_Song)
        {
            string connectionString = "Data Source=.;Initial Catalog=QL_WebNgheNhac;" + "Integrated Security=true";

            // Provide the query string with a parameter placeholder.
            string queryString = "SELECT * FROM Song WHERE ID_Song = @idsong AND EXISTS (SELECT * FROM Library_Music WHERE Song.ID_Song = Library_Music.ID_Song And ID_AdminUser=@iduser);";
            var songs = new List<Song>();

            // Specify the parameter value.
            // Create and open the connection in a using block. This
            // ensures that all resources will be closed and disposed
            // when the code exits.
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                // Create the Command and Parameter objects.
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@idsong", ID_Song);
                command.Parameters.AddWithValue("@iduser", ID_User);

                // Open the connection in a try/catch block.
                // Create and execute the DataReader, writing the result
                // set to the console window.
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var song = new Song();
                        song.ID_Song = int.Parse(reader["ID_Song"].ToString());
                        song.Name_Song = reader["Name_Song"].ToString();
                        song.ID_Catergory = int.Parse(reader["ID_Catergory"].ToString());
                        song.Release_Date = DateTime.Parse(reader["Release_Date"].ToString());
                        song.Audio_Song = reader["Audio_Song"].ToString();
                        song.ImageSong = reader["ImageSong"].ToString();
                        song.View_Song = int.Parse(reader["View_Song"].ToString());
                        song.ID_Singer = int.Parse(reader["ID_Singer"].ToString());
                        songs.Add(song);

                    }
                    reader.Close();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    connection.Close();
                }
            }
            return songs.FirstOrDefault();
        }
        public IEnumerable<AdminUserModel> SeachAccount(string name)
        {
            string connectionString = "Data Source=.;Initial Catalog=QL_WebNgheNhac;" + "Integrated Security=true";

            // Provide the query string with a parameter placeholder.
            string queryString = "SELECT * FROM dbo.AdminUser WHERE NameUser LIKE N'%" + name + "%'";
            var acc = new List<AdminUserModel>();

            // Specify the parameter value.
            // Create and open the connection in a using block. This
            // ensures that all resources will be closed and disposed
            // when the code exits.
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                // Create the Command and Parameter objects.
                SqlCommand command = new SqlCommand(queryString, connection);
                /*command.Parameters.AddWithValue("@name", name);*/

                // Open the connection in a try/catch block.
                // Create and execute the DataReader, writing the result
                // set to the console window.
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var user = new AdminUserModel();
                        user.ID = int.Parse(reader["ID"].ToString());
                        user.NameUser = reader["NameUser"].ToString();
                        user.EmailUser = reader["EmailUser"].ToString();
                        user.RoleUser = reader["RoleUser"].ToString();
                        user.PasswordUser = reader["PasswordUser"].ToString();
                        acc.Add(user);
                    }
                    reader.Close();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    connection.Close();
                }
            }
            return acc;
        }
        public IEnumerable<AdminUserModel> OrderByNameAccount(string name)
        {
            string connectionString = "Data Source=.;Initial Catalog=QL_WebNgheNhac;" + "Integrated Security=true";

            // Provide the query string with a parameter placeholder.
            string queryString = "SELECT * FROM AdminUser ORDER BY NameUser;";
            var acc = new List<AdminUserModel>();

            // Specify the parameter value.
            // Create and open the connection in a using block. This
            // ensures that all resources will be closed and disposed
            // when the code exits.
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                // Create the Command and Parameter objects.
                SqlCommand command = new SqlCommand(queryString, connection);
                /*command.Parameters.AddWithValue("@name", name);*/

                // Open the connection in a try/catch block.
                // Create and execute the DataReader, writing the result
                // set to the console window.
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var user = new AdminUserModel();
                        user.ID = int.Parse(reader["ID"].ToString());
                        user.NameUser = reader["NameUser"].ToString();
                        user.EmailUser = reader["EmailUser"].ToString();
                        user.RoleUser = reader["RoleUser"].ToString();
                        user.PasswordUser = reader["PasswordUser"].ToString();
                        acc.Add(user);
                    }
                    reader.Close();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    connection.Close();
                }
            }
            return acc;
        }

        public IEnumerable<Singer> SeachSinger(string name)
        {
            string connectionString = "Data Source=.;Initial Catalog=QL_WebNgheNhac;" + "Integrated Security=true";

            // Provide the query string with a parameter placeholder.
            string queryString = "SELECT * FROM dbo.Singer WHERE Name_Singer LIKE N'%" + name + "%'";
            var singers = new List<Singer>();

            // Specify the parameter value.
            // Create and open the connection in a using block. This
            // ensures that all resources will be closed and disposed
            // when the code exits.
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                // Create the Command and Parameter objects.
                SqlCommand command = new SqlCommand(queryString, connection);
                /*command.Parameters.AddWithValue("@name", name);*/

                // Open the connection in a try/catch block.
                // Create and execute the DataReader, writing the result
                // set to the console window.
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var singer = new Singer();
                        singer.ID_Singer = int.Parse(reader["ID_Singer"].ToString());
                        singer.Name_singer = reader["Name_Singer"].ToString();
                        singer.Story = reader["Story"].ToString();
                        singer.View_moth = int.Parse(reader["View_moth"].ToString());
                        singer.ImageSinger = reader["imgSinger"].ToString();
                        singers.Add(singer);
                    }
                    reader.Close();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    connection.Close();
                }
            }
            return singers;
        }
        public IEnumerable<Singer> OrderByNameSinger(string name)
        {
            string connectionString = "Data Source=.;Initial Catalog=QL_WebNgheNhac;" + "Integrated Security=true";

            // Provide the query string with a parameter placeholder.
            string queryString = "SELECT * FROM Singer ORDER BY Name_Singer;";
            var singers = new List<Singer>();

            // Specify the parameter value.
            // Create and open the connection in a using block. This
            // ensures that all resources will be closed and disposed
            // when the code exits.
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                // Create the Command and Parameter objects.
                SqlCommand command = new SqlCommand(queryString, connection);
                /*command.Parameters.AddWithValue("@name", name);*/

                // Open the connection in a try/catch block.
                // Create and execute the DataReader, writing the result
                // set to the console window.
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var singer = new Singer();
                        singer.ID_Singer = int.Parse(reader["ID_Singer"].ToString());
                        singer.Name_singer = reader["Name_Singer"].ToString();
                        singer.Story = reader["Story"].ToString();
                        singer.View_moth = int.Parse(reader["View_moth"].ToString());
                        singer.ImageSinger = reader["imgSinger"].ToString();
                        singers.Add(singer);
                    }
                    reader.Close();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    connection.Close();
                }
            }
            return singers;
        }
        public IEnumerable<LibraryModel> GetLibraryAdmin()
        {
            string connectionString = "Data Source=.;Initial Catalog=QL_WebNgheNhac;" + "Integrated Security=true";
            string queryString = "SELECT * FROM Library_Music INNER JOIN Song ON Library_Music.ID_Song = Song.ID_Song INNER JOIN AdminUser ON AdminUser.ID = Library_Music.ID_AdminUser;";
            var lbs = new List<LibraryModel>();
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var lb = new LibraryModel();
                        lb.ID_Library = int.Parse(reader["ID_Library"].ToString());
                        lb.adminUser.NameUser = reader["NameUser"].ToString();
                        lb.song.Name_Song = reader["Name_Song"].ToString();
                        lb.song.Audio_Song = reader["Audio_Song"].ToString();
                        lb.song.ImageSong = reader["ImageSong"].ToString();
                        lbs.Add(lb);
                    }
                    reader.Close();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    connection.Close();
                }
            }
            return lbs;
        }
        public IEnumerable<LibraryModel> SeachLibrary(string name)
        {
            string connectionString = "Data Source=.;Initial Catalog=QL_WebNgheNhac;" + "Integrated Security=true";
            string queryString = "SELECT * FROM Library_Music INNER JOIN Song ON Library_Music.ID_Song = Song.ID_Song INNER JOIN AdminUser ON AdminUser.ID = Library_Music.ID_AdminUser AND NameUser LIKE N'%" + name + "%'";
            var lbs = new List<LibraryModel>();
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var lb = new LibraryModel();
                        lb.ID_Library = int.Parse(reader["ID_Library"].ToString());
                        lb.adminUser.NameUser = reader["NameUser"].ToString();
                        lb.song.Name_Song = reader["Name_Song"].ToString();
                        lb.song.Audio_Song = reader["Audio_Song"].ToString();
                        lb.song.ImageSong = reader["ImageSong"].ToString();
                        lbs.Add(lb);
                    }
                    reader.Close();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    connection.Close();
                }
            }
            return lbs;
        }

        public LibraryModel GetLibraryAdminByID(int id)
        {
            string connectionString = "Data Source=.;Initial Catalog=QL_WebNgheNhac;" + "Integrated Security=true";
            string queryString = "SELECT * FROM Library_Music INNER JOIN Song ON Library_Music.ID_Song = Song.ID_Song INNER JOIN AdminUser ON AdminUser.ID = Library_Music.ID_AdminUser Where ID_Library = @id;";
            var lbs = new List<LibraryModel>();
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@id", id);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    
                    while (reader.Read())
                    {
                        var lb = new LibraryModel();
                        lb.ID_Library = int.Parse(reader["ID_Library"].ToString());
                        lb.adminUser.NameUser = reader["NameUser"].ToString();
                        lb.song.Name_Song = reader["Name_Song"].ToString();
                        lb.song.Audio_Song = reader["Audio_Song"].ToString();
                        lb.song.ImageSong = reader["ImageSong"].ToString();
                        lbs.Add(lb);
                    }
                    reader.Close();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    connection.Close();
                }
            }
            return lbs.FirstOrDefault();
        }
        public void DeleteLibrary(int ID_Library)
        {
            string connectionString = "Data Source=.;Initial Catalog=QL_WebNgheNhac;" + "Integrated Security=true";
            // Provide the query string with a parameter placeholder.
            string queryString = "DELETE FROM [dbo].[Library_Music] WHERE ID_Library=@id";
            // Specify the parameter value.
            // Create and open the connection in a using block. This
            // ensures that all resources will be closed and disposed
            // when the code exits.
            try
            {
                using (SqlConnection connection =
                    new SqlConnection(connectionString))
                {
                    connection.Open();
                    // Create the Command and Parameter objects.
                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.Parameters.AddWithValue("@id", ID_Library);
                    command.ExecuteNonQuery();
                    // Open the connection in a try/catch block.
                    // Create and execute the DataReader, writing the result
                    // set to the console window.
                    connection.Close();

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}