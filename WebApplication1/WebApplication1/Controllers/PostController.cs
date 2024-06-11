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
    [Route("api/post")]
    public class PostController : ControllerBase
    {
        private readonly PostService postService;

        public PostController(PostService postService)
        {
            this.postService = postService;
        }

        // GET: api/post
        [HttpGet]
        public ActionResult<List<Post>> GetPosts()
        {
            return postService.GetAllPosts();
        }

        [HttpGet("get_post")]
        public ActionResult<Post> getPost(int PostId)
        {
            var post = postService.GetPostById(PostId);

            if (post != null)
            {
                return Ok(post);
            }
            else
            {
                return Unauthorized("未找到帖子");
            }
        }

        [HttpPost("create_post")]
        public ActionResult<string> createPost(int userId, string? title, string? content)
        {
            Post post = new Post(userId, title, content);
            if (postService.AddPost(post))
            {
                return ("帖子创建成功");
            }
            else
            {
                return Unauthorized("帖子创建失败");
            }
        }

        [HttpPost("like_post")]
        public ActionResult<string> likePost(int postId, int userId)
        {
            if (postService.LikePost(postId, userId))
            {
                return ("已点赞");
            }
            else
            {
                return Unauthorized("点赞失败");
            }
        }

        [HttpPost("fav_post")]
        public ActionResult<string> favPost(int postId, int userId)
        {
            if (postService.FavPost(postId, userId))
            {
                return ("已收藏");
            }
            else
            {
                return Unauthorized("收藏失败");
            }
        }

        [HttpPost("comment_post")]
        public ActionResult<string> commentPost(int postId, int userId, string commentContent)
        {
            if (postService.CommentPost(postId, userId, commentContent))
            {
                return ("已评论");
            }
            else
            {
                return Unauthorized("评论失败");
            }
        }

        [HttpDelete("delete_post")]
        public ActionResult<string> deletePost(int postId)
        {
            if (postService.DeletePost(postId))
            {
                return ("成功删除帖子");
            }
            else
            {
                return Unauthorized("删除帖子失败");
            }
        }

        [HttpPut("cancel_like")]
        public ActionResult<string> cancelLike(int postId, int userId)
        {
            if (postService.CancelLikePost(postId, userId))
            {
                return ("成功取消点赞");
            }
            else
            {
                return Unauthorized("取消点赞失败");
            }
        }

        [HttpDelete("cancal_fav")]
        public ActionResult<string> cancelFav(int postId, int userId)
        {
            if (postService.CancelFavPost(postId, userId))
            {
                return ("成功取消收藏");
            }
            else
            {
                return Unauthorized("取消收藏失败");
            }
        }

        [HttpDelete("delete_comment")]
        public ActionResult<string> deleteComment(int postId, int userId, int commentId)
        {
            if (postService.DeleteComment(postId, userId, commentId))
            {
                return ("成功删除评论");
            }
            else
            {
                return Unauthorized("删除评论失败");
            }
        }
    }
}