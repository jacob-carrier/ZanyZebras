using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
namespace Zany_Zebras
{
    public class Input
    {
        public MouseState oldState, newState;
        public Vector2 MousePosition
        {
            get
            {
                return new Vector2(newState.X, newState.Y);
            }
        }

        public bool mouseDown()
        {
            if (newState.LeftButton == ButtonState.Pressed && oldState.LeftButton == ButtonState.Pressed)
            {
                return true;
            }
            return false;
        }

        public bool mouseUp()
        {
            if (newState.LeftButton == ButtonState.Released && oldState.LeftButton == ButtonState.Released)
            {
                return true;
            }
            return false;
        }

        public bool mouseReleased()
        {
            if (newState.LeftButton == ButtonState.Released && oldState.LeftButton == ButtonState.Pressed)
            {
                return true;
            }

            return false;
        }

        public bool mousePressed()
        {
            if (newState.LeftButton == ButtonState.Pressed && oldState.LeftButton == ButtonState.Released)
            {
                return true;
            }

            return false;
        }


        public virtual void Update() { }
    }
}
