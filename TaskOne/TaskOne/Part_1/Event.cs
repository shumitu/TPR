using Newtonsoft.Json;
using System;

namespace Task_1.Part_1
{
    [Serializable]
    public class Event
    {
        public Register person;
        public StatusDescription description;
        public DateTime date;


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


        public override string ToString()
        {
            return "Event with " + this.Person.ToString() + " with description: " + this.Description + " on " + this.Date;
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


    [Serializable]
    public class BookBought : Event
    {
        [JsonProperty(Required=Required.Always)]
        public double Price { get; set; }

        [JsonConstructor]

        public BookBought(Register person, StatusDescription description, DateTime date, double Price)
        {
            if (Price < 0.00)
            {
                throw new Exception("Cannot create event with negative price");
            }

            this.person = person;
            this.description = description;
            this.date = date;
            this.Price = Price;
        }

        public override string ToString()
        {
            return "Event with " + this.Person.ToString() + " with description: " + this.Description + " on " + this.Date + " with price: " + this.Price;
        }


        public override bool Equals(object obj)
        {
            if (obj is Event)
            {
                Event other = (Event)obj;
                return this.Person.Equals(other.Person) && this.Date == other.Date;
            }
            return base.Equals(obj);
        }
    }


    [Serializable]
    public class BookDestroy : Event
    {
        public BookDestroy(Register person, StatusDescription description, DateTime date)
        {
            this.person = person;
            this.description = description;
            this.date = date;
        }


        public override bool Equals(object obj)
        {
            if (obj is Event)
            {
                Event other = (Event)obj;
                return this.Person.Equals(other.Person) && this.Date == other.Date;
            }
            return base.Equals(obj);
        }
    }


    [Serializable]
    public class BookBorrow : Event
    {
        public BookBorrow(Register person, StatusDescription description, DateTime date)
        {
            this.person = person;
            this.description = description;
            this.date = date;
        }


        public override bool Equals(object obj)
        {
            if (obj is Event)
            {
                Event other = (Event)obj;
                return this.Person.Equals(other.Person) && this.Date == other.Date;
            }
            return base.Equals(obj);
        }
    }


    [Serializable]
    public class BookReturn : Event
    {
        public BookReturn(Register person, StatusDescription description, DateTime date)
        {
            this.person = person;
            this.description = description;
            this.date = date;
        }


        public override bool Equals(object obj)
        {
            if (obj is Event)
            {
                Event other = (Event)obj;
                return this.Person.Equals(other.Person) && this.Date == other.Date;
            }
            return base.Equals(obj);
        }
    }
}