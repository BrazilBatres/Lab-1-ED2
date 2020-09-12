using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
     class MultiPathNode<T> where T : IComparable
    {
        //public class NodeHead : Node
        //{
        //    public MultiPathNode<T> LeftChild;
        //}
        //public class Node
        //{
        //    public Node next;
        //    public Node prev;
        //    public MultiPathNode<T> RightChild;
        //    public T objeto;
        //}
        public MultiPathNode (int dgree){
            degree = dgree;
        }
        int degree;
        Node<T> Head;
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
                Node<T> aux = Head;
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
                Head = new Node<T>();
                Head.t_object = t;
                return true;
            }
            else
            {
                Node<T> nuevoNode = new Node<T>();
                nuevoNode.t_object = t;
                Node<T> aux = new Node<T>();
                aux = Head;
                bool exit = false;
                do
                {
                    if (nuevoNode.t_object.CompareTo(aux.t_object) > 0)
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
                    else if (nuevoNode.t_object.CompareTo(aux.t_object) < 0)
                    {
                        if (aux.prev == null)
                        {
                            Node<T> NodoTemp = new Node<T>();
                            NodoTemp.t_object = Head.t_object;
                            NodoTemp.next = Head.next;

                            Head = nuevoNode;
                            Head.next = NodoTemp;
                            if (NodoTemp.next != null)
                            {
                                NodoTemp.next.prev = NodoTemp;
                            }
                            
                            NodoTemp.prev = Head;

                        }
                        else
                        {
                            Node<T> NodoTemp = new Node<T>();
                            NodoTemp.t_object = aux.t_object;
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

        public bool IsFull()
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
                Node<T> aux = new Node<T>();
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

                return aux.t_object;
            }
            else
                return default(T);
        }
        public Node<T> PeekNode(T newValue)
        {
          
            Node<T> aux = new Node<T>();
            aux = Head;
            bool exit = false;
            do
            {
                
                if (newValue.CompareTo(aux.t_object) > 0)
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
                else if (newValue.CompareTo(aux.t_object) < 0)
                {
                    if (aux.prev == null || aux.prev == Head)
                    {
                        return Head;

                    }
                    else
                    {
                        return aux.prev;

                    }
                    


                }
                else
                {
                    return null;

                }

            } while (!exit);
            return aux;
        }

        public void Shift(Node<T> aux, bool hd)
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

        public Node<T> GetHead()
        {
            return Head;
        }

    }
}
