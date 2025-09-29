namespace aranyerme;

class Program
{
    static Random rnd = new Random();
    static List<int> Ermek()
    {
        List<int> e = new List<int>();
        int i, hossz, a;
        hossz = rnd.Next(1,40);
        for (i = 0; i < hossz; i++)
        {
            a = rnd.Next(1, 100);
            e.Add(a);
        }

        return e;
    }
    static void Kiir(List<int> e, bool vizszintes = true)
    {
        int i;
        for (i = 0; i < e.Count; i++)
        {
            if (vizszintes)
            {
                Console.Write(e[i] + " ");
            }
            else
            {
                Console.WriteLine(e[i]);
            }
        }
        if (vizszintes)
        {
            Console.WriteLine();
        }

    }
    static void Main(string[] args)
    {
        Console.Clear();
        int Index;
        rnd = new Random();
        List<int> ermek = Ermek();
        List<int> egyedi = ermek.Distinct().ToList();
        Kiir(ermek);
        Console.WriteLine("Az érmék száma: " + ermek.Count);
        Console.WriteLine("A legnagyobb érme: " + ermek.Max());

        for (int i = 0; i < 3; i++)
        {
            Index = rnd.Next(0, ermek.Count);
            ermek.Insert(Index, 22);
        }
        Kiir(ermek);

        Console.WriteLine("Érmefajták száma: " + egyedi.Count);

        egyedi.Sort();
        egyedi.Reverse();
        Kiir(egyedi, false);
        


    }
}

