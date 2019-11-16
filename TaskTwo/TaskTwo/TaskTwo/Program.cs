using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_1.Part_1;
using Task_1.Part_4;
using TaskTwo.Data;
using TaskTwo.JsonSerializer;
using TaskTwo.OurSerializer;

namespace TaskTwo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=========================================================================");
            Console.WriteLine("Welcome in simple TUI which allows You to perform I/O operations on files.");
            Console.WriteLine("=========================================================================\n");
            Console.WriteLine("[1] Fill with defined data");
            Console.WriteLine("[2] Export to .json");
            Console.WriteLine("[3] Export to .dat");
            Console.WriteLine("[4] Import from .json");
            Console.WriteLine("[5] Import from .dat");
            Console.WriteLine("[6] Show data");
            Console.WriteLine("[7] Clear data");
            Console.WriteLine("[8] Exit program");


            int choose = 0;

            DataContext context = new DataContext();
            EmptyData empty = new EmptyData();
            DataRepository data = new DataRepository(empty);


            while (choose != 8)
            {
                Console.Write("\nEnter your choose: ");
                choose = Console.Read() - '0';
                switch (choose)
                {
                    case 1:
                        Console.WriteLine("Filling with defined data");
                        data = new DataRepository(new DefinedData());
                        break;

                    case 2:
                        Console.WriteLine("Exporting to .json");
                        JsonExport JsonExporter = new JsonExport();
                        JsonContextSerialization whole = new JsonContextSerialization(data);
                        whole.SerializeWhole();
                        JsonExporter.SerializeRegister(data);
                        JsonExporter.SerializeCatalog(data);
                        JsonExporter.SerializeStatusDescription(data);
                        JsonExporter.SerializeEvent(data);
                        break;

                    case 3:
                        Console.WriteLine("Exporting to .dat");
                        OurExport OurExporter = new OurExport();
                        OurExporter.SerializeRegister(data);
                        OurExporter.SerializeCatalog(data);
                        OurExporter.SerializeStatusDescription(data);
                        OurExporter.SerializeEvent(data);
                        break;

                    case 4:
                        Console.WriteLine("Importing from .json");
                        data = new DataRepository(new JsonImport());
                        data = new DataRepository(new JsonContextSerialization());
                        break;

                    case 5:
                        Console.WriteLine("Importing from .dat");
                        OurImport.DeserializeRegister(context);
                        OurImport.DeserializeCatalog(context);
                        OurImport.DeserializeStatusDescription(context);
                        OurImport.DeserializeEvent(context);
                        break;

                    case 6:
                        Console.WriteLine("Showing data\n");
                        DataService service = new DataService(data);
                        Console.WriteLine("\nCatalogs:\n");
                        service.View(data.GetAllRegisters());
                        Console.WriteLine("\nRegisters:\n");
                        service.View(data.GetAllFromCatalog());
                        Console.WriteLine("\nDescriptions:\n");
                        service.View(data.GetAllStatusDescriptions());
                        Console.WriteLine("\nEvents:\n");
                        service.View(data.GetAllEvents());
                        break;

                    case 7:
                        Console.WriteLine("Clearing data");
                        EmptyData empty2 = new EmptyData();
                        data = new DataRepository(empty2);
                        break;                   

                    case 8:
                        Environment.Exit(0);
                        break;

                    default:
                        break;
                }

                Console.ReadLine();
            }         
        }  
    }
}
