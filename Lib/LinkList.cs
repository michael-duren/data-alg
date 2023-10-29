using System.Net.NetworkInformation;
using Lib.Interfaces;

namespace Lib
{
    public class Node<T>
    {
        public required T Value { get; set; }
        public Node<T>? Prev { get; set; }
        public Node<T>? Next { get; set; }
    }

    public class LinkList<T> : ILinkList<T>
    {
        private int _length;
        private Node<T>? _head;

        public LinkList()
        {
            _length = 0;
        }

        public void Append(T item)
        {
            throw new NotImplementedException();
        }

        public T? Get(int index)
        {
            throw new NotImplementedException();
        }

        public void InsertAt(T item, int index)
        {
            throw new NotImplementedException();
        }

        public void Prepend(T item)
        {
            Node<T> node = new() { Value = item };

            _length++;

            if (_head is null)
            {
                _head = node;
                return;
            }

            node.Next = _head;
            _head.Prev = node;
            _head = node;
        }

        public T? Remove(T item)
        {
            throw new NotImplementedException();
        }

        public T? RemoveAt(int index)
        {
            throw new NotImplementedException();
        }
    }
}
