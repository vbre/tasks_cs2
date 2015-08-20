using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorAverage.Konstantin
{
    class SensorAverage : ISensorsAverage
    {
        private const int countOfSensors = 8;
        public Tuple<ushort, double>[] GetAverages(ushort[] data)
        {
            
            ushort[] codes = GetCodes(data);
            ushort[] sensorNumber = new ushort[countOfSensors];
            for (int index = 0; index < countOfSensors; index++)
            {
                sensorNumber[index] = (ushort)index;
            }
            short[] values = GetValues(data);
            double[] avarege = CountAverage(values, codes);
            int countOfValues = 0;
            foreach (var item in avarege)
            {
                if (item !=0)
                {
                    countOfValues++;
                }
            }
            Tuple<ushort, double>[] averages = new Tuple<ushort, double>[countOfValues];
            int tupleIndex = 0;
            for (int i = 0; i < avarege.Length; i++)
            {
                if (avarege[i]!=0)
                {
                    averages[tupleIndex] = Tuple.Create(sensorNumber[i], avarege[i]);
                    tupleIndex++;
                }
                
            }
           

            return averages;
        }
        private static short[] GetValues(ushort[] data)
        {

            short[] values = new short[data.Length];
            int[] tempValues = new int[data.Length];

            for (int index = 0; index < data.Length; index++)
            {
                values[index] = (short)(data[index] << 3);
                values[index]>>= 4;
                int trueBitsCount = 0;
                for (int indexIn = 32768; indexIn >1; indexIn/=2)
                {
                    if ((data[index]&indexIn) != 0)
                    {
                        trueBitsCount++;
                    }
                    
                }
                if (trueBitsCount % 2 == 1 && (data[index] %2 ==1)|| (trueBitsCount % 2 == 0 && (data[index] % 2 == 0)))
                {
                    values[index] = (short)((values[index] << 1) | 1);
                }
                else 
                {
                    values[index] = (short)(values[index] << 1);
                }
            }
            return values;
        }
        private static ushort[] GetCodes(ushort[] data)
        {
            ushort[] codes = new ushort[data.Length];
            for (int index = 0; index < data.Length; index++)
            {
                codes[index] = (ushort)(data[index] >> 13);
            }
            return codes;
        }
        public static double[] CountAverage(short[] values, ushort[] codes)
        {
            double[] average = new double[countOfSensors];
            double[] sum = new double[countOfSensors];
            int[] count = new int[countOfSensors];
            for (int index = 0; index < values.Length; index++)
            {
                if (values[index] % 2 == 1)
                {

                    sum[codes[index]] += values[index] >> 1;
                    count[codes[index]]++;

                }
            }


                
                for (int i = 0; i < countOfSensors; i++)
                {
                    if (count[i] != 0)
                    {
                        average[i] = sum[i] / count[i];
                    }
                    else
                    {
                        average[i] = 0;
                    }
                }

                return average;
            }
        }
    }


