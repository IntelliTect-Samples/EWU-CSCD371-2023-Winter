using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace Assignment
{
    public class Node<T>: IEnumerable<Node<T>>
    {

        private readonly T _value;
        private Node<T> _next;
        private Node<T> _last;
        
        public Node(T value)
        {
            _value = value;
            _next = this;
            _last = this;
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
                node = node.Next;
            }
            node.Next = Next;
            Next = this;
            // Note that any disconnected nodes will not be found in the reference tree next time and automatically garbage collected.
            // At least once all local instances of other nodes pass out of scope.
        }


        public IEnumerable<Node<T>> ChildItems(int maximum)
        {
            List<Node<T>> child = new();
            Node<T> currentNode = _last;

            int counter = 1;
            do
            {
                child.Add(currentNode);
                counter++;
                currentNode = currentNode.Next;
            } while (currentNode != _last && counter < maximum);
            return child;
        }
        public IEnumerator<Node<T>> GetEnumerator()
        {
            Node<T> current = this;

            do
            {
                yield return current;

                current = current.Next;
            } while (current != this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();

        }
    }
}

