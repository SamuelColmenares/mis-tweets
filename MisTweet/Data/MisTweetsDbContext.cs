
namespace MisTweet.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using MisTweet.Models;

    public class MisTweetsDbContext : IdentityDbContext
    {
        public MisTweetsDbContext(DbContextOptions<MisTweetsDbContext> options)
            : base(options) {}

        public DbSet<Post> Posts { get; set; }
    }
}
