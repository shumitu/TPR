using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Task_1.Part_1
{
    [Serializable]
    public class StatusDescription : ICloneable
    {
        private Catalog catalog;
        private double price;
        private string description;
        private DateTime date;


        public StatusDescription(Catalog catalog, double price, string description, DateTime date)
        {
            if (price < 0.00)
            {
                throw new Exception("Cannot create description with negative price");
            }

            this.catalog = catalog;
            this.price = price;
            this.description = description;
            this.date = date;
        }


        public StatusDescription() { }


        public StatusDescription(StatusDescription desc)
        {
            Catalog = desc.catalog;
            Price = desc.price;
            Description = desc.description;
            Date = desc.date;
        }


        public Catalog Catalog
        {
            get
            {
                return catalog;
            }
            set
            {
                catalog = value;
            }
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


        public string Description
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
            return "Catalog " + Catalog.ToString() + " with price: " + Price + ", description: " + Description + ", date: " + Date;
        }


        public override bool Equals(object obj)
        {
            if (obj is StatusDescription)
            {
                StatusDescription other = (StatusDescription)obj;
                return catalog.Equals(other.catalog) && date == other.date && price == other.price && description == other.description;
            }
            return base.Equals(obj);
        }


        public string Serialize(ObjectIDGenerator generator)
        {
            string data = "";
            data += this.GetType().FullName + ";";
            data += generator.GetId(this, out bool firstTime).ToString() + ";";
            data += generator.GetId(this.Catalog, out firstTime).ToString() + ";";
            data += this.Price.ToString() + ";";
            data += this.Description.ToString() + ";";
            data += this.Date + ";";
            return data;
        }


        public void Deserialize(string[] data, Dictionary<long, Object> deserialized)
        {
            this.Catalog = (Catalog)deserialized[long.Parse(data[2])];
            this.Price = double.Parse(data[3]);
            this.Description = data[4];
            this.Date = DateTime.Parse(data[5]);
        }


        public object Clone()
        {
            return new StatusDescription(this);
        }
    }
}