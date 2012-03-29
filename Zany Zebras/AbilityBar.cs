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
        GuiButton button1, button2, button3;
        List<GuiButton> buttonList;
        Vector2 position;
        Texture2D bar;

        public GuiButton Button1
        {
            get
            {
                return button1;
            }
        }

        public GuiButton Button2
        {
            get
            {
                return button2;
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
            abilityList.Add(new Pit(new Vector2(0, 0)));
            abilityList.Add(new Spike(new Vector2(0, 0)));
            abilityList.Add(new Nuke(new Vector2(0, 0)));

            abilities = new Dictionary<int,IAbility>();
            position = new Vector2(x, y);
            bar = Game1.Instance.gameContent.Load<Texture2D>("Sprites/abilitybar");
            button1 = new GuiButton(new Vector2(300,550), "Sprites/button_template", 48, 48, 0);
            button1.Enabled = true;
            button2 = new GuiButton(new Vector2(348, 550), "Sprites/button_template", 48, 48, 1);
            button2.Enabled = true;
            button3 = new GuiButton(new Vector2(396, 550), "Sprites/button_template", 48, 48, 2);
            button3.Enabled = true;
            buttonList = new List<GuiButton>();
            buttonList.Add(button1);
            buttonList.Add(button2);
            buttonList.Add(button3);
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
        }

        public IAbility getAbility(int id)
        {
            if(abilities.ContainsKey(id))
                return abilities[id];
            return null;
        }

        public GuiButton abilityButton(Point p)
        {
            foreach (GuiButton b in buttonList)
            {
                if (p.X > b.BoundingBox.X && p.X < (b.BoundingBox.X + b.BoundingBox.Width)
                        && p.Y > b.BoundingBox.Y && p.Y < (b.BoundingBox.Y + b.BoundingBox.Height))
                {
                    return b;
                }
            }
            return null;
        }

        public void Render()
        {
            Game1.Instance.SpriteBatch.Draw(bar, new Rectangle((int)position.X - 2, (int)position.Y - 2, 150, 50), Color.Black);
            //for (int x = 1; x <= 1; x++)
               // abilities[x].Render();
            foreach (GuiButton b in buttonList)
            {
                b.Render();
            }
        }

        public void Update(GameTime gameTime)
        {
            //for (int x = 1; x <= 1; x++)
                //abilities[x].Update(gameTime);
            foreach (GuiButton b in buttonList)
            {
                b.Update();
            }
        } 
    }
}
