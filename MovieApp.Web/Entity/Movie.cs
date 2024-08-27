﻿namespace MovieApp.Web.Entity
{
    public class Movie
    {
        public int Id { get; set; }
        public int? Genre_Id { get; set; }
        public string Title { get; set; }

        public string Actors { get; set; }

        public string Description { get; set; }

        public string Director { get; set; }
    }
}
