namespace fuggvenyek;

class Program
{
    public static Random? rnd;
    static void Csillag(int x0, int y0, int tipus)
    {
        int a;
        rnd = new Random();

        a = rnd.Next(0, 3);

        switch (a)
        {
            case 0:
                Console.ForegroundColor = ConsoleColor.White;
                break;
            case 1:
                Console.ForegroundColor = ConsoleColor.Yellow;
                break;
            case 2:
                Console.ForegroundColor = ConsoleColor.Red;
                break;
        }

        Console.CursorLeft = x0;
        Console.CursorTop = y0;
        if (tipus == 1)
        {
            Console.Write("*");

        }
        else
        {
            Console.Write(".");
        }
    }
    static void Main(string[] args)
    {
        rnd = new Random();
        int i, x, y;

        Console.CursorVisible = false;
        Console.Clear();

        for (i = 0; i < 50; i++)
        {
            x = rnd.Next(0, 100);
            y = rnd.Next(0, 30);
            Csillag(x, y, rnd.Next(0, 2));
        }


        Csillag(5, 12, 0);
        Csillag(18, 11, 1);
        Csillag(7, 1, 0);




        Console.ReadKey();
        Console.ResetColor();
        Console.CursorVisible = true;
    }
}

