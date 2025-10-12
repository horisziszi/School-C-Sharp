namespace Dolgozat_lista3;

class Program
{
    static List<int> Listakeszito()
    {
        Random rnd = new Random(); // random változót meghatározza
        int i, k; // egész szmú változók meghatározása
        int hossz = rnd.Next(20, 31); // lista hosszának megadása
        List<int> a = new List<int>(); // listák meghatározása
        for (i = 0; i < hossz; i++)
        {
            k = rnd.Next(0, 5); // egy valószínűséget eltároló változó
            if (k == 0) // egy az öthöz az esély, hogy 0 legyen az érték, vagyis 20% a 80 és 200 közötti számok gyakorisága 20%-a
            {
                a.Add(rnd.Next(80, 201)); 
            }
            else // mivel 1, 2, 3 és 4 értékeknek 4 az 5höz az esélye, hogy legyen, ezért a 0 és 50 közötti elemek gyakorisága 80%
            {
                a.Add(rnd.Next(0, 51));  
            }
        }
        a.TrimExcess(); // a feleslegesen lefoglalt helyet felszabadítja
        return a;

    }
    static int kiiratas(List<int> a) // listát kiíró függvény
    {
        int i;
        for (i = 0; i < a.Count; i++)
        {
            Console.Write(a[i] + " ");
        }
        Console.WriteLine();
        int hossz = a.Count;
        return hossz; // visszatérési értékként megadja a lista hosszát
    }
    static void Main(string[] args)
    {
        Console.Clear(); // tiszta konzollal kezdés
        int i, beszurando = 70, meghaladodb = 0, max; // egész értékű változók meghatározása
        double szazalek; // százalék változó meghatározása
        List<int> ertekek = Listakeszito(); // listák meghatározása
        List<int> egyedi = new List<int>(); // az eredeti lista egyedi elemeit tároló lista meghatározása
        kiiratas(ertekek); // az eredeti lista kiírása
        Console.WriteLine();

        ertekek.RemoveAt(5); // 5. elem eltávolítása
        ertekek.RemoveAt(5); // az 5. elem eltávolítása után az eredeti lista 6. elemének eltávolítása
        kiiratas(ertekek); // az új lista kiírása
        Console.WriteLine();

        for (i = 0; i < 3; i++)
        {
            ertekek.Insert(0, beszurando); // 3 db beszúrás
            beszurando -= 10; // az elején meghatározott 70-et csökkenti 10-zel, mert a feladatban úgy jönnek sorba az 50 60 70
        }
        kiiratas(ertekek); // a beszúrt elemekkel együtt kiírja a listát
        Console.WriteLine();


        for (i = 0; i < ertekek.Count; i++)
        {
            if (ertekek[i] > 150)
            {
                meghaladodb++; // megszámolja, hogy hány 150-nél nagyobb elem van
            }
        }

        szazalek = Math.Round((double)meghaladodb / ertekek.Count(),2); // megszámolja a 150-nél nagyobb elemek százalékát


        max = ertekek.Max(); // megkereszi a legnagyobb elemet

        egyedi = ertekek.Distinct().ToList(); // az egyedi listába eltárolja az elemeket az eredeti listából, amik egyedi értékek az eredeti listában
        egyedi.Sort(); // az egyedilistát növekvő sorrendbe állítja
        egyedi.Reverse(); // megfordítja a növekvő sorrendet csökkenőre
        egyedi.TrimExcess(); // a feleslegesen lefoglalt helyeket felszabadítja
        kiiratas(egyedi); // az egyedi listát kiírja
        Console.WriteLine();

        Console.ReadKey(); // program vége
    }
}
