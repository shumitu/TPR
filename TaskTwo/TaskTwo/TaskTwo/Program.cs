using System;
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

            void Show()
            {
                Console.WriteLine(" ");
                Console.WriteLine(" ");
                Console.WriteLine("[1] Fill with defined data");
                Console.WriteLine("[2] Export to .json");
                Console.WriteLine("[3] Export to .json (whole Context)");
                Console.WriteLine("[4] Export to .dat");
                Console.WriteLine("[5] Export to .dat (whole Context)");
                Console.WriteLine("[6] Import from .json");
                Console.WriteLine("[7] Import from .json (whole Context)");
                Console.WriteLine("[8] Import from .dat");
                Console.WriteLine("[9] Import from .dat (whole Context)");
                Console.WriteLine("[10] Show data");
                Console.WriteLine("[11] Clear data");
                Console.WriteLine("[12] Exit program");
                Console.WriteLine(" ");
                Console.WriteLine(" ");
            }

            Show();

            int choose = 0;

            DataContext context = new DataContext();
            EmptyData empty = new EmptyData();
            DataRepository data = new DataRepository(empty);


            while (choose != 12)
            {
                Console.Write("\nEnter your choose: ");
                choose = Convert.ToInt32(Console.ReadLine());

                switch (choose)
                {
                    case 1:
                        Console.WriteLine("Filling with defined data");
                        data = new DataRepository(new DefinedData());
                        Show();
                        break;

                    case 2:
                        Console.WriteLine("Exporting to .json");
                        JsonExport JsonExporter = new JsonExport();
                        JsonExporter.SerializeRegister(data);
                        JsonExporter.SerializeCatalog(data);
                        JsonExporter.SerializeStatusDescription(data);
                        JsonExporter.SerializeEvent(data);
                        Show();
                        break;

                    case 3:
                        Console.WriteLine("Exporting to .json (whole Context)");
                        JsonContextSerialization whole = new JsonContextSerialization(data);
                        whole.SerializeWhole();
                        Show();
                        break;

                    case 4:
                        Console.WriteLine("Exporting to .dat");
                        OurExport OurExporter = new OurExport();
                        OurExporter.SerializeRegister(data);
                        OurExporter.SerializeCatalog(data);
                        OurExporter.SerializeStatusDescription(data);
                        OurExporter.SerializeEvent(data);
                        Show();
                        break;

                    case 5:
                        Console.WriteLine("Exporting to .dat (whole Context)");
                        OurContextSerialization wholecontext = new OurContextSerialization(data);
                        wholecontext.SerializeWhole();
                        Show();
                        break;

                    case 6:
                        Console.WriteLine("Importing from .json");
                        data = new DataRepository(new JsonImport());
                        Show();
                        break;

                    case 7:
                        Console.WriteLine("Importing from .json (whole Context)");
                        data = new DataRepository(new JsonContextSerialization());
                        Show();
                        break;

                    case 8:
                        Console.WriteLine("Importing from .dat");
                        data = new DataRepository(new OurImport());
                        Show();
                        break;

                    case 9:
                        Console.WriteLine("Importing from .dat (whole Context)");
                        data = new DataRepository(new OurContextSerialization());
                        Show();
                        break;

                    case 10:
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
                        Show();
                        break;

                    case 11:
                        Console.WriteLine("Clearing data");
                        EmptyData empty2 = new EmptyData();
                        data = new DataRepository(empty2);
                        Show();
                        break;

                    case 12:
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Wrong choose");
                        Show();
                        break;
                }
            }
        }
    }
}