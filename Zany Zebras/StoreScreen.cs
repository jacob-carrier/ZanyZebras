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
        private GuiButton spikeButton, pitButton, lionButton;
        private string currentText ="";
        bool skillDragged = false;
        Texture2D draggedImage;

        public StoreScreen()
        {
            buttons = new List<GuiButton>();
            abilities = new List<IAbility>();
            pitButton = new GuiButton(new Vector2(200, 100), "Sprites/pit_button", 48, 48, 0);
            pitButton.Enabled = true;
            spikeButton = new GuiButton(new Vector2(156, 172), "Sprites/spikes_button", 48, 48, 1);
            spikeButton.Enabled = false;
            lionButton = new GuiButton(new Vector2(248, 172), "Sprites/lion_button", 48, 48, 2);
            spikeButton.Enabled = false;
            buttons.Add(pitButton);
            buttons.Add(spikeButton);
            buttons.Add(lionButton);

            abilityDesc = new List<string>();

            abilityDesc.Add("This is the pit ability");
            abilityDesc.Add("This is the spike ability");
            abilityDesc.Add("This is the lion ability");

            for (int i = 0; i < buttons.Count; i++)
            {
                if (buttons[i].Enabled)
                {
                    buttons[i].Click += new GuiButton.ClickHandler(addAbilityToBar);
                    buttons[i].Hover += new GuiButton.HoverHandler(changeText);
                    buttons[i].Drag += new GuiButton.DraggingHandler(dragging);
                    buttons[i].Drop += new GuiButton.DropHandler(dropping);
                }
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
            FontManager.Instance.Render(currentText, new Vector2(500,100));
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
            GuiButton abilityBarButton = Game1.Instance.GameAbilityBar.abilityBoundingBox(new Point(Mouse.GetState().X, Mouse.GetState().Y));
            if (abilityBarButton != null)
            {
                skillDragged = args.Dragged;
                if (box.Intersects(abilityBarButton.BoundingBox))
                {
                    Console.WriteLine("Collided");
                    Game1.Instance.GameAbilityBar.setAbility(args.AbilityID, Game1.Instance.GameAbilityBar.AbilityList[args.AbilityID]);
                    abilityBarButton.AbilityID = args.AbilityID;
                    abilityBarButton.ButtonImage = b.ButtonImage;
                }
            }
            else
            {
                skillDragged = false;
            }
        }
    }
}
