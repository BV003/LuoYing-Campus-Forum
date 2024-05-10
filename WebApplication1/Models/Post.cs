using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Models;
public class Post  
    {  
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
  
        // 点赞数  
        public int likeCount { get; set; }  
  
        // 评论数  
        public int commentCount { get; set; }  

        //收藏数
        public int favouriteCount { get; set; }
  
        // 是否置顶  
        public bool isPinned { get; set; }  
  
        // 是否加精  
        public bool isEssential { get; set; }
        
        public override bool Equals(object? obj)
        {
            if (obj is Post other)
            {
                return postId == other.postId;
            }
            return false;
        }


        public override int GetHashCode()//返回密码的hashcode
        {
            return postId.GetHashCode();
        }

        public override string ToString()
        {
            return $"postID:{postId},userId:{userId},title:{title},content:{content},publishTime:{publishTime},updateTime:{updateTime},likeCount:{likeCount},commentCount:{commentCount},isPinned:{isPinned},isEssential:{isEssential}";
        }
    } 