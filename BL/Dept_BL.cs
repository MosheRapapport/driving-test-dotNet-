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
        DAL.Idal dal = DAL.FactorySingletonDal.getInstance();

        public List<Tester> GetTesters()
        {
            return dal.GetTesters();
        }
        public bool AddTester(Tester tester)
        {
            if (DateTime.Now.Year - tester.DayOfBirth.Year < Configuration.MIN_TESTER_AGE)
            {
                throw new Exception("tester under " + Configuration.MIN_TESTER_AGE + " years");
            }
            try
            {
                dal.AddTester(tester);
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
            foreach (Test item in dal.GetTests())
            {
                if (tester.ID == item.Tester_ID && item.Date > DateTime.Now)
                    throw new Exception("The tester can not be deleted from the system, because he is registered in a test");
            }
            try
            {
                dal.RemoveTester(tester);
            }
            catch (Exception e)
            {
                throw e;
            }
            return true;
        }
        public bool UpdateTester(Tester tester)
        {
            foreach (Test item in dal.GetTests())
            {
               //אולי כדאי לבדוק מה הוא מעדכן
                if (tester.ID == item.Tester_ID && item.Date > DateTime.Now)
                    throw new Exception("The tester can not be update in the system, because he is registered in a test");
            }
            try
            {
                dal.UpdateTester(tester);
            }
            catch (Exception e)
            {
                throw e;
            }
            return true;
        }

        public List<Trainee> GetTrainees()
        {
            return dal.GetTrainees();
        }
        public bool AddTrainee(Trainee trainee)
        {
            if (trainee.DayOfBirth.Year - DateTime.Now.Year < Configuration.MIN_TRAINEE_AGE)
                throw new Exception("trainee under " + Configuration.MIN_TRAINEE_AGE + " years");
            try
            {
                dal.AddTrainee(trainee);
            }
            catch (Exception e)
            {
                throw e;
            }
            return true;
        }
        public bool RemoveTrainee(Trainee trainee)
        {
            foreach (Test item in dal.GetTests())
            {
                if (trainee.ID == item.Trainee_ID && item.Date > DateTime.Now)
                    throw new Exception("The trainee can not be deleted from the system, because he is registered in a test");
            }
            try
            {
                dal.RemoveTrainee(trainee);
            }
            catch (Exception e)
            {
                throw e;
            }
            return true;
        }
        public bool UpdateTrainee(Trainee trainee)
        {
            foreach (Test item in dal.GetTests())
            {
                if (trainee.ID == item.Trainee_ID && item.Date > DateTime.Now)
                    throw new Exception("The trainee can not be update in the system, because he is registered in a test");
            }
            try
            {
                dal.UpdateTrainee(trainee);
            }
            catch (Exception e)
            {
                throw e;
            }
            return true;
        }
       
        public List<Test> GetTests()
        {
            return dal.GetTests();
        }
        public bool AddDrivingTest(Test drivingTest)
        {
            Trainee currentTrainee= findTrainee(drivingTest.Trainee_ID);//האם קיים הנבחן
            Tester currentTester = findTester(drivingTest.Tester_ID);//האם קיים הבוחן

            if (currentTrainee.LessonsNb < Configuration.MIN_LESSONS_TO_REGISTER)//עשה מספיק שיעורים
                 throw new Exception("The trainee has not yet had 20 lessons");

            if (currentTrainee.CarTrained != currentTester.Expertise)//אותו סוג רכב
                throw new Exception("The type of vehicle does not match theTester's  expertise ");

            if (numOfTests(currentTrainee) > 0)//בודק האם ישנם טסטים בעבר שעבר או שקיים לו כבר טסט עתידי או שהאחרון היה לפני פחות משבוע
                TestsInThePast(currentTrainee);
        
            if(dal.GetTesters().Count(tester=> tester.ID== currentTester.ID) 
                >= currentTester.MaxTestWeekly)
                throw new Exception("The tester has to meny tests this wike");

            dal.AddTest(drivingTest);
            return true;
        }      
        public bool UpdateDrivingTest(Test drivingTest) { return true; }


        public List<Tester> rangOfTesters(Address address)
        {
            Random X = new Random();
            List<Tester> testersByRange = new List<Tester>();
            var rangGroup = from tester in dal.GetTesters()
                            group tester by tester.MaxDistance > X.Next(10, 200) into g
                            select new { corect = g.Key, testers = g };
            foreach (var item in rangGroup)
            {
                if(item.corect)
                {
                    foreach (var tester in item.testers)
                        testersByRange.Add(tester);
                }
            }
            return testersByRange;
        }

        public List<Tester> availableTetsers(DateTime dateTime)
        {
            throw new NotImplementedException();
        }

        public List<Test> condition(Func<Test, bool> func)
        {
            List<Test> boolTest = dal.GetTests().FindAll(item => func(item));
            return boolTest;
        }

        public int numOfTests(Trainee trainee)
        {
            return (dal.GetTests().Count(Test => 
            (Test.Trainee_ID == trainee.ID) && (Test.carType == trainee.CarTrained)));
        }

        public bool PassedTest(Trainee trainee)
        {
            throw new NotImplementedException();
        }

        public List<Test> TestsToday(DateTime dateTime)
        {
            return condition(test => test.Date == dateTime);
        }

        public Trainee findTrainee(string id)
        {
            foreach (Trainee item in dal.GetTrainees())
            {
                if (id == item.ID)
                    return item;
            }
            throw new Exception("Trainee not found");
        }
        public Tester findTester(string id)
        {
            foreach (Tester item in dal.GetTesters())
            {
                if (id == item.ID)
                    return item;
            }
            
            throw new Exception("Tester not found");
        }
        public List<Test> findTests(Tester tester)
        {
            List <Test> findTests = new List<Test>();

            return findTests;
        }
        public void TestsInThePast(Trainee trainee)
        {
            List<Test> lastTestsList = new List<Test>();
            foreach (Test item in dal.GetTests())
            {
                if( (trainee.ID == item.Trainee_ID)&&(trainee.CarTrained==item.carType))
                {
                    if (item.Success)         //בדיקה האם עבר כבר טסט בסוג רכב זה
                        throw new Exception("Has already passed a test on this type of vehicle");

                    if (item.Date>DateTime.Now)     //בדיקה האם יש לו טסט עתידי
                        throw new Exception("Has already have a test on this type of vehicle in the future");
                    lastTestsList.Add(item);
                }
                
            }
            //בדיקה האם עשה כבר טסט בשבוע האחרון
            var v = from Test item in lastTestsList
                    where (DateTime.Now - item.Date).Days < 7
                    select item;
            if (v.Any()) { throw new Exception("The trainee faild in a test in less then 7777 days"); }
            //foreach (Test item in lastTestsList)
            //{
            //    if ((DateTime.Now - item.Date).Days < 7)
            //        throw new Exception("The trainee faild in a test in less then 7 days");
            //}


        }

        public List<Tester> TestersExpertise(CarType carType, bool sorted = false)
        {
            var v = from tester in dal.GetTesters()
                    group tester by tester.Expertise == carType;
                    
            List<Tester> newList = new List<Tester>();
            foreach (var item in v)
            {
                if (item.Key)
                {
                    foreach (Tester item1 in item)
                        newList.Add(item1);
                }
            }
            return newList;
        }

        public List<Trainee> traineesBySchool(string school, bool sorted = false)
        {
            throw new NotImplementedException();
        }

        public List<Trainee> traineesByTeacher(string teacher, bool sorted = false)
        {
            throw new NotImplementedException();
        }

        public List<Trainee> traineesByNumOfTests(int numOfTests, bool sorted = false)
        {
            throw new NotImplementedException();
        }
    }
}
