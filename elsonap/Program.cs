using System;

namespace Iskola
{
    class Program
    {
        static void Main(string[] args)
        {
            string s, jelszo = "korona";
            int probalkozas = 3;
            int[] tomb = new int[10];
            Random r = new Random();


            // jelszo
            Console.Write("adja meg a jelszót: ");
            do
            {
                s = Console.ReadLine();
                if (s == jelszo)
                    Console.WriteLine("A kapu kinyílt");
                else if (probalkozas > 1)
                    Console.Write("A kapu zárva maradt: ");
                probalkozas -= 1;
            }
            while (s != jelszo && probalkozas > 0);

            //kincstar kulcs

            for (int i = 0; i < tomb.Length; i++)
            {
                tomb[i] = r.Next(1, 101);
            }


            for (int i = 0; i < tomb.Length; i++)
            {
                if (tomb[i] % 2 == 0) {
                    Console.WriteLine("Ebben a ládában van kulcs: {0}", i+1);
                }
            }




            Console.ReadKey();
        }
    }
}
