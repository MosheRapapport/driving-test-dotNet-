using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace BL
{
    internal class Dept_BL:IBL
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
        //באמצע..... עעעע
        public bool AddDrivingTest(Test drivingTest)
        {
            foreach (Trainee item in DAL.FactorySingletonDal.getInstance().GetTrainees())
            {
                if(drivingTest.Trainee_ID==item.ID)
                {
                    if (item.LessonsNb < 20)
                        throw new Exception("The trainee has not yet had 20 lessons");
                    if (item.DateOfTest != null && (DateTime.Now - item.DateOfTest).Days <= 7)
                        throw new Exception("Since the last test it has not been a week");
                    
                }
            }
            return true;
        }
        public bool RemoveDrivingTest(Test drivingTest) { return true; }
        public bool UpdateDrivingTest(Test drivingTest) { return true; }

        public List<Tester> GetTesters() { return null; }
        public List<Trainee> GetTrainees() { return null; }
        public List<Test> GetTests() { return null; }

    }
}
