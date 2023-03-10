using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Assignment;

public class Node<T> : IEnumerable<T>
{
    public T Value { get; set; }
    public Node<T> Next { get; private set; }

    public Node(T value, Node<T> next)
    {
        Value = value;
        Next = next ?? this;
    }

    public override string ToString()
    {
        return Value!.ToString() ?? "value is null";
    }

    public void Append(T newValue)
    {
        Next = !Next.Exists(newValue) ? new Node<T>(newValue, Next) : throw new ArgumentException("value already exists in linked list");
    }


    /*
     * WHY THIS CLEAR FUNCTION WORKS
     * 
     * It is sufficient to set next to itself becuase it will cut all off all the connected links
     * 
     * The removed items should not be set to circle back on themselves because it is a waste of a process.
     * Once the list of nodes are not referenced they will be collected by the garbage collector
     * 
     * I believe you would need to worry if you connected the linked list after removing your reference to that list
     * because every node would be referenced by another node, which I belive would create a memory leak because the 
     * garabge collector would not remove the abandoned nodes since they are all being referenced by eachother.
     */
    public void Clear()
    {
        Next = this;
    }

    public bool Exists(T value)
    {
        bool result = false;
        Node<T> curr = Next;
        do
        {
            if (curr.Value is not null && curr.Value.Equals(value))
            {
                result = true;
                break;
            }
            curr = curr.Next;
        } while (!curr.Equals(this));


        return result;
    }
    public IEnumerator<T> GetEnumerator()
    {
        Node<T> curr = this;
        do
        {
            yield return curr.Value;
            curr = curr.Next;
        }
        while (!curr.Equals(this));

        
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
     //7.


    public IEnumerable<T> ChildItems(int maximum)
    {
        Node<T> curr = this;
        
        do
        {
            yield return curr.Value;
            curr = curr.Next;
            maximum--;
        }
        while (!curr.Equals(this) && maximum > 0);
    }
}
