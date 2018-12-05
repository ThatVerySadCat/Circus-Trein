using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circus_Trein
{
    class IDPool
    {
        private static int idPool = 0;

        public static int GetNextID()
        {
            idPool += 1;
            return idPool;
        }
    }
}
