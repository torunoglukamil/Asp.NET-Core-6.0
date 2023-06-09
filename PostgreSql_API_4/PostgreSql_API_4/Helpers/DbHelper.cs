using Newtonsoft.Json;
using Npgsql;
using PostgreSql_API_4.Models;
using System.Data;

namespace PostgreSql_API_4.Helpers
{
    public class DbHelper
    {
        private readonly NpgsqlConnection _connection;

        public DbHelper(IConfiguration configuration)
        {
            _connection = new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }

        public ResponseModel SelectQuery(string query)
        {
            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(query, _connection);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                return new ResponseModel()
                {
                    Type = ResponseType.Success,
                    Data = JsonConvert.SerializeObject(dataTable),
                };
            }
            catch (Exception e)
            {
                return new ResponseModel()
                {
                    Type = ResponseType.Failure,
                    Data = e.Message,
                };
            }

        }
    }
}
