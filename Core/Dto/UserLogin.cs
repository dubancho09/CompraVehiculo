using System.ComponentModel.DataAnnotations;

namespace Core.Dto
{
    public class UserLogin
    {
        [Required]
        public string userName { get; set; }

        [Required]
        public string pass { get; set; }
    }
}
