namespace Exam
{
    internal class FinalExam: Exams
    {
        public FinalExam(int time, int numberOfQuestions) : base(time, numberOfQuestions) { }

        public override void ShowExam()
        {
            Console.WriteLine("\n===== Final Exam =====");
            foreach (var q in Questions)
            {
                q.Show();
            }
        }
    }
}
