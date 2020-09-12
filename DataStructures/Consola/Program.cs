
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
            MultiPathTree<int> multiPath = new MultiPathTree<int>(3);
            multiPath.Insert(13);
            multiPath.Insert(85);
            multiPath.Insert(73);
            multiPath.Insert(43);
            multiPath.Insert(1);
            multiPath.Insert(16);
            multiPath.Insert(40);
            multiPath.Insert(81);
            multiPath.Insert(65);
            multiPath.Insert(82);
            List<int> nuevaLista = new List<int>();
            multiPath.PostOrder(nuevaLista);
            foreach (var item in nuevaLista)
            {
                Console.WriteLine(item);
            }

            //for (int i = 0; i < 8; i++)
            //{
            //    Console.WriteLine(multiPath.Peek(i, false));
            //}
            Console.ReadLine();
        }
        

    }
}
