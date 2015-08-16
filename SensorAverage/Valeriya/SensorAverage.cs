using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorAverage.Valeriya
{
    class SensorAverage : ISensorsAverage
    {
        
        public Tuple<ushort, double>[] GetAverages(ushort[] data)
        {
            Tuple<ushort, double>[] dataFromSensor = new Tuple<ushort, double>[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                double valueFromSensor = data[i] >> 13;
                var temp = data[i] << 3;
                ushort codeOfSensor = (ushort)(temp >> 4);
                dataFromSensor[i] = Tuple.Create(codeOfSensor, valueFromSensor);
            }

            double sumForSensor1 = 0;
            for (int i = 0; i < dataFromSensor.Length; i++)
            {
                if (dataFromSensor[i].Item1 == dataFromSensor[i+1].Item1)
                {
                    sumForSensor1 = sumForSensor1 + dataFromSensor[i].Item1;
                    ushort sensorFist = dataFromSensor[i].Item1;

                }
                
            }

            return dataFromSensor;
        }
    }
}
