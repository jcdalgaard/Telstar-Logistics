using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbClient.Entitites
{
    public class Route : BaseModel
    {
        public City FirstCity { get; set; } = new City();
        public City SecondCity { get; set; } = new City();
        public int NumberOfSegments { get; set; }
        public SegmentPrice SegmentPrice { get; set; } = new SegmentPrice();
        public float Duration { get; set; }
    }
}