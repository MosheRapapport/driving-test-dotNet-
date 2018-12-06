using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace UI
{
    class Program
    {
        static void Main(string[] args)
        {
            Tester T = new Tester() {
                ID = "12345",
                Name = new Name { FirstName = "jojo", LastName = "chalass" },
                Address = new Address
                {
                    City = "Jerusalem",
                    Number = 21,
                    StreetName = "havvad haleumi",
                    //                  ZipCode = 91160
                },
                PhoneNumber = "054999999",

                DayOfBirth = DateTime.Now.AddYears(-50),
                Gender = Gender.MALE,
                Experience = 10,
                Expertise = CarType.Truck_Heavy,
                MaxDistance = 2,
                MaxTestWeekly = 1,
                Luz = new Schedule(new bool[5, 6] {
                        { false, false, true, false, false, false},
                        { false, false, false, false, false, false},
                        { false, false, false, false, false, false},
                        { false, false, true, false, false, false},
                        { false, false, false, false, false, false} })
            };
            Console.WriteLine(T.ToString());
            Console.WriteLine("-----------------");
            Console.ReadKey();
            Trainee S = new Trainee()
            {
                ID = "3064",
                Name = new Name { FirstName = "yoni", LastName = "labell" },
                Address = new Address
                {
                    City = "Jerusalem",
                    Number = 7,
                    StreetName = "mevo yoram",
                    //                  ZipCode = 91160
                },
                PhoneNumber = "0542520196",
                CarTrained = CarType.Private,
                GearType= GearType.Manual,
                DrivingSchool="beit sefer",
                Instructor = new Name { FirstName = "moshe", LastName = "bfx" },
                LessonsNb =35,
                DayOfBirth = DateTime.Now.AddYears(-31),
                Gender = Gender.MALE,
                

            };
            Console.WriteLine(S.ToString());
            Console.WriteLine("-----------------");
            Console.ReadKey();
            Test P = new Test();

        }
    }
}
