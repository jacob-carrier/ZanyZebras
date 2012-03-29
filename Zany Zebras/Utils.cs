using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Zany_Zebras
{
    class Utils
    {
        private static Utils _instance;
        public static Utils Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Utils();
                }

                return _instance;
            }
        }

        public Utils()
        {

        }

        public void drawTileOutline(Tile t, Vector4 color)
        {
            Game1.Instance.SpriteBatch.Draw(Game1.Instance.gameContent.Load<Texture2D>("Sprites/outline"), t.BoundingBox, new Color(color));
        }

        public bool BoundingBoxCollision(Rectangle r1, Rectangle r2)
        {
            return r1.Intersects(r2);
        }
    }
}
