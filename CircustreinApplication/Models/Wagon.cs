using System;
using System.Collections.Generic;
using System.Text;

namespace CircustreinApplication.Models
{
    public class Wagon
    {
        public int Capacity { get; private set; }
        public List<Animal> Animals { get; set; }
        public Diet CompatibleDiet { get; set; }
        public Size CompatibleSize { get; set; }

        public Wagon()
        {
            Capacity = 10;
            Animals = new List<Animal>();
        }

        public void AddToWagon(Animal animal)
        {
            if (Animals.Count == 0)
            {
                Animals.Add(animal);
                Capacity -= Convert.ToInt32(animal.Size);
                CompatibleDiet = animal.Diet;
                CompatibleSize = animal.Size;
            }
            else if (Animals.Count != 0 && CheckWagonCapacity(animal))
            {
                Animals.Add(animal);
                Capacity -= Convert.ToInt32(animal.Size);
            }
        }

        public bool CheckWagonCapacity(Animal animal)
        {
            return Capacity - animal.Size >= 0;
        }

        public bool AnimalIsCompatible(Animal animal)
        {
            bool isCompatible = true;

            if (animal.Size == CompatibleSize && animal.Diet == CompatibleDiet)
            {
                isCompatible = true;
            } 
            else if (animal.Size != CompatibleSize && animal.Diet == Diet.Herbivore && CompatibleDiet == Diet.Herbivore)
            {
                isCompatible = true;
            }
            else
            {
                isCompatible = false;
            }

            return isCompatible;
        }





    }
}
