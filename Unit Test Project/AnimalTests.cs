using Microsoft.VisualStudio.TestTools.UnitTesting;
using Circus_Trein;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_Test_Project
{
    [TestClass]
    public class AnimalTests
    {
        [TestMethod()]
        public void CompareToTrueTest()
        {
            Animal animal1 = new Animal(Diet.Herbivore, Size.Large);
            Animal animal2 = new Animal(Diet.Herbivore, Size.Large);

            bool expected = true;
            bool actual = animal1.CompareTo(animal2) == 0;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CompareToFalseTest()
        {
            Animal animal1 = new Animal(Diet.Carnivore, Size.Large);
            Animal animal2 = new Animal(Diet.Herbivore, Size.Large);

            bool expected = false;
            bool actual = animal1.CompareTo(animal2) == 1;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SortAnimalListTest()
        {
            AnimalGenerator generator = new AnimalGenerator();
            List<Animal> animals = generator.GetRandomAnimals(50);

            animals.Sort();

            int largestAnimalSize = (int)animals[0].Size;
            bool actual = true;
            foreach(Animal animal in animals)
            {
                int currentAnimalSize = (int)animal.Size;
                if(currentAnimalSize > largestAnimalSize)
                {
                    actual = false;
                    break;
                }

                largestAnimalSize = currentAnimalSize;
            }

            Assert.AreEqual(true, actual);
        }
    }
}