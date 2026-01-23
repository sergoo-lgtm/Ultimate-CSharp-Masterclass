
namespace LibrarySystem
{
    internal abstract class User
    {
        public string Name { get; set; }
        

        public void displaybooks(Library library)
        {
            library.display();

        }
    }
}
