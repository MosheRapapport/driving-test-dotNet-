using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    //חסרים פה מס' זיהוי של הטסט, ובתוך הדרישות צריך ליהיות מאפיין בוליאני אם עבר או לא עבר
    public class DrivingTest
    {
        private DateTime _date;
        private List<string> _requirements = new List<string>();
        //  private ArrayList _requirements = new ArrayList();
        /// <summary>
        /// get set the Trainee ID
        /// </summary>
        public String Trainee_ID { get; set; }
        /// <summary>
        /// get set the Tester ID
        /// </summary>
        public String Tester_ID { get; set; }

        public DateTime Date { get { return _date.Date; } set { Date = _date.Date; } }
        public TimeSpan Time { get => Date.TimeOfDay; set => _date.AddMilliseconds(value.TotalMilliseconds); }
        public Address StartingPoint { get; set; }
        public List<String> Requirements { get => _requirements; set => _requirements = value; }
        public bool Success { get; set; }
        public String Comment { get; set; }


    }
}
