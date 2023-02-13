namespace GenericsHomework;
using System;
using System.Collections.Generic;

public class Node<T>
{
    public T Data { get; set; }
    public Node<T> Next { get => _Next; private set => _Next = value ?? throw new ArgumentNullException(nameof(value)); }
    private Node<T> _Next;
    public Node(T data)
    {
        Data = data;
        _Next = this;
    }

    public override string ToString()
    {
        return $"Node Value: {Data}";
    }

    public void Append(T data)
    {
        if (!Exists(data))
        {
            Node<T> newNode = new(data);
            Node<T> nextNode = Next;

            Next = newNode;
            newNode.Next = nextNode;
        }
    }

    public void Append(Node<T> newNode)
    {
        if (!Exists(newNode.Data))
        {
            Node<T> nextNode = Next;

            Next = newNode;
            newNode.Next = nextNode;
        }
    }

    public void Clear()
    {
        // We are going through the list and setting all the nodes to point to themselves.
        // We have to do this because `Next` cannot be null. Otherwise we'd just set `Next` to null for all nodes.
        Node<T> currNode = this;
        Node<T> nextNode;

        while (currNode.Next != this)
        {
            nextNode = currNode.Next;
            currNode.Next = currNode;
            currNode = nextNode;
        }

        Next = this;
    }

    public bool Exists(T data)
    {
        if (data is null)
            throw new ArgumentNullException(nameof(data));

        Node<T> currNode = this;
        do
        {
            if (currNode.Data is not null && currNode.Data.Equals(data))
                return true;

            currNode = currNode.Next;
        } while (currNode != this);

        return false;
    }
}

