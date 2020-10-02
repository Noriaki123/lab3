using System;

namespace lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("Это программа для функции y=x*x-7x+10");
                Console.WriteLine("Введите шаг построения");
                double step = GetValCorrect();
                Console.WriteLine("Введите минимальное значение X");
                double MinX = GetValCorrect();
                Console.WriteLine("Введите максимальное значение X");
                double MaxX = GetValCorrect();
                if (MaxX > MinX)
                {
                    DrawTable(step, MinX, MaxX);
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Минимальное значение не должно быть больше или равно максимального");
                }
            }while(true);
        }

        static double GetY(Double x)
        {
            return x * x - 7 * x + 10;
        }

        static int GetMaxSize(double step, double MinX, double MaxX)
        {
            int size = 0;
            for (double i = MinX; i <= MaxX; i += step)
            {
                string x = i.ToString();
                string y = GetY(i).ToString();
                if (x.Length > size)
                {
                    size = x.Length;
                }
                else if (y.Length > size)
                {
                    size = y.Length;
                }
            }
            return size;
        }

        static void DrawTable(double step, double MinX, double MaxX)
        {
            int max = GetMaxSize(step, MinX, MaxX);
            DrawHead(max);
            DrawBody(max, step, MinX, MaxX);
        }

        static void DrawSymbol(int num, char symbol)
        {
            for (int i = 0; i < num; i++)
            {
                Console.Write(symbol);
            }
        }

        static void DrawHead(int max)
        {
            Console.Write("|");
            DrawSymbol(max - 1, ' ');
            Console.Write("Y");
            Console.Write(" |");
            DrawSymbol(max - 1, ' ');
            Console.Write("X");
            Console.Write(" |");
            Console.WriteLine();
            DrawSymbol(max * 2 + 5, '-');
            Console.WriteLine();
        }

        static void DrawBody(int max, double step, double MinX, double MaxX)
        {
            for (double i = MinX; i <= MaxX; i += step)
            {
                Console.Write("|");
                DrawSymbol(max - GetY(i).ToString().Length, ' ');
                Console.Write(GetY(i));
                Console.Write(" |");
                DrawSymbol(max - i.ToString().Length, ' ');
                Console.Write(i);
                Console.Write(" |");
                Console.WriteLine();
            }
        }
        static double GetValCorrect()
        {
            bool check = true;
            double y;
            string x;
            do
            {
                x = Console.ReadLine();
                Console.Clear();
                if (Double.TryParse(x, out y))
                {
                    check = false;
                }
                else
                {
                    Console.WriteLine("Вы ввели неверное значение, попробуйте ещё раз");
                }
            } while (check);
            return y;
        }
    }
}
