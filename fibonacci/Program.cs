namespace fibonacci;

class Program
{
    static List<int> Fibonacci(int hossz)
    {
        List<int> fib = new List<int>();
        fib.Add(1);
        fib.Add(1);
        for (int i = 2; i < hossz; i++)
        {
            fib.Add(fib[i - 1] + fib[i - 2]);
        }
        return fib;
    }
    static void Kiir(List<int> l)
    {
        int i;
        for (i = 0; i < l.Count; i++)
        {
            Console.WriteLine((i+1)+" "+l[i]);
        }
        Console.WriteLine();
    }
    static void Main(string[] args)
    {
        Console.Clear();
        List<int> fibonaccisorozat = Fibonacci(100);
        Kiir(fibonaccisorozat);
        Console.ReadKey();
    }
}
