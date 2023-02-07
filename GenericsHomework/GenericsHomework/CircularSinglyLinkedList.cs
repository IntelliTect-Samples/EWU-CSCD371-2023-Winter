namespace GenericsHomework;

public class CircularSinglyLinkedList<T>
{
    private Node? Head { get; set; }

    public class Node
    {
        public T Data
        {
            get => _Data!;
            set => _Data = value ?? throw new ArgumentNullException(nameof(Data));
        }
        private T? _Data;
        
        public Node Next
        {
            get => _Next!;
            private set => _Next = value ?? throw new ArgumentNullException(nameof(Next));
        }
        private Node? _Next;
        public Node(T data)
        {
            Data = data;
            Next = this;
        }
        public void Append(Node head, T data)
        {
            Node temp = head;
            while (temp.Next != head) 
            {
                temp = temp.Next;
            }
            Node newNode = new(data);
            temp.Next = newNode;
            newNode.Next = head;
        }
        public override string ToString()
        {
            return Data!.ToString()!;
        }
    }

    public void Append(T data)
    {
        if(Head is null)
            Head = new Node(data);
        else
            Head.Append(Head, data);
    }

    public T Get(int index)
    {
        if(Head is null)
            throw new ArgumentOutOfRangeException(nameof(index));
        Node currentNode = Head;
        for(int i = 0; i < index; i++)
        {
            currentNode = currentNode.Next;
            if(currentNode == Head)
                throw new ArgumentOutOfRangeException(nameof(index));
        }
        return currentNode.Data;
    }
}
