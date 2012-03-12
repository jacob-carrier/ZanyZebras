using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Zany_Zebras
{
    class AbilityBar
    {
        Dictionary<int, IAbility> abilities;
        Vector2 position;
        Texture2D bar;

        public Rectangle Button1
        {
            get
            {
                return abilities[1].dest;
            }
        }

        public AbilityBar(int x, int y)
        {
            abilities = new Dictionary<int,IAbility>();
            position = new Vector2(x, y);
            bar = Game1.Instance.gameContent.Load<Texture2D>("Sprites/abilitybar");
        }
         
        public void  setAbility(int id, IAbility newAbility)
        {
            abilities.Add(id, newAbility);
        }

        public IAbility getAbility(int id)
        {
            if(abilities.ContainsKey(id))
                return abilities[id];
            return null;
        }

        public void Render()
        {
            Game1.Instance.SpriteBatch.Draw(bar, new Rectangle((int)position.X - 2, (int)position.Y - 2, 100, 36), Color.Black);
            for (int x = 1; x <= 1; x++)
                abilities[x].Render();
        }

        public void Update(GameTime gameTime)
        {
            for (int x = 1; x <= 1; x++)
                abilities[x].Update(gameTime);
        } 
    }
}
