using System.Globalization;

namespace receptkonyv
{
    internal class Program
    {
        struct Recept
        {
            public int sorszam;
            public int hozzavalodb;
            public int ertek;
        }
        //1.
        struct Hozzavalo
        {
            public string nev;
            public int db;
            public double ar;
            public int rec;
        }
        //2.
        static List<Hozzavalo> Beolvas(string f)
        {
            StreamReader fajl = new StreamReader(f);
            List<Hozzavalo> a = new List<Hozzavalo>();
            string[] reszek;
            int i;
            Hozzavalo b;
            while (!fajl.EndOfStream)
            {
                b = new Hozzavalo();
                reszek = fajl.ReadLine().Split(";");
                b.nev = reszek[0];
                b.db = Convert.ToInt32(reszek[1]);
                b.ar = Double.Parse(reszek[2], NumberFormatInfo.InvariantInfo);
                //Console.WriteLine(b.ar);
                b.rec = Convert.ToInt32(reszek[3]);
                a.Add(b);
            }

            return a;
        }
        //kiirás
        static void Kiiras(List<Hozzavalo> a)
        {
            int i;
            for (i=0;i < a.Count;i++)
            {
                Console.WriteLine("{0,17} {1} {2,4} {3}", a[i].nev, a[i].db, a[i].ar, a[i].rec);
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            Console.Clear();
            Hozzavalo olcso, olcsegy;
            List<Hozzavalo> recept = Beolvas("recept.txt");
            List<Hozzavalo> rec1 = new List<Hozzavalo>();
            List<Hozzavalo> tizfol = new List<Hozzavalo>();
            List<Hozzavalo> csokkeno = new List<Hozzavalo>();
            Kiiras(recept);
            int i,recdb = 0;

            //3.
            olcso = recept.Find(x=> x.ar == recept.Min(x=> x.ar));
            Console.WriteLine("Legolcsóbb hozzávaló: {0}; ára: {1}",olcso.nev, olcso.ar);
            //4.
            olcsegy = recept.Find(x => x.ar/x.db == recept.Max(x => x.ar/x.db));
            Console.WriteLine("Legdrágább hozzávaló (egységárban): " + olcsegy.nev);
            //5.
            Console.WriteLine("Hozzávalók összértéke: {0} arany", recept.Sum(x=> x.ar));
            //6.
            rec1 = recept.FindAll(x => x.rec == 1);
            Console.WriteLine("\nRecept 1 hozzátevői:");
            Kiiras(rec1);
            Console.WriteLine("Összérték: {0} arany", rec1.Sum(x=> x.ar));
            //7.
            Console.WriteLine("Átlagos hozávaló ár: {0} arany", recept.Average(x => x.ar));
            //8.
            tizfol = recept.FindAll(x => x.ar > 10);
            Console.WriteLine("10 arany fölötti hozzávalók:");
            Kiiras(tizfol);
            //9.
            Console.WriteLine("Hozzávalók árban csökkenő sorrendben:");
            csokkeno = recept.OrderBy(x=>x.ar).ToList();
            csokkeno.Reverse();
            Kiiras(csokkeno);
            //10.
            recdb = recept.DistinctBy(x => x.rec).Count();
            Console.WriteLine("Különböző receptek száma: " + recdb);

            //11.
            int legdragabb=0;
            for (i = 0; i < recept.Max(x => x.rec); i++)
            {

            }


            Recept a;
            List<Recept> receptek = new List<Recept>();
            for (i = 0; i < recept.Max(x => x.rec); i++)
            {
                a = new Recept();
                a.sorszam = 0;
                a.hozzavalodb = 0;
                //a.ertek = Hozzavalo..Where(x => x.rec == rec.ar).Sum(x => x.ar);
                receptek.Add(a);
            }
            



            Console.ReadKey();
        }
    }
}
