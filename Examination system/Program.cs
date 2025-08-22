using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Examination_system
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Subject subject = new Subject(1, "Computer Science");
            subject.CreateExam();
            Console.Clear();

            string? choose;
            Console.Write("Do You Want To Start The Exam (y | n): ");
            choose = Console.ReadLine()?.ToLower();
            if (!string.IsNullOrEmpty(choose) && choose[0] == 'y')
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                subject.Exam.ShowExam();
                Console.WriteLine($"The Elapses Time = {stopwatch.Elapsed}");
            }
            else
            {
                Console.WriteLine("You Have Not Start The Exam :(");
                return;
            }
        }
    }
}
