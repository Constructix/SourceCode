using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCoreDemo
{
    class Program
    {
        static void Main(string[] args)
        {


            using (var db = new BloggingContext())
            {
                var blog = new Blog {Url = "http://Sample.com"};
                db.Blogs.Add(blog);
                db.SaveChanges();
            }


            using (var db = new BloggingContext())
            {
                var blogs = db.Blogs.ToList();
                foreach (Blog currentBlog in blogs)
                {
                    Console.WriteLine(currentBlog.Url);
                }
            }
        }
    }

    public class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=MyDatabase;Trusted_Connection=True;");
        }
    }

    public class Blog
    {
        public int BlogId { get; set; }
        public string Url { get; set; }

        public List<Post> Posts { get; set; }
    }

    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }

}
