namespace rgb;
class Program
{
    class Szin
    {
        public int r;
        public int g;
        public int b;

    }
    class Koordinata
    {
        public int sor;
        public int oszlop;
    }
    static Szin[,] kep = new Szin[360, 640];

    //   5. feladat
    static bool hatar(int sor, int elteres)
    {
        for (int i = 0; i<kep.GetLength(1)-1; i++)
        {
            if (Math.Abs((kep[sor, i].b)-(kep[sor, i+1].b)) > elteres)
            {
                return true;
            }
        }

        return false;
    }
    static void Main(string[] args)
    {
        Console.Clear();

        // 1. feladat
        StreamReader fajl = new StreamReader("kep.txt");

        string[] reszek;

        for (int i = 0; i<kep.GetLength(0); i++)
        {
            reszek = fajl.ReadLine().Split(" ");
            for (int j = 0; j<kep.GetLength(1); j++)
            {
                kep[i, j] = new Szin();
                kep[i, j].r = Convert.ToInt32(reszek[j * 3]);
                kep[i, j].g = Convert.ToInt32(reszek[j * 3 + 1]);
                kep[i, j].b = Convert.ToInt32(reszek[j * 3 + 2]);
            }
        }

        // 2. feladat
        Console.Write("2. feladat:\nKérem egy képpont adatait!\nSor: ");
        int sor = Convert.ToInt32(Console.ReadLine());
        Console.Write("Oszlop: ");
        int oszlop = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine($"A képpont színe: RGB({kep[sor, oszlop].r}, {kep[sor, oszlop].g}, {kep[sor, oszlop].b})");



        // 3. feladat
        const int vilagoshatar = 600;
        int vilagosok = 0;

        for (int i = 0; i<kep.GetLength(0); i++)
        {
            for (int j = 0; j<kep.GetLength(1); j++)
            {
                if (kep[i, j].r + kep[i, j].g + kep[i, j].b > vilagoshatar)
                {
                    vilagosok++;
                }
            }
        }
        Console.WriteLine($"3. feladat:\nA világos képpontok száma: {vilagosok}");


        // 4. feladat
        int minosszeg = 255 * 3;

        for (int i = 0; i<kep.GetLength(0); i++)
        {
            for (int j = 0; j<kep.GetLength(1); j++)
            {
                if (kep[i, j].r + kep[i, j].g + kep[i, j].b < minosszeg)
                {
                    minosszeg = kep[i, j].r + kep[i, j].g + kep[i, j].b;
                }
            }
        }
        List<Koordinata> legsotetebbekindex = new List<Koordinata>();
        for (int i = 0; i<kep.GetLength(0); i++)
        {
            for (int j = 0; j<kep.GetLength(1); j++)
            {
                if (kep[i, j].r + kep[i, j].g + kep[i, j].b == minosszeg)
                {
                    Koordinata koordinata = new Koordinata();
                    koordinata.sor = i;
                    koordinata.oszlop = j;
                    legsotetebbekindex.Add(koordinata);
                }
            }
        }
        Console.WriteLine("4. feladat:\nA legsötétebb képpontok színe:");
        for (int i = 0; i<legsotetebbekindex.Count; i++)
        {
            Console.WriteLine($"RGB({kep[legsotetebbekindex[i].sor, legsotetebbekindex[i].oszlop].r}, {kep[legsotetebbekindex[i].sor, legsotetebbekindex[i].oszlop].g}, {kep[legsotetebbekindex[i].sor, legsotetebbekindex[i].oszlop].b})");
        }

        // 6. feladat
        Console.WriteLine("6. feladat:");
        for (int i = 0; i<kep.GetLength(0); i++)
        {
            if (hatar(i, 10))
            {
                Console.WriteLine($"A felhő legfelső sora: {i+1}");
                break;
            }
        }
        for (int i = kep.GetLength(0)-1; i>0; i--)
        {
            if (hatar(i, 10))
            {
                Console.WriteLine($"A felhő legalsó sora: {i+1}");
                break;
            }
        }

        Console.ReadKey();
    }
}
