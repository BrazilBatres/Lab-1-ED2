using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace API
{
    public class Movie
    {
        
        public string director { get; set; }
        public double imdbRating { get; set; }
        public string genre { get; set; }
        public string releaseDate { get; set; }
        public int rottenTomatoesRating { get; set; }
        public string title { get; set; }

        //public int CompareByName(Movie movie)
        //{
        //    if(movie.Title.CompareTo(Title) < 0)
        //    {
        //        return -1;
        //    }
        //    else if(movie.Title.CompareTo(Title)>0)
        //    {
        //        return 1;
        //    }
        //    else
        //    {
        //        return 0;
        //    }
        //}
    }
}
