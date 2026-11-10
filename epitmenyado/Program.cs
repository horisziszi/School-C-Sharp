namespace epitmenyado;

class Program
{
    class Adat
    {
        public string azonosito;
        public string utcanev;
        public string hazszam;
        public char adosav;
        
        public int alapterulet;
        public int adofizetendo;
    }

    static int ado(char adosav, int alapterulet, int[] savok)
    {
        int ado = 0;
        if (adosav == 'A')
        {
            ado = alapterulet * savok[0];
        }
        else if (adosav == 'B')
        {
            ado = alapterulet * savok[1];
        }
        else if (adosav == 'C')
        {
            ado = alapterulet * savok[2];
        }

        return ado;
    }
    
    static void Main(string[] args)
    {
        Console.Clear();
        // A adózási sáv < 300m
        // B adózási sáv 300-600m
        // C adózási sáv > 600m
        // 10 000 Ft alatt nem kell adót fizetni

        // 1. Feladat
        StreamReader fajl = new StreamReader("utca.txt");
        string sor = fajl.ReadLine();
        string[] reszek = sor.Split(' ');
        int a=0, b=1, c=2;
        int[] savok = new int[3];
        savok[a]= int.Parse(reszek[0]);
        savok[b] = int.Parse(reszek[1]);
        savok[c] = int.Parse(reszek[2]);

        List<Adat> adatok = new List<Adat>();
        while (!fajl.EndOfStream)
        {
            sor = fajl.ReadLine();
            reszek = sor.Split(' ');
            Adat adatsor = new Adat();
            adatsor.azonosito = reszek[0];
            adatsor.utcanev = reszek[1];
            adatsor.hazszam = reszek[2];
            adatsor.adosav = char.ToUpper(char.Parse(reszek[3]));
            adatsor.alapterulet = int.Parse(reszek[4]);
            adatok.Add(adatsor);
        }
        fajl.Close();

        // 2. Feladat
        Console.WriteLine($"2. feladat. A mintában {adatok.Count} telek szerepel.");

        // 3. Feladat
        Console.WriteLine("3. Feladat. Egy tulajdonos adószáma: ");
        string keresettAzonosito = Console.ReadLine();
        int talalat = 0;
        for (int i = 0; i< adatok.Count; i++)
        {
            if (adatok[i].azonosito == keresettAzonosito)
            {
                Console.WriteLine($"{adatok[i].utcanev} utca {adatok[i].hazszam}");
                
            }
        }
        if (talalat == 0)
        {
            Console.WriteLine("Nem szerepel az adatállományban.");
        }

        // 5. Feladat
        Console.WriteLine("5. feladat");
        int[] savosszeg = new int[3];
        int[] savdarab = new int[3] ;
        
            
        for (int j = 0; j < adatok.Count; j++)
        {
            if (adatok[j].adosav == 'A')
            {
                savosszeg[a] += ado(adatok[j].adosav,adatok[j].alapterulet, savok);
                savdarab[a]++;
            }
            else if (adatok[j].adosav == 'B')
            {
                savosszeg[b] += ado(adatok[j].adosav,adatok[j].alapterulet, savok);
                savdarab[b]++;
            }
            else if (adatok[j].adosav == 'C')
            {
                savosszeg[c] += ado(adatok[j].adosav,adatok[j].alapterulet, savok);
                savdarab[c]++;
            }
                
        }
        
        for (int i = 0; i< savok.Length; i++)
        {
            Console.WriteLine($"A {i+1}. adósávba {savdarab[i]} telek esik, az adó {savosszeg[i]} Ft.");
        }


        // 6. feladat
        Console.WriteLine("6. feladat. A több sávba sorolt utcák: ");
        List<string> tobbsavosutcanev = new List<string>();
        for (int i =0; i< adatok.Count; i++)
        {
            for (int j = i+1; j< adatok.Count; j++)
            {
                if (adatok[i].utcanev == adatok[j].utcanev && adatok[i].adosav != adatok[j].adosav)
                {
                    tobbsavosutcanev.Add(adatok[i].utcanev);
                    
                }
            }
        }

        List<string> tobbsavosutcanev2 = tobbsavosutcanev.Distinct().ToList();

        for (int i = 0; i< tobbsavosutcanev2.Count; i++)
        {
            Console.WriteLine(tobbsavosutcanev2[i]);
        }




        // 7. feladat
        StreamWriter ki = new StreamWriter("fizetendo.txt");
        List<Adat> rendezett = adatok.OrderBy(x => x.azonosito).ToList();
        for (int i = 1; i< adatok.Count; i++)
        {
            List<int> fizetendo = new List<int>();
            for (int j = 0; j< adatok.Count; j++)
            {
                if (rendezett[i].azonosito == rendezett[j].azonosito)
                {
                    fizetendo.Add(ado(rendezett[j].adosav, rendezett[j].alapterulet, savok));
                }
            }
            int fizetendoosszeg = fizetendo.Sum();
            if (fizetendoosszeg > 10000)
            {
                ki.WriteLine($"{rendezett[i].azonosito} {fizetendoosszeg}");
            }
            else
            {
                ki.WriteLine($"{rendezett[i].azonosito} 0");
            }

        }
        ki.Close();










        Console.ReadKey();
    }
}
