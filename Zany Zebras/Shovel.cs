using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Zany_Zebras
{
    class Shovel : IAbility
    {
        

        //Game1.Instance.Load(image)
        public Shovel(int x, int y)
        {
            position.X = x;
            position.Y = y;
            //image = Game1.Instance.gameContent.Load<Texture2D>("Sprites/shovel_button");
        }

        public override void Update(GameTime gameTime)
        {

        }

        public override void Render()
        {
            dest = new Rectangle((int)position.X, (int)position.Y, 48, 48);
            Game1.Instance.SpriteBatch.Draw(image, dest, new Rectangle(0,0,48,48), Color.White);
        }
    }
}
