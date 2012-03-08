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
        private Dictionary<int, IAbility> abilitiesOnGrid;
        private Tile[,] grid;
        private int abilityId;
        private Texture2D tileSheet;

        public Grid(int width, int height)
        {
            abilityId = 0;
            mapWidth = width;
            mapHeight = height;
            tileSheet = Game1.Instance.gameContent.Load<Texture2D>("Sprites/tilesheet");
            grid = new Tile[height, width];

            for (int y = 0; y <= mapHeight; y++)
            {
                for (int x = 0; x <= mapWidth; x++)
                {
                    grid[y, x] = new Tile(new Vector2(0,0), ref tileSheet, x, y, mapWidth, mapHeight);
                }
            }

            abilitiesOnGrid = new Dictionary<int, IAbility>();
        }

        
        public IAbility getAbility(int x, int y)
        {
            return abilitiesOnGrid[this.getCell(x, y).AbilityId];
        }
        

        public Tile getCell(int x, int y)
        {
            return grid[y, x];
        }

      
        public void setCell(IAbility ability, int x, int y)
        {
            abilityId++;
            grid[y, x].AbilityId = abilityId;
            grid[y, x].Occupied = true;
            abilitiesOnGrid.Add(abilityId, ability);
        }

        public void Render()
        {
            for(int y = 0; y <= mapHeight; y++)
            {
                for (int x = 0; x <= mapWidth; x++)
                {
                    grid[y, x].Render();
                }
            }
        }
    }
}
