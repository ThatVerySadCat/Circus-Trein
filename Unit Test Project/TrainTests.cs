using System;
using System.Text;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Circus_Trein;

namespace Unit_Test_Project
{
    [TestClass]
    public class TrainTests
    {
        [TestMethod]
        public void AddAnimalCarnivoreTest()
        {
            Animal carnivore = new Animal(Diet.Carnivore, Size.Small);
            Train train = new Train();

            train.AddAnimal(carnivore);

            Assert.AreEqual(1, train.CarnivoreCount);
        }

        [TestMethod]
        public void AddAnimalHerbivoreTest()
        {
            Animal herbivore = new Animal(Diet.Herbivore, Size.Small);
            Train train = new Train();

            train.AddAnimal(herbivore);

            Assert.AreEqual(1, train.HerbivoreCount);
        }

        [TestMethod]
        public void AddPlaceAnimalsTest()
        {
            AnimalGenerator generator = new AnimalGenerator();
            List<Animal> animals = generator.GetRandomAnimals(50);
            Train train = new Train();

            train.AddAnimals(animals);
            train.PlaceAnimals();
        }
    }
}