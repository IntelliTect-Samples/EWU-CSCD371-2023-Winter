using System;
using System.Collections;

public class Node<T> : IEnumerable<T> where T : notnull
{
    public T Data { get; set; }
    public Node<T> Next { get => _Next!; private set => _Next = value ?? throw new ArgumentNullException(nameof(value)); }
    private Node<T>? _Next;
    public Node(T data)
    {
        Data = data;
        _Next = this;
    }

    public override string ToString()
    {
        return $"Node value: {Data}";
    }

    public void Append(T data)
    {
        if (Exists(data)) throw new InvalidDataException($"The specified data {nameof(data)} already exists in the list!");

        Node<T> newNode = new(data);
        newNode.Next = Next;
        Next = newNode;

    }

    public void Append(Node<T> newNode)
    {
        if (Exists(newNode.Data)) throw new InvalidDataException($"The specified data {nameof(newNode)} already exists in the list!");

        newNode.Next = Next;
        Next = newNode;
    }

    public void Clear()
    {
        /*
            We are going through the list and setting all the nodes to point to themselves.
            We have to do this because `Next` cannot be null. Otherwise we'd just set `Next` to null for all nodes.
            
            This works because the garbage collector looks to see if there are any root references to each object.
            Since the only reference to each node will be itself, it is technically out of scope and doesn't have any root references,
            and therefore will be garbage collected.
        */
        Node<T> currentNode = this;
        Node<T> nextNode;

        while (currentNode.Next != this)
        {
            nextNode = currentNode.Next;
            currentNode.Next = currentNode;
            currentNode = nextNode;
        }

        Next = this;
    }

    public bool Exists(T data)
    {
        if (data is null)
            throw new ArgumentNullException(nameof(data));

        Node<T> currrentNode = this;
        do
        {
            if (currrentNode.Data is not null && currrentNode.Data.Equals(data))
                return true;

            currrentNode = currrentNode.Next;
        } while (currrentNode != this);

        return false;
    }


    public IEnumerator<T> GetEnumerator()
    {
        Node<T>? current = this;
        do
        {
            yield return current.Data;
            current = current.Next;
        } while (current != this && current != null);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}