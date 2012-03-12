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
        private Vector2 position;
        private Point center;
        private int speed;

        public Zebra(Texture2D image, int posX, int posY)
        {
            sheet = image;
            position = new Vector2(posX, posY);
            animations = new Dictionary<string, Animation>();
            speed = 2;
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

        public Point Center
        {
            get
            {
                return animations[currentAnim].getFrame.Center;
            }
        }

        public string CurrentAnimation
        {
            set
            {
                currentAnim = value;
            }
        }

        public void Update(GameTime gameTime)
        {
            animations[currentAnim].Update(gameTime);
            position.X += speed;
            if (position.X > 450)
            {
                speed = -speed;
                currentAnim = "left";
            }
            if (position.X < 10)
            {
                speed = -speed;
                currentAnim = "right";
            }
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
