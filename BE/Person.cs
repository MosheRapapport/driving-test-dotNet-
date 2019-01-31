using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Person
    {
        public string ID { get; set; }
        public Name Name { get; set; }
        public DateTime DayOfBirth { get; set; }
        public Gender Gender { get; set; }
        public Address Address { get; set; }
        public string PhoneNumber { get; set; }
        public override string ToString()
        {
            return "\nID: "+ID+ "\nName: "+ Name.ToString()+ "\nDayOfBirth: "+ DayOfBirth.ToString()+
                "\nGender: "+ Gender.ToString()+ "\nAddress: " + Address.ToString()+ "\nPhoneNumber: "+ PhoneNumber;
        }
        public virtual Person Clone()  //deep clone 
        {
            return new Person
            {
                ID = this.ID,
                Address = new Address
                {
                    City = this.Address.City,
                    Number = this.Address.Number,
                    StreetName = this.Address.StreetName//,
                    //ZipCode = this.Address.ZipCode
                },
                DayOfBirth = this.DayOfBirth,
                Gender = this.Gender,
                Name = this.Name,
                PhoneNumber = this.PhoneNumber
            };
        }


    }
}
