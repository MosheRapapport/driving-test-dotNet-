using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace BL
{
    interface IBL
    {
        //G.A.R.U Trainee
        List<Trainee> GetTrainees();
        bool AddTrainee(Trainee trainee);
        bool RemoveTrainee(Trainee trainee);
        bool UpdateTrainee(Trainee trainee);
        //G.A.R.U Tester
        List<Tester> GetTesters();
        bool AddTester(Tester tester);
        bool RemoveTester(Tester tester);
        bool UpdateTester(Tester tester);
        //G.A.U Test
        List<Test> GetTests();
        bool AddDrivingTest(Test drivingTest);
        bool UpdateDrivingTest(Test drivingTest);

        Trainee findTrainee(string id);
        Tester findTester(string id);
        void TestsInThePast(Trainee trainee);

        List<Tester> rangOfTesters(Address address);
        List<Tester> availableTetsers(DateTime dateTime);
        List<Test> condition(Func<Test, bool> func);
        int numOfTests(Trainee trainee);
        bool PassedTest(Trainee trainee);
        List<Test> TestsToday(DateTime dateTime);
        //grouping
        List<Tester> TestersExpertise(CarType carType, bool sorted=false);
        List<Trainee> traineesBySchool(string school , bool sorted = false);
        List<Trainee> traineesByTeacher(string teacher, bool sorted = false);
        List<Trainee> traineesByNumOfTests(int numOfTests, bool sorted = false);



    }
}
