using System;
using System.Collections.Generic;

namespace Assignment;

public class Node<T>
{
    public Node(T value)
    {
        Value = value == null ? throw new ArgumentNullException(nameof(value)) : value;
        Next = this;
    }

    private T Value { get; set; }
    public Node<T> Next { get; private set; }

    public void Append(T value)
    {
        Node<T> newNode = new Node<T>(value)
        {
            Next = this
        };

        Node<T> currentNode = this;
        while (currentNode.Next != this)
        {
            if (currentNode.Next.Value !.Equals(value))
            {
                throw new ArgumentException("Value already exists in list");
            }
            currentNode = currentNode.Next;
        }
        currentNode.Next = newNode;
    }

    public IEnumerable<T> AllChildItems()
    {
        Node<T> currentNode = this;
        yield return currentNode.Value !;
        while (currentNode.Next != this)
        {
            yield return currentNode.Next.Value !;
            currentNode = currentNode.Next;
        }
    }

    public IEnumerable<T> ChildItems(int maximum)
    {
        Node<T> currentNode = this;
        yield return currentNode.Value !;
        maximum--;
        while (currentNode.Next != this && maximum > 0)
        {
            yield return currentNode.Next.Value !;
            currentNode = currentNode.Next;
            maximum--;
        }
    }

    public override string ToString()
    {
        return Value !.ToString() !;
    }

    public void RemoveAllChildItems()
    {
        Next = this;
    }

    public bool Exist(T value)
    {
        Node<T> currentNode = this;
        while (currentNode.Next != this)
        {
            if (currentNode.Next.Value !.Equals(value))
            {
                return true;
            }
            currentNode = currentNode.Next;
        }
        return false;
    }
}
