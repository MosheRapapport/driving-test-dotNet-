using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Tester:Person
    {
        public Schedule Luz { get; set; }
        public CarType Expertise { get; set; }
        public int Experience { get; set; }
        public int MaxTestWeekly { get; set; }
        public int MaxDistance { get; set; }
        public override string ToString()
        {
            return base.ToString() + "\n Expertise: " + Expertise.ToString() + " MaxTestWeekly: " + MaxTestWeekly +
                " MaxDistance: " + MaxDistance + "\nLuz: " + Luz.ToString();


        }

    }
}
