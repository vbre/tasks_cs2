using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorAverage
{
    class Program
    {
        static void Main(string[] args)
        {
            List<ISensorsAverage> sensorsCalculators = new List<ISensorsAverage>();
            sensorsCalculators.Add(new Alina.SensorAverage());
            sensorsCalculators.Add(new Andrey.SensorAverage());
            sensorsCalculators.Add(new Elena.SensorAverage());
            sensorsCalculators.Add(new Konstantin.SensorAverage());
            sensorsCalculators.Add(new Valeriya.SensorAverage());
            sensorsCalculators.Add(new Vladimir.SensorAverage());

            ushort[] myData = {  };

            foreach (var sensorCalculator in sensorsCalculators)
            {
                try
                {
                    Array.ForEach(
                        sensorCalculator.GetAverages(myData),
                        (dataElement) =>
                        { Console.WriteLine("sensor {0}: average {1}", dataElement.Item1, dataElement.Item2); });
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error for object {0}: {1}", sensorCalculator.ToString(), e.Message);
                }
            }
            Console.ReadKey(true);
        }
    }
}
