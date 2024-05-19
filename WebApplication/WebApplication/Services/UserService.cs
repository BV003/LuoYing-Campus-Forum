using Microsoft.EntityFrameworkCore;
using MySqlX.XDevAPI.CRUD;
using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace softs
{
     public class UserService
    {
        //private List<User> _users = new List<User>();

        //public void AddUser(User user)
        //{
        //    if (user == null)
        //    {
        //        throw new ArgumentNullException(nameof(user), "Cannot add a null user.");
        //    }

        //    _users.Add(user);
        //    Console.WriteLine($"User {user.username} added successfully.");
        //}

        //public bool RemoveUser(int userId)
        //{
        //    var userToRemove = _users.FirstOrDefault(u => u.userId == userId);
        //    if (userToRemove == null)
        //    {
        //        Console.WriteLine("User not found.");
        //        return false;
        //    }

        //    _users.Remove(userToRemove);
        //    Console.WriteLine($"User with ID {userId} removed successfully.");
        //    return true;
        //}

        //public User FindUserById(int userId)
        //{
        //    return _users.FirstOrDefault(u => u.userId == userId);
        //}

        //public IEnumerable<User> GetAllUsers()
        //{
        //    return _users;
        //}

        UserDbContext dbContext;

        public UserService(UserDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<User> GetAllUsers()
        {
            return dbContext.Users
                .ToList<User>();
        }

        public User login(string username, string password)
        {
            // 在数据库中查找用户名
            var user = dbContext.Users.FirstOrDefault(u => u.username == username);

            // 如果用户不存在，则返回null
            if (user == null)
            {
                return null;
            }
            // 验证密码是否匹配
            bool passwordIsValid = user.password == password;

            // 如果密码验证失败，则返回null
            if (!passwordIsValid)
            {
                return null;
            }

            // 如果用户名和密码都验证成功，则返回用户对象
            return user;
        }


        //增
        public bool AddUser(User user)
        {
            // 验证用户名是否已存在
            var existingUser = dbContext.Users.FirstOrDefault(u => u.username == user.username);
            if (existingUser != null)
            {
                // 用户名已存在
                return false;
            }          
            // 将新用户添加到数据库
            dbContext.Users.Add(user);
            dbContext.SaveChanges();
            return true;
            //添加成功
        }

        //删
        public void RemoveUser(string username)
        {
            var user = dbContext.Users
                .SingleOrDefault(o => o.username == username);
            if (user == null) return;
            dbContext.Users.Remove(user);
            dbContext.SaveChanges();
        }

        //查
        public User GetUser(string username)
        {
            return dbContext.Users
               .SingleOrDefault(o => o.username ==username);
        }

    }
}
