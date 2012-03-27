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
        private GuiButton spikeButton, pitButton, lionButton, gameButton;
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
            spikeButton.Cost = 50;
            spikeButton.Click += new GuiButton.ClickHandler(buyAbility);
            spikeButton.Hover += new GuiButton.HoverHandler(showCost);
            lionButton = new GuiButton(new Vector2(248, 172), "Sprites/lion_button", 48, 48, 2);
            lionButton.Enabled = false;
            lionButton.Cost = 100;
            lionButton.Click += new GuiButton.ClickHandler(buyAbility);
            lionButton.Hover += new GuiButton.HoverHandler(showCost);
            gameButton = new GuiButton(new Vector2(500, 550), "Sprites/button", 193, 25, 0);
            gameButton.Enabled = true;
            gameButton.ChangeScreens += new GuiButton.GuiHandler(changeScreens);
            gameButton.Hover += new GuiButton.HoverHandler(gameButton_Hover);
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
            gameButton.Update();
            Game1.Instance.GameAbilityBar.Update(gameTime);
        }

        public override void Render()
        {
            foreach (GuiButton b in buttons)
            {
                b.Render();
            }
            gameButton.Render();
            Game1.Instance.GameAbilityBar.Render();
            if (skillDragged)
            {
                Game1.Instance.SpriteBatch.Draw(draggedImage, new Rectangle(Mouse.GetState().X-24, Mouse.GetState().Y-24, 48, 48),new Rectangle(0,0,48,48), Color.White);
            }
            FontManager.Instance.Render(currentText, new Vector2(500,100));
            FontManager.Instance.Render("Store Points: " + Game1.Instance.StorePoints, new Vector2(500, 16));
            string nextLevel = "Next Level";
            FontManager.Instance.Render(nextLevel, new Vector2(gameButton.BoundingBox.X + gameButton.BoundingBox.Width / 4, gameButton.BoundingBox.Y + gameButton.BoundingBox.Height / 2 - 12) );
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

        private void gameButton_Hover(GuiButton b, ButtonArgs args)
        {
            b.FrameID = new Vector2(1, 0);
        }

        private void dragging(GuiButton b, ButtonArgs args){
            skillDragged = args.Dragged;
            draggedImage = b.ButtonImage;
        }

        private void dropping(GuiButton b, ButtonArgs args)
        {
            Rectangle box = new Rectangle(Mouse.GetState().X - 24, Mouse.GetState().Y - 24, 48, 48);
            GuiButton abilityBarButton = Game1.Instance.GameAbilityBar.abilityButton(new Point(Mouse.GetState().X, Mouse.GetState().Y));
            if (abilityBarButton != null)
            {
                skillDragged = args.Dragged;
                if (box.Intersects(abilityBarButton.BoundingBox))
                {
                    Console.WriteLine("Collided");
                    Game1.Instance.GameAbilityBar.setAbility(args.AbilityID, Game1.Instance.GameAbilityBar.AbilityList[args.AbilityID]);
                    Console.WriteLine(args.AbilityID);
                    abilityBarButton.AbilityID = args.AbilityID;
                    abilityBarButton.ButtonImage = b.ButtonImage;
                }
            }
            else
            {
                skillDragged = false;
            }
        }

        private void changeScreens(GuiButton b)
        {
            //Game1.Instance.ScreenManager.currentScreen().Block = true;
            //Game1.Instance.ScreenManager.currentScreen().Pause = true;
            //Game1.Instance.ScreenManager.popScreen();
            Game1.Instance.ScreenManager.currentScreen().Pause = true;
            Game1.Instance.ScreenManager.pushScreen(new GamePlayScreen());
        }

        private void buyAbility(GuiButton b, ButtonArgs args)
        {
            if (Game1.Instance.StorePoints >= b.Cost)
            {
                Game1.Instance.StorePoints -= b.Cost;
                b.Enabled = true;
                b.Click -= buyAbility;
                b.Hover -= showCost;
                b.Click += new GuiButton.ClickHandler(addAbilityToBar);
                b.Hover += new GuiButton.HoverHandler(changeText);
                b.Drag += new GuiButton.DraggingHandler(dragging);
                b.Drop += new GuiButton.DropHandler(dropping);
            }
            else
            {
                currentText = "Not enough store points!";
            }
        }

        private void showCost(GuiButton b, ButtonArgs args)
        {
            currentText = "Ability Cost: " + b.Cost + " Store Points\n" + abilityDesc[args.AbilityID];
        }
    }
}
