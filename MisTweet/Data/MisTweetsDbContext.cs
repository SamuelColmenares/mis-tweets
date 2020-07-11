
namespace MisTweet.Data
{
    using Microsoft.EntityFrameworkCore;
    using MisTweet.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class MisTweetsDbContext : DbContext
    {
        public MisTweetsDbContext(DbContextOptions<MisTweetsDbContext> options)
            : base(options) {}

        public DbSet<Post> Posts { get; set; }
    }
}
