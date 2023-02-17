using System.Collections.Generic;


namespace NET5.LINQ.Shared
{
    public class Person
    {
        public int Id { get; }
        public string Name { get; }
        public IEnumerable<Pet> Pets;

        public Person(int id, string name, IEnumerable<Pet> pets)
        {
            Id = id;
            Name = name;
            Pets = pets;
        }
    }
}
