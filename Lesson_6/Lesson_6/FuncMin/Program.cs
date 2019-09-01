using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuncMin
{
    class Program
    {
        
        static double FuncMin_1 (double x, double a)
        {
            return a * Math.Pow(x, 2);
        }

        static double FuncMin_2 (double x, double a)
        {
            return a * Math.Sin(x);
        }

        static void SaveToFile_1(string fileName, double a, double b, double c)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            double x = a;
            while (a <= b)
            {
                bw.Write(FuncMin_1(a, b));
                a += c;
            }
            bw.Close();
            fs.Close();
        }

        static void SaveToFile_2(string fileName, double a, double b, double c)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            double x = a;
            while (a <= b)
            {
                bw.Write(FuncMin_2(a, b));
                a += c;
            }
            bw.Close();
            fs.Close();
        }
        static double OpenFromFile(string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);

            double min = double.MaxValue;
            double d;
            for (int i = 0; i <fs.Length/sizeof(double); i ++)
            {
                d = br.ReadDouble();
                if (d < min) min = d;
            }

            return min;
        }

        static void Main(string[] args)
        {
            SaveToFile_1(@"data.txt",  1, 100, 3);
            Console.WriteLine(OpenFromFile(@"data.txt"));

            SaveToFile_2(@"data2.txt", 1, 100, 3);
            Console.WriteLine(OpenFromFile(@"data2.txt"));

            Console.ReadKey();
        }
    }
}
