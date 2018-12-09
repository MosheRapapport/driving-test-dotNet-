using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Trainee:Person
    {
        public CarType CarTrained { get; set; }
        public GearType GearType { get; set; }
        public String DrivingSchool { get; set; }
        public Name Instructor { get; set; }//name of teacher
        public int LessonsNb { get; set; } //new balance of lessons number
        public DateTime DateOfTest { get; set; }
        public override string ToString()
        {
            return base.ToString() + " CarTrained: " + CarTrained.ToString() +
               " GearType: " + GearType.ToString() + " DrivingSchool: " + DrivingSchool +
               "Instructor: " + Instructor.ToString() + " LessonsNb: " + LessonsNb;
        }
        public new Trainee Clone()
        {
            Trainee result = null;
            result = new Trainee
            {
                Address = this.Address.Clone(),
                DayOfBirth = this.DayOfBirth,
                Gender = this.Gender,
                ID = this.ID,
                Name = this.Name,
                PhoneNumber = this.PhoneNumber,
                CarTrained = this.CarTrained,
                DrivingSchool = this.DrivingSchool,
                GearType = this.GearType,
                Instructor = this.Instructor,
                LessonsNb = this.LessonsNb,
                DateOfTest=this.DateOfTest
            };
            return result;
        }

    }
}
