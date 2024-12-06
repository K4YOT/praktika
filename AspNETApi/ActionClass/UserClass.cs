using AspNETApi.ActionClass.Account;
using AspNETApi.ActionClass.HelperClass.DTO;
using AspNETApi.Interface;
using AspNETApi.Modelss;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspNETApi.ActionClass
{
    public class UserClass : IUser
    {
        private readonly Andreev223ToysShopDbContext _context;

        public UserClass(Andreev223ToysShopDbContext context)
        {
            _context = context;
        }

        public List<UserDTO> GetUsers()
        {
            try
            {
                var users = _context.Users.ToList();

                var userDTOs = users.Select(user => new UserDTO
                {
                    user_id = user.UserId,
                    full_name = user.Name,
                    polic = user.Surname,
                    password = user.Password
                }).ToList();

                return userDTOs;
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при получении пользователей: " + ex.Message);
            }
        }

        public List<UserDTO> GetUser(int userId)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(u => u.UserId == userId);

                if (user == null)
                {
                    return new List<UserDTO>();
                }

                var userDTO = new UserDTO
                {
                    user_id = user.UserId,
                    full_name = user.Name,
                    polic = user.Surname,
                    password = user.Password
                };

                return new List<UserDTO> { userDTO };
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при получении пользователя: " + ex.Message);
            }
        }

        public string AddUser(UserCreate user)
        {
            try
            {
                if (user.Name.Contains(" ") ||
                    user.Surname.Contains(" ") ||
                    user.Login.Contains(" ") ||
                    user.Password.Contains(" "))
                {
                    throw new Exception("ни в одном поле не должно содержаться пробела.");
                }

                if (user.Password.Length <= 4)
                {
                    throw new Exception("пароль должен содержать больше 4-ёх символов.");
                }

                User createUser = new User()
                {
                    Name = user.Name,
                    Surname = user.Surname,
                    Login = user.Login,
                    Password = user.Password
                };

                _context.Users.Add(createUser);
                _context.SaveChanges();

                int userId = createUser.UserId;
                string success = $"Успешно создан пользователь с ID {userId}";

                Results.Created();
                return success;
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка в выполнении запроса: " + ex.Message);
            }
        }

        public List<string> UpdateUser(int userId, UserUpdate user)
        {
            try
            {
                if (user.full_name.Contains(" ") ||
                    user.polic.Contains(" ") ||
                    user.password.Contains(" "))
                {
                    throw new Exception("ни в одном поле не должно содержаться пробела.");
                }

                if (user.password.Length <= 4)
                {
                    throw new Exception("пароль должен содержать больше 4-ёх символов.");
                }

                var existingUser = _context.Users.FirstOrDefault(u => u.UserId == userId);
                if (existingUser == null)
                {
                    return new List<string> { "Пользователь не найден." };
                }

                existingUser.Name = user.full_name ?? existingUser.Name;
                existingUser.Surname = user.polic ?? existingUser.Surname;
                existingUser.Password = user.password ?? existingUser.Password;

                _context.SaveChanges();

                return new List<string> { "Пользователь успешно обновлен." };
            }
            catch (Exception ex)
            {
                return new List<string> { "Ошибка при обновлении пользователя: " + ex.Message };
            }
        }

        public List<string> DeleteUser(int userId)
        {
            try
            {
                var existingUser = _context.Users.FirstOrDefault(u => u.UserId == userId);
                if (existingUser == null)
                {
                    return new List<string> { "Пользователь не найден." };
                }

                _context.Users.Remove(existingUser);
                _context.SaveChanges();

                return new List<string> { "Пользователь успешно удален." };
            }
            catch (Exception ex)
            {
                return new List<string> { "Ошибка при удалении пользователя: " + ex.Message };
            }
        }
    }
}