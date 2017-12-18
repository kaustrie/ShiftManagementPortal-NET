using System;
using System.Collections.Generic;
using System.Text;
using ShiftManagementPortal.Core.SeedWork;

namespace ShiftManagementPortal.Core.Domain.Model
{
    public class Address: ValueObject<Address>
    {
        private string _line1;
        private string _line2;
        private string _city;
        private string _stateCode;
        private int _zipCode;

        public string Line1 => _line1;
        public string Line2 => _line2;
        public string City => _city;
        public string StateCode => _stateCode;
        public int ZipCode => _zipCode;

        public Address(string line1, string line2, string city, string stateCode, int zipCode)
        {
            _line1 = line1;
            _line2 = line2;
            _city = city;
            _stateCode = stateCode;
            _zipCode = zipCode;
        }

        protected override bool EqualsCore(Address other)
        {
            return Line1 == other.Line1
                   && Line2 == other.Line2
                   && City == other.City
                   && StateCode == other.StateCode
                   && ZipCode == other.ZipCode;
        }

        protected override int GetHashCodeCore()
        {
            unchecked
            {
                int hashCode = Line1.GetHashCode();
                hashCode = (hashCode * 397) ^ Line2.GetHashCode();
                hashCode = (hashCode * 397) ^ City.GetHashCode();
                hashCode = (hashCode * 397) ^ StateCode.GetHashCode();
                hashCode = (hashCode * 397) ^ ZipCode.GetHashCode();
                return hashCode;
            }
        }
    }
}
