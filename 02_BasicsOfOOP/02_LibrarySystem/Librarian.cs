
namespace LibrarySystem
{
    internal class Librarian : User
    {
        public int employeeID {  get; set; }
        public Librarian(string name)
        {
            Name = name;
        }

        public void addbook(Book newBook, Library library)
        {
            library.add(newBook);
        }
        public void removebook(Book newBook, Library library)
        {
            library.remove(newBook);
        }
    }
}
