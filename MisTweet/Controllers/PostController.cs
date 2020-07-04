using Microsoft.AspNetCore.Mvc;
using MisTweet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MisTweet.Controllers
{
    public class PostController: Controller
    {

        private List<Post> posts;

        public PostController()
        {
            posts = new List<Post>();

            for (int i = 0; i < 5; i++)
            {
                posts.Add(new Post { Id = Guid.NewGuid().ToString() });
            }
        }

        [HttpGet("api/posts")]
        public IActionResult GetAll()
        {
            return Ok(posts);
        }
    }
}
