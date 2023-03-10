using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace GenericsHomework
{
    public class Node<T> : IEnumerable<T>
    {
        public T Value { get; set; }
        private Node<T> Next { get; set; }

        public Node(dynamic value) { 
            Value = value;
            Next = this;
        }


        public void Append(dynamic value)
        {
            if (!this.Exists(value))
            {
                Node<T> Cursor = this;
                while (Cursor.Next != this) Cursor = Cursor.Next;
                Cursor.Next = new Node<T>(value);
                Cursor.Next.Next = this;
            }
            else throw new Exception("Value already exists in list");
        }

        public void Clear()
        {
            /* Node temp_1 = this;
             Node temp_2 = this.Next;
             while(temp_1 != temp_2)
             {
                 temp_1.Next = temp_1;
                 temp_1 = temp_2;
                 temp_2 = temp_2.Next;
             }*/
            Next = this;
        }
        //we do not need to worry if it a circular list because the built in
        //.Net garbage collector should be able to deal with it themselves

        public bool Exists(dynamic value)
        {
            Node<T> cursor = this;
            do
            {
                if(cursor.Value == value) return true;
                cursor = cursor.Next;
            } while (cursor != this);
            return false;
        }

        public int CountNodes()
        {
            int count = 1;
            Node<T> cursor = this.Next;
            while (cursor != this)
            {
                count++;
                cursor = cursor.Next;
            }
            return count;
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Node<T> cursor = this;
            yield return cursor.Value;
            cursor = cursor.Next;
            while (cursor != this)
            {
                yield return cursor.Value;
                cursor = cursor.Next;
            }
        }

        public IEnumerable<T> ChildItems(int maximum)
        {
            int count = maximum;
            Node<T> cursor = this;
            yield return cursor.Value;
            cursor = cursor.Next;
            while (cursor != this)
            {
                if (count > 1)
                {
                    yield return cursor.Value;
                }
                cursor = cursor.Next;
                count--;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
