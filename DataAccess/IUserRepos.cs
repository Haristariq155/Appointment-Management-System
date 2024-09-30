using AppointmentManagementUserApi.Models;

namespace AppointmentManagementUserApi.DataAccess
{
    public interface IUserRepos
    {
        public bool SignUp(string username,string password);
        public string SignIn (SignInModel model);
        public List<User> GetAllUsers();
        public User GetUserById(int id);
        public void DeleteUser (int id);

        public void UpdateUser (User user);
        public User GetUserByName(string username);
       
    }
}
