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
        private Tile[,] grid;
        private Texture2D tileSheet;
        private Random random;

        public Grid(int width, int height)
        {
            mapWidth = width;
            mapHeight = height;
            random = new Random();
            tileSheet = Game1.Instance.gameContent.Load<Texture2D>("Sprites/map_tilesheet");
            grid = new Tile[height, width];
            Vector2 tileID = new Vector2(0,0);
            bool blocked = false;
            string type = "";

            for (int y = 0; y < mapHeight; y++)
            {
                for (int x = 0; x < mapWidth; x++)
                {
                    int percent = random.Next(100);
                    if (percent < 5)
                    {
                        tileID = new Vector2(2,0);
                        blocked = true;
                        type = "Object";

                    }
                    else if (percent < 35 && percent > 5)
                    {
                        tileID = new Vector2(1, 0);
                        blocked = false;
                    }
                    else
                    {
                        tileID = new Vector2(0, 0);
                        blocked = false;
                    }
                    grid[y, x] = new Tile(tileID, ref tileSheet, x, y, 40, 40);
                    grid[y, x].Occupied = blocked;
                    grid[y, x].Type = type;
                }
            }
        }

        
        public IAbility getAbility(int x, int y)
        {
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
        }

        public void Update(GameTime gameTime)
        {
            for (int y = 0; y < mapHeight; y++)
            {
                for (int x = 0; x < mapWidth; x++)
                {
                    grid[y, x].UpdateAbility(gameTime);
                }
            }
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

            for (int y = 0; y < mapHeight; y++)
            {
                for (int x = 0; x < mapWidth; x++)
                {
                    grid[y, x].RenderAbility();
                }
            }
        }
    }
}
