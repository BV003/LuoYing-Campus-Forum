using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.Services
{
     class UserService
    {
        private List<User> _users = new List<User>();

        public void AddUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "Cannot add a null user.");
            }

            _users.Add(user);
            Console.WriteLine($"User {user.username} added successfully.");
        }

        public bool RemoveUser(int userId)
        {
            var userToRemove = _users.FirstOrDefault(u => u.userId == userId);
            if (userToRemove == null)
            {
                Console.WriteLine("User not found.");
                return false;
            }

            _users.Remove(userToRemove);
            Console.WriteLine($"User with ID {userId} removed successfully.");
            return true;
        }

        public User FindUserById(int userId)
        {
            return _users.FirstOrDefault(u => u.userId == userId);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _users;
        }
    }
}
