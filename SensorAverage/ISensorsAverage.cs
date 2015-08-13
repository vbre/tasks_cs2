using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorAverage
{
    interface ISensorsAverage
    {
        /// <summary>
        /// Calculates average of data from several sensors (up to 8)
        /// </summary>
        /// <param name="data">Array of sensor data. Format:
        ///    first 3 bits - sensor code
        ///    last 1 bit - checksum (1 if quantity of other 1-s in one piece of data is odd)
        ///    other part of data piece is data from sensor.</param>
        /// <returns>Array of pairs &lt;sensor code, average of data of this sensor&gt; </returns>
        Tuple<ushort, double>[] GetAverages(ushort[] data);
    }
}
