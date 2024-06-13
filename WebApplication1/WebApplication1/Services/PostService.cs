using Microsoft.EntityFrameworkCore;
using MySqlX.XDevAPI.CRUD;
using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using softs;
using Microsoft.AspNetCore.Mvc;

namespace softs
{
    public class PostService
    {
        UserDbContext dbContext;

        public PostService(UserDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Post> GetAllPosts()
        {
            return dbContext.Posts
                .ToList<Post>();
        }

        public Post? MatchPost(int postId)
        {
            var postMatch = dbContext.Posts.FirstOrDefault(o => o.postId == postId);
            if (postMatch == null)
                throw new Exception("Post not found");
            else return postMatch;
        }

        public User? MatchUser(int userId, List<User>? userList)
        {
            if (userList == null)
                return null;
            var userMatch = userList.FirstOrDefault(o => o.userId == userId);
            if (userMatch == null)
                return null;
            else return userMatch;
        }

        //创建帖子
        public bool AddPost(Post post)
        {
            dbContext.Posts.Add(post);
            dbContext.SaveChanges();
            return true;
        }

        //删除帖子
        public bool DeletePost(int postId)
        {
            var postMatch = MatchPost(postId);
            dbContext.Posts.Remove(postMatch);
            dbContext.SaveChanges();
            return true;
        }

        //查找帖子
        public Post GetPostById(int postId)
        {
            var postMatch = MatchPost(postId);
            return postMatch;
        }

        //点赞帖子
        public bool LikePost(int postId, int userId)
        {
            //检测帖子是否存在
            var postMatch = MatchPost(postId);
            if (postMatch == null)
                throw new Exception("Post not found");
            //检测用户是否存在
            var userInfo = MatchUser(userId, dbContext.Users.ToList<User>());
            if (userInfo == null)
                throw new Exception("User not found");

            var userMatch = MatchUser(userId, postMatch.LikeUserList);
            if (userMatch != null) //说明该用户点赞过此帖子
                return false;
            else
            {
                if (postMatch.LikeUserList == null)
                    postMatch.LikeUserList = new List<User>();
                postMatch.LikeUserList.Add(userInfo);
                postMatch.likeCount++;
                dbContext.SaveChanges();
                return true;
            }
        }

        // 取消点赞
        public bool CancelLikePost(int postId, int userId)
        {
            //根据id查找帖子
            var postMatch = MatchPost(postId);
            if (postMatch == null)
                throw new Exception("Post not found");

            //查找用户是否点过赞
            var userMatch = MatchUser(userId,postMatch.LikeUserList);
            if (userMatch != null)
            {
                if (postMatch.LikeUserList == null)
                    postMatch.LikeUserList = new List<User>();
                postMatch.LikeUserList.Remove(userMatch);
                postMatch.likeCount--;
                dbContext.SaveChanges();
                return true;
            }
            else
                return false;
        }

        // 收藏帖子
        public bool FavPost(int postId, int userId)
        {
            //检测帖子是否存在
            var postMatch = MatchPost(postId);
            if (postMatch == null)
                throw new Exception("Post not found");
            //检测用户是否存在
            var userInfo = MatchUser(userId, dbContext.Users.ToList<User>());
            if (userInfo == null)
                throw new Exception("User not found");

            var userMatch = MatchUser(userId, postMatch.FavUserList);
            if (userMatch != null) //说明该用户点赞过此帖子
                return false;
            else
            {
                if (postMatch.FavUserList == null)
                    postMatch.FavUserList = new List<User>();
                postMatch.FavUserList.Add(userInfo);
                postMatch.favouriteCount++;
                dbContext.SaveChanges();
                return true;
            }
        }

        // 取消收藏
        public bool CancelFavPost(int postId, int userId)
        {
            //var postMatch = MatchPost(postId);
            var postMatch = dbContext.Posts.Include(p => p.FavUserList)
                .FirstOrDefault(o => o.postId == postId);
            if (postMatch == null)
                throw new Exception("Post not found");

            var userMatch = MatchUser(userId, postMatch.FavUserList);
            if (userMatch != null)
            {
                if (postMatch.FavUserList == null)
                    postMatch.FavUserList = new List<User>();
                postMatch.FavUserList.Remove(userMatch);
                postMatch.favouriteCount--;
                dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        // 评论帖子
        public bool CommentPost(int userId, int postId, String commentContent)
        {
            Comment comment = new Comment(userId, postId, commentContent);
            var postMatch = MatchPost(postId);
            if (postMatch != null) 
            {
                if (postMatch.CommentList == null)
                    postMatch.CommentList = new List<Comment>();
                postMatch.CommentList.Add(comment);
                postMatch.commentCount++;
                dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        // 回复评论
        public bool ReplyComment(int commentId, int postId, int replyUserId, string replyContent)
        {
            Reply reply = new Reply(commentId, postId, replyUserId, replyContent);
            var commentMatch = dbContext.Comments
            .Include(c => c.ReplyList) // 显式加载 ReplyList 导航属性
            .FirstOrDefault(c => c.commentId == commentId && c.postId == postId);

            if (commentMatch == null)
                throw new Exception("comment not found");

            // 确保 ReplyList 已初始化
            if (commentMatch.ReplyList == null)
                commentMatch.ReplyList = new List<Reply>();

            // 将新回复添加到回复列表中
            commentMatch.ReplyList.Add(reply);
            dbContext.SaveChanges();

            return true;
        }

        // 删除评论
        public bool DeleteComment(int postId, int userId, int commentId)
        {
            var postMatch = MatchPost(postId);
            var commentMatch = postMatch.CommentList.FirstOrDefault(o => o.commentId == commentId);
            if (commentMatch != null) 
            {
                postMatch.CommentList.Remove(commentMatch);
                postMatch.commentCount--;
                dbContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}