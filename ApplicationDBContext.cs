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
           
           // Exclude From Migration 
           //modelBuilder.Entity<Post>().ToTable("Posts", t => t.ExcludeFromMigrations());
           //change table name
           //modelBuilder.Entity<Post>().ToTable("Posts");
           // Computed Coulmn
           modelBuilder.Entity<Author>()
                .Property(a=> a.DisplayName)
                .HasComputedColumnSql("[FirstName] + ' ' + [LastName]");
            //Sequences
            modelBuilder.HasSequence<int>("BlogNumbers", schema: "shared")
                .StartsAt(1000)
                .IncrementsBy(5);
        }

        public DbSet<Blog>Blogs { get; set; }
        public DbSet<Author>Authors { get; set; }
        public DbSet<Category> Categories { get; set; }       
    }
}
