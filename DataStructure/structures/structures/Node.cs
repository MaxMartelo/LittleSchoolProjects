namespace structures
{
    public class Node<T>
    {
        public Node<T> Next { get; set; } // for the next el 
        public Node<T> Prev { get; set; } // for the previous el + coutains the actual node 
        
        public T value; 
        
        public Node(T data)
        {
            this.value = data;
        }
    }
}