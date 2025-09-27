
using System.Reflection.Metadata.Ecma335;

namespace string_fuggveny;

class Program
{
    static string Elsobetuk(string szoveg, string vago)
    {
        string jelszo="", elso= "";

        string[] reszek;
        reszek = szoveg.Split(vago, StringSplitOptions.RemoveEmptyEntries);
        int i;
        for (i = 0; i < reszek.Length; i++)
        {
            elso = reszek[i].Substring(0, 1);
            elso = elso.ToUpper();
            jelszo += elso;

        }









        return jelszo;
    }
    static void Main(string[] args)
    {
        string s, jelszo;
        Console.WriteLine("Kérem a szöveget: ");

        s = Console.ReadLine();
        jelszo = Elsobetuk(s, " ");
        Console.WriteLine(jelszo);





        Console.ReadKey();
    }
}
