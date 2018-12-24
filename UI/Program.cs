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
            for (int i = 0; i < 4; i++)
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
                        CarTrained = new CarType { carType = (carType)(i), gearType = (GearType)(i%2) },
                        DrivingSchool = "beit sefer",
                        Instructor = new Name { FirstName = "moshe", LastName = "bfx" },
                        LessonsNb = 20,
                        DayOfBirth = DateTime.Now.AddYears(-17),
                        Gender =( Gender)(i%2),


                    });
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                   
                }
            }
            for (int i = 0; i <4; i++)
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
                        Expertise = new CarType { carType = (carType)(i), gearType = (GearType)(i%2) },
                        MaxDistance = 1000,
                        MaxTestWeekly = 5,
                        Luz = new Schedule(new bool[5, 6] {
                        { true, true,true, true, true, true},
                        { true, true, true, true, true, true},
                        { true, true, true, true, true, true},
                        { true, true, true, true, true, true},
                        { true, true, true, true, true, true} })
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
                    BL.AddDrivingTest(new Test()
                    {

                        Trainee_ID = "S" +i.ToString(),
                        Date = new DateTime(2018, 12,17+i,9, 0, 0),                        
                        Success = false
                    });
                }
                catch (Exception e)
                {
                   
                    Console.WriteLine(e);
                   
                }
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
            for (int i = 0; i < 4; i++)
            {
                try
                {
                    foreach (Test item in BL.GetTests())
                    {
                        item.requirements[0].requirement = "tembel";
                        item.requirements[1].success = true;
                        item.requirements[2].success = true;
                        item.requirements[3].success = true;
                        item.requirements[4].success = true;
                        item.requirements[5].success = true;
                        item.Comment = "ok";
                        BL.UpdateDrivingTest(item);





                    }
                  
                   
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
            Console.WriteLine("\nupdate tranee\n-----------------------------------------\n");
            for (int i = 0; i < 4; i++)
            {
                try
                {
                    foreach (Trainee item in BL.GetTrainees())
                    {
                        item.CarTrained.carType =carType.Truck_Heavy ;
                        item.CarTrained.gearType=GearType.Manual;

                        BL.UpdateTrainee (item);





                    }
                  
                   
                }
                catch (Exception e)
                {

                    Console.WriteLine(e);

                }
            }
            Console.WriteLine("\ntranee after update\n-----------------------------------------\n");
            foreach (Trainee item in BL.GetTrainees())
            {
                Console.WriteLine(item.ToString());

            }
            for (int i = 0; i < 4; i++)
            {
                try
                {
                    BL.AddDrivingTest(new Test()
                    {

                        Trainee_ID = "S" + i.ToString(),
                        Date = new DateTime(2018, 12, 23 + i, 9, 0, 0),
                        Success = false
                    });
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
            Console.WriteLine("\n---------------------\n-----------------------------------------\n");
            foreach (var item in BL.traineesByNumOfTests(true))
            {
                Console.WriteLine(item.Key);
                foreach (var v in item)
                {
                    Console.WriteLine(v.ToString());
                }


            }
            Console.WriteLine("\n---------------------\n-----------------------------------------\n");
            foreach (var item in BL.GetTrainees())
            {
                Console.WriteLine(BL.numOfTests(item));
            }
            Console.ReadKey();



        }
    }
}

       