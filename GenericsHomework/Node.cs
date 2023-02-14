namespace GenericsHomework
{
    public class Node<T>
    {
        public T Value;
        public Node<T> Next { get; private set; } 

        public Node(T value) 
        {
            Value = value;
            Next = this;
        }

        public void Append(T value)
        {
            if(value is not null) 
            {
                Node<T> cur = this;
                do
                {
                    if (value.Equals(cur.Value))
                    {
                        throw new Exception("value already exists");
                    }
                    cur = cur.Next;
                }
                while (cur != this);

                Node<T> next = new(value);
                next.Next = this;
                Next = next;     
            }            
        }

        public void Clear() 
        {
            Next = this;
        }

        public bool Exists(T value)
        {
            if(value is null) return false;
            Node<T> cur = this;
            do
            {
                if (value.Equals(cur.Value))
                {
                    return true;
                }
                cur = cur.Next;
            }
            while (cur != this);
            return false;
        }

        public override string? ToString()
        {
            if(Value is null) return null;
            return Value.ToString();  
        }
    }
}