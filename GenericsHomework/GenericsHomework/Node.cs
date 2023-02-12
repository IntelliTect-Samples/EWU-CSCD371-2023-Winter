using System.Collections;

namespace GenericsHomework;

public class Node<T> : ICollection<T>, IEnumerable<T>
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

    private CircularSinglyLinkedList<T>? _List;
    protected CircularSinglyLinkedList<T> List
    {
        get => _List!;
        init => _List = value ?? throw new ArgumentNullException(nameof(List));
    }

    private Node<T>? _Next;
    public Node(T data)
    {
        Data = data;
        Next = this;
        _Count = 1;
    }

    public Node(T data, CircularSinglyLinkedList<T> list) : this(data)
    {
        List = list;
    }

    public void Append(Node<T> head, T data)
    {
        Node<T> temp = head;
        while (temp.Next != head)
        {
            temp = temp.Next;
        }
        Node<T> newNode = new(data, this.List);
        temp.Next = newNode;
        newNode.Next = head;
        _Count++;
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
        Append(List.Head, item);
        /*Node<T> end = this;
        while(end.Next != this)
        {
            end = end.Next;
        }
        end.Next = new(item, this.List)
        {
            Next = this
        };
        _Count++;*/
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
        if(array.Length < Count + arrayIndex)
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
            if (currentNode.Data!.Equals(Data))
            {
                currentNode.Next = currentNode.Next.Next;
                _Count--;
                return true;
            }
            currentNode= currentNode.Next;
        } while (currentNode.Next != this);
        return false;
    }

    public IEnumerator<T> GetEnumerator()
    {
        return this.List;
    }

    IEnumerator<T> IEnumerable<T>.GetEnumerator()
    {
        return this.List;
    }

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return this.List;
    }
}
