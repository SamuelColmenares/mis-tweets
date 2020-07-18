using Microsoft.AspNetCore.Components;
using MisTweet.Data.EfCore;
using MisTweet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MisTweet.Controllers.V1
{
    [Route("api/v1/[controller]")]
    public class NuevoPostController : GenericController<Post, PostRepository>
    {
        public NuevoPostController(PostRepository repository)
            : base(repository) { }
    }
}
