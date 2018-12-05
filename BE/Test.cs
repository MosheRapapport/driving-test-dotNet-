using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Test
    {
        public Test()
        {
            codeOfTest++;
        }
        private static int codeOfTest = 10000000;
        public int CodeOfTest { get => codeOfTest; }
        private DateTime _date;
        public DateTime Date { get => _date.Date; set => _date = value.Date; }
        private List<Requirement> _requirements = new List<Requirement> ();
        public List<Requirement> Requirements { get => _requirements; set => _requirements = value; }
        public String Trainee_ID { get; set; }
        public String Tester_ID { get; set; }
        public TimeSpan Time { get => Date.TimeOfDay; set => _date.AddMilliseconds(value.TotalMilliseconds); }
        public Address StartingPoint { get; set; }
        public bool Success { get; set; }
        public String Comment { get; set; }
        public override string ToString()
        {
            return "code of test: " + codeOfTest + " trainee ID: " + Trainee_ID +
                " tester ID: " + Tester_ID + " date:  " + Date.ToString() +
                " requirements: " + Requirements.ToString() + " starting point: " + StartingPoint.ToString() +
                " success: " + Success + " comment: " + Comment;
        }

    }
}
