using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace softs
{
    public class Reply
    {
        // 回复id
        public int replyId { get; set; }

        // 评论id
        public int commentId { get; set; }

        // 帖子id
        public int postId { get; set; }

        // 评论用户
        public int replyUserId { get; set; }

        // 评论内容
        public string? replyContent { get; set; }

        // 评论时间
        public DateTime? replyTime { get; set; }

        // 点赞人数
        public int replyLikeCount { get; set; }

        // 导航
        public virtual Comment Comment { get; set; }

        // 点赞用户列表（用于增删点赞）
        public List<User>? replyLikeUserList { get; set; }

        Reply() { }

        public Reply(int commentId, int postId, int replyUserId, string replyContent)
        {
            this.commentId = commentId;
            this.postId = postId;
            this.replyUserId = replyUserId;
            this.replyContent = replyContent;
            replyTime = DateTime.Now;
            replyLikeCount = 0;
            replyLikeUserList = new List<User>();
        }
    }
}
