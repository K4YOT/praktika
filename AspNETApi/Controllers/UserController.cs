using AspNETApi.ActionClass.Account;
using AspNETApi.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AspNETApi.Modelss;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspNETApi.ActionClass.HelperClass.DTO;

namespace AspNETApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser _IUser;

        public UserController(IUser iUser)
        {
            _IUser = iUser;
        }

        [HttpGet("getUser")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<List<UserDTO>> GetUser(int userId)
        {
            try
            {
                var user = _IUser.GetUser(userId);
                if (user.Count == 0)
                {
                    return NotFound("Пользователь не найден.");
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ошибка при получении пользователя: " + ex.Message);
            }
        }

        [HttpGet("getAllUsers")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<List<UserDTO>> GetUsers()
        {
            try
            {
                var users = _IUser.GetUsers();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ошибка при получении пользователей: " + ex.Message);
            }
        }

        [HttpPost("addUser")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<string>> Post([FromBody] UserCreate user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await Task.FromResult(_IUser.AddUser(user));
            return CreatedAtAction(nameof(Post), new { id = result }, result);
        }

        [HttpPut("updateUser")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<List<string>> UpdateUser(int userId, [FromBody] UserUpdate user)
        {
            try
            {
                var result = _IUser.UpdateUser(userId, user);
                if (result.Contains("не найден"))
                {
                    return NotFound(result);
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ошибка при обновлении пользователя: " + ex.Message);
            }
        }

        [HttpDelete("deleteUser")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<List<string>> DeleteUser(int userId)
        {
            try
            {
                var result = _IUser.DeleteUser(userId);
                if (result.Contains("не найден"))
                {
                    return NotFound(result);
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ошибка при удалении пользователя: " + ex.Message);
            }
        }
    }
}