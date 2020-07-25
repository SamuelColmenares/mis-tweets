﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MisTweet.Models
{
    public class Post: IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }


        public string UserId { get; set; }
        public IdentityUser User { get; set; }
    }
}
