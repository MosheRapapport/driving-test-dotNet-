using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Configuration
    {
        //, , גיל נבחן  מינימלי, טווח זמן בין מבחן למבחן
        public static int MIN_LESSONS = 28; //מספר השיעורים המינימלי
        public static int MAX_TESTER_AGE = 99;
        public static int MIN_TESTER_AGE = 40;
        public static int MIN_TRAINEE_AGE = 16;
        public static int MIN_GAP_TEST = 30;
        public static int CODE_OF_TEST = 10000000;

        public override string ToString()
        {
            return " MIN_LESSONS: 28 "+"MAX_TESTER_AGE: 99 "+ "MIN_TRAINEE_AGE: 16 "+" MIN_GAP_TEST: 30\n";
        }

    }
}
