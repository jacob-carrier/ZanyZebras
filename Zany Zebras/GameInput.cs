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
        public IAbility SelectedAbility
        {
            get
            {
                return selectedAbility;
            }
        }
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
                            for (int i = (newState.Y / 40); i < (newState.Y / 40) + a.YTiles; i++)
                            {
                                for (int j = (newState.X / 40); j < (newState.X / 40) + a.XTiles; j++)
                                {
                                    levelRef.Grid.setCell(a, j, i);
                                    levelRef.Grid.getCell(j, i).Occupied = true;
                                }
                            }
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
