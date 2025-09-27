namespace kicserelo_string;

class Program
{
    static int Kicserelo(string szoveg, string cserelendo, string csereszo)
    {
        int cseredb=0;
        int n = 0;
        do
        {
            n = szoveg.IndexOf(cserelendo, n);
            if (n != -1)
            {
                cseredb++;
                n += cserelendo.Length;
            }
        }
        while (n != -1);

        return cseredb;
    }
    static void Main(string[] args)
    {
        Console.Clear();
        string cserelendo;
        string csereszo;
        string szoveg;
        int cseredb;

        Console.Write("Kérem a szöveget: ");
        szoveg = Console.ReadLine();
        Console.Write("Kérem a cserélendő szót: ");
        cserelendo = Console.ReadLine();
        Console.Write("Kérem a csereszót: ");
        csereszo = Console.ReadLine();

        cseredb = Kicserelo(szoveg, cserelendo, csereszo);
        Console.WriteLine(cseredb);

        }
}
