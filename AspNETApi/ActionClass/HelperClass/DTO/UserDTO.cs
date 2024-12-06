using System.ComponentModel.DataAnnotations;

namespace AspNETApi.ActionClass.HelperClass.DTO
{
    public class UserDTO
    {
        public int user_id { get; set; }

        public string? full_name { get; set; }

        public string? polic { get; set; }

        public string password { get; set; } = null!;
    }
}
