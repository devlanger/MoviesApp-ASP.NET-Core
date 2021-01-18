using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MoviesWebApp.Models;

namespace MoviesWebApp.Data
{
    public class MoviesWebAppContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public MoviesWebAppContext (DbContextOptions<MoviesWebAppContext> options)
            : base(options)
        {
        }

        public DbSet<MoviesWebApp.Models.Movie> Movie { get; set; }
    }
}
