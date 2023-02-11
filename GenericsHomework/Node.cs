namespace GenericsHomework;
using System;
using System.Collections.Generic;

public class Node<T>
{
    public T Data { get; set; }
    public Node<T> Next { get => _Next; set => _Next = value ?? throw new ArgumentNullException(); }
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
}

