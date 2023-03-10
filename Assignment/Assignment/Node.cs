using System;
using System.Collections;
using System.Collections.Generic;

namespace Assignment;

public class Node<T> : ICollection<T>, IEnumerable<T>
{
    public T? Value { get; set; }
    public Node<T> Next { get; private set; }

    public int Count
    {
        get
        {
            int count = 0;
            foreach (T element in this)
                count++;
            return count;
        }
    }

    public bool IsReadOnly { get; } = false;

    public Node(T? value)
    {
        Value = value;
        Next = this;
    }

    public override string ToString()
    {
        return Value?.ToString() ?? "null";
    }

    // Clear should set every node in the list to point to itself.
    // This will release the allocated memory because we will remove the circular dependency
    public void Clear()
    {
        Node<T> current = this;
        do
        {
            Node<T> next = current.Next;
            current.Next = current;
            current = next;
        } while (current != this);
    }

    public void Append(T value)
    {
        if (Exists(value))
            throw new ArgumentException("Value already exists in the list ", nameof(value));

        // Create a new node and insert it between this and this.Next
        Node<T> newNode = new(value)
        {
            Next = this.Next
        };
        this.Next = newNode;
    }

    public bool Exists(T value)
    {
        Node<T> current = this;
        do
        {
            if (object.Equals(value, current.Value))
                return true;
            current = current.Next;
        } while (current != this);
        return false;
    }

    public void Add(T item)
    {
        Append(item);
    }

    public bool Contains(T item)
    {
        return Exists(item);
    }

    public void CopyTo(T[] array, int index)
    {
        if (array is null)
        {
            throw new ArgumentNullException(nameof(array));
        }

        // index should be in array bounds
        // also index+Count should be in bounds so we can copy all items
        if (index < 0 || (index + Count) > array.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }

        Node<T> current = this;

        do
        {
            array[index] = current.Value!;
            current = current.Next;
            index++;
        } while (current != this);
    }

    public bool Remove(T item)
    {
        Node<T> current = this;
        Node<T> previous = current;
        do
        {
            if (object.Equals(item, current.Value))
            {
                if (current == this)
                    return false;

                // Connect previous to point to what removed node.Next was
                previous.Next = current.Next;
                current.Next = current; // Removed element point to itself
                return true;
            }
            previous = current;
            current = current.Next;
        } while (current != this);
        return false; // item not found
    }

    IEnumerator<T> IEnumerable<T>.GetEnumerator()
    {
        return (IEnumerator<T>)this.GetEnumerator();
    }

    public IEnumerator GetEnumerator()
    {
        Node<T> current = this;
        do
        {
            yield return current.Value!;
            current = current.Next;
        } while (current != this);
    }

    public IEnumerable<T> ChildItems(int maximum)
    {
        if (maximum > 0)
        {
            Node<T> current = this;
            do
            {
                yield return current.Value!;
                current = current.Next;
                maximum--;
            } while (current != this && maximum > 0);
        }
    }
}