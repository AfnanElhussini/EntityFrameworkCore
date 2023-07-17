using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Models
{
   public class Blog
    {
        public int id { get; set; }
       
        public string Url { get; set; }

        public List<Post> Posts { get; set; }
    }
}
