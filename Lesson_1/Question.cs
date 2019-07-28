using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1
{
    public class Question
    {
        public static List<string> textList = new List<string>();
        public static string Ques (string text)
        {
            Console.Write("{0}: ", text);
            textList.Add(text);
            return Console.ReadLine();
        }

        internal static void WriteQues(string i, int txt)
        {
                Console.Write("{0} {1}; ", textList[txt], i);
        }
    }
}
