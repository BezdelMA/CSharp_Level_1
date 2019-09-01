using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Игра "Верю-Не верю". Все работает исправно, только мало вопросов нашел в Интернете (особо и не искал)

namespace MiniGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Игра 'Верю-Не верю'. Вам предложено ответить на 5 вопросов 'да' или 'нет'.\nВ конце будут подсчитаны очки.");
            Game game = new Game
            {
                Questions = Game.LoadFile(1),
                Answer = Game.LoadFile(2)
            };
            game.Start();

            Console.ReadKey();
        }
    }
}
