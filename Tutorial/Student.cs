using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorial
{
    internal class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public double Math { get; set; }
        public double Physics { get; set; }
        public double Chemistry { get; set; }
        public double Biology { get; set; }
        public override string ToString()
        {
            return $"{ID,-5} {Name,-15} {Gender,-7} {Age,5} {Math,5} {Physics,7} {Chemistry,7} {Biology,7}";
        }
    }
}
