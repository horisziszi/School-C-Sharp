using System;

namespace Iskola.szelerosseg
{
    class Program
    {
        struct Meres
        {
            public int masodperc;
            public int sebesseg;
            public string irany;
        }
        static Meres[] Beolvas(string nev)
        {
            Meres[] m;
            StreamReader fajl = new StreamReader(nev); // a .csproj-ban hozzáadtam a meresek.txt-t 
            string s;
            string[] reszek;
            int i, hossz;

            s = fajl.ReadLine();
            hossz = Convert.ToInt32(s);
            m = new Meres[hossz];
            for (i = 0; i < hossz; i++)
            {
                s = fajl.ReadLine();
                reszek = s.Split(' ');
                m[i].masodperc = Convert.ToInt32(reszek[0]);
                m[i].sebesseg = Convert.ToInt32(reszek[1]);
                m[i].irany = reszek[2];
            }
            fajl.Close();



            return m;
        }
        static void kiiratas(Meres[] m)
        {
            int i;
            for (i = 0; i < m.Length; i++)
            {
                Console.WriteLine(m[i].masodperc + " " + m[i].sebesseg + " " + m[i].irany);     
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            Console.Clear();
            Meres[] m = Beolvas("meresek.txt");

            kiiratas(m);

        }
    }
}