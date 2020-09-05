using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    class MultiPathTree<T> where T : IComparable
    {
        public class NodeHead : Node
        {
            public MultiPathTree<T> LeftChild;
        }
        public class Node
        {
            public Node next;
            public Node prev;
            public MultiPathTree<T> RightChild;
            public T objeto;
        }

        public Node Head;
        public bool IsEmpty()
        {
            return Head == null;
        }

        public int getLength()
        {
            if (Head == null)
            {
                return 0;
            }
            else
            {
                Node aux = Head;
                int length = 1;
                while (aux.next != null)
                {
                    aux = aux.next;
                    length++;
                }
                return length;
            }
        }
        public void Enlist(T t)
        {

            if (IsEmpty())
            {
                Head = new NodeHead();
                Head.objeto = t;
            }
            else
            {
                Node nuevoNode = new Node();
                nuevoNode.objeto = t;
                Node aux = new Node();
                aux = Head;

                while (aux.next != null)
                {
                    if (nuevoNode.objeto.CompareTo(aux.objeto) > 0)
                    {
                        aux = aux.next;
                        break;
                    }
                    else if (nuevoNode.objeto.CompareTo(aux.objeto) < 0)
                    {
                        if (aux.prev == null)
                        {
                            Node NodoTemp = new Node();
                            NodoTemp.objeto = Head.objeto;
                            NodoTemp.next = Head.next;
                            NodoTemp.prev = Head;
                            Head = nuevoNode;
                            Head.next = NodoTemp;
                            NodoTemp.next.prev = NodoTemp;
                            break;
                        }
                    }

                }
                aux.next = nuevoNode;
                nuevoNode.prev = aux;
            }
        }

        public bool IsFull(int degree)
        {
            if (getLength() == degree - 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public T Peek(int posición, bool eliminar)
        {
            if (posición < getLength())
            {
                Node aux = new Node();
                aux = Head;
                bool shiftHead = true;
                for (int i = 0; i < posición; i++)
                {
                    shiftHead = false;
                    aux = aux.next;
                }
                if (eliminar)
                {
                    Shift(aux, shiftHead);
                }

                return aux.objeto;
            }
            else
                return default(T);
        }

        public void Shift(Node aux, bool hd)
        {
            if (!hd)
            {
                aux.prev.next = aux.next;
            }

            if (aux.next != null)
            {
                aux.next.prev = aux.prev;
            }

            aux.prev = null;
            aux.next = null;
        }


    }
}
