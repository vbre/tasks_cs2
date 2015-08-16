using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorAverage.Valeriya
{
    class SensorAverage : ISensorsAverage
    {
        ParseDataFromSensors dataParser = new ParseDataFromSensors();
        public Tuple<ushort, double>[] GetAverages(ushort[] data)
        {
            int numberOfSensors = 3;
            double sumForSensor1 = 0;

            Tuple<ushort, double>[] averageFromSensors = new Tuple<ushort, double>[numberOfSensors];
            for (int i = 0; i < data.Length; i++)
            {
                sumForSensor1 += averageFromSensors[i].Item2;
            }

           return averageFromSensors;

        }
    }
}
