using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Zany_Zebras
{
    public class Zebra
    {
        
        private Texture2D sheet;
        private Dictionary<String, Animation> animations;
        private string currentAnim;
        private Vector2 position, movement, direction;
        private int health;
        private Rectangle bounds;
        private float elapsedTime;
        private Random random;

        public Zebra(Texture2D image, int posX, int posY)
        {
            sheet = image;
            position = new Vector2(posX, posY);
            movement = new Vector2(1, 1);
            direction = new Vector2(1, 0);
            animations = new Dictionary<string, Animation>();
            health = 20;
            random = new Random();
        }

        public float X
        {
            get
            {
                return position.X;
            }

            set
            {
                position.X = value;
            }
        }

        public float Y
        {
            get
            {
                return position.Y;
            }

            set
            {
                position.Y = value;
            }
        }

        public Rectangle BoundingBox
        {
            get
            {
                return bounds;
            }
        }

        public Point Center
        {
            get
            {
                return bounds.Center;
            }
        }

        public string CurrentAnimation
        {
            set
            {
                currentAnim = value;
            }
        }

        public int Health
        {
            get
            {
                return health;
            }

            set
            {
                health = value;
            }
        }

        public void Update(GameTime gameTime)
        {
            
            elapsedTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
            animations[currentAnim].Update(gameTime);
            if (elapsedTime > 2)
            {
                direction = new Vector2(1, random.Next(-2, 2));
                elapsedTime = 0;
            }
            position += movement * direction;

            if (position.Y < 0)
            {
                position.Y = 0;
            }

            if (position.Y >= Game1.Instance.Window.ClientBounds.Y + Game1.Instance.Window.ClientBounds.Height)
            {
                position.Y = Game1.Instance.Window.ClientBounds.Y + Game1.Instance.Window.ClientBounds.Height;
            }

            bounds = new Rectangle((int)position.X, (int)position.Y, animations[currentAnim].getFrame.Width, animations[currentAnim].getFrame.Height);
        }

        public void Render()
        {
            Game1.Instance.SpriteBatch.Draw(sheet, position, animations[currentAnim].getFrame, Color.White);
        }

        public void addAnimation(string animName, Animation newAnim)
        {
            animations.Add(animName, newAnim);
        }
    }
}
