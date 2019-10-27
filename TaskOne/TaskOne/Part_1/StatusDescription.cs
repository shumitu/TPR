using System;
using System.Collections.Generic;
using System.Text;

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


        public string All
        {
            get
            {
                return this.Catalog.All + " " + Price + " " + Description + " " + Date;
            }
        }


        public override bool Equals(object obj)
        {
            if (obj is StatusDescription)
            {
                StatusDescription other = (StatusDescription)obj;
                return this.catalog.Equals(other.catalog) && this.date == other.date;
            }
            return base.Equals(obj);
        }
    }
}