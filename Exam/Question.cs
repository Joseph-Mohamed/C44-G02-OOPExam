using System;

namespace Exam
{
    public abstract class Questionbase
    {
        public string Header { get; set; }
        public string Body { get; set; }
        public int Mark { get; set; }
        public Answer[] Answers { get; set; }
        public Answer CorrectAnswer { get; set; }

        public Questionbase(string header, string body, int mark, Answer[] answers, Answer correctAnswer)
        {
            Header = header;
            Body = body;
            Mark = mark;
            Answers = answers;
            CorrectAnswer = correctAnswer;
        }

        public abstract void Show();
    }

}
