using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

using BL;

namespace UI
{
    class Program
    {
        static void Main(string[] args)
        {
            Trainee S1 = new Trainee()
            {
                ID = "1",
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
                DayOfBirth = DateTime.Now.AddYears(16),
                Gender = Gender.MALE,


            };
            //Console.WriteLine(S1.ToString());
            Trainee S2 = new Trainee()
            {
                ID = "2",
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
            //Console.WriteLine(S2.ToString());
            Trainee S3 = new Trainee()
            {
                ID = "3",
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
            //Console.WriteLine(S2.ToString());
            //Console.WriteLine("-----------------");
            Tester T1 = new Tester()
            {
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
                MaxTestWeekly = 2,
                Luz = new Schedule(new bool[5, 6] {
                        { false, false, true, false, false, false},
                        { false, false, false, false, false, false},
                        { false, false, false, false, false, false},
                        { false, false, true, false, false, false},
                        { false, false, false, false, false, false} })
            };
            Tester T2 = new Tester()
            {
                ID = "123456",
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
                MaxDistance = 201,
                MaxTestWeekly = 2,
                Luz = new Schedule(new bool[5, 6] {
                        { false, false, true, false, false, false},
                        { false, false, false, false, false, false},
                        { false, false, false, false, false, false},
                        { false, false, true, false, false, false},
                        { false, false, false, false, false, false} })
            };
            //Console.WriteLine(T1.ToString());
            //Console.WriteLine("-----------------");
            List<Requirement> req = new List<Requirement>();
            req.Add(new Requirement() { requirement = "adom", success = false });
            Test M1 = new Test()
            {
                Tester_ID = "12345",
                Trainee_ID = "1",
                Date = new DateTime(2018,12,1),
                Comment = "",
                Requirements = req,
                StartingPoint = new Address()
                {
                    City = "Jerusalem",
                    Number = 7,
                    StreetName = "mevo yoram",
                },
                Success =false,
                carType=CarType.Private
            };
            //Console.WriteLine(M1.ToString());
            Test M2 = new Test()
            {
                Tester_ID = "12345",
                Trainee_ID = "1",
                Date = new DateTime(2018, 01,04),
                Comment = "",
                Requirements = req,
                StartingPoint = new Address()
                {
                    City = "Jerusalem",
                    Number = 7,
                    StreetName = "mevo yoram",
                },
                Success = false,
                carType = CarType.Private

            };
            //Console.WriteLine(M2.ToString());
            //Console.ReadKey();
            Dept_BL p = new Dept_BL();
            
            try
            {
                p.AddTester(T1);
                p.AddTester(T2);
                p.AddTrainee(S1);
                //p.AddTrainee(S2);
                //p.AddTrainee(S3);

                //S3.ID = "2";
                //p.UpdateTrainee(S3);
                p.AddDrivingTest(M1);
                p.AddDrivingTest(M2);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            Console.WriteLine("--");
            try
            {
                foreach (Test item in p.TestsToday(new DateTime(2018, 01, 04)))
                {
                    Console.WriteLine(item.codeOfTest);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            Console.WriteLine("--------------------");
            foreach (Trainee item in p.GetTrainees())
            {
                Console.WriteLine(item.ToString());
            }
            foreach (Test item in p.GetTests())
            {
                Console.WriteLine(item.ToString());
            }
            Console.ReadKey();
            Console.ReadKey();


        }
    }
}
