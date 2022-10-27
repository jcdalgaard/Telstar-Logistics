using ApiCore.Scenarios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelstarLogistics.DbClient.Archives.Interfaces;
using TelstarLogistics.ExternalApiClient.Archives.Interfaces;

namespace ApiCore.Scenarios
{
    public class TestScenario: ITestScenario
    {
        private readonly ITestArchive _testArchive;
        private readonly IDbTestArchive _dbTestArchive;

        public TestScenario(ITestArchive testArchive, IDbTestArchive dbTestArchive)
        {
            _testArchive = testArchive;
            _dbTestArchive = dbTestArchive;

         }

        public void Test()
        {
            Console.WriteLine("Works!");
            _testArchive.Test();
            _dbTestArchive.Test();

        }
    }
}
