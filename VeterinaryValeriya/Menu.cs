using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeterinaryValeriya
{
    class Menu: IEnumerable
    {
        public struct MenuItem
        {
            public char Code;
            public string Label;
            public Action ActionToDo;
        }

        private List<MenuItem> items;

        public Menu (List<MenuItem> ListOfMenuItems)
        {
            items = ListOfMenuItems;
        }

        public void HandleUserInput (char code)
        {
            int currentItemIndex = items.FindIndex((items) => { return items.Code == code; });

            if (currentItemIndex != -1 && items[currentItemIndex].ActionToDo != null)
            {
                items[currentItemIndex].ActionToDo();
            }
        }

        public IEnumerator GetEnumerator()
        {
            foreach (MenuItem elem in items)
            {
                yield return elem;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
