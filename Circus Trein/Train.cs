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
        /// The amount of carnivores that have been added to the train.
        /// </summary>
        public int CarnivoreCount
        {
            get
            {
                return carnivores.Count;
            }
        }
        /// <summary>
        /// The amount of herbivores that have been added to the train.
        /// </summary>
        public int HerbivoreCount
        {
            get
            {
                return herbivores.Count;
            }
        }

        /// <summary>
        /// A list containing all the carnivores added to the train thus far.
        /// </summary>
        private List<Animal> carnivores = new List<Animal>();
        /// <summary>
        /// A list containing all of the herbivores added to the train thus far.
        /// </summary>
        private List<Animal> herbivores = new List<Animal>();
        /// <summary>
        /// A list containing the wagons that are a part of the train.
        /// </summary>
        private List<Wagon> wagons = new List<Wagon>();

        public Train() { }
        
        /// <summary>
        /// Adds the given animal to the correct list based on its diet.
        /// </summary>
        /// <param name="animal">The animal to add.</param>
        public void AddAnimal(Animal animal)
        {
            if(animal.Diet == Diet.Carnivore)
            {
                carnivores.Add(animal);
            }
            else if(animal.Diet == Diet.Herbivore)
            {
                herbivores.Add(animal);
            }
        }

        /// <summary>
        /// Adds the animals in the given list to the correct list based on its diet.
        /// </summary>
        /// <param name="animals">The list of animals to add.</param>
        public void AddAnimals(List<Animal> animals)
        {
            foreach(Animal animal in animals)
            {
                AddAnimal(animal);
            }
        }

        /// <summary>
        /// Places the animals that are contained within the train in wagons.
        /// </summary>
        public void PlaceAnimals()
        {
            PlaceCarnivores();
            PlaceHerbivores();
        }

        /// <summary>
        /// Places the carnivores in wagons.
        /// </summary>
        private void PlaceCarnivores()
        {
            carnivores.Sort();

            wagons.Add(new Wagon());
            foreach (Animal carnivore in carnivores)
            {
                Wagon newestWagon = wagons[wagons.Count - 1];

                if (newestWagon.CanAnimalBeAdded(carnivore))
                {
                    newestWagon.AddAnimal(carnivore);
                }
                else
                {
                    newestWagon = new Wagon();
                    wagons.Add(newestWagon);

                    newestWagon.AddAnimal(carnivore);
                }
            }
        }

        /// <summary>
        /// Places the herbivores in wagons.
        /// </summary>
        private void PlaceHerbivores()
        {
            herbivores.Sort();

            foreach (Animal herbivore in herbivores)
            {
                bool animalWasPlaced = false;
                for (int i = 0; i < wagons.Count; i++)
                {
                    Wagon currentWagon = wagons[i];
                    if (currentWagon.CanAnimalBeAdded(herbivore))
                    {
                        currentWagon.AddAnimal(herbivore);
                        animalWasPlaced = true;

                        break;
                    }
                }

                if (!animalWasPlaced)
                {
                    Wagon newWagon = new Wagon();
                    wagons.Add(newWagon);
                    newWagon.AddAnimal(herbivore);
                }
            }
        }
    }
}
