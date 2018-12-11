using System.ComponentModel.DataAnnotations;

namespace VolupiaServer
{
    public class Client
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(6, ErrorMessage = "Deve conter 6 ou mais digitos")]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [MinLength(4,ErrorMessage = "Deve conter 4 ou mais digitos")]
        public string Username { get; set; }
    }
}
