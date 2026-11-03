using System;

namespace szamla;

struct Hivas
{
    // Kezdés
    public int kora;
    public int kperc;
    public int kmp;

    // Vége
    public int vora;
    public int vperc;
    public int vmp;

    // Kiszámlázandó hívás hossza, megkezdett percekben
    public int hossza;
    public string telefonszam;
}


class Program
    {
        static bool MobilHivas(Hivas hivas)
        {
            string korzet = hivas.telefonszam.Substring(0, 2);
            string[] mobilkorzetszamok = { "39", "41", "71" };

            return Array.Exists(mobilkorzetszamok, element => element == korzet);
        }
        static int HivasHossza(Hivas hivas)
        {
            int hossza = 0;

            // Ha a hívás kezdete és vége ugyanabban az órában van
            if (hivas.kora == hivas.vora)
            {
                hossza = hivas.vperc - hivas.kperc;
            }
            else
            {
                // Ha a hívás több órán keresztül tart
                hossza = (60 - hivas.kperc) + (hivas.vora - hivas.kora - 1) * 60 + hivas.vperc;
            }

            return hossza;
        }
        static void Main(string[] args)
        {
        Console.Clear();

        List<Hivas> hivasok = new List<Hivas>();
        // Csúcsidő: 7:00-18:00
        // Csúcsidőn kívül: 00:00-7:00 és 18:00-24:00

        // Vezetékes: 30 Ft/perc || 15 Ft/perc
        // Mobil: 69,175 Ft/perc || 46,675 Ft/perc

        StreamReader fajl = new StreamReader("HIVASOK.TXT");

        string[] mobilkorzetszamok = { "39", "41", "71"};
        string sor;

        while (!fajl.EndOfStream)
        {
            sor = fajl.ReadLine();
            string[] adatok = sor.Split(' ');

            hivasok.Add(new Hivas
            {
                kora = int.Parse(adatok[0]),
                kperc = int.Parse(adatok[1]),
                kmp = int.Parse(adatok[2]),
                vora = int.Parse(adatok[3]),
                vperc = int.Parse(adatok[4]),
                vmp = int.Parse(adatok[5]),

                telefonszam = fajl.ReadLine()

            });

            
        }
        fajl.Close();

        for (int i = 0; i < hivasok.Count; i++)
        {
            Hivas hivas = hivasok[i];
            hivas.hossza = HivasHossza(hivas);
            hivasok[i] = hivas;
        }



        // 1. Feladat
        Console.WriteLine("1. Feladat:");
        Console.Write("Adjon meg egy telefonszámot: ");
        string keresettSzam = Console.ReadLine();
        string korzet = keresettSzam.Substring(0, 2);

        if (Array.Exists(mobilkorzetszamok, element => element == korzet))
        {
            Console.WriteLine("A megadott szám mobil hívószám.");
        }
        else
        {
            Console.WriteLine("A megadott szám vezetékes hívószám.");
        }


        // 2. Feladat
        Console.WriteLine("\n2. Feladat:");
        Console.Write("Adjon meg egy kezdési időpontot (óra:perc:másodperc): ");
        Hivas bekert = new Hivas();
        sor = Console.ReadLine();
        string[] idopont = sor.Split(':');
        bekert.kora = int.Parse(idopont[0]);
        bekert.kperc = int.Parse(idopont[1]);
        bekert.kmp = int.Parse(idopont[2]);
        Console.Write("Adjon meg egy befejezési időpontot (óra:perc:másodperc): ");
        sor = Console.ReadLine();
        idopont = sor.Split(':');
        bekert.vora = int.Parse(idopont[0]);
        bekert.vperc = int.Parse(idopont[1]);
        bekert.vmp = int.Parse(idopont[2]);

        int hossza = HivasHossza(bekert);
        Console.WriteLine($"A hívás hossza: {hossza} perc");



        // 3. Feladat
        Console.WriteLine("\n3. Feladat:");
        StreamWriter kimenet = new StreamWriter("percek.txt");
        for (int i = 0; i < hivasok.Count; i++)
        {
            Hivas hivas = hivasok[i];
            kimenet.WriteLine(hivas.hossza + " " + hivas.telefonszam);


        }
        kimenet.Close();

        Console.WriteLine("A hívások hossza és a telefonszámok kiírásra kerültek a 'percek.txt' fájlba.");


        // 4. Feladat
        Console.WriteLine("\n4. Feladat:");
        int csucshivasok = 0;
        int nemcsucshivasok = 0;
        for (int i = 0; i < hivasok.Count; i++)
        {
            Hivas hivas = hivasok[i];
            if (hivas.kora >= 7 && hivas.kora < 18)
            {
                csucshivasok++; 
            }
            else
            {
                nemcsucshivasok++;
            }
        }
        Console.WriteLine($"A csúcsidőben indított hívások száma: {csucshivasok}");
        Console.WriteLine($"A csúcsidőn kívül indított hívások száma: {nemcsucshivasok}");


        // 5. Feladat
        Console.WriteLine("\n5. Feladat:");
        int mobilperc = 0;
        int vezetekesperc = 0;
        for (int i = 0; i < hivasok.Count; i++)
        {
            Hivas hivas = hivasok[i];
            if (MobilHivas(hivas))
            {
                mobilperc += hivas.hossza;
            }
            else
            {
                vezetekesperc += hivas.hossza;
            }
        }

        Console.WriteLine($"A mobil hívások összesen {mobilperc} percet tettek ki.");
        Console.WriteLine($"A vezetékes hívások összesen {vezetekesperc} percet tettek ki.");


        // 6. Feladat
        Console.WriteLine("\n6. Feladat:");
        double csucsar = 0;

        for (int i = 0; i < hivasok.Count; i++)
        {
            Hivas hivas = hivasok[i];
            if (hivas.kora >= 7 && hivas.kora < 18)
            {
                if (MobilHivas(hivas))
                {
                    csucsar += hivas.hossza * 69.175;
                }
                else
                {
                    csucsar += hivas.hossza * 30;
                }
            }
        }

        Console.WriteLine($"A csúcsidőben indított hívások összesen {csucsar} Ft-ba kerültek.");



    }
}
