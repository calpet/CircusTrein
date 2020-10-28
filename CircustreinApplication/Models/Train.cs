using System;
using System.Collections.Generic;
using System.Text;

namespace CircustreinApplication.Models
{
    public class Train
    {
        private int _totalWagons;
        public List<Wagon> Wagons { get; private set; }

        public Train()
        {
            Wagons = new List<Wagon>();
        }

        public bool SortInWagons(List<Animal> animals)
        {
            bool isSorted = false;
            foreach (var animal in animals)
            {
                var availableWagon = CheckIfWagonAvailable(animal);
                if (availableWagon != null)
                {
                    availableWagon.Animals.Add(animal);
                    isSorted = true;
                }
                else
                {
                    availableWagon = new Wagon();
                    availableWagon.Animals.Add(animal);
                }
            }

            return isSorted;
        }

        public Wagon CheckIfWagonAvailable(Animal animal)
        {
            Wagon available = null;

            foreach (var wagon in Wagons)
            {
                for (int i = 0; i < wagon.Animals.Count; i++)
                {
                    if (wagon.AnimalIsCompatible(animal) && wagon.CheckWagonCapacity(animal))
                    {
                        available = wagon;
                    }
                    
                    available = null;
                    
                }
            }

            return available;
        }


    }
}
