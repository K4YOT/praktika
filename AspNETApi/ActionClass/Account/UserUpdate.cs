using System.ComponentModel.DataAnnotations;

namespace AspNETApi.ActionClass.Account
{
    public class UserUpdate
    {
        [Required]
        public string full_name { get; set; }

        [Required]
        public string polic { get; set; }

        [Required]
        public string password { get; set; }
    }
}
