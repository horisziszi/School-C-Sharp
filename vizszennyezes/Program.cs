using System.Security.Cryptography.X509Certificates;

namespace vizszennyezes;

class Program
{
    // Létrehoz és visszaad egy véletlenszerű egész számokból álló listát.
    // A lista hossza 20 és 40 közé esik.
    // Kb. 75% az értékek közötti (0..80), a többi 81..200 tartományból kerül ki.
    static List<int> Listakeszito()
    {
        List<int> l = new List<int>();

        Random rnd = new Random();
        int i, hossz, b;
        hossz = rnd.Next(20, 41);
        for (i = 0; i < hossz; i++)
        {
            b = rnd.Next(0, 4);
            if (b < 3)
            {
                l.Add(rnd.Next(0, 81));
            }
            else
            {
                l.Add(rnd.Next(81, 201));
            }
        }
        l.TrimExcess();

        return l;
    }

    // Kiírja a lista elemeit egy sorban szóközökkel elválasztva.
    static void ListaKiir(List<int> a)
    {
        int i;
        for (i = 0; i < a.Count; i++)
        {
            Console.Write(a[i] + " ");
        }
        Console.WriteLine();
    }

    // Visszaadja a lista átlagát, két tizedesre kerekítve.
    static double Atlagolololo(List<int> a)
    {
        double atalg = Math.Round(a.Average(), 2);
        return atalg;
    }

    // Kiszámolja a lista elemeinek százalékos arányát, amelyek 31 és 79 közé esnek (31..79).
    // Az eredményt két tizedesre kerekítve adja vissza.
    static double Gyakorisag(List<int> a)
    {
        int i;
        double gyak;
        int db = 0;
        for (i = 0; i < a.Count; i++)
        {
            if (a[i] < 80 && a[i] > 30)
            {
                db++;
            }
        }
        gyak = Math.Round((double)db / a.Count * 100, 2);
        return gyak;
    }

    static void Main(string[] args)
    {
        Console.Clear();
        int i, db=0;
        double szazalek;
        List<int> szamok = Listakeszito();
        List<int> egyedi;
        ListaKiir(szamok);
        Console.WriteLine();
        
        // Beszúr egy magas értéket az index 14-re
        szamok.Insert(14, 177);

        // Az első négy elem eltávolítása (a ciklus előrehaladása megváltoztatja az indexeket,
        // ezért ez a megközelítés kihagyhat elemeket; ha az eredeti első négy elemet akarjuk törölni,
        // érdemes négyszer RemoveAt(0)-t hívni.)
        for (i=0;i<4;i++)
        {
            szamok.RemoveAt(i);
        }
        ListaKiir(szamok);
        Console.WriteLine();

        // Megszámolja az 120-nál nagyobb értékeket
        for (i = 0; i < szamok.Count; i++)
        {
            if (szamok[i] > 120)
            {
                db++;
            }
        }

        Console.WriteLine("Határértéket túllépő értékek száma: "+db);
        Console.WriteLine("Legmagasabb érték: "+szamok.Max());

        // 50 alatti értékek százalékos aránya
        db = 0;
        for (i = 0; i < szamok.Count; i++)
        {
            if (szamok[i] < 50)
            {
                db++;
            }
        }
        szazalek = Math.Round(((double)db / szamok.Count * 100),2);
        Console.WriteLine("50 alatti értékek százaléka: " + szazalek);

        Console.WriteLine("Átlag: " + Atlagolololo(szamok));

        // Egyedi értékek listája rendezve
        egyedi = szamok.Distinct().ToList();
        egyedi.Sort();
        Console.WriteLine("Egyediek száma: " + egyedi.Count);
        ListaKiir(egyedi);
        // A 3. legnagyobb egyedi érték (feltételezi, hogy legalább 3 egyedi érték van)
        Console.WriteLine("3. Legnagyobb mérés értéke: " + egyedi[egyedi.Count-3]);

        Console.WriteLine("Gyakoriság: " + Gyakorisag(szamok));
        
    }
}

