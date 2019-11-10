using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_1.Part_1;
using Task_1.Part_4;
using TaskTwo.Data;

namespace TaskTwo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=========================================================================");
            Console.WriteLine("Welcome in simple TUI which allows You to perfom I/O operations on files.");
            Console.WriteLine("=========================================================================\n");
            Console.WriteLine("[1] Fill with defined data and show");
            Console.WriteLine("[2] Export to .json");
            Console.WriteLine("[3] Export to .dat");
            Console.WriteLine("[4] Import from .json");
            Console.WriteLine("[5] Import from .dat");
            Console.WriteLine("[6] Show data");
            Console.WriteLine("[7] Exit program");


            int choose = 0;

            DataContext context = new DataContext();
            EmptyData empty = new EmptyData();
            DataRepository data = new DataRepository(empty);


            while (choose != 7)
            {
                Console.Write("\nEnter your choose: ");
                choose = Console.Read() - '0';
                switch (choose)
                {
                    case 1:
                        Console.WriteLine("Filling with defined data");
                        DefinedData defined = new DefinedData();
                        data = new DataRepository(defined);
                        break;

                    case 2:
                        Console.WriteLine("Exporting to .json");
                        break;

                    case 3:
                        Console.WriteLine("Exporting to .dat");
                        break;

                    case 4:
                        Console.WriteLine("Importing from .json");
                        break;

                    case 5:
                        Console.WriteLine("Importing from .dat");
                        break;

                    case 6:
                        Console.WriteLine("Showing data");
                        DataService service = new DataService(data);
                        service.View(data.GetAllRegisters());
                        service.View(data.GetAllFromCatalog());
                        service.View(data.GetAllStatusDescriptions());
                        service.View(data.GetAllEvents());
                        break;

                    case 7:
                        break;

                    default:
                        break;
                }

                Console.ReadLine();
            }         
        }       
    }
}
