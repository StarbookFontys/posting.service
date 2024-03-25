using MySql.Data.MySqlClient;
using posting_service.Interfaces;

namespace posting_service.DatabaseCom
{
	public class PostingHandler
	{
		private IConnection con;

		public PostingHandler(IConnection _con) 
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
	}
}
