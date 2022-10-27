
namespace BookingSystem
{
    public class Package
    {
        private Guid Id;
        private double Weight;

        private enum ContentType{Weapons, Animals, Parcels, Refrigeration, Other};
        private enum PackageType{SmallPackage, Box, Crate};

    }
}
