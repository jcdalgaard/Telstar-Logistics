using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TelstarLogistcs.DbClient.Entitites;

namespace DbClient.Entitites
{
    public class User : BaseModel
    {
        public string Name { get; set; } = "";
        public string Password { get; set; } = "";

        [ForeignKey("UserRole")]
        public int UserRoleID { get; set; }

        public UserRole UserRole { get; set; } = new UserRole();
    }
}