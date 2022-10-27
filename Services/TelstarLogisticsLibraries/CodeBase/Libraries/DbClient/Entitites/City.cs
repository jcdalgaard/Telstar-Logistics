using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbClient.Entitites
{
    public class City : BaseModel
    {
        public string Name { get; set; } = "";
        public bool IsActive { get; set; }
    }
}