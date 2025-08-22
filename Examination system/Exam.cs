namespace Examination_system
{
    internal abstract class Exam : Question, IComparable<Exam>
    {
        #region propertey
        public string[,] options { get; set; }

        public Question[] Questions { get; set; }
        public Answer[] UserAnswers { get; set; }
        public int Time { get; set; }
        public int Number { get; set; }

        #endregion

        #region Constructor
        protected Exam(int time, int number)
        {
            Time = time;
            Number = number;
            Questions = new Question[number];
            AnswerList = new Answer[number];
            UserAnswers = new Answer[number];
            options = new string[number, 4]; // Assuming 4 options per question
        }
        #endregion

        #region Method
        public abstract void TypeOfExam();
        public abstract void CreateQuestions(int start, int end);

        public virtual void ShowExam() { }
        #endregion

        #region ToString
        public override string ToString()
        {
            return $"Exam with {Number} Questions, Time: {Time} minutes";
        }
        #endregion

        #region Implement Interfaces

        public int CompareTo(Exam? other)
        {
            if (other == null)
                return 1;
            return this.Time.CompareTo(other.Time);
        }
        #endregion
    }
}
