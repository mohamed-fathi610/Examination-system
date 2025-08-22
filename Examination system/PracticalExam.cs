namespace Examination_system
{
    internal class PracticalExam : Exam
    {
        #region property Help
        public int totalGrade { get; set; } = 0;
        public int userGrade { get; set; } = 0;
        #endregion

        #region Constructor
        public PracticalExam(int time, int number)
            : base(time, number) { }

        #endregion

        #region Method
        public override void CreateQuestions(int start, int end = -1)
        {
            string? body;
            int marks;
            bool isValid = false;
            int correctOptionIndex;

            if (end == -1)
            {
                end = Questions.Length;
            }

            for (int i = start; i < end; i++)
            {
                Console.WriteLine("Choose One Answer Question");
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
                    }
                } while (!isValid || marks <= 0);

                int j = 0;

                do
                {
                    Console.WriteLine("Please Enter The Choices Of Question");

                    for (; j < 4; j++)
                    {
                        Console.Write($"Please Enter The Choice Numder {j + 1}: ");
                        options[i, j] = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(options[i, j]))
                        {
                            Console.WriteLine("Invalid input. Please enter a right choice.");
                            Console.WriteLine();
                            isValid = false;
                            break;
                        }
                        if (j == 3)
                        {
                            isValid = true;
                        }
                    }
                } while (!isValid);

                do
                {
                    Console.WriteLine("Please Specify The Right Choice Of Question (1 : 4)");
                    isValid = int.TryParse(Console.ReadLine(), out correctOptionIndex);
                    if (!isValid || correctOptionIndex < 1 || correctOptionIndex > 4)
                    {
                        Console.WriteLine("Invalid input. Please enter a number between 1 and 4.");
                    }
                } while (!isValid || correctOptionIndex < 1 || correctOptionIndex > 4);

                Questions[i] = new MCQQuestion(body, marks);
                AnswerList[i] = new Answer(correctOptionIndex, options[i, correctOptionIndex - 1]);
                Console.WriteLine(" question have been created successfully.");
                Console.WriteLine();
                Thread.Sleep(2000);
                Console.Clear();
            }
        }

        public override void TypeOfExam()
        {
            Console.WriteLine(
                $"Practical Exam With Number Of Questions: {Number}, Time: {Time} minutes and have just MCQ Questions"
            );
        }

        public override void DisplayQuestion()
        {
            for (int i = 0; i < Questions.Length; i++)
            {
                Console.WriteLine($"({Questions[i]})");
            }
        }

        public virtual void DisplayAnswer()
        {
            Console.WriteLine("The Question    |    The Right Answers Of Exam: ");
            for (int i = 0; i < AnswerList.Length; i++)
            {
                Console.WriteLine(
                    $"Q{i + 1}) {Questions[i].Body}   |   {AnswerList[i].AnswerText}"
                );
            }
        }

        public override void ShowExam()
        {
            Console.WriteLine($"Number Of Questions: {Number}");
            Console.WriteLine($"Time: {Time} Minutes");
            TypeOfExam();
            Console.WriteLine();
            Console.WriteLine("Please Wait, The Exam Is Loading...");
            for (int i = 0; i < 6; i++)
            {
                Thread.Sleep(1000);
                Console.WriteLine(5 - i);
            }
            Console.Clear();

            int userInput = 0;
            bool isValid = false;

            for (int i = 0; i < Questions.Length; i++)
            {
                Console.WriteLine($"Q{i + 1}: {Questions[i].Body}   (Mark: {Questions[i].Mark})");

                if (Questions[i] is MCQQuestion mcq)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        Console.Write($"{j + 1}. {options[i, j]}    ");
                    }

                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("-------------------------------------");
                    Console.WriteLine();

                    do
                    {
                        Console.Write("Enter The Number Of The Answer: ");
                        isValid = int.TryParse(Console.ReadLine(), out userInput);
                        if (!isValid || userInput < 1 || userInput > 4)
                        {
                            Console.WriteLine(
                                "Invalid input. Please enter a number between 1 and 4."
                            );
                            Console.WriteLine();
                        }
                    } while (!isValid || userInput < 1 || userInput > 4);

                    UserAnswers[i] = new Answer(userInput, options[i, userInput - 1]);
                    Console.WriteLine();
                    Console.WriteLine("*************************************");
                    Console.WriteLine();
                }
                else if (Questions[i] is TFQuestion tf)
                {
                    Console.WriteLine("1. True    2. False");
                    Console.WriteLine();
                    Console.WriteLine("-------------------------------------");
                    Console.WriteLine();

                    do
                    {
                        Console.Write("Enter The Number Of The Answer: ");
                        isValid = int.TryParse(Console.ReadLine(), out userInput);
                        if (!isValid || userInput != 1 && userInput > 2)
                        {
                            Console.WriteLine(
                                "Invalid input. Please enter 1 for True or 2 for False."
                            );
                            Console.WriteLine();
                        }
                    } while (!isValid || userInput != 1 && userInput != 2);
                    UserAnswers[i] = new Answer(userInput, userInput == 1 ? "True" : "False");
                    Console.WriteLine();
                    Console.WriteLine("*************************************");
                    Console.WriteLine();
                }

                totalGrade += Questions[i].Mark;

                if (isValid)
                {
                    if (AnswerList[i].AnswerId == userInput)
                    {
                        userGrade += Questions[i].Mark;
                    }
                }
            }

            Console.Clear();

            DisplayAnswer();
        }

        #endregion
    }
}
