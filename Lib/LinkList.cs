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
        private Node<T>? _tail;

        public LinkList()
        {
            _length = 0;
        }

        public void Append(T item)
        {
            Node<T> node = new() { Value = item };
            _length++;

            if (_tail is null)
            {
                _head = _tail = node;
                return;
            }

            node.Prev = _tail;
            _tail.Next = node;

            _tail = node;
        }

        public T? Get(int index)
        {
            throw new NotImplementedException();
        }

        public void InsertAt(T item, int index)
        {
            if (index > _length)
            {
                throw new IndexOutOfRangeException("Index is outside the bounds of the array.");
            }
            if (index == _length)
            {
                Append(item);
                return;
            }
            if (index == 0)
            {
                Prepend(item);
                return;
            }

            _length++;
            if (_head is null)
            {
                _head = new Node<T>() { Value = item };
                return;
            }
            Node<T> current = _head;

            for (int i = 0; i < index; i++)
            {
                current = current.Next!;
            }

            Node<T> node =
                new()
                {
                    Value = item,
                    Next = current,
                    Prev = current.Prev
                };
            current.Prev = node;

            if (node.Prev is not null)
            {
                current.Prev.Next = current;
            }
        }

        public void Prepend(T item)
        {
            Node<T> node = new() { Value = item };

            _length++;

            if (_head is null)
            {
                _head = node;
                _tail = node;
                return;
            }

            node.Next = _head;
            _head.Prev = node;
            _head = node;
        }

        public T? Remove(T item)
        {
            if (_head is null)
            {
                return default; // if empty return null
            }

            Node<T> current = _head; // start at head
            EqualityComparer<T> comparer = EqualityComparer<T>.Default;
            for (int i = 0; i < _length; i++)
            {
                if (comparer.Equals(current!.Value, item)) // if found break
                    break;

                current = current.Next!;
            }

            if (current is null) // if we didn't find return null
                return default;

            _length--;
            if (_length == 0)
            {
                _head = _tail = null;
                return default;
            }

            if (current.Prev is not null)
                current.Prev = current.Next;

            if (current.Next is not null)
                current.Next = current.Prev;

            if (current == _head)
                _head = current.Next;

            if (current == _tail)
                _tail = current.Prev;

            current.Prev = current.Next = null;
            return current.Value;
        }

        public T? RemoveAt(int index)
        {
            throw new NotImplementedException();
        }
    }
}
