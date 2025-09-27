namespace palindrome;

class Program
{
    static bool Palindrome(string s)
    {
        bool isPalindrome= true;
        s = s.ToLower();
        char[] karakter = s.ToCharArray();
        int i;



        for (i = 0; i < karakter.Length / 2; i++)
        {
            if (karakter[i] != karakter[karakter.Length - 1 - i])
                isPalindrome = false;
        }



        return isPalindrome;
    }
    static void Main(string[] args)
    {
        Console.Clear();
        string s="";
        Console.Write("Kérek egy szót: ");
        s = Console.ReadLine();
        if (Palindrome(s))
            Console.WriteLine("A megadott szó palindrom.");
        else
            Console.WriteLine("A megadott szó nem palindrom.");

    }
}
