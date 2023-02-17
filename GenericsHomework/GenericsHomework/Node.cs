using System.Runtime.CompilerServices;

namespace GenericsHomework;

public class Node<T>
{
    public T Value { get { return valueActual; } }

    public Node<T> next;

    public T valueActual;

    public Node(T value)
    {
        valueActual = value;
        next = this;
    }
    public Node<T> Next
    {
        get { return next; }
        private set { next = value; }
    }
    public override string ToString()
    {
        return valueActual?.ToString() ?? "is null";
    }

    public Node<T> Append(T value)
    {
        if (Exists(value))
        {
            throw new ArgumentException("Duplicate value.");
        }
        Node<T> added = new(value);
        added.Next = Next;
        Next = added;
        return added;
    }

    public void Clear()
    {
        var node = this.Next;

        while (node.Next != this)
        {
            node = node.Next;
        }
        node.Next = Next;
        Next = this;
    }
    public bool Exists(T value)
    {
        var currentNode = this;
        do
        {
        if (currentNode.Value is null && value is null)
        {
            return true;
        }
        else if (currentNode.Value!.Equals(value))
        {
            return true;
        }
        currentNode = currentNode.Next;
        }
        while (currentNode != this);
        return false;
    }

}

