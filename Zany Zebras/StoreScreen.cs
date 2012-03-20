using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Zany_Zebras
{
    class StoreScreen : GameScreen
    {
        private StoreInput input;
        private List<GuiButton> buttons;
        private GuiButton shovelButton;

        public StoreScreen()
        {
            buttons = new List<GuiButton>();
            shovelButton = new GuiButton(new Vector2(50, 100), "Sprites/shovel_button", 48, 48, 1);
            buttons.Add(shovelButton);

            for (int i = 0; i < buttons.Count; i++)
            {
                buttons[i].Click += new GuiButton.ClickHandler(addAbilityToBar);
            }
        }

        public void Update(GameTime gameTime)
        {
            input.Update();
        }

        public void Render()
        {

        }

        private void addAbilityToBar(GuiButton b, ButtonArgs args)
        {
            // This function would fetch the ability in general list and add it to the instantiated bar of the gamescreen
            Console.WriteLine(args.AbilityID);
        }
    }
}
