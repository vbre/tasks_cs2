using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorAverage.Vladimir
{
    class SensorAverage : ISensorsAverage
    {

        int countControllers = 8;    // максимум №№ конроллеров на трех разрядах
        int countBlocs = 10;         // число получаемых блоков для экперимента
        int lengthBloc = 16;         // число бит в одном блоке
           
        public Tuple<ushort, double>[] GetAverages(ushort[] data)
        {
            Tuple<ushort, double>[] answerTuple = new Tuple<ushort, double>[countControllers];
            
              int countTrueBlocs = 0;
              foreach (ushort curentData in data)  // определение количества правильных блоков данных (нечетное к-во единиц в 15 разрядах и 1 в последнем бите)
              {
                  if (IsCodeTrue(curentData, lengthBloc))
                  {
                      countTrueBlocs++;
                  }
              }

              if (countTrueBlocs != 0)
              {
                  ushort[] codes = new ushort[countTrueBlocs];
                  ushort[] values = new ushort[countTrueBlocs];

                  int index = 0;
                  foreach (ushort curentData in data)    // наполнение code и value данными
                  {
                      if (IsCodeTrue(curentData, lengthBloc))
            
                      {
                          codes[index] = BlocCode(curentData, lengthBloc);
                          values[index] = BlocValue(curentData, lengthBloc);
                          
                          index++;
                      }
                  }

                  //  подготовка результатов к выдаче
              
                  AverageByBit[] dataOut = CountAverage(codes, values, countControllers);  // формирование структуры вывода
          
                  for (int i = 0; i < countControllers; i++)
                  {
                    answerTuple[i] = Tuple.Create(dataOut[i].code, dataOut[i].value);
                  }
              
              }
              else
              {
                  //Console.WriteLine("На вход поданы исключительно плохие блоки данных");            
              }
            
              return answerTuple;
              
        }




//

        public static float CountBit1(ushort inData, int inLength)
        {
            float summ = 0;
            for (int i = 1; i<=inLength; i++)
            {
                if ((inData & (1<<i)) != 0 )
                {
                    summ++;          
                }
            }
            return summ;
        }

        public static bool IsCodeTrue(ushort inData, int inLength)
        {
            bool answer = false;

            if ((CountBit1(inData, inLength) %2 != 0 && (inData & (1 << 0)) == 1) || (CountBit1(inData, inLength) %2 == 0 && (inData & (1 << 0)) == 0))
            {
                answer = true;
            }                        
            return answer;
        }

        public static ushort BlocCode(ushort inData, int inLength)
        {
            return (ushort)(inData >> (inLength - 3)); // (inLength - 3) 16,15,14 биты = код контроллера
        }

        public static ushort BlocValue(ushort inData, int inLength)
        {   
            inData = (ushort) (inData & (~((1<<15)|(1<<14)|(1<<13)))) ; //Обнуляем 16-й, 15-й, 14-й биты (выкидываем из данных код контроллера)

            return (ushort)(inData >> 1); // (выкидываем из данных проверочный бит)
        }

        public struct AverageByBit
        {
            public ushort code;
            public double value;
        }
        
        public static AverageByBit[] CountAverage(ushort[] inCodes, ushort[] inValues, int inCountControllers)
        {
            AverageByBit[] answerData = new AverageByBit[inCountControllers];  //всего разных датчиков от 000 до 111 - 8 шт.
            
            for(ushort i = 0; i <= inCountControllers-1; i++)
            {
                answerData[i].code = i;    // инициализируем сруктуру ответов
                answerData[i].value = 0.0;
            }

            int[] countValueForAverage = new int[inCountControllers];
         
            for (int i = 0; i <= inCodes.Length -1 ; i++)
            {
                ushort currentCode = inCodes[i];
           
                answerData[currentCode].value += inValues[i];
                countValueForAverage[currentCode]++;

                //answerData[currentCode].value = (answerData[currentCode].value * countValueForAverage[i] + inValues[i]) / (countValueForAverage[i] + 1);
            }
            
            for (int i = 0; i <= inCodes.Length -1 ; i++)
            {
                answerData[i].value = countValueForAverage[i]!=0 ? answerData[i].value / countValueForAverage[i] : 0.0;
            }
            return answerData;
        }

        
     }
   }



