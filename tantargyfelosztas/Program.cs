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
    static void Main(string[] args)
    {
        Console.Clear();
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

        Console.WriteLine("Bejegyzések száma: " + masodikfeladat(felosztas));

        Console.WriteLine("Heti órák száma: " + hardmadikfeladat(felosztas));


        Console.ReadKey();
    }
}
