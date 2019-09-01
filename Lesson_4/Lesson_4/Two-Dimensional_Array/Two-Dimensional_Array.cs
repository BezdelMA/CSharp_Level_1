using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Two_Dimensional_Array
{
    class Two_Array
    {
        static int[,] mass;


        public int[,] Mass { get => mass; set => mass = value; }

        public int Length
        {
            get
            {
                return mass.Length;
            }
        }

        public int Min
        {
            get
            {
                int min = mass[0, 0];
                for (int i = 0; i < mass.GetLength(0); i++)
                {
                    for (int j = 0; j < mass.GetLength(1); j++)
                    {
                        if (mass[i, j] < min)
                            min = mass[i, j];
                    }
                }
                return min;
            }
        }

        public int Max
        {
            get
            {
                int max = mass[0, 0];
                for (int i = 0; i < mass.GetLength(0); i++)
                {
                    for (int j = 0; j < mass.GetLength(1); j++)
                    {
                        if (mass[i, j] > max)
                            max = mass[i, j];
                    }
                }
                return max;
            }
        }

        public static int Sum()
        {
            int sum = 0;
            for (int i = 0; i < mass.GetLength(0); i ++)
            {
                for (int j = 0; j < mass.GetLength(1); j++)
                    sum += mass[i, j];
            }
            return sum;
        }

        public static int Sum(int min)
        {
            int sum = 0;
            for (int i = 0; i < mass.GetLength(0); i++)
            {
                for (int j = 0; j < mass.GetLength(1); j++)
                {
                    if (mass[i, j] > min)
                        sum += mass[i, j];
                }
            }
            return sum;
        }

        public string Print
        {
            get
            {
                string str = "";
                for (int i = 0; i < mass.GetLength(0); i++)
                {
                    for (int j = 0; j < mass.GetLength(1); j++)
                        str += mass[i, j] + "; ";
                    str += "\n";
                }
                return str;
            }
        }

        public Two_Array()
        {

        }

        public Two_Array (int max_x, int max_y)
        {
            mass = new int[max_x, max_y];
            Random rnd = new Random();
            for (int i = 0; i < max_x; i ++)
            {
                for (int j = 0; j < max_y; j++)
                    mass[i, j] = rnd.Next(0, 100);
            }
        }
    }
}
