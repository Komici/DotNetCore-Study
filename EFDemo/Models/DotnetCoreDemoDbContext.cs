using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFDemo.Models
{
    public class DotnetCoreDemoDbContext : DbContext
    {
        public DbSet<ConfigValues> ConfigValues { get; set; }

        public DbSet<Blog> Blogs { get; set; }

        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = localhost;Database = DotnetCoreDemo;User ID = sa;Password = 123456;Trusted_Connection = False;");
        }
    }
}
