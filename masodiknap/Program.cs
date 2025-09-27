using System;
using System.Collections.Generic;

namespace Iskola
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            int[,] labirintus = new int[5, 5];
            Random rnd = new Random();
            int i, j;
            int x0,y0,x,y;
            x0 = 0; y0 = 0; // Kezdőpozíció
            x = x0; y = y0; // Aktuális pozíció


            bool vege = false;
            ConsoleKeyInfo bill, regi;




            for (i = 0; i < labirintus.GetLength(0); i++)
            {
                for (j = 0; j < labirintus.GetLength(1); j++)
                {
                    if (rnd.Next(101) > 60) // 40% esély a szabad útra
                    {
                        labirintus[i, j] = 0; // Szabad út
                    }
                    else
                    {
                        labirintus[i, j] = 1; // Fal
                    }
                }
            }

            labirintus[0, 0] = 0; // Kezdőpont
            labirintus[labirintus.GetLength(0) - 1, labirintus.GetLength(1) - 1] = 0; // Cél

            Console.CursorLeft = 0;
            Console.CursorTop = 4;

            for (i = 0; i < labirintus.GetLength(0); i++)
            {
                for (j = 0; j < labirintus.GetLength(1); j++)
                {
                    Console.Write(labirintus[i, j] + " ");
                }
                Console.WriteLine();
            }

            Console.CursorLeft = 0;
            Console.CursorTop = 0;

            Console.Write("X ");
            while (!vege)
            {
                bill = Console.ReadKey(true);
                switch (bill.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (y0 > 0 && labirintus[x, y - 1] == 0) y = y0 - 1;
                        break;
                    case ConsoleKey.DownArrow:
                        if (y < labirintus.GetLength(1) - 1 && labirintus[x, y + 1] == 0) y = y0 + 1;
                        break;
                    case ConsoleKey.LeftArrow:
                        if (x > 0 && labirintus[x - 1, y] == 0) x = x0 - 1;
                        break;
                    case ConsoleKey.RightArrow:
                        if (x < labirintus.GetLength(0) - 1 && labirintus[x + 1, y] == 0) x = x0 + 1;
                        break;
                    case ConsoleKey.Escape:
                        vege = true;
                        break;
                }

                Console.CursorLeft = x0 * 2;
                Console.CursorTop = (y0)+4;
                Console.Write("0 ");
                Console.CursorLeft = x * 2;
                Console.Write("X ");
                Console.CursorTop = (y)+4;
                x0 = x; y0 = y;
                regi = bill;

                if (x0 == labirintus.GetLength(0) - 1 && y0 == labirintus.GetLength(1) - 1)
                {
                    Console.CursorLeft = 0;
                    Console.CursorTop = labirintus.GetLength(0) + 1;
                    Console.WriteLine("Gratulálok, nyertél!");
                    vege = true;
                }
            }




        }
    }
}
