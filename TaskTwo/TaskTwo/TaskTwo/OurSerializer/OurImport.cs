using System.Collections.Generic;
using Task_1.Part_1;
using Task_1.Part_2;

namespace TaskTwo.OurSerializer
{
    public class OurImport : IDataFill
    {
        public void Fill(DataContext context)
        {
            IEnumerable<Register> savedregister = OurSerializer.Deserialize<IEnumerable<Register>>(@"..\\..\\Files\\Register.dat");
            foreach (var item in savedregister)
            {
                context.lists.Add(item);
            }


            IEnumerable<Catalog> savedcatalog = OurSerializer.Deserialize<IEnumerable<Catalog>>(@"..\\..\\Files\\Catalog.dat");
            int i = 0;
            foreach (var item in savedcatalog)
            {
                context.catalogs.Add(i, item);
                i++;
            }


            IEnumerable<Event> savedevent = OurSerializer.Deserialize<IEnumerable<Event>>(@"..\\..\\Files\\Event.dat");
            foreach (var item in savedevent)
            {
                context.events.Add(item);
            }


            IEnumerable<StatusDescription> savedstatus = OurSerializer.Deserialize<IEnumerable<StatusDescription>>(@"..\\..\\Files\\StatusDescription.dat");
            foreach (var item in savedstatus)
            {
                context.descriptions.Add(item);
            }
        }
    }
}