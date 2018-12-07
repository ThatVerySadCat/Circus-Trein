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
        /// Instantiates a Random object with the given seed.
        /// </summary>
        /// <param name="seed">The seed to use for the random number generation.</param>
        public AnimalGenerator(int seed)
        {
            rng = new Random(seed);
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
    }
}
