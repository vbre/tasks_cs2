using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorAverage.Alina
{
    class SensorAverage : ISensorsAverage
    {
            public struct SensorData
            {
                public ushort codeSensor;
                public ushort valueSensor;
                public ushort isСorrupted;
                public SensorData(ushort code, ushort val, ushort corrupt)
                {
                    codeSensor = code;
                    valueSensor = val;
                    isСorrupted = corrupt;
                }
            }
            private static SensorData[] GetParse(ushort[] myData)
            {
                SensorData[] resultParse = new SensorData[myData.Length];
                uint firstMask = 0x1;
                uint secondMask = 0x1FFE;
                for (int i = 0; i < myData.Length; i++)
                {
                    int counter = 0;
                    int dataResult = myData[i];
                    while (dataResult > 0)
                    {
                        dataResult = dataResult >> 1;
                        counter++;
                    }
                    int amountOfBits = counter - 1;
                    int cod = myData[i] >> 13;
                    uint controlBit = myData[i] & firstMask;
                    uint val = (myData[i] & secondMask) >> 1;
                    if ((amountOfBits % 2 == 0 && controlBit == 0) || (amountOfBits % 2 != 0 && controlBit == 1))
                    {
                        resultParse[i] = new SensorData(Convert.ToUInt16(cod), Convert.ToUInt16(val), Convert.ToUInt16(controlBit));
                    }
                    else
                    {
                        Console.WriteLine("Данные {0} со счетчика {1} повреждены", myData[i], cod);
                    }
                }
                return resultParse;
            }
            private static Tuple<ushort, double>[] GetAverageBySensor(SensorData[] resultParse)
            {
                var codMax = resultParse.Max(x => x.codeSensor);
                double [,] parser = new double [codMax+1, 2];
                foreach (var result in resultParse)
                {
                    parser[result.codeSensor, 0] += result.valueSensor;
                    parser[result.codeSensor, 1] += 1;
                }
                int couter = 0;
                for (int i = 0; i < parser.GetLength(0); i++)
                {
                    if (parser[i,0]>0)
                    {
                        couter++;
                    }
                }
                Tuple<ushort, double>[] averageTuples = new Tuple<ushort, double>[couter];
                couter = 0;
                for (ushort i = 0; i < parser.GetLength(0); i++)
                {
                    if (parser[i,0]>0)
                    {
                        averageTuples[couter] = new Tuple<ushort, double>(i, ((double)parser[i, 0]) / ((double)parser[i, 1]));
                        couter++;
                    }
                }

                return averageTuples;
            }

        public Tuple<ushort, double>[] GetAverages(ushort[] data)
        {
            var parsData = GetParse(data);
            return GetAverageBySensor(parsData);
        }
    }
}
