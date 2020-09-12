using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace API
{
    public class Movie : IComparable
    {
        public string director { get; set; }
        public double imdbRating { get; set; }
        public string genre { get; set; }
        public string releaseDate { get; set; }
        public int rottenTomatoesRating { get; set; }
        public string title { get; set; }

        public int CompareTo(object obj)
        {
            var comparator = (Movie)obj;
            if(title != null)
            {
                if (title.CompareTo(comparator.title) == 1)
                {
                    return 1;
                }
                else if (title.CompareTo(comparator.title) == -1)
                {
                    return -1;
                }
                else
                {
                    return releaseDate.CompareTo(comparator.releaseDate);
                }
            }
            else
            {
                return releaseDate.CompareTo(comparator.releaseDate);
            }
            


        }
    }
}
