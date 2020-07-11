using MisTweet.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MisTweet.Services
{
    public class PostServiceMock : IPostService
    {
        private List<Post> posts;

        public PostServiceMock()
        {
            posts = new List<Post>();

            for (int i = 0; i < 5; i++)
            {
                posts.Add(new Post { Id = Guid.NewGuid(), Name = "nombre" + i });
            }
        }

        public bool Create(Post newPost)
        {
            var exist = posts.Any(x => x.Id == newPost.Id);
            if (exist) return false;

            posts.Add(newPost);
            return true;
        }

        public List<Post> GetAll()
        {
            return posts;
        }

        public Post GetById(Guid id)
        {
            var post = posts.FirstOrDefault(x => x.Id == id);

            return post;
        }

        public bool Update(Post postToUpdate, Guid id)
        {
            /*
             * var post = posts.FirstOrDefault(x => x.Id == id);

            if (post == null) return false;

            post.Id = postToUpdate.Id;
            post.Name = postToUpdate.Name;
            **/            
            
            var exists = posts.Any(x => x.Id == id);

            if (!exists) return false;

            int index = posts.FindIndex(x => x.Id == id);
            posts[index].Id = postToUpdate.Id;
            posts[index].Name = postToUpdate.Name;

            return true;
        }
    }
}
