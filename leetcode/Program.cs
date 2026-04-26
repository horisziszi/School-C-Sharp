namespace leetcode;


public class Solution {
    public bool CanMakeArithmeticProgression(int[] arr) {
        int a=0,b=0,c=0,i;
        bool isarithmetic=false;
        for (i=0; i<arr.Length-1; i++){
            a = arr[i] - arr[i+1];
            if (a!=b){
                c++;
            }
            a = b;
        }
        if (c==1){
            isarithmetic = false;
        }
        else{
            isarithmetic = true;
        }

        return isarithmetic;
    }
}



class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}
