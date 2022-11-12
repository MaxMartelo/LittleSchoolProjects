using System;

namespace structures
{
    public class List<T>
    {
        private Node<T> _head;
        private Node<T> _tail;
        private uint _size;

        public List()
        {
            this._head = null; // last element entered in the list (first in the list)
            this._tail = null; // the one at the end of the list 
            this._size = 0;
        }

        public List(T[] data)
        {
            foreach (var el in data)
            {
                AddLast(el);
            }
        }
        
        public void AddFirst(T data)
        {
            Node<T> node = new Node<T>(data);
            if (this._tail == null)
            {
                this._tail = this._head = node;
            }
            else
            {
                // as we add at the beginning of the list, the head changes but not the tail
                node.Next = _head; 
                this._head.Prev = node;
                this._head = node;
            }
            this._size++;
        }

        public void AddLast(T data)
        {
            Node<T> node = new Node<T>(data);
            if (this._tail == null)
            {
                this._tail = node;
                this._head = node;
            }

            else
            {
                // as we add at the end of the list, the tail changes but not the head
                node.Prev = _tail;
                this._tail.Next = node;
                this._tail = node;

            }
            this._size++;
        }
        
        public void Add(int index, T data)
        {
            int len = (int)_size;
            if (index > _size)
                throw new ArgumentException("index out of range");
            
            if(this._tail == null && index != 0)
                throw new ArgumentOutOfRangeException();
            
            else if (index == 0)
                AddFirst(data);
            
            else if (index == len)
                AddLast(data);
            
            else
            {
                Node<T> node = new Node<T>(data);
                int i = 0;
                Node<T> temp = _head.Next;
                Node<T> temp2 = _head;
                while (i < index - 1)
                {
                    temp = temp.Next;
                    temp2 = temp2.Next;
                    i++;
                }
                
                
                node.Prev = temp.Prev;
                node.Next = temp;
                temp.Prev = node; // to link my node as previous of 1
                
                temp2.Next = node; // to link my node as Next of 0 
                
                this._size++;
                
            }
           
            
        }

        public void RemoveFirst()
        {
            if (_head.value == null)
                           throw new ArgumentOutOfRangeException();
            
            this._head = _head.Next; // set my new head as the next node of our previous head
            this._head.Prev = null; // set the Prev of my head null
            this._size--;
            
        }

        public void RemoveLast()
        {
            if (_tail.value == null)
                throw new ArgumentOutOfRangeException();
            
            this._tail = _tail.Prev; // set my new tail as the previous node of our previous tail
            this._tail.Next = null; // set the next of my new tail as null
            this._size--;
        }

        public void Remove(int index)
        {
            int len = (int)_size;
            if (index > _size)
                throw new ArgumentException("index out of range");
            
            if(this._tail == null && this._head == null)
                throw new ArgumentOutOfRangeException("Can not remove an el in an empty List");
            
            else if (index == 0)
                RemoveFirst();
            
            else if (index == len - 1)
                RemoveLast();
            
            else
            {
                int i = 0;
                Node<T> temp = _head;
                Node<T> node = temp;
                while (i < index)
                {
                    temp = temp.Next;
                    
                    i++;
                }

                node = temp.Prev;
                node.Next = temp.Next;
                temp.Next.Prev = node; 

                this._size--;
                
            }
        }

        public T Get(int index)
        {
            int len = (int)_size;
            if (index >= len)
                throw new NotImplementedException("Index out of range");
            int i = 0;
            Node<T> Hbis = _head;
            while (i < index)
            {
                _head = _head.Next;
                i++;
            }

            T res = _head.value;
            _head = Hbis; 

            return res;
        }
        
        public int Count()
        {
            return (int)_size;
            
        }
    }
}