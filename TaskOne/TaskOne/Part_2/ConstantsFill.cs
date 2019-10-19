using System;
using System.Collections.Generic;
using System.Text;
using Task_1.Part_1;

namespace Task_1.Part_2
{
    public class ConstantsFill : DataFill
    {
        public ConstantsFill()
        {

        }


        public void Fill(DataContext context)
        {
            context.lists.Add(new Register(1, "Jan", "Kowalski"));
            context.lists.Add(new Register(2, "Tomasz", "Nowak"));
            context.lists.Add(new Register(3, "Adrian", "Wiśniewski"));
            context.lists.Add(new Register(4, "Anna", "Stasiak"));
            context.lists.Add(new Register(5, "Martyna", "Lotus"));
            context.lists.Add(new Register(6, "Kamil", "Szybki"));
            context.lists.Add(new Register(7, "Ewa", "Kuś"));


            context.catalogs.Add(0, new Catalog(0, "Bolesław Prus", "Lalka", 1960));
            context.catalogs.Add(1, new Catalog(1, "Adam Mickiewicz", "Pan Tadeusz", 1978));
            context.catalogs.Add(2, new Catalog(2, "Fiodor Dostojewski", "Zbrodnia i kara", 1989));
            context.catalogs.Add(3, new Catalog(3, "J.R.R. Tolkien", "Władca Pierścieni", 2006));
            context.catalogs.Add(4, new Catalog(4, "J.K. Rowling", "Harry Potter i Zakon Feniksa", 2001));
            context.catalogs.Add(5, new Catalog(5, "Stanisław Lem", "Solaris", 1961));
            context.catalogs.Add(6, new Catalog(6, "Stephen King", "Zielona Mila", 1996));


            context.descriptions.Add(new StatusDescription(context.catalogs[0], 1, 19.99, "Krótki opis", DateTime.Today));
            context.descriptions.Add(new StatusDescription(context.catalogs[1], 1, 29.99, "Krótki opis", DateTime.Today));
            context.descriptions.Add(new StatusDescription(context.catalogs[2], 1, 9.99, "Krótki opis", DateTime.Today));
            context.descriptions.Add(new StatusDescription(context.catalogs[3], 1, 49.99, "Krótki opis", DateTime.Today));
            context.descriptions.Add(new StatusDescription(context.catalogs[4], 1, 44.99, "Krótki opis", DateTime.Today));
            context.descriptions.Add(new StatusDescription(context.catalogs[5], 1, 39.99, "Krótki opis", DateTime.Today));
            context.descriptions.Add(new StatusDescription(context.catalogs[6], 1, 59.99, "Krótki opis", DateTime.Today));


            context.events.Add(new Event(context.lists[0], context.descriptions[0], new DateTime(2019, 07, 23), DateTime.Now));
            context.events.Add(new Event(context.lists[1], context.descriptions[1], new DateTime(2018, 04, 14), DateTime.Now));
            context.events.Add(new Event(context.lists[2], context.descriptions[2], new DateTime(2019, 10, 07), DateTime.Now));
            context.events.Add(new Event(context.lists[3], context.descriptions[3], new DateTime(2019, 02, 21), DateTime.Now));
            context.events.Add(new Event(context.lists[4], context.descriptions[4], new DateTime(2017, 10, 15), DateTime.Now));
            context.events.Add(new Event(context.lists[5], context.descriptions[5], new DateTime(2019, 05, 02), DateTime.Now));
            context.events.Add(new Event(context.lists[6], context.descriptions[6], new DateTime(2019, 06, 29), DateTime.Now));


        }
    }
}
