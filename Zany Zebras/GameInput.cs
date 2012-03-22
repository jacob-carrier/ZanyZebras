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
                if (newState.X > Game1.Instance.GameAbilityBar.Button1.BoundingBox.X && newState.X < (Game1.Instance.GameAbilityBar.Button1.BoundingBox.X + Game1.Instance.GameAbilityBar.Button1.BoundingBox.Width)
                    && newState.Y > Game1.Instance.GameAbilityBar.Button1.BoundingBox.Y && newState.Y < (Game1.Instance.GameAbilityBar.Button1.BoundingBox.Y + Game1.Instance.GameAbilityBar.Button1.BoundingBox.Height))
                {
                    if (selectedAbility == null)
                    {
                        selectedAbility = Game1.Instance.GameAbilityBar.getAbility(Game1.Instance.GameAbilityBar.Button1.AbilityID);
                    }
                }
                else
                {
                    if (selectedAbility != null)
                    {
                        IAbility a = (IAbility)selectedAbility.Clone();
                        int X = newState.X / 40;
                        int Y = newState.Y / 40;
                        a.position = new Vector2(levelRef.Grid.getCell(X, Y).Position.X, levelRef.Grid.getCell(X, Y).Position.Y);
                        levelRef.Grid.setCell(a, newState.X / 40, newState.Y / 40);
                        levelRef.Grid.getCell(newState.X / 40, newState.Y / 40).Occupied = true;
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
