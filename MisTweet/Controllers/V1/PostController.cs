using Microsoft.AspNetCore.Mvc;
using MisTweet.Contracts.V1;
using MisTweet.Contracts.V1.Requests;
using MisTweet.Contracts.V1.Responses;
using MisTweet.Models;
using MisTweet.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace MisTweet.Controllers.V1
{
    public class PostController : Controller
    {

        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet(ApiRoutes.Posts.GetAll)]
        public IActionResult GetAll()
        {
            var posts = from post in _postService.GetAll()
                        select new PostResponse
                        {
                            Id = post.Id,
                            Name = post.Name
                        };

            return Ok(posts);
        }

        [HttpGet(ApiRoutes.Posts.Get)]
        public IActionResult Get([FromRoute] Guid postId)
        {
            var post = _postService.GetById(postId);

            if (post == null) return NotFound();

            return Ok(new PostResponse
            {
                Id = post.Id,
                Name = post.Name
            });
        }

        [HttpPost(ApiRoutes.Posts.Create)]
        public IActionResult Create([FromBody] CreatePostRequest postRequest)
        {
            var newPost = new Post { Name = postRequest.Name };

            newPost.Id = Guid.NewGuid();
            bool result = _postService.Create(newPost);

            if (!result) return BadRequest();

            var response = new PostResponse
            {
                Id = newPost.Id,
                Name = newPost.Name
            };

            string urlBase = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            string locationUri = $"{urlBase}/{ApiRoutes.Posts.Get.Replace("{postId}", newPost.Id.ToString())}";
            return Created(locationUri, response);
        }

        [HttpPut(ApiRoutes.Posts.Update)]
        public IActionResult Update([FromRoute] Guid postId, [FromBody] UpdatePostRequest postRequest)
        {
            var post = new Post
            {
                Id = postId,
                Name = postRequest.Name
            };

            var postUpdated = _postService.Update(post, postId);

            if (postUpdated) return Ok(post);
            return BadRequest();
        }
    }
}
