using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circus_Trein
{
    public class Animal
    {
        public Diet Diet
        {
            get;
            private set;
        }
        public int ID
        {
            get;
            private set;
        }
        public Size Size
        {
            get;
            private set;
        }
        
        public Animal(Diet _diet, Size _size)
        {
            Diet = _diet;
            ID = IDPool.GetNextID();
            Size = _size;
        }
    }
}
