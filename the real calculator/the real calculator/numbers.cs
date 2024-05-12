using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace the_real_calculator
{
    class Numbers
    {
        double result = 0;
        string Operator = "";
        bool isOperator = false;

        public static string Remove(string Sentence, int p)
        {
            string t = "";
            for (int i = 0; i < Sentence.Length; i++)
            {
                if (i != p) t += Sentence[i];
            }
            return t;
        }
    }
}
