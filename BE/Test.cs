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
        private Requirements _requirements = new Requirements();
        public Requirements requirements { get=>_requirements; set=>_requirements=value; }
        public String Trainee_ID { get; set; }
        public String Tester_ID { get; set; }
        public Address StartingPoint { get; set; }
        public bool Success { get; set; }
        private string comment="manyak";
        public String Comment { get => comment; set => comment = value; }
        public CarType carType { get; set; }
        public override string ToString()
        {
            string A = "";
         
            return "\ncode of test: " + codeOfTest + " trainee ID: " + Trainee_ID +
                " tester ID: " + Tester_ID + " date:  " + Date.ToString() + A+
                " carType: "+ carType.ToString()+
                " starting point: " + StartingPoint.ToString() +
                 requirements.ToString()+
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
                requirements=this.requirements.Clone(),
              
                StartingPoint = this.StartingPoint.Clone(),
                Success = this.Success,
                carType = this.carType.Clone()
            };
        }

    }
}
