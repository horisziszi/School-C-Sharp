using System.Globalization;

namespace Recept
{
    internal class Program
    {
        // A hozzávalót leíró struktúra
        struct Hozzavalo
        {
            public string Nev;        // hozzávaló neve
            public int Mennyiseg;     // mennyiség (egység itt egész számként)
            public double AranyAr;    // ára (aranyban, lebegőpontos)
            public int ReceptSzam;    // melyik recepthez tartozik (azonosító)
        }

        // Beolvas: fájl sorait feldolgozza és visszaad egy listát Hozzavalo objektumokkal
        static List<Hozzavalo> Beolvas(string path)
        {
            StreamReader reader = new StreamReader(path); // fájl megnyitása olvasásra
            List<Hozzavalo> list = new List<Hozzavalo>();
            Hozzavalo a;
            string sor;
            string[] reszek;
            while (!reader.EndOfStream) // amíg van sor a fájlban
            {
                sor = reader.ReadLine();                 // sor beolvasása
                reszek = sor.Split(";");                 // mezők ; mentén szétválasztva
                a.Nev = reszek[0];                       // 0. mező: név
                a.Mennyiseg = Convert.ToInt32(reszek[1]); // 1. mező: mennyiség (int)
                a.AranyAr = double.Parse(reszek[2], NumberFormatInfo.InvariantInfo); // 2. mező: ár (double)
                a.ReceptSzam = Convert.ToInt32(reszek[3]); // 3. mező: recept száma (int)
                list.Add(a);                              // hozzáadás a listához
            }
            reader.Close(); // fájl lezárása (jobb lenne using blokkot használni)
            return list;    // visszaadjuk a feltöltött listát
        }

        static void Main(string[] args)
        {
            List<Hozzavalo> list = new List<Hozzavalo>();
            list = Beolvas("recept.txt"); // beolvassuk a recept.txt fájlt a listába
            int a;      // deklarált, de nincs használva a jelenlegi kódban
            double m;   // próbálja a minimum ár indexét vagy értékét tárolni (hibás használat)
            string s;   // név tárolására, de nincs inicializálva a kódban -> hibás

            //2.
            // Következő sorok hibásak:
            // - list.IndexOf(list.Min(x => x.AranyAr)): IndexOf egy objektumot vár, de list.Min visszaad egy double értéket.
            // - m változó típusa double, de IndexOf int-et adna vissza (ha működne).
            // - s nincs beállítva mielőtt kiírnánk a nevét.
            m = list.IndexOf(list.Min(x => x.AranyAr));
            Console.WriteLine("A {0} hozzávaló a legolcsóbb {1} aranyba kerül.", s, list.Min(x=> x.AranyAr));
        }
    }
}