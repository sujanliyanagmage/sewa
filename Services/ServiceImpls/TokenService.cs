using System;
using sewa.DBConfig;
using sewa.Entities;
using sewa.Model;

namespace sewa.Services.ServiceImpls
{
    public class TokenService : ITokenService

    {
        private readonly ApplicationDbContext _context;

        public TokenService(ApplicationDbContext context)
        {
            _context = context;
        }




        public List<TicketResponseDto> GetToke(ServiceCategory category)
        {
            List<Ticket> tickets = _context.Tickets.Where(t => t.Category == category.ToString()).ToList();

            List<TicketResponseDto> ticketDtos = new List<TicketResponseDto>();

            foreach (var ticket in tickets)
            {
                TicketResponseDto dto = new TicketResponseDto
                {
                    CreatedDate = ticket.CreatedDate,
                    TokenNumber = ticket.TokenNumber,
                    Category = Enum.Parse<ServiceCategory>(ticket.Category),
                    CompletedTime = ticket.CompletedTime,
                    TicketStatus = Enum.Parse<TicketStatus>(ticket.TicketStatus)
                };

                ticketDtos.Add(dto);
            }

            return ticketDtos;
        }

        public string CreateTicket(ServiceCategory category)
        {
            Ticket ticket = new Ticket();
            ticket.Category = category.ToString();
            ticket.CreatedDate = DateTime.Now; // Set the CreatedDate to the current date and time
            ticket.TicketStatus = TicketStatus.New.ToString();
            ticket.TokenNumber = GenerateTokenNumber(category.ToString());
            // You need to add your ticket to the context
            _context.Tickets.Add(ticket);

            // Save changes to the database
            _context.SaveChanges();

            // Retrieve the saved ticket from the database
            Ticket savedTicket = _context.Tickets.OrderByDescending(t => t.Id).FirstOrDefault();

            return savedTicket.TokenNumber;
        }


        public string UpdateTicketStatus(TicketStatus status, String token)
        {
           var ticket = _context.Tickets.FirstOrDefault(t => t.TokenNumber == token);

            if (ticket == null)
            {
                throw new InvalidDataException("Invalid ticket number");
            }

            // Update the status of the retrieved ticket
            ticket.TicketStatus = status.ToString();

            try
            {
                // Save the changes to the database
                _context.SaveChanges();
                return "Ticket status updated successfully";
            }
            catch (Exception ex)
            {
                return "An error occurred while updating ticket status: " + ex.Message;
            }
        }

        public string UpdateTicket(TicketResponseDto dto)
        {
            try
            {
                // Retrieve the ticket using the provided token
                Ticket ticketToUpdate = _context.Tickets.FirstOrDefault(t => t.TokenNumber == dto.TokenNumber);

                // If the ticket is not found, return an error message
                if (ticketToUpdate == null)
                {
                    throw new InvalidDataException("Invalid ticket number");
                }

                // Update ticket properties with values from the DTO
                ticketToUpdate.Category = dto.Category.ToString(); 
                ticketToUpdate.TicketStatus = dto.TicketStatus.ToString();
                ticketToUpdate.Description = dto.Description;
                ticketToUpdate.CompletedTime = DateTime.Now; 
                // Save changes to the database
                _context.SaveChanges();

                return "Ticket updated successfully";

            }
            catch (Exception ex)
            {
                // Handle exceptions
                return "An error occurred while updating the ticket: " + ex.Message;
            }
        }


        private string GenerateTokenNumber(string category)
        {
            // Check if the category is not null or empty and has at least two characters
            if (!string.IsNullOrEmpty(category) && category.Length >= 2)
            {
                // Take the first two characters of the category and add a unique identifier
                return $"{category.Substring(0, 2)}_{Guid.NewGuid().ToString().Substring(0, 8)}";
            }
            else
            {
                // If the category is invalid, generate a default token number
                return Guid.NewGuid().ToString().Substring(0, 10);
            }
        }
    }
}

