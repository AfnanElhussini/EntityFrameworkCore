using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Models
{
    // Indexes can be created on a single column or on multiple columns of a table.
    [Index(nameof(Url), Name = "Index_URL")]
   public class Blog
    {
        public int id { get; set; }
       
        public string Url { get; set; }

        public List<Post> Posts { get; set; }
    }
}
