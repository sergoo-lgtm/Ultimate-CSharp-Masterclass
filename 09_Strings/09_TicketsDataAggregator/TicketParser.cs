using System;
using System.Collections.Generic;
using System.Globalization;

namespace TicketsDataAggregator
{
    internal class TicketParser
    {
        public List<Ticket> Parse(string rawText)
        {
            var ticketsList = new List<Ticket>();

            string[] ticketsBlocks = rawText.Split(new[] { "Title:" }, StringSplitOptions.None);

            CultureInfo culture = GetCulture(rawText);

            foreach (string block in ticketsBlocks)
            {
                if (string.IsNullOrWhiteSpace(block)) continue;

                if (!block.Contains("Date:") || !block.Contains("Time:"))
                {
                    continue;
                }

                try
                {
                    var titleSplit = block.Split(new[] { "Date:" }, StringSplitOptions.None);
                    string title = titleSplit[0].Trim();

                    var dateSplit = titleSplit[1].Split(new[] { "Time:" }, StringSplitOptions.None);
                    if (dateSplit.Length < 1) continue;

                    string dateString = dateSplit[0].Trim();

                    var timeSplit = dateSplit[1].Split(new[] { '\n', '\r' }, StringSplitOptions.None);
                    string timeString = timeSplit[0].Trim();

                    DateOnly dateObj = DateOnly.Parse(dateString, culture);
                    TimeOnly timeObj = TimeOnly.Parse(timeString, culture);

                    ticketsList.Add(new Ticket
                    {
                        Title = title,
                        Date = dateObj,
                        Time = timeObj
                    });

                    Console.WriteLine($"Parsed: {title}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Skipping a ticket due to error: {ex.Message}");
                }
            }

            return ticketsList;
        }

        private CultureInfo GetCulture(string text)
        {
            if (text.Contains(".jp")) return new CultureInfo("ja-JP");
            if (text.Contains(".fr")) return new CultureInfo("fr-FR");
            return new CultureInfo("en-US");
        }
    }
}