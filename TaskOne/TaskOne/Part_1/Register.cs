using System;
using System.Collections.Generic;
using System.Text;

namespace Task_1.Part_1
{
    public class Register
    {
        private string firstName;
        private string lastName;


        public Register(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
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


        public string FullName
        {
            get
            {
                return firstName + " " + lastName;
            }
        }
    }
}