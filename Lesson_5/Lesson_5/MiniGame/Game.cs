using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace MiniGame
{
    class Game
    {
        string[] questions;
        string[] answer;

        public string[] Questions
        {
            set
            {
                string[] str = LoadFile(1);
                questions = str;
            }
        }

        public string[] Answer
        {
            set
            {
                string[] str = LoadFile(2);
                answer = str;
            }
        }

        public static string[] LoadFile(int n)
        {
            StreamReader sr = new StreamReader(@"answer.txt", Encoding.UTF8);
            string temp = sr.ReadLine();
            string[] str = temp.Split('|');
            string[] answer = new string[str.Length / 2];
            string[] questions = new string[str.Length / 2];
            for (int i = 0; i < str.Length - 1; i++)
            {
                if (i % 2 == 0)
                    questions[i / 2] = str[i];
                else answer[(i - 1) / 2] = str[i].ToLower();
            }
            if (n == 1) return questions;
            else return answer;
        }

        internal void Start()
        {
            Console.ForegroundColor = ConsoleColor.White;
            int score = 0;
            string userAnswer;
            Random rnd = new Random();
            for (int i = 0; i < 5; i ++)
            {
                int n = rnd.Next(0, questions.Length - 1);
                Console.WriteLine(questions[n]);
                userAnswer = Console.ReadLine();
                if (IsHit(userAnswer, n))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Верно");
                    Console.ForegroundColor = ConsoleColor.White;
                    score++;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ответ не верный");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            Console.Write("\nИгра закончена. Вы набрали {0} очков", score);
        }

        private bool IsHit(string userAnswer, int n)
        {
            return userAnswer.ToLower() == answer[n];
        }
    }
}
