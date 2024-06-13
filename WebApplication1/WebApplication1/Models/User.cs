using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace softs
{
     public class User
    {
        public int userId { get; set; }
        public string username { get; set; }
        public string password { get; set; }

        public string url { get; set; }

        public User(int userId,string username,string password)
        {
            this.userId = userId;
            this.username = username;
            this.password = password;
        }

        public User()
        {
        }

        public override bool Equals(object obj)
        {
            if (obj is User other)
            {
                return userId == other.userId;
            }
            return false;
        }

        public override int GetHashCode()//返回密码的hashcode
        {
            return password.GetHashCode();
        }

        public override string ToString()
        {
            return $"userId:{userId},username:{username},password:{password}";
        }


    }
}
