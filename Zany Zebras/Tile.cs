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
        private Rectangle src, bounding;
        private Vector2 position;
        //Holds reference to the abilityManager to update/render/access them through tile Data
        IAbility ability;
        private Vector2 tileId;
        private int width;
        private int height;
        private Boolean occupied;
        private string type;
        public string Type
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
            }
        }

        public Rectangle BoundingBox
        {
            get
            {
                return bounding;
            }
        }

        public IAbility Ability
        {
            get
            {
                return ability;
            }

            set
            {
                ability = value;
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

        public Vector2 Position
        {
            get
            {
                return position;
            }
        }

        public Tile(Vector2 id, ref Texture2D Sheet, int x, int y, int Width, int Height)
        {
            tileId = id;
            sheet = Sheet;
            position = new Vector2(x*Width, y*Height);
            bounding = new Rectangle((int)position.X, (int)position.Y, Width, Height);
            width = Width;
            height = Height;
            ability = null;
        }

        public void Render()
        {
            src = new Rectangle((int)tileId.X * width, (int)tileId.Y * height, width, height);
            Game1.Instance.SpriteBatch.Draw(sheet, position, src, Color.White);
            
        }

        public void RenderAbility()
        {
            if (ability != null)
            {
                ability.Render();
            }
        }

        public void UpdateAbility(GameTime gameTime)
        {
            if (ability != null)
            {
                ability.Update(gameTime);
            }
        }
    }
}
