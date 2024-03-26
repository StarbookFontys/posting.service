using MySql.Data.MySqlClient;
using posting_service.Interfaces;

namespace posting_service.DatabaseCom
{
	public class PostData : IPostData
	{
		private IConnection con;

		public PostData(IConnection _con) 
		{ 
			con = _con;
		}
		public void CreatePost(string title, string desc, string date, string author)
		{
				con.Open();

				string insertQuery = "INSERT INTO posts (title, description, post_date, author) VALUES (@title, @desc, @post_date, @author)";
				MySqlCommand command = new MySqlCommand(insertQuery, con.GetConnectionString());
				command.Parameters.AddWithValue("@title", title);
				command.Parameters.AddWithValue("@desc", desc);
				command.Parameters.AddWithValue("post_date", date);
				command.Parameters.AddWithValue("@author", author);
				command.ExecuteNonQuery();

				Console.WriteLine("Data inserted successfully.");
				con.Close();
		}

		public List<Models.PostModel> GetUserPosts(string author)
		{
			con.Open();
			List<Models.PostModel> posts = new List<Models.PostModel>();
			string GetQuery = "SELECT * FROM posts WHERE author = @Author";
			MySqlCommand command = new MySqlCommand(GetQuery, con.GetConnectionString());
			command.Parameters.AddWithValue("@Author", author);
			MySqlDataReader reader = command.ExecuteReader();
				while (reader.Read())
				{
					string postTitle = reader.GetString(reader.GetOrdinal("title"));
					string postDesc = reader.GetString(reader.GetOrdinal("description"));
					string postAuthor = reader.GetString(reader.GetOrdinal("author"));
					string postDate = Convert.ToString(reader.GetDateTime(reader.GetOrdinal("post_date")));

					posts.Add(new Models.PostModel
					{
						title = postTitle,
						Description = postDesc,
						Author = postAuthor,
						postdate = postDate
					});
				}
			con.Close();

			return posts; 
		}
	}
}
