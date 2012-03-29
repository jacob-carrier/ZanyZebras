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
                GuiButton b = Game1.Instance.GameAbilityBar.abilityButton(new Point(newState.X, newState.Y));
                if (b != null)
                {
                    if (selectedAbility == null)
                    {
                        Console.WriteLine(b.AbilityID);
                        selectedAbility = Game1.Instance.GameAbilityBar.getAbility(b.AbilityID);
                    }
                }
                else
                {
                    if (selectedAbility != null)
                    {
                        if (!levelRef.Grid.getCell(newState.X / 40, newState.Y / 40).Occupied)
                        {
                            IAbility a = (IAbility)selectedAbility.Clone();
                            int X = newState.X / 40;
                            int Y = newState.Y / 40;
                            a.position = new Vector2(levelRef.Grid.getCell(X, Y).Position.X, levelRef.Grid.getCell(X, Y).Position.Y);
                            levelRef.Grid.setCell(a, newState.X / 40, newState.Y / 40);
                            levelRef.Grid.getCell(newState.X / 40, newState.Y / 40).Occupied = true;
                            selectedAbility = null;
                        }
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
