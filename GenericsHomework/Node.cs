namespace GenericsHomework;
using System;
using System.Collections.Generic;

public class Node<T>
{
    public T Data { get; set; }
    public Node<T> Next { get; set; }
    public Node(T data)
    {
        Data = data;
        Next = this;
    }

    public override string ToString()
    {
        return $"Node Value: {Data}";
    }
}

