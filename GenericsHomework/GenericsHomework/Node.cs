using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsHomework.GenericsHomework;

public class Node<T>
{
    public T? Data { get; set; }
    private int Size { get; set; }
    public Node<T> Next { get; set; }
    public Node(T? data)
    {
        Data = data;
    }
    public override string ToString()
    {
        return Data?.ToString() ?? "null";
    }
    public void Append(T data)
    {
        Next = new Node<T>(data);
    }
    public bool existing(T data)
    {
        if(data is null)
        {
            throw new ArgumentNullException(nameof(data));
        }
        Node<T> cur = Next;
        while(cur != null) 
        {
            if (cur.Data.Equals(data)) { return true; }
            cur = cur.Next;
        }
        return false;

    }
}
