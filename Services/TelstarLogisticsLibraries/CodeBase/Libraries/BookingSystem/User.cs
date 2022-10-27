namespace BookingSystem
{
    public class User
    {
        private Guid Id { get; }
        private string Name { get; set; }
        private string Password { get; set; }
        public enum UserRole {Employee, Admin};
        private UserRole Role { get; set; }

        public User(Guid id, string name, string password, UserRole role)
        {
            this.Id = id;
            this.Name = name;
            this.Password = password;
            this.Role = role; ;
        }
    }
}
