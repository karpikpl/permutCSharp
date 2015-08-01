using System;
using System.Linq;
using System.Numerics;

namespace Permut
{
    public class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var input = Console.ReadLine();
                if (input == null || input.Length < 3)
                    return;

                var data = input.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                var n = int.Parse(data[0]);
                var i = BigInteger.Parse(data[1]);

                var result = FindIthPermutation(n, i);
                Console.WriteLine(ArrayToString(result));
            }
        }

        static string ArrayToString(int[] array)
        {
            return string.Join(" ", array.Select(d => d.ToString()));
        }

        public static int[] FindIthPermutation(int n, BigInteger i)
        {
            BigInteger[] fact = new BigInteger[n];
            int[] permutation = new int[n];

            fact[0] = 1;
            for (int k = 1; k < n; k++)
            {
                fact[k] = fact[k - 1] * k;
            }

            for (int k = 0; k < n; k++)
            {
                permutation[k] = (int)BigInteger.Divide(i, fact[n - 1 - k]);
                i = i % fact[n - 1 - k];
            }

            for (int k = n - 1; k > 0; k--)
            {
                for (int j = k - 1; j >= 0; j--)
                {
                    if (permutation[j] <= permutation[k])
                        permutation[k]++;
                }
            }

            for (int k = 0; k < n; k++)
            {
                permutation[k]++;
            }

            return permutation;
        }
    }
}
