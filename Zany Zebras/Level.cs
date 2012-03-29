using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Zany_Zebras
{
    class Level
    {
        private Grid grid;
        public Grid Grid
        {
            get
            {
                return grid;
            }
        }

        //EntityManager entityManager;

        public Level()
        {
            grid = new Grid(25, 15);
        }

        public void Reset()
        {
            // Here we randomize the level and set the tiles to new things
            // Grid Add new Ability
            // Set the tile occupancy
            
            //Delete and create the new Zebras
            
            //Go to store screen for player to buy new skills

        }

        public void Update(GameTime gameTime)
        {
            grid.Update(gameTime);
        }

        public void Render()
        {
            grid.Render();
        }
    }
}
