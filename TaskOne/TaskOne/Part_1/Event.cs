using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Task_1.Part_1
{
    [Serializable]

    public class Event : ICloneable, SerialInterface
    {
        public Register person;
        public StatusDescription description;
        public DateTime date;


        public Event() { }


        public Event (Event evt)
        {
            Person = evt.person;
            Description = evt.description;
            Date = evt.Date;
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


        public virtual string Serialize(ObjectIDGenerator generator)
        {
            string data = "";
            data += this.GetType().FullName + "-";
            data += generator.GetId(this, out bool firstTime).ToString() + "-";
            data += generator.GetId(this.Person, out firstTime).ToString() + "-";
            data += generator.GetId(this.Description, out firstTime).ToString() + "-";
            data += this.Date + "-";
            return data;
        }


        public void Deserialize(string[] data, Dictionary<long, Object> deserialized)
        {
            this.Person = (Register)deserialized[long.Parse(data[2])];
            this.Description = (StatusDescription)deserialized[long.Parse(data[3])];
            this.Date = DateTime.Parse(data[4]);
        }


        public object Clone()
        {
            return new Event(this);
        }
    }


    [Serializable]
    [JsonObject]
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
    [JsonObject]
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
    [JsonObject]
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
    [JsonObject]
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