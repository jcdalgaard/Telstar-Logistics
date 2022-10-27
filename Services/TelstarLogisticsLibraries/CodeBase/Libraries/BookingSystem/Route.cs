
namespace BookingSystem
{
    public class Route
    {
        private Guid Id;
        private City CityFrom;
        private City CityTo;
        private int NumberOfSegments;
        private double SegmentPrice;
        private double Duration;
        private enum type{Internal, Oceanic, EastIndian};

    }
}
