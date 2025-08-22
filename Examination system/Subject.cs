using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_system
{
    internal class Subject
    {
        #region propertey
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public Exam Exam { get; set; }

        #endregion

        #region Constructor
        public Subject(int subjectId, string subjectName)
        {
            SubjectId = subjectId;
            SubjectName = subjectName;
        }

        #endregion

        #region Method
        public void CreateExam()
        {
            bool isExam = false;
            int choice = 0,
                time = 0,
                numberOfQuestions = 0;

            do
            {
                Console.Write(
                    "Please Enter The Type Of Exam You Want To Create (1 for Practical and 2 for Final): "
                );

                isExam = int.TryParse(Console.ReadLine(), out choice);
                if (!isExam || (choice != 1 && choice != 2))
                {
                    Console.WriteLine("Invalid choice. Please enter 1 or 2.");
                    Console.WriteLine();
                    isExam = false;
                }
            } while (!isExam || (choice != 1 && choice != 2));

            do
            {
                Console.Write("Please Enter The Time Of Exam In Minutes: ");
                isExam = int.TryParse(Console.ReadLine(), out time);
                if (!isExam || time <= 0)
                {
                    Console.WriteLine("Invalid time. Please enter a positive number.");
                    Console.WriteLine();
                    isExam = false;
                }
            } while (!isExam);

            do
            {
                Console.Write("Please Enter The Number Of Questions You Want To Create: ");
                isExam = int.TryParse(Console.ReadLine(), out numberOfQuestions);
                if (!isExam || numberOfQuestions <= 0)
                {
                    Console.WriteLine("Invalid number. Please enter a positive number.");
                    Console.WriteLine();
                    isExam = false;
                }
            } while (!isExam);

            Console.Clear();

            if (choice == 1)
            {
                Exam = new PracticalExam(time, numberOfQuestions);

                Console.Clear();
                Exam.CreateQuestions(0, -1);
            }
            else if (choice == 2)
            {
                Exam = new FinalExam(time, numberOfQuestions);
                Console.Clear();
                Exam.CreateQuestions(0, -1);
            }
        }
        #endregion

        #region ToString
        public override string ToString()
        {
            return $"Subject: {SubjectName}, ID: {SubjectId}, Exam: {Exam}";
        }
        #endregion
    }
}
