using System;
using System.Collections.Generic;
using System.Text;

namespace CircustreinApplication.Models
{
    public class Wagon
    {
        public int Capacity { get; private set; }
        public List<Animal> Animals { get; set; }
        public Diet AnimalDiet { get; set; }

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
                AnimalDiet = animal.Diet;
            }
            else
            {
                Animals.Add(animal);
            }
        }

        public bool CheckWagonCapacity(Animal animal)
        {
            if (Capacity - animal.Size > 0)
            {
                Animals.Add(animal);
                Capacity -= Convert.ToInt32(animal.Size);
                return true;
            }

            return false;
        }

        public bool AnimalIsCompatible(Animal animal)
        {
            bool isCompatible = false;
            for (int i = 0; i < Animals.Count; i++)
            {
                if (animal.Size == Animals[i].Size && animal.Diet == AnimalDiet)
                {
                    isCompatible = true;
                } 
                else if (animal.Size != Animals[i].Size && animal.Diet == Diet.Herbivore && AnimalDiet == Diet.Herbivore)
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
