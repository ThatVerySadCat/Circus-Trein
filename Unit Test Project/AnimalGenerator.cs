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
        Random rng;

        public AnimalGenerator(int seed)
        {
            rng = new Random(seed);
        }

        public Animal GetRandomAnimal()
        {
            int animalDiet = rng.Next(0, 2);
            int animalSize = rng.Next(0, 4);

            return new Animal((Diet)animalDiet, (Size)animalSize);
        }
    }
}
