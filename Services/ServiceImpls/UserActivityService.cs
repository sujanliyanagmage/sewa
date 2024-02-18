using sewa.DBConfig;
using sewa.Entities;
namespace sewa.Services
{
    public class UserActivityService : IUserActivityService

	{

        private readonly ApplicationDbContext _context;

        public UserActivityService(ApplicationDbContext context)
		{
            _context = context;
        }


        public User Login(string username, string password)
        {
            return IsValidUserName(username, password);
         
        }


        private User IsValidUserName(string userName,string password)
        {
            if (string.IsNullOrEmpty(userName)|| string.IsNullOrEmpty(userName))
            {
                throw new UnauthorizedAccessException("Invalid Username or Password.");
            }
            User user = _context.Users.FirstOrDefault(u => u.Username == userName && u.Password == password);

            if (user==null)
            {
                throw new UnauthorizedAccessException("You are not authenticated. Please log in.");
            }

            return user;
        }
    }
}

