namespace Exam
{
    public abstract class Exams: ICloneable , IComparable<Exams>
    {
        public int Time { get; set; }
        public int NumberOfQuestions { get; set; }
        public Questionbase[] Questions { get; set; }

        public Exams(int time, int numberOfQuestions)
        {
            Time = time;
            NumberOfQuestions = numberOfQuestions;
            Questions = new Questionbase[NumberOfQuestions];
        }

        public abstract void ShowExam();

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public int CompareTo(Exams other)
        {
            return this.Time.CompareTo(other.Time);
        }

        public override string ToString()
        {
            return $"Exam Duration: {Time} minutes, Questions: {NumberOfQuestions}";
        }

    }
}
