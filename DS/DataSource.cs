using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS
{
    public class DataSource
    {
        private static List<Tester> testersList = new List<Tester>();
        private static List<Trainee> traineesList = new List<Trainee>();
        private static List<Test> testsList = new List<Test>();

        public static List<Test> TestsList
        {
            get { return testsList; }
        }

        public static List<Tester> TestersList
        {
            get { return testersList; }
        }

        public static List<Trainee> TraineesList
        {
            get { return traineesList; }
        }


    }
}
