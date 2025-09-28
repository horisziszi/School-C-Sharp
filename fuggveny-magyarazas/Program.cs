namespace fuggveny_magyarazas;

class Program
{
    static Random rnd = new Random(); // a véletlenszám generátort csak egyszer hozzuk létre, és újra felhasználjuk
    static int[] randomtomb(int fmeret, int fmin, int fmax)
    {
        int[] ftomb = new int[fmeret];
        for (int i = 0; i < ftomb.Length; i++)
        {
            ftomb[i] = rnd.Next(fmin, fmax + 1);
        }
        return ftomb;
    }
    static void Main(string[] args)
    {
        Console.Clear();
        // tegyük fel, kell egy tömb tele random számokkal
        // függcények nélkül valahogy így nézhet ki
        int i, min = 1, max = 100, meret = 10;
        int[] tomb = new int[meret];
        
        for (i = 0; i < tomb.Length; i++)
        {
            tomb[i] = rnd.Next(min, max + 1);
        }
        Console.WriteLine("Hardcode-olt tömb: ");
        for (i = 0; i < tomb.Length; i++)
        {
            Console.Write(" " + tomb[i]);
        }
        Console.WriteLine();
        // ez így hosszú, nehezen szerkeszthető, ráadásul ha máshol is kell ilyen tömb, át kell írni a paramétereket egyesével
        // helyette írjunk egy függvényt, amivel könnyű megcsinálni paraméterektől függő tömböt
        // Mi úgy tanultuk C#-ban, hogy a Main fölött legyen a saját definiált függvény, ezért elég fura a kommentek sorrendje

        // Na de most itt van fügvénnyel:
        int[] ftomb = randomtomb(10, 1, 100);
        Console.WriteLine("Függvénnyel generált tömb: ");
        for (i = 0; i < tomb.Length; i++)
        {
            Console.Write(" " + ftomb[i]);
        }
        Console.WriteLine();

        // Egy teljes sort megspórultunk, és ha kell egy másik tömb, csak meghívjuk a függvényt más paraméterekkel
        int[] ftomb2 = randomtomb(20, 50, 500);
        Console.WriteLine("Másik függvénnyel generált tömb: ");
        for (i = 0; i < tomb.Length; i++)
        {
            Console.Write(" " + ftomb2[i]);
        }
        Console.WriteLine();


        Console.ReadKey();
    }
}
