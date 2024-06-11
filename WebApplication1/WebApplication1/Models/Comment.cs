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

        // 评论用户
        public int commentUserId { get; set; }

        // 评论内容
        public string? commentContent { get; set; }

        // 评论时间
        public DateTime? commentTime { get; set; }

        // 点赞人数
        public int CommentLikeCount { get; set; }

        // 点赞用户列表（用于增删点赞）
        public List<User>? CommentLikeUserList { get; set; }

        // 回复评论列表
        public List<Comment>? ReplyList { get; set; }

        Comment() { }

        public Comment(int commentUserId, string commentContent)
        {
            this.commentUserId = commentUserId;
            this.commentContent = commentContent;
            this.commentTime = DateTime.Now;
            this.CommentLikeCount = 0;
            CommentLikeUserList = null;
            ReplyList = null;
        }
    }
}
