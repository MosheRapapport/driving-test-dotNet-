using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Address
    {
        public string StreetName { get; set; }
        public int Number { get; set; }
        public string City { get; set; }
        public override string ToString()
        {
            // "pisga 45 st. jerusalem
            return StreetName + " " + Number + " " + "st." + City;
        }

        public Address Clone()
        {
           
            Address result = new Address
            {
                StreetName = this.StreetName,
                Number = this.Number,
                City = this.City
            };
            return result;
        }
    }
}
