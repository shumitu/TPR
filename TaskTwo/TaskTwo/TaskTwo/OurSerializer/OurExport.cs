using System.Collections.Generic;
using Task_1.Part_1;

namespace TaskTwo.OurSerializer
{
    public class OurExport
    {
        public void SerializeRegister(DataRepository data)
        {
            IEnumerable<Register> constant = data.GetAllRegisters();
            OurSerializer.Serialize(@"..\\..\\Files\\Register.dat", constant);
        }


        public void SerializeCatalog(DataRepository data)
        {
            IEnumerable<Catalog> constant = data.GetAllFromCatalog();
            OurSerializer.Serialize(@"..\\..\\Files\\Catalog.dat", constant);
        }


        public void SerializeEvent(DataRepository data)
        {
            IEnumerable<Event> constant = data.GetAllEvents();
            OurSerializer.Serialize(@"..\\..\\Files\\Event.dat", constant);
        }


        public void SerializeStatusDescription(DataRepository data)
        {
            IEnumerable<StatusDescription> constant = data.GetAllStatusDescriptions();
            OurSerializer.Serialize(@"..\\..\\Files\\StatusDescription.dat", constant);
        }
    }
}