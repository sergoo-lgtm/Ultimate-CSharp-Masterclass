
namespace LibrarySystem
{
    internal class LibraryUser : User
    {
       


        public LibraryUser(string name)
        { Name = name; }
        public void borrowbook(Book book , Library library)
        {
            library.borrow(book);
        }

    }
}
