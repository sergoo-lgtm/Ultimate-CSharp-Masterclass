using System;
using System.Collections.Generic;
using System.IO; 

namespace TicketsDataAggregator
{
    internal class TicketsAggregator
    {
        private readonly string _folderPath;
        private readonly PdfReader _pdfReader;
        private readonly TicketParser _parser;
        private readonly FileWriter _writer;

        public TicketsAggregator(string folderPath)
        {
            _folderPath = folderPath;
            _pdfReader = new PdfReader();
            _parser = new TicketParser();
            _writer = new FileWriter();
        }

        public void Run()
        {
           
            var allTickets = new List<Ticket>();

            string[] pdfFiles = Directory.GetFiles(_folderPath, "*.pdf");

            Console.WriteLine($"Found {pdfFiles.Length} PDF files inside {_folderPath}");

           
            foreach (string file in pdfFiles)
            {
                try
                {
                    Console.WriteLine($"Processing file: {Path.GetFileName(file)}...");

                   
                    string rawText = _pdfReader.ReadPdf(file);

              
                    List<Ticket> fileTickets = _parser.Parse(rawText);

                    
                    allTickets.AddRange(fileTickets);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error processing file {file}: {ex.Message}");
                }
            }

            string outputFilePath = Path.Combine(_folderPath, "aggregatedTickets.txt");

            _writer.WriteToFile(outputFilePath, allTickets);
        }
    }
}