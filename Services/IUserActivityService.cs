using sewa.Entities;

namespace sewa.Services
{
    public interface IUserActivityService
    {
        User Login(string username, string password);

    }
}

