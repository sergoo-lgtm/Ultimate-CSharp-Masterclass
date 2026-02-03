using System;
using System.Collections.Generic; 
using System.IO;
using System.Globalization; 

namespace TicketsDataAggregator
{
    internal class FileWriter
    {
        
        public void WriteToFile(string outputFilePath, List<Ticket> tickets)
        {
            
            var culture = CultureInfo.InvariantCulture;

            
            using (StreamWriter writer = new StreamWriter(outputFilePath, false))
            {
                foreach (var ticket in tickets)
                {
                    
                    string dateStr = ticket.Date.ToString("d", culture);
                    string timeStr = ticket.Time.ToString("t", culture);

                   
                    string line = string.Format("{0, -40} | {1} | {2}",
                                                ticket.Title, dateStr, timeStr);

                   
                    writer.WriteLine(line);
                }
            }

            Console.WriteLine($"Result saved to {outputFilePath}");
        }
    }
}