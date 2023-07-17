using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCore.Models;
using EFCore.Configrations;

namespace EFCore
{
    public class ApplicationDBContext : DbContext
    {
        // Connection String is degined in OnConfiguring method
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=EFDataBase;Integrated Security=True; TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuditEntry>();
            new BlogEntityTypeConfiguration().Configure(modelBuilder.Entity<Blog>());
           
        }

        public DbSet<Blog>Blogs { get; set; }
    }
}
