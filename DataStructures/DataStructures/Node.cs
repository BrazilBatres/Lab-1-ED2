using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    class Node<T> where T:IComparable
    {
        public Node<T> next;
        public Node<T> prev;
        public MultiPathNode<T> RightChild;
        public T t_object;
        public MultiPathNode<T> LeftChild;
    }
}
