using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Zany_Zebras
{
    public class Nuke : IAbility
    {
        private Animation anim;
       
        private float elapsedTime;
        public Nuke(Vector2 v)
        {
            image = Game1.Instance.gameContent.Load<Texture2D>("Sprites/nuke_reference");
            position = v;
            damage = 20;
            anim = new Animation(7, 150, 115, 0);
            done = false;
            XTiles = 25;
            YTiles = 15;
        }

        public override void Update(GameTime gameTime)
        {
            anim.Update(gameTime);
            elapsedTime += gameTime.ElapsedGameTime.Seconds;
            if (elapsedTime >= 5)
            {
                done = true;
            }
        }

        public override void Render()
        {
            Rectangle dest = new Rectangle((int)position.X-55, (int)position.Y-55,115,150);
            Game1.Instance.SpriteBatch.Draw(image, dest, anim.getFrame, Color.White);
        }

        public override void  gameEvent(Zebra z)
        {
            z.Health -= 20;
        }
    }
}
