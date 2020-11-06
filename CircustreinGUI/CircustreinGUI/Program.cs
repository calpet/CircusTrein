using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using CircustreinApplication;
using CircustreinApplication.Models;
using CircusTreinViewModels;

namespace CircustreinGUI
{
    class Program
    {
        private static AlgorithmViewModel _algo = new AlgorithmViewModel();
        private static List<Animal> _animals = new List<Animal>();
        private static bool _started = true;
        static void Main(string[] args)
        {
            Random rDiet = new Random();
            Random rSize = new Random();
            Array dValues = Enum.GetValues(typeof(Diet));
            Array sValues = Enum.GetValues(typeof(Size));

            for (int i = 0; i < 16; i++)
            {
                Animal animal = new Animal() { Diet = (Diet)dValues.GetValue(rDiet.Next(dValues.Length)), Size = (Size)sValues.GetValue(rSize.Next(sValues.Length))};
                _animals.Add(animal);
            }

            var train = Submit(_animals);
            Result(train);
        }

        public static void Menu()
        {
            while (_started)
            {
                string size = "";
                Console.WriteLine("Please choose an animal size:\n1. Small\n2. Medium\n3. Large\n");
                string sizeInput = Console.ReadLine();

                if (sizeInput == "1")
                {
                    size = "Small";
                }
                else if (sizeInput == "2")
                {
                    size = "Medium";
                }
                else if (sizeInput == "3")
                {
                    size = "Large";
                }
                else
                {
                    Console.WriteLine("Please choose 1, 2 or 3.\n");
                }

                string diet = "";
                Console.WriteLine("Please choose an animal diet\n1. Carnivore\n2. Herbivore");
                string dietInput = Console.ReadLine();

                if (dietInput == "1")
                {
                    diet = "Carnivore";
                }
                else if (dietInput == "2")
                {
                    diet = "Herbivore";
                }

                string isFinished;
                Console.WriteLine("Are you finished? Y/N");
                isFinished = Console.ReadLine();

                if (isFinished == "Y" || isFinished == "y")
                {
                    _started = false;
                    CreateAnimal(size, diet);
                    var train = Submit(_animals);
                    Result(train);

                }
                else
                {
                    CreateAnimal(size, diet);
                    _started = true;
                }
            }


        }

        public static void CreateAnimal(string size, string diet)
        {
            Animal animal = new Animal() { Size = Enum.Parse<Size>(size), Diet = Enum.Parse<Diet>(diet) };
            _animals.Add(animal);
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
                    Console.WriteLine("\nWagon Compatibility: " + w.CompatibleWith + "\n");
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
