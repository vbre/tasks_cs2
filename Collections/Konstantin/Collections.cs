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
    }
}
