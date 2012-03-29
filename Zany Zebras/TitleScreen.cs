using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
namespace Zany_Zebras
{
    public class TitleScreen : GameScreen
    {
        private Texture2D background;
        GuiButton playButton;
        public TitleScreen()
        {
            background = Game1.Instance.gameContent.Load<Texture2D>("GUI/title_screen");
            playButton = new GuiButton(new Vector2(550, 300), "Sprites/button", 193, 25, 0);
            playButton.Enabled = true;
            playButton.Hover += new GuiButton.HoverHandler(playButton_Hover);
            playButton.ChangeScreens += new GuiButton.GuiHandler(playButton_ChangeScreens);
        }

        private void playButton_ChangeScreens(GuiButton b)
        {
            Game1.Instance.ScreenManager.popScreen();
            Game1.Instance.ScreenManager.pushScreen(new StoreScreen());
        }

        public override void Update(GameTime gameTime)
        {
            playButton.Update();   
        }

        public override void Render()
        {
            Game1.Instance.SpriteBatch.Draw(background, new Rectangle(0, 0, background.Width, background.Height), Color.White);
            playButton.Render();
            string nextLevel = "New Game";
            FontManager.Instance.Render(nextLevel, new Vector2(playButton.BoundingBox.X + playButton.BoundingBox.Width / 4, playButton.BoundingBox.Y + playButton.BoundingBox.Height / 2 - 12));
        }

        private void playButton_Hover(GuiButton b, ButtonArgs args)
        {
            b.FrameID = new Vector2(1, 0);
        }
    }
}
