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
            _conn.Execute("UPDATE userprofile SET Name = @Name, Age = @age, Weight = @weight, Workout = @workout, Nutrition = @nutrition, Gender = @gender, Height = @height Where id = @id", new { name = user.Name, age = user.Age, 
                weight = user.Weight, workout = user.Workout, nutrition = user.Nutrition, gender = user.Gender, height = user.Height, id = user.ID,});
        }

        public void InsertUser(User user)
        {
            _conn.Execute("INSERT INTO userprofile (name, age, weight, height, gender, workout, nutrition ) values (@name, @age, @weight, @height, @gender, @workout, @nutrition);", new { name = user.Name, age = user.Age, 
                weight = user.Weight, height = user.Height, gender = user.Gender, workout = user.Workout, nutrition = user.Nutrition });
        }

        public void DeleteUser(User user) 
        {
            _conn.Execute("Delete FROM userprofile WHERE id = @id;", new { id = user.ID });
        }
    }
}
