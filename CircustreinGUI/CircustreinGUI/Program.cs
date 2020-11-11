using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using CircustreinApplication;
using CircustreinApplication.Models;
using CircusTreinViewModels;

namespace CircustreinGUI
{
    public class Program
    {
        private static AlgorithmViewModel _algo = new AlgorithmViewModel();
        private static List<Animal> _animals = new List<Animal>();

        static void Main(string[] args)
        {
            _algo = new AlgorithmViewModel(); 
            _animals = _algo.GenerateRandomAnimals(214);
            var train = Submit(_animals);
            Result(train);
        }

        public static Train Submit(List<Animal> animals)
        {
            return _algo.StartAlgorithms(animals);
        }

        public static void Result(Train train)
        {
            var wagons = train.Wagons;
            for (int i = 0; i < wagons.Count; i++)
            {
                foreach (var w in wagons)
                {
                    foreach (var animal in w.Animals)
                    {
                        Console.WriteLine(animal);
                    }

                    Console.WriteLine("\nWagon Capacity: " + w.Capacity);
                }
            }
        }
    }
}
