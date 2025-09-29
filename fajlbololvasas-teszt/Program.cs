namespace fajlbololvasas_teszt;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        StreamReader fajl = new StreamReader("/home/szilard/alma.txt");
        // a fix elérésű fájlolvasás működik, de csak az én gépemen, és nem megy fel a GitHub-ra jól
        string sor;
        while ((sor = fajl.ReadLine()) != null)
        {
            Console.WriteLine(sor);
        }
        fajl.Close();

        Console.WriteLine();
        
        StreamReader fajl2 = new StreamReader("narancs.txt"); //Ha hozzáadom a .csproj-hoz a szövegfájlt, akkor működik a fájlból olvasás relatív elérési úttal
        // és ez még azért is jó, mert a GitHub-ra is jól kerül fel
        while ((sor = fajl2.ReadLine()) != null)
        {
            Console.WriteLine(sor);
        }
        fajl2.Close();
    }
}
