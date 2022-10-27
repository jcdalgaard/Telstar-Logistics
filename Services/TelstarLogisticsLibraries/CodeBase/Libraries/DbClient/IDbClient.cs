using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelstarLogistics.DbClient
{
    public interface IDbClient
    {
        void RunCommand(string queryString);
    }
}
