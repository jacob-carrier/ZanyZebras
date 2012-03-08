using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zany_Zebras
{
    class ScreenManager
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

        public void Render()
        {
            foreach (GameScreen screen in _screens)
            {
                if(!screen.Block)
                {
                    screen.Render();
                }
            }
        }

        public void Update()
        {
            foreach (GameScreen screen in _screens)
            {
                if (!screen.Pause)
                {
                    screen.Update();
                }
            }
        }
    }
}
