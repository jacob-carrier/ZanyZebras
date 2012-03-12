using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Zany_Zebras
{
    class Pit : IAbility
    {
        public Pit(Vector2 v)
        {
            image = Game1.Instance.gameContent.Load<Texture2D>("Sprites/Clear_shovel");
            position = v;
            damage = 20;
        }

        public override void Update(GameTime gameTime)
        {
            
        }

        public override void Render()
        {
            dest = new Rectangle((int)position.X, (int)position.Y, 32, 32);
            Game1.Instance.SpriteBatch.Draw(image, dest, new Rectangle(32, 0, 32, 32), Color.White);
        }

        public override void gameEvent(Zebra z)
        {
            z.Health -= 20;
            Console.WriteLine("Zebra's Health: " + z.Health);
        }
    }
}
