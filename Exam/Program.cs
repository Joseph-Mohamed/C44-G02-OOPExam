using System.Diagnostics;

namespace Exam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("===== Welcome to the Exam System =====");

           
            int subId;
            bool isParsed;

            Console.Write("Enter Subject ID: ");
            string input = Console.ReadLine();

            isParsed = int.TryParse(input, out subId) && subId > 0;

            while (!isParsed)
            {
                Console.Write("Invalid! Enter a valid positive Subject ID: ");
                input = Console.ReadLine();
                isParsed = int.TryParse(input, out subId) && subId > 0;
            }


            Console.Write("Enter Subject Name: ");
            string subName = Console.ReadLine();

            Subject subject = new Subject(subId, subName);
            subject.CreateExam();  

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
        }
    }

