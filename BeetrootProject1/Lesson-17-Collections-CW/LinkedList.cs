using System;
using System.Collections;
using System.Collections.Generic;

namespace Lesson17.Collections
{
   public interface IIterable<T>
    {
        IIterator<T> GetIterator();
    }
    //create interface
    public interface IIterator<T>
    {
        bool HasNext();
        T Current { get; }
        void Reset();
    }
    //create interface realiation
    class Iterator<T> : IEnumerator<T>
    {
        //in this method are the same as im this methods
        //   for (int i= 0; i<list.Count; i++)
        //{
        //    Console.WriteLine($" {list.GetByIndex(i)}");
        //}

        private readonly LinkedList<T> _list;
        private int _index;

        public Iterator(LinkedList<T> list)
        {
            this._list = list;
        }
        
        //($" {list.GetByIndex(i)}");
        public T Current { get; private set; }

        object IEnumerator.Current => throw new NotImplementedException();

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        //i<list.Count
        public bool MoveNext()
        {
            if(this._index < this._list.Count)
            {
                Current = this._list.GetByIndex(this._index++);
                return true;
            }
            return false;
        }

        //same as pointer / reset -> int i= 0
        public void Reset()
        {
            this._index = 0;
        }
    }

    public class LinkedList<T> : ICollection<T>
    {
        //save Head, Tail, amount of elements of linked list
        private Node<T> _head;
        private Node<T> _tail;
        //according to Incapsulation save Count as privare field
        private int _count;

        //класс, который saves ссылку на след элемент и сохраняет собственное значение
        private class Node<T>
        {
            //constructor
            public Node(T value, Node<T> next)
            {
                Value = value;
                Next = next;
            }
            // save собственное значение
            public T Value { get; }

            //save ссылку на след элемент
            public Node<T> Next { get; set; }
        }
        public void Add(T item)
        {
            //check if there is a Head
            if (this._head == null)
            {
                //if not - save new
                //pass value - item and link to next element - null
                this._head = new Node<T>(item, null);
                //head is the tail now 
                this._tail = this._head;
            }

            else
            {
                //in case head is present
                //create current element we want to save
                //in parameters: next element = null because we don't know it
                var newNode = new Node<T>(item, null);

                //we are linking new node to Tail
                this._tail.Next = newNode;

                //save new tail
                this._tail = newNode;
            }
            //increase Count 
            this._count++;
        }

        //Count returns from Private variable (Back in field)
        public int Count => this._count;


        //return full List
        public IEnumerable<T> GetAll()
        {
            //save Head elemment 
            var item = this._head;

            //returns current item 
            //while there are next elements
            while (item != null) 
            {
                yield return item.Value;
                item = item.Next;
            }             
        }


        //check if in collection is certain element
        public bool Contains(T item)
        {
            var pointer = this._head;
            while (pointer != null)
            {
                if (pointer.Value.Equals(item))
                {
                    return true;
                }
                pointer = pointer.Next;
            }
            return false;
        }

        //find element by index
        //returns T 
        public T GetByIndex(int index)
        {
            //validation
            if (index < 0 || index >= this._count)
            {
                throw new IndexOutOfRangeException();
            }

            //point to head (1st element)
            var pointer = this._head;
            //if we search 0 element - we will skip loop because i > or = index
            for (int i = 0; i < index; i++)
            {
                //add index times to pointer next item
                pointer = pointer.Next;
            }
            //returns 0 element
            return pointer.Value;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
            => throw new NotImplementedException();
        public bool IsReadOnly { get; } = false;

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
            => new Iterator<T>(this);

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();
    }
}