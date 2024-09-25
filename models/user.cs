using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace WebApplication1.models
{
    public class User
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }


        public required string name { get; set; }

        public required string lastName { get; set; }

        public required string email { get; set; } 

        public required string password { get; set; }


    }
}
