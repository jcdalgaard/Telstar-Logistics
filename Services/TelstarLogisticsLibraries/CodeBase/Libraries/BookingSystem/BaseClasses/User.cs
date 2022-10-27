namespace BookingSystem.BaseClasses
{
    public class User
    {
        private Guid Id { get; }
        private string Name { get; set; }
        private string Password { get; set; }
        public enum UserRole { Employee, Admin };
        private UserRole Role { get; set; }

        public User(Guid id, string name, string password, UserRole role)
        {
            Id = id;
            Name = name;
            Password = password;
            Role = role; ;
        }
    }
}
