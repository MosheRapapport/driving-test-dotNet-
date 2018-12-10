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
        bool AddDrivingTest(Test drivingTest);
        bool AddTester(Tester tester);
        bool AddTrainee(Trainee trainee);

        bool RemoveDrivingTest(Test drivingTest);
        bool RemoveTester(Tester tester);
        bool RemoveTrainee(Trainee trainee);

        bool UpdateDrivingTest(Test drivingTest);
        bool UpdateTester(Tester tester);
        bool UpdateTrainee(Trainee trainee);

        List<Test> GetTests();
        List<Tester> GetTesters();
        List<Trainee> GetTrainees();

        Trainee findTrainee(string id);
        Tester findTester(string id);
        bool pastTests(Trainee trainee);

        List<Tester> rangOfTesters(Address address, int rang);
        List<Tester> availableTetsers(DateTime dateTime);
        List<Test> condition(Func<Test, bool> func);
        int numOfTests(Trainee trainee);
        bool PassedTest(Trainee trainee);
        List<Test> TestsToday(DateTime dateTime);
        //grouping
        List<Tester> TestersExpertise(bool sorted=false);
        List<Trainee> traineesBySchool(bool sorted = false);
        List<Trainee> traineesByTeacher(bool sorted = false);
        List<Trainee> traineesByNumOfTests(bool sorted = false);



    }
}
