using System.Data;

namespace GenericsHomework;

public class Node<T>
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

    public T Item { get; }
    
    public void Append(T item) => Next = !Exists(item) ? new Node<T>(item, Next) : throw new DuplicateNameException();

    public override string? ToString() => Item?.ToString();

    // We don't need to worry about a circular loop
    // because we set `Next` to `this` for every `Node`, breaking the loop
    public void Clear()
    {
        var node = Next;
        Next = this;
        if (node != this) Next.Clear();
    }

    public bool Exists(T item) => Equals(item, Item) || (Next != this && Next.Exists(item));
}