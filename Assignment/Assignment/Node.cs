using System;
using System.Collections;
using System.Collections.Generic;

namespace Assignment
{
    public class Node<TValues> : IEnumerable<Node<TValues>>
    {
        public TValues Value { get; set; }
        public Node<TValues> Next { get; private set; }
        public Node<TValues> Last;

        public Node(TValues value)
        {
            Value = value;
            Next = this;
            Last = this;
        }

        public Node(TValues value, Node<TValues> node)
        {
            Value = value;
            Next = node;
            Last = this;
        }

        public void Append(TValues value)
        {
            bool keyValueExists = Exists(value);
            if (keyValueExists == true)
            {
                throw new ArgumentException("Can not add duplicate values");
            }
            Node<TValues> lastNode = GetLast();
            lastNode.Next = new Node<TValues>(value, Last);
        }

        public Node<TValues> GetLast()
        {
            Node<TValues> currentNode = Last;
            while (currentNode.Next != Last)
            {
                currentNode = currentNode.Next;
            }
            return currentNode;
        }
        public void Clear()
        {
            //The garbage collector picks up objects once they are no longer referenced.
            //Thus removing the next node would delete it and the node it was pointing to.
            //and the current node is only pointing to itself.

            Last.Next = this;
        }
        public Boolean Exists(TValues key)
        {
            Node<TValues> currentNode = Last;
            do
            {
                if (key is null)
                {
                    if (currentNode.Value is null)
                        return true;
                }
                else if (key.Equals(currentNode.Value))
                    return true;
                currentNode = currentNode.Next;
            } while (currentNode != Last);

            return false;
        }

        public override string ToString()
        {
            string? stringReturn = null;
            if (Value is not null)
                stringReturn = Value.ToString();
            if (stringReturn is null)
                return "";
            return stringReturn;
        }

        public IEnumerable<Node<TValues>> ChildItems(int maximum)
        {
            List<Node<TValues>> child = new();
            Node<TValues> currentNode = Last;

            int counter = 1;
            do
            {
                child.Add(currentNode);
                counter++;
                currentNode = currentNode.Next;
            } while (currentNode != Last && counter < maximum);
            return child;
        }

        public IEnumerator<Node<TValues>> GetEnumerator()
        {
            Node<TValues> current = this;

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