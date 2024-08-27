using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MovieApp.Web.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieApp.Web.Data
{
    public class DataSeeding
    {
        public static void Seed(IApplicationBuilder app)
        {
            var scope = app.ApplicationServices.CreateScope();
            var _context = scope.ServiceProvider.GetService<MovieContext>();

            _context.Database.Migrate();

            if (_context.Database.GetPendingMigrations().Count() == 0)
            {
                if (_context.Movies.Count() == 0)
                {
                    _context.Movies.AddRange(MovieRepository.Movies);
                }

                if (_context.Genres.Count() == 0)
                {
                    _context.Genres.AddRange(
                        new List<Genre>() {
                            new Genre {Name="Komedi"},
                            new Genre {Name="Korku"},
                            new Genre {Name="Romantik"},
                            new Genre {Name="Bilim Kurgu"},
                            new Genre {Name="Aksiyon"}
                        }
                    );
                    
                }

                _context.SaveChanges();
            }
        }
    }
}
