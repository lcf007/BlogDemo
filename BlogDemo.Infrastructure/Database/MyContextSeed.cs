using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BlogDemo.Core;
using BlogDemo.Core.Entities;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;

namespace BlogDemo.Infrastructure.Database
{
    public class MyContextSeed
    {
        public static async Task SeedAsync(MyContext myContext,
            ILoggerFactory loggerFactory, int retry = 0)
        {
            int retryForAvailability = retry;
            try
            {
                if (!myContext.Posts.Any())
                {
                    myContext.Posts.AddRange(
                        new List<Post>
                        {
                            new Post
                            {
                                Title = "Post Title 1",
                                Body = "Post Body 1",
                                Author = "Richard",
                                LastModified = DateTime.Now
                            },
                            new Post
                            {
                                Title = "Post Title 2",
                                Body = "Post Body 2",
                                Author = "Dave",
                                LastModified = DateTime.Now
                            },
                            new Post
                            {
                                Title = "Post Title 3",
                                Body = "Post Body 3",
                                Author = "Frank",
                                LastModified = DateTime.Now
                            }
                        });
                    await myContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                if (retryForAvailability < 10)
                {
                    retryForAvailability++;
                    var logger = loggerFactory.CreateLogger<MyContextSeed>();
                    logger.LogError(ex.Message);
                    await SeedAsync(myContext, loggerFactory, retryForAvailability);
                }
            }
        }
    }
}
