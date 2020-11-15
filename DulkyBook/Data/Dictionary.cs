using System;
using System.Collections.Generic;

namespace DulkyBook.Data
{
    public partial class Dictionary
    {
        public long Id { get; set; }
        public string English { get; set; }
        public string Serbian { get; set; }
        public int Round { get; set; }
        public string Flag { get; set; }
    }
}
