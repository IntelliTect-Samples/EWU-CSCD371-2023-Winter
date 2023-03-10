using System;
using System.Collections;
using System.Collections.Generic;

namespace Assignment
{
    public class Node<T> : IEnumerable<T>
{
    private readonly T _value;
    private Node<T> _next;
    public Node(T value)
    {
        _value = value;
        _next = this;
    }

    public T Value { get { return _value; } }

    public IEnumerator<T> GetEnumerator()
    {
            var node = this;

            do
            {
                yield return node.Value;
                node = node.Next;
            }
            while (node.Next != Next);

    }
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
        var node = Next;
        while (node.Next != this)
        {
            node = node.Next;
        }
        node.Next = Next;
        Next = this;
    }
        public IEnumerable<T> ChildItems(int maximum)
        {
            int count = 0;
            var node = this;
            do
            {
                yield return node.Value;
                node = node.Next;
                count++;
            }
            while (node.Next != Next && count < maximum - 1);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

