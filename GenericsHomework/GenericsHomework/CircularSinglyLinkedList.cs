using System.Xml.Linq;

namespace GenericsHomework
{
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
                get => _Next;
                private set => _Next = value ?? throw new ArgumentNullException(nameof(Next));
            }
            private Node _Next;
            public Node(T data)
            {
                Data = data;
                Next = this;
            }
            public void Append(Node Head, T Data)
            {
                Node temp = Head;
                while (temp.Next != Head) 
                {
                    temp = temp.Next;
                }
                Node NewNode = new(Data);
                temp.Next = NewNode;
                NewNode.Next = Head;
            }
            public override string ToString()
            {
                return Data!.ToString()!;
            }
        }

    }
    
}