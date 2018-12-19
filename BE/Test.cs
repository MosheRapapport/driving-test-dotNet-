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
        public DateTime Date { get; set; }
        public Requirement[] Requirements = new Requirement[6]
        { new Requirement {requirement="revers",success=false } ,
          new Requirement { requirement = "U turn", success = false },
          new Requirement {requirement = "speed", success = false },
          new Requirement {requirement = "breks", success = false },
          new Requirement {requirement = "blinks", success = false },
          new Requirement { requirement = "Mirrors", success = false }
        };
        public String Trainee_ID { get; set; }
        public String Tester_ID { get; set; }
        public Address StartingPoint { get; set; }
        public bool Success { get; set; }
        private string comment = "not comment yet";
        public String Comment { get => comment; set => comment = value; }
        public CarType carType { get; set; }
        public override string ToString()
        {
            string A = "";
            foreach (Requirement item in Requirements)
            {
                A += item.ToString();
            }
            return "\ncode of test: " + codeOfTest + " trainee ID: " + Trainee_ID +
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
                Requirements = this.Requirements,
                StartingPoint = this.StartingPoint.Clone(),
                Success = this.Success,
                carType = this.carType.Clone()
            };
        }

    }
}
