using System;
using ConsoleApp1; // Ensure this matches your Namespace

class Program
{
    static void Main(string[] args)
    {
        // Set the console text color for the welcome message
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("==================================================");
        Console.WriteLine("   🚀 Welcome to Dr. Youssef's Linked List Demo   ");
        Console.WriteLine("==================================================");
        Console.ResetColor();

        // 1. Creating the List
        // We chose 'string' type to simulate a music Playlist
        CustomLinkedList<string> myPlaylist = new CustomLinkedList<string>();
        Console.WriteLine("\n[1] List Created. Initial Count: " + myPlaylist.Count);

        // ---------------------------------------------------------
        
        // 2. Testing Adding Methods (Add, AddToFront, AddToEnd)
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\n--- Testing Add Methods ---");
        Console.ResetColor();

        myPlaylist.Add("Shape of You");          // Add (Adds to the end by default)
        Console.WriteLine("Added 'Shape of You' (Add)");

        myPlaylist.AddToFront("Intro Song");     // AddToFront (Adds to the beginning)
        Console.WriteLine("Added 'Intro Song' (AddToFront)");

        myPlaylist.AddToEnd("Believer");         // AddToEnd (Adds to the end)
        Console.WriteLine("Added 'Believer' (AddToEnd)");

        myPlaylist.AddToFront("Podcast Ep.1");   // AddToFront again
        Console.WriteLine("Added 'Podcast Ep.1' (AddToFront)");

        // Print the current state of the list
        PrintListState(myPlaylist);

        // ---------------------------------------------------------

        // 3. Testing Search (Contains)
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\n--- Testing Contains ---");
        Console.ResetColor();

        string searchItem1 = "Believer";
        string searchItem2 = "Despacito";

        // Check if items exist
        Console.WriteLine($"Is '{searchItem1}' in the list? " + myPlaylist.Contains(searchItem1)); // Expected: True
        Console.WriteLine($"Is '{searchItem2}' in the list? " + myPlaylist.Contains(searchItem2)); // Expected: False

        // ---------------------------------------------------------

        // 4. Testing Removal (Remove)
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\n--- Testing Remove ---");
        Console.ResetColor();

        // Remove an item from the middle
        Console.WriteLine("Removing 'Shape of You'...");
        bool isRemoved = myPlaylist.Remove("Shape of You");
        Console.WriteLine($"Remove Success: {isRemoved}");
        PrintListState(myPlaylist);

        // Try to remove a non-existent item
        Console.WriteLine("Removing 'Unknown Song'...");
        isRemoved = myPlaylist.Remove("Unknown Song");
        Console.WriteLine($"Remove Success: {isRemoved}"); // Expected: False

        // Remove the Head (First item)
        Console.WriteLine("Removing 'Podcast Ep.1' (The Head)...");
        myPlaylist.Remove("Podcast Ep.1");
        PrintListState(myPlaylist);

        // ---------------------------------------------------------

        // 5. Testing CopyTo (Copy to Array)
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\n--- Testing CopyTo (Array) ---");
        Console.ResetColor();

        string[] songArray = new string[5]; // Create an empty array
        myPlaylist.CopyTo(songArray, 0);    // Copy the linked list items into the array

        Console.WriteLine("Items inside the Array:");
        for (int i = 0; i < songArray.Length; i++)
        {
            if (songArray[i] != null)
                Console.WriteLine($"Index [{i}]: {songArray[i]}");
        }

        // ---------------------------------------------------------

        // 6. Testing Clear (Delete All)
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\n--- Testing Clear ---");
        Console.ResetColor();

        myPlaylist.Clear(); // Empty the list
        Console.WriteLine("List Cleared!");
        PrintListState(myPlaylist);
        
        Console.WriteLine("\n==================================================");
        Console.WriteLine("           Test Completed Successfully!           ");
        Console.WriteLine("==================================================");
    }

    // ---------------------------------------------------------
    // Helper Method
    // Used to print the list items and count nicely to avoid code repetition
    static void PrintListState(CustomLinkedList<string> list)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("Current List: ");
        
        // This uses the GetEnumerator method you implemented!
        foreach (var item in list)
        {
            Console.Write($"[{item}] -> ");
        }
        Console.WriteLine("null");
        Console.WriteLine($"Count: {list.Count}");
        Console.ResetColor();
        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}