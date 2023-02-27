using System;
using System.Collections;
using System.Collections.Generic;

namespace Assignment
{
    public class Node<TVal> : IEnumerable<Node<TVal>> where TVal : notnull
    {
        public Node(TVal val)
        {
            Val = val ?? throw new ArgumentNullException($"Node<{typeof(TVal)}> value cannot be null");
            Next = this;
        }

        public TVal Val
        {
            get;
            set;
        }

        public Node<TVal> Next
        {
            get;
            private set;
        }

        public void Append(TVal node)
        {
            if (Exists(node))
            {
                throw new ArgumentException("Value already exists. Value must be unique.");
            }

            Node<TVal> node1 = new(node);

            if (Next == this)
            {
                Next = node1;
                node1.Next = this;
            }
            else
            {
                node1.Next = Next;
                Next = node1;
            }
        }

        /*
        * Need only to get rid of the link from the first
        * node because only the first node can access the subsequent nodes,
        * thus leaving no more references to the objects created.
        * This is proven in GenericsHomeworkTests.Node_GarbageCollection()
        */

        public void Clear()
        {
            Next = this;
        }

        public Boolean Exists(TVal val)
        {
            Node<TVal> temp = this;
            while (!temp.Val.Equals(val))
            {
                if (temp.Next == this)
                {
                    return false;
                }

                temp = temp.Next;
            }

            return true;
        }

        public IEnumerable<Node<TVal>> GetEnumerator()
        {
            Node<TVal> cur = this.Next;
            do
            {
                yield return cur;
                cur = cur.Next;
            }
            while (cur != this);
        }

        public override string ToString()
        {
            return $"{Val}";
        }

        IEnumerator<Node<TVal>> IEnumerable<Node<TVal>>.GetEnumerator()
        {
            return (IEnumerator<Node<TVal>>)GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            yield return GetEnumerator();
        }

        public IEnumerable<Node<TVal>> ChildItems(int max)
        {
            Node<TVal> cur = this;
            int count = 0;
            while(count < max)
            {
                yield return cur;
                cur.GetEnumerator().GetEnumerator().MoveNext();
                count++;
            }
        }

    }
}
