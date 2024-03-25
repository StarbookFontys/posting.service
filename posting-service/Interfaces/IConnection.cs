using MySql.Data.MySqlClient;

namespace posting_service.Interfaces
{
	public interface IConnection
	{
		void Open();
		void Close();
		MySqlConnection GetConnectionString();
	}
}
