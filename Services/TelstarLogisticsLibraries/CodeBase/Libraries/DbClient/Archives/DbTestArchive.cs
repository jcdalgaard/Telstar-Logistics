using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelstarLogistics.DbClient.Archives.Interfaces;
using TelstarLogistics.DbClient.Setup;

namespace TelstarLogistics.DbClient.Archives
{
    public class DbTestArchive: IDbTestArchive
    {
        private readonly DataContext _dataContext;

        public DbTestArchive(DataContext dataContext)
        {
            _dataContext = dataContext;
        }


        public void Test()
        {
            Console.WriteLine("DB works!");
            Console.WriteLine(_dataContext.UserRole.FirstOrDefault().Name);
        }
    }
}
