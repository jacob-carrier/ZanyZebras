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

        private bool dragged = false;
        public bool Dragged
        {
            get
            {
                return dragged;
            }

            set
            {
                dragged = value;
            }
        }
    }

    public class GuiButton : Input
    {
        public event ClickHandler Click;
        public event HoverHandler Hover;
        public event DraggingHandler Drag;
        public event DropHandler Drop;
        public delegate void ClickHandler(GuiButton b, ButtonArgs args); //recieves function that handles the click with the ID that represents the Ability
        public delegate void HoverHandler(GuiButton b, ButtonArgs args); //recieves function that handles which button the mouse is over;
        public delegate void DraggingHandler(GuiButton b, ButtonArgs args);
        public delegate void DropHandler(GuiButton b, ButtonArgs args);

        bool dragging = false;

        private Rectangle bounds;
        public Rectangle BoundingBox
        {
            get
            {
                return bounds;
            }
        }

        private Texture2D image;
        public Texture2D ButtonImage
        {
            get
            {
                return image;
            }
            set
            {
                image = value;
            }
        }
        // Do like tilesheets, and destination rect offset is based on ability
        private Vector2 position;
        private Vector2 frameID;
        public Vector2 FrameID
        {
            set
            {
                frameID = value;
            }
        }

        private int abilityID;
        public int AbilityID
        {
            set
            {
                abilityID = value;
            }
        }

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
                if (dragging)
                {
                    dragging = false;
                    if (Drag != null)
                    {
                        ButtonArgs args = new ButtonArgs(abilityID);
                        args.Dragged = false;
                        Drop(this, args);
                    }
                }

                if (!dragging)
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
                else
                {
                    frameID = new Vector2(0, 0);
                }
            }

            if (newState.X > bounds.X && newState.X < (bounds.X + bounds.Width)
                    && newState.Y > bounds.Y && newState.Y < (bounds.Y + bounds.Height) && mouseDown())
            {
                dragging = true;
            }

            if (dragging)
            {
                if (Drag != null)
                {
                    ButtonArgs args = new ButtonArgs(abilityID);
                    args.Dragged = true;
                    Drag(this, args);
                }
            }

            oldState = newState;
        }

        public void Render()
        {
            Rectangle dest = new Rectangle((int)frameID.X*bounds.Width, 0, bounds.Width, bounds.Height);
            Game1.Instance.SpriteBatch.Draw(image, bounds, dest, Color.White);
        }
    }
}
