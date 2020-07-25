
namespace MisTweet.Data.EfCore
{
    using Microsoft.EntityFrameworkCore;
    using MisTweet.Models;
    using System;
    using System.Threading.Tasks;

    public class PostRepository : EfCoreRepository<Post, MisTweetsDbContext>
    {
        private readonly MisTweetsDbContext _postContext;
        public PostRepository(MisTweetsDbContext context)
            : base(context)
        {
            _postContext = context;
        }

        internal async Task<bool> UserOwnsPostAsync(Guid postId, string userId)
        {
            var post = await _postContext.Posts.SingleOrDefaultAsync(x => x.Id == postId);

            return post != null && post.UserId == userId;
        }
    }
}
