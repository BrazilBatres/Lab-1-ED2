using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataStructures;

namespace API.Models
{
    public class Data
    {
        private static Data _instance = null;
        public static MultiPathTree<Movie> tree;
        public static Data Instance()
        {

            if (_instance == null)
            {
                _instance = new Data();

            }
            return _instance;

        }
    }
}
