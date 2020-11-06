using System.Collections.Generic;
using CircustreinApplication;
using CircustreinApplication.Models;
using CircusTreinViewModels;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using NUnit.Framework;

namespace CircusTreinUnitTests
{
    public class Tests
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

        [Test]
        public void Train_HasOneFullWagon()
        {
            //Arrange: 
            _animals = _algo.GenerateSpecificAnimals(Size.Small, Diet.Carnivore, 10);

            //Act:
            _train.SortInWagons(_animals);

            //Assert:
            Assert.AreEqual(1, _train.Wagons.Count);
        }
    }
}