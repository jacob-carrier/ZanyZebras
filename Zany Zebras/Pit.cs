﻿using System;
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
            image = Game1.Instance.gameContent.Load<Texture2D>("Sprites/pit");
            position = v;
            damage = 20;
            done = false;
            XTiles = 1;
            YTiles = 1;
        }

        public override void Update(GameTime gameTime)
        {
            
        }

        public override void Render()
        {
            dest = new Rectangle((int)position.X, (int)position.Y, 40, 40);
            Game1.Instance.SpriteBatch.Draw(image, dest, new Rectangle(0, 0, 48, 48), Color.White);
        }

        public override void gameEvent(Zebra z)
        {
            z.Health -= damage;
        }
    }
}
