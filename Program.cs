using System;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Факториал
{
    class Program
    {
        static ulong CalculatingFactorial(int x)
        {
            ulong y = 1;

            if (x == 0)
            {
                return 1;
            }
            else
            {
                for (int i = 1; i <= x; i++)
                    y *= (ulong)i;

                return y;
            }
        }

        static int InputX()
        {
            int x;
            bool checkparse;
            do
            {
                Console.WriteLine("Введите число:");
                checkparse = int.TryParse(Console.ReadLine(), out x);
                if (!checkparse || x < 0)
                {
                    Console.WriteLine("Число должно быть целым и >=0");
                    checkparse = false;
                }
            } while (!checkparse);
            return x;
        }

        static string GetHorizontLine(ulong count, int up_down) // up=0, down=1
        {
            string num = Convert.ToString(count);
            char horizontline = '═';
            char[] corner = { '╔', '╚', '╗', '╝' };
            string line;
            line= corner[up_down] + new string(horizontline, num.Length) + corner[up_down+2];
            return line;
        }

        static string GetBox(ulong num)
        {
            string sideline = "║";
            return GetHorizontLine(num, 0) + '\n' +
                   sideline + num + sideline + '\n' +
                   GetHorizontLine(num, 1)
                   +'\n' + '\n' + "Press any key to exit";
        }

        static ConsoleColor GetColor(bool step)
        {
            if (step) return ConsoleColor.Blue;
            else return ConsoleColor.White;
        }

        static void PrintingColoredBox(string box, int sleep, bool step)
        {
                Console.BackgroundColor = GetColor(step);
                Console.ForegroundColor = GetColor(!step);
                Console.Clear();
                Console.Write(box);
                Thread.Sleep(sleep);
        }

        static void Main()
        {
            ulong y = CalculatingFactorial(InputX());
            Console.Clear();
            string box = GetBox(y);
            int sleeptime = 160; //константа для времени задержки
            for( ; ; )
            {
                PrintingColoredBox(box, sleeptime, true);
                PrintingColoredBox(box, sleeptime, false);
                if (Console.KeyAvailable) break;
            }
        }
    }
}
