namespace SO_OMS.Domain.Entities
{
    public class Admin
    {
        public int AdminID { get; }
        public string Username { get; }
        public string PasswordHash { get; }
        public string FullName { get; }
        public string Email { get; }

        public Admin(int adminID, string username, string passwordHash, string fullName, string email)
        {
            AdminID = adminID;
            Username = username;
            PasswordHash = passwordHash;
            FullName = fullName;
            Email = email;
        }
    }
}
