using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CircustreinApplication
{
    public class AnimalCollection
    {
        public List<Animal> SortBySize(List<Animal> animals)
        {
            return animals.OrderByDescending(x => x.Size).ToList();
        }
    }
}
