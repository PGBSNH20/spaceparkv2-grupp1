using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Models
{
    public class Person
    {
        public string Count { get; set; }
        public List<Results> Results { get; set; }
    }

    public class Results
    {
        public string Name { get; set; }
        public List<string> Starships { get; set; }
    }
}
