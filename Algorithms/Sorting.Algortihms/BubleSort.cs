using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Sorting.Algortihms
{
    public class BubleSort
    {
        public void Sort(int[] arr)
        {
            for (int j = arr.Length - 1; j >= 0; --j)
            {
                for (int i = 0; i < j; i++)
                {
                    if (arr[i] > arr[i + 1])
                        Swap(ref arr[i], ref arr[i + 1]);
                }
            }
        }

        public void Swap(ref int n1, ref int n2)
        {
            if (n1 == n2) return;
            n1 ^= n2;
            n2 ^= n1;
            n1 ^= n2;
        }

    }
}
