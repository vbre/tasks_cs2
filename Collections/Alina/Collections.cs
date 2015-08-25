using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections.Alina
{
    class Collections: ICollections
    {
        public int SortPotatoes(List<IPotatoe> potatoeBag, out List<IPotatoe> goodPotatoes, out List<IPotatoe> badPotatoes)
        {
            List<IPotatoe> good = new List<IPotatoe>();
            List<IPotatoe> bad = new List<IPotatoe>();
            foreach (var potatoe in potatoeBag)
            {
                if (potatoe.IsBad)
                {
                    bad.Add(potatoe);
                }
                else
                {
                    good.Add(potatoe);
                }
            }
            goodPotatoes = good;
            badPotatoes = bad;
            potatoeBag.Clear();
            return good.Count;
        }


        public List<IOutData> ProcessData(IReadOnlyList<IInData> inputData)
        {
            //List<IOutData> output = new List<IOutData>();

            //Dictionary<int, int> sensors = new Dictionary<int, int>();

            //foreach (var input in inputData)
            //{
            //    if (input.IsValid)
            //    {
            //        sensors.Add(input.Code, input.Value);

            //    }
            //}

            return null;
        }

        public LinkedList<int> CreateOrderedList(IReadOnlyList<int> input)
        {
            List<int> output = new List<int>(input);
            output.Sort();
            return new LinkedList<int>(output);      
        }


        public IReadOnlyDictionary<char, IList<string>> OrganizeByFirstCharacter(IEnumerable<string> text)
        {
            throw new NotImplementedException();
        }
    }
}
