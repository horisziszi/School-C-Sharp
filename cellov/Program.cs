namespace cellov;

class Program
{

    static int loertek(string sor)
    {
        int aktpont = 20;
        int ertek = 0;
        for (int i = 0; i < sor.Length; i++)
        {
            if (sor[i] == '+')
            {
                ertek += aktpont;
            }
            else
            {
                if (aktpont > 0) aktpont--;
            }
        }
        return ertek;
    }
    static void Main(string[] args)
    {
        Console.Clear();

        StreamReader fajl = new StreamReader("verseny.txt");

        // versenyzők számának beolvasása
        int versenyzokSzama = int.Parse(fajl.ReadLine());

        // pontok tárolása
        List<string> pontok = new List<string>();
        
        // 1. feladat
        do
        {
            pontok.Add(fajl.ReadLine());
        } while (!fajl.EndOfStream);
        fajl.Close();


        // 2. feladat
        Console.WriteLine("2. feladat: \n");
        for (int i = 0; i < versenyzokSzama; i++)
        {
            if (pontok[i].Contains("++"))
            {
                Console.Write(i+1 + " ");
            }
        }


        // 3. feladat
        Console.WriteLine("\n\n3. feladat: \n");
        int max = 0;
        int maxindex = 0;
        for (int i = 0; i < versenyzokSzama; i++)
        {
            int pont = 0;
            for (int j = 0; j < pontok[i].Length; j++)
            {
                if (pontok[i][j] == '+')
                {
                    pont++;
                }
            }
            if (pont > max)
            {
                max = pont;
                maxindex = i;
            }
        }

        Console.WriteLine("A legtöbb lövést leadó versenyző: " + (maxindex+1) + ". versenyző, " + max + " lövéssel.");


        // 5. feladat
        Console.WriteLine("\n5. feladat: \n");
        Console.Write("Kérem egy versenyző sorszámát: ");
        int sorszam = int.Parse(Console.ReadLine());
        int talalatok = 0;
        for (int i = 0; i < pontok[sorszam - 1].Length; i++)
        {
            if (pontok[sorszam - 1][i] == '+')
            {
                talalatok++;
            }
        }

        int maxSorozat = 0;
        int aktSorozat = 0;
        for (int i = 0; i < pontok[sorszam - 1].Length; i++)
        {
            if (pontok[sorszam - 1][i] == '+')
            {
                aktSorozat++;
            }
            else
            {
                if (aktSorozat > maxSorozat)
                {
                    maxSorozat = aktSorozat;
                }
                aktSorozat = 0;
            }
        }
        if (aktSorozat > maxSorozat) maxSorozat = aktSorozat;
        Console.WriteLine("A(z) " + sorszam + ". versenyzőnek " + talalatok + " találata volt, a leghosszabb találati sorozata " + maxSorozat + ", pontszáma: " + loertek(pontok[sorszam - 1]));

        // 7. feladat
        StreamWriter ki = new StreamWriter("eredmenyek.txt");

        int[] pontszamok = new int[versenyzokSzama];
        int[] sorszamok = new int[versenyzokSzama];  
        
        for (int i = 0; i< versenyzokSzama; i++)
        {
            pontszamok[i] = loertek(pontok[i]);
            sorszamok[i] = i + 1; 
        }


        // Bubble sort 
        for (int i = 0; i < versenyzokSzama - 1; i++)
        {
            for (int j = 0; j < versenyzokSzama - 1 - i; j++)
            {
                if (pontszamok[j] < pontszamok[j + 1])
                {
                    
                    int temp = pontszamok[j];
                    pontszamok[j] = pontszamok[j + 1];
                    pontszamok[j + 1] = temp;
                    
                    
                    int tempSorszam = sorszamok[j];
                    sorszamok[j] = sorszamok[j + 1];
                    sorszamok[j + 1] = tempSorszam;
                }
            }
        }

        
        for (int i = 0; i < versenyzokSzama; i++)
        {
            ki.WriteLine((i + 1) +"\t"+ sorszamok[i] +"\t"+ pontszamok[i]);
        }

        ki.Close();
        Console.WriteLine("\nA rangsor kiírva az eredmenyek.txt fájlba.");


        Console.ReadKey();
    }
}
