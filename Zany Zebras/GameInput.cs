using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace Zany_Zebras
{
    class GameInput : Input
    {
        private Level levelRef;
        private GamePlayScreen gpScreen;
        public GameInput(GamePlayScreen screen, Level level)
        {
            levelRef = level;
            gpScreen = screen;
        }
        
        public override void Update()
        {
            newState = Mouse.GetState();

            if (mouseDown())
            {
                gpScreen.ShowMouseText = true;
            }

            if (mouseUp())
            {
                gpScreen.RenderTileOutline = true;
            }

            oldState = newState;
        }
    }
}
