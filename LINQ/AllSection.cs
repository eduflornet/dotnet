using NET5.LINQ.Shared;
using System;
using System.Collections.Generic;
using System.Linq;


namespace NET5.LINQ
{
    public class AllSection
    {


        #region AreAllNumbersDivisibleBy10
        // We simply should use the All method to check if all numbers are divisible by 10.
        // Remember, to check if a number is divisible by another number,
        // we can check if the modulo operation for them gives 0:
        public static bool AreAllNumbersDivisibleBy10(int[] numbers)
        {
            return numbers.All(number => number % 10 == 0);
        }

        #endregion


        #region AreAllPetsOfTheSameType_Refactored
        // This is perfectly fine, but we could be smarter about it.
        // With the next solution, if a new type of pet will be added to the PetType enum,
        // we would have to modify this method. We could access all enum values like this:
        // var allPetTypes = Enum.GetValues(typeof(PetType)).Cast<PetType>();

        // This way we check if for any of the PetTypes,
        // all pets are of this type. Now, if  new PetType is added, the code will still work correctly.

        public static bool AreAllPetsOfTheSameType_Refactored(IEnumerable<Pet> pets)
        {
            var allPetTypes = Enum.GetValues(typeof(PetType)).Cast<PetType>();

            return allPetTypes.Any(petType => pets.All(pet => pet.PetType == petType));

        }
        #endregion


        #region AreAllPetsOfTheSameType
        // To implement such a function, we need to check if:
        // all pets are Dogs, or
        // all pets are Cats, or
        // all pets are Fish
        public static bool AreAllPetsOfTheSameType(IEnumerable<Pet> pets)
        {
            return 
                pets.All(pet => pet.PetType == PetType.Dog) ||
                pets.All(pet => pet.PetType == PetType.Cat) ||
                pets.All(pet => pet.PetType == PetType.Fish);

        }

        #endregion


        #region AreAllWordsOfTheSameLength_Refactored
        //This method checks if all words in the input collection have the same length as the first word.
        //In other words - if all words in this collection have the same length.
        //nterestingly, this will also work correctly if the input is an empty List.
        //For empty collections, All return true.
        //Also, the lambda passed as an argument will never be executed (because it's executed for each element of the collection,
        //but there are none), which means no exception will be thrown when calling "words[0]," which would normally happen with an empty list.
        public static bool AreAllWordsOfTheSameLength_Refactored(List<string> words)
        {
            return words.All(word => word.Length == words[0].Length);
        }

        //do not modify this method
        public static bool AreAllWordsOfTheSameLength(List<string> words)
        {
            if (words.Count == 0 || words.Count == 1)
            {
                return true;
            }
            var length0 = words[0].Length;
            for (int i = 1; i < words.Count; ++i)
            {
                if (words[i].Length != length0)
                {
                    return false;
                }
            }
            return true;
        }

        #endregion
    }
}
