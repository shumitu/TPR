using System;
using System.Collections.Generic;

namespace Task_1.Part_1
{
    public class StatusDescription
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

    }
}