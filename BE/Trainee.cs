using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{// חסר מס' טלפון
    public class Trainee:Person
    {
        public CarType CarTrained { get; set; }
        public GearType GearType { get; set; }
        public String DrivingSchool { get; set; }
        public Name Instructor { get; set; }//(name of teacher)
        public int LessonsNb { get; set; }  //new balance of lessons number

    }
}
