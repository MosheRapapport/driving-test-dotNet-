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
            for (int i = 0; i < 50; i++)
            {
                try
                {
                    BL.AddTrainee(new Trainee()
                    {
                        ID = "S" + i.ToString(),
                        Name = new Name { FirstName = "yoni", LastName = "labell" },
                        Address = new Address
                        {
                            City = "Jerusalem",
                            Number = 7,
                            StreetName = "mevo yoram",

                        },
                        PhoneNumber = "0542520196",
                        CarTrained = new CarType { carType = (carType)(i%4), gearType = (GearType)(i%2) },
                        DrivingSchool = "beit sefer",
                        Instructor = new Name { FirstName = "moshe", LastName = "bfx" },
                        LessonsNb = 20,
                        DayOfBirth = DateTime.Now.AddYears(17),
                        Gender = Gender.MALE,


                    });
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            for (int i = 0; i < 4; i++)
            {
                try
                {
                    BL.AddTester(new Tester()
                    {
                        ID = "T" + i.ToString(),
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
                        Expertise = new CarType { carType = (carType)i, gearType = (GearType)(i%2) },
                        MaxDistance = 3000,
                        MaxTestWeekly = 5,
                        Luz = new Schedule(new bool[5, 6] {
                        { true, false, true, true, true, true},
                        { true, true, false, true, true, true},
                        { true, false, false, true, true, true},
                        { true, true, true, false, true, true},
                        { true, true, true, true, true, true} })
                    });
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            for (int i = 0; i < 40; i++)
            {
                try
                {
                    BL.AddDrivingTest(new Test()
                    {

                        Trainee_ID = "S" + i.ToString(),
                        Date = new DateTime(2018, 12, i%30, (i % 5) + 9, 0, 0),
                        
                        Success = false
                    });
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
           





            //Console.WriteLine("Trainees\n--------------------------------------\n");
            //foreach (Trainee item in BL.GetTrainees())
            //{
            //    Console.WriteLine(item.ToString());
            //}
            //Console.WriteLine("\nTesters\n---------------------------------------\n");
            //foreach (Tester item in BL.GetTesters())
            //{
            //    Console.WriteLine(item.ToString());
            //}
            Console.WriteLine("\nTests\n-----------------------------------------\n");
            foreach (Test item in BL.GetTests())
            {
                Console.WriteLine(item.ToString());
            }
            foreach (var item in BL.GetTests())
            {
                item.Comment = "bad gob";
                item.Requirements[0].success = true;
                item.Requirements[1].success = true;
                item.Requirements[2].success = true;
                item.Requirements[3].success = false;
                item.Requirements[4].success = true;
                item.Requirements[5].success = true;
                try
                {
                    BL.UpdateDrivingTest(item);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

            }
            Console.WriteLine("\nTests after update\n-----------------------------------------\n");
            foreach (Test item in BL.GetTests())
            {
                Console.WriteLine(item.ToString());
            }


            Console.ReadKey();



        }
    }
}

       