using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Zany_Zebras
{
    class PauseScreen : GameScreen
    {

        public PauseScreen()
        {
            Pause = true;
            Block = false;
        }
                
        public override void Render()
        {
            FontManager.Instance.Render("Paused the Game!", new Vector2(100,100));
        }

        public override void Update(GameTime gameTime)
        {
        }   
    }
}
