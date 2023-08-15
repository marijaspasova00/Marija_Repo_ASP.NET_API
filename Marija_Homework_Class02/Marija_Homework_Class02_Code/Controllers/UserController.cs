using Marija_Homework_Class02_Code.Data;
using Marija_Homework_Class02_Code.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Marija_Homework_Class02_Code.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public ActionResult<User> GetAllUsers()
        {
            try
            {
                var userDb = StaticDb.Users;
                var users = userDb.Select(u => new User
                {
                    Id = u.Id,
                    FullName = u.FullName,
                    Email = u.Email
                }).ToList();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured, contact the admin!");
            }
        }
        [HttpGet("{id}")]
        public ActionResult<User> GetUserById(int id)
        {
            try
            {
                if (id < 0)
                {
                    return BadRequest("The id can not be negative!");
                }
                User userDb = StaticDb.Users.FirstOrDefault(u => u.Id == id);
                if (userDb == null)
                {
                    return NotFound($"Note with id {id} does not exist!");
                }
                var user = new User
                {
                    Id = userDb.Id,
                    FullName = userDb.FullName,
                    Email = userDb.Email
                };
                return Ok(user);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured, contact the admin!");
            }
        }

    }
}
