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
            Animal animal1 = new Animal(Diet.herbivore, Size.large);
            Animal animal2 = new Animal(Diet.herbivore, Size.large);

            bool expected = true;
            bool actual = animal1.CompareTo(animal2) == 0;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CompareToFalseTest()
        {
            Animal animal1 = new Animal(Diet.carnivore, Size.large);
            Animal animal2 = new Animal(Diet.herbivore, Size.large);

            bool expected = false;
            bool actual = animal1.CompareTo(animal2) == 1;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SortAnimalListTest()
        {
            AnimalGenerator generator = new AnimalGenerator((int)DateTime.Now.Ticks);
            List<Animal> animalList = new List<Animal>(50);

            for(int i = 0; i < 50; i++)
            {
                animalList.Add(generator.GetRandomAnimal());
            }

            animalList.Sort();
            animalList.Reverse();

            int lastAnimalSize = (int)animalList[0].Size;
            bool actual = true;
            foreach(Animal animal in animalList)
            {
                int currentAnimalSize = (int)animal.Size;
                if(currentAnimalSize > lastAnimalSize)
                {
                    actual = false;
                    break;
                }

                lastAnimalSize = currentAnimalSize;
            }

            Assert.AreEqual(true, actual);
        }
    }
}