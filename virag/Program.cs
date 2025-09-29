using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.ComponentModel;

namespace virag
{
    class Program
    {
        struct Virag
        {
            public string nev;
            public int db;
        }
        static Virag[] Beolvas(string nev)
        {
            Virag[] a;
            StreamReader fajl = new StreamReader("data.txt");
            string s;
            string[] reszek;
            int i, hossz;

            s = fajl.ReadLine();
            hossz = Convert.ToInt32(s);
            a = new Virag[hossz];
            for (i = 0; i < hossz; i++)
            {
                s = fajl.ReadLine();
                reszek = s.Split(' ');
                a[i].nev = reszek[0];
                a[i].db = Convert.ToInt32(reszek[1]);
            }



            return a;
        }
        static List<string> Viraglista(Virag[] a)
        {
            List<string> lista = new List<string>();
            int i;
            for (i = 0; i < a.Length; i++)
            {
                lista.Add(a[i].nev);
            }
            return lista;
        }
        static void Main(string[] args)
        {
            Console.Clear();
            Virag[] a = Beolvas("data.txt");

            









        }
    }
}
