using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API
{
    public class Movie
    {
        public string name { get; set; }
        public int year { get; set; }
        public string directed_by { get; set; }
        public string[] stars { get; set; }
        public string genre { get; set; }


        public int CompareByName(Movie movie)
        {
            if(movie.name.CompareTo(name) < 0)
            {
                return -1;
            }
            else if(movie.name.CompareTo(name)>0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
