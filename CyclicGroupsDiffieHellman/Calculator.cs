using System;
using System.Collections.Generic;

namespace DiffieHellmanCalculator
{
    internal class Calculator
    {
        internal static long Phi(long n)
        {
            if (n <= 0)
                return 0;

            long result = n;
            long tempN = n;

            for (long i = 2; i * i <= tempN; ++i)
            {
                if (tempN % i == 0)
                {
                    while (tempN % i == 0)
                    {
                        tempN /= i;
                    }
                    result -= result / i;
                }
            }

            if (tempN > 1)
            {
                result -= result / tempN;
            }

            return result;
        }

        internal static bool IsPrimeFermat(long n, int k = 5)
        {
            if (n <= 1) return false;
            if (n <= 3) return true;
            if (n % 2 == 0) return false;

            Random rand = new Random();

            for (int i = 0; i < k; i++)
            {
                long a = rand.NextInt64(2, n - 1);
                if (Power(a, n - 1, n) != 1)
                {
                    return false;
                }
            }

            return true;
        }

        internal static long Gcd(long a, long b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);

            while (b != 0)
            {
                long remainder = a % b;
                a = b;
                b = remainder;
            }

            return a;
        }

        internal static long Power(long baseNum, long exponent, long m)
        {
            if (exponent < 0)
            {
                throw new ArgumentException("Exponent cannot be negative.");
            }

            long result = 1;
            long normBase = Normalize(baseNum, m);

            while (exponent > 0)
            {
                if ((exponent & 1) == 1)
                {
                    result = Normalize(result * normBase, m);
                }
                normBase = Normalize(normBase * normBase, m);
                exponent >>= 1;
            }

            return result;
        }

        private static long Normalize(long value, long mod)
        {
            long result = value % mod;
            return result < 0 ? result + mod : result;
        }

        // order of the group 
        internal static long GetGroupOrder(long p)
        {
            if (p <= 1)
                throw new ArgumentException("Parameter p must be greater than 1.");

            return Phi(p);
        }

        // order of the element g in the group of integers modulo p
        internal static long GetElementOrder(long g, long p)
        {
            if (p <= 1)
                throw new ArgumentException("Parameter p must be greater than 1.");
            if (Gcd(g, p) != 1)
                throw new InvalidOperationException($"g = {g} and p = {p} must be coprime (GCD = 1).");

            long groupOrder = Phi(p);
            for (long k = 1; k <= groupOrder; k++)
            {
                if (groupOrder % k == 0 && Power(g, k, p) == 1)
                {
                    return k;
                }
            }

            return groupOrder;
        }

        // Search for all generators (primitive roots) relative to the input number p
        internal static List<long> GetGenerators(long p)
        {
            if (p <= 1)
                throw new ArgumentException("Parameter p must be greater than 1.");

            long order = Phi(p);
            List<long> primeFactors = GetPrimeFactors(order);
            List<long> generators = new List<long>();

            for (long g = 1; g < p; g++)
            {
                if (Gcd(g, p) != 1)
                    continue;

                bool isGenerator = true;
                foreach (long factor in primeFactors)
                {
                    if (Power(g, order / factor, p) == 1)
                    {
                        isGenerator = false;
                        break;
                    }
                }

                if (isGenerator)
                {
                    generators.Add(g);
                }
            }

            return generators;
        }

        private static List<long> GetPrimeFactors(long n)
        {
            List<long> factors = new List<long>();
            long temp = n;

            for (long i = 2; i * i <= temp; i++)
            {
                if (temp % i == 0)
                {
                    factors.Add(i);
                    while (temp % i == 0)
                    {
                        temp /= i;
                    }
                }
            }

            if (temp > 1)
            {
                factors.Add(temp);
            }

            return factors;
        }

        // Diffie-Hellman key exchange calculation
        internal static (long publicA, long publicB, long sharedKey) CalculateDiffieHellman(long p, long g, long privateA, long privateB)
        {
            if (!IsPrimeFermat(p))
                throw new ArgumentException($"p = {p} must be a prime number.");
            if (g <= 1 || g >= p)
                throw new ArgumentException("g must be in range 1 < g < p.");
            if (privateA <= 0 || privateB <= 0)
                throw new ArgumentException("Secret numbers A and B must be positive integers.");

            long publicA = Power(g, privateA, p);
            long publicB = Power(g, privateB, p);
            long sharedKeyA = Power(publicB, privateA, p);
            long sharedKeyB = Power(publicA, privateB, p);

            if (sharedKeyA != sharedKeyB)
                throw new InvalidOperationException("Shared keys do not match.");

            return (publicA, publicB, sharedKeyA);
        }
    }
}