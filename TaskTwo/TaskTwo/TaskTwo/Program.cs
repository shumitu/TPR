using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What would you like to do?:");
            Console.WriteLine("1. Export to .json");
            Console.WriteLine("2. Export to .dat");
            Console.WriteLine("3. Import from .json");
            Console.WriteLine("4. Import from .dat");
            Console.WriteLine("5. Show data");
            Console.WriteLine("6. Exit program");


            int choose = 0;


            while (choose != 6)
            {
                choose = Console.Read()-'0';
                switch (choose)
                {
                    case 1:
                        Console.WriteLine("Exporting to .json");
                        break;

                    case 2:
                        Console.WriteLine("Exporting to .dat");
                        break;

                    case 3:
                        Console.WriteLine("Importing from .json");
                        break;

                    case 4:
                        Console.WriteLine("Importing from .dat");
                        break;

                    case 5:
                        Console.WriteLine("Showing data");
                        break;

                    case 6:
                        break;

                    default:
                        break;
                }
            }
        }
    }
}
