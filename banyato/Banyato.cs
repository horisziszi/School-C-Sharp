namespace banyato;

class Banyato
{
    class Koordinatak
    {
        public int sor;
        public int oszlop;
    }
    static void Main(string[] args)
    {
        Console.Clear();
        int[,] meres; // dm
        int sorok, oszlopok, i, j;
        string sor;
        string[] reszek;


        // 1. Feladat
        StreamReader fajl = new StreamReader("melyseg.txt");
        sorok = Convert.ToInt32(fajl.ReadLine());
        oszlopok = Convert.ToInt32(fajl.ReadLine());

        meres = new int[sorok, oszlopok];

        for (i = 0; i < sorok; i++)
        {
            sor = fajl.ReadLine();
            reszek = sor.Split(' ');
            for (j = 0; j < oszlopok && j < reszek.Length; j++)
            {
                meres[i, j] = Convert.ToInt32(reszek[j]);
            }
        }



        // 2. Feladat
        Console.Write("\n2. Feladat:\n Kérem egy 'sor oszlop' párosát (pl. 3 4): ");
        sor = Console.ReadLine();
        reszek = sor.Split(' ');
        int s, o;
        s = Convert.ToInt32(reszek[0]);
        o = Convert.ToInt32(reszek[1]);
        if (s < 1 || s > sorok || o < 1 || o > oszlopok)
        {
            Console.WriteLine("\nHibás koordináták!");
        }
        else
        {
            Console.WriteLine($"\nA megadott helyen a vízmélység: {meres[s - 1, o - 1]} dm");
        }


        // 3. Feladat
        int felszin = 0;
        double atlag = 0;
        for (i = 0; i < sorok; i++)
        {
            for (j = 0; j < oszlopok; j++)
            {
                if (meres[i,j] !=0 )
                {
                    felszin++;
                    atlag += meres[i, j];
                }
                
            }
        }
        atlag /= (felszin*10); // m2-re váltás
        Console.WriteLine($"\n3. Feladat:\n A tó felszíne: {felszin} m2, az átlagos vízmélység: {atlag:F2} dm");


        // 4. Feladat
        int melyseg = 0;
        
        List<Koordinatak> lkoordinatak = new List<Koordinatak>();
        for (i = 0; i < sorok; i++)
        {
            for (j = 0; j < oszlopok; j++)
            {
                if (meres[i, j] > melyseg)
                {
                    melyseg = meres[i, j];
                    lkoordinatak.Clear();
                    lkoordinatak.Add(new Koordinatak { sor = i + 1, oszlop = j + 1 });
                }
                else if (meres[i, j] == melyseg)
                {
                    lkoordinatak.Add(new Koordinatak { sor = i + 1, oszlop = j + 1 });
                }
            }
        }
        Console.WriteLine($"\n4. Feladat:\n A tó legnagyobb mélysége: {melyseg} dm, a helye(i):");
        for (i = 0; i < lkoordinatak.Count; i++)
        {
            Console.Write($"({lkoordinatak[i].sor}; {lkoordinatak[i].oszlop}) ");
        }
        


        // 5. Feladat
        int partvonal = 0;
        for (i = 0; i < sorok; i++)
        {
            for (j = 1; j < oszlopok; j++)
            {
                if (meres[i, j-1] == 0 && meres[i, j] > 0 || meres[i, j-1] > 0 && meres[i, j] == 0)
                {
                    partvonal++;
                }
            }
        }
        for (j = 0; j < oszlopok; j++)
        {
            for (i = 1; i < sorok; i++)
            {
                if (meres[i-1, j] == 0 && meres[i, j] > 0 || meres[i-1, j] > 0 && meres[i, j] == 0)
                {
                    partvonal++;
                }
            }
        }
        Console.WriteLine($"\n5. Feladat:\n A tó partvonala: {partvonal} m hosszú");

        // 6. Feladat





        Console.ReadKey();
    }
}
