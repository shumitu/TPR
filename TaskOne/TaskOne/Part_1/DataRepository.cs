﻿using System;
using System.Collections.Generic;
using System.Linq;
using Task_1.Part_2;
using Task_1.Part_4;

namespace Task_1.Part_1
{
    [Serializable]
    public class DataRepository : IDataRepository
    {
        public DataContext context;
        public IDataFill fill;


        public DataRepository(IDataFill fill)
        {
            this.context = new DataContext();
            this.fill = fill;
            this.fill.Fill(context);
        }


        public DataContext Context
        {
           private get
            {
                return context;
            }
            set
            {
                context = value;
            }
        }


        public IDataFill Fill
        {
            private get
            {
                return fill;
            }
            set
            {
                fill = value;
            }
        }



        public void AddRegister(Register person)
        {
            context.lists.Add(person);
        }


        public Register GetRegister(int personId)
        {
            foreach (var Person in context.lists)
            {
                if (Person.PersonId == personId)
                {
                    return Person;
                }
            }
            throw new Exception("No match found");
        }


        public IEnumerable<Register> GetAllRegisters()
        {
            return context.lists;
        }


        public void DeleteRegister(int id)
        {
            Register tmp = GetRegister(id);

            foreach (var event1 in context.events)
            {
                if (event1.Person == tmp)
                {
                    throw new Exception("Cannot delete that person");
                }
            }
            context.lists.Remove(tmp);
        }



        private int counter = 7;


        public void AddToCatalog(Catalog catalog)
        {
            context.catalogs.Add(counter, catalog);
            counter++;
        }


        public Catalog GetFromCatalog(int id)
        {
            return context.catalogs[id];
        }


        public IEnumerable<Catalog> GetAllFromCatalog()
        {
            return context.catalogs.Values;
        }


        public void DeleteFromCatalog(int id)
        {
            foreach (var description in context.descriptions)
            {
                if (description.Catalog.Equals(context.catalogs[id]))
                {
                    throw new Exception("Cannot delete this element, because it's used by StatusDescription");
                }
            }
            context.catalogs.Remove(id);
        }



        public void AddEvent(Event event1)
        {
            context.events.Add(event1);
        }


        public Event GetEvent(int id)
        {
            return context.events[id];
        }


        public IEnumerable<Event> GetAllEvents()
        {
            return context.events;
        }


        public void DeleteEvent(int id)
        {
            if (id >= context.events.Count())
            {
                throw new Exception("Cannot find match");
            }
            context.events.Remove(context.events[id]);
        }



        public void AddStatusDescription(StatusDescription description)
        {
            context.descriptions.Add(description);
        }


        public StatusDescription GetStatusDescription(int id)
        {
            return context.descriptions[id];
        }


        public IEnumerable<StatusDescription> GetAllStatusDescriptions()
        {
            return context.descriptions;
        }


        public void DeleteStatusDescription(int id)
        {
            StatusDescription Description = GetStatusDescription(id);
            foreach (var event1 in context.events)
            {
                if (event1.Description.Equals(Description))
                {
                    throw new Exception("StatusDescription is already used somewhere");
                }
            }
            context.descriptions.Remove(Description);
        }
    }
}