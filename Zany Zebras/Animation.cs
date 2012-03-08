using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Zany_Zebras
{
    class Animation
    {
        private int _currentFrame;
        private int numFrames;
        private int frameWidth;
        private int frameHeight;
        private int offsetY;
        private double elapsedTime;
        private List<Rectangle> frames;

        public Rectangle getFrame
        {
            get
            {
                return frames[_currentFrame];
            }
        }

        public Animation(int num, int width, int height, int OffsetY)
        {
            numFrames = num;
            frameWidth = width;
            frameHeight = height;
            offsetY = OffsetY;
            elapsedTime = 0.0f;
            frames = new List<Rectangle>();

            for (int i = 0; i <= numFrames; i++)
            {
                frames.Add(new Rectangle(i*frameWidth, offsetY * frameHeight, frameWidth, frameHeight));
            }
        }

        public void Update(GameTime gameTime)
        {
            elapsedTime += gameTime.ElapsedGameTime.Milliseconds;
            if (elapsedTime >= 12*16)
            {
                elapsedTime = 0.0f;
                _currentFrame++;
                if (_currentFrame >= numFrames)
                {
                    _currentFrame = 0;
                }
            }
        }
    }
}
