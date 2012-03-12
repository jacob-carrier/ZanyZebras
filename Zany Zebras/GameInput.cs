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
        private IAbility selectedAbility;
        public GameInput(GamePlayScreen screen, Level level)
        {
            levelRef = level;
            gpScreen = screen;
            selectedAbility = null;
        }
        
        public override void Update()
        {
            newState = Mouse.GetState();

            if (mouseReleased())
            {
                gpScreen.ShowMouseText = true;
                if (newState.X > gpScreen.AbilityBar.Button1.X && newState.X < (gpScreen.AbilityBar.Button1.X + gpScreen.AbilityBar.Button1.Width)
                    && newState.Y > gpScreen.AbilityBar.Button1.Y && newState.Y < (gpScreen.AbilityBar.Button1.Y + gpScreen.AbilityBar.Button1.Height))
                {
                    if (selectedAbility == null)
                    {
                        selectedAbility = gpScreen.AbilityBar.getAbility(1);
                    }
                }
                else
                {
                    if (selectedAbility != null)
                    {
                        IAbility a = (IAbility)selectedAbility.Clone();
                        int X = newState.X / 40;
                        int Y = newState.Y / 40;
                        a.position = new Vector2(gpScreen.LevelInstance.Grid.getCell(X, Y).Position.X, gpScreen.LevelInstance.Grid.getCell(X, Y).Position.Y);
                        gpScreen.LevelInstance.Grid.setCell(a, newState.X / 40, newState.Y / 40);
                    }
                }
            }

            if (mouseUp())
            {
                gpScreen.RenderTileOutline = true;
            }            

            oldState = newState;
        }
    }
}
