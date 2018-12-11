using System;
using System.Collections.Generic;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Circus_Trein;

namespace Unit_Test_Project
{
    [TestClass]
    public class WagonTests
    {
        [TestMethod]
        public void CanAnimalBeAddedHerbivoreSameWeightTest()
        {
            Wagon wagon = new Wagon();
            Animal herbivore1 = new Animal(Diet.Herbivore, Size.Small);
            Animal herbivore2 = new Animal(Diet.Herbivore, Size.Small);

            wagon.AddAnimal(herbivore1);
            bool actual = wagon.CanAnimalBeAdded(herbivore2);

            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        public void CanAnimalBeAddedSmallHerbivoreLargeHerbivore()
        {
            Animal smallHerbivore = new Animal(Diet.Herbivore, Size.Small);
            Animal largeHerbivore = new Animal(Diet.Herbivore, Size.Large);

            bool actual = CanAnimalFitAfterPlaced(smallHerbivore, largeHerbivore);

            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        public void CanAnimalBeAddedLargeHerbivoreSmallHerbivoreTest()
        {
            Animal largeHerbivore = new Animal(Diet.Herbivore, Size.Large);
            Animal smallHerbivore = new Animal(Diet.Herbivore, Size.Small);

            bool actual = CanAnimalFitAfterPlaced(largeHerbivore, smallHerbivore);

            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        public void CanAnimalBeAddedCarnivoreSameWeightTest()
        {
            Wagon wagon = new Wagon();
            Animal carnivore1 = new Animal(Diet.Carnivore, Size.Small);
            Animal carnivore2 = new Animal(Diet.Carnivore, Size.Small);

            wagon.AddAnimal(carnivore1);
            bool actual = wagon.CanAnimalBeAdded(carnivore2);

            Assert.AreEqual(false, actual);
        }

        [TestMethod]
        public void CanAnimalBeAddedCarnivoreDifferentWeightTest()
        {
            Animal smallCarnivore = new Animal(Diet.Carnivore, Size.Small);
            Animal largeCarnivore = new Animal(Diet.Carnivore, Size.Large);

            bool actual = CanAnimalFitAfterPlaced(smallCarnivore, largeCarnivore);

            Assert.AreEqual(false, actual);
        }

        [TestMethod]
        public void CanAnimalBeAddedLargeCarnivoreSmallCarnivoreTest()
        {
            Animal largeCarnivore = new Animal(Diet.Carnivore, Size.Large);
            Animal smallCarnivore = new Animal(Diet.Carnivore, Size.Small);

            bool actual = CanAnimalFitAfterPlaced(largeCarnivore, smallCarnivore);

            Assert.AreEqual(false, actual);
        }

        [TestMethod]
        public void CanAnimalBeAddedMixedDietHerbivoreCarnivoreTest()
        {
            Animal herbivore = new Animal(Diet.Herbivore, Size.Small);
            Animal carnivore = new Animal(Diet.Carnivore, Size.Small);

            bool actual = CanAnimalFitAfterPlaced(herbivore, carnivore);

            Assert.AreEqual(false, actual);
        }

        [TestMethod]
        public void CanAnimalBeAddedMixedDietCarnivoreHerbivoreTest()
        {
            Animal carnivore = new Animal(Diet.Carnivore, Size.Small);
            Animal herbivore = new Animal(Diet.Herbivore, Size.Small);

            bool actual = CanAnimalFitAfterPlaced(carnivore, herbivore);

            Assert.AreEqual(false, actual);
        }

        [TestMethod]
        public void CanAnimalBeAddedMixedDietSmallHerbivoreLargeCarnivoreTest()
        {
            Animal smallHerbivore = new Animal(Diet.Herbivore, Size.Small);
            Animal largeCarnivore = new Animal(Diet.Carnivore, Size.Large);
            
            bool actual = CanAnimalFitAfterPlaced(smallHerbivore, largeCarnivore);

            Assert.AreEqual(false, actual);
        }

        [TestMethod]
        public void CanAnimalBeAddedMixedDietLargeCarnivoreSmallHerbivoreTest()
        {
            Animal largeCarnivore = new Animal(Diet.Carnivore, Size.Large);
            Animal smallHerbivore = new Animal(Diet.Herbivore, Size.Small);

            bool actual = CanAnimalFitAfterPlaced(largeCarnivore, smallHerbivore);

            Assert.AreEqual(false, actual);
        }

        [TestMethod]
        public void CanAnimalBeAddedMixedDietLargeHerbivoreSmallCarnivoreTest()
        {
            Animal largeHerbivore = new Animal(Diet.Herbivore, Size.Large);
            Animal smallCarnivore = new Animal(Diet.Carnivore, Size.Small);
            
            bool actual = CanAnimalFitAfterPlaced(largeHerbivore, smallCarnivore);

            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        public void CanAnimalBeAddedMixedDietSmallCarnivoreLargeHerbivoreTest()
        {
            Animal smallCarnivore = new Animal(Diet.Carnivore, Size.Small);
            Animal largeHerbivore = new Animal(Diet.Herbivore, Size.Large);

            bool actual = CanAnimalFitAfterPlaced(smallCarnivore, largeHerbivore);

            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        public void CanAnimalBeAddedWeightSuccessTest()
        {
            Animal animal1 = new Animal(Diet.Herbivore, Size.Large);
            Animal animal2 = new Animal(Diet.Herbivore, Size.Large);

            bool actual = CanAnimalFitAfterPlaced(animal1, animal2);

            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        public void CanAnimalBeAddedWeightFailureTest()
        {
            Animal animal1 = new Animal(Diet.Herbivore, Size.Large);
            Animal animal2 = new Animal(Diet.Herbivore, Size.Large);
            Animal animal3 = new Animal(Diet.Herbivore, Size.Small);

            Wagon wagon = new Wagon();
            wagon.AddAnimal(animal1);
            wagon.AddAnimal(animal2);
            bool actual = wagon.CanAnimalBeAdded(animal3);

            Assert.AreEqual(false, actual);
        }

        private bool CanAnimalFitAfterPlaced(Animal animalToPlace, Animal animalToCheck)
        {
            Wagon wagon = new Wagon();
            wagon.AddAnimal(animalToPlace);
            return wagon.CanAnimalBeAdded(animalToCheck);
        }
    }
}
