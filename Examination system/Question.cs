using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_system
{
    internal abstract class Question : IComparable<Question>
    {
        #region propertey
        public string Header { get; set; }
        public string Body { get; set; }
        public int Mark { get; set; }
        public Answer[] AnswerList { get; set; }
        #endregion

        #region Constructor
        protected Question(string header, string body, int mark)
        {
            Header = header;
            Body = body;
            Mark = mark;
        }

        protected Question() { }

        protected Question(string header, string body, int marks, int numberOFQuestion)
            : this(header, body, marks)
        {
            AnswerList = new Answer[numberOFQuestion];
        }
        #endregion

        #region Methods
        public abstract void DisplayQuestion();

        public override string ToString()
        {
            return $"{Header}\n\n{Body}            ({Mark})";
        }
        #endregion

        #region Implement Interfaces
        public int CompareTo(Question? other)
        {
            if (other == null)
                return 1;
            return this.Mark.CompareTo(other.Mark);
        }
        #endregion
    }
}
