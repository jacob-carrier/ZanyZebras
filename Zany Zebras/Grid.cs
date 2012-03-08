using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Zany_Zebras
{
    class Grid
    {
        private int mapWidth, mapHeight;
        //private Dictionary<int, IAbility> abilitiesOnGrid;
        private Tile[,] grid;
        private Texture2D tileSheet;

        public Grid(int width, int height)
        {
            mapWidth = width;
            mapHeight = height;
            tileSheet = Game1.Instance.gameContent.Load<Texture2D>("Sprites/map_tilesheet");
            grid = new Tile[height, width];

            for (int y = 0; y < mapHeight; y++)
            {
                for (int x = 0; x < mapWidth; x++)
                {
                    grid[y, x] = new Tile(new Vector2(0,0), ref tileSheet, x, y, 40, 40);
                }
            }

            //abilitiesOnGrid = new Dictionary<int, IAbility>();
        }

        
        public IAbility getAbility(int x, int y)
        {
            //return abilitiesOnGrid[this.getCell(x, y).AbilityId];
            return this.getCell(x, y).Ability;
        }
        

        public Tile getCell(int x, int y)
        {
            return grid[y, x];
        }

      
        public void setCell(IAbility ability, int x, int y)
        {
            grid[y, x].Ability = ability;
            grid[y, x].Occupied = true;
            //abilitiesOnGrid.Add(abilityId, ability);
        }

        public void Render()
        {
            for(int y = 0; y < mapHeight; y++)
            {
                for (int x = 0; x < mapWidth; x++)
                {
                    grid[y, x].Render();
                }
            }
        }
    }
}
