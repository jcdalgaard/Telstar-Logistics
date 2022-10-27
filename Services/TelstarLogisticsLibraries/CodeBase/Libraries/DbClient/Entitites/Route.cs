using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbClient.Entitites
{
    public class Route : BaseModel
    {
        [ForeignKey("City")]
        public int FirstCityID { get; set; }

        public City FirstCity { get; set; } = new City();

        [ForeignKey("City")]
        public int SecondCityID { get; set; }

        public City SecondCity { get; set; } = new City();

        [ForeignKey("SegmentPrice")]
        public int SegmentPriceID { get; set; }

        public SegmentPrice SegmentPrice { get; set; } = new SegmentPrice();

        public int NumberOfSegments { get; set; }

        public double Duration { get; set; }
    }
}