using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

namespace Zany_Zebras
{
    class FontManager
    {
        SpriteFont font;
        private static FontManager _instance;

        public FontManager()
        {
            font = Game1.Instance.gameContent.Load<SpriteFont>("Fonts/gameText");
        }

        public static FontManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new FontManager();
                }
                return _instance;
            }
        }

        public void Render(String text, Vector2 position)
        {
            Game1.Instance.SpriteBatch.DrawString(font, text, position, Color.White);
        }
    }
}
