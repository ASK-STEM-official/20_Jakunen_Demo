namespace Domain.Entities
{
    public class Admin
    {
        public int AdminId { get; }
        public string Username { get; }
        public string PasswordHash { get; }
        public string FullName { get; }
        public string Email { get; }

        public Admin(int adminId, string username, string passwordHash, string fullName, string email)
        {
            AdminId = adminId;
            Username = username;
            PasswordHash = passwordHash;
            FullName = fullName;
            Email = email;
        }
    }
}
