

namespace LibrarySystem
{
    internal class Library
    {
        private Book[] Books = new Book[100];
        public Book[] BorrowedBooks = new Book[50];
        private int currentbook = 0;
        private int currentborrowdbook = 0;


        public void add(Book Book)
        {
            if (currentbook < Books.Length)
            {
                Books[currentbook] = Book;
                Console.WriteLine("book added successfully");
                currentbook++;
            }
            else 
            {
                Console.WriteLine("library is full");
            }
        }
        public void remove(Book Book)
        {
            int index = Array.IndexOf(Books, Book);
            Books[index] = null;
            Console.WriteLine("book is removed");
            currentbook--;
        }

        public void display ()
        {
            for (int i =0; i< currentbook; i++)
            { Console.WriteLine(Books[i].Title); }
        }
        
        public void borrow(Book Book)
        {
            if (currentborrowdbook < BorrowedBooks.Length)
            {
                BorrowedBooks[currentborrowdbook] = Book;
                Console.WriteLine("book borred successfully");
                currentborrowdbook++;
            }
            else
            {
                Console.WriteLine("sorry cant not borrow");
            }
        }
    }
}
