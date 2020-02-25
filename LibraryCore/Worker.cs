using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCore
{
    class Worker : People
    {
        public Worker(string n)
        {
            Name = n;
        }

        public string DisplayInfo()
        {
            return $"Witam, Do pana dyspozycji : {Name}";
        }
    }
}
