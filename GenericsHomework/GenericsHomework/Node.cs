using System.Collections;
using System.Data;

namespace GenericsHomework;

public class Node<T> : ICollection<T>
{
    private Node<T>? _next;

    public Node(T item)
    {
        Item = item;
    }

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

    public T Item { get; }

    public IEnumerator<T> GetEnumerator()
    {
        return new NodeEnum(this);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Add(T item)
    {
        Append(item);
    }


    // We don't need to worry about a circular loop not being garbage collected
    // because we set `Next` to `this` for every `Node`, breaking the loop
    public void Clear()
    {
        var node = Next;
        Next = this;
        if (node != this) Next.Clear();
    }

    public bool Contains(T item)
    {
        return Exists(item);
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        if (array == null) throw new ArgumentNullException(nameof(array));
        if (arrayIndex < 0) throw new ArgumentOutOfRangeException(nameof(arrayIndex));
        var node = this;
        do
        {
            array[arrayIndex++] = node.Item;
            node = node.Next;
        } while (node != this);
    }

    public bool Remove(T item)
    {
        var node = this;
        var prevNode = this;
        while (prevNode.Next != node) prevNode = node.Next;
        do
        {
            if (Equals(node.Item, item))
            {
                prevNode.Next = node.Next;
                return true;
            }

            node = node.Next;
            prevNode = prevNode.Next;
        } while (node != this);

        return false;
    }

    public int Count
    {
        get
        {
            int i = 1;
            var node = this;
            while (node.Next != this)
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

    public bool Exists(T item)
    {
        return Equals(item, Item) || (Next != this && Next.Exists(item));
    }

    public class NodeEnum : IEnumerator<T>
    {
        private readonly Node<T> Home;
        private Node<T> _current;

        public NodeEnum(Node<T> current)
        {
            _current = current;
            Home = current;
        }

        public bool MoveNext()
        {
            if (_current.Next == Home) return false;
            _current = _current.Next;
            return true;
        }

        public void Reset()
        {
            _current = Home;
        }

        public T Current => _current.Item;

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            _current.Remove(Current);
        }
    }
}