
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataStructures;
namespace Consola
{
    class Program
    {
        static void Main (string [] args)
        {
            MultiPathNode<int> multiPath = new MultiPathNode<int>();
            multiPath.Enlist(5);
            multiPath.Enlist(10);
            multiPath.Enlist(1);
            multiPath.Enlist(8);

            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine(multiPath.Peek(i, false));
            }
            Console.ReadLine();
        }
        
    }
}
