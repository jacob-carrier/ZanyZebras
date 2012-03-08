using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zany_Zebras
{
    class Level
    {
        private static Grid grid;
        public static Grid Grid
        {
            get
            {
                return grid;
            }
        }

        private static Level _instance;
        public static Level Instance
        {
            get
            {
                if (_instance == null)
                {
                    throw new Exception("Level Instance is Null");
                }
                else
                {
                    return _instance;
                }
            }
        }

        //EntityManager entityManager;

        public Level()
        {
            grid = new Grid(15, 15);
            _instance = this;
        }

        public void Reset()
        {
            // Here we randomize the level and set the tiles to new things
            // Grid Add new Ability
            // Set the tile occupancy
            
            //Delete and create the new Zebras
            
            //Go to store screen for player to buy new skills

        }

        public void Render()
        {
            grid.Render();
        }
    }
}
