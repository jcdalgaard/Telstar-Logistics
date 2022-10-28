using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DbClient.Entitites
{
    public class SegmentPrice : BaseModel
    {
        public double Value { get; set; }
    }
}