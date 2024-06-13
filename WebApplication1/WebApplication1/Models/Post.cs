using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace softs;
public class Post
{
    // 帖子主体模块
    // 帖子ID 
    public int postId { get; set; }
    // 用户ID  
    public int userId { get; set; }
    // 标题
    public string? title { get; set; }
    // 内容  
    public string? content { get; set; }
    // 发布时间  
    public DateTime publishTime { get; set; }
    // 更新时间  
    public DateTime updateTime { get; set; }
    // isMarkdown
    public bool isMarkdown { get; set; }
    // 是否置顶  
    public bool isPinned { get; set; }
    // 是否加精  
    public bool isEssential { get; set; }

    // 标签
    public string? tags { get; set; }
    // 图片
    public string? images { get; set; }


    // 点赞模块
    // 点赞数
    public int likeCount { get; set; }
    //点赞用户列表（用于增删点赞）
    public List<User>? LikeUserList { get; set; }
    //public List<int> LikeIdList { get; set; }


    // 评论模块
    // 评论数
    public int commentCount { get; set; }
    // 评论列表
    public virtual ICollection<Comment> CommentList { get; set; }

    //收藏模块
    //收藏数
    public int favouriteCount { get; set; }
    //收藏用户列表
    public List<User>? FavUserList { get; set; } = new List<User>();
    //public List<int> FavIdList { get; set; }

    public Post() {}

    public Post(int userId, string? title, string? content, string? tags, string? images)
    {
        this.userId = userId;
        this.title = title;
        this.content = content;
        this.publishTime = DateTime.Now;
        this.updateTime = DateTime.Now;
        this.likeCount = 0;
        this.favouriteCount = 0;
        this.commentCount = 0;
        this.isPinned = false;
        this.isEssential = false;
        this.isMarkdown = false;

        this.tags = tags;
        this.images = images;

        LikeUserList = new List<User>();
        CommentList = new List<Comment>();
        FavUserList = new List<User>();
    }

    public override bool Equals(object? obj)
    {
        if (obj is Post other)
        {
            return postId == other.postId;
        }
        return false;
    }

    public override int GetHashCode()//返回hashcode
    {
        return postId.GetHashCode();
    }

    public override string ToString()
    {
        return $"postID:{postId},userId:{userId},title:{title},content:{content},publishTime:{publishTime},updateTime:{updateTime},likeCount:{likeCount},commentCount:{commentCount},isPinned:{isPinned},isEssential:{isEssential}";
    }
}