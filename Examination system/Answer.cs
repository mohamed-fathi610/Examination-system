using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_system
{
    internal class Answer : ICloneable
    {
        #region propertey
        public int AnswerId { get; set; }
        public string AnswerText { get; set; }

        #endregion


        #region Constructor
        public Answer(int answerId, string answerText)
        {
            AnswerId = answerId;
            AnswerText = answerText;
        }
        #endregion

        #region ToString
        public override string ToString()
        {
            return $"{AnswerId} {AnswerText}";
        }
        #endregion

        #region Implement Interfaces
        public object Clone()
        {
            return new Answer(this.AnswerId, this.AnswerText);
        }
        #endregion
    }
}
