using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorAverage.Valeriya
{

    class Sensors
    {
        static int countOfSensors = 3;
        static List<double> values = new List<double>();
        static double[] codes = new double[Sensors.countOfSensors];
        static List<double> ParseSensorsData (ushort[] data)
        {
            foreach(ushort element in data)
            {
                codes[element] = data[element] >> 13;
                Sensors.values.Add(data[element] >> 3);
            }

            return Sensors.values;
        }
    }
}
