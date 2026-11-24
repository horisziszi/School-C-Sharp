using System.Security.Cryptography.X509Certificates;

namespace otszaz;

class Program
{
    class Vasarlas
    {
        public int sorszam;
        public string termek;
    }
    static int ertek(int darabszam)
    {
        switch (darabszam)
        {
            case 0:
                return 0;
            case 1:
                return 500;
            case 2:
                return 950;
            case 3:
                return 1350;
            case >= 4:
                return 1350 + (darabszam - 3) * 400;
        }

        
        return -1;
    }
    static void Main(string[] args)
    {
        Console.Clear();
        List<Vasarlas> vasarlasok = new List<Vasarlas>();
        int sorszam = 1;

        // 1. feladat
        StreamReader fajl = new StreamReader("penztar.txt");
        while (!fajl.EndOfStream)
        {
            string sor = fajl.ReadLine();
            if (sor == "F")
            {
                sorszam++;
            }
            else 
            {
                Vasarlas v = new Vasarlas();
                v.sorszam = sorszam;
                v.termek = sor;
                vasarlasok.Add(v);
            }
        }
        fajl.Close();

        // 2. feladat
        Console.WriteLine($"2. feladat\nFizetések száma: {vasarlasok.Select(x => x.sorszam).Distinct().Count()}");

        // 3. feladat
        Console.WriteLine($"3. feladat\nAz első vásárló {vasarlasok.Count(x => x.sorszam == 0)} darab terméket vásárolt.");

        // 4. feladat
        Console.WriteLine("4. feladat\nAdja meg egy vásárlás sorszámát!  ");
        int bekertSorszam = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Adja meg egy árucikk nevét!  ");
        string bekertTermek = Console.ReadLine();
        Console.WriteLine("Adja meg a vásárolt darabszámot!  ");
        int darabszam = Convert.ToInt32(Console.ReadLine());

        // 5. feladat
        Console.WriteLine($"5. feladat\nAz első vásárlás sorszáma: {vasarlasok.Where(x => x.termek == bekertTermek).Select(x => x.sorszam).FirstOrDefault()}");
        Console.WriteLine($"Az utolsó vásárlás sorszáma: {vasarlasok.Where(x => x.termek == bekertTermek).Select(x => x.sorszam).LastOrDefault()}");
        Console.WriteLine($"{vasarlasok.Where(x => x.termek == bekertTermek).Count()} vásárlás során vettek belőle.");



        // 6. feladat
        Console.WriteLine($"6. feladat\n{darabszam} darab vételekor fizetendő: {ertek(darabszam)}");

        // 7. feladat

        Console.WriteLine($"7. feladat");
        


        Console.ReadKey();
    }
}
