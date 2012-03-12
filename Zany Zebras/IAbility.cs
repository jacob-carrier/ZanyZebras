using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Zany_Zebras
{
    class IAbility : ICloneable
    {
        public Texture2D image;
        public Vector2 position;
        public Rectangle dest;
        public int damage;

        public virtual void Render() { }
        public virtual void Update(GameTime gameTime) { }
        public virtual void gameEvent(Zebra z) { }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
