namespace Exam
{
    internal class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Exams Exam { get; set; }

        public Subject(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public void CreateExam()
        {
            Console.Write("Enter Exam Type (1 = Final, 2 = Practical): ");
            int type = int.Parse(Console.ReadLine());

            Console.Write("Enter Exam Duration (minutes): ");
            int time = int.Parse(Console.ReadLine());

            if (type == 2)
            {
                Console.WriteLine("This is a Practical Exam. It only supports MCQ questions.");
            }

            Console.Write("Enter Number of Questions: ");
            int count = int.Parse(Console.ReadLine());

            // Create exam object
            if (type == 1)
                Exam = new FinalExam(time, count);
            else
                Exam = new PracticalExam(time, count);

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"\nEnter details for Question {i + 1}:");

                int qtype;

                if (type == 2)
                {
                    // Practical: only MCQ allowed
                    qtype = 1;
                }
                else
                {
                    Console.Write("Question Type (1 = MCQ, 2 = True/False): ");
                    qtype = int.Parse(Console.ReadLine());
                }

                Console.Write("Enter Question Body: ");
                string body = Console.ReadLine();

                string header = qtype == 1 ? "[MCQ]" : "[T/F]";

                Console.Write("Enter Mark: ");
                int mark = int.Parse(Console.ReadLine());

                if (qtype == 1)
                {
                    Console.Write("Number of choices: ");
                    int choices = int.Parse(Console.ReadLine());

                    Answer[] answers = new Answer[choices];
                    for (int j = 0; j < choices; j++)
                    {
                        Console.Write($"Choice {j + 1}: ");
                        answers[j] = new Answer(j + 1, Console.ReadLine());
                    }

                    Console.Write("Correct answer number: ");
                    int correctIndex = int.Parse(Console.ReadLine()) - 1;

                    Exam.Questions[i] = new MCQQuestion(header, body, mark, answers, answers[correctIndex]);
                }
                else
                {
                    Answer[] tf = {
                    new Answer(1, "True"),
                    new Answer(2, "False")
                };

                    Console.Write("Correct answer (1 = True, 2 = False): ");
                    int correctIndex = int.Parse(Console.ReadLine()) - 1;

                    Exam.Questions[i] = new TFQuestion(header, body, mark, tf, tf[correctIndex]);
                }
            }

            // Ask if user wants to start exam
            Console.Write("\nDo you want to start the exam? (y/n): ");
            string answer = Console.ReadLine().ToLower();

            if (answer != "y")
            {
                Console.WriteLine("\nExam cancelled. Goodbye!");
                return;
            }

            Console.Clear();
            Console.WriteLine("\n===== Start Answering the Questions =====");

            int totalMark = 0;
            int userScore = 0;

            for (int i = 0; i < Exam.Questions.Length; i++)
            {
                var q = Exam.Questions[i];
                Console.WriteLine($"\nQuestion {i + 1} {q.Header}");
                Console.WriteLine($"{q.Body}");

                foreach (var ans in q.Answers)
                {
                    Console.WriteLine(ans);
                }

                Console.Write("Your Answer (Enter answer number): ");
                int userChoice = int.Parse(Console.ReadLine());

                if (q.Answers[userChoice - 1].AnswerText == q.CorrectAnswer.AnswerText)
                {
                    Console.WriteLine("Correct!");
                    userScore += q.Mark;
                }
                else
                {
                    Console.WriteLine($"❌ Wrong. Correct Answer: {q.CorrectAnswer.AnswerText}");
                }

                totalMark += q.Mark;
                Console.WriteLine("-------------------------------------");
            }

            // Result & Evaluation
            double percentage = (double)userScore / totalMark * 100;

            if (percentage >= 85)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n🎉 Your Final Score: {userScore} / {totalMark} - Excellent ({percentage:F1}%)");
            }
            else if (percentage >= 60)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"\n🙂 Your Final Score: {userScore} / {totalMark} - Good ({percentage:F1}%)");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n💔 Your Final Score: {userScore} / {totalMark} - Failed ({percentage:F1}%)");
            }

            Console.ResetColor();
        }
    }


}
