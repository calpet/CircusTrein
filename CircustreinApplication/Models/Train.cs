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

        public void SortInWagons(List<Animal> animals)
        {
            foreach (var animal in animals)
            {
                var availableWagon = CheckIfWagonAvailable(animal);
                if (availableWagon != null)
                {
                    availableWagon.AddAnimalToWagon(animal);
                }
                else
                {
                    availableWagon = new Wagon(animal.Diet, animal.Size);
                    Wagons.Add(availableWagon);
                    availableWagon.AddAnimalToWagon(animal);
                }
            }
        }

        public Wagon CheckIfWagonAvailable(Animal animal)
        {
            foreach (var wagon in Wagons)
            {
                if (wagon.IsAnimalCompatible(animal) && wagon.DoesAnimalFitWagon(animal) || wagon.CompatibleSize == 0 && wagon.CompatibleDiet == 0)
                {
                    _wagon = wagon;
                    break;
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
