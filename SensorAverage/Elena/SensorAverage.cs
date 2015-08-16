using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorAverage.Elena
{
    class SensorAverage : ISensorsAverage
    {
       public struct AvarageBySensor
        {
            public ushort code;
            public double value;

        }
  
      
        public Tuple<ushort, double>[] GetAverages(ushort[] data)
        {
            int[] parity = new int[data.Length]; //счетчик единиц
            int lastByte = 0;
            int counter=0;
            int countOfSensor = 8;
            int[] sensorCode = new int[countOfSensor];
            ushort codeRezult;
            double valueRezult;
            SensorAverage.AvarageBySensor Average;
            Tuple<ushort, double>[] rezultTuple = { Tuple.Create((ushort)0, 0.0), Tuple.Create((ushort)0, 0.0), Tuple.Create((ushort)0, 0.0)};


            List<SensorAverage.AvarageBySensor> AvarageList = new List<AvarageBySensor>();
            for (int t = 32768; t > 0; t /= 2)
            {
                for (int arreyCount = 0; arreyCount < data.Length; arreyCount++)
                {
                    if (t != 1)
                    {
                        if ((data[arreyCount] & t) != 0)
                        {
                            parity[arreyCount]++;
                        }

                    }
                    else
                    {
                        lastByte = data[arreyCount] & t;
                        if (((lastByte == 1) && (parity[arreyCount] % 2 != 0)) || ((lastByte == 0) && (parity[arreyCount] % 2 == 0)))
                        {
                            //разбираем информацию на составляющие


                            codeRezult = (ushort)(data[arreyCount] >> 13);
                            Average.code = codeRezult;
                            bool isCode = Array.TrueForAll(sensorCode, (codeOfSensor)=>(codeOfSensor!=codeRezult));
                            if (isCode)
                            {
                                sensorCode[counter] = codeRezult;
                                counter++;
                            }
                            valueRezult = (double)((data[arreyCount] >> 1) & 0xFFF);
                            Average.value = valueRezult;

                            //забиваем данные в массив
                            AvarageList.Add(Average);

                        }
                    }
                }
            }
            SensorAverage.AvarageBySensor[] AvarageArray = AvarageList.ToArray();
            double[,] SensorDataRezult = new double[countOfSensor, 2];
            for (int i = 0; i < AvarageArray.Length; i++)
            {
                for (int k = 0; k < countOfSensor; k++)
                {
                    if (AvarageArray[i].code == sensorCode[k])
                    {
                        
                        SensorDataRezult[k, 0] += AvarageArray[i].value;
                        SensorDataRezult[k, 1] += 1;
                    }
                }

            }

            for (int k = 0; k < counter; k++)
            {
                rezultTuple[k] = Tuple.Create((ushort)sensorCode[k], SensorDataRezult[k,0]/SensorDataRezult[k,1]);
            }

            CompareOnSensorCode Compare = new CompareOnSensorCode();
            Array.Sort(rezultTuple, Compare);

            return rezultTuple;


        }
    }

    public class CompareOnSensorCode : IComparer
    {
        public int Compare(object x, object y)
        {
            int result;

            Tuple<ushort, double> objectOne = (Tuple<ushort, double>)x;
            Tuple<ushort, double> objectTwo = (Tuple<ushort, double>)y;

            if (objectOne.Item1 > objectTwo.Item1)
            { result = 1; }

            else if (objectOne.Item1 == objectTwo.Item1)
            { result = 0; }

            else
            { result = -1; }

            return result;
        }
    }
}
