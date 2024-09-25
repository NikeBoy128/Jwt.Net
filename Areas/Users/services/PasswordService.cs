namespace WebApplication1.Areas.Users.services
{
    public class PasswordService
    {




        public string hash(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password,10);
        }


        public bool compare(string plainPassword, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(plainPassword, hashedPassword);
        }
    }
}
