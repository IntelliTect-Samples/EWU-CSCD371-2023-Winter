namespace GenericsHomework;

public class Node<T>
{
    public T Value { get; set; }
    public Node<T> Next { get; private set; }

    public Node(T value)
    {
        Value = value;
        Next = this;
    }

    public override string ToString()
    {
        return Value?.ToString() ?? "null";
    }

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
            throw new ArgumentException("Value already exists in the list", nameof(value));

        // Create a new node and insert it between this and this.Next
        Node<T> newNode = new Node<T>(value)
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
}