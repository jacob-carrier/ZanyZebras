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
        private List<string> abilityDesc;
        private GuiButton shovelButton, pitButton;
        private string currentText ="";

        public StoreScreen()
        {
            buttons = new List<GuiButton>();
            abilityDesc = new List<string>();
            shovelButton = new GuiButton(new Vector2(50, 100), "Sprites/shovel_button", 48, 48, 0);
            pitButton = new GuiButton(new Vector2(98, 100), "Sprites/pit_button", 48, 48, 1);
            buttons.Add(shovelButton);
            buttons.Add(pitButton);

            abilityDesc.Add("This is the shovel ability");
            abilityDesc.Add("This is the pit ability");

            for (int i = 0; i < buttons.Count; i++)
            {
                buttons[i].Click += new GuiButton.ClickHandler(addAbilityToBar);
                buttons[i].Hover += new GuiButton.HoverHandler(changeText);
            }

            input = new StoreInput(buttons);
        }

        public override void Update(GameTime gameTime)
        {
            input.Update();
        }

        public override void Render()
        {
            foreach (GuiButton b in buttons)
            {
                b.Render();
            }

            FontManager.Instance.Render(currentText, new Vector2(300,100));
        }

        private void addAbilityToBar(GuiButton b, ButtonArgs args)
        {
            // This function would fetch the ability in general list and add it to the instantiated bar of the gamescreen
            Console.WriteLine("AbilityID: " + args.AbilityID);
        }

        private void changeText(GuiButton b, ButtonArgs args)
        {
            currentText = abilityDesc[args.AbilityID];
        }
    }
}
