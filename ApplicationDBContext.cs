using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore
{
    public class ApplicationDBContext : DbContext
    {
        // Connection String is degined in OnConfiguring method
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=EFDataBase;Integrated Security=True; TrustServerCertificate=True");
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
