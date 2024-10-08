using System.Diagnostics;

namespace DSandAPractice.Algorithms;
public static class PrimeNumbers
{
    /// <summary>
    /// Given a number n, returns a list of prime numbers up to n (inclusive)
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public static List<int> Sieve(int n)
    {
        List<int> primes = new();
        //Create a list of booleans up to n
        bool[] sieve = new bool[n + 1];
        int i;
        for(i = 0; i < sieve.Length - 1; i++) sieve[i] = true;
        //initialize 0 and 1 to false, as they are not prime
        sieve[0] = false;
        sieve[1] = false;
        //using GetPrime func, iterate up to n and set multiples of our iterator to false
        for (i = 2; i <= n; i = GetNextPrime(i, sieve))
        {
            MarkOffMultiples(i, sieve);
            primes.Add(i);
        }
        //return a list of positions at which our boolean list returns true
        return primes;
    }
    static int GetNextPrime(int i, bool[] sieve)
    {
        for (i += 1; i < sieve.Length; i++) {
            if (sieve[i]) break;
        }
        return i;
    }
    static void MarkOffMultiples(int i, bool[] sieve) {
        for (int index = i; i < sieve.Length; index+=i) {
            if(index > sieve.Length - 1) break;
            sieve[index] = false;
        }
    }

    public static bool IsPrime(int num)
    {
        if (num <= 1) return false;
        for (int i = 2; i < Math.Sqrt(num); i++) {
            if (num % i == 0) return false;
        }
        return true;
    }
}