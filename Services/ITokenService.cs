using System;
using sewa.Entities;
using sewa.Model;

namespace sewa.Services
{
	public interface ITokenService
	{
        List<TicketResponseDto> GetToke(ServiceCategory category);
        string CreateTicket(ServiceCategory category);
        string UpdateTicketStatus(TicketStatus status, String token);
        string UpdateTicket(TicketResponseDto dto);
    }
}

