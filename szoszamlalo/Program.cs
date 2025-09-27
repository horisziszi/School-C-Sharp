namespace szoszamolo;

class Program
{
    static int Szoszamlalo(string szoveg, int hatar, ref int max)
    {
        int db = 0;
        string[] reszek;
        int i;

        reszek = szoveg.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        for (i = 0; i < reszek.Length; i++)
        {
            if (reszek[i].Length > hatar)
            {
                db++;
            }
            if (reszek[i].Length > max)
            {
                max = reszek[i].Length;
            }
        }


        if (hatar < 1)
        {
            return -1;
        }




        return db;
    }
    static void Main(string[] args)
    {
        Console.Clear();
        string s = "Miért Beni, a tengervíz hidratál??";
        int szoszam = 0;
        int maxhossz = 0;

        szoszam = Szoszamlalo(s, 10, ref maxhossz);

        Console.WriteLine(szoszam);
        Console.WriteLine(maxhossz);
    }
}
