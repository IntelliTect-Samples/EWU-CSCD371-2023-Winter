namespace GenericsHomework;

public class CircularSinglyLinkedList<T>
{
    public Node<T>? Head { get; set; }

    public int Size { get; private set; }

    public CircularSinglyLinkedList() 
    {
        Head = null;
        Size = 0;
    }

    public bool Exists(T data) 
    {
        if(Head is null) return false;
        return Head.Exists(Head, data);
    }

    public void Append(T data)
    {
        if (Head is null) 
        {
            Head = new Node<T>(data);
            Size++;
        }
        else if (Exists(data))
        {
            throw new ArgumentException("Given data already exists in the list", nameof(data));
        }
        else
        {
            Head.Append(Head, data);
            Size++;
        }     
    }

    public T Get(int index)
    {
        return GetNode(index).Data;
    }

    public Node<T> GetNode(int index)
    {
        if (Head is null)
            throw new ArgumentOutOfRangeException(nameof(index));
        Node<T> currentNode = Head;
        for (int i = 0; i < index; i++)
        {
            currentNode = currentNode.Next;
            if (currentNode == Head)
                throw new ArgumentOutOfRangeException(nameof(index));
        }
        return currentNode;
    }

    public void Clear(T data) 
    {
        if (Exists(data))
        {
            Head = new(data);
            Size = 1;
        }
    }
}
