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
    public class OurImport
    {
        static public void DeserializeRegister(DataContext context)
        {
            FileStream F = new FileStream("..\\..\\Files\\Register.dat", FileMode.Open, FileAccess.Read);
            BinaryFormatter b = new BinaryFormatter();
            IEnumerable<Register> list = (IEnumerable<Register>) b.Deserialize(F);
            F.Close();

            for (int i=0; i < list.Count(); i++)
            {
                string amount = list.Count().ToString();
                
                using (var stream = new FileStream("..\\..\\Files\\TestRegister.txt", FileMode.OpenOrCreate, FileAccess.Write))
                {
                    stream.WriteByte(0);
                    WriteString(stream, amount, Encoding.UTF8);
                    stream.Close();
                }               
            }
        }


        static public void DeserializeCatalog(DataContext context)
        {
            FileStream F = new FileStream("..\\..\\Files\\Catalog.dat", FileMode.Open, FileAccess.Read);
            BinaryFormatter b = new BinaryFormatter();
            IEnumerable<Catalog> list = (IEnumerable<Catalog>)b.Deserialize(F);
            F.Close();

            for (int i = 0; i < list.Count(); i++)
            {
                string amount = list.Count().ToString();

                using (var stream = new FileStream("..\\..\\Files\\TestCatalog.txt", FileMode.OpenOrCreate, FileAccess.Write))
                {
                    stream.WriteByte(0);
                    WriteString(stream, amount, Encoding.UTF8);
                    stream.Close();
                }
            }
        }


        static public void DeserializeStatusDescription(DataContext context)
        {
            FileStream F = new FileStream("..\\..\\Files\\StatusDescription.dat", FileMode.Open, FileAccess.Read);
            BinaryFormatter b = new BinaryFormatter();
            IEnumerable<StatusDescription> list = (IEnumerable<StatusDescription>)b.Deserialize(F);
            F.Close();

            for (int i = 0; i < list.Count(); i++)
            {
                string amount = list.Count().ToString();

                using (var stream = new FileStream("..\\..\\Files\\TestStatusDescription.txt", FileMode.OpenOrCreate, FileAccess.Write))
                {
                    stream.WriteByte(0);
                    WriteString(stream, amount, Encoding.UTF8);
                    stream.Close();
                }
            }
        }


        static public void DeserializeEvent(DataContext context)
        {
            FileStream F = new FileStream("..\\..\\Files\\Event.dat", FileMode.Open, FileAccess.Read);
            BinaryFormatter b = new BinaryFormatter();
            IEnumerable<Event> list = (IEnumerable<Event>)b.Deserialize(F);
            F.Close();

            for (int i = 0; i < list.Count(); i++)
            {
                string amount = list.Count().ToString();

                using (var stream = new FileStream("..\\..\\Files\\TestEvent.txt", FileMode.OpenOrCreate, FileAccess.Write))
                {
                    stream.WriteByte(0);
                    WriteString(stream, amount, Encoding.UTF8);
                    stream.Close();
                }
            }
        }


        static private void WriteString(Stream stream, string stringToWrite, Encoding encoding)
        {
            var charBuffer = encoding.GetBytes(stringToWrite);
            stream.Write(charBuffer, 0, charBuffer.Length);
        }
    }
}
