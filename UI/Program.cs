using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;
using BL;

namespace UI
{
    class Program
    {
        static void Main(string[] args)
        {
            Trainee S1 = new Trainee()
            {
                ID = "234567",
                Name = new Name { FirstName = "yoni", LastName = "labell" },
                Address = new Address
                {
                    City = "Jerusalem",
                    Number = 7,
                    StreetName = "mevo yoram",

                },
                PhoneNumber = "0542520196",
                CarTrained = CarType.Private,
                GearType = GearType.Manual,
                DrivingSchool = "beit sefer",
                Instructor = new Name { FirstName = "moshe", LastName = "bfx" },
                LessonsNb = 35,
                DayOfBirth = DateTime.Now.AddYears(31),
                Gender = Gender.MALE,


            };
            Console.WriteLine(S1.ToString());
            Trainee S2 = new Trainee()
            {
                ID = "2345678",
                Name = new Name { FirstName = "moshe", LastName = "rapaport" },
                Address = new Address
                {
                    City = "Jerusalem",
                    Number = 7,
                    StreetName = "bait & gan",

                },
                PhoneNumber = "054567899",
                CarTrained = CarType.Private,
                GearType = GearType.Manual,
                DrivingSchool = "beit sefer",
                Instructor = new Name { FirstName = "moshe", LastName = "bfx" },
                LessonsNb = 35,
                DayOfBirth = DateTime.Now.AddYears(25),
                Gender = Gender.MALE,


            };
            Console.WriteLine(S2.ToString());
            Trainee S3 = new Trainee()
            {
                ID = "23456789",
                Name = new Name { FirstName = "barouch", LastName = "geler" },
                Address = new Address
                {
                    City = "Jerusalem",
                    Number = 9,
                    StreetName = "har nof",

                },
                PhoneNumber = "0543434344",
                CarTrained = CarType.Private,
                GearType = GearType.Manual,
                DrivingSchool = "beit sefer",
                Instructor = new Name { FirstName = "moshe", LastName = "bfx" },
                LessonsNb = 35,
                DayOfBirth = DateTime.Now.AddYears(32),
                Gender = Gender.MALE,


            };
            Console.WriteLine(S2.ToString());
            Console.WriteLine("-----------------");
            Tester T1 = new Tester() {
                ID = "12345",
                Name = new Name { FirstName = "jojo", LastName = "chalass" },
                Address = new Address
                {
                    City = "Jerusalem",
                    Number = 21,
                    StreetName = "havvad haleumi",
                },
                PhoneNumber = "054999999",

                DayOfBirth = DateTime.Now.AddYears(-50),
                Gender = Gender.MALE,
                Experience = 10,
                Expertise = CarType.Private,
                MaxDistance = 2,
                MaxTestWeekly = 3,
                Luz = new Schedule(new bool[5, 6] {
                        { false, false, true, false, false, false},
                        { false, false, false, false, false, false},
                        { false, false, false, false, false, false},
                        { false, false, true, false, false, false},
                        { false, false, false, false, false, false} })
            };
            Console.WriteLine(T1.ToString());
            Console.WriteLine("-----------------");
            Console.ReadKey();
            
          
            List<Requirement> req = new List<Requirement>();
            req.Add(new Requirement() { requirement = "adom", success = false });
            Test M1 = new Test()
            {
                Tester_ID = "12345",
                Trainee_ID = "234567",
                Date = new DateTime(2018, 12, 09, 11, 00, 00),
                Comment = "",
                Requirements = req,
                StartingPoint = new Address()
                {
                    City = "Jerusalem",
                    Number = 7,
                    StreetName = "mevo yoram",
                },
                Success = false,
                
            };
            Console.WriteLine(M1.ToString());
            Test M2 = new Test()
            {
                Tester_ID = "12345",
                Trainee_ID = "23456789",
                Date = new DateTime(2018, 12, 09, 11, 00, 00),
                Comment = "",
                Requirements = req,
                StartingPoint = new Address()
                {
                    City = "Jerusalem",
                    Number = 7,
                    StreetName = "mevo yoram",
                },
                Success = false,

            };
            Console.WriteLine(M2.ToString());
            Console.ReadKey();
            Dept_BL p = new Dept_BL();
            
            try
            {
                p.AddTester(T1);
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            try
            {
                p.AddTrainee(S1);
                p.AddTrainee(S2);
                p.AddTrainee(S3);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            Dal_Imp temp = new Dal_Imp();
            temp.AddTest(M1);
            try
            {
               
                p.AddDrivingTest(M2);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            Console.ReadKey();


        }
    }
}
