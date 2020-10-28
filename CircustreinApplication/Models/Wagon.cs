using System;
using System.Collections.Generic;
using System.Text;

namespace CircustreinApplication.Models
{
    public class Wagon
    {
        public int Capacity { get; private set; }
        public List<Animal> Animals { get; set; }

        public Wagon()
        {
            Capacity = 10;
            Animals = new List<Animal>();
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
                if (animal.Size == Animals[i].Size && animal.Diet == Animals[i].Diet)
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
