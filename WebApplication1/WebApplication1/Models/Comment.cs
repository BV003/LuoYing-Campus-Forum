using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace softs
{
    public class Comment
    {
        // 评论id
        public int commentId { get; set; }

        // 帖子id
        public int postId { get; set; }

        // 评论用户
        public int commentUserId { get; set; }

        // 评论内容
        public string? commentContent { get; set; }

        // 评论时间
        public DateTime? commentTime { get; set; }

        // 点赞人数
        public int CommentLikeCount { get; set; }

        // 点赞用户列表（用于增删点赞）（导航）
        public List<User>? CommentLikeUserList { get; set; }

        // 回复评论列表（导航）
        public virtual ICollection<Reply> ReplyList { get; set; }

        // 导航
        public virtual Post Post { get; set; }

        Comment() { }

        public Comment(int commentUserId, int postId, string commentContent)
        {
            this.commentUserId = commentUserId;
            this.postId = postId;
            this.commentContent = commentContent;
            this.commentTime = DateTime.Now;
            this.CommentLikeCount = 0;
            CommentLikeUserList = new List<User>();
            ReplyList = new List<Reply>();
        }
    }
}
