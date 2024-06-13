using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace softs
{

    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly UserService userService;

        public UserController(UserService userService)
        {
            this.userService = userService;
        }

        // GET: api/user
        [HttpGet]
        public ActionResult<List<User>> GetUsers()
        {
            return userService.GetAllUsers();
        }

        [HttpPost("login")]
        public ActionResult<int> Login(string username, string password)
        {
            // 调用UserService来验证用户凭证
            var user = userService.login(username, password);

            // 如果用户凭证有效，返回用户信息
            if (user != null)
            {
                // 这里可以添加生成JWT Token或其他认证机制的代码
                // 返回成功的状态码和用户信息
                return Ok(user.userId);
            }

            // 如果凭证无效，返回错误的状态码和消息
            return Unauthorized("用户名或密码错误");
        }

        // POST注册
        [HttpPost("register")]
        public ActionResult<string> AddUser(string username, string password)
        {
            User user = new User { username = username, password = password ,url="null"};
            if(userService.AddUser(user))
            {
                return Ok("注册成功");
            }
            else
            {
                return Unauthorized("用户名已存在");
            }
        }

        //得到用户信息
        [HttpGet("get_info")]
        public ActionResult<User> GetUserInfo(int userId)
        {
            // 调用UserService中的GetUser方法，但这次传入userId
            var user = userService.GetUserById(userId); // 假设这个方法是根据userId获取用户信息

            if (user != null)
            {
                // 如果用户存在，返回用户信息
                return Ok(user);
            }
            else
            {
                // 如果用户不存在，返回404 Not Found状态码
                return NotFound("用户未找到");
            }
        }

        //修改用户信息
        [HttpPost("change")]
        public ActionResult<string> change(string username,string password)
        {
            User user = new User { username = username, password = password };
            userService.RemoveUser(username);
            if(userService.AddUser(user))
            {
                return Ok("修改成功");
            }
            else
            {
                return Unauthorized("修改失败");
            }

        }

        [HttpPost("postimg")]
        public ActionResult<string> PostImg(int userId, string url)
        {
            // 调用UserService中的PostUrl方法更新用户的URL
            bool isUpdated = userService.PostUrl(userId, url);

            if (isUpdated)
            {
                // 如果更新成功，返回成功消息
                return Ok("URL更新成功");
            }
            else
            {
                // 如果更新失败，返回401 Unauthorized状态码
                return Unauthorized("用户不存在或URL更新失败");
            }
        }

        


    }
}
