using Dapper;
using Fitness__App.Models;
using System.Data;

namespace Fitness__App
{
    public class UserRepo : IUserRepo
    {
        private readonly IDbConnection _conn;

        public UserRepo(IDbConnection conn)
        {
            _conn = conn;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _conn.Query<User>("SELECT * FROM userprofile");
        }

        public User GetUser(int id)
        {
           return _conn.QuerySingle<User>("SELECT * FROM userprofile WHERE id = @id", new { id = id });

        }

        public void UpdateUser(User user)
        {
            _conn.Execute("UPDATE userprofile SET Name = @Name, Age = @age, Weight = @weight, Gender = @gender, Height = @height Where id = @id", new { name = user.Name, age = user.Age, 
                weight = user.Weight, gender = user.Gender, height = user.Height, id = user.ID });
        }

        public void InsertUser(User name)
        {
            _conn.Execute("INSERT INTO userprofile (name, age, weight, height) values (@name, @age, @weight, @height);", new { name = name.Name, age = name.Age, 
                weight = name.Weight, height = name.Height });
        }

        public void DeleteUser(User user) 
        {
            _conn.Execute("Delete FROM userprofile WHERE id = @id;", new { id = user.ID });
        }
    }
}
