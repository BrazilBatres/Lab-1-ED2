using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    public class MultiPathTree<T> where T:IComparable
    {
        MultiPathNode<T> Root;
        int degree;
        public MultiPathTree (int dgree)
        {
            if (dgree<2)
            {
                Root = new MultiPathNode<T>(2);
                degree = 2;
            }
            else
            {
                Root = new MultiPathNode<T>(dgree);
                degree = dgree;
            }
        }
        public bool Insert(T value)
        {
            if (!Root.IsFull())
            {
                Root.Enlist(value);
                return true;
            }
            else
            {
                Node<T> aux = new Node<T>();
                aux = Root.PeekNode(value);
                if (aux != null)
                {

                    if (aux.prev == null && value.CompareTo(aux.t_object) < 0)
                    {
                        if (aux.LeftChild != null)
                        {
                            return RecursiveInsert(value, aux.LeftChild);
                        }
                        else
                        {
                            CreateNode(aux, value, true);
                            return true;
                        }


                    }
                    else
                    {
                        if (aux.RightChild != null)
                        {
                            return RecursiveInsert(value, aux.RightChild);
                        }
                        else
                        {
                            CreateNode(aux, value, false);
                            return true;
                        }

                    }
                }
                else
                {
                    return false;
                }

            }

        }
        bool RecursiveInsert(T value, MultiPathNode<T> SubTree)
        {
            if (!SubTree.IsFull())
            {
                SubTree.Enlist(value);
                return true;
            }
            else
            {
                Node<T> aux = new Node<T>();
                aux = SubTree.PeekNode(value);
                if (aux != null)
                {
                    if (aux.prev == null && value.CompareTo(aux.t_object) < 0)
                    {
                        if (aux.LeftChild != null)
                        {
                            return RecursiveInsert(value, aux.LeftChild);
                        }
                        else
                        {
                            CreateNode(aux, value, true);
                            return true;
                        }


                    }
                    else
                    {
                        if (aux.RightChild != null)
                        {
                            return RecursiveInsert(value, aux.RightChild);
                        }
                        else
                        {
                            CreateNode(aux, value, false);
                            return true;
                        }

                    }
                }
                else
                {
                    return false;
                }

            }
        }
        void CreateNode(Node<T> dad, T newValue, bool headLeft)
        {
            MultiPathNode<T> newNode = new MultiPathNode<T>(degree);
            newNode.Enlist(newValue);
            if (headLeft)
            {
                dad.LeftChild = newNode;
            }
            else
            {
                dad.RightChild = newNode;
            }

        }

        public void InOrder(List<T> lista)
        {

            RecursiveInOrder(lista, Root);

        }
        private void RecursiveInOrder(List<T> _list, MultiPathNode<T> actualNode)
        {
            if (actualNode != null)
            {
                Node<T> head = actualNode.GetHead();
                if (head != null)
                {
                    RecursiveInOrder(_list, head.LeftChild);
                    _list.Add(head.t_object);
                    RecursiveInOrder(_list, head.RightChild);
                    Node<T> aux = head;
                    while (aux.next != null)
                    {
                        aux = aux.next;
                        _list.Add(aux.t_object);
                        RecursiveInOrder(_list, aux.RightChild);

                    }
                }
                
            }
        }
        public void PostOrder(List<T> lista)
        {

            OriginalRecursivePostOrder(lista, Root);

        }
       
        private void RecursivePostOrder(List<T> _list, MultiPathNode<T> actualNode) //Explicado el sábado
        {
            if (actualNode != null)
            {
                Node<T> head = actualNode.GetHead();
                if (head != null)
                {
                    RecursivePostOrder(_list, head.LeftChild);
                    RecursivePostOrder(_list, head.RightChild);
                    _list.Add(head.t_object);
                    Node<T> aux = head;
                    while (aux.next != null)
                    {
                        aux = aux.next;
                        RecursivePostOrder(_list, aux.RightChild);
                        _list.Add(aux.t_object);


                    }

                }
                
            }
        }
        private void OriginalRecursivePostOrder(List<T> _list, MultiPathNode<T> actualNode) //Explicado en clase
        {
            if (actualNode != null)
            {
                Node<T> head = actualNode.GetHead();
                if (head != null)
                {
                    OriginalRecursivePostOrder(_list, head.LeftChild);
                    OriginalRecursivePostOrder(_list, head.RightChild);
                    Node<T> aux = head;
                    while (aux.next != null)
                    {
                        aux = aux.next;
                        OriginalRecursivePostOrder(_list, aux.RightChild);



                    }
                    _list.Add(head.t_object);
                    aux = head;
                    while (aux.next != null)
                    {
                        aux = aux.next;

                        _list.Add(aux.t_object);


                    }


                }
                
            }
        }
        public void PreOrder(List<T> lista)
        {

            RecursivePreOrder(lista, Root);

        }
        private void RecursivePreOrder(List<T> _list, MultiPathNode<T> actualNode) 
        {
            if (actualNode != null)
            {
                Node<T> head = actualNode.GetHead();
                
                if (head != null)
                {
                    _list.Add(head.t_object);
                    Node<T> aux = head;
                    while (aux.next != null)
                    {
                        aux = aux.next;

                        _list.Add(aux.t_object);


                    }
                    aux = head;
                    RecursivePreOrder(_list, head.LeftChild);
                    RecursivePreOrder(_list, head.RightChild);
                    while (aux.next != null)
                    {
                        aux = aux.next;
                        RecursivePreOrder(_list, aux.RightChild);



                    }


                }

                


            }
        }
        Node<T> FindMinor(MultiPathNode<T> actualNode)
        {
            Node<T> head = actualNode.GetHead();
            if (head.LeftChild != null)
            {
                return FindMinor(head.LeftChild);
            }
            else
            {
                return head;
            }
        }
    }
}
