﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Models
{
    [Index(nameof(Url))]
   public class Blog
    {
        public int id { get; set; }
       
        public string Url { get; set; }

        public List<Post> Posts { get; set; }
    }
}
