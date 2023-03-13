using System.Collections;

namespace ClassLibrary
{
    public class Node<T> : IEnumerable<T>
    {
        public T Content { get; set; }
        public Node<T> NextNode { get; private set; }
        public Node<T>? PrevNode { get; set; }

        public Node(T content)
        {
            Content = content;
            NextNode = this;
        }

        public override string? ToString()
        {
            if (Content != null)
            {
                return Content.ToString()!;
            }
            else
            {
                return null;
            }
        }

        public void Append(T content)
        {

            Node<T> newNode = new Node<T>(content);
            Node<T> current = this;

            if (NextNode.Equals(this))
            {
                NextNode = newNode;
                newNode.PrevNode = this;
                return;
            }
            else
            {
                while (current.NextNode != current)
                {
                    current = current.NextNode;
                }
                current.NextNode = newNode;
                newNode.PrevNode = current;
                this.PrevNode = newNode;
                return;
            }
        }

        public void Clear()
        {
            NextNode = this;
            PrevNode = null;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> currNode = this;
            do
            {
                yield return currNode.Content;
                currNode = currNode.NextNode;
            } while (!currNode.Equals(this));
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerable<T> ChildItems(int maximum)
        {
            int count = 0;
            Node<T> current = this.NextNode;

            while (current != this && count < maximum)
            {
                yield return current.Content;
                current = current.NextNode;
                count++;
            }
        }
    }
}
