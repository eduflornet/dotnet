using NET5.LINQ.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET5.LINQ
{
    public class OrderBySection
    {

    }

    public class PetByTypeComparer : IComparer<Pet>
    {
        public int Compare(Pet x, Pet y)
        {
            return x.PetType.CompareTo(y.PetType);
        }
    }



}
