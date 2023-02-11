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

    /*
     * We do not need to worry about the garbage collector once the Clear() method is called.
     * 
     * The "Head" node of a CircularSinglyLinkedList lives on the stack for the entire scope of
     * the list. Unless the "Head" node of the CircularSinglyLinkedList is null (the list is empty),
     * it points to the first node in the list. As long as a node can be reached by a path originating
     * from the "Head" node it is considered to be "reachable" and will be marked "Do Not Collect" by 
     * the Garbage Collector. If a node CANNOT be reached from a reference originating from the "Head"
     * node it will not be marked as "Do Not Collect" and will be collected as soon as the Generation 
     * heap it belongs to begins to gets full.
     * 
     * The way our Clear() method works is by simply creating a new node with the data of the single
     * node that is intended to be kept, and assigning this new node to "Head". The "Head" node will 
     * reference from the stack, the new node which is on the heap, and the new node will reference 
     * itself with its "Next" field. This will make it so the only node on the heap that is reachable
     * from the stack is the first node, the new node that was created containing the data of node
     * that was to be kept. Therefore all the other nodes that were on the list are not "reachable"
     * from the stack and will be removed from the heap as soon as the heap begins to get full. 
     * 
     */
    public void Clear(T data) 
    {
        if (Exists(data))
        {
            Head = new(data);
            Size = 1;
        }
    }
}
