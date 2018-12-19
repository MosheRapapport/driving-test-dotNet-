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
        private static  DAL.Idal dal = DAL.FactorySingletonDal.getInstance();


        //G.A.R.U Trainee
        public List<Trainee> GetTrainees()
        {
            return dal.GetTrainees();
        } //v
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
        } //v
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
        } //v
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
        } //v

        //Functions for Trainee
        public int numOfTests(Trainee trainee)
        {
            return (dal.GetTests().Count(Test =>
            (Test.Trainee_ID == trainee.ID) && (Test.carType >= trainee.CarTrained)));
        }//v
        public bool PassedTest(Trainee trainee)
        {
            foreach (Test item in dal.GetTests())
            {
                if ((trainee.ID == item.Trainee_ID) && (trainee.CarTrained <= item.carType) && (item.Success))
                    return true;
            }
            return false;
        }
        public Trainee findTrainee(string id)
        {
            foreach (Trainee item in dal.GetTrainees())
            {
                if (id == item.ID)
                    return item;
            }
            throw new Exception("Trainee not found");
        }//v
        public void TestsInThePast(Trainee trainee)
        {
            List<Test> lastTestsList = new List<Test>();
            foreach (Test item in dal.GetTests())
            {
                if ((trainee.ID == item.Trainee_ID) && (trainee.CarTrained <= item.carType) )
                {
                    if (item.Success)         //בדיקה האם עבר כבר טסט בסוג רכב זה
                        throw new Exception("Has already passed a test on this type of vehicle or better");

                    if (item.Date > DateTime.Now)     //בדיקה האם יש לו טסט עתידי
                        throw new Exception("Has already have a test on this type of vehicle or better in the future");
                    lastTestsList.Add(item);
                }

            }
            //בדיקה האם עשה כבר טסט בשבוע האחרון
            var v = from Test item in lastTestsList
                    where (DateTime.Now - item.Date).Days < 7
                    select item;
            if (v.Any()) { throw new Exception("The trainee faild in a test in less then 7 days"); }

        }//v


        //G.A.R.U Tester
        public List<Tester> GetTesters()
        {
            return dal.GetTesters();
        } //v
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
        } //v
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
        } //v
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
        }//v

        //Functions for Tester
        public List<Tester> rangOfTesters(Address address)
        {
            Random X = new Random();
            List<Tester> testersByRange = new List<Tester>();
            var rangGroup = from tester in dal.GetTesters()
                            group tester by tester.MaxDistance > X.Next(10, 200) into g
                            select new { corect = g.Key, testers = g };
            foreach (var item in rangGroup)
            {
                if (item.corect)
                {
                    foreach (var tester in item.testers)
                        testersByRange.Add(tester);
                }
            }
            return testersByRange;
        }//v
        //public List<Tester> availableTetsers(DateTime dateTime)
        //{
        //    throw new NotImplementedException();
        //}
        public List<Test> condition(Func<Test, bool> func)
        {
            List<Test> boolTest = dal.GetTests().FindAll(item => func(item));
            return boolTest;
        }//v
        public List<Test> TestsToday(DateTime dateTime)
        {
            return condition(test => test.Date.AddHours(-test.Date.Hour) == dateTime.AddHours(-dateTime.Hour));
        }//v    
        public Tester findATester(Test test)
        {
            //עובר על כל הטסטרים מאותו סוג רכב ובודק האם הם זמינים
            var v = from t1 in TestersExpertise(test.carType)
                    from t2 in rangOfTesters(test.StartingPoint)
                    where t1 == t2
                    select t1;
            foreach (var item in v)
            {
                if (AvailableTester(item, test.Date))
                {
                    return item;
                }
            }

            throw new Exception("Tester not found `");
        }//v
        public bool AvailableTester(Tester tester, DateTime Date)
        {
            //האם הטסטר עובד
            if (tester.Luz.data[(int)Date.DayOfWeek, Date.Hour - 9] == false)
            {
                return false;
            }
            //האם כבר יש לו טסט באותו שעה
            var v = from t in dal.GetTests()
                    where t.Tester_ID == tester.ID && SameWeek(t.Date,Date)
                   // orderby t.Date==Date
                    select t;
            foreach (var item in v)
            {
                if (item.Date == Date)
                {
                    Console.WriteLine("The tester has a test in this date\n");
                    return false;
                }
            }
            //האם עבר את כמות הטסטים המותרת באותו שבוע
            if(v.Count()>=tester.MaxTestWeekly)
            {
                Console.WriteLine("The tester has to meny tests this wike\n");
                return false;
            }
            return true;
        }//v+
        public List<Tester> TestersExpertise(CarType carType)
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
        }//v


        //G.A.U Test
        public List<Test> GetTests()
        {
            return dal.GetTests();
        } //v
        public bool AddDrivingTest(Test drivingTest)
        {
            //האם הנבחן קיים במערכת
            Trainee currentTrainee = findTrainee(drivingTest.Trainee_ID);
            //עשה מספיק שיעורים
            if (currentTrainee.LessonsNb < Configuration.MIN_LESSONS_TO_REGISTER)
                 throw new Exception("The trainee has not yet had 20 lessons");
            //בודק האם ישנם טסטים בעבר שעבר או שקיים לו כבר טסט עתידי או שהאחרון היה לפני פחות משבוע
            if (numOfTests(currentTrainee) > 0)
                TestsInThePast(currentTrainee);
            //האם יש בוחן זמין
            Tester currentTester = findATester(drivingTest);
            drivingTest.Tester_ID = currentTester.ID;

            //ADD
            try
            {
                dal.AddTest(drivingTest);
            }
            catch (Exception e)
            {
                throw e;
            }
            return true;
        }//v-
        public bool UpdateDrivingTest(Test drivingTest)
        {
            return true;
        }
        public bool SameWeek(DateTime date1, DateTime date2)
        {
            return date1.AddDays(-(int)date1.DayOfWeek).AddHours(-date1.Hour) ==
                date2.AddDays(-(int)date2.DayOfWeek).AddHours(-date2.Hour);
        }





        public List<Test> findTests(Tester tester)
        {
            List <Test> findTests = new List<Test>();

            return findTests;
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

        public List<Tester> TestersExpertise(CarType carType, bool sorted = false)
        {
            throw new NotImplementedException();
        }
    }
}
