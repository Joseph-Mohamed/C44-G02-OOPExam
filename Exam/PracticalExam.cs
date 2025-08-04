namespace Exam
{
    internal class PracticalExam:Exams
    {
        public PracticalExam(int time, int numberOfQuestions) : base(time, numberOfQuestions) { }

        public override void ShowExam()
        {
            Console.WriteLine("\n===== Practical Exam =====");
            foreach (var q in Questions)
            {
                q.Show();
                Console.WriteLine($"Correct Answer: {q.CorrectAnswer.AnswerText}\n");
            }
        }
    }
}
