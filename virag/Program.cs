using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.ComponentModel;

namespace virag
{
    class Program
    {
        struct Adat
        {
            public string nev;
            public int db;
        }
        static Adat[] Beolvas(string nev)
        {
            Adat[] a;
            StreamReader fajl = new StreamReader(nev); // a .csproj-ban hozzáadtam a data.txt-t 
            string s;
            string[] reszek;
            int i, hossz;

            s = fajl.ReadLine();
            hossz = Convert.ToInt32(s);
            a = new Adat[hossz];
            for (i = 0; i < hossz; i++)
            {
                s = fajl.ReadLine();
                reszek = s.Split(' ');
                a[i].nev = reszek[0];
                a[i].db = Convert.ToInt32(reszek[1]);
            }
            fajl.Close();

            return a;
        }
        static List<string> Viraglista(Adat[] a)
        {
            List<string> lista = new List<string>();
            int i,j;
            for (i = 0; i < a.Length; i++)
            {
                for (j = 0; j < a[i].db; j++)
                {
                    lista.Add(a[i].nev);
                }
            }
            return lista;
        }

        static void ListaKiir(List<string> v)
        {
            int j;
            for (j = 0; j < v.Count; j++)
            {
                Console.Write(v[j] + " ");
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            Console.Clear();
            Adat[] viragok;
            viragok = Beolvas("data.txt");
            int i, index;
            Random rnd = new Random();

            List<string> ultetes = new List<string>();


            List<string> szinek;
            szinek = Viraglista(viragok);
            ListaKiir(szinek);


            while (szinek.Count > 0)
            {
                index = rnd.Next(0, szinek.Count);
                ultetes.Add(szinek[index]);
                szinek.RemoveAt(index);
            }
            szinek.TrimExcess();

            Console.WriteLine();
            ListaKiir(ultetes);

            //Insert
            index = rnd.Next(0, ultetes.Count);
            ultetes.Insert(index, "Zöld");
            Console.WriteLine();
            ListaKiir(ultetes);
        }
    }
}
