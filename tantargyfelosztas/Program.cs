using System.Security.Cryptography.X509Certificates;

namespace tantargyfelosztas;

class Program
{
    public struct Adatok
    {
        public string tanar;
        public string nev;
        public string osztaly;
        public int oraszam;
    }
    static int masodikfeladat(List<Adatok> felosztas)
    {
        return felosztas.Count;
    }
    static int hardmadikfeladat(List<Adatok> felosztas)
    {
        int oraosszeg = 0;
        for (int i = 0; i < felosztas.Count; i++)
        {
            oraosszeg += felosztas[i].oraszam;
        }

        return oraosszeg;
    }

    static int negyedikfeladat(List<Adatok> felosztas, string tanarnev)
    {
        int oraosszeg = 0;
        for (int i = 0; i < felosztas.Count; i++)
        {
            if (felosztas[i].tanar == tanarnev)
            {
                oraosszeg += felosztas[i].oraszam;
            }
        }

        return oraosszeg;
    }
    static void Main(string[] args)
    {
        Console.Clear();

        // 1. feladat
        StreamReader fajl = new StreamReader("beosztas.txt");
        Adatok adatok = new Adatok();
        List<Adatok> felosztas = new List<Adatok>();

        do
        {
            adatok.tanar = fajl.ReadLine();
            adatok.nev = fajl.ReadLine();
            adatok.osztaly = fajl.ReadLine();
            adatok.oraszam = int.Parse(fajl.ReadLine());
            felosztas.Add(adatok);

        }while (!fajl.EndOfStream);


        // 2. feladat
        Console.WriteLine("Bejegyzések száma: " + masodikfeladat(felosztas));
        Console.WriteLine();


        // 3. feladat
        Console.WriteLine("Heti órák száma: " + hardmadikfeladat(felosztas));
        Console.WriteLine();

        // 4. feladat
        Console.Write("Kérem a tanár nevét: ");
        Console.WriteLine("Heti órák száma: " + negyedikfeladat(felosztas, Console.ReadLine()));

        // 5. feladat
        StreamWriter ki = new StreamWriter("of.txt");
        for (int i = 0; i< felosztas.Count; i++)
        {
            if (felosztas[i].nev == "osztalyfonoki")
            {
                ki.WriteLine(felosztas[i].osztaly + " - " + felosztas[i].tanar);
            }
        }
        ki.Close();
        Console.WriteLine("Az of.txt fájl elkészült!");


        

        Console.ReadKey();
    }
}
