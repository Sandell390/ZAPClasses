using System;
using System.Collections.Generic;
using System.Text;

namespace ZAPFrameLibrary
{
    public class Customer
    {
        private string firstName;

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        private string lastName;

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        private string email;

        public string Eamil
        {
            get { return email; }
            set { email = value; }
        }

        private string telefonNr;

        public string TelefonNr
        {
            get { return telefonNr; }
            set { telefonNr = value; }
        }

        private string address;

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public Customer(string _firstName, string _lastName, string _address, string _email, string _telefonNr)
        {
            firstName = _firstName;
            lastName = _lastName;
            address = _address;
            email = _email;
            telefonNr = _telefonNr;

        }

    }
}
