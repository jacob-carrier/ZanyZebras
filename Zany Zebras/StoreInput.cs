using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Zany_Zebras
{
    class StoreInput : Input
    {
        private List<GuiButton> buttons;
        public StoreInput(List<GuiButton> btnList)
        {
            buttons = btnList;
        }

        public override void Update()
        {
            newState = Mouse.GetState();
            foreach (GuiButton b in buttons)
            {
                b.Update();
            }
            oldState = newState;
        }
    }
}
