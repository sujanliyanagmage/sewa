using System;
namespace sewa.Model
{
	public class TicketResponseDto
	{
        public TicketResponseDto()
        {
        }

        public DateTime CreatedDate { get; set; }
        public string TokenNumber { get; set; }
        public ServiceCategory Category { get; set; }
        public DateTime CompletedTime { get; set; }
        public TicketStatus TicketStatus { get; set; }
        public string Description { get; set; }
    }
}

