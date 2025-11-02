// OKTV gyakrolások
namespace gyakorlas;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();

        // https://www.oktatas.hu/pub_bin/dload/kozoktatas/tanulmanyi_versenyek/oktv/oktv2020_2021_1ford/info2_flap1f_oktv_2021.pdf

        int zold = 1, piros = 1, sarga = 2, feher = 3;
        int[] T = new int[6];
        T[0] = 1; // one way to build height 0 (no boxes)
        int[] heights = { zold, piros, sarga, feher };

        for (int i = 1; i < T.Length; i++)
        {
            foreach (int h in heights)
            {
                if (i - h >= 0)
                    T[i] += T[i - h];
            }
        }

        for (int i = 0; i < T.Length; i++)
            Console.WriteLine(T[i]);
        // I've had enough after one excercise, I'm done :(

        Console.ReadKey();
    }
}
