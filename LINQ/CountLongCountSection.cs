using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET5.LINQ
{
    public class CountLongCountSection
    {
        public static int CountAllLongWords(IEnumerable<string> words)
        {
            return words.Count(word => word.Length > 100);
        }

        #region AreThereFewerOddThanEvenNumbers
        //We must use the Count method to count the even and odd numbers in the collection,
        //and then check if countOfEven > countOfOdd:
        public static bool AreThereFewerOddThanEvenNumbers(IEnumerable<int> numbers)
        {
            return numbers.Count(number => number % 2 == 0) > numbers.Count(number => number % 2 != 0);
        }

        // This solution would work, but it's not optimal.
        // We use the Count method twice, which means we iterate over the numbers collection twice.
        // We can optimize that. It's enough if we count only the even numbers in the collection.
        // If a number is not even, it must be odd. So the count of odd numbers is countOfAllNumbers - countOfEvenNumbers.
        // Calculating the count of all elements in the collection is in most cases a constant-time operation (so it's very, very fast).

        public static bool AreThereFewerOddThanEvenNumbers_Refactored(IEnumerable<int> numbers)
        {
            //conteo de números pares
            var countOfEvenNumbers = numbers.Count(number => number % 2 == 0);
            //conteo de números impares
            var countOfOddNumbers = numbers.Count(number => number % 2 != 0);

            return countOfEvenNumbers > countOfOddNumbers;

        }

        #endregion

        

        // This method iterates over a nested collection of numbers - so a collection of collections of numbers.
        // For each of them, it calculates how many numbers are there.
        // If any of those collections is longer than the "maxLength" value, this method will return true.
        // Otherwise, it will return false.
        public static bool IsAnySequenceTooLong(IEnumerable<IEnumerable<int>> numberSequences, int maxLength)
        {
            foreach (var numberSequence in numberSequences)
            {
                var count = 0;
                foreach (var number in numberSequence)
                {
                    ++count;
                }
                if (count > maxLength)
                {
                    return true;
                }
            }
            return false;
        }

        // In other words, we want to check if for any of those collections the count is larger than the "maxCount".
        // We need to use two LINQ methods: Any and Count:
        public static bool IsAnySequenceTooLong_Refactored(IEnumerable<IEnumerable<int>> numberSequences, int maxLength)
        {
            return numberSequences.Any(numberSequence => numberSequence.Count() > maxLength);
        }

    }
}
