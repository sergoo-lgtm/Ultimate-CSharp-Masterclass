using System.Collections;

namespace ConsoleApp1;

public class CustomLinkedList<T>:ILinkedList<T>
{ 
    public int Count { get; set; } 
    public bool IsReadOnly { get; }
    public CustomLinkedList()
    {
        Head = null; 
        Count = 0;
    }
    public Node<T>? Head { get; set; } 
    
    public void Add(T item)
    {
        AddToEnd(item);
    }

    public void Clear()  
    {
        Head = null;

        Count = 0;
    }

    public bool Contains(T item)      
    {
        if (Count == 0)
        {
            return false;   
        }

        if (Equals(Head.Value, item))
        {
            return true;
        }
        var current = Head;
        while (current.Next != null)
        {
                if (Equals(current.Next.Value, item))
                {
                    return true;
                    
                }
                current = current.Next;
        }
        return false;
    }

    public void CopyTo(T[] array, int arrayIndex)       
    {
        var current = Head;

        while (current != null)
        {
            array[arrayIndex] = current.Value;

            arrayIndex++;

            current = current.Next;
        }
    }

    public bool Remove(T item)
    {
        if (Count == 0)
        {
            return false;
            
        }
        if (Equals(Head.Value, item))
        {
            Head = Head.Next;
            Count--;
            return true;
        }
        var current = Head;
        while (current.Next != null)
        {
            if (Equals(current.Next.Value, item))
            {
                    current.Next = current.Next.Next;
                    Count--;
                    return true;
            }
            current = current.Next;
        }
        return false;    
    }

   
    public IEnumerator<T> GetEnumerator()      
    {
        var current = Head;
        while (current != null)
        {
            yield return current.Value;
        
            current = current.Next;
        }
        
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    
    public void AddToFront(T item)
    {
       var newnode = new Node<T>(item);
       
       newnode.Next = Head;
       Head = newnode;
       Count++;
       
    }
    

    public void AddToEnd(T item)
    {
        var lastnode = new Node<T>(item);
        if (Head == null)
        {
            lastnode.Next = Head;
            Head = lastnode;
        }
        else
        {
            var current = Head;
            while (current.Next != null)
            {
                current = current.Next;
                
            }
            current.Next = lastnode;
        }
        Count++;
    }
}