using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ugadai
{
    class Ugadai
    {
        int answer;
        int userAnswer;
        int maxStep = 10;
        int answerCount = 0;

        public int Answer { get => answer; }
        public int UserAnswer { get => userAnswer; set => userAnswer = value; }
        public int MaxStep { get => maxStep; }
        public int AnswerCount { get => answerCount; }
        /// <summary>
        /// Проверка корректности введенных данных пользователем в TextBox
        /// </summary>
        /// <param name="text">Введенные данные</param>
        /// <returns></returns>
        internal static bool CheckAnswer(string text)
        {
            if (!Int32.TryParse(text, out int temp) || temp <= 0 || temp > 100) return false;
            return true;
        }
        
        /// <summary>
        /// Конструктор нового экземпляра класса Ugadai
        /// </summary>
        /// <param name="answer">Псевдо случайное число в диапазоне 1...100</param>
        public Ugadai (int answer)
        {
            this.answer = answer;
            maxStep = 10;
            answerCount = 0;
        }
        /// <summary>
        /// Новая игра при окончании предыдущей игры
        /// </summary>
        public void NewGame()
        {
            answer = new Random().Next(1, 101);
            maxStep = 10;
            userAnswer = 0;
        }
        /// <summary>
        /// Проверка правильности ответа при каждом нажатии кнопки
        /// </summary>
        /// <returns></returns>
        public int Check()
        {
            maxStep--;
            if (userAnswer == answer)
            {
                answerCount++;
                return 0;
            }
            else if (maxStep == 0) return 3;
            else if (userAnswer > answer) return 1;
            else if (userAnswer < answer) return 2;
            return 0;
        }
    }
}
