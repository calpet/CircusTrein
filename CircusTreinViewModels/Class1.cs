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

        public AlgorithmViewModel()
        {
            _animal = new Animal();
            _collection = new AnimalCollection();
            _wagon = new Wagon();
            _train = new Train();
        }

        public Train StartAlgorithms(List<Animal> animals)
        {
            var sortedList = _collection.SortBySize(animals);
            _train.SortInWagons(sortedList);

            return _train;
        }
    }
}
