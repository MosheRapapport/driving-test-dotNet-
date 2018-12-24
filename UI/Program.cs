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
          
            Dept_BL BL = new Dept_BL();
            try
            {
            BL.AddTrainee(new Trainee()
            {
                ID = "S1",
                Name = new Name { FirstName = "s1", LastName = "s1" },
                Address = new Address
                {
                    City = "s1",
                    Number = 1,
                    StreetName = "s1",

                },
                PhoneNumber = "0542520196",
                CarTrained = new CarType { carType = carType.Private, gearType = GearType.Automatic },
                DrivingSchool = "beit sefer",
                Instructor = new Name { FirstName = "moshe", LastName = "bfx" },
                LessonsNb = 20,
                DayOfBirth = DateTime.Now.AddYears(-17),
                Gender = Gender.MALE,
            });
            BL.AddTrainee(new Trainee()
            {
                ID = "S2",
                Name = new Name { FirstName = "s2", LastName = "s2" },
                Address = new Address
                {
                    City = "s2",
                    Number = 2,
                    StreetName = "s2",

                },
                PhoneNumber = "0542520196",
                CarTrained = new CarType { carType = carType.Private, gearType = GearType.Automatic },
                DrivingSchool = "beit sefer",
                Instructor = new Name { FirstName = "moshe", LastName = "bfx" },
                LessonsNb = 20,
                DayOfBirth = DateTime.Now.AddYears(-17),
                Gender = Gender.MALE,
            });
            BL.AddTrainee(new Trainee()
            {
                ID = "S3",
                Name = new Name { FirstName = "s3", LastName = "s3" },
                Address = new Address
                {
                    City = "s3",
                    Number = 3,
                    StreetName = "s3",

                },
                PhoneNumber = "0542520196",
                CarTrained = new CarType { carType = carType.Private, gearType = GearType.Automatic },
                DrivingSchool = "beit sefer",
                Instructor = new Name { FirstName = "moshe", LastName = "bfx" },
                LessonsNb = 20,
                DayOfBirth = DateTime.Now.AddYears(-17),
                Gender = Gender.MALE,
            });
            BL.AddTrainee(new Trainee()
            {
                ID = "S4",
                Name = new Name { FirstName = "s4", LastName = "s4" },
                Address = new Address
                {
                    City = "s4",
                    Number = 4,
                    StreetName = "s4",

                },
                PhoneNumber = "0542520196",
                CarTrained = new CarType { carType = carType.Private, gearType = GearType.Automatic },
                DrivingSchool = "beit sefer",
                Instructor = new Name { FirstName = "moshe", LastName = "bfx" },
                LessonsNb = 20,
                DayOfBirth = DateTime.Now.AddYears(-17),
                Gender = Gender.MALE,
            });
            BL.AddTrainee(new Trainee()
            {
                ID = "S5",
                Name = new Name { FirstName = "s5", LastName = "s5" },
                Address = new Address
                {
                    City = "s5",
                    Number = 5,
                    StreetName = "s5",

                },
                PhoneNumber = "0542520196",
                CarTrained = new CarType { carType = carType.Private, gearType = GearType.Automatic },
                DrivingSchool = "beit sefer",
                Instructor = new Name { FirstName = "moshe", LastName = "bfx" },
                LessonsNb = 20,
                DayOfBirth = DateTime.Now.AddYears(-17),
                Gender = Gender.MALE,
            });
            BL.AddTrainee(new Trainee()
            {
                ID = "S6",
                Name = new Name { FirstName = "s6", LastName = "s6" },
                Address = new Address
                {
                    City = "s6",
                    Number = 6,
                    StreetName = "s6",

                },
                PhoneNumber = "0542520196",
                CarTrained = new CarType { carType = carType.Private, gearType = GearType.Automatic },
                DrivingSchool = "beit sefer",
                Instructor = new Name { FirstName = "moshe", LastName = "bfx" },
                LessonsNb = 20,
                DayOfBirth = DateTime.Now.AddYears(-17),
                Gender = Gender.MALE,
            });
            BL.AddTrainee(new Trainee()
            {
                ID = "S7",
                Name = new Name { FirstName = "s7", LastName = "s7" },
                Address = new Address
                {
                    City = "s7",
                    Number = 7,
                    StreetName = "s7",

                },
                PhoneNumber = "0542520196",
                CarTrained = new CarType { carType = carType.Private, gearType = GearType.Automatic },
                DrivingSchool = "beit sefer",
                Instructor = new Name { FirstName = "moshe", LastName = "bfx" },
                LessonsNb = 20,
                DayOfBirth = DateTime.Now.AddYears(-17),
                Gender = Gender.MALE,
            });

            BL.AddTester(new Tester()
            {
                ID = "T1",
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
                Expertise = new CarType { carType = carType.Private, gearType = GearType.Automatic },
                MaxDistance = 1000,
                MaxTestWeekly = 5,
                Luz = new Schedule(new bool[5, 6] {
                        { true, true,true, true, true, true},
                        { true, true, true, true, true, true},
                        { true, true, true, true, true, true},
                        { true, true, true, true, true, true},
                        { true, true, true, true, true, true} })
            });
            BL.AddTester(new Tester()
            {
                ID = "T2",
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
                Expertise = new CarType { carType = carType.Private, gearType = GearType.Automatic },
                MaxDistance = 1000,
                MaxTestWeekly = 5,
                Luz = new Schedule(new bool[5, 6] {
                        { true, true,true, true, true, true},
                        { true, true, true, true, true, true},
                        { true, true, true, true, true, true},
                        { true, true, true, true, true, true},
                        { true, true, true, true, true, true} })
            });
            BL.AddTester(new Tester()
            {
                ID = "T3",
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
                Expertise = new CarType { carType = carType.Private, gearType = GearType.Automatic },
                MaxDistance = 1000,
                MaxTestWeekly = 5,
                Luz = new Schedule(new bool[5, 6] {
                        { true, true,true, true, true, true},
                        { true, true, true, true, true, true},
                        { true, true, true, true, true, true},
                        { true, true, true, true, true, true},
                        { true, true, true, true, true, true} })
            });
            BL.AddTester(new Tester()
            {
                ID = "T4",
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
                Expertise = new CarType { carType = carType.Private, gearType = GearType.Automatic },
                MaxDistance = 1000,
                MaxTestWeekly = 5,
                Luz = new Schedule(new bool[5, 6] {
                        { true, true,true, true, true, true},
                        { true, true, true, true, true, true},
                        { true, true, true, true, true, true},
                        { true, true, true, true, true, true},
                        { true, true, true, true, true, true} })
            });

            BL.AddDrivingTest(new Test()
            {

                Trainee_ID = "S1",
                Date = new DateTime(2018, 12, 17, 9, 0, 0),
                Success = false
            });
            BL.AddDrivingTest(new Test()
            {

                Trainee_ID = "S2",
                Date = new DateTime(2018, 12, 17, 9, 0, 0),
                Success = false
            });
            BL.AddDrivingTest(new Test()
            {

                Trainee_ID = "S3",
                Date = new DateTime(2018, 12, 17, 9, 0, 0),
                Success = false
            });
            BL.AddDrivingTest(new Test()
            {

                Trainee_ID = "S4",
                Date = new DateTime(2018, 12, 17, 9, 0, 0),
                Success = false
            });
            BL.AddDrivingTest(new Test()
            {

                Trainee_ID = "S5",
                Date = new DateTime(2018, 12, 17, 9, 0, 0),
                Success = false
            });
            BL.AddDrivingTest(new Test()
            {

                Trainee_ID = "S6",
                Date = new DateTime(2018, 12, 17, 9, 0, 0),
                Success = false
            });
            BL.AddDrivingTest(new Test()
            {

                Trainee_ID = "S7",
                Date = new DateTime(2018, 12, 17, 9, 0, 0),
                Success = false
            });

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
            Console.WriteLine("\nupdate\n-----------------------------------------\n");

            Console.WriteLine("\nTests after update\n-----------------------------------------\n");
            Console.WriteLine("\nupdate tranee\n-----------------------------------------\n");
            Console.WriteLine("\ntranee after update\n-----------------------------------------\n");
            Console.WriteLine("\nTests after update\n-----------------------------------------\n");
            Console.WriteLine("\n---------------------\n-----------------------------------------\n");
            Console.WriteLine("\n---------------------\n-----------------------------------------\n");
            Console.ReadKey();



        }
    }
}

       