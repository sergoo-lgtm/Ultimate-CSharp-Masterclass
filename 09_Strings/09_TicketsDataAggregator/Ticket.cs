using System;
using System.Collections.Generic;
using System.Text;

namespace TicketsDataAggregator
{
    internal class Ticket
    {
        public string Title { get; set; }
        public DateOnly Date{ get; set; }
        public TimeOnly Time { get; set; }
    }
}
