using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_system
{
    internal class TFQuestion : Question
    {
        #region Constructor
        public TFQuestion(string body, int mark)
            : base("True | False Question", body, mark) { }
        #endregion

        #region Method
        public override void DisplayQuestion()
        {
            Console.WriteLine($"Header: {Header}");
            Console.WriteLine($"Body: {Body}");
            Console.WriteLine($"Mark: {Mark}");
        }
        #endregion
    }
}
