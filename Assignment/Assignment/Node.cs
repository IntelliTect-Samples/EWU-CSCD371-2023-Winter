using System.Collections;
using System.Collections.Generic;

public class Node<T> : IEnumerable<T>
{
    public Node(T value)
    {
        Value = value;
    }

    public T Value { get; set; }
    public Node<T>? Next { get; set; }

    public void Add(T value)
    {
        if (Next == null)
        {
            Next = new Node<T>(value);
        }
        else
        {
            Next.Add(value);
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        Node<T>? current = this;

        while (current != null)
        {
            yield return current.Value;
            current = current.Next;
            if (current == this) // return back to the start
            {
                yield break;
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public IEnumerable<T> ChildItems(int maximum)
    {
        int count = 0;
        Node<T>? current = Next;

        while (current != null && count < maximum)
        {
            yield return current.Value;
            current = current.Next;
            count++;
        }
    }
}