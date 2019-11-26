using System;
using System.IO;
using System.Runtime.Serialization;
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
                Console.WriteLine("\n\n[1] Fill with defined data");
                Console.WriteLine("[2] Export to .json");
                Console.WriteLine("[3] Export to .json (whole Context)");
                Console.WriteLine("[4] Export to .txt (whole Context)");
                Console.WriteLine("[5] Import from .json");
                Console.WriteLine("[6] Import from .json (whole Context)");
                Console.WriteLine("[7] Import from .txt (whole Context)");
                Console.WriteLine("[8] Show data");
                Console.WriteLine("[9] Clear data");
                Console.WriteLine("[10] Create test classes and export to .txt");
                Console.WriteLine("[11] Import test classes from .txt");
                Console.WriteLine("[12] Exit program\n\n");
            }

            Show();

            int choose = 0;

            DataContext context = new DataContext();
            EmptyData empty = new EmptyData();
            DataRepository data = new DataRepository(empty);
            const string path = @"..\\..\\Files\\Context.txt";


            while (choose != 12)
            {
                Console.Write("\nEnter your choose: ");
                choose = Convert.ToInt32(Console.ReadLine());

                switch (choose)
                {
                    case 1:
                        Console.WriteLine("Filling with defined data");
                        data = new DataRepository(new ConsoleDataFill());
                        Show();
                        break;

                    case 2:
                        Console.WriteLine("Exporting to .json");
                        JsonExport jsonExporter = new JsonExport();
                        jsonExporter.SerializeRegister(data);
                        jsonExporter.SerializeCatalog(data);
                        jsonExporter.SerializeStatusDescription(data);
                        jsonExporter.SerializeEvent(data);
                        Show();
                        break;

                    case 3:
                        Console.WriteLine("Exporting to .json (whole Context)");
                        JsonContextSerialization wholeContent = new JsonContextSerialization(data);
                        wholeContent.SerializeWhole();
                        Show();
                        break;

                    case 4:
                        Console.WriteLine("Exporting to .txt (whole Context)");
                        using (Stream stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
                        {
                            IOurSerializer serializer = new OurSerializer.OurSerializer();
                            serializer.Serialize(data.context, stream);
                        }
                        Show();
                        break;

                    case 5:
                        Console.WriteLine("Importing from .json");
                        data = new DataRepository(new JsonImport());
                        Show();
                        break;

                    case 6:
                        Console.WriteLine("Importing from .json (whole Context)");
                        data = new DataRepository(new JsonContextSerialization());
                        Show();
                        break;

                    case 7:
                        Console.WriteLine("Importing from .dat (whole Context)");
                        using (Stream stream2 = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
                        {
                            data = new DataRepository(new OurSerializer.OurSerializer(stream2));
                        }
                        Show();
                        break;

                    case 8:
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

                    case 9:
                        Console.WriteLine("Clearing data");
                        EmptyData empty2 = new EmptyData();
                        data = new DataRepository(empty2);
                        Show();
                        break;


                    case 10:
                        Console.WriteLine("Creating test classes and exporting to .txt");
                        TestClassA clsA = new TestClassA(null, 1.5f, new DateTime(2019, 11, 10, 0, 0, 0), "This is TestClassA");
                        TestClassB clsB = new TestClassB(null, 2.5f, new DateTime(2019, 11, 11, 0, 0, 0), "This is TestClassB");
                        TestClassC clsC = new TestClassC(null, 3.5f, new DateTime(2019, 11, 12, 0, 0, 0), "This is TestClassC");
                        clsA.AnotherTestClassB = clsB;
                        clsB.AnotherTestClassC = clsC;
                        clsC.AnotherTestClassA = clsA;
                        using (FileStream s = new FileStream("..\\..\\Files\\TestClassA.txt", FileMode.Create))
                        {
                            IFormatter f = new OurNewSerializer.OurNewSerializer();
                            f.Serialize(s, clsA);
                        }
                        using (FileStream s = new FileStream("..\\..\\Files\\TestClassB.txt", FileMode.Create))
                        {
                            IFormatter f = new OurNewSerializer.OurNewSerializer();
                            f.Serialize(s, clsB);
                        }
                        using (FileStream s = new FileStream("..\\..\\Files\\TestClassC.txt", FileMode.Create))
                        {
                            IFormatter f = new OurNewSerializer.OurNewSerializer();
                            f.Serialize(s, clsC);
                        }
                        Show();
                        break;
                                            

                    case 11:
                        Console.WriteLine("Importing test classes from .txt");
                        using (FileStream s = new FileStream("..\\..\\Files\\TestClassA.txt", FileMode.Open))
                        {
                            IFormatter f = new OurNewSerializer.OurNewSerializer();
                            TestClassA testClassA = (TestClassA)f.Deserialize(s);
                            Console.WriteLine(testClassA.AnotherTestClassB.AnotherTestClassC.AnotherTestClassA.Text);
                        }
                        using (FileStream s = new FileStream("..\\..\\Files\\TestClassB.txt", FileMode.Open))
                        {
                            IFormatter f = new OurNewSerializer.OurNewSerializer();
                            TestClassB testClassB = (TestClassB)f.Deserialize(s);
                            Console.WriteLine(testClassB.AnotherTestClassC.AnotherTestClassA.AnotherTestClassB.Text);
                        }
                        using (FileStream s = new FileStream("..\\..\\Files\\TestClassC.txt", FileMode.Open))
                        {
                            IFormatter f = new OurNewSerializer.OurNewSerializer();
                            TestClassC testClassC = (TestClassC)f.Deserialize(s);
                            Console.WriteLine(testClassC.AnotherTestClassA.AnotherTestClassB.AnotherTestClassC.Text);
                        }
                        Show();
                        break;

                    case 12:
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Wrong choose, try again");
                        Show();
                        break;
                }
            }
        }
    }
}