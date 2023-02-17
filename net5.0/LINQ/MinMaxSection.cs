using NET5.LINQ.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET5.LINQ
{
    public class MinMaxSection
    {
        #region LengthOfTheShortestWord
        // If the collection is empty, we want to return null.
        // We can check if the collection is not empty with the Any method.
        // If it's not, we want to use the Min method, to find the shortest word in the words collection:
        public static int? LengthOfTheShortestWord(IEnumerable<string> words)
        {
            return words.Any() ?
                words.Min(word => word.Length) : null;
        }

        #endregion

        #region CountOfLargestNumbers

        // method, which will check how many numbers in the collection are equal to the largest number in this collection.
        // For an empty collection, the result should be 0.
        // Implement the CountOfLargestNumbers method,
        // which will check how many numbers in the collection are equal to the largest number in this collection. For an empty collection, the result should be 0.
        // In this code, we count all those numbers, that are equal to the largest number in the collection.

        public static int CountOfLargestNumbers(IEnumerable<int> numbers)
        {
            return numbers.Count(number => number == numbers.Max());
        }

        #endregion


        #region CountOfDogsOfTheOwnerWithMostDogs
        // This method iterates over the collection of owners and counts the dogs of each owner. Then it stores the maximum count of dogs in the maxDogCount variable. In other words, it finds the count of dogs owned by the owner who has most dogs. For example, if we have owners like below:
        // John has a cat and 2 dogs
        // Mark has a dog and 3 fish
        // Monica has one ferret
        // Then the result of the CountOfDogsOfTheOwnerWithMostDogs will be 2 because the owner of most dogs owns 2 dogs.

        public static int CountOfDogsOfTheOwnerWithMostDogs(IEnumerable<Person> owners)
        {
            var maxDogCount = 0;
            foreach (var owner in owners)
            {
                var dogsCount = 0;
                foreach (var pet in owner.Pets)
                {
                    if (pet.PetType == PetType.Dog)
                    {
                        dogsCount++;
                    }
                }
                if (dogsCount > maxDogCount)
                {
                    maxDogCount = dogsCount;
                }
            }
            return maxDogCount;
        }

        // We can implement this in LINQ using two methods: Count and Max.
        // We need to find the count of the dogs for each of the owners, and then find a maximum of those values.
        public static int CountOfDogsOfTheOwnerWithMostDogs_Refactored(IEnumerable<Person> owners)
        {
            return owners.Max(
                owner => owner.Pets.Count(
                    pet => pet.PetType == PetType.Dog));
        }

        #endregion

    }


}

