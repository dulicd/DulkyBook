using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DulkyBook.Models
{
    public class DictionaryModel
    {
        public long Id { get; set; }
        public string English { get; set; }
        public string Serbian { get; set; }
        public int Round { get; set; }
    }
}
