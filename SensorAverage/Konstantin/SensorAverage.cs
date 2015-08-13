using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorAverage.Konstantin
{
    class SensorAverage : ISensorsAverage
    {
        public Tuple<ushort, double>[] GetAverages(ushort[] data)
        {
            Tuple<ushort, double>[] averages = new Tuple<ushort, double>[7];
            ushort[] codes = GetCodes(data);
            short[] values = GetValues(data);
            double[] avarege = CountAverage(values, codes);
            for (int i = 0; i < avarege.Length; i++)
            {
                averages[i] = Tuple.Create(codes[i], avarege[i]);
            }
            return averages;
        }
        private static short[] GetValues(ushort[] data)
        {

            short[] values = new short[data.Length];
            short[] tempValues = new short[data.Length];

            for (int index = 0; index < data.Length; index++)
            {
                values[index] = (short)(data[index] << 3);
                values[index] = (short)(values[index] >> 4);
                tempValues[index] = values[index];
                ushort trueBitsCount = 0;
                for (int indexIn = 0; indexIn < 13; indexIn++)
                {
                    if ((tempValues[index] & 1) == 1)
                    {
                        trueBitsCount++;
                    }
                    tempValues[index] >>= 1;
                }
                if (trueBitsCount % 2 == 1)
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
            double [] average = new double [8];
            int [] sum  = new int [8];
            int [] count = new int[8];
            for (int index = 0; index < values.Length; index++)
            {
                if (values[index] % 2 == 1)
                {
                    switch (codes[index])
                    {
                        case 0:
                            sum[0] += values[index];
                            count[0]++;
                            break;
                        case 1:
                            sum[1] += values[index];
                            count[1]++;
                            break;
                        case 2:
                             sum[2] += values[index];
                             count[2]++;
                            break;
                        case 3:
                            sum[3] += values[index];
                            count[3]++;
                            break;
                        case 4:
                            sum[4] += values[index];
                            count[4]++;
                            break;
                        case 5:
                            sum[5] += values[index];
                            count[5]++;
                            break;
                        case 6:
                            sum[6] += values[index];
                            count[6]++;
                            break;
                        case 7:
                            sum[7] += values[index];
                            count[7]++;
                            break;
                        default:
                            break;
                    }
                }

            }
            for (int i = 0; i < 8; i++)
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
