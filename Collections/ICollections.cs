using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    interface ICollections
    {
        /// <summary>
        /// переберите этот мешок на два других мешка,
        /// в один положите испорченные, а в другой - неиспорченные. 
        /// Из самого первого мешка при этом картофелины должны уже удаляться
        /// </summary>
        /// <param name="potatoeBag">входной мешок картошки</param>
        /// <param name="goodPotatoes">мешок с хорошими картофелинами</param>
        /// <param name="badPotatoes">мешок с плохими картофелинами</param>
        /// <returns>количество хороших картофелин</returns>
        int SortPotatoes(
            List<IPotatoe> potatoeBag, 
            out List<IPotatoe> goodPotatoes,
            out List<IPotatoe> badPotatoes);
    }
}
