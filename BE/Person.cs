using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Person
    {
        public String ID { get; set; }
        public Name Name { get; set; }
        public DateTime DayOfBirth { get; set; }
        public Gender Gender { get; set; }
        public Address Address { get; set; }
        public String PhoneNumber { get; set; }
        public override string ToString()
        {
            return "ID: "+ID+ " Name: "+ Name.ToString()+ " DayOfBirth: "+ DayOfBirth.ToString()+
                " Gender: "+ Gender.ToString()+ Address.ToString()+ " PhoneNumber: "+ PhoneNumber;
        }

    }
}
