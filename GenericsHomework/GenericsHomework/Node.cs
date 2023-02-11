namespace GenericsHomework;

public class Node<T> : ICollection<T>
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

    private int _Count;
    public int Count => _Count!;

    public bool IsReadOnly => false;

    public bool IsHead { get; }

    private Node<T>? _Next;
    public Node(T data)
    {
        Data = data;
        Next = this;
        _Count = 1;
    }
    public Node(T data, bool isHead): this(data)
    {
        IsHead = isHead;
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
//        _Count++;
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

    public void Add(T item)
    {
        Node<T> end = this;
        while(!end.Next.IsHead)
        {
            end = end.Next;
        }
        end.Next = new(item)
        {
            Next = this
        };
        _Count++;
    }

    public void Clear()
    {
        Next = this;
        _Count = 1;
    }

    public bool Contains(T item)
    {
        Node<T> currentNode = this;
        while (currentNode.Next != this)
        {
            if (currentNode.Data!.Equals(currentNode)) return true;
            else
                currentNode = currentNode.Next;
        }
        return false;
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        if(array.Length < this.Count + arrayIndex)
            throw new ArgumentOutOfRangeException(nameof(array), "array.Length must be >= list.Count + arrayIndex");
        Node<T> currentNode = this;
        int currentIndex = arrayIndex;
        do
        {
            array[currentIndex++] = currentNode.Data;
            currentNode = currentNode.Next;
        } while (currentNode != this);
    }

    public bool Remove(T item)
    {
        Node<T> currentNode = this;
        do
        {
            if (currentNode.Data!.Equals(this.Data))
            {
                currentNode.Next = currentNode.Next.Next;
                _Count--;
                return true;
            }
            currentNode= currentNode.Next;
        } while (currentNode.Next != this);
        return false;
    }

    // TODO: properly implement this
    public IEnumerator<T> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    // TODO: properly implement this
    IEnumerator<T> IEnumerable<T>.GetEnumerator()
    {
        throw new NotImplementedException();
    }

    // TODO: properly implement this
    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }
}
