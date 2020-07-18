using Microsoft.AspNetCore.Mvc;
using MisTweet.Contracts.V1;

namespace MisTweet.Controllers.V1
{
    using MisTweet.Contracts.V1.Responses;
    using MisTweet.Data.EfCore;
    using MisTweet.Models;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using MisTweet.Contracts.V1.Requests;

    public class PostController : Controller
    {

        private readonly PostRepository _postRepository;

        public PostController(PostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        [HttpGet(ApiRoutes.Posts.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            var posts = from post in await _postRepository.GetAll()
                        select new PostResponse
                        {
                            Id = post.Id,
                            Name = post.Name
                        };

            return Ok(posts);
        }

        [HttpGet(ApiRoutes.Posts.Get)]
        public async Task<IActionResult> Get([FromRoute] Guid postId)
        {
            var post = await _postRepository.Get(postId);

            if (post == null) return NotFound();

            return Ok(new PostResponse
            {
                Id = post.Id,
                Name = post.Name
            });
        }

        [HttpPost(ApiRoutes.Posts.Create)]
        public async Task<IActionResult> Create([FromBody] CreatePostRequest postRequest)
        {
            var newPost = new Post { Name = postRequest.Name };

            newPost.Id = Guid.NewGuid();
            Post result = await _postRepository.Add(newPost);

            if (result == null) return BadRequest();

            var response = new PostResponse
            {
                Id = result.Id,
                Name = result.Name
            };

            string urlBase = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            string locationUri = $"{urlBase}/{ApiRoutes.Posts.Get.Replace("{postId}", newPost.Id.ToString())}";
            return Created(locationUri, response);
        }

        [HttpPut(ApiRoutes.Posts.Update)]
        public async Task<IActionResult> Update([FromRoute] Guid postId, [FromBody] UpdatePostRequest postRequest)
        {
            var post = new Post
            {
                Id = postId,
                Name = postRequest.Name
            };

            var postUpdated = await _postRepository.Update(post);

            if (postUpdated != null) return Ok(post);
            return BadRequest();
        }
    }
}
