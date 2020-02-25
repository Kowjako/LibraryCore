using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCore
{
    public class Book
    {
        public int cost { get; set; }
        public string name { get; set; }
        public string author { get; set;}
        public Book(int s, string a, string b)
        {
            cost = s;
            name = a;
            author = b;
        }
    }
}
