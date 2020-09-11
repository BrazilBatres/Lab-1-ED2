using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    public class MultiPathNode<T> where T : IComparable
    {
        public class NodeHead : Node
        {
            public MultiPathNode<T> LeftChild;
        }
        public class Node
        {
            public Node next;
            public Node prev;
            public MultiPathNode<T> RightChild;
            public T objeto;
        }

        public Node Head;
        public bool IsEmpty()
        {
            return Head == null;
        }

        public int GetLength()
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
        public bool Enlist(T t)
        {

            if (IsEmpty())
            {
                Head = new NodeHead();
                Head.objeto = t;
                return true;
            }
            else
            {
                Node nuevoNode = new Node();
                nuevoNode.objeto = t;
                Node aux = new Node();
                aux = Head;
                bool exit = false;
                do
                {
                    if (nuevoNode.objeto.CompareTo(aux.objeto) > 0)
                    {
                        if (aux.next != null)
                        {
                            aux = aux.next;
                        }
                        else
                        {
                            exit = true;
                        }
                        
                    }
                    else if (nuevoNode.objeto.CompareTo(aux.objeto) < 0)
                    {
                        if (aux.prev == null)
                        {
                            Node NodoTemp = new Node();
                            NodoTemp.objeto = Head.objeto;
                            NodoTemp.next = Head.next;

                            Head = nuevoNode;
                            Head.next = NodoTemp;
                            NodoTemp.next.prev = NodoTemp;
                            NodoTemp.prev = Head;

                        }
                        else
                        {
                            Node NodoTemp = new Node();
                            NodoTemp.objeto = aux.objeto;
                            NodoTemp.next = aux.next;
                            NodoTemp.prev = aux.prev;

                            nuevoNode.next = aux;
                            nuevoNode.prev = aux.prev;
                            aux.prev.next = nuevoNode;
                            aux.prev = nuevoNode;

                        }
                        return true;


                    }
                    else
                    {
                        return false;

                    }

                } while (!exit);
                aux.next = nuevoNode;
                nuevoNode.prev = aux;
                return true;

            }
        }

        public bool IsFull(int degree)
        {
            if (GetLength() == degree - 1)
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
            if (posición < GetLength())
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
