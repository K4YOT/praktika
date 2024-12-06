using AspNETApi.ActionClass.Account;
using AspNETApi.ActionClass.HelperClass.DTO;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace AspNETApi.Interface
{
    public interface IUser
    {
        public List<UserDTO> GetUsers();

        public List<UserDTO> GetUser(int user_id);

        public string AddUser(UserCreate user);

        public List<string> UpdateUser(int user_id, UserUpdate user);

        public List<string> DeleteUser(int user_id);
    }
}
