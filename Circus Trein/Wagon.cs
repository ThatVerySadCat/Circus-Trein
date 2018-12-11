using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circus_Trein
{
    public class Wagon
    {
        /// <summary>
        /// Does the wagon contain any animals?
        /// </summary>
        public bool ContainsAnimals
        {
            get
            {
                if(animals.Count > 0)
                {
                    return true;
                }

                return false;
            }
        }
        /// <summary>
        /// A ReadOnlyCollection containing all the animals found in the wagon.
        /// </summary>
        public ReadOnlyCollection<Animal> Animals
        {
            get
            {
                return new ReadOnlyCollection<Animal>(animals);
            }
        }

        /// <summary>
        /// A list containing all animals found in the wagon.
        /// </summary>
        private List<Animal> animals = new List<Animal>();

        /// <summary>
        /// The maximum allowed weight on a single wagon.
        /// </summary>
        private const int maxWeight = 10;

        public Wagon() { }

        /// <summary>
        /// Adds the given animal to the wagon.
        /// </summary>
        /// <param name="animal">The animal to add.</param>
        public void AddAnimal(Animal animal)
        {
            animals.Add(animal);
        }

        /// <summary>
        /// Can the given animal be added to this wagon?
        /// </summary>
        /// <param name="animal">The animal to check.</param>
        /// <returns></returns>
        public bool CanAnimalBeAdded(Animal animal)
        {
            int currentSize = GetWagonWeight();
            if(animal == null || currentSize + (int)animal.Size > maxWeight)
            {
                return false;
            }

            animals.Sort();
            
            Animal biggestCarnivore = animals.Find(findAnimal => findAnimal.Diet == Diet.Carnivore);
            if(animal.Diet == Diet.Carnivore && biggestCarnivore == null)
            {
                return CanCarnivoreBeAdded(animal);
            }
            else if(animal.Diet == Diet.Herbivore && (biggestCarnivore == null || (biggestCarnivore != null && animal.Size > biggestCarnivore.Size)))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Can the given carnivore be added to this wagon?
        /// </summary>
        /// <param name="carnivoreToCheck">The carnivore to check.</param>
        /// <returns></returns>
        private bool CanCarnivoreBeAdded(Animal carnivoreToCheck)
        {
            if(carnivoreToCheck.Diet != Diet.Carnivore)
            {
                return false;
            }

            Animal smallestHerbivore = null;
            foreach (Animal findAnimal in animals)
            {
                if (smallestHerbivore == null || findAnimal.Size < smallestHerbivore.Size)
                {
                    smallestHerbivore = findAnimal;
                    if (smallestHerbivore.Size == Size.Small)
                    {
                        break;
                    }
                }
            }

            if ((smallestHerbivore != null && smallestHerbivore.Size > carnivoreToCheck.Size) || smallestHerbivore == null)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Returns the combined weight of all the animals in this wagon.
        /// </summary>
        /// <returns></returns>
        private int GetWagonWeight()
        {
            int wagonWeight = 0;
            animals.ForEach(animal => wagonWeight += (int)animal.Size);
            return wagonWeight;
        }
    }
}
