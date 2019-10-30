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
            return "Catalog " + this.Catalog.ToString() + " with price: " + this.Price + ", description: " + this.Description + ", date: " + this.Date;
        }


        public override bool Equals(object obj)
        {
            if (obj is StatusDescription)
            {
                StatusDescription other = (StatusDescription)obj;
                return this.catalog.Equals(other.catalog) && this.date == other.date && this.price == other.price && this.description == other.description;
            }
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            var hashCode = 957587004;
            hashCode = hashCode * -1521134295 + EqualityComparer<Catalog>.Default.GetHashCode(catalog);
            hashCode = hashCode * -1521134295 + price.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(description);
            hashCode = hashCode * -1521134295 + date.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Catalog>.Default.GetHashCode(Catalog);
            hashCode = hashCode * -1521134295 + Price.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Description);
            hashCode = hashCode * -1521134295 + Date.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ToString());
            return hashCode;
        }
    }
}