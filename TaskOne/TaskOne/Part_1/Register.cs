using System;
using System.Collections.Generic;
using System.Text;

namespace Task_1.Part_1
{
    public class Register
    {
        private string personId;
        private string firstName;
        private string lastName;


        public Register(string personId, string firstName, string lastName)
        {
            this.personId = personId;
            this.firstName = firstName;
            this.lastName = lastName;
        }


        public string PersonId
        {
            get
            {
                return personId;
            }
            set
            {
                personId = value;
            }
        }


        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
            }
        }


        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
            }
        }


        public string All
        {
            get
            {
                return personId + " " + firstName + " " + lastName;
            }
        }
    }
}