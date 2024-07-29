using System.ComponentModel.DataAnnotations;

namespace JwtAuthApi.Models
{
    public class UserModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }    

        [Required]
        public string Password { get; set; }
    }

    public class UserResponseModel
    {
        public string Username { get; set; }
        public string Token { get; set; }
    }
}
