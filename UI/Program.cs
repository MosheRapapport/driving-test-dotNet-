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
            Trainee S1, S2, S3;
            newTrainees(out S1, out S2, out S3);
            Tester T1, T2;
            newTesters(out T1, out T2);
            Test M1, M2;
            newTests(out M1, out M2);

            Dept_BL BL = new Dept_BL();

            try
            {
                BL.AddTester(T1);
                BL.AddTester(T2);
                BL.AddTrainee(S1);
                BL.AddTrainee(S2);
                BL.AddTrainee(S3);
                BL.AddDrivingTest(M1);
                BL.AddDrivingTest(M2);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            Console.WriteLine("Trainees\n--------------------------------------\n");
            foreach (Trainee item in BL.GetTrainees())
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("\nTesters\n---------------------------------------\n");
            foreach (Tester item in BL.GetTesters())
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("\nTests\n-----------------------------------------\n");
            foreach (Test item in BL.GetTests())
            {
                Console.WriteLine(item.ToString());
            }
          
            
           
            Console.ReadKey();
            


        }

        private static void newTests(out Test M1, out Test M2)
        {
            List<Requirement> req = new List<Requirement>();
            req.Add(new Requirement() { requirement = "adom", success = false });
            M1 = new Test()
            {
                Tester_ID = "12345",
                Trainee_ID = "1",
                Date = new DateTime(2018,12,18,10,0,0),
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
            //Console.WriteLine(M1.ToString());
            M2 = new Test()
            {
                Tester_ID = "123456",
                Trainee_ID = "2",
              //  DateTime date1 = new DateTime(2008, 3, 1, 7, 0, 0);
            Date = new DateTime(2018, 12, 17, 12, 0, 0),
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
        }

        private static void newTesters(out Tester T1, out Tester T2)
        {
            T1 = new Tester()
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
                        { true, true, true, true, true, true},
                        { true, true, true, true, true, true},
                        { false, true, false, false, false, false},
                        { false, false, true, false, false, false},
                        { false, false, false, true, false, false} })
            };
            T2 = new Tester()
            {
                ID = "123456",
                Name = new Name { FirstName = "moohamed", LastName = "abo rabak" },
                Address = new Address
                {
                    City = "gaza",
                    Number = 21,
                    StreetName = "shahid",
                },
                PhoneNumber = "054770770",

                DayOfBirth = DateTime.Now.AddYears(-50),
                Gender = Gender.MALE,
                Experience = 10,
                Expertise = CarType.Private,
                MaxDistance = 201,
                MaxTestWeekly = 2,
                Luz = new Schedule(new bool[5, 6] {
                        { true, false, true, false, false, false},
                        { false, false, true, false, false, false},
                        { false, false, false, false, false, false},
                        { false, false, true, false, false, false},
                        { true, false, false, false, false, true} })
            };
            //Console.WriteLine(T1.ToString());
            //Console.WriteLine("-----------------");
        }

        private static void newTrainees(out Trainee S1, out Trainee S2, out Trainee S3)
        {
            S1 = new Trainee()
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
            S2 = new Trainee()
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
            S3 = new Trainee()
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
        }


    }
}
