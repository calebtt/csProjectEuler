using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csProjectEuler
{ 
    /// <summary>
    /// Computes a list of positive prime numbers using the
    /// sieve of eratosthenes, or a variation thereof.
    /// </summary>
    public class PeSieveGenerator
    {
        private readonly Int64 m_maxPrime;
        public PeSieveGenerator(Int64 primeMaxComputeValue)
        {
            m_maxPrime = primeMaxComputeValue;
        }
        public List<Int64> GetPrimes()
        {
            //maximum prime factors of the large number will only be up to the sqrt of that number.
            Int64 maximumFactor = (Int64) Math.Sqrt(m_maxPrime) + 1;
            Console.WriteLine("Max prime factor value to compute: " + maximumFactor.ToString());
            //Default Boolean value in C# is false, sieve to get the prime numbers up to maximumFactor
            Boolean[] bitArray = new Boolean[maximumFactor];
            //bit location 0 is not prime and will be marked off.
            bitArray[0] = true;
            bitArray[1] = true;
            Console.WriteLine("Computing...");
            //O(N) operation to sieve for primes, better than performing
            //division each iteration to find them. only O(N) because up to sqrt(N)
            //even with nested for loops
            for (Int64 i = 2; i < maximumFactor; i++)
            {
                for (Int64 j = 2; (i*j) < maximumFactor; j++)
                {
                    bitArray[i * j] = true;
                }
            }
            List<Int64> primes = new List<Int64>();
            for (Int64 i = 0; i < bitArray.LongLength; i++)
            {
                if(!bitArray[i])
                    primes.Add(i);
            }
            Console.WriteLine("List of possible prime factors computed...");
            return primes;
        }
    }
}
