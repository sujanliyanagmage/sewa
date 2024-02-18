using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using sewa.Model;
using sewa.Services;

namespace sewa.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TicketController
	{
		private readonly ITokenService _tokenService;

		public TicketController(ITokenService tokenService)
		{
			_tokenService = tokenService;
		}

        [HttpGet("Tickets", Name = "Tickets")]
        public List<TicketResponseDto> GetAllTicketsByCategory(ServiceCategory category)
		{
			return _tokenService.GetToke(category);
		}

        [HttpPost("Tickets", Name = "Tickets")]
        public string CreateTicket(ServiceCategory category)

        {
			return _tokenService.CreateTicket(category);

        }

        [HttpGet("Categorois", Name = "Categorois")]
        public List<KeyValuePair<int, string>> GetAllCategories()

        {
            List<KeyValuePair<int, string>> enumList = Enum.GetValues(typeof(ServiceCategory))
                                                         .Cast<ServiceCategory>()
                                                         .Select(e => new KeyValuePair<int, string>((int)e, e.ToString()))
                                                         .ToList();

            
            return enumList;
        }




        [HttpGet("Status", Name = "Status")]
        public List<KeyValuePair<int, string>> GetTicketStatus()

        {
            List<KeyValuePair<int, string>> enumList = Enum.GetValues(typeof(TicketStatus))
                                                         .Cast<TicketStatus>()
                                                         .Select(e => new KeyValuePair<int, string>((int)e, e.ToString()))
                                                         .ToList();


            return enumList;

        }


        [HttpPut("UpdateStatus", Name = "UpdateStatus")]
        public string UpdateTicketStatus(TicketStatus status,string token)

        {
            return _tokenService.UpdateTicketStatus(status, token);

        }

        [HttpPut("UpdateTicket", Name = "UpdateTicket")]
        public string UpdateTicket(TicketResponseDto dto)

        {
            return _tokenService.UpdateTicket(dto);

        }
    }
}

