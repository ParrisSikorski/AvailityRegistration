using System.ComponentModel.DataAnnotations;

namespace Registration.API.Models
{
    public class Registrations
    {
        [Key]
        public int Id { get; set; }
        public string NPINumber { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string BusinessAddress { get; set; }
        [Required]
        public string TelephoneNumber { get; set; }
    }
}
