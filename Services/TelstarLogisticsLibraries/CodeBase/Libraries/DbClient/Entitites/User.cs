using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelstarLogistcs.DbClient.Entitites;

namespace DbClient.Entitites
{
    public class User : BaseModel
    {
        public string Name { get; set; } = "";
        public string Password { get; set; } = "";
        public UserRole UserRole { get; set; } = new UserRole();
    }
}