using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesWebApp.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        
        [Display(Name = "Released Date")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }
    }
}
