using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorAverage.Valeriya
{
    public class ParseDataFromSensors
    {
        public struct AverageBySensor
        {
           public ushort code;
           public double value;
           
           public AverageBySensor (ushort code, double value)
            {
                this.code = code;
                this.value = value;
            }
        }

        public List<AverageBySensor> ParseData (ushort[] data)
        {
            List<AverageBySensor> dataFromSensors = new List<AverageBySensor>();
            //AverageBySensor dataFromSensor = new AverageBySensor();            
            for (int i = 0; i < data.Length; i++)
            {
                ushort codeOfSensor = (ushort)(data[i] >> 13);
                if ((data[i] & 0x1) == 1)
                {
                    var temp = data[i] << 3;
                    double valueFromSensor = temp >> 4;
                    dataFromSensors.Add(new AverageBySensor(codeOfSensor, valueFromSensor));
                }
            }

            return dataFromSensors;
        }
    }
}
