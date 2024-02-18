using Microsoft.AspNetCore.Mvc;
using sewa.Entities;
using sewa.Services;

namespace sewa.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserActivityController
	{

        private readonly IUserActivityService _userActivityService;

        public UserActivityController(IUserActivityService userActivityService)
        {
            _userActivityService = userActivityService;
        }

        [HttpGet( Name = "Login")]
        public User Login(string username,string password)
		{
            return _userActivityService.Login(username, password);

        }
	}
}

