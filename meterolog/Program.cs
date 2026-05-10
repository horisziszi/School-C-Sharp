namespace meterolog;

class Program
{
    public class Jelentes
    {
        public string telepules;
        public string ido;
        public int ora;
        public int perc;
        public string szelirany;
        public int szelerosseg;
        public int homerseklet;
    }
    static void Main(string[] args)
    {
        Console.Clear();
        

        // 1. feladat: Adatok beolvasása
        Console.WriteLine("1. feladat");
        List<Jelentes> jelentesek = new List<Jelentes>();
        

        StreamReader fajl = new StreamReader("tavirathu13.txt");
        
        do
        {
            Jelentes adatsor = new Jelentes();
            string sor = fajl.ReadLine();
            adatsor.telepules = sor.Substring(0,2);
            adatsor.ido = sor.Substring(3,4);
            adatsor.ora = int.Parse(sor.Substring(3,2));
            adatsor.perc = int.Parse(sor.Substring(5,2));
            adatsor.szelirany = sor.Substring(8,3);
            adatsor.szelerosseg = int.Parse(sor.Substring(11,2));
            adatsor.homerseklet = int.Parse(sor.Substring(14,2));

            jelentesek.Add(adatsor);

        } while (!fajl.EndOfStream);
        fajl.Close();

        Console.WriteLine("1. feladat kész ✅");

        // Debug line
        // Console.WriteLine((jelentesek[1].telepules + " " + jelentesek[1].ido + " " + jelentesek[1].ora + ":" + jelentesek[1].perc + " " + jelentesek[1].szelirany + " " + jelentesek[1].szelerosseg + " " + jelentesek[1].homerseklet));

        // 2. feladat: adott városból ékrező utolsó jelentés
        Console.WriteLine("\n2. feladat");
        Console.Write("Adja meg a város rövid nevét: ");
        char[] varosbetu = Console.ReadLine().ToCharArray();
        for (int i = 0; i < varosbetu.Length; i++)
        {
            varosbetu[i] = char.ToUpper(varosbetu[i]);
        }
        string varos = new string(varosbetu);
        for (int i = jelentesek.Count - 1; i >= 0; i--)
        {
            if (jelentesek[i].telepules == varos)
            {
                Console.WriteLine($"Az utolsó jelentés a {varos} városból: {jelentesek[i].ora}:{jelentesek[i].ido.Substring(2,2)}");
                break;
            }
        }

        // 3. feladat: legalacsonyabb és lagmagasabb hőmérséklet
        Console.WriteLine("\n3. feladat");
        int minhom = jelentesek[0].homerseklet;
        int maxhom = jelentesek[0].homerseklet;

        for (int i = 1; i < jelentesek.Count; i++)
        {
            if (jelentesek[i].homerseklet < minhom)
            {
                minhom = jelentesek[i].homerseklet;
            }
            if (jelentesek[i].homerseklet > maxhom)
            {
                maxhom = jelentesek[i].homerseklet;
            }
        }
        Console.WriteLine($"A legalacsonyabb hőmérséklet: {minhom}°C");
        Console.WriteLine($"A legmagasabb hőmérséklet: {maxhom}°C");

        // 4. feladat: szélcsend
        Console.WriteLine("\n4. feladat");
        List<int> szelcsnedindex = new List<int>();
        for (int i = 0; i < jelentesek.Count; i++)
        {
            if (jelentesek[i].szelerosseg == 0 && jelentesek[i].szelirany == "000")
            {
                szelcsnedindex.Add(i);
            }
        }
        if (szelcsnedindex.Count == 0)
        {
            Console.WriteLine("Nem volt szélcsend a mérések során.");
        }
        else
        {
            Console.WriteLine("Szélcsend volt a következő időpontokban:");
            for (int i = 0; i < szelcsnedindex.Count; i++)
            {
                int index = szelcsnedindex[i];
                Console.WriteLine($"{jelentesek[index].telepules} {jelentesek[index].ora}:{jelentesek[index].ido.Substring(2,2)}");
            }
        }


        // 5. feladat: településenként napi középhőmérséklet és hőingadozás
        Console.WriteLine("\n5. feladat");
            List<string> varosok = jelentesek.Select(x => x.telepules).Distinct().ToList();
            List<int> h1;
            List<int> h7;
            List<int> h13;
            List<int> h19;
            for (int i = 0; i < varosok.Count; i++)
            {
                int osszeg = 0, db = 0;
                maxhom = jelentesek.Where(x => x.telepules == varosok[i]).Max(x => x.homerseklet);
                minhom = jelentesek.Where(x => x.telepules == varosok[i]).Min(x => x.homerseklet);
            
                h1 = jelentesek.Where(x => x.telepules == varosok[i] && x.ido.Substring(0, 2) == "01").Select(x => x.homerseklet).ToList();
                h7 = jelentesek.Where(x => x.telepules == varosok[i] && x.ido.Substring(0, 2) == "07").Select(x => x.homerseklet).ToList();
                h13 = jelentesek.Where(x => x.telepules == varosok[i] && x.ido.Substring(0, 2) == "13").Select(x => x.homerseklet).ToList();
                h19 = jelentesek.Where(x => x.telepules == varosok[i] && x.ido.Substring(0, 2) == "19").Select(x => x.homerseklet).ToList();

                if (h1.Count > 0 && h7.Count > 0 && h13.Count > 0 && h19.Count > 0)
                {
                    db = h1.Count + h7.Count + h13.Count + h19.Count;
                    osszeg = h1.Sum() + h7.Sum() + h13.Sum() + h19.Sum();
                    osszeg = (int)Math.Round((double)osszeg / db);
                    Console.WriteLine("{0} Középhőmérséklet: {1}; Hőmérséklet - ingadozás: {2}", varosok[i], osszeg, maxhom - minhom);
                }
                else {
                    Console.WriteLine("{0} NA; Hőmérséklet - ingadozás: {1}", varosok[i], maxhom - minhom);
                }
        }


        // 6. feladat: városonként fájlt létrehozni a jelentésekből
        Console.WriteLine("\n6. feladat");
        for (int i = 0; i < varosok.Count; i++)
        {
            StreamWriter ki = new StreamWriter(varosok[i] + ".txt");
            for (int j = 0; j < jelentesek.Count; j++)
            {
                if (jelentesek[j].telepules == varosok[i])
                {
                    string szelero = new string('#',jelentesek[j].szelerosseg);
                    ki.WriteLine($"{jelentesek[j].ora}:{jelentesek[j].ido.Substring(2,2)} {szelero}");
                }
            }
            ki.Close();
        }
        Console.WriteLine("6. feladat kész ✅");

        Console.ReadKey();
    }
}
