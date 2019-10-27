using System;
using System.Collections.Generic;
using System.Text;

namespace Task_1.Part_1
{
    public class Event
    {
        private Register person;
        private StatusDescription description;
        private DateTime date;


        //public Event(Register person, StatusDescription description, DateTime date)
        //{
        //    this.person = person;
        //    this.description = description;
        //    this.date = date;
        //}

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


        public DateTime Date
        {
            get
            {
                return date;
            }
            set
            {
                date = value;
            }
        }


        public string All
        {
            get
            {
                return this.Person.FullName + " " + Description.All + " " + Date;
            }
        }


        public override bool Equals(object obj)
        {
            if (obj is Event)
            {
                Event other = (Event) obj;
                return this.Person.Equals(other.person) && this.Date == other.date;
            }
            return base.Equals(obj);
        }      
    }



    public class BookBought : Event
    {
        private Register person;
        private StatusDescription description;
        private DateTime date;
        private double price;


        public BookBought(Register person, StatusDescription description, DateTime date, double price)
        {
            this.person = person;
            this.description = description;
            this.date = date;
            this.price = price;
        }


        public double Price
        {
            get
            {
                return price;
            }
            set
            {
                price = value;
            }
        }


        public string All
        {
            get
            {
                return this.Person.FullName + " " + Description.All + " " + Date + " " + Price;
            }
        }
    }



    public class BookDestroy : Event
    {
        private Register person;
        private StatusDescription description;
        private DateTime date;


        public BookDestroy(Register person, StatusDescription description, DateTime date)
        {
            this.person = person;
            this.description = description;
            this.date = date;
        }
    }



    public class BookBorrow : Event
    {
        private Register person;
        private StatusDescription description;
        private DateTime date;


        public BookBorrow(Register person, StatusDescription description, DateTime date)
        {
            this.person = person;
            this.description = description;
            this.date = date;
        }
    }



    public class BookReturn : Event
    {
        private Register person;
        private StatusDescription description;
        private DateTime date;


        public BookReturn(Register person, StatusDescription description, DateTime date)
        {
            this.person = person;
            this.description = description;
            this.date = date;
        }
    }
}