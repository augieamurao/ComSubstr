using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComSubstr
{
 
    class Program
    {

        static int Max(int a, int b)
        {
            if (a >= b)
                return a;
            else
                return b;
        }

        // Brute force approach
        static int LCSubStr_BF(string X, string Y, int m, int n)
        {
            int result = 0;
            for (int i = 0; i < m; i++)
            {
                for (int j = i; j < n; j++)
                {
                    if (j < m)
                    {
                        string substr = X.Substring(i, j - i + 1);
                        if (Y.Contains(substr))
                        {
                            result = Max(result, j - i + 1);
                        }
                        else
                        {
                            break; // don't have to check anymore of the substring once it fails
                        }
                    }
                }
            }

            return result;
        }


        static int LCSubStr_DP(string X, string Y, int m, int n)
        {
            int[,] table = new int[m, n];
            int result = 0;

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (X[i] != Y[j])
                    {
                        table[i, j] = 0;
                    }                    
                    else
                    {
                        if ((i > 0) && (j > 0))
                            table[i, j] = table[i - 1, j - 1] + 1;
                        else
                            table[i, j] = 1;
                    }
                    result = Max(result, table[i, j]);
                }
            }
            return result;
        }


        public static void Main()
        {
            String X = "AugieAmurao_ Wrote This";
            String Y = "Joshua _Amurao-  did not do This";

            int m = X.Length;
            int n = Y.Length;

            Console.WriteLine("Length of Longest Common using BF"
            + " Substring is " + LCSubStr_BF(X, Y, m, n));

            Console.WriteLine("Length of Longest Common using DP"
            + " Substring is " + LCSubStr_DP(X, Y, m, n));

        }

    }
}
