using System;
using BlogDemo.Core;
using Microsoft.EntityFrameworkCore;

namespace BlogDemo.Infrastructure
{
    public class MyContext:DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
        }

        public DbSet<Post> Posts { get; set; }
    }
}
