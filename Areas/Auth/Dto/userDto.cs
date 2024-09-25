using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Areas.Auth.Dto
{
    public class userDto
    {

        [Required]
        
        public required string email { get; set; }

        [Required]
        public  required string password { get; set; }
    }
}
