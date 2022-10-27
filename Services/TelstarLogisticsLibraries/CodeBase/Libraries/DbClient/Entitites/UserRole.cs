using DbClient.Entitites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelstarLogistcs.DbClient.Entitites
{
    public class UserRole : BaseModel
    {
        public string Name { get; set; } = "";
    }
}