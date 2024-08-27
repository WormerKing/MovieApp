using System.Collections.Generic;
using MovieApp.Web.Entity;

namespace MovieApp.Web.Models
{
    public class MovieGenreViewModel
    {
        public List<Movie> Movies { get; set; }
        public List<Genre> Genres { get; set; }
    }
}
