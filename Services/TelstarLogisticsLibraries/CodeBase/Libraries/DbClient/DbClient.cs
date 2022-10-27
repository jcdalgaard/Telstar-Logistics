using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelstarLogistics.DbClient.Setup;

namespace TelstarLogistics.DbClient
{
    public class DbClient: IDbClient
    {
        private readonly IOptions<DbSettings> _dbSettings;

        public DbClient(IOptions<DbSettings> dbSettings)
        {
            _dbSettings = dbSettings;
        }

        public void RunCommand(string queryString)
        {
            SqlConnection cnn;

            cnn = new SqlConnection(_dbSettings.Value.ConnectionString);
            cnn.Open();
            SqlCommand command = new SqlCommand(
            queryString, cnn);
            Console.WriteLine("Connection Open");
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine(String.Format("{0}, {1}",
                        reader[0], reader[1]));
                }
            }
            cnn.Close();
        }
    }
}
