using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SereginLab1.Data;
using System;
using System.Linq;

namespace SereginLab1.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcDbEntityContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcDbEntityContext>>()))
            {
                // Look for any movies.
                if (context.DbEntity.Any())
                {
                    return;   // DB has been seeded
                }

                context.DbEntity.AddRange(
                    new DbEntity
                    {
                        Name = "Ivan",
                        BirthDay = DateTime.Parse("1997-2-12"),
                        Age = 25
                    },

                    new DbEntity
                    {
                        Name = "Alex ",
                        BirthDay = DateTime.Parse("1992-1-13"),
                        Age = 30
                    },

                    new DbEntity
                    {
                        Name = "John",
                        BirthDay = DateTime.Parse("1986-2-23"),
                        Age = 36
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
