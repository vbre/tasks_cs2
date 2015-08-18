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

            ushort[] myData = 
                { 0xE1FA, 0xE1F0, 0xE1F9, 0xE1F5, 0xE1F4 /**/, 0xC1FB, 0xC1F1, 0x21FA, 0x21F0, 0x21F9 };

            Dictionary<ushort, double> modelResults = 
                new Dictionary<ushort, double>
                {
                    { 0x1, /* 253 + 248 + 252 */ 251.0 }, 
                    { 0x6, /* 253 + 248 */ 250.5 },
                    { 0x7, /* 253 + 248 + 252 + 250 */ 250.75 }
                };

            foreach (var sensorCalculator in sensorsCalculators)
            {
                try
                {
                    Array.ForEach(
                        sensorCalculator.GetAverages(myData),
                        (dataElement) =>
                        { 
                            Console.WriteLine("sensor {0}: average {1}, status: {2}",
                                dataElement.Item1,
                                dataElement.Item2, 
                                modelResults[dataElement.Item1] == dataElement.Item2 
                                    ? "OK"
                                    : "Wrong average. Model value is " + modelResults[dataElement.Item1].ToString()
                                );
                        });
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
