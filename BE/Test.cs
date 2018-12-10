using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Test
    {
        private int _codeOfTest = 0;
        public int codeOfTest { get => _codeOfTest; set => _codeOfTest = value; }
        private DateTime _date;
        public DateTime Date { get => _date.Date; set => _date = value.Date; }
        private List<Requirement> _requirements = new List<Requirement> ();
        public List<Requirement> Requirements { get => _requirements; set => _requirements = value; }
        public String Trainee_ID { get; set; }
        public String Tester_ID { get; set; }
        public Address StartingPoint { get; set; }
        public bool Success { get; set; }
        public String Comment { get; set; }
        public  CarType carType { get; set; }
        public override string ToString()
        {
            string A = "";
            foreach (Requirement item in Requirements)
            {
                A += item.ToString();
            }
            return "code of test: " + codeOfTest + " trainee ID: " + Trainee_ID +
                " tester ID: " + Tester_ID + " date:  " + Date.ToString() + A+
                " starting point: " + StartingPoint.ToString() +
                " success: " + Success + " comment: " + Comment;
        }
        public Test Clone()  //amok 
        {
            return new Test
            {
                codeOfTest = this.codeOfTest,
                Tester_ID = this.Tester_ID,
                Trainee_ID = this.Trainee_ID,
                Date = this.Date,
                Comment = this.Comment,
                Requirements = this.Requirements.ToList(),
                StartingPoint = this.StartingPoint.Clone(),
                Success = this.Success,
                carType = this.carType
            };
        }

    }
}
