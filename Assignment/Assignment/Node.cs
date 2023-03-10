using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    // ICollection extends IEnumerable, so therefore this implements IEnumerable
    public class Node<TNodeType> : ICollection<TNodeType>
    {
        private Node<TNodeType>? _Next { get; set; }

        private TNodeType? _Value;

        public TNodeType? Value
        {
            get
            {
                return _Value;
            }
            private set
            {
                _Value = value;
            }
        }
        public Node<TNodeType> Next
        {
            get
            {
                return _Next!;
            }
            private set
            {
                ArgumentNullException.ThrowIfNull(value);
                _Next = value;
            }
        }
        public int Count
        {
            get
            {
                int count = 0;
                foreach (TNodeType element in this)
                {
                    count++;
                }
                return count;
            }
        }
        bool ICollection<TNodeType>.IsReadOnly { get; } = false;
        public Node(TNodeType value)
        {
            Value = value;
            Next = this;
        }

        private Node(TNodeType value, Node<TNodeType> next)
        {
            Value = value;
            Next = next;
        }

        public void Append(TNodeType data)
        {
            if (Exists(data))
            {
                throw new ArgumentException($"{data} is already added in list");
            }
            Node<TNodeType> newNode = new(data, Next);
            Console.WriteLine(newNode.Value);
            Next = newNode;
        }

        public bool Exists(TNodeType data)
        {
            Node<TNodeType> head = this;
            Node<TNodeType> curr = head;
            do
            {
                if (EqualityComparer<TNodeType>.Default.Equals(data, curr.Value))
                {
                    return true;
                }
                curr = curr.Next;

            } while (curr != head);
            return false;
        }

        public TNodeType[] ToArray()
        {
            TNodeType[] array = new TNodeType[Count];
            int i = 0;
            foreach (TNodeType element in this)
            {
                array[i] = element;
                i++;
            }
            return array;
        }

        public override string ToString()
        {
            return Value?.ToString() ?? "null";
        }

        public void Clear()
        {
            // It is sufficient to set the current node's next to itself, this will allow the garbage collector to clean the whole linked list. 
            // We don't need to go through each individual and close the loop on it, setting it to itself
            // This is becaues the garbage collector will recognize that the first
            // Item in the list has no reference pointing to it, and will clean it, then look at the next one. This will occur recursively 
            // We tested to see if the Garbage Collector arrives sooner if each reference points to itself; however, the destructor
            // showed no signs of enhancement
            // We don't need the removed items to circle back on themselves because if they have a reference to themselves they may not be collected
            // Thus they cannot be in a a circle, because if there is a circular list of items, you will have to worry about garbage collection at least until the program closes

            Next = this;
        }

        public void Add(TNodeType item)
        {
            Append(item);
        }
        bool ICollection<TNodeType>.Contains(TNodeType item)
        {
            return Exists(item);
        }

        public void CopyTo(TNodeType[] array, int arrayIndex)
        {
            if (array is null)
            {
                throw new ArgumentNullException(nameof(array));
            }
            if (arrayIndex > array.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(arrayIndex));
            }
            Node<TNodeType> head = this;
            Node<TNodeType> curr = this;

            int index = arrayIndex;
            do
            {
                if (array.Length > index)
                {
                    array[index] = curr.Value!;
                }
                else
                {
                    array.Append(curr.Value);
                }
                curr = curr.Next;
                index++;
            } while (curr != head);
        }

        public bool Remove(TNodeType item)
        {

            Node<TNodeType> curr = this;
            Node<TNodeType> prev = this;
            Node<TNodeType> head = this;

            do
            {
                if (EqualityComparer<TNodeType>.Default.Equals(item, curr.Value))
                {
                    // Cannot remove the head object 
                    if (curr == head)
                    {
                        return false;
                    }

                    // Without a reference to curr, the garbage collector will remove it 
                    prev.Next = curr.Next;
                    return true;
                }
                prev = curr;
                curr = curr.Next;

            } while (curr != head);
            return false;
        }

        IEnumerator<TNodeType> IEnumerable<TNodeType>.GetEnumerator()
        {
            Node<TNodeType> curr = this;
            do
            {
                yield return curr.Value!;
                curr = curr.Next;
            } while (curr != this);
        }

        public IEnumerator GetEnumerator()
        {
            Node<TNodeType> curr = this;
            do
            {
                yield return curr.Value!;
                curr = curr.Next;
            } while (curr != this);

        }

        public IEnumerable<TNodeType> ChildItems(int maximum) {
  
                Node<TNodeType> curr = this;

                for (int i = 0; i < maximum && i < Count; i++) {
                    yield return curr.Value!; 
                    curr = curr.Next;   
                }
            }
        
        }
    }

