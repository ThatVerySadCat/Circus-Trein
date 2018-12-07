using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Circus_Trein;

namespace Unit_Test_Project
{
    [TestClass]
    public class PlatformManagerTests
    {
        [TestMethod]
        public void TestAddAnimal()
        {
            PlatformManager manager = new PlatformManager();
            AnimalGenerator generator = new AnimalGenerator((int)DateTime.Now.Ticks);
            Animal testAnimal = generator.GetRandomAnimal();

            manager.AddAnimal(testAnimal);

            bool containsAnimal = manager.AnimalList.Contains(testAnimal) && (manager.AnimalCount == 1);
            Assert.AreEqual(true, containsAnimal);
        }

        [TestMethod]
        public void TestAddAnimalList()
        {
            PlatformManager manager = new PlatformManager();
            AnimalGenerator generator = new AnimalGenerator((int)DateTime.Now.Ticks);
            List<Animal> testList = new List<Animal>(50);

            for(int i = 0; i < 50; i++)
            {
                testList.Add(generator.GetRandomAnimal());
            }

            manager.AddAnimalList(testList);

            bool listContainsSameAnimals = true;
            ReadOnlyCollection<Animal> managerAnimalCollection = manager.AnimalList;
            foreach (Animal animal in testList)
            {
                if(!managerAnimalCollection.Contains(animal))
                {
                    listContainsSameAnimals = false;
                    break;
                }
            }

            bool countsAreEqual = testList.Count == manager.AnimalList.Count;

            Assert.AreEqual(true, listContainsSameAnimals && countsAreEqual);
        }

        [TestMethod]
        public void TestGetAnimalGroupsAllAnimalsPlaced()
        {
            AnimalGenerator generator = new AnimalGenerator((int)DateTime.Now.Ticks);
            PlatformManager manager = new PlatformManager();

            int expectedAnimalCount = 50;

            List<Animal> animalList = new List<Animal>(expectedAnimalCount);
            for(int i = 0; i < expectedAnimalCount; i++)
            {
                animalList.Add(generator.GetRandomAnimal());
            }
            manager.AddAnimalList(animalList);

            List<List<Animal>> animalGroupList = manager.GetAnimalGroups();
            int actualAnimalCount = 0;
            animalGroupList.ForEach(x => actualAnimalCount += x.Count);

            Assert.AreEqual(expectedAnimalCount, actualAnimalCount);
        }

        [TestMethod]
        public void TestGetAnimalGroupsCarnivoreKillingPrevention()
        {
            AnimalGenerator generator = new AnimalGenerator((int)DateTime.Now.Ticks);
            PlatformManager manager = new PlatformManager();

            List<Animal> animalList = new List<Animal>(50);
            for(int i = 0; i < 50; i++)
            {
                animalList.Add(generator.GetRandomAnimal());
            }
            manager.AddAnimalList(animalList);

            List<List<Animal>> animalGroupList = manager.GetAnimalGroups();
            bool actual = false;
            foreach(List<Animal> animalGroup in animalGroupList)
            {
                List<Animal> carnivoresInGroup = animalGroup.FindAll(x => x.Diet == Diet.carnivore);
                foreach(Animal carnivore in carnivoresInGroup)
                {
                    if(animalGroup.Find(x => x.Size <= carnivore.Size) != null)
                    {
                        actual = true;
                        break;
                    }
                }

                if(actual)
                {
                    break;
                }
            }

            Assert.AreEqual(true, actual);
        }
        
        [TestMethod]
        public void TestGetAnimalGroupsMaximumSize()
        {
            AnimalGenerator generator = new AnimalGenerator((int)DateTime.Now.Ticks);
            PlatformManager manager = new PlatformManager();

            List<Animal> animalList = new List<Animal>(50);
            for(int i = 0; i < 50; i++)
            {
                animalList.Add(generator.GetRandomAnimal());
            }
            manager.AddAnimalList(animalList);

            bool actual = true;

            List<List<Animal>> animalGroupList = manager.GetAnimalGroups();
            foreach(List<Animal> animalGroup in animalGroupList)
            {
                int groupSize = 0;
                animalGroup.ForEach(x => groupSize += (int)x.Size);

                if(groupSize > 10)
                {
                    actual = false;
                    break;
                }
            }

            Assert.AreEqual(true, actual);
        }
    }
}
