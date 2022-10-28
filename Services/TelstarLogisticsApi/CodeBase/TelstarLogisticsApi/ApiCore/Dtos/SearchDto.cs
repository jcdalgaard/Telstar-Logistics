using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCore.Dtos
{
    public class SearchDto
    {
        public string DepartureCity { get; set; }
        public string DestinationCity { get; set; }
        public bool RecordedDelivery { get; set; }
        public bool RefridgeratedGoods { get; set; }
        public bool LiveAnimals { get; set; }
        public bool CautiousParcels { get; set; }
        public bool ExpressDelivery { get; set; }
    }
}
