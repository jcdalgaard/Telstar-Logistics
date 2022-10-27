using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbClient.Entitites
{
    public class Package : BaseModel
    {
        public int BookingID { get; set; }

        public float Weight;
        public PackageContentType PackageContentType { get; set; } = new PackageContentType();
        public PackageSizeType PackageSizeType { get; set; } = new PackageSizeType();
    }
}