using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Task_1.Part_1
{
    [Serializable]
    public class Register : ICloneable, SerialInterface
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


        public Register() { }


        public Register(Register reg)
        {
            PersonId = reg.personId;
            FirstName = reg.firstName;
            LastName = reg.lastName;
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


        public string Serialize(ObjectIDGenerator generator)
        {
            string data = "";
            data += this.GetType().FullName + ";";
            data += generator.GetId(this, out bool firstTime).ToString() + ";";
            data += this.PersonId.ToString() + ";";
            data += this.FirstName.ToString() + ";";
            data += this.LastName.ToString() + ";";
            return data;
        }


        public void Deserialize(string[] data, Dictionary<long, Object> deserialized)
        {
            this.PersonId = int.Parse(data[2]);
            this.FirstName = data[3];
            this.LastName = data[4];
        }


        public object Clone()
        {
            return new Register(this);
        }
    }
}