namespace SSU.Coins.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public string Login { get; set; }

        public byte[] HashPassword { get; set; }

        public int RoleWebSite { get; set; }

        public byte[] Avatar { get; set; }
    }
}
