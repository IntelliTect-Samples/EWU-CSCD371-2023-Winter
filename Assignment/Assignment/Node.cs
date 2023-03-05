using System;
using System.Collections;
using System.Collections.Generic;

namespace Assignment
{
    public class Node<T> : IEnumerable<T>
    {
        private readonly T _value;
        private Node<T> _next;
        private static List<Node<T>> InternalCollection = new List<Node<T>>();

        public Node(T value)
        {
            _value = value;
            _next = this;
            InternalCollection.Add(this);
        }

        public T Value { get { return _value; } }

        public override string? ToString()
        {
            if (_value == null) return null;
            return _value.ToString();
        }

        public Node<T> Next
        {
            get { return _next; }
            private set
            {
                _next = value;
            }
        }

        public Node<T> Append(T value)
        {
            if (Exists(value)) throw new ArgumentException("This item already exists in the list");
            Node<T> newNode = new(value);
            //InternalCollection.Add(value);
            newNode.Next = Next;
            Next = newNode;
            return newNode;
        }

        public bool Exists(T value)
        {
            var node = this;
            do
            {
                if (EqualityComparer<T>.Default.Equals(node.Value, value)) return true;
                node = node.Next;
            } while (node != this);
            return false;
        }

        public void Clear()
        {
            // Setting Next = this is sufficient, however if any other references to nodes are held outside the list, 
            // this cleans them up so that all nodes' Next property reference themselves.

            // This loops around all the nodes and sets all their Next properties to themselves effectively eliminating the list.
            // This works even if there is only a single node.
            var node = Next;
            while (node.Next != this)
            {
                InternalCollection.Remove(node);
                node = node.Next;
            }
            InternalCollection.Remove(node);
            node.Next = Next;
            Next = this;
            // Note that any disconnected nodes will not be found in the reference tree next time and automatically garbage collected.
            // At least once all local instances of other nodes pass out of scope.
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (Node<T> item in InternalCollection) 
            {
                yield return item.Value;
            }
        }

        public IEnumerable<T> GetAllItems() 
        {
            foreach (Node<T> items in InternalCollection) 
            {
                yield return items.Value;
            }
        }

        public IEnumerable<T> ChildItems(int maximum) 
        {
            int count = maximum;
            foreach (Node<T> item in InternalCollection) 
            {
                if (count > 1) 
                {
                    yield return item.Value;
                }
                count--;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}


