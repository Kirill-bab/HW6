
namespace Task_3
{
    public class User
    {
        public string Login { get; }
        public string Password { get; }

        public User(string login, string password)
        {
            Login = login;
            Password = password;
        }
    }
}
