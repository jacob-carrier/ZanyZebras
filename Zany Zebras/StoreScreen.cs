using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Zany_Zebras
{
    class StoreScreen : GameScreen
    {
        private StoreInput input;
        private List<GuiButton> buttons;
        private List<string> abilityDesc;
        private List<IAbility> abilities;
        private GuiButton shovelButton, pitButton;
        private string currentText ="";
        bool skillDragged = false;
        Texture2D draggedImage;

        public StoreScreen()
        {
            buttons = new List<GuiButton>();
            abilities = new List<IAbility>();
            shovelButton = new GuiButton(new Vector2(50, 100), "Sprites/shovel_button", 48, 48, 0);
            pitButton = new GuiButton(new Vector2(98, 100), "Sprites/pit_button", 48, 48, 1);
            buttons.Add(shovelButton);
            buttons.Add(pitButton);

            abilityDesc = new List<string>();

            abilityDesc.Add("This is the shovel ability");
            abilityDesc.Add("This is the pit ability");

            for (int i = 0; i < buttons.Count; i++)
            {
                buttons[i].Click += new GuiButton.ClickHandler(addAbilityToBar);
                buttons[i].Hover += new GuiButton.HoverHandler(changeText);
                buttons[i].Drag += new GuiButton.DraggingHandler(dragging);
                buttons[i].Drop += new GuiButton.DropHandler(dropping);
            }

            input = new StoreInput(buttons);
        }

        public override void Update(GameTime gameTime)
        {
            input.Update();
            Game1.Instance.GameAbilityBar.Update(gameTime);
        }

        public override void Render()
        {
            foreach (GuiButton b in buttons)
            {
                b.Render();
            }
            Game1.Instance.GameAbilityBar.Render();
            if (skillDragged)
            {
                Game1.Instance.SpriteBatch.Draw(draggedImage, new Rectangle(Mouse.GetState().X-24, Mouse.GetState().Y-24, 48, 48),new Rectangle(0,0,48,48), Color.White);
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
            b.FrameID = new Vector2(1, 0);
            currentText = abilityDesc[args.AbilityID];
        }

        private void dragging(GuiButton b, ButtonArgs args){
            skillDragged = args.Dragged;
            draggedImage = b.ButtonImage;
        }

        private void dropping(GuiButton b, ButtonArgs args)
        {
            Rectangle box = new Rectangle(Mouse.GetState().X - 24, Mouse.GetState().Y - 24, 48, 48);
            if (box.Intersects(Game1.Instance.GameAbilityBar.Button1.BoundingBox))
            {
                Console.WriteLine("Collided");
                Game1.Instance.GameAbilityBar.setAbility(args.AbilityID, Game1.Instance.GameAbilityBar.AbilityList[args.AbilityID]);
            }
            skillDragged = args.Dragged;
        }
    }
}
