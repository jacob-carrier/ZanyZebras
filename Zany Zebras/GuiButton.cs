using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace Zany_Zebras
{
    public class ButtonArgs : EventArgs
    {

        public ButtonArgs(int id)
        {
            abilityID = id;
        }
        private int abilityID;
        public int AbilityID
        {
            get
            {
                return abilityID;
            }
        }
    }

    class GuiButton : Input
    {
        public event ClickHandler Click;
        public event HoverHandler Hover;
        public delegate void ClickHandler(GuiButton b, ButtonArgs args); //recieves function that handles the click with the ID that represents the Ability
        public delegate void HoverHandler(GuiButton b, ButtonArgs args); //recieves function that handles which button the mouse is over;

        private Rectangle bounds;
        public Rectangle BoundingBox
        {
            get
            {
                return bounds;
            }
        }

        private Texture2D image;
        private Vector2 position;
        private bool hover;
        public bool MouseOver
        {
            get
            {
                return hover;
            }
        }
        private int abilityID;

        public GuiButton(Vector2 pos, string imageName, int width, int height, int abilityID)
        {
            position = pos;
            image = Game1.Instance.Content.Load<Texture2D>(imageName);
            bounds = new Rectangle((int)position.X, (int)position.Y, width, height);
            this.abilityID = abilityID;
        }

        public override void Update()
        {
            newState = Mouse.GetState();
            if (mouseReleased())
            {
                if (newState.X > bounds.X && newState.X < (bounds.X + bounds.Width)
                    && newState.Y > bounds.Y && newState.Y < (bounds.Y + bounds.Height))
                {
                    if (Click != null)
                    {
                        ButtonArgs args = new ButtonArgs(abilityID);
                        Click(this, args);
                    }
                }
            }

            if (mouseUp())
            {
                if (newState.X > bounds.X && newState.X < (bounds.X + bounds.Width)
                    && newState.Y > bounds.Y && newState.Y < (bounds.Y + bounds.Height))
                {
                    if (Hover != null)
                    {
                        ButtonArgs args = new ButtonArgs(abilityID);
                        Hover(this, args);
                    }
                }
            }

            oldState = newState;
        }

        public void Render()
        {
            Game1.Instance.SpriteBatch.Draw(image, bounds, Color.White);
        }
    }
}
