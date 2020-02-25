using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCore
{
    public class Reader : People
    {
        public int sum { get; set; }
        public Reader(string s, int a)
        {
            Name = s;
            sum = a;
        }
    }
}
