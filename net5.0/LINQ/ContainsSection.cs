using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NET5.LINQ
{
    public class ContainsSection
    {


        #region IsAppointmentDateAvailable
        // This method takes two parameters: date of an appointment, and existingAppointmentDates,which is a collection of dates that are already taken.
        // This method should return true only if the date is not amongst the existingAppointmentDates.
        //For example, for the following existingAppointmentDates: new DateTime(2022, 1, 11), new DateTime(2022, 1, 12)
        // ...and the date parameter equal to new DateTime(2022, 1, 10), the result shall be true, because the date is not present in the existingAppointmentDates.

        // On the other hand, for the following existingAppointmentDates new DateTime(2022, 1, 11), new DateTime(2022, 1, 10)
        // ...and the date parameter equal to new DateTime(2022, 1, 10), the result shall be false, because the date is present in the existingAppointmentDates.
        public static bool IsAppointmentDateAvailable(DateTime date, IEnumerable<DateTime> existingAppointmentDates)
        {
            return !existingAppointmentDates.Contains(date);
        }
        #endregion


        #region CountFriendsOf
        // Implement the CountFriendsOf method. This method takes the friend parameter and a collection of people.
        // We want to count all those people, who have friend amongst their friends.

        // For example, in this case, the result of the method should be 3 because there are 3 people who have friend in their Friends collection.
        // We need to count all those people, for whom the Friends collection contains friend parameter.
        // We will use Count and Contains LINQ methods.
        public static int CountFriendsOf(Friend friend, IEnumerable<Person> people)
        {
            return people.Count(person => person.Friends.Contains(friend));
        }

        public class Person
        {
            public string Name { get; }
            public IEnumerable<Friend> Friends { get; }

            public Person(string name, IEnumerable<Friend> friends)
            {
                Name = name;
                Friends = friends;
            }
        }

        public class Friend
        {

        }

        #endregion


        #region ContainsBannedWords

        // This method iterates the words collection. For each word, it checks (by using the inner loop) if it is equal to any words in the bannedWords collection.
        // in other words, it checks if any of the words belong to the bannedWords collection.
        public static bool ContainsBannedWords(IEnumerable<string> words, IEnumerable<string> bannedWords)
        {
            foreach (var word in words)
            {
                foreach (var bannedWord in bannedWords)
                {
                    if (word == bannedWord)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        // The refactored code could use Any and Contains LINQ methods.
        // This method checks if any of the words are contained within bannedWords collection.
        public static bool ContainsBannedWords_Refactored(IEnumerable<string> words, IEnumerable<string> bannedWords)
        {
            return words.Any(word => bannedWords.Contains(word));
        }

        #endregion

    }


}
