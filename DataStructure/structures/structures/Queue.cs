using System;

namespace structures
{
    public class Queue<T>
    {
        private Node<T> _head;
        private Node<T> _tail;
        private uint _size;

        public Queue()
        {
            this._head = null; // last element entered in the queue (first in the queue)
            this._tail = null; // the one at the end of the queue 
            this._size = 0;
        }

        public Queue(T[] data)
        {

            foreach (var el in data)
            {
                this.Push(el); // = new head 
            }
            
        }
        
        public void Push(T data)
        {
            Node<T> node = new Node<T>(data);
            if (this._tail == null)
            {
                this._tail = this._head = node;
            }
            else
            {
                node.Next = _head; // link the previous head to our new node
                this._head.Prev = node; // link the node as our next head
                this._head = node; // set the new node as the head
            }
            this._size++;
        }
        
        public T Pop()
        {
            if (_tail.value == null)
                throw new ArgumentOutOfRangeException();
            
            T temp = _tail.value; // store the actual value to pop

            if (this._size == 1)
            {
                this._head = this._tail = null;
            }
            else
            {
                this._tail = _tail.Prev; // set my new tail as the previous node of our previous tail
                this._tail.Next = null; // set the next of my new tail as null
            }
            this._size--;
            return temp;
        }
        
        public T Peek()
        {
            if (_tail.value == null)
                throw new ArgumentOutOfRangeException();
            
            return _tail.value;
        }

        public int Count()
        {
            return (int)_size;
        }
    }
}