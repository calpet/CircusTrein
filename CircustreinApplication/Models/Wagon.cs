using System;
using System.Collections.Generic;
using System.Text;

namespace CircustreinApplication.Models
{
    public class Wagon
    {
        public int Capacity { get; private set; }
        public List<Animal> Animals { get; set; }
        public Diet CompatibleWith { get; set; }

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
                CompatibleWith = animal.Diet;
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

            for (int i = 0; i < Animals.Count; i++)
            {
                if (animal.Size == Animals[i].Size && animal.Diet == CompatibleWith)
                {
                    isCompatible = true;
                } 
                else if (animal.Size != Animals[i].Size && animal.Diet == Diet.Herbivore && CompatibleWith == Diet.Herbivore)
                {
                    isCompatible = true;
                }
                else
                {
                    isCompatible = false;
                }
            }

            return isCompatible;
        }





    }
}
