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

        public LinkList(T[] items)
        {
            _length = 0; // start length at 0

            // add each item to the list on creation
            foreach (T item in items)
            {
                Append(item);
            }
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < _length; i++)
            {
                if (Get(i)!.Equals(item))
                    return true;
            }

            return false;
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

            Node<T>? current = GetAt(index); // get the node of the current index

            if (current is null)
                return;

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
                node.Prev.Next = current;
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
                if (comparer.Equals(current.Value, item)) // if found break
                    break;

                current = current.Next!; // else get next node
            }

            if (current is null) // if we didn't find return null
                return default;

            // decreased length in removeNode
            return RemoveNode(current); // else remove the node
        }

        public T? RemoveAt(int index)
        {
            Node<T>? node = GetAt(index);

            if (node is null)
                return default;

            return RemoveNode(node);
        }

        public T? Get(int index)
        {
            Node<T>? node = GetAt(index);
            if (node is not null)
                return node.Value;

            return default;
        }

        private T? RemoveNode(Node<T> node)
        {
            _length--;

            if (_length == 0) // if we are removing last item
            {
                if (_head is null)
                    return default;
                T valueOut = _head.Value;
                _head = _tail = null;
                return valueOut;
            }

            if (node.Prev is not null)
                node.Prev.Next = node.Next;

            if (node.Next is not null)
                node.Next.Prev = node.Prev;

            if (node == _head)
                _head = node.Next;

            if (node == _tail)
                _tail = node.Prev;

            node.Prev = node.Next = null;
            return node.Value;
        }

        private Node<T>? GetAt(int index)
        {
            Node<T>? current = _head;
            if (current is null)
                return null;

            for (int i = 0; i < index; i++)
            {
                if (current.Next is null)
                    return null;
                current = current.Next;
            }

            return current;
        }
    }
}
