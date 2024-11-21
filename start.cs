using Start.task_1;
using System;

namespace Start
{
    internal class Start
    {
        public static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            string choice;

            do
            {
                Console.WriteLine("1 - Task 1 - MyMatrix");
                Console.WriteLine("2 - Task 2 - MyTime");
                Console.WriteLine("0 - Exit");

                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("\n\nRunning Task 1 - MyMatrix\n");
                        Start_task1.StartTask1(null);
                        break;

                    case "2":
                        Console.WriteLine("\n\nRunning Task 2 - MyTime\n");
                        Start_MyTime.StartMyTime(null);
                        break;

                    case "0":
                        Console.WriteLine("Exiting program...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please enter 1, 2 or 0 to exit.");
                        break;
                }

            } while (choice != "0");
        }
    }
}
