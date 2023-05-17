using Microsoft.EntityFrameworkCore;
using MyBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Data.Concrete.EfCore
{
    public class BlogContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Messages> Messages { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           // optionsBuilder.UseSqlServer(@"Server=ADMINISTRATOR;Database=MyBlogDb;integrated security=true");
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=MyBloggDb;Trusted_Connection=true");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BlogCategory>().HasKey(c => new { c.CategoryId, c.BlogId });
        }
    }
}
