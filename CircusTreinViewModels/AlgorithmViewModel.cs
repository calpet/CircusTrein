using System;
using System.Collections.Generic;
using CircustreinApplication;
using CircustreinApplication.Models;

namespace CircusTreinViewModels
{
    public class AlgorithmViewModel
    {
        private Animal _animal;
        private AnimalCollection _collection;
        private Wagon _wagon;
        private Train _train;
        private List<Animal> _animals;

        public AlgorithmViewModel()
        {
            _animal = new Animal();
            _collection = new AnimalCollection();
            _wagon = new Wagon();
            _train = new Train();
            _animals = new List<Animal>();
        }

        public Train StartAlgorithms(List<Animal> animals)
        {
            var sortedList = _collection.SortBySize(animals);
            _train.SortInWagons(sortedList);

            return _train;
        }

        public List<Animal> GenerateRandomAnimals(int amount)
        {
            Random rDiet = new Random();
            Random rSize = new Random();
            Array dValues = Enum.GetValues(typeof(Diet));
            Array sValues = Enum.GetValues(typeof(Size));

            for (int i = 0; i < amount; i++)
            {
                Animal animal = new Animal() { Diet = (Diet)dValues.GetValue(rDiet.Next(dValues.Length)), Size = (Size)sValues.GetValue(rSize.Next(sValues.Length)) };
                _animals.Add(animal);
            }

            return _animals;
        }

        public List<Animal> GenerateSpecificAnimals(Size size, Diet diet, int amount)
        {
            List<Animal> animals = new List<Animal>();

            for (int i = 0; i < amount; i++)
            {
                Animal animal = new Animal() { Size = size, Diet = diet};
                animals.Add(animal);
            }

            return animals;
        }
    }
}
