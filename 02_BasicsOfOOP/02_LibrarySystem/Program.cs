using LibrarySystem;

Console.WriteLine("welcome to the library system \n are you librarian or regular user\n(L or R)");
Library library = new Library();
char usertype = Console.ReadLine().ToUpper()[0];

    if (usertype == 'L')
    {
        Console.WriteLine("enter your name");
        string librrarianName = Console.ReadLine();
        Librarian l1 = new Librarian(librrarianName);
        Console.WriteLine("welcome " + l1.Name);
    while (true)
    {
        Console.WriteLine("please choose to Add book (A) or remove (R) or display (D)");


        char choise = Console.ReadLine().ToUpper()[0];

        switch (choise)
        {
            case 'A':
                Console.WriteLine("enter book details [bookname,authername,year]");
                string bookname = Console.ReadLine();
                string authername = Console.ReadLine();
                int year = int.Parse(Console.ReadLine());
                Book book = new Book(bookname, authername, year);
                l1.addbook(book, library);
                break;
            case 'R':
                Console.WriteLine("enter book details [bookname,authername,year]");
                bookname = Console.ReadLine();
                authername = Console.ReadLine();
                year = int.Parse(Console.ReadLine());
                book = new Book(bookname, authername, year);
                l1.removebook(book, library);
                break;
            case 'D':
                Console.WriteLine("the book list : ");
                l1.displaybooks(library);
                break;
            default:
                Environment.Exit(0);
                break;

        }


    }

    }
    else if (usertype == 'R')
    {
    Console.WriteLine("enter your name");
    string regularuserName = Console.ReadLine();
    LibraryUser r1 = new LibraryUser(regularuserName);
    Console.WriteLine("welcome " + r1.Name);


    while (true)
    {
        Console.WriteLine("please choose to borrow (B) or display (D)");


        char choise = Console.ReadLine().ToUpper()[0];

        switch (choise)
        {
            case 'B':
                Console.WriteLine("enter book details [bookname]");
                string bookname = Console.ReadLine();
                var book =  new Book(bookname);
                r1.borrowbook(book, library);
                break;
            case 'D':
                Console.WriteLine("the book list : ");
                r1.displaybooks(library);
                break;
            default:
                Environment.Exit(0);
                break;
        }



        }
    }
    else
    { Console.WriteLine("wrong input"); }
