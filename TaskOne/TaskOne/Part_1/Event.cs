using System;
using System.Collections.Generic;
using System.Text;

namespace Task_1.Part_1
{
    public class Event
    {
        private Register person;
        private StatusDescription description;
        private DateTime dateBorrow;
        private DateTime dateReturn;


        public Event(Register person, StatusDescription description, DateTime dateBorrow, DateTime dateReturn)
        {
            this.person = person;
            this.description = description;
            this.dateBorrow = dateBorrow;
            this.dateReturn = dateReturn;
        }

        public Register Person
        {
            get
            {
                return person;
            }
            set
            {
                person = value;
            }
        }


        public StatusDescription Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
            }
        }


        public DateTime DateBorrow
        {
            get
            {
                return dateBorrow;
            }
            set
            {
                dateBorrow = value;
            }
        }


        public DateTime DateReturn
        {
            get
            {
                return dateReturn;
            }
            set
            {
                dateReturn = value;
            }
        }


        public string All
        {
            get
            {
                return this.Person.FullName + " " + Description.All + " " + DateBorrow + " " + DateReturn;
            }
        }


        public override bool Equals(object obj)
        {
            if (obj is Event)
            {
                Event other = (Event) obj;
                return this.Person.Equals(other.person) && this.DateBorrow == other.dateBorrow;
            }
            return base.Equals(obj);
        }      
    }
}