namespace Examination_system
{
    internal class FinalExam : PracticalExam
    {
        #region Constructor

        public FinalExam(int time, int number)
            : base(time, number) { }
        #endregion

        #region Method

        public override void CreateQuestions(int start = 0, int end = -1)
        {
            if (end == -1)
            {
                end = Questions.Length;
            }
            for (int i = 0; i < Questions.Length; i++)
            {
                bool isExam = false;
                int choice = 0;
                do
                {
                    Console.Write(
                        $"Please Choose The Type Of Question Number {i + 1} (1 for True Or False and 2 for MCQ): "
                    );
                    isExam = int.TryParse(Console.ReadLine(), out choice);
                    if (!isExam || (choice != 1 && choice != 2))
                    {
                        Console.WriteLine("Invalid choice. Please enter 1 or 2.");
                        Console.WriteLine();
                        isExam = false;
                    }
                } while (!isExam);

                Console.Clear();

                if (choice == 1)
                {
                    string? body;
                    int marks;
                    bool isValid = false;
                    int correctOptionIndex;

                    Console.WriteLine("True | False Question");
                    do
                    {
                        Console.WriteLine($"Please Enter The Body Of Question: ");
                        body = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(body) || int.TryParse(body, out _))
                        {
                            Console.WriteLine("Invalid input. Please enter a right question ");
                            Console.WriteLine();
                        }
                    } while (string.IsNullOrWhiteSpace(body) || int.TryParse(body, out _));

                    do
                    {
                        Console.WriteLine("Please Enter The Marks Of Question: ");
                        isValid = int.TryParse(Console.ReadLine(), out marks);
                        if (!isValid || marks <= 0)
                        {
                            Console.WriteLine(
                                "Invalid input. Please enter a positive number for marks."
                            );
                            Console.WriteLine();
                            isValid = false;
                        }
                    } while (!isValid || marks <= 0);

                    do
                    {
                        Console.WriteLine(
                            "Please Enter The Right Answer Of Question (1 for True, 2 for False): "
                        );
                        isValid = int.TryParse(Console.ReadLine(), out correctOptionIndex);
                        if (!isValid || (correctOptionIndex != 1 && correctOptionIndex != 2))
                        {
                            Console.WriteLine(
                                "Invalid input. Please enter 1 for True or 2 for False."
                            );
                            Console.WriteLine();
                            isValid = false;
                        }
                    } while (!isValid || (correctOptionIndex != 1 && correctOptionIndex != 2));

                    Questions[i] = new TFQuestion(body, marks);
                    AnswerList[i] = new Answer(
                        correctOptionIndex,
                        correctOptionIndex == 1 ? "True" : "False"
                    );
                    Console.WriteLine(" question have been created successfully.");
                    Console.WriteLine();
                    Thread.Sleep(2000);
                    Console.Clear();
                }
                else if (choice == 2)
                {
                    base.CreateQuestions(i, i + 1); // Create MCQ Questions
                }
            }
        }

        public override void TypeOfExam()
        {
            Console.WriteLine(
                $"Final Exam With Number Of Questions: {Number}, Time: {Time} Minutes And Have MCQ & True Or False Questions"
            );
        }

        public override void DisplayAnswer()
        {
            Console.WriteLine(
                "The Question       |       Your Answers:      |       Right Answers"
            );
            for (int i = 0; i < AnswerList.Length; i++)
            {
                Console.WriteLine(
                    $"Q{i + 1}){Questions[i].Body}     |    {UserAnswers[i].AnswerText}     |     Right Answers: {AnswerList[i].AnswerText}  "
                );
            }

            Console.WriteLine();
            Console.WriteLine($"Your Exam Grade is {userGrade} from {totalGrade}");
        }

        public override void ShowExam()
        {
            base.ShowExam();
        }
        #endregion
    }
}
