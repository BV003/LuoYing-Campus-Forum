using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class PostService
    {
        private List<Post> posts = new List<Post>();

        public void CreatePost(Post post)  
        {  
            if (post == null)  
            {  
                throw new ArgumentNullException(nameof(post), "Cannot add a null post.");
            }   
            posts.Add(post);
            Console.WriteLine($"Post {post.postId} added successfully.");
        }  

        /* public Post SearchPostById(int postId)
        {
            return posts.FirstOrDefault(u => u.postId == postId);
        } */

        public void likePost(Post post)
        {
            post.likeCount++;
            Console.WriteLine($"You liked the post.");
        }

        public void favPost(Post post)
        {
            post.favouriteCount++;
            Console.WriteLine($"You put the post in your favourites.");
        }

        public void commentPost(Post post)
        {
            post.commentCount++;
            Console.WriteLine($"You commented the post.");
        }

        public void pinPost(Post post)
        {
            post.isPinned = true;
            Console.WriteLine($"You pinned the post.");
        }

        public void essentialPost(Post post)
        {
            post.isEssential = true;
            Console.WriteLine($"You made the post essential.");
        }

        public bool deletePost(int _postId)
        {
            var postToDelete = posts.FirstOrDefault(c => c.postId == _postId);
            if (postToDelete == null)
            {
                Console.WriteLine("Post not found.");
                return false;
            }

            posts.Remove(postToDelete);
            Console.WriteLine($"Course with ID {_postId} removed successfully.");
            return true;
        }
    }
}