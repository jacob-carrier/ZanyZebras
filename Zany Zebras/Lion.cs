using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Zany_Zebras
{
    public class Lion : IAbility
    {
        private Animation anim;

        
        public Lion(Vector2 v)
        {
            image = Game1.Instance.gameContent.Load<Texture2D>("Sprites/Lion");
            position = v;
            damage = .7f;
            anim = new Animation(3, 80, 40, 0);
            XTiles = 2;
            YTiles = 1;
        }

        public override void Update(GameTime gameTime)
        {
            anim.Update(gameTime);
        }

        public override void Render()
        {
            Rectangle dest = new Rectangle((int)position.X, (int)position.Y, 80, 40);
            Game1.Instance.SpriteBatch.Draw(image, dest, anim.getFrame, Color.White);
        }

        public override void gameEvent(Zebra z)
        {
            z.Health -= damage;
        }
    }
}
