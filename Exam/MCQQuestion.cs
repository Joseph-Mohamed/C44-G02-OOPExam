namespace Exam
{
    internal class MCQQuestion: Questionbase
    {
        public MCQQuestion(string header, string body, int mark, Answer[] answers, Answer correctAnswer)
       : base(header, body, mark, answers, correctAnswer) { }

        public override void Show()
        {
            Console.WriteLine($"\n{Header}: {Body} ({Mark} marks)");
            foreach (var ans in Answers)
            {
                Console.WriteLine(ans);
            }
        }
    }
}
