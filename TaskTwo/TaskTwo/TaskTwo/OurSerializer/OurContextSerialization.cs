using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_1.Part_1;
using Task_1.Part_2;

namespace TaskTwo.OurSerializer
{
    class OurContextSerialization : IDataFill
    {
        DataContext cont;


        public OurContextSerialization()
        {

        }


        public OurContextSerialization(DataRepository rep)
        {
            this.cont = rep.context;
        }


        public void SerializeWhole()
        {
            try
            {
                OurSerializer.Serialize(@"..\\..\\Files\\Context.dat", cont);
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read: " + e.Message);
            }
        }


        public DataContext DeserializeWhole()
        {
            DataContext deserialized = null;

            try
            {
                deserialized = OurSerializer.Deserialize<DataContext>(@"..\\..\\Files\\Context.dat");
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read: " + e.Message);
            }

            return deserialized;
        }


        public void Fill(DataContext context)
        {
            DataContext deserialized = null;

            try
            {
                deserialized = OurSerializer.Deserialize<DataContext>(@"..\\..\\Files\\Context.dat");
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read: " + e.Message);
            }

            context.lists = deserialized.lists;
            context.catalogs = deserialized.catalogs;
            context.descriptions = deserialized.descriptions;
            context.events = deserialized.events;
        }
    }
}