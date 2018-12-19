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
        void TestsInThePast(Trainee trainee);

        List<Tester> rangOfTesters(Address address);
        //List<Tester> availableTetsers(DateTime dateTime);
        List<Test> condition(Func<Test, bool> func);
        int numOfTests(Trainee trainee);
        bool PassedTest(Trainee trainee);
        List<Test> TestsToday(DateTime dateTime);
        //grouping
        IEnumerable<IGrouping<CarType,Tester>> TestersExpertise( bool sorted=false);
        IEnumerable<IGrouping<string, Trainee>> traineesBySchool( bool sorted = false);
        IEnumerable<IGrouping<Name, Trainee>> traineesByTeacher( bool sorted = false);
        IEnumerable<IGrouping<int, Trainee>> traineesByNumOfTests( bool sorted = false);



    }
}
