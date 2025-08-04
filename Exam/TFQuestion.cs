namespace Exam
{
    internal class TFQuestion: Questionbase
    {
        public TFQuestion(string header, string body, int mark, Answer[] answers, Answer correctAnswer)
      : base(header, body, mark, answers, correctAnswer) { }

        public override void Show()
        {
            Console.WriteLine($"\n{Header}: {Body} ({Mark} marks)");
            Console.WriteLine("1. True");
            Console.WriteLine("2. False");
        }
    }

}
