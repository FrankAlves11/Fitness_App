using Fitness__App.Models;

namespace Fitness__App
{
    public interface IUserRepo
    {
        public IEnumerable<User> GetAllUsers();

        public User GetUser(int id);

        public void UpdateUser(User user);

        public void InsertUser(User user);

        public void DeleteUser(User user);
    }

    

   
}
