using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET5.LINQ.Shared
{
    public class Pet: IComparable<Pet>
    {
        public int Id { get; }
        public string Name { get; }
        public PetType PetType { get; }
        public float Weight { get; }

        public Pet(int id, string name, PetType petType, float weight)
        {
            Id = id;
            Name = name;
            PetType = petType;
            Weight = weight;
        }


        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Type: {PetType}, Weight: {Weight}";
        }

        // Implemented the Compare method this way that two pets will be compared by weight
        public int CompareTo(Pet other)
        {
            return Weight.CompareTo(other.Weight);
        }
    }
}
