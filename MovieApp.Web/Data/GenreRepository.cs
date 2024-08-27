using MovieApp.Web.Models;
using System.Collections.Generic;
using System.Linq;
using MovieApp.Web.Entity;

namespace MovieApp.Web.Data
{
    public class GenreRepository
    {
        private static readonly List<Genre> _genres = null;
        public static List<Genre> Genres
        {
            get
            {
                return _genres;
            }
        }
        static GenreRepository()
        {
            _genres = new List<Genre>() {
                new Genre {Id=1,Name="Komedi"},
                new Genre {Id=2,Name="Korku"},
                new Genre {Id=3,Name="Romantik"},
                new Genre {Id=4,Name="Bilim Kurgu"},
                new Genre {Id=5,Name="Aksiyon"}
            };
        }

        public static void AddGenre(Genre genre)
        {
            _genres.Add(genre);
        }

        public static Genre GetById(int id)
        {
            return _genres.FirstOrDefault(elm => elm.Id == id);
        }
    }
}
