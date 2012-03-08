using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Zany_Zebras
{
    class Tile
    {
        private Texture2D sheet;
        private Rectangle src;
        private Vector2 position;
        //Holds reference to the abilityManager to update/render/access them through tile Data
        //IAbility ability;
        private Vector2 tileId;
        private int width;
        private int height;
        private Boolean occupied;
        int abilityId;

        public int AbilityId
        {
            get
            {
                return abilityId;
            }

            set
            {
                abilityId = value;
            }
        }

        public Boolean Occupied
        {
            get
            {
                return occupied;
            }

            set
            {
                occupied = value;
            }
        }

        public int tileX
        {
            set
            {
                tileId.X = value;
            }
        }

        public int tileY
        {
            set
            {
                tileId.Y = value;
            }
        }

        public Tile(Vector2 id, ref Texture2D Sheet, int x, int y, int Width, int Height)
        {
            tileId = id;
            sheet = Sheet;
            position = new Vector2(x, y);
            width = Width;
            height = Height;
        }

        public void Render()
        {
            src = new Rectangle((int)tileId.X * width, (int)tileId.Y * height, width, height);
            Game1.Instance.SpriteBatch.Draw(sheet, position, src, Color.White);
        }
    }
}
