using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Zany_Zebras
{
    public class ScreenManager
    {
        private List<GameScreen> _screens;

        public ScreenManager()
        {
            _screens = new List<GameScreen>();
        }

        public void pushScreen(GameScreen screen)
        {
            _screens.Add(screen);
        }

        public void popScreen()
        {
            _screens.RemoveAt(_screens.Count - 1);
        }

        public GameScreen currentScreen()
        {
            return _screens.Last();
        }

        public void Render()
        {
            /*foreach (GameScreen screen in _screens)
            {
                if(!screen.Block)
                {
                    screen.Render();
                }
            }
             */
            for (int i = 0; i < _screens.Count; i++)
            {
                if (!_screens[i].Block)
                {
                    _screens[i].Render();
                }
            }
        }

        public void Update(GameTime gameTime)
        {
            /*foreach (GameScreen screen in _screens)
            {
                if (!screen.Pause)
                {
                    screen.Update(gameTime);
                }
            }
            */
            for (int i = 0; i < _screens.Count; i++)
            {
                if (!_screens[i].Pause)
                {
                    _screens[i].Update(gameTime);
                }
            }
        }
    }
}
