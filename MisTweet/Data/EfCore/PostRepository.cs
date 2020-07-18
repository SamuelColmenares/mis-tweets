
namespace MisTweet.Data.EfCore
{
    using MisTweet.Models;

    public class PostRepository : EfCoreRepository<Post, MisTweetsDbContext>
    {
        public PostRepository(MisTweetsDbContext context)
            : base(context) { }
    }
}
