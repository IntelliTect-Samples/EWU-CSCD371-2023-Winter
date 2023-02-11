namespace GenericsHomework;

public class Node<T>
{
    public T Data
    {
        get => _Data!;
        set => _Data = value ?? throw new ArgumentNullException(nameof(Data));
    }
    private T? _Data;

    public Node<T> Next
    {
        get => _Next!;
        private set => _Next = value ?? throw new ArgumentNullException(nameof(Next));
    }
    private Node<T>? _Next;
    public Node(T data)
    {
        Data = data;
        Next = this;
    }
    public void Append(Node<T> head, T data)
    {
        Node<T> temp = head;
        while (temp.Next != head)
        {
            temp = temp.Next;
        }
        Node<T> newNode = new(data);
        temp.Next = newNode;
        newNode.Next = head;
    }

    public override string ToString()
    {
        return Data!.ToString()!;
    }

    public bool Exists(Node<T> head, T data)
    {
        Node<T> temp = head;
        while (temp.Next != head)
        {
            if (temp.Data!.Equals(data)) return true;
            else
                temp = temp.Next;
        }
        return temp.Data!.Equals(data);
    }
}
