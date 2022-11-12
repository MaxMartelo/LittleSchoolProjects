using System;
using System.Collections;

namespace structures
{
    public class Stack<T>
    {
        private Node<T> _head; // value of the head of the stack
        private uint _size; // size of the stack
        
        // init our stack 
        public Stack()
        {
            this._head = null;
            this._size = 0;
        }

        public Stack(T[] data)
        {
            uint len = (uint)data.Length;
            foreach (var el in data)
            {
                this.Push(el); // = new head 
            }

            
        }

        public void Push(T data)
        {
            Node<T> node = new Node<T>(data);
            
            node.Prev = _head; // previous of the new node is the previous head
            node.Next = null; // the next of the new node is null
            this._head = node; // set the new node as the new head
            
            this._size++;
        }

        public T Pop()
        {
            if (_head.value == null)
                throw new ArgumentOutOfRangeException();
            
            T temp = _head.value; // store the actual value to pop
            this._head = _head.Prev; // set my new head as the previous node of our previous head
            this._head.Next = null; // set the next of my new head as null
            this._size--;
            return temp;
        }

        public T Peek()
        {
            if (_head.value == null)
                throw new ArgumentOutOfRangeException();
            
            return _head.value;
        }

        public int Count()
        {
            return (int)_size;
        }
    }
}