using System.Security.Cryptography.X509Certificates;

namespace szelmeresek;

class Program
{
    // Struktúra a szélmérési adatok tárolására
    struct Adat
    {
        public int ido;      // A mérés időpontja
        public int erosseg;  // A szél erőssége
        public string irany; // A szél iránya
    }

    Random rnd = new Random();

    // Beolvassa az adatokat a megadott nevű fájlból és visszaadja egy listában
    static List<Adat> Olvas(string nev)
    {
        List<Adat> adatok = new List<Adat>();
        string s;                // Egy sor a fájlból
        string[] reszek;         // A sor részekre bontva
        Adat a;                 // Egy adat tárolására
        StreamReader fajl = new StreamReader(nev); // Fájl megnyitása olvasásra
        while (!fajl.EndOfStream)
        {
            s = fajl.ReadLine();           // Egy sor beolvasása
            reszek = s.Split(' ');         // Sor feldarabolása szóközöknél
            a.ido = int.Parse(reszek[0]);      // Idő konvertálása számmá
            a.erosseg = int.Parse(reszek[1]);  // Erősség konvertálása számmá
            a.irany = reszek[2];               // Irány beállítása
            adatok.Add(a);                     // Adat hozzáadása a listához
        }
        fajl.Close();                     // Fájl bezárása
        adatok.TrimExcess();              // Lista méretének optimalizálása
        return adatok;                    // Lista visszaadása
    }
    static bool Atvalt(int pk, out int ora, out int perc)
    {
        bool sikeres = false;
        ora = 0;
        perc = 0;

        if (pk >= 0)
        {
            ora = pk / 60;
            perc = pk % 60;
            sikeres = true;
        }

        return sikeres;
    }
    // Kiírja a lista tartalmát a konzolra
    static void Kiiro(List<Adat> a)
    {
        int i;
        for (i = 0; i < a.Count; i++)
        {
            Console.WriteLine(a[i].ido + " " + a[i].erosseg + " " + a[i].irany);
        }
        Console.WriteLine();  // Üres sor a végén
    }

    static void Kiirato(List<Adat> a)
    {
        int ora, perc, i;
        for (i = 0; i < a.Count; i++)
        {
            Atvalt(a[i].ido, out ora, out perc);
            Console.WriteLine(ora + ":" + perc + " " + a[i].erosseg + "km/h " + a[i].irany);
        }
        Console.WriteLine();
    }

    // A program fő része
    static void Main(string[] args)
    {
        Console.Clear();  // Képernyő törlése
        // Adatok beolvasása fájlból
        List<Adat> meresek = Olvas("meresek_lista.txt");
        // Adatok kiírása a képernyőre
        Kiiro(meresek);

        Console.WriteLine("Legnagyobb szélsebesség: " + meresek.Max(x => x.erosseg));

        // erős szél = (>30)
        Console.WriteLine("Hányszor mértek erős szelet: " + meresek.Count(x => x.erosseg > 30));

        int max = 0;
        bool van = false;
        van = meresek.Exists(x => x.irany == "É");
        if (van)
        {
            max = meresek.Where(x => x.irany == "É").Max(x => x.erosseg);
        }
        van = false;
        Console.WriteLine("Legerősebb északi szél: " + max);

        int del = meresek.IndexOf(meresek.Where(x => x.irany == "DNY").First());
        Console.WriteLine("Első délnyugati mérés helye: " + del);

        List<string> iranyok = meresek.Select(x => x.irany).Distinct().ToList();

        Kiirato(meresek);
        
        // Várakozás billentyűleütésre
        Console.ReadKey();
    }
}
