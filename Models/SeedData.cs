using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MoviesWebApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesWebApp.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using(MoviesWebAppContext context = new MoviesWebAppContext(
                serviceProvider.GetRequiredService<DbContextOptions<MoviesWebAppContext>>()))
            {
                //There are already record added to the Table
                if(context.Movie.Any())
                {
                    return;
                }

                var initialMovies = new List<Movie>();
                initialMovies.Add(new Movie()
                {
                    Title = "Scary Movie II",
                    Date = DateTime.Now,
                    Genre = "Horror, Comedy",
                    Price = 11.7M
                });

                context.Movie.AddRange(initialMovies);
                context.SaveChanges();
            }
        }
    }
}
