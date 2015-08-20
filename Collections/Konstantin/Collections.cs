using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections.Konstantin
{
    class Collections : ICollections
    {

        public int SortPotatoes(List<IPotatoe> potatoeBag, out List<IPotatoe> goodPotatoes, out List<IPotatoe> badPotatoes)
        {
            goodPotatoes = new List<IPotatoe>();
            badPotatoes = new List<IPotatoe>();

            int countOfGoodPotatoes = 0;
            foreach (var potatoe in potatoeBag)
            {
                if (potatoe.IsBad)
                {
                    badPotatoes.Add(potatoe);
                }
                else
                {
                    goodPotatoes.Add(potatoe);
                    countOfGoodPotatoes++;
                }
            }
            potatoeBag.RemoveAll((x) => { return true; });
            return countOfGoodPotatoes;
        }


        public List<IOutData> ProcessData(IReadOnlyList<IInData> inputData)
        {
            List<double> sum = new List<double>();
            List<int> count = new List<int>();
            List<int> codes = new List<int>();
            foreach (var data in inputData)
            {
                if (data.IsValid)
                {
                    if (!codes.Contains(data.Code))
                    {
                        codes.Add(data.Code);
                        sum.Add(0);
                        count.Add(0);
                    }
                    sum[codes.IndexOf(data.Code)] += data.Value;
                    count[codes.IndexOf(data.Code)]++;
                }
            }
            List<IOutData> outputData = new List<IOutData>();
            for (int index = 0; index < codes.Count; index++)
            {

                outputData.Add(new OutData(codes[index], sum[index] / count[index]));
            }


            return outputData;
        }
        private class OutData : IOutData
        {
            public OutData(int code, double average)
            {
                Code = (int)code;
                Average = average;
            }

            public int Code { get; private set; }

            public double Average { get; private set; }
        }


        public LinkedList<int> CreateOrderedList(IReadOnlyList<int> input)
        {
            
            List<int> tempList = new List<int>();
            foreach (var item in input)
            {
                tempList.Add(item);
            }
            tempList.Sort();
            LinkedList<int> orderedList = new LinkedList<int>();
            foreach (var item in tempList)
            {
                orderedList.AddLast(item);
            }
            return orderedList;
        }
    }
}
