using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lesson_7
{
    class Udvoitel
    {
        public List<int> LastStep = new List<int>();
        int answer, userAnswer, step = 0, stepMin, answerCount = 0;

        public int Answer { get => answer ;}
        public int UserAnswer { get => userAnswer; }
        public int Step { get => step; }
        public int StepMin { get => stepMin; }
        public int AnswerCount { get => answerCount; }
        
        /// <summary>
        /// Конструктор нового экземпляра класса Udvoitel
        /// </summary>
        /// <param name="answer">Псевдослучайное число из диапазона 1...100</param>
        public Udvoitel (int answer)
        {
            this.answer = answer;
            userAnswer = 1;
            answerCount = 0;
            int temp = answer;
            while (temp!=1)
            {
                if (temp%2 == 0)
                {
                    temp /= 2;
                    stepMin++;
                }
                else if (temp%2 > 0)
                {
                    temp -= 1;
                    stepMin++;
                }
            }
        }
        /// <summary>
        /// Новая игра в случае, если игрок выиграл или проиграл. Обнуление всех счетчиков
        /// </summary>
        public void NewGame()
        {
            answer = new Random().Next(1, 101);
            userAnswer = 1;
            step = 0;
            stepMin = 0;
            int temp = answer;
            while (temp != 1)
            {
                if (temp % 2 == 0)
                {
                    temp /= 2;
                    stepMin++;
                }
                else if (temp % 2 > 0)
                {
                    temp -= 1;
                    stepMin++;
                }
            }
            for (int i = LastStep.Count-1; i >= 0; i--)
            {
                LastStep.RemoveAt(i);
            }
        }
        /// <summary>
        /// Прибавление единици к ответу пользователя при нажатии соответствующей клавиши
        /// </summary>
        public void Plus()
        {
            userAnswer += 1;
            step++;
            LastStep.Add(0);
        }
        /// <summary>
        /// Умножение на 2 ответа пользоваталя при нажатии соответствующей клавиши
        /// </summary>
        public void Multi()
        {
            userAnswer *= 2;
            step++;
            LastStep.Add(1);
        }
        /// <summary>
        /// Начать заново составлять уже загаданное число (количество совершенных шагов сбрасываетя)
        /// </summary>
        public void Reset()
        {
            userAnswer = 1;
            step = 0;
        }
        /// <summary>
        /// Проверка соответствия ответа игрока загаданному числу после каждого нажатия клавиши умножения и прибавления
        /// </summary>
        /// <returns></returns>
        public bool IsHit()
        {
            if (userAnswer == answer)
            {
                answerCount++;
                MessageBox.Show("Игра закончена!\nВы победили!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }

            else if (userAnswer > answer || step == stepMin)
            {
                MessageBox.Show("Игра закончена!\nВы проиграли!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }

            else return false;
        }
        /// <summary>
        /// Отмена последних шагов (пока есть, что отменять)
        /// </summary>
        public void Back()
        {
            if (LastStep.Count == 0) MessageBox.Show("Нет ходов для отмены", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (LastStep.Last() == 0)
            {
                userAnswer -= 1;
                LastStep.RemoveAt(LastStep.Count - 1);
                step -= 1;
            }

            else if (LastStep.Last() == 1)
            {
                userAnswer /= 2;
                LastStep.RemoveAt(LastStep.Count - 1);
                step -= 1;
            }
        }
    }
}
