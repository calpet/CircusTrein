using System;
using System.Collections.Generic;
using System.Text;
using CircustreinApplication;
using CircustreinApplication.Models;
using CircusTreinViewModels;
using NUnit.Framework;

namespace CircusTreinUnitTests
{
    public class WagonTests
    {
        private AlgorithmViewModel _algo;
        private Wagon _wagon;
        private List<Animal> _animals;
        private Animal _animal;

        [SetUp]
        public void Setup()
        {
            //Arrange:
            _algo = new AlgorithmViewModel();
            _wagon = new Wagon();
        }

        [Test]
        public void Wagon_AnimalGetsAddedToEmptyWagon()
        {
            //Arrange: 
            _animal = new Animal() {Diet = Diet.Herbivore, Size = Size.Large};

            //Act:
            _wagon.AddToWagon(_animal);

            //Assert:
            Assert.AreEqual(5, _wagon.Capacity);
        }

        [Test]
        public void Animal_IsNotCompatibleWithOtherAnimalsInWagon()
        {
            //Arrange: 
            _animal = new Animal() {Diet = Diet.Carnivore, Size = Size.Large};

            //Act:
            _animals = _algo.GenerateSpecificAnimals(Size.Large, Diet.Herbivore, 2);
            Train train = _algo.StartAlgorithms(_animals);
            bool isCompatible = train.Wagons[0].CheckWagonCapacity(_animal);

            //Assert:
            Assert.IsFalse(isCompatible);
        }

    }
}
