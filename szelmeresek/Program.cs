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

    // A program fő része
    static void Main(string[] args)
    {
        Console.Clear();  // Képernyő törlése
        // Adatok beolvasása fájlból
        List<Adat> meresek = Olvas("meresek_lista.txt");
        // Adatok kiírása a képernyőre
        Kiiro(meresek);

        // Várakozás billentyűleütésre
        Console.ReadKey();
    }
}
