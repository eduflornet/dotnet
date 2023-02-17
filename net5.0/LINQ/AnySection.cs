using NET5.LINQ.Shared;
using System.Collections.Generic;
using System.Linq;



namespace NET5.LINQ
{
    public class AnySection
    {
        // check if any number in the collection is smaller than 0

        #region IsAnyNumberNegative

        public static bool IsAnyNumberNegative(IEnumerable<int> numbers)
        {
            return numbers.Any(number => number < 0);
        }

        #endregion


        // check if in the collection of Pets there is a cat that weighs over 2 kilos

        #region AreThereAnyBigCats

        public static bool AreThereAnyBigCats(IEnumerable<Pet> pets)
        {
            return pets.Any(pet => pet.PetType == PetType.Cat && pet.Weight > 2);
        }

        #endregion
        // We can use Any to check if there are any invalid names in the collection.
        // If there are none, it means all names in the collection are valid.
        // That's why we need to negate the result produced by the Any method:
        // Now this method checks,
        // if there are not any names in this collection which are not valid,
        // which is logically equivalent to checking if all names in the collection are valid.
        #region AreAllNamesValid_Refactored
        public static bool AreAllNamesValid_Refactored(string[] names)
        {
            return !names.Any(name => char.IsLower(name[0]) || name.Length < 2 || name.Length > 25);
            
        }
        #endregion

        // This code check if all names are valid.
        // To be valid, the name can't start with the lower case,
        // can't be shorter than 2 characters, and can't be longer than 25 characters.

        #region AreAllNamesValid
        public static bool AreAllNamesValid(string[] names)
        {
            foreach (string name in names)
            {
                if (char.IsLower(name[0]))
                {
                    return false;
                }

                if (name.Length < 2)
                {
                    return false;
                }


                if (name.Length > 25)
                {
                    return false;
                }

            }
            return true;
        }

        #endregion
    }
}
