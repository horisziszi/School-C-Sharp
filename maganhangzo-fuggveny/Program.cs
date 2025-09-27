namespace maganhangzo_fuggveny;

class Program
{
    static int MaganhangzoSzamol(string s)
    {
        int db = 0;
        string maganhangzok = "aáeéiíoóöőuúüű";
        s = s.ToLower();


        for (int i = 0; i < s.Length; i++)
        {
            if (maganhangzok.IndexOf(s[i]) != -1)
            {
                db++;
            }
        }


        return db;
    }
    static void Main(string[] args)
    {
        Console.Clear();
        string s;
        int db;

        Console.Write("Kérem a szöveget: ");
        s = Console.ReadLine();

        db = MaganhangzoSzamol(s);
        Console.WriteLine(db);
    }
}

