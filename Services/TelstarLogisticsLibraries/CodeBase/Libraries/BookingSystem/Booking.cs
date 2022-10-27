namespace BookingSystem
{
    public class Booking
    {
        private Guid Id;
        private DateTime ArrivalDate;
        private DateTime BookedDate;
        private List<Route> Routes;
        private List<ExtraFeeType> ExtraTypeFee;
        private List<Package> Packages;
        private User User;
        private enum Status { New, InProgress, Deactivated, Completed };
        private bool IsCompleted;

    }
}
