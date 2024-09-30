using AppointmentManagementUserApi.DataAccess;
using AppointmentManagementUserApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentManagementUserApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepos _userRepos;

        public UserController(IUserRepos userRepos)
        {
            _userRepos = userRepos;
        }


        [HttpGet("GetAllUsers")]
        public List<User> GetAllUsers()
        {
            return _userRepos.GetAllUsers();
        }

        [HttpGet("GetUserById")]
        public User GetUser(int id)
        {
            return _userRepos.GetUserById(id);
        }

        [AllowAnonymous]
        [HttpPost("SignUpUser")]

        public bool PostUser(string userName, string userPassword) 
        {
            if (userName == null || userPassword == null)
            {
                return false;
            }

            try
            {
                _userRepos.SignUp(userName,userPassword);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [HttpDelete("DeleteUser")]

        public void DeleteUser(int id)
        {
            _userRepos.DeleteUser(id);
        }

        [HttpPut("UpdateUser")]

        public bool PutUser(int id,string userName, string userPassword) {
            {
                var user = _userRepos.GetUserById(id);
                if (user == null)
                {
                    return false;
                }
                user.UserName = userName;
                user.UserPassword = userPassword;
                _userRepos.UpdateUser(user);
                return true;

            }

        }


        [AllowAnonymous]
        [HttpPost("SignIn")]

        public string SignIn(SignInModel model)
        {
            if (model.UserName != null && model.Password != null)
            {

                return _userRepos.SignIn(model);
            }
            return "User Does Not Exist";
        }
    }
}
    