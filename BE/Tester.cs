using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{// חסר מס ' טלפון
    public class Tester:Person
    {
        public Schedule Luz { get; set; }
        public CarType Expertise { get; set; }
        public int Experience { get; set; }
        public int MaxTestWeekly { get; set; }
        public int MaxDistance { get; set; }

    }
}
