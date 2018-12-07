using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circus_Trein
{
    public class PlatformManager
    {
        /// <summary>
        /// The total amount of animals kept by the platform manager.
        /// </summary>
        public int AnimalCount
        {
            get
            {
                return (carnivoreList.Count + herbivoreList.Count);
            }
        }
        /// <summary>
        /// The total amount of animals with a carnivore diet kept by the platform manager.
        /// </summary>
        public int CarnivoreCount
        {
            get
            {
                return carnivoreList.Count;
            }
        }
        /// <summary>
        /// The total amount of animals with a herbivore diet kept by the platform manager.
        /// </summary>
        public int HerbivoreCount
        {
            get
            {
                return herbivoreList.Count;
            }
        }

        /// <summary>
        /// A ReadOnlyCollection containing all of the animals kept by the platform manager.
        /// </summary>
        public ReadOnlyCollection<Animal> AnimalList
        {
            get
            {
                List<Animal> completeList = new List<Animal>(carnivoreList.Count + herbivoreList.Count);
                completeList.AddRange(carnivoreList);
                completeList.AddRange(herbivoreList);

                return new ReadOnlyCollection<Animal>(completeList);
            }
        }
        /// <summary>
        /// A ReadOnlyCollection containing all of the animals with a carnivore diet kept by the platform manager.
        /// </summary>
        public ReadOnlyCollection<Animal> CarnivoreList
        {
            get
            {
                return new ReadOnlyCollection<Animal>(carnivoreList);
            }
        }
        /// <summary>
        /// A ReadOnlyCollection containing all of the animals with a herbivore diet kept by the platform manager.
        /// </summary>
        public ReadOnlyCollection<Animal> HerbivoreList
        {
            get
            {
                return new ReadOnlyCollection<Animal>(herbivoreList);
            }
        }

        /// <summary>
        /// The list of animals with diet carnivore.
        /// </summary>
        private List<Animal> carnivoreList = new List<Animal>();
        /// <summary>
        /// The list of animals with diet herbivore.
        /// </summary>
        private List<Animal> herbivoreList = new List<Animal>();

        public PlatformManager() { }

        /// <summary>
        /// Add the given animal and add it to the correct list.
        /// </summary>
        /// <param name="animal">The Animal to add.</param>
        public void AddAnimal(Animal animal)
        {
            if(animal.Diet == Diet.carnivore)
            {
                carnivoreList.Add(animal);
            }
            else if(animal.Diet == Diet.herbivore)
            {
                herbivoreList.Add(animal);
            }
        }

        /// <summary>
        /// Adds the given animalList to the correct PlatformManager list.
        /// </summary>
        /// <param name="animalList">The list of animal to add.</param>
        public void AddAnimalList(List<Animal> animalList)
        {
            foreach(Animal animal in animalList)
            {
                AddAnimal(animal);
            }
        }

        /// <summary>
        /// Returns a list of animal groups that meet the functional requirements for the application.
        /// </summary>
        /// <returns>A list of animal groups that meet the functional requirements.</returns>
        public List<List<Animal>> GetAnimalGroups()
        {
            /* Sorts the animal lists from small to large and then reverses them */
            carnivoreList.Sort();
            carnivoreList.Reverse();
            herbivoreList.Sort();
            herbivoreList.Reverse();

            List<List<Animal>> animalGroupList = new List<List<Animal>>();
            animalGroupList.Add(new List<Animal>());
            foreach (Animal carnivore in carnivoreList)
            {
                int currentGroupIndex = animalGroupList.Count - 1;
                int currentGroupSize = 0;
                animalGroupList[currentGroupIndex].ForEach(x => currentGroupSize += (int)x.Size);

                if((currentGroupSize + (int)carnivore.Size) <= 10 && animalGroupList[currentGroupIndex].Find(x => (x.Diet == Diet.carnivore && x.Size >= carnivore.Size) || (x.Diet == Diet.herbivore && x.Size < carnivore.Size)) == null)
                {
                    animalGroupList[currentGroupIndex].Add(carnivore);

                    currentGroupSize += (int)carnivore.Size;
                }
                else
                {
                    animalGroupList.Add(new List<Animal>());
                    animalGroupList[currentGroupIndex + 1].Add(carnivore);

                    currentGroupIndex += 1;
                    currentGroupSize = (int)carnivore.Size;
                }

                // Run through herbivore list to find if there is a herbivore that can fit with the carnivore
                // This is to add large herbivores with medium carnivores and large/medium herbivores with small carnivores
                for(int i = 0; i < herbivoreList.Count; i++)
                {
                    Animal herbivore = herbivoreList[i];

                    Animal biggerCarnivore = animalGroupList[currentGroupIndex].Find(x => x.Diet == Diet.carnivore && x.Size >= herbivore.Size);
                    if ((currentGroupSize + (int)herbivore.Size) <= 10 && biggerCarnivore == null)
                    {
                        animalGroupList[currentGroupIndex].Add(herbivore);
                        currentGroupSize += (int)herbivore.Size;

                        herbivoreList.RemoveAt(i);
                    }
                    else if (biggerCarnivore != null)
                    {
                        break;
                    }
                }
            }
            
            // Run through the herbivore list here and try to add them to any of the already existing groups or create a new group
            foreach(Animal herbivore in herbivoreList)
            {
                bool wasPlaced = false;
                foreach (List<Animal> animalGroup in animalGroupList)
                {
                    int currentGroupSize = 0;
                    animalGroup.ForEach(x => currentGroupSize += (int)x.Size);

                    if((currentGroupSize + (int)herbivore.Size) <= 10 && animalGroup.Find(x => x.Diet == Diet.carnivore && x.Size >= herbivore.Size) == null)
                    {
                        animalGroup.Add(herbivore);
                        wasPlaced = true;

                        break;
                    }
                }

                if(!wasPlaced)
                {
                    animalGroupList.Add(new List<Animal>());
                    animalGroupList[animalGroupList.Count - 1].Add(herbivore);
                }
            }

            return animalGroupList;
        }
    }
}
