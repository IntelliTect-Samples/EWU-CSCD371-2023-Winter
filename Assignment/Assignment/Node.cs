using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace Assignment
{
    public class Node<T> : IEnumerable<T>
    {
        public Node(T value)
        {
            _Value = value;
            _Next = this;
        }

        private readonly T _Value;
        public T Value { get => _Value; }

        private Node<T> _Next;
        public Node<T> Next
        {
            get
            {
                return _Next;
            }
            private set
            {
                _Next = value;
            }
        }

        public override string? ToString()
        {
            if(Value is null) return null;
            else return Value.ToString();
        }

        public void Append(T value)
        {
            if (Exists(value)) throw new ArgumentException("Cannot add dupilicate value");
            Node<T> next = Next;
            Next = new Node<T>(value)
            {
                Next = next
            };
        }

        public void Clear(Node<T> source)
        {
            if (Next == this) return;
            Node<T> next = Next;
            Next = this;
            next.Clear(source);
            // Force sets the Next property to null if the node is not the source nod and therefore we don't care about it
            // Clears any issues with garbage collection (it is no longer pointed to by anything)
            if (source != this) Next = null!;
        }

        public bool Exists(T value)
        {
            Node<T> start = this;
            Node<T> cur = start;
            do
            {
                if (cur.Value is not null && cur.Value.Equals(value))
                    return true;
                cur = cur.Next;
            } while (cur != start);
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> cur = this;
            do
            {
                yield return cur.Value;
                cur = cur.Next;
            } while(cur != this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerable<T> ChildItems(int maximum)
        {
            Node<T> cur = this;
            for(int i = 0; i < maximum; i++)
            {
                cur = cur.Next;
                yield return cur.Value;
                if (cur.Next == this) break;
            }
        }
    }
}