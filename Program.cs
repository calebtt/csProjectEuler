using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace csProjectEuler
{
    internal class Program
    {
        private static string BuildOutputFromList(IEnumerable<int> currentList)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var elem in currentList)
            {
                sb.Append(elem.ToString() + " ");
            }
            return sb.ToString();
        }

        private static void PrintOutputFromBuiltList(IEnumerable<int> currentList, string message)
        {
            Console.Write(message + BuildOutputFromList(currentList));
        }

        private static void PrintColoredText<T>(string message, T someVal, ConsoleColor col = ConsoleColor.Green)
        {
            ConsoleColor orig = Console.ForegroundColor;
            Console.ForegroundColor = col;
            Console.Write(message);
            Console.WriteLine(someVal);
            Console.ForegroundColor = orig;
        }
        private static void PEProblemOne()
        {
            const int MAXNUM = 1000;
            const int FIRSTMULTIPLE = 3;
            const int SECONDMULTIPLE = 5;
            List<int> threeMultiples = new List<int>();
            List<int> fiveMultiples = new List<int>();
            List<int> combinedList = new List<int>(); // duplicates must be counted only once.
            for (int i = 0; i < MAXNUM; i += FIRSTMULTIPLE)
            {
                threeMultiples.Add(i);
            }
            for (int j = 0; j < MAXNUM; j += SECONDMULTIPLE)
            {
                fiveMultiples.Add(j);
            }
            combinedList.AddRange(threeMultiples);
            combinedList.AddRange(fiveMultiples);
            IEnumerable<int> distinctCombinedList = combinedList.Distinct();

            //PrintOutputFromBuiltList(threeMultiples, "Three List: ");
            //Console.WriteLine();
            //PrintOutputFromBuiltList(fiveMultiples, "Five List: ");
            //Console.WriteLine();
            PrintOutputFromBuiltList(distinctCombinedList, "Combined List: ");
            int distinctSum = distinctCombinedList.Sum();
            Console.WriteLine();
            PrintColoredText("PE#1 ANSWER: ", distinctSum);
        }

        private static void PEProblemTwo()
        {
            Console.WriteLine("Starting PE#2");
            const int MAX_VAL = 4_000_000;
            List<bool> evenNumbers = new List<bool>(MAX_VAL); //alloc enough memory
            List<int> fibNumbers = new List<int>();
            bool toggler = true;
            for (var i = 0; i < MAX_VAL; i++)
            {
                evenNumbers.Add(toggler);
                toggler = !toggler;
            }
            fibNumbers.Add(2);
            for (int i = 1, j = 2; (i + j) < MAX_VAL;)
            {
                int tempFib = i + j;
                if (tempFib < MAX_VAL)
                {
                    if (evenNumbers[tempFib])
                    {
                        fibNumbers.Add(tempFib);
                    }

                    i = j;
                    j = tempFib;
                }
                else
                {
                    break;
                }
            }
            var sumOf = fibNumbers.Sum();
            Console.WriteLine();
            PrintColoredText("PE#2 ANSWER: ", sumOf.ToString("N"));
        }

        private static void PEProblemThree()
        {
            //generate prime numbers up to sqrt(PELARGENUM)
            const Int64 PELARGENUM = 600_851_475_143;
            Console.WriteLine("PE provided large number: " + PELARGENUM.ToString("N"));
            //const Int64 PELARGENUM = 13195;
            PeSieveGenerator primeGenerator = new PeSieveGenerator(PELARGENUM);
            List<Int64> primeList = primeGenerator.GetPrimes();
            Console.Write("First few primes: ");
            for (int i = 0; i < 5; i++)
            {
                Console.Write(primeList[i].ToString() + " ");
            }
            Console.WriteLine();
            List<Int64> resultList = new List<Int64>();
            //find largest primes in the list that are factors of PELARGENUM
            for (int i = primeList.Count - 1; i >= 0; i--)
            {
                Int64 r = PELARGENUM % primeList[i];
                if (r == 0)
                {
                    PrintColoredText("Result found: ", primeList[i].ToString("N"), ConsoleColor.DarkYellow);
                    resultList.Add(primeList[i]);
                }
            }
            Int64 probableResult = resultList.First();
            PrintColoredText("PE#3 ANSWER: ", probableResult);
            //quick test for being a factor of the big number
            Decimal resultDecimal = (Decimal)PELARGENUM / (Decimal)probableResult;
            Console.WriteLine("Look for remainder after division with PE provided test number: " +
                              resultDecimal.ToString("N"));
            Console.WriteLine("Test division number: " + (Decimal)PELARGENUM / (resultDecimal - 1));
        }

        private static void PEProblemFour()
        {

        }
        static void Main(string[] args)
        {
            PEProblemOne();
            PEProblemTwo();
            PEProblemThree();
            PEProblemFour();
        }
    }
}
