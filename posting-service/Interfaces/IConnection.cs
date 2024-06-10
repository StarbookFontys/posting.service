using MySql.Data.MySqlClient;
using Npgsql;

namespace posting_service.Interfaces
{
	public interface IConnection
	{
		void Open();
		void Close();
		NpgsqlConnection GetConnectionString();
	}
}
