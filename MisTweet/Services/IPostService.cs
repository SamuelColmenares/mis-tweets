using MisTweet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MisTweet.Services
{
    public interface IPostService
    {
        List<Post> GetAll();
        Post GetById(Guid id);
        bool Create(Post newPost);
        bool Update(Post postToUpdate, Guid id);
    }
}
