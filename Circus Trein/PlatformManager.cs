using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circus_Trein
{
    public class PlatformManager
    {
        public int AnimalCount
        {
            get
            {
                return (carnivoreList.Count + herbivoreList.Count);
            }
        }
        public int CarnivoreCount
        {
            get
            {
                return carnivoreList.Count;
            }
        }
        public int HerbivoreList
        {
            get
            {
                return herbivoreList.Count;
            }
        }

        private List<Animal> carnivoreList = new List<Animal>();
        private List<Animal> herbivoreList = new List<Animal>();

        public PlatformManager() { }

        public void AddAnimal(Animal animal) { }
        public void AddAnimalList(List<Animal> animalList) { }
    }
}
