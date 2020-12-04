using System.Collections.Generic;
using CircustreinApplication;
using CircustreinApplication.Models;
using CircusTreinViewModels;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using NUnit.Framework;

namespace CircusTreinUnitTests
{
    public class TrainTests
    {
        private AlgorithmViewModel _algo;
        private Train _train;
        private List<Animal> _animals;

        [SetUp]
        public void Setup()
        {
            //Arrange:
            _train = new Train();
            _algo = new AlgorithmViewModel();
        }

        /// <summary>
        /// Naming convention: [methodName]_[input]_[expectedOutput]()
        /// </summary>

        [Test]
        public void SortInWagons_10SmallCarnivores_TrainHasOneFullWagon()
        {
            //Arrange: 
            _animals = _algo.GenerateSpecificAnimals(Size.Small, Diet.Carnivore, 10);

            //Act:
            _train.SortInWagons(_animals);

            //Assert:
            Assert.AreEqual(1, _train.Wagons.Count);
        }

        [Test]
        public void SortInWagons_5SmallCarnivores5SmallHerbivores_TrainHasTwoWagons()
        {
            //Arrange:
            _animals = _algo.GenerateSpecificAnimals(Size.Small, Diet.Carnivore, 5);
            _animals.AddRange(_algo.GenerateSpecificAnimals(Size.Small, Diet.Herbivore, 5));

            //Act:
            _train.SortInWagons(_animals);

            //Assert:
            Assert.AreEqual(2, _train.Wagons.Count);
        }

        [Test]
        public void Train_HasWagonAvailable()
        {
            //Arrange:
            _animals = _algo.GenerateSpecificAnimals(Size.Medium, Diet.Herbivore, 2);
            
            //Act:
            _train.SortInWagons(_animals);
            var wagon = _train.CheckIfWagonAvailable(_algo.GenerateSpecificAnimals(Size.Small, Diet.Herbivore, 1)[0]);

            //Assert:
            Assert.IsNotNull(wagon);
        }

        [Test]
        public void Train_HasNoWagonsAvailable()
        {
            //Arrange:
            _animals = _algo.GenerateSpecificAnimals(Size.Medium, Diet.Carnivore, 2);


            //Act:
            _train.SortInWagons(_animals);
            var wagon = _train.CheckIfWagonAvailable(_algo.GenerateSpecificAnimals(Size.Small, Diet.Herbivore, 1)[0]);

            //Assert:
            Assert.IsNull(wagon);
        }
    }
}