using System;
using System.Collections.Generic;
using System.Text;

namespace CircustreinApplication.Models
{
    public class Wagon
    {
        private bool _isCompatible;
        public int Capacity { get; private set; }
        public List<Animal> Animals { get; private set; }
        public Diet CompatibleDiet { get; private set; }
        public Size CompatibleSize { get; private set; }

        public Wagon()
        {
            Capacity = 10;
            Animals = new List<Animal>();
            CompatibleSize = 0;
            CompatibleDiet = 0;
        }

        public Wagon(Diet compDiet, Size compSize)
        {
            Capacity = 10;
            Animals = new List<Animal>();
            CompatibleDiet = compDiet;
            CompatibleSize = compSize;
        }

        public void AddAnimalToWagon(Animal animal)
        {
            if (Animals.Count == 0)
            {
                Animals.Add(animal);
                Capacity -= Convert.ToInt32(animal.Size);
                CompatibleDiet = animal.Diet;
                CompatibleSize = animal.Size;
            }
            else if (Animals.Count != 0 && DoesAnimalFitWagon(animal))
            {
                Animals.Add(animal);
                Capacity -= Convert.ToInt32(animal.Size);
            }
        }

        public bool DoesAnimalFitWagon(Animal animal)
        {
            return Capacity - animal.Size >= 0;
        }

        public bool IsAnimalCompatible(Animal animal)
        {
            if (animal.Size == CompatibleSize && animal.Diet == CompatibleDiet || CompatibleSize == 0 && CompatibleDiet == 0)
            {
                _isCompatible = true;
            } 
            else if (animal.Size != CompatibleSize && animal.Diet == Diet.Herbivore && CompatibleDiet == Diet.Herbivore)
            {
                _isCompatible = true;
            }
            else
            {
                _isCompatible = false;
            }

            return _isCompatible;
        }





    }
}
