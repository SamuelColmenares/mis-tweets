

namespace MisTweet.Services
{
    using MisTweet.Data;
    using MisTweet.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class PostSqlService : IPostService
    {
        private readonly MisTweetsDbContext _misTweetsDbContext;

        public PostSqlService(MisTweetsDbContext misTweetsDbContext)
        {
            _misTweetsDbContext = misTweetsDbContext;
        }

        public bool Create(Post newPost)
        {
            _misTweetsDbContext.Posts.Add(newPost);
            var result = _misTweetsDbContext.SaveChanges();
            return result > 0;
        }

        public List<Post> GetAll()
        {
            return _misTweetsDbContext.Posts.ToList();
        }

        public Post GetById(Guid id)
        {
            return _misTweetsDbContext.Posts.Find(id);
        }

        public bool Update(Post postToUpdate, Guid id)
        {
            var post = _misTweetsDbContext.Posts.Find(id);
            if (post == null) return false;

            //postToUpdate.Id = null;
             _misTweetsDbContext.Posts.Update(postToUpdate);
            //postUpd.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            var res = _misTweetsDbContext.SaveChanges();

            return res > 0;
        }
    }
}
