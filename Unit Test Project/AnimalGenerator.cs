using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Circus_Trein;

namespace Unit_Test_Project
{
    public class AnimalGenerator
    {
        /// <summary>
        /// The Random class used to generate random numbers.
        /// </summary>
        Random rng;

        /// <summary>
        /// Instantiates a Random object with the current date time ticks as the seed.
        /// </summary>
        public AnimalGenerator()
        {
            rng = new Random((int)DateTime.Now.Ticks);
        }

        /// <summary>
        /// Gets an animal with a random Diet, a random Size and a unique ID.
        /// </summary>
        /// <returns></returns>
        public Animal GetRandomAnimal()
        {
            int animalDiet = rng.Next(0, 2);
            int animalSize = rng.Next(0, 5);
            if(animalSize == 0 || animalSize == 2 || animalSize == 4)
            {
                animalSize += 1;
            }

            return new Animal((Diet)animalDiet, (Size)animalSize);
        }

        /// <summary>
        /// Returns a list of count amount of randomly generated animals.
        /// </summary>
        /// <param name="count">The amount of animals to generate.</param>
        /// <returns></returns>
        public List<Animal> GetRandomAnimals(int count)
        {
            List<Animal> returnAnimals = new List<Animal>(count);
            for(int i = 0; i < count; i++)
            {
                returnAnimals.Add(GetRandomAnimal());
            }

            return returnAnimals;
        }
    }
}
