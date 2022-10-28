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
        [ForeignKey("Booking")]
        public int BookingID { get; set; }


        public double Weight;

        [ForeignKey("PackageContentType")]
        public int PackageContentTypeID { get; set; }

        public PackageContentType PackageContentType { get; set; } = new PackageContentType();

        [ForeignKey("PackageSizeType")]
        public int PackageSizeTypeID { get; set; }

        public PackageSizeType PackageSizeType { get; set; } = new PackageSizeType();
    }
}