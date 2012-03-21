using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Zany_Zebras
{
    public class AbilityBar
    {
        List<IAbility> abilityList; // List of all possible abilities
        Dictionary<int, IAbility> abilities; // Abilities in the bar from 1-4
        GuiButton button1, button2;
        Vector2 position;
        Texture2D bar;

        public GuiButton Button1
        {
            get
            {
                return button1;
            }
        }

        public List<IAbility> AbilityList
        {
            get
            {
                return abilityList;
            }
        }

        public AbilityBar(int x, int y)
        {
            abilityList = new List<IAbility>();
            abilityList.Add(new Shovel(0, 0));
            abilityList.Add(new Pit(new Vector2(0, 0)));

            abilities = new Dictionary<int,IAbility>();
            position = new Vector2(x, y);
            bar = Game1.Instance.gameContent.Load<Texture2D>("Sprites/abilitybar");
            button1 = new GuiButton(new Vector2(200,400), "Sprites/button_template", 48, 48, 0);
            button2 = new GuiButton(new Vector2(248, 400), "Sprites/button_template", 48, 48, 0);
        }
         
        public void  setAbility(int id, IAbility newAbility)
        {
            if (abilities.ContainsKey(id))
            {
                abilities[id] = newAbility;
            }
            else
            {
                abilities.Add(id, newAbility);
            }
            button1.AbilityID = id;
            button1.ButtonImage = newAbility.image;
        }

        public IAbility getAbility(int id)
        {
            if(abilities.ContainsKey(id))
                return abilities[id];
            return null;
        }

        public void Render()
        {
            Game1.Instance.SpriteBatch.Draw(bar, new Rectangle((int)position.X - 2, (int)position.Y - 2, 100, 50), Color.Black);
            //for (int x = 1; x <= 1; x++)
               // abilities[x].Render();
            button1.Render();
            button2.Render();
        }

        public void Update(GameTime gameTime)
        {
            //for (int x = 1; x <= 1; x++)
                //abilities[x].Update(gameTime);
        } 
    }
}
