namespace futar;

class Program
{
    struct Tavok
    {
        public int nap;
        public int fuvarindex;
        public int ut;
    }

    static int NapiFuvarSzam(List<Tavok> tavok, int nap)
    {
        int i = 0;
        int fuvarokszama = 0;
        for (i = 0; i < tavok.Count; i++)
        {
            if (tavok[i].nap == nap)
            {
                fuvarokszama++;
            }
        }

        return fuvarokszama;
    }
    static int NapiOsszesKm(List<Tavok> tavok, int nap)
    {
        int i = 0;
        int osszeskm = 0;
        for (i = 0; i < tavok.Count; i++)
        {
            if (tavok[i].nap == nap)
            {
                osszeskm += tavok[i].ut;
            }
        }

        return osszeskm;
    }
    static int TavDijazas(int tav)
    {
        int dij = 0;
        switch (tav)
        {
            case int n when (n >= 1 && n <= 2):
                dij = 500;
                break;
            case int n when (n >= 3 && n <= 5):
                dij = 700;
                break;
            case int n when (n >= 6 && n <= 10):
                dij = 900;
                break;
            case int n when (n >= 11 && n <= 20):
                dij = 1400;
                break;
            case int n when (n >= 21 && n <= 30):
                dij = 2000;
                break;
            default:
                dij = -1; // nincs tarifálás
                break;
        }
        return dij;
    }
    static void Main(string[] args)
    {
        Console.Clear();
        string sor;
        int i;

        List<Tavok> tavok = new List<Tavok>();
        StreamReader fajl = new StreamReader("tavok.txt");




        // 1. Feladat
        while (!fajl.EndOfStream)
        {
            sor = fajl.ReadLine();
            string[] db = sor.Split(' ');
            Tavok t = new Tavok();
            t.nap = Convert.ToInt32(db[0]);
            t.fuvarindex = Convert.ToInt32(db[1]);
            t.ut = Convert.ToInt32(db[2]);
            tavok.Add(t);
        }





        // 2. Feladat
        int legelsonap= 7, legelsoindex= 40, legelsout= 30;
        for (i = 0; i < tavok.Count; i++)
        {
            if (tavok[i].nap < legelsonap)
            {
                legelsonap = tavok[i].nap;
            }
        }

        for (i = 0; i < tavok.Count; i++)
        {
            if (tavok[i].nap == legelsonap && tavok[i].fuvarindex < legelsoindex)
            {
                legelsoindex = tavok[i].fuvarindex;
                legelsout = tavok[i].ut;
            }
        }

        Console.WriteLine($"2. Feladat: \nA  hét legelső útja: {legelsout} km");





        // 3. Feladat
        int utolsonap = 0, utolsoindex = 0, utolsout = 0;
        for (i = 0; i < tavok.Count; i++)
        {
            if (tavok[i].nap > utolsonap)
            {
                utolsonap = tavok[i].nap;
            }
        }

        for (i = 0; i < tavok.Count; i++)
        {
            if (tavok[i].nap == utolsonap && tavok[i].fuvarindex > utolsoindex)
            {
                utolsoindex = tavok[i].fuvarindex;
                utolsout = tavok[i].ut;
            }
        }
        Console.WriteLine($"3. Feladat: \nA hét utolsó útja: {utolsout} km");




        // 4. Feladat
        int[] napok = new int[7];
        napok = tavok.Select(t => t.nap).Distinct().ToArray();

        int[] szabadnapok = new int[7];

        szabadnapok = Enumerable.Range(1, 7).Except(napok).ToArray();

        Console.WriteLine("4. Feladat: \nA futár szabadnapjai:");
        for (i = 0; i < szabadnapok.Length; i++)
        {
            Console.Write(szabadnapok[i]+" ");
        }




        // 5. Feladat
        int[] napszamok = new int[7];
        for (i = 0; i < 7; i++)
        {
            napszamok[i] = NapiFuvarSzam(tavok, i + 1);
        }

        int maxindex = Array.IndexOf(napszamok, napszamok.Max());
        Console.WriteLine($"\n5. Feladat: \nA legtöbb fuvar a {maxindex + 1}. napon volt, összesen {napszamok[maxindex]} fuvar.");




        // 6. Feladat
        int[] napkm = new int[7];
        for (i = 0; i < 7; i++)
        {
            napkm[i] = NapiOsszesKm(tavok, i + 1);
        }
        Console.WriteLine("6. Feladat: \nA megtett út kilométerben naponta:");

        for (i = 0; i < 7; i++)
        {
            Console.WriteLine($"{i + 1}. nap: {napkm[i]} km");
        }


        // 7. Feladat
        // 1 - 2 km = 500 Ft
        // 3 - 5 km = 700 Ft
        // 6 - 10 km = 900 Ft
        // 11 - 20 km = 1400 Ft
        // 21 - 30 km = 2000 Ft

        Console.Write("7. Feladat: \nAdjon meg egy tetszőleges távolságot (km): ");
        int tav = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine($"A távolság díjazása: {TavDijazas(tav)} Ft");



        // 8. Feladat
        StreamWriter ki = new StreamWriter("dijazas.txt");




        Console.ReadKey();

    }
}
