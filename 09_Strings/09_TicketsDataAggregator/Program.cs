using System;

namespace TicketsDataAggregator
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("===========> Tickets Data Aggregator <===========");
            Console.WriteLine();
            Console.WriteLine("Please enter the full path to the tickets folder:");
            Console.Write("> "); 
           
            string rawInput = Console.ReadLine();

            Console.WriteLine();
            string ticketsFolder = rawInput.Replace("\"", "").Trim();

            try
            {
                
                if (!System.IO.Directory.Exists(ticketsFolder))
                {
                    Console.WriteLine("Error: The specified folder does not exist!");
                    return;
                }

                var aggregator = new TicketsAggregator(ticketsFolder);
                aggregator.Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred: " + ex.Message);
            }

            Console.WriteLine("Press any key to close.");
            Console.ReadKey();
        }
    }
}