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
                if(animalList.Count > 0)
                {
                    return true;
                }

                return false;
            }
        }
        /// <summary>
        /// A ReadOnlyCollection containing all the animals found in the wagon.
        /// </summary>
        public ReadOnlyCollection<Animal> AnimalList
        {
            get
            {
                return new ReadOnlyCollection<Animal>(animalList);
            }
        }

        /// <summary>
        /// A list containing all animals found in the wagon.
        /// </summary>
        private List<Animal> animalList = new List<Animal>();

        public Wagon() { }

        /// <summary>
        /// Adds the given animal to the wagon.
        /// </summary>
        /// <param name="animal">The animal to add.</param>
        public void AddAnimal(Animal animal)
        {
            animalList.Add(animal);
        }
    }
}
