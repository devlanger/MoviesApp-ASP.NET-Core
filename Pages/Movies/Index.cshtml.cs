using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MoviesWebApp.Data;
using MoviesWebApp.Models;

namespace MoviesWebApp.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly MoviesWebApp.Data.MoviesWebAppContext _context;

        public IndexModel(MoviesWebApp.Data.MoviesWebAppContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Genres { get; set; }
        [BindProperty(SupportsGet = true)]
        public string MovieGenre { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<string> genresQuery = from m in _context.Movie orderby m.Genre select m.Genre;

            var movies = from m in _context.Movie select m;

            if(!string.IsNullOrEmpty(SearchString))
            {
                movies = movies.Where(m => m.Title.Contains(SearchString));
            }

            if(!string.IsNullOrEmpty(MovieGenre))
            {
                movies = movies.Where(m => m.Genre == MovieGenre);
            }

            Genres = new SelectList(await genresQuery.Distinct().ToListAsync());
            Movie = await movies.ToListAsync();
        }
    }
}
