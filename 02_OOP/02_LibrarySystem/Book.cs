
namespace LibrarySystem
{
    internal class Book
    {
        public string Title { get; set; }
        public string Auther { get; set; } 
        public int year { get; set; }
        public Book(string title, string auther, int year)
        {
            Title = title;
            Auther = auther;
            this.year = year;
        }
        public Book(string title)
        {
            Title = title;
   
        }
    }
}
