using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Zany_Zebras
{
    class Zebra
    {
        
        private Texture2D sheet;
        private Dictionary<String, Animation> animations;
        private string currentAnim;
        private Vector2 position, movement;
        private Point center;
        private int health;
        private Rectangle bounds;

        public Zebra(Texture2D image, int posX, int posY)
        {
            sheet = image;
            position = new Vector2(posX, posY);
            movement = new Vector2(1, 0);
            animations = new Dictionary<string, Animation>();
            health = 20;
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
            animations[currentAnim].Update(gameTime);
            position += movement;
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
