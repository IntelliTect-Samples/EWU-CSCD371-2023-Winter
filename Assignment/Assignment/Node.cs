using System;
using System.Collections;
using System.Collections.Generic;

namespace Assignment;

public class Node<T> : ICollection<T>
{
    public T Value { get; }

    public Node<T> Next { get; private set; }

    public Node(T value)
    {
        Value = value;
        Next = this;
    }

    public Node<T> Append(T value)
    {
        if (Exists(value))
            throw new ArgumentException("Cannot add same value more than once", nameof(value));

        var next = Next;
        Next = new Node<T>(value)
        {
            Next = next
        };
        return Next;

    }

    public bool Exists(T value)
    {
        var current = this;
        do
        {
            if (EqualityComparer<T>.Default.Equals(current.Value, value))
                return true;

            current = current.Next;
        } while (current != this);

        return false;
    }

    public IEnumerable<T> ChildItems(int maximum)
    {
        int count = 0;
        var current = this;

        while (current.Next != this && ++count <= maximum)
        {
            yield return current.Next.Value;
            current = current.Next;
        }
    }

    void ICollection<T>.Add(T item)
    {
        Append(item);
    }

    // I interpret this to mean clearing all the connections in the entire chain, if it were named 'remove'
    // then I would disconnect the calling node and mend the loop, since this is not the case, I set the 'next' property
    // of every connected node to itself so that every node stands alone. On the chance
    // that there is a reference to one of other the nodes further down the line held in some other
    // location outside of the chain, this will prevent broken behavior and allow that node to continue being
    // a functional collection with a single item. This decision was not influenced by garbage collection, because
    // GC will collect anything not accessible from the root, circular references in the ether will be collected.
    public void Clear()
    {
        if (Next == this)
            return;
        var oldNext = Next;
        Next = this;
        oldNext.Clear();
    }

    bool ICollection<T>.Contains(T item)
    {
        return Exists(item);
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        var count = Count;
        var current = this;
        for (int i = arrayIndex; i < arrayIndex + count; i++)
        {
            array[i] = current.Value;
            current = current.Next;
        }
    }

    public bool Remove(T item)
    {
        if (!Exists(item))
            return false;
        var current = this;
        while (!EqualityComparer<T>.Default.Equals(current.Next.Value, item))
        {
            current = current.Next;
        }

        // get the node to remove
        var toRemove = current.Next;
        // set the node behind it's next to the removed node's next (bridge the gap that gets created)
        current.Next = toRemove.Next;
        // apply a self-reference to the removed node
        toRemove.Next = toRemove;

        return true;
    }

    public int Count
    {
        get
        {
            var count = 1;
            var current = this.Next;
            while (current != this)
            {
                count++;
                current = current.Next;
            }

            return count;
        }
    }

    public bool IsReadOnly => false;

    public IEnumerator<T> GetEnumerator()
    {
        var current = this;
        do
        {
            yield return current.Value;
            current = current.Next;
        } while (current != this);
    }

    public override string? ToString()
    {
        return Value?.ToString();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
