using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BloggingEntityDemo
{
    class Program
    {
        static void Main(string[] args)
        {
           BloggingContext context = new BloggingContext();

           var blog = new Blog
           {
               BlogId = 1, Url = "https://blogs.com", Rating = 3,
               Posts = new List<Post>() {new Post {BlogId = 1, Content = "test", Title = "first title"}}
           };

           context.Blogs.Add(blog);
           context.SaveChanges();


        }
    }
    public class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=Blogging;Integrated Security=True");
        }
    }


    public class Blog
    {
        public int BlogId { get; set; }
        public string Url { get; set; }
        public int Rating { get; set; }
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
