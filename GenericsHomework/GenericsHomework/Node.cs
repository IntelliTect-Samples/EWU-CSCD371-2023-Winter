using System.Runtime.CompilerServices;

namespace GenericsHomework
{
    public class Node<T>
    {
        public T Value { get; }

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

        public Node<T> Append(T value)
        {
            if (value != null)
            {
                Next.Append(value);
            }
            return this;
        }

        public void Clear()
        {
            if (Next == this)
            {
                return;
            }
            var next = Next;
            Next = this;
            next.Clear();
        }

        public bool Exists(T value)
        {
            var currentNode = this;
            while (currentNode != null && value != null)
            {
                if (currentNode.Equals(value))
                {
                    return true;
                }
                else if (currentNode.Next != null)
                {
                    currentNode = currentNode.Next;
                }
            }
            return false;
        }

    }
}

