
namespace kovek;

class Program
{
    static bool Primvizsga(int a)
    {
        bool p = true;
        int i;
        int gyok = (int)Math.Sqrt(a);


        for (i = 2; i < gyok && p; i++)
        {
            if (a % i == 0)
            {
                p = false;

            }

        }


        return p;
    }
    static int[] TombolvasInt(string szoveg){

        int[] t;
        string s;
        string[] reszek;
        int i;
        Console.Write(szoveg);
        s=Console.ReadLine();
        reszek=s.Split(' ');

        for (i = 0; reszek.Length > i; i++)
        {
            t = new int[reszek.Length];
            t[i] = Convert.ToInt32(reszek[i]);
        }




        return t;
    }
    static void Main(string[] args)
    {
        Random rnd = new Random();


        int[] kovek = new int[8];
        int[] jell = new int[8];
        int[] tip;
        int i;

        for (i = 0; i < kovek.Length; i++)
        {
            kovek[i] = rnd.Next(1, 30);
            if (Primvizsga(kovek[i]))
            {
                jell[i] = 1;
            }
            else
            {
                jell[i] = 0;
            }
        }

        Console.WriteLine("Melyik szám prím? Igaz=1, Hamis=0\n");
        tip = TombolvasInt("Válaszok: ");








    }
}
