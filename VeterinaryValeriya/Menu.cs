using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeterinaryValeriya
{
    class Menu
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
            foreach (MenuItem elem in ListOfMenuItems)
            {
                items.Add(elem);
            }
        }

        private void PrintMenu ()
        {
            foreach (MenuItem elem in items)
            {
                Console.WriteLine("{0} - {1}", elem.Code, elem.Label);
            }
        }

        public void HandleUserInput (char code)
        {
            Action currentAction = null;
            do
            {
                PrintMenu();
                int currentItemIndex = items.FindIndex((items) => { return items.Code == code; });
                if (currentItemIndex != -1)
                    currentAction = items[currentItemIndex].ActionToDo;
                if (currentAction != null)
                {
                    currentAction();
                }
            }
            while (currentAction != null);
        }
    }
}
