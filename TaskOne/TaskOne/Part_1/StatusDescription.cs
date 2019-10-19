using System;
using System.Collections.Generic;
using System.Text;

namespace Task_1.Part_1
{
    public class StatusDescription
    {
        private Catalog catalog;
        private int amount;
        private float price;
        private string description;
        private DateTime date;


        public StatusDescription(Catalog catalog, int amount, float price, string description, DateTime date)
        {
            this.catalog = catalog;
            this.amount = amount;
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


        public int Amount
        {
            get
            {
                return amount;
            }
            set
            {
                amount = value;
            }
        }


        public float Price
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
                return this.Catalog.All + " " + Amount + " " + Price + " " + Description + " " + Date;
            }
        }
    }
}