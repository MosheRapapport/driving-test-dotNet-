using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Dal_Imp : Idal
    {
        public bool AddTest(Test drivingTest)
        {
            if (drivingTest.codeOfTest != 0)
                throw new Exception("this test is already in the system");
            //initillizing the test code
            Test test = drivingTest.Clone();
            drivingTest.codeOfTest = Configuration.CODE_OF_TEST;
            test.codeOfTest = Configuration.CODE_OF_TEST++;
          
           

            DS.DataSource.TestsList.Add(test);
            return true;
        }

        public bool AddTester(Tester tester)
        {
            foreach (Tester item in DS.DataSource.TestersList)
            {
                if (item.ID == tester.ID)
                {
                    throw new Exception("Tester already exist");
                }
            }
            DS.DataSource.TestersList.Add(tester.Clone());
            return true;

        }

        public bool AddTrainee(Trainee trainee)
        {
            foreach (Trainee item in DS.DataSource.TraineesList)
            {
                if (item.ID==trainee.ID)
                {
                    throw new Exception("trainee already exist");
                }
            }
            DS.DataSource.TraineesList.Add(trainee.Clone());
            return true;
        }

        public List<Tester> GetTesters()
        {
            if (!DS.DataSource.TestersList.Any())
                throw new Exception("There is no testers in the database");
            List<Tester> result = new List<Tester>();
            foreach (Tester item in DS.DataSource.TestersList)
            {
                result.Add(item.Clone());
            }
            return result;
        }

        public List<Test> GetTests()
        {
            //if (!DS.DataSource.TestsList.Any())
            //    throw new Exception("There is no tests in the database");
            List<Test> result = new List<Test>();
            foreach (Test item in DS.DataSource.TestsList)
            {
                result.Add(item.Clone());
            }
            return result;
        }

        public List<Trainee> GetTrainees()
        {
            if (!DS.DataSource.TraineesList.Any())
                throw new Exception("There is no trainees in database");
            List<Trainee> result = new List<Trainee>();
            foreach (Trainee item in DS.DataSource.TraineesList)
            {
                result.Add(item.Clone());
            }
            return result;
        }

        public bool RemoveTest(Test drivingTest)
        {
            foreach (Test item in DS.DataSource.TestsList)
            {
                if (drivingTest.codeOfTest==item.codeOfTest)
                {
                    DS.DataSource.TestsList.Remove(item);
                    return true;
                }
            }
            throw new Exception("The current test is not in the database");
        }

        public bool RemoveTester(Tester tester)
        {
            foreach (Tester item in DS.DataSource.TestersList)
            {
                if (tester.ID == item.ID)
                {
                    DS.DataSource.TestersList.Remove(item);
                    return true;
                }
            }
            throw new Exception("The current tester is not in the database");
        }

        public bool RemoveTrainee(Trainee trainee)
        {
            foreach (Trainee item in DS.DataSource.TraineesList)
            {
                if (trainee.ID==item.ID)
                {
                    DS.DataSource.TraineesList.Remove(item);
                    return true;
                }
            }
            throw new Exception("The current trainee is not in the database");
        }

        public bool UpdateTest(Test drivingTest)
        {
            foreach (Test item in DS.DataSource.TestsList)
            {
                if (drivingTest.codeOfTest==item.codeOfTest)
                {
                    DS.DataSource.TestsList.Remove(item);//delete corente test
                    DS.DataSource.TestsList.Add(drivingTest.Clone());//add the update test
                    return true;
                }
            }
            throw new Exception("The current test is not in the database");
        }

        public bool UpdateTester(Tester tester)
        {
            foreach (Tester item in DS.DataSource.TestersList)
            {
                if (tester.ID==item.ID)
                {
                    DS.DataSource.TestersList.Remove(item);
                    DS.DataSource.TestersList.Add(tester.Clone());
                    return true;
                }
            }
            throw new Exception("The current tester is not in the database");
        }

        public bool UpdateTrainee(Trainee trainee)
        {
            foreach (Trainee item in DS.DataSource.TraineesList)
            {
                if (trainee.ID==item.ID)
                {
                    DS.DataSource.TraineesList.Remove(item);
                    DS.DataSource.TraineesList.Add(trainee.Clone());
                    return true;
                }
            }
            throw new Exception("The current trainee is not in the database");
        }
    }
}
