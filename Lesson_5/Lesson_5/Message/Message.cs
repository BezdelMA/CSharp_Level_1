using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Message
{
    class MessageString
    {
        string message;

        public string Print
        {
            get
            {
                string str = "";
                foreach (var i in message)
                    str += i;
                return str;
            }
        }

        public int Length
        {
            get
            {
                string[] str = message.Split(' ');
                return str.Length;
            }
        }

        public string StringTo
        {
            get
            {
                return message;
            }
        }

        public string MaxLength
        {
            get
            {
                string [] str = message.Split(' ', '.', ',', '?', '!');
                string max = str[0];
                string maxLength = "";
                for (int i = 1; i < str.Length; i ++)
                {
                    if (str[i].Length > max.Length)
                        max = str[i];
                }
                for (int i = 0; i < str.Length; i ++)
                {
                    if (str[i].Length == max.Length)
                        maxLength += str[i];
                }
                return maxLength;
            }
        }

        public MessageString()
        {

        }

        public MessageString(string message)
        {
            this.message = message;
        }

        public MessageString(string[] messageMass)
        {
            message = "";
            foreach (var i in messageMass)
                message += i;
        }
        
        public static MessageString Conclusion (MessageString message, int n)
        {
            int j = 0;
            string [] str = message.Split(' ', '.', ',', '?', '!');
            foreach (var i in str)
            {
                if (i.Length <= n)
                    ++j;
            }
            string[] answer = new string [j];
            j = 0;
            foreach (var i in str)
            {
                if (i.Length <= n)
                {
                    answer[j] = i + " ";
                    ++j;
                }
            }
            return new MessageString(answer);
        }

        public static MessageString Max(MessageString message, int n)
        {
            int j = 0;
            string[] str = message.Split(' ', '.', ',', '?', '!');
            foreach (var i in str)
            {
                if (i.Length >= n)
                    ++j;
            }
            string[] answer = new string[j];
            j = 0;
            foreach (var i in str)
            {
                if (i.Length >= n)
                {
                    answer[j] = i + " ";
                    ++j;
                }
            }
            return new MessageString(answer);
        }

        private string[] Split(char v, char d, char c, char b, char a)
        {
            return message.Split(v, a, b, c, d);
        }

        public static MessageString DeleteChar (MessageString message, char v)
        {
            string [] txt = (message.StringTo).Split(' ');
            int j = 0;
            for (int i = 0; i < txt.Length; i++)
            {
                if (txt[i][txt[i].Length - 1] != v)
                    j++;
            }
            string[] str = new string[j];
            j = 0;

            for (int i = 0; i < str.Length; i++)
            {
                if (txt[i][txt[i].Length - 1] != v)
                {
                    str[j] = txt[i] + " ";
                    j++;
                }
            }

            return new MessageString(str);
        }

        public static MessageString MaxBuilder(MessageString message, int n)
        {
            StringBuilder str = new StringBuilder();
            str.Append((Max(message, n)).StringTo);

            return new MessageString(str.ToString());
        }
    }
}
