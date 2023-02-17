using System;
using System.Collections.Generic;
using System.Linq;

namespace NET5.LINQ
{
    public class OrderBySection
    {

        #region OrderFromLongestToShortest
        // Since we want words to be ordered from longest to shortest, we need to use OrderByDescending method

        public static IEnumerable<string> OrderFromLongestToShortest(IEnumerable<string> words)
        {
            return words.OrderByDescending(x => x.Length);
        }

        #endregion


        #region FirstEvenThenOddDescending
        // first, the even numbers, then, the odd numbers
        // Within each of the group, the numbers should be ordered descending.For example, for numbers {1,2,3,4,5,6,7}
        // the result should be: {6,4,2,7,5,3,1}.
        // We need to use OrderBy and ThenByDescending methods. First, we need to order the numbers in such a way,
        // that even numbers come first. The important thing here is that in C# when ordering a collection by a boolean variable,
        // the false values come before true values. For example:
        // orderedBools will look like this: {false, true, true}.
        // We know that ordering by bool places the false values before true values.
        // We want the even numbers to come before odd numbers, so we want to order by such a boolean expression,
        // that will be false for even numbers and true for odd numbers.
        // This expression is "number % 2 !=0". Then, we must simply use ThenByDescending method to order the numbers in descending order.

        public static IEnumerable<int> FirstEvenThenOddDescending(IEnumerable<int> numbers)
        {
            return numbers.OrderBy(number => number % 2 != 0).ThenByDescending(number => number);
        }
        #endregion

        #region OrderByMonth 
        
        public static IEnumerable<DateTime> OrderByMonth(List<DateTime> dates)
        {
            dates.Sort((left, right) =>
            {
                return left.Month.CompareTo(right.Month);
            });
            return dates;
        }

        // This method uses List.Sort method to sort the input dates by month ascending.
        // Let's user LINQ's OrderBy, which will let us do the same, but without list modification:

        public static IEnumerable<DateTime> OrderByMonth_Refactored(List<DateTime> dates)
        {
            dates.Sort((left, right) =>
            {
                return left.Month.CompareTo(right.Month);
            });

            return dates;
        }

        #endregion


    }

}
