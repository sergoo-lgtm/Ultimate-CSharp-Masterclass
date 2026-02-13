using System.Collections.Generic; 
namespace ConsoleApp1;

public interface ILinkedList<T> : ICollection<T>
{
        void AddToFront(T item); 
        void AddToEnd(T item);   
}