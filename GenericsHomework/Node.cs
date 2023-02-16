namespace GenericsHomework
{
    public class Node<T>
    {
        public T? Data { get; set; }
        private int Size { get; set; }
        public Node<T> Next { get; set; }

        public Node(T? data)
        {

            this.Data = data;
            this.Next = this;
        }
        public override string ToString()
        {
            return Data?.ToString() ?? "null";
        }
        public void Append(T data)
        {
            if (data == null) return;
            if(existing(data) == true)
            {
                throw new ArgumentException();
            }
            Node<T> cur = this;
            while (cur.Next != this)
            {
                cur = cur.Next;
            }
            Node<T> newNode = new Node<T>(data);
            newNode.Next = this;
            cur.Next = newNode;
            this.Size++;
        }
        public void Clear()
        {
            Next = this;
            this.Size = 0;
            /*
            * The garbage collector in .NET automatically reclaims the memory
            * occupied by unused nodes in a circular linked list. In class the
            * professor talked about the automatic garbage collector .NET
            * uses so that is where our answer is coming from.
            */
        }
        public bool existing(T data)
        {
            if (data is null)
            {
                throw new ArgumentNullException(nameof(data));
            }
            Node<T> cur = Next;
            Node<T> head = this;
            while (cur != null && cur != this)
            {
                if (cur.Data.Equals(data)) { return true; }
                cur = cur.Next;
            }
            return false;
        }
    }
}