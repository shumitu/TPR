using System;

namespace Task_1.Part_1
{
    public class Register
    {
        private int personId;
        private string firstName;
        private string lastName;


        public Register(int personId, string firstName, string lastName)
        {
            if (personId < 0)
            {
                throw new Exception("Cannot create person with negative id");
            }

            this.personId = personId;
            this.firstName = firstName;
            this.lastName = lastName;
        }


        public int PersonId
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


        public string FullName
        {
            get
            {
                return personId + " " + firstName + " " + lastName;
            }
        }


        public override bool Equals(object obj)
        {
            Register other = (Register)obj;
            return this.PersonId == other.PersonId && this.FirstName == other.firstName && this.LastName == other.lastName;
        }
    }
}