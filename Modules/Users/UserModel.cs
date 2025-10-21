using System.ComponentModel.DataAnnotations;
using ApiEscala.Database;
using ApiEscala.Utils;

namespace ApiEscala.Modules.Users
{
    public class UserModel : BaseModel
    {
        [Required]
        [Unique]
        public required string Name { get; set; }

        [Required]
        public required string Email { get; set; }

        [Required]
        [MinLength(8)]
        public required string Password { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(6)]
        public string Role { get; set; } = "user";
    }
}
