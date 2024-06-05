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
    // Class that represent the database (Deals with the database)
    public class ApplicationDBContext : DbContext
    {
        // Connection String is degined in OnConfiguring method
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // not recommended to hard code the connection string here 
            // we can add it in appsettings.json and use it here
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
            //Data Seeding 
            modelBuilder.Entity<Blog>().HasData(
                new Blog { id = 1, Url = "http://sample.com" }
                
                );
        }
        // Class that represent the table in the database
        // i tell the context that these classes are Domain classes
        // DbSet is a collection of entities (Generic)

        public DbSet<Blog>Blogs { get; set; }
        public DbSet<Author>Authors { get; set; }
        public DbSet<Category> Categories { get; set; }       
    }
}


/*

 * Migration Rollback 
 remove-migration  to remove the last migration
 update-database to apply the migration
 update-database LastGoodMigration to rollback to the last good migration
 update-database migration:0 

 */