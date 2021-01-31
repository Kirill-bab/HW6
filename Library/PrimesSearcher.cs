using System;
using System.Collections.Generic;
using System.Linq;

namespace Library
{
    public class PrimesSearcher
    {
        public int From { get; }
        public int To { get; }

        public PrimesSearcher(int from, int to)
        {
            From = from < 2 ? 2 : from;
            To = to;
        }

        private bool IsPrime(int numb)
        {
            if (Enumerable.Range(-1, 3).Contains(numb))
            {
                return false;
            }

            bool isPrime = Enumerable.All(Enumerable.Range(2,Math.Abs(numb) - 2), n => numb % n != 0);
            return isPrime;
        }
        public List<int> FindPrimes(bool isParallel)
        {
            if (To < From)
            {
                return new List<int>(0);
            }
            if (isParallel)
            {
                return Enumerable.Range(From, To - From + 1).AsParallel().AsOrdered().Where(numb => IsPrime(numb)).ToList();
            }
            return Enumerable.Range(From, To - From + 1).Where(numb => IsPrime(numb)).ToList();
        }
    }
}
