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
        public void TestAddAnimalsToWagons()
        {
            AnimalGenerator generator = new AnimalGenerator((int)DateTime.Now.Ticks);
            PlatformManager manager = new PlatformManager();

            List<Animal> animalList = new List<Animal>(50);
            for (int i = 0; i < 50; i++)
            {
                animalList.Add(generator.GetRandomAnimal());
            }
            manager.AddAnimalList(animalList);

            List<List<Animal>> animalGroupList = manager.GetAnimalGroups();

            Train train = new Train(animalGroupList.Count);
            foreach (List<Animal> animalGroup in animalGroupList)
            {
                train.AddAnimalGroupToWagon(animalGroup);
            }

            bool actual = true;
            for (int i = 0; i < animalGroupList.Count; i++)
            {
                ReadOnlyCollection<Animal> wagonAnimalList = train.GetAnimalListFromWagon(i);
                List<Animal> animalGroup = animalGroupList[i];

                bool equal = true;
                for (int animalIndex = 0; animalIndex < animalGroup.Count - 1; animalIndex++)
                {
                    if (!animalGroup[animalIndex].Equals(wagonAnimalList[animalIndex]))
                    {
                        equal = false;
                        break;
                    }
                }

                if (!equal)
                {
                    actual = false;
                    break;
                }
            }

            Assert.AreEqual(true, actual);
        }
    }
}