using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
namespace Zany_Zebras
{
    class Input
    {
        private MouseState _state;
        public Vector2 MousePosition
        {
            get
            {
                return new Vector2(_state.X, _state.Y);
            }
        }

        public virtual void mouseDown()
        {

        }

        public virtual void mouseUp()
        {

        }
    }
}
