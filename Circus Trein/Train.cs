using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circus_Trein
{
    public class Train
    {
        /// <summary>
        /// A list containing the wagons that are a part of the train.
        /// </summary>
        private List<Wagon> wagonList = new List<Wagon>();

        /// <summary>
        /// Instantiate the Train object with the given amount of wagons.
        /// </summary>
        /// <param name="wagonCount">The amount of wagons to create.</param>
        public Train(int wagonCount)
        {
            for(int i = 0; i < wagonCount; i++)
            {
                wagonList.Add(new Wagon());
            }
        }

        /// <summary>
        /// Returns a ReadOnlyCollection containing the animals found in the wagon with the given wagonIndex.
        /// </summary>
        /// <param name="wagonIndex">The position of the wagon in the wagon list to access.</param>
        /// <returns>A ReadOnlyCollection containing the animals found in the desired wagon.</returns>
        public ReadOnlyCollection<Animal> GetAnimalListFromWagon(int wagonIndex)
        {
            return wagonList[wagonIndex].AnimalList;
        }

        /// <summary>
        /// Adds the given group of animals to the first wagon containing no animals.
        /// </summary>
        /// <param name="animalGroup">The group of animals to add.</param>
        public void AddAnimalGroupToWagon(List<Animal> animalGroup)
        {
            foreach(Wagon wagon in wagonList)
            {
                if(!wagon.ContainsAnimals)
                {
                    foreach(Animal animal in animalGroup)
                    {
                        wagon.AddAnimal(animal);
                    }

                    break;
                }
            }
        }
    }
}
