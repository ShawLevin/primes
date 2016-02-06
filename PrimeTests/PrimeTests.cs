using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace PrimeTests
{
    [TestClass]
    public class PrimeTests
    {
        [TestMethod]
        public void CheckNegative()
        {
            Assert.AreEqual(IsPrime(-1), false);
        }

        [TestMethod]
        public void CheckZero()
        {
            Assert.AreEqual(IsPrime(0), false);
        }

        [TestMethod]
        public void CheckOne()
        {
            Assert.AreEqual(IsPrime(1), false);
        }

        [TestMethod]
        public void CheckTwo()
        {
            Assert.AreEqual(IsPrime(2), true);
        }

        [TestMethod]
        public void CheckEvens()
        {
            Assert.AreEqual(IsPrime(4), false);
            Assert.AreEqual(IsPrime(6), false);
            Assert.AreEqual(IsPrime(8), false);
            Assert.AreEqual(IsPrime(10), false);
            Assert.AreEqual(IsPrime(12), false);
            Assert.AreEqual(IsPrime(14), false);
            Assert.AreEqual(IsPrime(102), false);
        }

        [TestMethod]
        public void Check99()
        {
            Assert.AreEqual(IsPrime(99), false);
        }

        [TestMethod]
        public void Check100()
        {
            Assert.AreEqual(IsPrime(100), false);
        }

        [TestMethod]
        public void Check101()
        {
            Assert.AreEqual(IsPrime(101), true);
        }

        [TestMethod]
        public void Check1000001()
        {
            Assert.AreEqual(IsPrime(1000001), false);
        }

        [TestMethod]
        public void CheckBigs()
        {
            Assert.AreEqual(IsPrime(15485867), true);
            Assert.AreEqual(IsPrime(67867967), true);
            Assert.AreEqual(IsPrime(86028157), true);
        }

        [TestMethod]
        public void CheckListOfPrimes()
        {
            using (StreamReader r = new StreamReader(@"C:\Users\Shaw\Documents\Visual Studio 2015\Projects\PrimeCalculator\PrimeTests\primes.txt"))
            {
                string line;
                while ((line = r.ReadLine()) != null)
                {
                    string[] primes = line.Split(',');
                    foreach (string s in primes)
                    {
                        Assert.IsTrue(IsPrime(Int32.Parse(s)));
                    }
                }
            }
        }

        [TestMethod]
        public void CheckListOfComposites()
        {
            using (StreamReader r = new StreamReader(@"C:\Users\Shaw\Documents\Visual Studio 2015\Projects\PrimeCalculator\PrimeTests\composites.txt"))
            {
                string line;
                while ((line = r.ReadLine()) != null)
                {
                    string[] primes = line.Split(',');
                    foreach (string s in primes)
                    {
                        Assert.IsFalse(IsPrime(Int32.Parse(s)));
                    }
                }
            }
        }

        [TestMethod]
        public void Loop()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(i + ":" + IsPrime(i));
            }
        }

        public static Boolean IsPrime(int x)
        {
            if (x < 2) //Handle the always not primes.
            {
                return false;
            }

            if (x == 2 || x == 3 || x == 5) // These are quick.
            {
                return true;
            }

            //Binary & with 0 checks if the last digit is also 0 - meaning number is even and thus not prime.
            if ((x & 1) == 0) 
            {
                return false;
            }

            for (int i = 3; i < x/i+1; i+=2)
            {
                if (x % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
