using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace BL
{
    public class Dept_BL:IBL
    {
        public bool AddTester(Tester tester)
        {
            if (DateTime.Now.Year - tester.DayOfBirth.Year < Configuration.MIN_TESTER_AGE)
            {
                throw new Exception("tester under " + Configuration.MIN_TESTER_AGE + " years");
            }
            try
            {
                DAL.FactorySingletonDal.getInstance().AddTester(tester);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return true;
        }
        public bool RemoveTester(Tester tester)
        {
            //אפשר להשתמש בפונקציה שמקבלת תנאי
            foreach (Test item in DAL.FactorySingletonDal.getInstance().GetTests())
            {
                if (tester.ID == item.Tester_ID && item.Date > DateTime.Now)
                    throw new Exception("The tester can not be deleted from the system, because he is registered in a test");
            }
            try
            {
                DAL.FactorySingletonDal.getInstance().RemoveTester(tester);
            }
            catch (Exception e)
            {
                throw e;
            }
            return true;
        }
        public bool UpdateTester(Tester tester)
        {
            foreach (Test item in DAL.FactorySingletonDal.getInstance().GetTests())
            {
                if (tester.ID == item.Tester_ID && item.Date > DateTime.Now)
                    throw new Exception("The tester can not be update in the system, because he is registered in a test");
            }
            try
            {
                DAL.FactorySingletonDal.getInstance().UpdateTester(tester);
            }
            catch (Exception e)
            {
                throw e;
            }
            return true;
        }

        public bool AddTrainee(Trainee trainee)
        {
            if (trainee.DayOfBirth.Year - DateTime.Now.Year < Configuration.MIN_TRAINEE_AGE)
                throw new Exception("trainee under " + Configuration.MIN_TRAINEE_AGE + " years");
            try
            {
                DAL.FactorySingletonDal.getInstance().AddTrainee(trainee);
            }
            catch (Exception e)
            {
                throw e;
            }
            return true;
        }
        public bool RemoveTrainee(Trainee trainee)
        {
            foreach (Test item in DAL.FactorySingletonDal.getInstance().GetTests())
            {
                if (trainee.ID == item.Trainee_ID && item.Date > DateTime.Now)
                    throw new Exception("The trainee can not be deleted from the system, because he is registered in a test");
            }
            try
            {
                DAL.FactorySingletonDal.getInstance().RemoveTrainee(trainee);
            }
            catch (Exception e)
            {
                throw e;
            }
            return true;
        }
        public bool UpdateTrainee(Trainee trainee)
        {
            foreach (Test item in DAL.FactorySingletonDal.getInstance().GetTests())
            {
                if (trainee.ID == item.Trainee_ID && item.Date > DateTime.Now)
                    throw new Exception("The trainee can not be update in the system, because he is registered in a test");
            }
            try
            {
                DAL.FactorySingletonDal.getInstance().UpdateTrainee(trainee);
            }
            catch (Exception e)
            {
                throw e;
            }
            return true;
        }
       
        public bool AddDrivingTest(Test drivingTest)
        {
            Trainee currentTrainee= findTrainee(drivingTest.Trainee_ID);//האם קיים הנבחן
            Tester currentTester = findTester(drivingTest.Tester_ID);//האם קיים הבוחן
            if (currentTrainee.LessonsNb < Configuration.MIN_LESSONS_TO_REGISTER)//עשה מספיק שיעורים
                 throw new Exception("The trainee has not yet had 20 lessons");
            if(currentTrainee.CarTrained!=currentTester.Expertise)//אותו סוג רכב
                 throw new Exception("The type of vehicle does not match theTester's  expertise ");
            pastTests(currentTrainee);//האם נבחן *בהצלחה* על אותו סוג רכב

            //foreach (Trainee item in DAL.FactorySingletonDal.getInstance().GetTrainees())
            //{
            //    if(drivingTest.Trainee_ID==item.ID)
            //    {
            //        if (item.LessonsNb < Configuration.MIN_LESSONS_TO_REGISTER)
            //            throw new Exception("The trainee has not yet had 20 lessons");
            //        //if (item.DateOfTest != null && (DateTime.Now - item.DateOfTest).Days <= 7)
            //        //    throw new Exception("Since the last test it has not been a week");
            //        foreach (Test item2 in DAL.FactorySingletonDal.getInstance().GetTests())
            //        {
            //            if (item.ID == item2.Trainee_ID && drivingTest.carType == item2.carType && item2.Success == true)
            //                throw new Exception("    ");
            //        }

            //    }
            // }
            return true;
        }
        public bool RemoveDrivingTest(Test drivingTest) { return true; }
        public bool UpdateDrivingTest(Test drivingTest) { return true; }

        public List<Tester> GetTesters() { return null; }
        public List<Trainee> GetTrainees() { return null; }
        public List<Test> GetTests() { return null; }

        public List<Tester> rangOfTesters(Address address, int rang)
        {
            throw new NotImplementedException();
        }

        public List<Tester> availableTetsers(DateTime dateTime)
        {
            throw new NotImplementedException();
        }

        public List<Test> condition(Func<Test, bool> func)
        {
            throw new NotImplementedException();
        }

        public int numOfTests(Trainee trainee)
        {
            throw new NotImplementedException();
        }

        public bool PassedTest(Trainee trainee)
        {
            throw new NotImplementedException();
        }

        public List<Test> TestsToday(DateTime dateTime)
        {
            throw new NotImplementedException();
        }

        public List<Tester> TestersExpertise(bool sorted = false)
        {
            throw new NotImplementedException();
        }

        public List<Trainee> traineesBySchool(bool sorted = false)
        {
            throw new NotImplementedException();
        }

        public List<Trainee> traineesByTeacher(bool sorted = false)
        {
            throw new NotImplementedException();
        }

        public List<Trainee> traineesByNumOfTests(bool sorted = false)
        {
            throw new NotImplementedException();
        }

        public Trainee findTrainee(string id)
        {
            foreach (Trainee item in DAL.FactorySingletonDal.getInstance().GetTrainees())
            {
                if (id == item.ID)
                    return item;
            }
            throw new Exception("Trainee not found");
        }

        public Tester findTester(string id)
        {
            foreach (Tester item in DAL.FactorySingletonDal.getInstance().GetTesters())
            {
                if (id == item.ID)
                    return item;
            }
            
            throw new Exception("Tester not found");
        }

        public bool pastTests(Trainee trainee)
        {
            
            foreach (Test item in DAL.FactorySingletonDal.getInstance().GetTests())
            {
                if( (trainee.ID == item.Trainee_ID)&&(trainee.CarTrained==item.carType))
                {
                    if (item.Success)
                    {
                        throw new Exception("Has already passed a test on this type of vehicle");
                    }
                   
                }
                
            }
            return true;
        }
    }
}
