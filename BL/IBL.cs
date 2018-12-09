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

    }
}
