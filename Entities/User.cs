using System;
using System.ComponentModel.DataAnnotations;

namespace sewa.Entities
{
	public class User
    {
        [Key]
        [StringLength(50)]
        public string Username { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string Role { get; set; }
    }
}

