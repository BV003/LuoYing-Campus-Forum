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

        public User GetUserById(int userId)
        {
            // 在数据库中查找用户ID对应的用户
            var user = dbContext.Users.SingleOrDefault(u => u.userId == userId);

            // 如果用户存在，则返回用户对象
            // 如果用户不存在，则返回null
            return user;
        }

        public string GetUrl(int userid)
        {
             var user = dbContext.Users.SingleOrDefault(u => u.userId == userid);

            // 如果用户不存在，则返回null或抛出异常
            if (user == null)
            {
                // 可以选择返回null，或者抛出一个异常，例如:
                // throw new Exception("User not found with id: " + userId);
                return null;
            }

            // 如果用户存在，则返回用户的URL属性
            return user.url;
        }

        public bool PostUrl(int userId, string url)
        {
            // 根据userId查找用户
            var user = dbContext.Users.SingleOrDefault(u => u.userId == userId);

            // 如果用户不存在，则返回false
            if (user == null)
            {
                return false;
            }

            // 更新用户的url属性
            user.url = url;

            // 保存更改到数据库
            dbContext.SaveChanges();

            // 更新成功，返回true
            return true;
        }

    }
}
