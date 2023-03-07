using System;
using System.Collections;
using System.Collections.Generic;

namespace Assignment;
public class Node<T> : IEnumerable<T>
{
    private int Size { get; set; }
    public T? Item { get; set; }
    public Node<T> Next
    { get; private set; }

    public Node(T? item, Node<T> next)
    {
        Item = item;
        Next = next ?? this;
        Size = 1;
    }
    public IEnumerator<T> GetEnumerator()
    {
        Node<T> n = this.Next;
        yield return this.Item!;
        while(n != this)
        {
            yield return n.Item!;
            n = n.Next;
        }
    }
    IEnumerator IEnumerable.GetEnumerator() { 
        return GetEnumerator();
    }

    public IEnumerable<T> ChildItems(int max)
    {
        List<T> list = new();
        Node<T> n = this.Next;
        int i = 0;
        while (n != this)
        {
            if(i < max)
            {
                list.Add(n.Item!);
                n = n.Next;
            }
            i++;
        }
        return list;
    }

    public override string ToString()
    {
        return Item!.ToString() ?? "null";
    }

    public void Append(T item)
    {
        if (Next.Exists(item)) throw new ArgumentException(nameof(item) + " already exists");
        Next = new Node<T>(item, Next);
        Size++;
    }

    public bool Exists(T item)
    {
        bool result = false;
        if (Item is not null && Item.Equals(item))
        {
            result = true;
        }
        else
        {
            Node<T> current = Next;
            for (int i = 0; i < Size; i++)
            {
                if (current.Item is not null && current.Item.Equals(item)) result = true;
                else current = current.Next;
            }
        }
        return result;
    }

    public void Clear()
    {
        Next = this;
    }
    //I believe that it will all be garbage collected by simply disconnecting the rest of the list from the current node
    //because from my understanding it is irrelevant what an object points to as long as it itself is not pointed to
    //in regards to garbage collecting. Ergo, I think by removing the rest of the list from this "head", they will all
    //inevitably be collected. Even if only iteratively and not in like one fell swoop.
    //For example, if you have a list A > B > C > D, and you were to call clear on B, then C would no longer be pointed to
    //and be collected. C getting collected means D is no longer pointed to and will be collected. Then D's collection
    //means A is no longer pointed to and would be collected. Leaving only the original node that called clear, B, remaining.
    //So while I'm unsure if they could all be taken at once, it seems to me that in the end they'd all be collected.
}