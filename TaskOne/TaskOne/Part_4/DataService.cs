using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Task_1.Part_1;

namespace Task_1.Part_4
{
    public class DataService
    {
        private IDataRepository data;


        public DataService(IDataRepository data)
        {
            this.data = data;
        }


        public void View(IEnumerable<Register> lists)
        {
            List<Register> new1 = lists.ToList<Register>();


            for (int i = 0; i < lists.Count(); i++)
            {
                Console.WriteLine(new1[i].FullName);
            }
        }


        public void View(IEnumerable<Catalog> catalogs)
        {
            Dictionary<int, Catalog> new1 = catalogs.ToDictionary(x => x.BookId, x => x);


            for (int i = 0; i < catalogs.Count(); i++)
            {
                Console.WriteLine(new1[i].All);
            }
        }


        public void View(IEnumerable<StatusDescription> descriptions)
        {
            List<StatusDescription> new1 = descriptions.ToList<StatusDescription>();


            for (int i = 0; i < descriptions.Count(); i++)
            {
                Console.WriteLine(new1[i].All);
            }
        }


        public void View(IEnumerable<Event> events)
        {
            ObservableCollection<Event> new1 = new ObservableCollection<Event>(events);


            for (int i = 0; i < events.Count(); i++)
            {
                Console.WriteLine(new1[i].All);
            }
        }



        public IEnumerable<StatusDescription> StatusDescriptionForCatalog(Catalog catalog)
        {
            List<StatusDescription> all = this.data.GetAllStatusDescriptions().ToList<StatusDescription>();
            List<StatusDescription> new1 = new List<StatusDescription>();


            foreach (var description in all)
            {
                if (description.Catalog.Equals(catalog))
                {
                    new1.Add(description);
                }
            }

            return (IEnumerable<StatusDescription>)new1;
        }


        public IEnumerable<Event> EventForRegister(Register register)
        {
            ObservableCollection<Event> all = new ObservableCollection<Event>(this.data.GetAllEvents());
            ObservableCollection<Event> new1 = new ObservableCollection<Event>();


            foreach (var event1 in all)
            {
                if (event1.Person.Equals(register))
                {
                    new1.Add(event1);
                }
            }

            return (IEnumerable<Event>)new1;
        }


        public IEnumerable<Event> EventForStatusDescription(StatusDescription description)
        {
            ObservableCollection<Event> all = new ObservableCollection<Event>(this.data.GetAllEvents());
            ObservableCollection<Event> new1 = new ObservableCollection<Event>();


            foreach (var event1 in all)
            {
                if (event1.Description.Equals(description))
                {
                    new1.Add(event1);
                }
            }

            return (IEnumerable<Event>)new1;
        }



        public void AddRegister(Register register)
        {
            this.data.AddRegister(register);
        }


        public void AddRegister(int personId, string firstName, string lastName)
        {
            this.data.AddRegister(new Register(personId, firstName, lastName));
        }


        public void AddCatalog(Catalog catalog)
        {
            this.data.AddToCatalog(catalog);
        }


        public void AddCatalog(int bookId, string author, string title, int year)
        {
            this.data.AddToCatalog(new Catalog(bookId, author, title, year));
        }


        public void AddStatusDescription(StatusDescription description)
        {
            this.data.AddStatusDescription(description);
        }


        public void AddStatusDescription(Catalog catalog, double price, string description, DateTime date)
        {
            this.data.AddStatusDescription(new StatusDescription(catalog, price, description, date));
        }


        public void AddEvent(Event event1)
        {
            this.data.AddEvent(event1);
        }


        public void AddEventBought(Register person, StatusDescription description, DateTime date, double price)
        {
            this.data.AddEvent(new BookBought(person, description, date, price));
        }


        public void AddEventDestroy(Register person, StatusDescription description, DateTime date)
        {
            this.data.AddEvent(new BookDestroy(person, description, date));
        }


        public void AddEventBorrow(Register person, StatusDescription description, DateTime date)
        {
            this.data.AddEvent(new BookBorrow(person, description, date));
        }


        public void AddEventReturn(Register person, StatusDescription description, DateTime date)
        {
            this.data.AddEvent(new BookReturn(person, description, date));
        }



        public List<Event> FindEvent(string enquiry)
        {
            List<Event> all = this.data.GetAllEvents().ToList<Event>();
            List<Event> new1 = new List<Event>();
            String text = string.Empty;

            for (int i = 0; i < this.data.GetAllEvents().Count(); i++)
            {
                text = all[i].All;

                if (text.Contains(enquiry))
                {
                    new1.Add(all[i]);
                }
            }

            return new1;
        }


        public Dictionary<int, Catalog> FindCatalog(string enquiry)
        {
            Dictionary<int, Catalog> all = this.data.GetAllFromCatalog().ToDictionary(x => x.BookId, x => x);
            Dictionary<int, Catalog> new1 = new Dictionary<int, Catalog>();

            String text = string.Empty;
            int index = 0;

            for (int i = 0; i < this.data.GetAllRegisters().Count(); i++)
            {
                text = all[i].All;

                if (text.Contains(enquiry))
                {
                    new1.Add(index, all[i]);
                    index++;
                }
            }

            return new1;
        }


        public List<StatusDescription> FindStatusDescription(double minimum, double maximum)
        {
            List<StatusDescription> all = this.data.GetAllStatusDescriptions().ToList();
            List<StatusDescription> new1 = new List<StatusDescription>();

            for (int i = 0; i < this.data.GetAllRegisters().Count(); i++)
            {
                if (all[i].Price > minimum && all[i].Price < maximum)
                {
                    new1.Add(all[i]);
                }
            }

            return new1;
        }


        public ObservableCollection<Event> FindEvent(DateTime dateStart, DateTime dateEnd)
        {
            ObservableCollection<Event> all = new ObservableCollection<Event>(this.data.GetAllEvents());
            ObservableCollection<Event> new1 = new ObservableCollection<Event>();

            for (int i = 0; i < this.data.GetAllRegisters().Count(); i++)
            {
                if (all[i].Date > dateStart && all[i].Date < dateEnd)
                {
                    new1.Add(all[i]);
                }
            }

            return new1;
        }
    }
}