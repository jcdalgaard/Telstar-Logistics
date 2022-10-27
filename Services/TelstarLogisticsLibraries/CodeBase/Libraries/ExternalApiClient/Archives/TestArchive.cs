using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelstarLogistics.ExternalApiClient.Archives.Interfaces;

namespace TelstarLogistics.ExternalApiClient.Archives
{
    public class TestArchive: ITestArchive
    {
        public void Test()
        {
            Console.WriteLine("External client works!");
        }
    }
}
