using Microsoft.AspNetCore.Connections;
using posting_service.Interfaces;
using MySql.Data.MySqlClient;

namespace posting_service.DatabaseCom
{
	public class Connection : IConnection
	{
        private MySqlConnection _connection;
        private string _ConnectionString;

        public Connection(string connectionString)
        {
            _ConnectionString = connectionString;
        }

        public void Open()
        {
            _connection = new MySqlConnection(_ConnectionString);
            _connection.Open();
        }

        public void Close()
        {
			if (_connection != null && _connection.State != System.Data.ConnectionState.Closed)
			{
				_connection.Close();
			}
		}

        public MySqlConnection GetConnectionString() { return _connection; }
	}
}
