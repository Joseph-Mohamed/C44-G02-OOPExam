using System.Diagnostics;

namespace Exam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("===== Welcome to the Exam System =====");

            Console.Write("Enter Subject ID: ");
            int subId = int.Parse(Console.ReadLine());

            Console.Write("Enter Subject Name: ");
            string subName = Console.ReadLine();

            Subject subject = new Subject(subId, subName);
            subject.CreateExam();  

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
        }
    }

