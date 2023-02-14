using System.Collections;
using System.Data;

namespace GenericsHomework;

public class Node<T> : ICollection<T>
{
    private Node<T>? _next;

    public Node(T item) => Item = item;

    private Node(T item, Node<T> next)
    {
        Item = item;
        Next = next;
    }

    public Node<T> Next
    {
        get => _next ?? this;
        private set => _next = value;
    }

    public T Item { get; private set; }

    public IEnumerator<T> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Add(T item) => Append(item);


    // We don't need to worry about a circular loop
    // because we set `Next` to `this` for every `Node`, breaking the loop
    public void Clear()
    {
        var node = Next;
        Next = this;
        if (node != this) Next.Clear();
    }

    public bool Contains(T item) => Exists(item);

    public void CopyTo(T[] array, int arrayIndex)
    {
        if (array == null) throw new ArgumentNullException(nameof(array));
        if (arrayIndex < 0) throw new ArgumentOutOfRangeException(nameof(arrayIndex));
        var node = this;
        do
        {
            array[arrayIndex++] = node.Item;
            node = node.Next;
        } while (node.Next != node);
    }

    public bool Remove(T item)
    {
        var node = this;
        while (true)
        {
            if (Equals(node.Item, item))
            {
                node.Item = node.Next.Item;
                node.Next = node.Next;
                return true;
            }

            if (node.Next == node) return false;
        }
    }

    public int Count
    {
        get
        {
            int i = 1;
            var node = this;
            while (node.Next != node)
            {
                node = node.Next;
                i++;
            }

            return i;
        }
    }

    public bool IsReadOnly => false;

    public void Append(T item)
    {
        Next = !Exists(item) ? new Node<T>(item, Next) : throw new DuplicateNameException();
    }

    public override string? ToString()
    {
        return Item?.ToString();
    }

    public bool Exists(T item) => Equals(item, Item) || (Next != this && Next.Exists(item));
}