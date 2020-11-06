using System;
using System.Collections.Generic;
using System.Text;

namespace CircustreinApplication.Models
{
    public class Train
    {
        public List<Wagon> Wagons { get; private set; }
        private Wagon _wagon;

        public Train()
        {
            Wagons = new List<Wagon>();
            _wagon = new Wagon();
            Wagons.Add(_wagon);
        }

        public bool SortInWagons(List<Animal> animals)
        {
            bool isSorted = false;
            foreach (var animal in animals)
            {
                var availableWagon = CheckIfWagonAvailable(animal);
                if (availableWagon != null)
                {
                    availableWagon.AddToWagon(animal);
                    isSorted = true;
                }
                else
                {
                    availableWagon = new Wagon();
                    Wagons.Add(availableWagon);
                    availableWagon.AddToWagon(animal);
                }
            }

            return isSorted;
        }

        public Wagon CheckIfWagonAvailable(Animal animal)
        {

            foreach (var wagon in Wagons)
            {
                if (wagon.AnimalIsCompatible(animal) && wagon.CheckWagonCapacity(animal))
                {
                    _wagon = wagon;
                }

                else
                {
                    _wagon = null;
                }

            }

            return _wagon;
        }


    }
}
