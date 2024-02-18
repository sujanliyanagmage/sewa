using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sewa.Entities
{
    public class Ticket
    {
        [Key]
        public int? Id { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        [StringLength(255)]
        public string? TokenNumber { get; set; }

        [StringLength(50)]
        public string? Category { get; set; }

        [Required]
        public DateTime CompletedTime { get; set; }

        [Required]
        [StringLength(50)]
        public string? TicketStatus { get; set; }

        [StringLength(250)]
        public string? Description { get; set; }
    }
}

