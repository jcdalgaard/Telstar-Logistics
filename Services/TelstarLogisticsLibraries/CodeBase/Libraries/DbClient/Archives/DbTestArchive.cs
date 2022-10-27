using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelstarLogistics.DbClient.Archives.Interfaces;

namespace TelstarLogistics.DbClient.Archives
{
    public class DbTestArchive: IDbTestArchive
    {
        private readonly IDbClient _dbClient;

        public DbTestArchive(IDbClient dbClient)
        {
            _dbClient = dbClient;
        }
        public void Test()
        {
            Console.WriteLine("DB works!");
            _dbClient.RunCommand("SELECT * from dbo.UserRole");
        }
    }
}
