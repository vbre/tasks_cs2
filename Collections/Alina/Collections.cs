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
                potatoeBag.Remove(potatoe);
            }
            goodPotatoes = good;
            badPotatoes = bad;
            return good.Count;
        }
    }
}
