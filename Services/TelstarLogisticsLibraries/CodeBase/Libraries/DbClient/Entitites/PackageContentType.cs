using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbClient.Entitites
{
    public class PackageContentType : BaseModel
    {
        public string Name { get; set; } = "";
        public float FeeAmount { get; set; }
        public bool IsLegal { get; set; }
        public float PercentialPriceIncrease { get; set; }
    }
}