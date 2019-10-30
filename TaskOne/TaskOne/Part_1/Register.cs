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


        public override string ToString()
        {
            return "Person id: " + PersonId + ", first name: " + FirstName + ", last name: " + LastName;
        }


        public override bool Equals(object obj)
        {
            Register other = (Register)obj;
            return PersonId == other.PersonId && FirstName == other.firstName && LastName == other.lastName;
        }
    }
}