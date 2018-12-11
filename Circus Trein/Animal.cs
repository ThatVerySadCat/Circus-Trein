using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circus_Trein
{
    public class Animal : IComparable<Animal>
    {
        /// <summary>
        /// The animals Diet.
        /// </summary>
        public Diet Diet
        {
            get;
            private set;
        }
        /// <summary>
        /// The unique animal ID.
        /// </summary>
        public int ID
        {
            get;
            private set;
        }
        /// <summary>
        /// The animals Size.
        /// </summary>
        public Size Size
        {
            get;
            private set;
        }
        
        /// <summary>
        /// Instantiate an Animal with the given _diet and _size properties and an unique ID.
        /// </summary>
        /// <param name="_diet">The animals diet.</param>
        /// <param name="_size">The animals size.</param>
        public Animal(Diet _diet, Size _size)
        {
            Diet = _diet;
            ID = IDPool.GetNextID();
            Size = _size;
        }

        /// <summary>
        /// Compare to function used to find the smaller animal.
        /// </summary>
        /// <param name="compareAnimal">The Animal to compare with.</param>
        /// <returns>Returns less than 0 when the compareAnimal is smaller, returns zero if the compareAnimal is equal size, returns more than zero if compareAnimal is larger. Returns 0 if compareAnimal is null.</returns>
        public int CompareTo(Animal compareAnimal)
        {
            if (compareAnimal == null)
            {
                return 0;
            }
            
            return this.Size.CompareTo(compareAnimal.Size) * -1;
        }
    }
}
