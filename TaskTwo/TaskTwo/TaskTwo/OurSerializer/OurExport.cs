using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Task_1.Part_1;

namespace TaskTwo.OurSerializer
{
    public class OurExport
    {
        public void SerializeRegister(DataRepository data)
        {
            FileStream F = new FileStream("..\\..\\Files\\Register.dat", FileMode.Create, FileAccess.Write);
            BinaryFormatter b = new BinaryFormatter();
            IEnumerable<Register> constant = data.GetAllRegisters();
            b.Serialize(F, constant);
            F.Close();
        }


        public void SerializeCatalog(DataRepository data)
        {
            FileStream F = new FileStream("..\\..\\Files\\Catalog.dat", FileMode.Create, FileAccess.Write);
            BinaryFormatter b = new BinaryFormatter();
            IEnumerable<Catalog> constant = data.GetAllFromCatalog();
            b.Serialize(F, constant);
            F.Close();
        }


        public void SerializeStatusDescription(DataRepository data)
        {
            FileStream F = new FileStream("..\\..\\Files\\StatusDescription.dat", FileMode.Create, FileAccess.Write);
            BinaryFormatter b = new BinaryFormatter();
            IEnumerable<StatusDescription> constant = data.GetAllStatusDescriptions();
            b.Serialize(F, constant);
            F.Close();
        }


        public void SerializeEvent(DataRepository data)
        {
            FileStream F = new FileStream("..\\..\\Files\\Event.dat", FileMode.Create, FileAccess.Write);
            BinaryFormatter b = new BinaryFormatter();
            IEnumerable<Event> constant = data.GetAllEvents();
            b.Serialize(F, constant);
            F.Close();
        }
    }
}
