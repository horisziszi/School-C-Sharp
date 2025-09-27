using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design.Serialization;

namespace lista;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        List<int> szamok = new List<int>(20);
        Random rnd = new Random();
        int i, a, index, max, min, összeg;
        double atlag;
        bool sikeres;

        szamok.Add(11);
        szamok.Add(12);
        szamok.Add(13);
        /*szamok.Add(4);
        szamok.Add(5);
        szamok.Add(6);*/

        for (i = 0; i < 7; i++)
        {
            a = rnd.Next(1, 21);
            szamok.Add(a);
        }

        for (i = 0; i < szamok.Count; i++)
        {
            Console.Write("{0} ", szamok[i]);
        }
        Console.WriteLine();




        Console.WriteLine("A lista elemeinek száma: {0}", szamok.Count);
        Console.WriteLine("A lista ennyi helyet foglal: {0}", szamok.Capacity);

        szamok.TrimExcess();
        Console.WriteLine();
        Console.WriteLine("A lista ennyi helyet foglal: {0}", szamok.Capacity);

        a = rnd.Next(1, 21);
        index = szamok.IndexOf(a);
        Console.WriteLine("A {0} szám első előfordulása a listában", a);
        if (index >= 0)
        {
            Console.WriteLine("Az indexe: {0}", index);
        }
        else
        {
            Console.WriteLine("Nincs benne a listában");
        }

        max = szamok.Max();
        min = szamok.Min();
        összeg = szamok.Sum();
        atlag = (int)szamok.Average();
        atlag = Math.Round(atlag, 2);

        Console.WriteLine("A lista legnagyobb eleme: {0}", max);
        Console.WriteLine("A lista legkisebb eleme: {0}", min);
        Console.WriteLine("A lista elemeinek összege: {0}", összeg);
        Console.WriteLine("A lista elemeinek átlaga: {0}", atlag);


        szamok.Insert(2, 100);
        for (i = 0; i < szamok.Count; i++)
        {
            Console.Write("{0} ", szamok[i]);
        }
        Console.WriteLine();

        szamok.Remove(10); //első 10-est eltávolítja a listából
        szamok.RemoveAt(6); //6. indexű elemet eltávolítja
        szamok.RemoveAt(2); //2. indexű elemet eltávolítja
        Console.WriteLine();
        for (i = 0; i < szamok.Count; i++)
        {
            Console.Write("{0} ", szamok[i]);
        }

        sikeres = szamok.Remove(10);
        if (sikeres)
        {
            Console.WriteLine();
            Console.WriteLine("Sikeres törlés");
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine("Nincs benne a listában");
        }

        szamok.RemoveAll(x => x > 15); //minden 15-nél nagyobb számot eltávolít a listából
        Console.WriteLine();
        for (i = 0; i < szamok.Count; i++)
        {
            Console.Write("{0} ", szamok[i]);
        }

        szamok.FindAll(x => x < 10); //minden 10-nél kisebb számot megkeres a listában
        Console.WriteLine();
        for (i = 0; i < szamok.Count; i++)
        {
            Console.Write("{0} ", szamok[i]);
        }



        Console.WriteLine();


    }
}
