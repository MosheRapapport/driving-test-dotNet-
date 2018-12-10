using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface Idal
    {
        List<Tester> GetTesters();
        bool AddTester(Tester tester);
        bool RemoveTester(Tester tester);
        bool UpdateTester(Tester tester);

        List<Trainee> GetTrainees();
        bool AddTrainee(Trainee trainee);
        bool RemoveTrainee(Trainee trainee);
        bool UpdateTrainee(Trainee trainee);

        List<Test> GetTests();
        bool AddTest(Test drivingTest);
        bool RemoveTest(Test drivingTest);
        bool UpdateTest(Test drivingTest);

        
        
        

    }
}
