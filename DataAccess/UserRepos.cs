using AppointmentManagementUserApi.Helpers;
using AppointmentManagementUserApi.Models;

namespace AppointmentManagementUserApi.DataAccess
{
    public class UserRepos : IUserRepos
    {
        private readonly AppointmentUserDBContext _dbContext;
        private readonly JWTAuth _jWTAuth;

        public UserRepos(AppointmentUserDBContext dbContext, JWTAuth jWTAuth)
        {
            _dbContext = dbContext;
            this._jWTAuth = jWTAuth;
        }

        public void DeleteUser(int id)
        {
            var user = _dbContext.Users.Remove(GetUserById(id));
            if (user != null)
            {
                _dbContext.SaveChanges();
            }
           
        }

        public List<User> GetAllUsers()
        {
            return _dbContext.Users.ToList();
        }

        public User GetUserById(int id)
        {
            User user = _dbContext.Users.FirstOrDefault(x=>x.UserId == id);
            return user;
            
        }

        public string SignIn(SignInModel model)
        {
            var user = _dbContext.Users.FirstOrDefault(u=>u.UserName == model.UserName && u.UserPassword == model.Password);
            if (user != null)
            {
               return _jWTAuth.GenerateToken(user.UserId, user.UserName).GetAwaiter().GetResult();

            }


            return "Invalid User";

        }

        public bool SignUp(string username, string password)
        {
            var existingUser = _dbContext.Users.FirstOrDefault(x=>x.UserName == username);
            if (existingUser != null) 
            {
                return false;
            }
            var user = new User
            {
                UserName = username,
                UserPassword = password
            };

            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
            return true;

            
            
        }

        public void UpdateUser(User user)
        {
            _dbContext.Users.Update(user);
            _dbContext.SaveChanges();
        }

        public User GetUserByName(string username)
        {
            User user = _dbContext.Users.FirstOrDefault(x=>x.UserName == username);
            return user;
        }
    }
}
