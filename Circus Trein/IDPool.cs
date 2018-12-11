using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circus_Trein
{
    class IDPool
    {
        /// <summary>
        /// The variable from which to obtain unique IDs.
        /// </summary>
        private static int idPool = 0;

        /// <summary>
        /// Returns an ID which is unique.
        /// Method is NOT thread safe!
        /// </summary>
        /// <returns></returns>
        public static int GetNextID()
        {
            idPool += 1;
            return idPool;
        }
    }
}
